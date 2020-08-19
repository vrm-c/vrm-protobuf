// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .extensions.VRM.materialProperties[{0}].vectorProperties[{1}]
    public class gltf__extensions__VRM__materialProperties_ITEM__vectorProperties_PROP__Validator
    {
        ValidationContext m_context;

        public gltf__extensions__VRM__materialProperties_ITEM__vectorProperties_PROP__Validator(ValidationContext context)
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
