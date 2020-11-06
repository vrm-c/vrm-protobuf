using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Vrm.JsonSchema;
using Vrm.JsonSchema.Schemas;

namespace ProtoGenerator
{
    class ProtoNode
    {
        public readonly string Path;

        public readonly ObjectJsonSchema Schema;

        public ProtoNode Parent;

        public ProtoNode Root
        {
            get
            {
                if (Parent is null)
                {
                    return null;
                }
                var current = Parent;
                while (current.Parent != null)
                {
                    current = current.Parent;
                }
                return current;
            }
        }

        public readonly List<ProtoNode> Children = new List<ProtoNode>();

        public readonly List<string> Imports = new List<string>();

        public ProtoNode(string path, ObjectJsonSchema schema)
        {
            Path = path;
            Schema = schema;
        }

        public void Dump(string indent = "")
        {
            Console.WriteLine($"{indent}{Schema.JsonPath}");
            foreach (var child in Children)
            {
                child.Dump(indent + "  ");
            }
        }

        public void WriteTo(string path)
        {
            using (var s = new FileStream(path, FileMode.Create))
            using (var w = new StreamWriter(s, new UTF8Encoding(false)))
            {
                w.WriteLine("syntax = \"proto3\";");
                w.WriteLine("package VrmProtobuf;");

                w.WriteLine("import \"google/protobuf/wrappers.proto\";");
                foreach (var import in Imports)
                {
                    w.WriteLine($"import \"{import}\";");
                }

                w.WriteLine();

                WriteMessage(w);
            }
        }

        static List<string> s_used = new List<string>();

        static List<string> s_ignore = new List<string>{
            "Extension",
            "Extras",
        };

        static bool IsNestTitle(string title)
        {
            if (s_ignore.Contains(title))
            {
                return true;
            }
            return false;
        }

        void WriteMessage(StreamWriter w, string indent = "")
        {
            if (s_ignore.Contains(Schema.Title))
            {

            }
            else
            {
                if (s_used.Contains(Schema.Title))
                {
                    return;
                }
                s_used.Add(Schema.Title);
            }

            // not nest
            foreach (var child in Children)
            {
                if (child.Schema != null)
                {
                    if (IsNestTitle(child.Schema.Title))
                    {
                        // nest in message
                    }
                    else
                    {
                        child.WriteMessage(w, indent);
                    }
                }
            }

            int id = 1;
            w.WriteLine($"{indent}message {GetProtoType(Schema, true)}");
            w.WriteLine($"{indent}{{");
            foreach (var child in Children)
            {
                if (child.Schema != null)
                {
                    if (IsNestTitle(child.Schema.Title))
                    {
                        child.WriteMessage(w, indent + "  ");
                    }
                }
            }

            var usedEnumName = new HashSet<string>();

            foreach (var kv in Schema.Properties)
            {
                if (kv.Value is null)
                {
                    continue;
                }

                if (kv.Value is EnumStringJsonSchema enumSchema)
                {
                    var enumName = GetProtoType(enumSchema, true);
                    if (!usedEnumName.Contains(enumName))
                    {
                        // unique enum
                        usedEnumName.Add(enumName);
                        w.WriteLine();
                        w.WriteLine($"{indent}  enum {enumName} {{");

                        int i = 0;
                        foreach (var value in enumSchema.Values)
                        {
                            w.WriteLine($"{indent}    {value} = {i++};");
                        }
                        w.WriteLine($"{indent}  }}");
                    }
                }

                if (id > 1)
                {
                    w.WriteLine();
                }

                // // if (kv.Value.ClassName.EndsWith("__extensions")
                // // || kv.Value.ClassName.EndsWith("__extras"))
                // if (kv.Value.JsonSchemaType == JsonSchemaType.Object)
                // {
                //     WriteMessage(w, kv.Value as ObjectJsonSchema, indent + "  ");
                // }

                w.WriteLine($"{indent}  // {kv.Value.Description}");
                var required = Schema.Required?.Contains(kv.Key);
                w.WriteLine($"{indent}  {GetProtoType(kv.Value, required.GetValueOrDefault())} {kv.Key} = {id++};");
            }
            w.WriteLine($"{indent}}}");
        }

        static string GetProtoType(ArrayJsonSchema s)
        {
            return $"repeated {GetProtoType(s.Items, true)}";
        }

        static string GetProtoType(JsonSchemaBase s, bool required)
        {
            switch (s.JsonSchemaType)
            {
                case JsonSchemaType.EnumString:
                    if (!string.IsNullOrEmpty(s.Title))
                    {
                        return s.Title.Replace(" ", "");
                    }
                    else
                    {
                        var name = s.ClassName.Split("__").Last();
                        if (name == "type")
                        {
                            if (s.JsonPath == ".cameras[].type")
                            {
                                return "cameraType";
                            }
                            else if (s.JsonPath == ".accessors[].type")
                            {
                                return "accessorType";
                            }
                            else
                            {
                                throw new NotImplementedException();
                            }
                        }

                        if (name == "alphaMode"
                        || name == "interpolation"
                        || name == "path")
                        {
                            return name + "Type";
                        }
                        else
                        {
                            return name;
                        }
                    }

                case JsonSchemaType.Object:
                    if (s is DictionaryJsonSchema d)
                    {
                        return $"map<string, {GetProtoType(d.AdditionalProperties, true)}>";
                    }
                    else
                    {
                        if (s.ClassName.EndsWith("__extras"))
                        {
                            return "Extras";
                        }
                        else if (s.ClassName.EndsWith("__extensions"))
                        {
                            return "Extensions";
                        }
                        else
                        {
                            return s.Title?.Replace(" ", "");
                        }
                    }

                case JsonSchemaType.String:
                    return "string";

                case JsonSchemaType.Boolean:
                    if (required)
                    {
                        return "bool";
                    }
                    else
                    {
                        return "google.protobuf.BoolValue";
                    }

                case JsonSchemaType.Enum:
                case JsonSchemaType.Integer:
                    if (required)
                    {
                        return "int32";
                    }
                    else
                    {
                        return "google.protobuf.Int32Value";
                    }

                case JsonSchemaType.Number:
                    if (required)
                    {
                        return "float";
                    }
                    else
                    {
                        return "google.protobuf.FloatValue";
                    }

                case JsonSchemaType.Array:
                    return GetProtoType(s as ArrayJsonSchema);

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
