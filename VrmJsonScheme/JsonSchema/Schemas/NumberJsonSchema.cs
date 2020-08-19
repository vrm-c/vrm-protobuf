namespace Vrm.JsonSchema.Schemas
{
    public class IntegerJsonSchema : JsonSchemaBase
    {
        public readonly int? Minimum;
        public readonly bool ExclusiveMinimum;
        public readonly int? Maximum;
        public readonly int? MultipleOf;

        public string IndexTargetJsonPath;

        public IntegerJsonSchema(in JsonSchemaSource source) : base(source)
        {
            if (source.minimum.HasValue)
            {
                Minimum = (int)source.minimum.Value;
            }
            ExclusiveMinimum = source.exclusiveMinimum;
            if (source.maximum.HasValue)
            {
                Maximum = (int)source.maximum.Value;
            }
            if (source.multipleOf.HasValue)
            {
                MultipleOf = (int)source.multipleOf.Value;
            }
        }
    }

    public class NumberJsonSchema : JsonSchemaBase
    {
        public readonly double? Minimum;
        public readonly bool ExclusiveMinimum;
        public readonly double? Maximum;
        public readonly double? MultipleOf;

        public NumberJsonSchema(in JsonSchemaSource source) : base(source)
        {
            if (source.minimum.HasValue)
            {
                Minimum = source.minimum.Value;
            }
            ExclusiveMinimum = source.exclusiveMinimum;
            if (source.maximum.HasValue)
            {
                Maximum = source.maximum.Value;
            }
            if (source.multipleOf.HasValue)
            {
                MultipleOf = source.multipleOf.Value;
            }
        }
    }

}