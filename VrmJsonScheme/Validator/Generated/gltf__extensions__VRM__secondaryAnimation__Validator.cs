// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .extensions.VRM.secondaryAnimation
    public class gltf__extensions__VRM__secondaryAnimation__Validator
    {
        ValidationContext m_context;

        public gltf__extensions__VRM__secondaryAnimation__Validator(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            foreach(var kv in json.EnumerateObject())
            {

                if(kv.Name == "boneGroups")
                {
                    new gltf__extensions__VRM__secondaryAnimation__boneGroups__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "colliderGroups")
                {
                    new gltf__extensions__VRM__secondaryAnimation__colliderGroups__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                // unknown key
                m_context.AddMessage(MessageTypes.UnknownProperty, kv.Value, ".extensions.VRM.secondaryAnimation", kv.Name);
            }
        }
    }

}
