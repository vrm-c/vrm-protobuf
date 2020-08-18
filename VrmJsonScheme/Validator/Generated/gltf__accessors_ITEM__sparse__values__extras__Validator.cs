// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .accessors[{0}].sparse.values.extras
    public class gltf__accessors_ITEM__sparse__values__extras__Validator
    {
        ValidationContext m_context;

        public gltf__accessors_ITEM__sparse__values__extras__Validator(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            foreach(var kv in json.EnumerateObject())
            {

                // unknown key
                m_context.AddMessage(MessageTypes.UnknownProperty, kv.Value, ".accessors[{0}].sparse.values.extras", kv.Name);
            }
        }
    }

}
