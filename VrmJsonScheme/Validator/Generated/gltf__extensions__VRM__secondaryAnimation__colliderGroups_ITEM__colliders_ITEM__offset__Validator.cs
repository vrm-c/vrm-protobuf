// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .extensions.VRM.secondaryAnimation.colliderGroups[{0}].colliders[{1}].offset
    public class gltf__extensions__VRM__secondaryAnimation__colliderGroups_ITEM__colliders_ITEM__offset__Validator
    {
        ValidationContext m_context;

        public gltf__extensions__VRM__secondaryAnimation__colliderGroups_ITEM__colliders_ITEM__offset__Validator(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            foreach(var kv in json.EnumerateObject())
            {

                if(kv.Name == "x")
                {
                    
                    continue;
                }

                if(kv.Name == "y")
                {
                    
                    continue;
                }

                if(kv.Name == "z")
                {
                    
                    continue;
                }

                // unknown key
                m_context.AddMessage(MessageTypes.UnknownProperty, kv.Value, ".extensions.VRM.secondaryAnimation.colliderGroups[{0}].colliders[{1}].offset", kv.Name);
            }
        }
    }

}
