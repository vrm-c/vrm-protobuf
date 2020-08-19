// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .extensions.VRM.secondaryAnimation.colliderGroups[{0}]
    public class gltf__extensions__VRM__secondaryAnimation__colliderGroups_ITEM__Validator
    {
        ValidationContext m_context;

        public gltf__extensions__VRM__secondaryAnimation__colliderGroups_ITEM__Validator(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            foreach(var kv in json.EnumerateObject())
            {

                if(kv.Name == "node")
                {
                    
                    continue;
                }

                if(kv.Name == "colliders")
                {
                    new gltf__extensions__VRM__secondaryAnimation__colliderGroups_ITEM__colliders__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                // unknown key
                m_context.AddMessage(MessageTypes.UnknownProperty, kv.Value, ".extensions.VRM.secondaryAnimation.colliderGroups[{0}]", kv.Name);
            }
        }
    }

}
