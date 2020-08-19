// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .materials[{0}].emissiveTexture.extensions.KHR_texture_transform
    public class gltf__materials_ITEM__emissiveTexture__extensions__KHR_texture_transform__Validator
    {
        ValidationContext m_context;

        public gltf__materials_ITEM__emissiveTexture__extensions__KHR_texture_transform__Validator(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            foreach(var kv in json.EnumerateObject())
            {

                if(kv.Name == "extensions")
                {
                    new gltf__materials_ITEM__emissiveTexture__extensions__KHR_texture_transform__extensions__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "extras")
                {
                    new gltf__materials_ITEM__emissiveTexture__extensions__KHR_texture_transform__extras__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "offset")
                {
                    new gltf__materials_ITEM__emissiveTexture__extensions__KHR_texture_transform__offset__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "rotation")
                {
                    
                    continue;
                }

                if(kv.Name == "scale")
                {
                    new gltf__materials_ITEM__emissiveTexture__extensions__KHR_texture_transform__scale__Validator(m_context).Validate(kv.Value);
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
                            m_context.AddMessage(MessageTypes.MinimumException, value, ".materials[{0}].emissiveTexture.extensions.KHR_texture_transform.texCoord", null);
                        }
                        else{
                            // OK
                        }
                    }
                    else{
                        m_context.AddMessage(MessageTypes.InvalidType, kv.Value, ".materials[{0}].emissiveTexture.extensions.KHR_texture_transform.texCoord", null);
                    }
                }


                    continue;
                }

                // unknown key
                m_context.AddMessage(MessageTypes.UnknownProperty, kv.Value, ".materials[{0}].emissiveTexture.extensions.KHR_texture_transform", kv.Name);
            }
        }
    }

}
