// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .animations[{0}].channels[{1}].target.extensions
    public class gltf__animations_ITEM__channels_ITEM__target__extensions__Validator
    {
        ValidationContext m_context;

        public gltf__animations_ITEM__channels_ITEM__target__extensions__Validator(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            foreach(var kv in json.EnumerateObject())
            {

                // unknown key
                m_context.AddMessage(MessageTypes.UnknownProperty, kv.Value, ".animations[{0}].channels[{1}].target.extensions", kv.Name);
            }
        }
    }

}
