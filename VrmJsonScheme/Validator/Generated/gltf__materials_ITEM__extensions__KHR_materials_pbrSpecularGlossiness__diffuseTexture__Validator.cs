// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .materials[{0}].extensions.KHR_materials_pbrSpecularGlossiness.diffuseTexture
    public class gltf__materials_ITEM__extensions__KHR_materials_pbrSpecularGlossiness__diffuseTexture__Validator
    {
        ValidationContext m_context;

        public gltf__materials_ITEM__extensions__KHR_materials_pbrSpecularGlossiness__diffuseTexture__Validator(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            foreach(var kv in json.EnumerateObject())
            {

                if(kv.Name == "extensions")
                {
                    new gltf__materials_ITEM__extensions__KHR_materials_pbrSpecularGlossiness__diffuseTexture__extensions__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "extras")
                {
                    new gltf__materials_ITEM__extensions__KHR_materials_pbrSpecularGlossiness__diffuseTexture__extras__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "index")
                {
                    
                    continue;
                }

                if(kv.Name == "texCoord")
                {
                    
                {
                    if(kv.Value.ValueKind == JsonValueKind.Number)
                    {
                        var value = kv.Value.GetInt32();
                        if(value < 0)
                        {
                            m_context.AddMessage(MessageTypes.MinimumException, value, ".materials[{0}].extensions.KHR_materials_pbrSpecularGlossiness.diffuseTexture.texCoord", null);
                        }
                        else{
                            // OK
                        }
                    }
                    else{
                        m_context.AddMessage(MessageTypes.InvalidType, kv.Value, ".materials[{0}].extensions.KHR_materials_pbrSpecularGlossiness.diffuseTexture.texCoord", null);
                    }
                }


                    continue;
                }

                // unknown key
                m_context.AddMessage(MessageTypes.UnknownProperty, kv.Value, ".materials[{0}].extensions.KHR_materials_pbrSpecularGlossiness.diffuseTexture", kv.Name);
            }
        }
    }

}
