using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Vrm.JsonScheme
{
    public class JsonSchemaParser
    {
        DirectoryInfo[] m_dir;
        Dictionary<FileInfo, byte[]> m_cache = new Dictionary<FileInfo, byte[]>();

        public JsonSchemaParser(params DirectoryInfo[] dir)
        {
            m_dir = dir;
        }

        public static JsonSchemaSource Parse(string root, string jsonPath = "")
        {
            // setup
            var path = new FileInfo(root);
            var parser = new JsonSchemaParser(path.Directory);

            // traverse
            return parser.Load(path.Name, jsonPath);
        }

        public JsonSchemaSource Load(string fileName, string jsonPath)
        {
            if (fileName == "glTFChildOfRootProperty.schema.json")
            {
                var a = 0;
            }
            if (fileName == "glTFid.schema.json")
            {
                var a = 0;
            }

            JsonSchemaSource loaded = null;
            foreach (var dir in m_dir)
            {
                var path = Path.Combine(dir.FullName, fileName);
                if (File.Exists(path))
                {
                    loaded = Load(new FileInfo(path), jsonPath);
                    break;
                }
            }

            if (loaded is null)
            {
                throw new FileNotFoundException(fileName);
            }
            return loaded;
        }

        public JsonSchemaSource Load(FileInfo path, string jsonPath)
        {
            var options = new JsonDocumentOptions
            {
            };

            if (!m_cache.TryGetValue(path, out byte[] bytes))
            {
                // Console.WriteLine($"load {path}");
                bytes = File.ReadAllBytes(path.FullName);
                m_cache.Add(path, bytes);
            }

            using (var document = JsonDocument.Parse(bytes, options))
            {
                var jsonSchema = Parse(document.RootElement, jsonPath);
                jsonSchema.FilePath = path;
                return jsonSchema;
            }
        }

        void MergeTo(JsonSchemaSource src, JsonSchemaSource dst)
        {
            if (string.IsNullOrEmpty(dst.title))
            {
                dst.title = src.title;
            }
            if (string.IsNullOrEmpty(dst.description))
            {
                dst.description = src.description;
            }
            if (src.type != JsonSchemaType.Unknown)
            {
                dst.type = src.type;
            }
            foreach (var (k, v) in src.EnumerateProperties())
            {
                dst.AddProperty(k, v);
            }
        }

        JsonSchemaSource Parse(JsonElement json, string jsonPath)
        {
            var source = new JsonSchemaSource
            {
                JsonPath = jsonPath,
            };

            foreach (var kv in json.EnumerateObject())
            {
                switch (kv.Name)
                {
                    case "$ref":
                        {
                            var reference = Load(kv.Value.GetString(), jsonPath);
                            MergeTo(reference, source);
                            break;
                        }

                    case "allOf":
                        // glTF では継承として使われる
                        {
                            var reference = AllOf(kv.Value, jsonPath);
                            MergeTo(reference, source);
                            break;
                        }

                    case "$schema":
                        break;

                    case "type":
                        source.type = (JsonSchemaType)Enum.Parse(typeof(JsonSchemaType), kv.Value.GetString(), true);
                        break;

                    case "title":
                        source.title = kv.Value.GetString();
                        break;

                    case "description":
                        source.description = kv.Value.GetString();
                        break;

                    case "gltf_detailedDescription":
                        source.gltfDetail = kv.Value.GetString();
                        break;

                    case "default":
                        break;

                    case "gltf_webgl":
                        break;

                    case "anyOf":
                        // glTF ではenumとして使われる
                        ParseAnyOfAsEnum(ref source, kv.Value);
                        break;

                    case "oneOf":
                        // TODO: union 的な
                        break;

                    case "not":
                        // TODO: プロパティの両立を禁止する、排他的な
                        break;

                    case "pattern":
                        source.pattern = kv.Value.GetString();
                        break;

                    case "format":
                        // TODO
                        break;

                    case "gltf_uriType":
                        // TODO
                        break;

                    case "minimum":
                        if (source.type != JsonSchemaType.Number && source.type != JsonSchemaType.Integer) throw new Exception();
                        source.minimum = kv.Value.GetDouble();
                        break;

                    case "exclusiveMinimum":
                        if (source.type != JsonSchemaType.Number && source.type != JsonSchemaType.Integer) throw new Exception();
                        source.exclusiveMinimum = kv.Value.GetBoolean(); // ?
                        break;

                    case "maximum":
                        if (source.type != JsonSchemaType.Number && source.type != JsonSchemaType.Integer) throw new Exception();
                        source.maximum = kv.Value.GetDouble();
                        break;

                    case "multipleOf":
                        if (source.type != JsonSchemaType.Number && source.type != JsonSchemaType.Integer) throw new Exception();
                        source.multipleOf = kv.Value.GetDouble();
                        break;

                    case "properties":
                        if (source.type != JsonSchemaType.Object) throw new Exception();
                        // source.properties = new Dictionary<string, JsonSchemaSource>();
                        foreach (var prop in kv.Value.EnumerateObject())
                        {
                            var propJsonPath = $"{jsonPath}.{prop.Name}";
                            var propSchema = Parse(prop.Value, propJsonPath);
                            if (propSchema is null)
                            {
                                if (source.baseSchema is null)
                                {
                                    // add empty object. extras
                                    source.AddProperty(prop.Name, new JsonSchemaSource
                                    {
                                        JsonPath = propJsonPath,
                                        type = JsonSchemaType.Object,
                                    });
                                }
                                // else if (source.baseSchema.GetPropertyFromPath(propJsonPath))
                                // {
                                //     // ok
                                // }
                                else
                                {
                                    throw new Exception("unknown");
                                }
                            }
                            else
                            {
                                if (source.GetProperty(prop.Name) == null)
                                {
                                    source.AddProperty(prop.Name, propSchema);
                                }
                            }
                        }
                        break;

                    case "required":
                        source.required = kv.Value.EnumerateArray().Select(x => x.GetString()).ToArray();
                        break;

                    case "dependencies":
                        // Property間の依存関係？
                        // TODO:
                        break;

                    case "additionalProperties":
                        if (source.type != JsonSchemaType.Object) throw new Exception();
                        if (kv.Value.ValueKind == JsonValueKind.Object)
                        {
                            source.additionalProperties = Parse(kv.Value, $"{jsonPath}{{}}");
                        }
                        else if (kv.Value.ValueKind == JsonValueKind.False)
                        {
                            // skip. do nothing
                        }
                        else
                        {
                            throw new NotImplementedException();
                        }
                        break;

                    case "minProperties":
                        if (source.type != JsonSchemaType.Object) throw new Exception();
                        source.minProperties = kv.Value.GetInt32();
                        break;

                    case "items":
                        if (source.type != JsonSchemaType.Array) throw new Exception();
                        source.items = Parse(kv.Value, $"{jsonPath}[]");
                        break;

                    case "uniqueItems":
                        if (source.type != JsonSchemaType.Array) throw new Exception();
                        source.uniqueItems = kv.Value.GetBoolean();
                        break;

                    case "maxItems":
                        if (source.type != JsonSchemaType.Array) throw new Exception();
                        source.maxItems = kv.Value.GetInt32();
                        break;

                    case "minItems":
                        if (source.type != JsonSchemaType.Array) throw new Exception();
                        source.minItems = kv.Value.GetInt32();
                        break;

                    case "enum":
                        if (source.type == JsonSchemaType.String)
                        {
                            ParseStringEnum(ref source, kv.Value);
                        }
                        else if (source.type == JsonSchemaType.Integer
                        || source.type == JsonSchemaType.Number)
                        {
                            throw new NotImplementedException();
                        }
                        else
                        {
                            throw new NotImplementedException();
                        }
                        break;

                    default:
                        Console.WriteLine($"unknown property: {kv.Name} => {kv.Value}");
                        break;
                }
            }

            return source;
        }

        void ParseStringEnum(ref JsonSchemaSource source, JsonElement json)
        {
            source.enumStringValues = json.EnumerateArray().Select(x => x.GetString()).ToArray();
            source.type = JsonSchemaType.EnumString;
        }

        void ParseAnyOfAsEnum(ref JsonSchemaSource source, JsonElement json)
        {
            List<int> values = new List<int>();
            List<string> stringValues = new List<string>();
            List<string> descriptions = new List<string>();
            foreach (var v in json.EnumerateArray())
            {
                foreach (var kv in v.EnumerateObject())
                {
                    switch (kv.Name)
                    {
                        case "enum":
                            {
                                int i = 0;
                                foreach (var a in kv.Value.EnumerateArray())
                                {
                                    if (a.ValueKind == JsonValueKind.Number)
                                    {
                                        values.Add(a.GetInt32());
                                    }
                                    else if (a.ValueKind == JsonValueKind.String)
                                    {
                                        stringValues.Add(a.GetString());
                                    }
                                    else
                                    {
                                        throw new NotImplementedException();
                                    }
                                    ++i;
                                }
                            }
                            break;

                        case "description":
                            {
                                descriptions.Add(kv.Value.GetString());
                            }
                            break;

                        case "type":
                            break;

                        default:
                            throw new NotImplementedException();
                    }
                }
            }

            if (stringValues.Count > 0)
            {
                if (values.Count == 0)
                {
                    source.enumStringValues = stringValues.ToArray();
                    source.type = JsonSchemaType.EnumString;
                    return;
                }
            }

            if (descriptions.Count == values.Count)
            {
                source.enumValues = new KeyValuePair<string, int>[values.Count];
                for (int i = 0; i < values.Count; ++i)
                {
                    source.enumValues[i] = new KeyValuePair<string, int>
                    (
                        descriptions[i],
                        values[i]
                    );
                }
                source.type = JsonSchemaType.Enum;
                return;
            }

            throw new NotImplementedException();
        }

        JsonSchemaSource AllOf(JsonElement json, string jsonPath)
        {
            string refValue = null;
            int count = 0;
            foreach (var a in json.EnumerateArray())
            {
                foreach (var kv in a.EnumerateObject())
                {
                    if (kv.Name != "$ref")
                    {
                        throw new NotImplementedException();
                    }

                    refValue = kv.Value.GetString();

                    ++count;
                }
            }
            if (count != 1)
            {
                throw new NotImplementedException();
            }

            var reference = Load(refValue, jsonPath);
            return reference;
        }
    }
}
