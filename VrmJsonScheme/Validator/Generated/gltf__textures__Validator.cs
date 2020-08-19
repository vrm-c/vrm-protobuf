// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .textures
    public class gltf__textures__Validator
    {
        ValidationContext m_context;

        public gltf__textures__Validator(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            int i=0;
            foreach(var item in json.EnumerateArray())
            {
                m_context.Push(i++);
                new gltf__textures_ITEM__Validator(m_context).Validate(item);
                m_context.Pop();
            }
        }
    }

}
