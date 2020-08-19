// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .extensions.EXT_lights_image_based.lights[{0}].extras
    public class gltf__extensions__EXT_lights_image_based__lights_ITEM__extras__Validator
    {
        ValidationContext m_context;

        public gltf__extensions__EXT_lights_image_based__lights_ITEM__extras__Validator(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            foreach(var kv in json.EnumerateObject())
            {

                // unknown key
                m_context.AddMessage(MessageTypes.UnknownProperty, kv.Value, ".extensions.EXT_lights_image_based.lights[{0}].extras", kv.Name);
            }
        }
    }

}
