// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .bufferViews[{0}]
    public class gltf__bufferViews_ITEM__Validator
    {
        ValidationContext m_context;

        public gltf__bufferViews_ITEM__Validator(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            foreach(var kv in json.EnumerateObject())
            {

                if(kv.Name == "extensions")
                {
                    new gltf__bufferViews_ITEM__extensions__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "extras")
                {
                    new gltf__bufferViews_ITEM__extras__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "name")
                {
                    
                    continue;
                }

                if(kv.Name == "buffer")
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
                            m_context.AddMessage(MessageTypes.MinimumException, value, ".bufferViews[{0}].byteOffset", null);
                        }
                        else{
                            // OK
                        }
                    }
                    else{
                        m_context.AddMessage(MessageTypes.InvalidType, kv.Value, ".bufferViews[{0}].byteOffset", null);
                    }
                }


                    continue;
                }

                if(kv.Name == "byteLength")
                {
                    
                {
                    if(kv.Value.ValueKind == JsonValueKind.Number)
                    {
                        var value = kv.Value.GetInt32();
                        if(value < 1)
                        {
                            m_context.AddMessage(MessageTypes.MinimumException, value, ".bufferViews[{0}].byteLength", null);
                        }
                        else{
                            // OK
                        }
                    }
                    else{
                        m_context.AddMessage(MessageTypes.InvalidType, kv.Value, ".bufferViews[{0}].byteLength", null);
                    }
                }


                    continue;
                }

                if(kv.Name == "byteStride")
                {
                    
                {
                    if(kv.Value.ValueKind == JsonValueKind.Number)
                    {
                        var value = kv.Value.GetInt32();
                        if(value < 4)
                        {
                            m_context.AddMessage(MessageTypes.MinimumException, value, ".bufferViews[{0}].byteStride", null);
                        }
                        else{
                            // OK
                        }
                    }
                    else{
                        m_context.AddMessage(MessageTypes.InvalidType, kv.Value, ".bufferViews[{0}].byteStride", null);
                    }
                }


                    continue;
                }

                if(kv.Name == "target")
                {
                    
                    continue;
                }

                // unknown key
                m_context.AddMessage(MessageTypes.UnknownProperty, kv.Value, ".bufferViews[{0}]", kv.Name);
            }
        }
    }

}
