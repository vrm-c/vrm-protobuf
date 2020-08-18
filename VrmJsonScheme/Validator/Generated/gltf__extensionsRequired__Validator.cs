// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .extensionsRequired
    public class gltf__extensionsRequired__Validator
    {
        ValidationContext m_context;

        public gltf__extensionsRequired__Validator(ValidationContext context)
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
