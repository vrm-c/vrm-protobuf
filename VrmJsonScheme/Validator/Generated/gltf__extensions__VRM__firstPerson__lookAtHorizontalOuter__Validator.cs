// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .extensions.VRM.firstPerson.lookAtHorizontalOuter
    public class gltf__extensions__VRM__firstPerson__lookAtHorizontalOuter__Validator
    {
        ValidationContext m_context;

        public gltf__extensions__VRM__firstPerson__lookAtHorizontalOuter__Validator(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            foreach(var kv in json.EnumerateObject())
            {

                if(kv.Name == "curve")
                {
                    new gltf__extensions__VRM__firstPerson__lookAtHorizontalOuter__curve__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "xRange")
                {
                    
                    continue;
                }

                if(kv.Name == "yRange")
                {
                    
                    continue;
                }

                // unknown key
                m_context.AddMessage(MessageTypes.UnknownProperty, kv.Value, ".extensions.VRM.firstPerson.lookAtHorizontalOuter", kv.Name);
            }
        }
    }

}
