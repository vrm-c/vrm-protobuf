// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .materials[{0}]
    public class gltf__materials_ITEM__Validator
    {
        ValidationContext m_context;

        public gltf__materials_ITEM__Validator(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            foreach(var kv in json.EnumerateObject())
            {

                if(kv.Name == "extensions")
                {
                    new gltf__materials_ITEM__extensions__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "extras")
                {
                    new gltf__materials_ITEM__extras__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "name")
                {
                    
                    continue;
                }

                if(kv.Name == "pbrMetallicRoughness")
                {
                    new gltf__materials_ITEM__pbrMetallicRoughness__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "normalTexture")
                {
                    new gltf__materials_ITEM__normalTexture__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "occlusionTexture")
                {
                    new gltf__materials_ITEM__occlusionTexture__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "emissiveTexture")
                {
                    new gltf__materials_ITEM__emissiveTexture__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "emissiveFactor")
                {
                    new gltf__materials_ITEM__emissiveFactor__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "alphaMode")
                {
                    
                    continue;
                }

                if(kv.Name == "alphaCutoff")
                {
                    
                    continue;
                }

                if(kv.Name == "doubleSided")
                {
                    
                    continue;
                }

                // unknown key
                m_context.AddMessage(MessageTypes.UnknownProperty, kv.Value, ".materials[{0}]", kv.Name);
            }
        }
    }

}
