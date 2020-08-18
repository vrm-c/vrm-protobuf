// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .skins[{0}].extras
    public class gltf__skins_ITEM__extras__Validator
    {
        ValidationContext m_context;

        public gltf__skins_ITEM__extras__Validator(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            foreach(var kv in json.EnumerateObject())
            {

                // unknown key
                m_context.AddMessage(MessageTypes.UnknownProperty, kv.Value, ".skins[{0}].extras", kv.Name);
            }
        }
    }

}
