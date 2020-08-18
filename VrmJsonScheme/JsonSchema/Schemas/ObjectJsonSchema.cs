using System;
using System.Collections.Generic;
using System.Linq;

namespace Vrm.JsonScheme.Schemas
{
    public class ObjectJsonSchema : JsonSchemaBase
    {
        public string[] Required;

        public ObjectJsonSchema(in JsonSchemaSource source) : base(source)
        {
            foreach (var kv in source.EnumerateProperties())
            {
                var prop = kv.Value.Create();
                if (prop is null)
                {
                    throw new NotImplementedException();
                }
                Properties.Add(kv.Key, prop);
            }
            Required = source.required;
        }

        public override string ToString()
        {
            var values = "";
            if (Required != null && Required.Any())
            {
                values = $" require: {{{string.Join(", ", Required)}}}";
            }
            return $"{base.ToString()}{values}";
        }

        public readonly Dictionary<string, JsonSchemaBase> Properties = new Dictionary<string, JsonSchemaBase>();
    }
}
