// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .materials[{0}].emissiveTexture.extensions
    public class gltf__materials_ITEM__emissiveTexture__extensions__Validator
    {
        ValidationContext m_context;

        public gltf__materials_ITEM__emissiveTexture__extensions__Validator(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            foreach(var kv in json.EnumerateObject())
            {

                if(kv.Name == "KHR_texture_transform")
                {
                    new gltf__materials_ITEM__emissiveTexture__extensions__KHR_texture_transform__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                // unknown key
                m_context.AddMessage(MessageTypes.UnknownProperty, kv.Value, ".materials[{0}].emissiveTexture.extensions", kv.Name);
            }
        }
    }

}
