// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .asset.extensions
    public class gltf__asset__extensions__Validator
    {
        ValidationContext m_context;

        public gltf__asset__extensions__Validator(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            foreach(var kv in json.EnumerateObject())
            {

                // unknown key
                m_context.AddMessage(MessageTypes.UnknownProperty, kv.Value, ".asset.extensions", kv.Name);
            }
        }
    }

}
