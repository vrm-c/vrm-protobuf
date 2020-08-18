// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .samplers[{0}]
    public class gltf__samplers_ITEM__Validator
    {
        ValidationContext m_context;

        public gltf__samplers_ITEM__Validator(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            foreach(var kv in json.EnumerateObject())
            {

                if(kv.Name == "extensions")
                {
                    new gltf__samplers_ITEM__extensions__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "extras")
                {
                    new gltf__samplers_ITEM__extras__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "name")
                {
                    
                    continue;
                }

                if(kv.Name == "magFilter")
                {
                    
                    continue;
                }

                if(kv.Name == "minFilter")
                {
                    
                    continue;
                }

                if(kv.Name == "wrapS")
                {
                    
                    continue;
                }

                if(kv.Name == "wrapT")
                {
                    
                    continue;
                }

                // unknown key
                m_context.AddMessage(MessageTypes.UnknownProperty, kv.Value, ".samplers[{0}]", kv.Name);
            }
        }
    }

}
