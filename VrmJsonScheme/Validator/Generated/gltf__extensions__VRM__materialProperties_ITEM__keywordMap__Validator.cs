// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .extensions.VRM.materialProperties[{0}].keywordMap
    public class gltf__extensions__VRM__materialProperties_ITEM__keywordMap__Validator
    {
        ValidationContext m_context;

        public gltf__extensions__VRM__materialProperties_ITEM__keywordMap__Validator(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            foreach(var kv in json.EnumerateObject())
            {
                m_context.Push(kv.Name);
                
                m_context.Pop();
            }
        }
    }

}
