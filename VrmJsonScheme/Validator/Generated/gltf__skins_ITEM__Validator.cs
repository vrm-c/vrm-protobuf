// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .skins[{0}]
    public class gltf__skins_ITEM__Validator
    {
        ValidationContext m_context;

        public gltf__skins_ITEM__Validator(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            foreach(var kv in json.EnumerateObject())
            {

                if(kv.Name == "extensions")
                {
                    new gltf__skins_ITEM__extensions__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "extras")
                {
                    new gltf__skins_ITEM__extras__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "name")
                {
                    
                    continue;
                }

                if(kv.Name == "inverseBindMatrices")
                {
                    
                    continue;
                }

                if(kv.Name == "skeleton")
                {
                    
                    continue;
                }

                if(kv.Name == "joints")
                {
                    new gltf__skins_ITEM__joints__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                // unknown key
                m_context.AddMessage(MessageTypes.UnknownProperty, kv.Value, ".skins[{0}]", kv.Name);
            }
        }
    }

}
