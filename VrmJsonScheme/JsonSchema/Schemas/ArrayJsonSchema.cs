using System;

namespace Vrm.JsonScheme.Schemas
{
    public class ArrayJsonSchema : JsonSchemaBase
    {
        public readonly JsonSchemaBase Items;
        public readonly bool UniqueItems;
        public readonly int MinItems;
        public readonly int? MaxItems;

        public ArrayJsonSchema(in JsonSchemaSource source) : base(source)
        {
            Items = source.items.Create();
            UniqueItems = source.uniqueItems.GetValueOrDefault();
            MinItems = source.minItems.GetValueOrDefault();
            if (source.maxItems.HasValue)
            {
                MaxItems = source.maxItems.Value;
            }
        }
    }
}
