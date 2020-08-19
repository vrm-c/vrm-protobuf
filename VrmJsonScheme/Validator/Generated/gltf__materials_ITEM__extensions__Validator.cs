// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .materials[{0}].extensions
    public class gltf__materials_ITEM__extensions__Validator
    {
        ValidationContext m_context;

        public gltf__materials_ITEM__extensions__Validator(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            foreach(var kv in json.EnumerateObject())
            {

                if(kv.Name == "KHR_materials_unlit")
                {
                    new gltf__materials_ITEM__extensions__KHR_materials_unlit__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "KHR_materials_pbrSpecularGlossiness")
                {
                    new gltf__materials_ITEM__extensions__KHR_materials_pbrSpecularGlossiness__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                // unknown key
                m_context.AddMessage(MessageTypes.UnknownProperty, kv.Value, ".materials[{0}].extensions", kv.Name);
            }
        }
    }

}
