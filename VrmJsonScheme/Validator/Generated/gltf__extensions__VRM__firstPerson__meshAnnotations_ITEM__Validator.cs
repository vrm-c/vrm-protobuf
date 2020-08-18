// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .extensions.VRM.firstPerson.meshAnnotations[{0}]
    public class gltf__extensions__VRM__firstPerson__meshAnnotations_ITEM__Validator
    {
        ValidationContext m_context;

        public gltf__extensions__VRM__firstPerson__meshAnnotations_ITEM__Validator(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            foreach(var kv in json.EnumerateObject())
            {

                if(kv.Name == "mesh")
                {
                    
                    continue;
                }

                if(kv.Name == "firstPersonFlag")
                {
                    
                    continue;
                }

                // unknown key
                m_context.AddMessage(MessageTypes.UnknownProperty, kv.Value, ".extensions.VRM.firstPerson.meshAnnotations[{0}]", kv.Name);
            }
        }
    }

}
