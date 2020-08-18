// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .extensions.VRM
    public class gltf__extensions__VRM__Validator
    {
        ValidationContext m_context;

        public gltf__extensions__VRM__Validator(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            foreach(var kv in json.EnumerateObject())
            {

                if(kv.Name == "exporterVersion")
                {
                    
                    continue;
                }

                if(kv.Name == "specVersion")
                {
                    
                    continue;
                }

                if(kv.Name == "meta")
                {
                    new gltf__extensions__VRM__meta__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "humanoid")
                {
                    new gltf__extensions__VRM__humanoid__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "firstPerson")
                {
                    new gltf__extensions__VRM__firstPerson__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "blendShapeMaster")
                {
                    new gltf__extensions__VRM__blendShapeMaster__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "secondaryAnimation")
                {
                    new gltf__extensions__VRM__secondaryAnimation__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "materialProperties")
                {
                    new gltf__extensions__VRM__materialProperties__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                // unknown key
                m_context.AddMessage(MessageTypes.UnknownProperty, kv.Value, ".extensions.VRM", kv.Name);
            }
        }
    }

}
