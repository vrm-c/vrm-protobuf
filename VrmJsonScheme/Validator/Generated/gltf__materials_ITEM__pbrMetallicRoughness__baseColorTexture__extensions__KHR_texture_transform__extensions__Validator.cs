﻿// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .materials[{0}].pbrMetallicRoughness.baseColorTexture.extensions.KHR_texture_transform.extensions
    public class gltf__materials_ITEM__pbrMetallicRoughness__baseColorTexture__extensions__KHR_texture_transform__extensions__Validator
    {
        ValidationContext m_context;

        public gltf__materials_ITEM__pbrMetallicRoughness__baseColorTexture__extensions__KHR_texture_transform__extensions__Validator(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            foreach(var kv in json.EnumerateObject())
            {

                // unknown key
                m_context.AddMessage(MessageTypes.UnknownProperty, kv.Value, ".materials[{0}].pbrMetallicRoughness.baseColorTexture.extensions.KHR_texture_transform.extensions", kv.Name);
            }
        }
    }

}
