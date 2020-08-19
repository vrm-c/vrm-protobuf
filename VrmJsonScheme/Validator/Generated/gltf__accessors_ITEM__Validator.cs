// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .accessors[{0}]
    public class gltf__accessors_ITEM__Validator
    {
        ValidationContext m_context;

        public gltf__accessors_ITEM__Validator(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            foreach(var kv in json.EnumerateObject())
            {

                if(kv.Name == "extensions")
                {
                    new gltf__accessors_ITEM__extensions__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "extras")
                {
                    new gltf__accessors_ITEM__extras__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "name")
                {
                    
                    continue;
                }

                if(kv.Name == "bufferView")
                {
                    
                    continue;
                }

                if(kv.Name == "byteOffset")
                {
                    
                {
                    if(kv.Value.ValueKind == JsonValueKind.Number)
                    {
                        var value = kv.Value.GetInt32();
                        if(value < 0)
                        {
                            m_context.AddMessage(MessageTypes.MinimumException, value, ".accessors[{0}].byteOffset", null);
                        }
                        else{
                            // OK
                        }
                    }
                    else{
                        m_context.AddMessage(MessageTypes.InvalidType, kv.Value, ".accessors[{0}].byteOffset", null);
                    }
                }


                    continue;
                }

                if(kv.Name == "componentType")
                {
                    
                    continue;
                }

                if(kv.Name == "normalized")
                {
                    
                    continue;
                }

                if(kv.Name == "count")
                {
                    
                {
                    if(kv.Value.ValueKind == JsonValueKind.Number)
                    {
                        var value = kv.Value.GetInt32();
                        if(value < 1)
                        {
                            m_context.AddMessage(MessageTypes.MinimumException, value, ".accessors[{0}].count", null);
                        }
                        else{
                            // OK
                        }
                    }
                    else{
                        m_context.AddMessage(MessageTypes.InvalidType, kv.Value, ".accessors[{0}].count", null);
                    }
                }


                    continue;
                }

                if(kv.Name == "type")
                {
                    
                    continue;
                }

                if(kv.Name == "max")
                {
                    new gltf__accessors_ITEM__max__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "min")
                {
                    new gltf__accessors_ITEM__min__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "sparse")
                {
                    new gltf__accessors_ITEM__sparse__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                // unknown key
                m_context.AddMessage(MessageTypes.UnknownProperty, kv.Value, ".accessors[{0}]", kv.Name);
            }
        }
    }

}
