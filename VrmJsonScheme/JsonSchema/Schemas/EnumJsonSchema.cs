using System;
using System.Linq;

namespace Vrm.JsonScheme.Schemas
{
    public struct EnumValue
    {
        public string Name;
        public int Value;

        public override string ToString()
        {
            return $"{Name}={Value}";
        }
    }

    public class EnumJsonSchema : JsonSchemaBase
    {
        public readonly EnumValue[] Values;

        public EnumJsonSchema(in JsonSchemaSource source) : base(source)
        {
            Values = source.enumValues.Select(x => new EnumValue
            {
                Name = x.Key,
                Value = x.Value
            }).ToArray();
        }

        public override string ToString()
        {
            var values = string.Join(", ", Values);
            return $"{base.ToString()} {{{values}}}";
        }
    }

    public class EnumStringJsonSchema : JsonSchemaBase
    {
        public readonly String[] Values;

        public EnumStringJsonSchema(in JsonSchemaSource source) : base(source)
        {
            Values = source.enumStringValues;
        }

        public override string ToString()
        {
            var values = string.Join(", ", Values);
            return $"{base.ToString()} {{{values}}}";
        }
    }
}
