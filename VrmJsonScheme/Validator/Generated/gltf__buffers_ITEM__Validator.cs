// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .buffers[{0}]
    public class gltf__buffers_ITEM__Validator
    {
        ValidationContext m_context;

        public gltf__buffers_ITEM__Validator(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            foreach(var kv in json.EnumerateObject())
            {

                if(kv.Name == "extensions")
                {
                    new gltf__buffers_ITEM__extensions__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "extras")
                {
                    new gltf__buffers_ITEM__extras__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "name")
                {
                    
                    continue;
                }

                if(kv.Name == "uri")
                {
                    
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
                            m_context.AddMessage(MessageTypes.MinimumException, value, ".buffers[{0}].byteLength", null);
                        }
                        else{
                            // OK
                        }
                    }
                    else{
                        m_context.AddMessage(MessageTypes.InvalidType, kv.Value, ".buffers[{0}].byteLength", null);
                    }
                }


                    continue;
                }

                // unknown key
                m_context.AddMessage(MessageTypes.UnknownProperty, kv.Value, ".buffers[{0}]", kv.Name);
            }
        }
    }

}
