// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .animations
    public class gltf__animations__Validator
    {
        ValidationContext m_context;

        public gltf__animations__Validator(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            int i=0;
            foreach(var item in json.EnumerateArray())
            {
                m_context.Push(i++);
                new gltf__animations_ITEM__Validator(m_context).Validate(item);
                m_context.Pop();
            }
        }
    }

}
