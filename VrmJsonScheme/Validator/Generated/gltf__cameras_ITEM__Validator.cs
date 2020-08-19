// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .cameras[{0}]
    public class gltf__cameras_ITEM__Validator
    {
        ValidationContext m_context;

        public gltf__cameras_ITEM__Validator(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            foreach(var kv in json.EnumerateObject())
            {

                if(kv.Name == "extensions")
                {
                    new gltf__cameras_ITEM__extensions__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "extras")
                {
                    new gltf__cameras_ITEM__extras__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "name")
                {
                    
                    continue;
                }

                if(kv.Name == "orthographic")
                {
                    new gltf__cameras_ITEM__orthographic__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "perspective")
                {
                    new gltf__cameras_ITEM__perspective__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "type")
                {
                    
                    continue;
                }

                // unknown key
                m_context.AddMessage(MessageTypes.UnknownProperty, kv.Value, ".cameras[{0}]", kv.Name);
            }
        }
    }

}
