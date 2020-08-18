// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .meshes[{0}].primitives[{1}].targets
    public class gltf__meshes_ITEM__primitives_ITEM__targets__Validator
    {
        ValidationContext m_context;

        public gltf__meshes_ITEM__primitives_ITEM__targets__Validator(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            int i=0;
            foreach(var item in json.EnumerateArray())
            {
                m_context.Push(i++);
                new gltf__meshes_ITEM__primitives_ITEM__targets_ITEM__Validator(m_context).Validate(item);
                m_context.Pop();
            }
        }
    }

}
