// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .meshes[{0}].primitives[{1}].targets[{2}]
    public class gltf__meshes_ITEM__primitives_ITEM__targets_ITEM__Validator
    {
        ValidationContext m_context;

        public gltf__meshes_ITEM__primitives_ITEM__targets_ITEM__Validator(ValidationContext context)
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
