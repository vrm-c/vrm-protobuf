// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .nodes[{0}].extensions
    public class gltf__nodes_ITEM__extensions__Validator
    {
        ValidationContext m_context;

        public gltf__nodes_ITEM__extensions__Validator(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            foreach(var kv in json.EnumerateObject())
            {

                // unknown key
                m_context.AddMessage(MessageTypes.UnknownProperty, kv.Value, ".nodes[{0}].extensions", kv.Name);
            }
        }
    }

}
