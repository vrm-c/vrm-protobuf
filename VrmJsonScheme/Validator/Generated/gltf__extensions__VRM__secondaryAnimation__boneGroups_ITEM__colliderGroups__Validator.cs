// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .extensions.VRM.secondaryAnimation.boneGroups[{0}].colliderGroups
    public class gltf__extensions__VRM__secondaryAnimation__boneGroups_ITEM__colliderGroups__Validator
    {
        ValidationContext m_context;

        public gltf__extensions__VRM__secondaryAnimation__boneGroups_ITEM__colliderGroups__Validator(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            int i=0;
            foreach(var item in json.EnumerateArray())
            {
                m_context.Push(i++);
                
                m_context.Pop();
            }
        }
    }

}
