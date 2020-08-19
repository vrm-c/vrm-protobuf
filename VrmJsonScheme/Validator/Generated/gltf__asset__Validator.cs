// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .asset
    public class gltf__asset__Validator
    {
        ValidationContext m_context;

        public gltf__asset__Validator(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            foreach(var kv in json.EnumerateObject())
            {

                if(kv.Name == "extensions")
                {
                    new gltf__asset__extensions__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "extras")
                {
                    new gltf__asset__extras__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "copyright")
                {
                    
                    continue;
                }

                if(kv.Name == "generator")
                {
                    
                    continue;
                }

                if(kv.Name == "version")
                {
                    
                    continue;
                }

                if(kv.Name == "minVersion")
                {
                    
                    continue;
                }

                // unknown key
                m_context.AddMessage(MessageTypes.UnknownProperty, kv.Value, ".asset", kv.Name);
            }
        }
    }

}
