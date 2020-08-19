// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .extensions.EXT_lights_image_based
    public class gltf__extensions__EXT_lights_image_based__Validator
    {
        ValidationContext m_context;

        public gltf__extensions__EXT_lights_image_based__Validator(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            foreach(var kv in json.EnumerateObject())
            {

                if(kv.Name == "extensions")
                {
                    new gltf__extensions__EXT_lights_image_based__extensions__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "extras")
                {
                    new gltf__extensions__EXT_lights_image_based__extras__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "lights")
                {
                    new gltf__extensions__EXT_lights_image_based__lights__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                // unknown key
                m_context.AddMessage(MessageTypes.UnknownProperty, kv.Value, ".extensions.EXT_lights_image_based", kv.Name);
            }
        }
    }

}
