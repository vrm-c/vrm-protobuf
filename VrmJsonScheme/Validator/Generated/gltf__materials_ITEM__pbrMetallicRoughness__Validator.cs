// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .materials[{0}].pbrMetallicRoughness
    public class gltf__materials_ITEM__pbrMetallicRoughness__Validator
    {
        ValidationContext m_context;

        public gltf__materials_ITEM__pbrMetallicRoughness__Validator(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            foreach(var kv in json.EnumerateObject())
            {

                if(kv.Name == "extensions")
                {
                    new gltf__materials_ITEM__pbrMetallicRoughness__extensions__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "extras")
                {
                    new gltf__materials_ITEM__pbrMetallicRoughness__extras__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "baseColorFactor")
                {
                    new gltf__materials_ITEM__pbrMetallicRoughness__baseColorFactor__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "baseColorTexture")
                {
                    new gltf__materials_ITEM__pbrMetallicRoughness__baseColorTexture__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "metallicFactor")
                {
                    
                    continue;
                }

                if(kv.Name == "roughnessFactor")
                {
                    
                    continue;
                }

                if(kv.Name == "metallicRoughnessTexture")
                {
                    new gltf__materials_ITEM__pbrMetallicRoughness__metallicRoughnessTexture__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                // unknown key
                m_context.AddMessage(MessageTypes.UnknownProperty, kv.Value, ".materials[{0}].pbrMetallicRoughness", kv.Name);
            }
        }
    }

}
