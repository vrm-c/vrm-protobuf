// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .skins
    public class gltf__skins__Validator
    {
        ValidationContext m_context;

        public gltf__skins__Validator(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            int i=0;
            foreach(var item in json.EnumerateArray())
            {
                m_context.Push(i++);
                new gltf__skins_ITEM__Validator(m_context).Validate(item);
                m_context.Pop();
            }
        }
    }

}
