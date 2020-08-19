// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .animations[{0}].channels[{1}]
    public class gltf__animations_ITEM__channels_ITEM__Validator
    {
        ValidationContext m_context;

        public gltf__animations_ITEM__channels_ITEM__Validator(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            foreach(var kv in json.EnumerateObject())
            {

                if(kv.Name == "extensions")
                {
                    new gltf__animations_ITEM__channels_ITEM__extensions__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "extras")
                {
                    new gltf__animations_ITEM__channels_ITEM__extras__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "sampler")
                {
                    
                    continue;
                }

                if(kv.Name == "target")
                {
                    new gltf__animations_ITEM__channels_ITEM__target__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                // unknown key
                m_context.AddMessage(MessageTypes.UnknownProperty, kv.Value, ".animations[{0}].channels[{1}]", kv.Name);
            }
        }
    }

}
