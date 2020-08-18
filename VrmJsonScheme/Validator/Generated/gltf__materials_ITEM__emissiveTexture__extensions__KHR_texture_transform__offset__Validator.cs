// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .materials[{0}].emissiveTexture.extensions.KHR_texture_transform.offset
    public class gltf__materials_ITEM__emissiveTexture__extensions__KHR_texture_transform__offset__Validator
    {
        ValidationContext m_context;

        public gltf__materials_ITEM__emissiveTexture__extensions__KHR_texture_transform__offset__Validator(ValidationContext context)
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
