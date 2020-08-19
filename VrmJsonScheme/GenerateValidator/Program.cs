using System;
using System.IO;
using Vrm.JsonSchema;
using Vrm.JsonSchema.Schemas;

namespace VrmValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                // USAGE
                return;
            }
            var root = new FileInfo(args[0]);
            var parser = new JsonSchemaParser(root.Directory);
            var jsonSchema = parser.Load(root.Name, "");

            // add extensions
            jsonSchema.AddJsonPath(".materials[].extensions.KHR_materials_unlit", new JsonSchemaSource
            {
                type = JsonSchemaType.Object,
            });
            jsonSchema.AddJsonPath(".meshes[].primitives[].extras.targetNames", new JsonSchemaSource
            {
                type = JsonSchemaType.Array,
                items = new JsonSchemaSource
                {
                    JsonPath = ".meshes[].primitives[].extras.targetNames[]",
                    type = JsonSchemaType.String,
                },
            });

            for (int i = 2; i < args.Length; i += 2)
            {
                var jsonPath = args[i];
                var extensionSchemaPath = new FileInfo(args[i + 1]);
                var extensionParser = new JsonSchemaParser(root.Directory, extensionSchemaPath.Directory);
                var extensionSchema = extensionParser.Load(extensionSchemaPath, jsonPath);
                var (parent, child) = JsonSchemaSource.SplitParent(jsonPath);
                jsonSchema.Get(parent).AddProperty(child, extensionSchema);
            }

            foreach (var source in jsonSchema.Traverse())
            {
                var schema = source.Create();
                // index 項を列挙する
                if (IndexTargets.Map.TryGetValue(schema.JsonPath, out string target))
                {
                    if (schema is IntegerJsonSchema index)
                    {
                        Console.WriteLine($"{schema.JsonPath} => {target}");
                        index.IndexTargetJsonPath = target;
                    }
                    else
                    {
                        throw new NotImplementedException();
                    }
                }
                else
                {
                    // Console.WriteLine(schema.JsonPath);
                }

                if (schema.JsonPath == ".extensions.VRM.blendShapeMaster.blendShapeGroups[].binds[]")
                {
                    // 特別処理
                    schema.HardCode = @"
                // 対象の morph が存在していることを確認する
                var meshProp = json.GetProperty(""mesh"");
                var indexProp = json.GetProperty(""index"");                
                if(meshProp.ValueKind == JsonValueKind.Number
                    && indexProp.ValueKind == JsonValueKind.Number)
                {
                    var mesh = meshProp.GetInt32();
                    if(mesh<0)
                    {
                        m_context.AddMessage(MessageTypes.MinimumException, mesh, ""${json_path}"", ""mesh"");
                    }
                    else{
                        var jsonPath = string.Format("".meshes[{0}].primitives[*].targets"" , mesh);
                        if(m_context.TryGetArrayLength(jsonPath, out int length))
                        {
                            var index = indexProp.GetInt32();
                            if(index<0)
                            {
                                m_context.AddMessage(MessageTypes.MinimumException, index, ""${json_path}"", ""index"");
                            }
                            else if(index >= length)
                            {
                                m_context.AddMessage(MessageTypes.ArrayExceedLength, index, ""${json_path}"", ""index"");
                            }
                            else{
                                // OK
                            }
                        }
                        else
                        {
                            m_context.AddMessage(MessageTypes.ArrayNotExists, mesh, ""${json_path}"", ""mesh"");
                        }
                    }
                }
                else{
                    m_context.AddMessage(MessageTypes.InvalidType, json, ""${json_path}"", null);
                }
";
                }
            }

            if (args.Length < 2)
            {
                return;
            }

            var config = new ValidatorGenerator.Configuration
            {
                Prefix = "gltf",
                Suffix = "__Validator",
            };
            ValidatorGenerator.GenerateTo(jsonSchema, new DirectoryInfo(args[1]), config, true);
        }
    }
}
