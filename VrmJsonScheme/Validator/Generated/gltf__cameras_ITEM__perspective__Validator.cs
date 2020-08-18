// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .cameras[{0}].perspective
    public class gltf__cameras_ITEM__perspective__Validator
    {
        ValidationContext m_context;

        public gltf__cameras_ITEM__perspective__Validator(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            foreach(var kv in json.EnumerateObject())
            {

                if(kv.Name == "extensions")
                {
                    new gltf__cameras_ITEM__perspective__extensions__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "extras")
                {
                    new gltf__cameras_ITEM__perspective__extras__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "aspectRatio")
                {
                    
                    continue;
                }

                if(kv.Name == "yfov")
                {
                    
                    continue;
                }

                if(kv.Name == "zfar")
                {
                    
                    continue;
                }

                if(kv.Name == "znear")
                {
                    
                    continue;
                }

                // unknown key
                m_context.AddMessage(MessageTypes.UnknownProperty, kv.Value, ".cameras[{0}].perspective", kv.Name);
            }
        }
    }

}
