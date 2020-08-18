using System;
using System.IO;
using System.Linq;
using Vrm.JsonScheme;

namespace ProtoGenerator
{
    static class Generator
    {
        static void ClearFolder(DirectoryInfo dir)
        {
            Console.WriteLine($"clear: {dir}");

            foreach (FileInfo file in dir.GetFiles())
            {
                file.Delete();
            }

            foreach (DirectoryInfo child in dir.GetDirectories())
            {
                child.Delete(true);
            }
        }

        public static void Fix(JsonSchemaSource obj)
        {
            if (obj.title == "Mesh Primitive")
            {
                // repeated map<string, int32> targets = 7;
                var items = new JsonSchemaSource
                {
                    JsonPath = "",
                    type = JsonSchemaType.Object,
                    title = "target",
                };
                items.AddProperty("POSITION", new JsonSchemaSource
                {
                    JsonPath = "",
                    type = JsonSchemaType.Integer,
                    title = "POSITION",
                });
                items.AddProperty("NORMAL", new JsonSchemaSource
                {
                    JsonPath = "",
                    type = JsonSchemaType.Integer,
                    title = "TARGET",
                });
                items.AddProperty("TANGENT", new JsonSchemaSource
                {
                    JsonPath = "",
                    type = JsonSchemaType.Integer,
                    title = "TANGENT",
                });

                obj.GetProperty("targets", true);
                obj.AddProperty("targets", new JsonSchemaSource
                {
                    JsonPath = "",
                    type = JsonSchemaType.Array,
                    items = items,
                    title = "targets",
                    description = "An array of Morph Targets, each  Morph Target is a dictionary mapping attributes (only `POSITION`, `NORMAL`, and `TANGENT` supported) to their deviations in the Morph Target.",
                });
                return;
            }

            if (obj.title == "Image")
            {
                var mimeType = obj.GetProperty("mimeType", true);
                obj.AddProperty("mimeType", new JsonSchemaSource
                {
                    JsonPath = mimeType.JsonPath,
                    type = JsonSchemaType.String,
                    title = mimeType.title,
                    description = mimeType.description,
                });
                return;
            }

            if (obj.title == "Camera")
            {
                var type = obj.GetProperty("type", true);
                obj.AddProperty("type", new JsonSchemaSource
                {
                    JsonPath = type.JsonPath,
                    type = JsonSchemaType.String,
                    title = type.title,
                    description = type.description,
                });
                return;
            }
        }

        public static void GenerateTo(JsonSchemaSource root, DirectoryInfo dir, bool clearFolder)
        {
            // clear or create folder
            if (dir.Exists)
            {
                if (dir.EnumerateFileSystemInfos().Any())
                {
                    if (!clearFolder)
                    {
                        Console.WriteLine($"{dir} is not empty.");
                        return;
                    }

                    // clear
                    ClearFolder(dir);
                }
            }
            else
            {
                Console.WriteLine($"create: {dir}");
                dir.Create();
            }

            var d = new ProtoNodeDistributer();
            d.Distribute(root);

            // 各ファイルに出力する
            foreach (var node in d.Roots)
            {
                Console.WriteLine($"## file: {node.Path} ##");
                node.Dump();
                node.WriteTo(Path.Combine(dir.FullName, node.Path));
            }

            // write google/protobuf/wrappers.proto
            {
                Directory.CreateDirectory(Path.Combine(dir.FullName, "google/protobuf"));
                File.WriteAllText(Path.Combine(dir.FullName, "google/protobuf/wrappers.proto"), Wrappers.Source);
            }
        }
    }
}
