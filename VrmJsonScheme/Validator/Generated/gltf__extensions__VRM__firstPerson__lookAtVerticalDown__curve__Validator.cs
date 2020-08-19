// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .extensions.VRM.firstPerson.lookAtVerticalDown.curve
    public class gltf__extensions__VRM__firstPerson__lookAtVerticalDown__curve__Validator
    {
        ValidationContext m_context;

        public gltf__extensions__VRM__firstPerson__lookAtVerticalDown__curve__Validator(ValidationContext context)
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
