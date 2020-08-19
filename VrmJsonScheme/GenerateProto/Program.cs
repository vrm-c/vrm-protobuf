using System.IO;
using Vrm.JsonSchema;

namespace ProtoGenerator
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
            var source = parser.Load(root.Name, "");

            // extra
            source.AddJsonPath(".meshes[].primitives[].extras.targetNames", new JsonSchemaSource
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
                {
                    var parentSchema = source.Get(parent);
                    parentSchema.AddProperty(child, extensionSchema);
                }
            }

            source.Dump();

            if (args.Length < 2)
            {
                return;
            }

            ProtoGenerator.Generator.GenerateTo(source, new DirectoryInfo(args[1]), clearFolder: true);
        }
    }
}
