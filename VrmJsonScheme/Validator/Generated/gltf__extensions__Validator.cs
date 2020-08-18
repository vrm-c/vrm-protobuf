// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .extensions
    public class gltf__extensions__Validator
    {
        ValidationContext m_context;

        public gltf__extensions__Validator(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            foreach(var kv in json.EnumerateObject())
            {

                if(kv.Name == "EXT_lights_image_based")
                {
                    new gltf__extensions__EXT_lights_image_based__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "VRM")
                {
                    new gltf__extensions__VRM__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                // unknown key
                m_context.AddMessage(MessageTypes.UnknownProperty, kv.Value, ".extensions", kv.Name);
            }
        }
    }

}
