// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .textures[{0}]
    public class gltf__textures_ITEM__Validator
    {
        ValidationContext m_context;

        public gltf__textures_ITEM__Validator(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            foreach(var kv in json.EnumerateObject())
            {

                if(kv.Name == "extensions")
                {
                    new gltf__textures_ITEM__extensions__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "extras")
                {
                    new gltf__textures_ITEM__extras__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "name")
                {
                    
                    continue;
                }

                if(kv.Name == "sampler")
                {
                    
                    continue;
                }

                if(kv.Name == "source")
                {
                    
                    continue;
                }

                // unknown key
                m_context.AddMessage(MessageTypes.UnknownProperty, kv.Value, ".textures[{0}]", kv.Name);
            }
        }
    }

}
