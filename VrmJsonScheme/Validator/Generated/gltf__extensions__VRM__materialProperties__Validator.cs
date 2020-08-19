// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .extensions.VRM.materialProperties
    public class gltf__extensions__VRM__materialProperties__Validator
    {
        ValidationContext m_context;

        public gltf__extensions__VRM__materialProperties__Validator(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            int i=0;
            foreach(var item in json.EnumerateArray())
            {
                m_context.Push(i++);
                new gltf__extensions__VRM__materialProperties_ITEM__Validator(m_context).Validate(item);
                m_context.Pop();
            }
        }
    }

}
