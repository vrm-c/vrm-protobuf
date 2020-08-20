using System.Collections.Generic;
using System.Linq;
using Vrm.JsonSchema;

namespace ProtoGenerator
{
    /// <summary>
    /// ファイルに分配する
    /// </summary>
    class ProtoNodeDistributer
    {
        public readonly List<ProtoNode> Roots = new List<ProtoNode>();

        static Dictionary<string, (string, string)> s_fileMap = new Dictionary<string, (string, string)>
        {
            {".materials[].extensions.VRMC_materials_mtoon", ("VRMC_materials_mtoon.proto", "glTF.proto")},
            {".extensions.VRMC_vrm", ("VRMC_vrm.proto", "glTF.proto")},
            {".nodes[].extensions.VRMC_node_collider", ("VRMC_node_collider.proto", "glTF.proto")},
            {".extensions.VRMC_springBone", ("VRMC_springBone.proto", "glTF.proto")},
            {".extensions.VRMC_constraint", ("VRMC_constraint.proto", "glTF.proto")},
        };

        /// <summary>
        /// ファイル分割を決める
        /// </summary>
        /// <param name="schema"></param>
        /// <returns></returns>
        static (string, string) GetFilePath(string jsonPath)
        {
            foreach (var kv in s_fileMap)
            {
                if (jsonPath.StartsWith(kv.Key))
                {
                    return kv.Value;
                }
            }

            // gltf
            return ("glTF.proto", "");
        }

        public void Distribute(JsonSchemaSource source, ProtoNode current = null)
        {
            ProtoNode node;
            if (source.type == JsonSchemaType.Object)
            {
                // special case
                Generator.Fix(source);

                var (path, parent) = GetFilePath(source.JsonPath);
                var obj = source.Create() as Vrm.JsonSchema.Schemas.ObjectJsonSchema;
                if (obj != null)
                {
                    node = new ProtoNode(path, obj);
                    node.Parent = current;
                    if (current == null || current.Path != path)
                    {
                        // new path
                        if (!Roots.Any(x => x.Path == path))
                        {
                            // add import
                            node.Root?.Imports.Add(path);
                            Roots.Add(node);
                        }
                    }
                    else if (current != null)
                    {
                        current.Children.Add(node);
                    }
                }
                else
                {
                    node = current;
                }
            }
            else
            {
                node = current;
            }

            foreach (var child in source.Children())
            {
                Distribute(child, node);
            }
        }
    }
}
