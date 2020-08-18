// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .accessors[{0}].min
    public class gltf__accessors_ITEM__min__Validator
    {
        ValidationContext m_context;

        public gltf__accessors_ITEM__min__Validator(ValidationContext context)
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
