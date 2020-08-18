namespace Vrm.JsonScheme.Schemas
{
    public class StringJsonSchema : JsonSchemaBase
    {
        public readonly string Pattern;

        public StringJsonSchema(in JsonSchemaSource source) : base(source)
        {
            Pattern = source.pattern;
        }
    }
}
