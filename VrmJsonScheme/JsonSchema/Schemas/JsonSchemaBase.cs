using System.Text;

namespace Vrm.JsonSchema.Schemas
{
    public class JsonSchemaBase
    {
        public readonly string JsonPath;

        public string ClassName => JsonPath
                .Replace(".", "__")
                .Replace("[]", "_ITEM")
                .Replace("{}", "_PROP")
                ;

        public readonly JsonSchemaType JsonSchemaType;
        public readonly string Title;
        public readonly string Description;

        /// HardCoding
        public string HardCode;

        public JsonSchemaBase(in JsonSchemaSource source)
        {
            JsonPath = source.JsonPath;
            JsonSchemaType = source.type;
            Title = source.title;
            Description = source.description;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("[");
            sb.Append(JsonSchemaType);
            sb.Append("]");
            if (!string.IsNullOrEmpty(Title))
            {
                sb.Append($" \"{Title}\"");
            }
            return sb.ToString();
        }
    }
}
