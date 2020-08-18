// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .materials[{0}].extensions.KHR_materials_pbrSpecularGlossiness
    public class gltf__materials_ITEM__extensions__KHR_materials_pbrSpecularGlossiness__Validator
    {
        ValidationContext m_context;

        public gltf__materials_ITEM__extensions__KHR_materials_pbrSpecularGlossiness__Validator(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            foreach(var kv in json.EnumerateObject())
            {

                if(kv.Name == "extensions")
                {
                    new gltf__materials_ITEM__extensions__KHR_materials_pbrSpecularGlossiness__extensions__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "extras")
                {
                    new gltf__materials_ITEM__extensions__KHR_materials_pbrSpecularGlossiness__extras__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "diffuseFactor")
                {
                    new gltf__materials_ITEM__extensions__KHR_materials_pbrSpecularGlossiness__diffuseFactor__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "diffuseTexture")
                {
                    new gltf__materials_ITEM__extensions__KHR_materials_pbrSpecularGlossiness__diffuseTexture__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "specularFactor")
                {
                    new gltf__materials_ITEM__extensions__KHR_materials_pbrSpecularGlossiness__specularFactor__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "glossinessFactor")
                {
                    
                    continue;
                }

                if(kv.Name == "specularGlossinessTexture")
                {
                    new gltf__materials_ITEM__extensions__KHR_materials_pbrSpecularGlossiness__specularGlossinessTexture__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                // unknown key
                m_context.AddMessage(MessageTypes.UnknownProperty, kv.Value, ".materials[{0}].extensions.KHR_materials_pbrSpecularGlossiness", kv.Name);
            }
        }
    }

}
