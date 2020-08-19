// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .extensions.EXT_lights_image_based.lights[{0}]
    public class gltf__extensions__EXT_lights_image_based__lights_ITEM__Validator
    {
        ValidationContext m_context;

        public gltf__extensions__EXT_lights_image_based__lights_ITEM__Validator(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            foreach(var kv in json.EnumerateObject())
            {

                if(kv.Name == "extensions")
                {
                    new gltf__extensions__EXT_lights_image_based__lights_ITEM__extensions__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "extras")
                {
                    new gltf__extensions__EXT_lights_image_based__lights_ITEM__extras__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "name")
                {
                    
                    continue;
                }

                if(kv.Name == "rotation")
                {
                    new gltf__extensions__EXT_lights_image_based__lights_ITEM__rotation__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "intensity")
                {
                    
                    continue;
                }

                if(kv.Name == "irradianceCoefficients")
                {
                    new gltf__extensions__EXT_lights_image_based__lights_ITEM__irradianceCoefficients__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "specularImages")
                {
                    new gltf__extensions__EXT_lights_image_based__lights_ITEM__specularImages__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "specularImageSize")
                {
                    
                {
                    if(kv.Value.ValueKind == JsonValueKind.Number)
                    {
                        var value = kv.Value.GetInt32();
                        if(value < 1)
                        {
                            m_context.AddMessage(MessageTypes.MinimumException, value, ".extensions.EXT_lights_image_based.lights[{0}].specularImageSize", null);
                        }
                        else{
                            // OK
                        }
                    }
                    else{
                        m_context.AddMessage(MessageTypes.InvalidType, kv.Value, ".extensions.EXT_lights_image_based.lights[{0}].specularImageSize", null);
                    }
                }


                    continue;
                }

                // unknown key
                m_context.AddMessage(MessageTypes.UnknownProperty, kv.Value, ".extensions.EXT_lights_image_based.lights[{0}]", kv.Name);
            }
        }
    }

}
