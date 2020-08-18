// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .scenes[{0}].extensions.EXT_lights_image_based.extras
    public class gltf__scenes_ITEM__extensions__EXT_lights_image_based__extras__Validator
    {
        ValidationContext m_context;

        public gltf__scenes_ITEM__extensions__EXT_lights_image_based__extras__Validator(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            foreach(var kv in json.EnumerateObject())
            {

                // unknown key
                m_context.AddMessage(MessageTypes.UnknownProperty, kv.Value, ".scenes[{0}].extensions.EXT_lights_image_based.extras", kv.Name);
            }
        }
    }

}
