// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .meshes[{0}].primitives[{1}].extras.targetNames
    public class gltf__meshes_ITEM__primitives_ITEM__extras__targetNames__Validator
    {
        ValidationContext m_context;

        public gltf__meshes_ITEM__primitives_ITEM__extras__targetNames__Validator(ValidationContext context)
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
