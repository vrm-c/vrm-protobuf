using System;

namespace Vrm.JsonScheme.Schemas
{
    public class DictionaryJsonSchema : JsonSchemaBase
    {
        public readonly JsonSchemaBase AdditionalProperties;

        public readonly int MinProperties;

        public DictionaryJsonSchema(in JsonSchemaSource source) : base(source)
        {
            AdditionalProperties = source.additionalProperties.Create();
            MinProperties = source.minProperties.GetValueOrDefault();
        }
    }
}
