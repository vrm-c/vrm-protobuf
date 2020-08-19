// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .extensions.VRM.humanoid
    public class gltf__extensions__VRM__humanoid__Validator
    {
        ValidationContext m_context;

        public gltf__extensions__VRM__humanoid__Validator(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            foreach(var kv in json.EnumerateObject())
            {

                if(kv.Name == "humanBones")
                {
                    new gltf__extensions__VRM__humanoid__humanBones__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "armStretch")
                {
                    
                    continue;
                }

                if(kv.Name == "legStretch")
                {
                    
                    continue;
                }

                if(kv.Name == "upperArmTwist")
                {
                    
                    continue;
                }

                if(kv.Name == "lowerArmTwist")
                {
                    
                    continue;
                }

                if(kv.Name == "upperLegTwist")
                {
                    
                    continue;
                }

                if(kv.Name == "lowerLegTwist")
                {
                    
                    continue;
                }

                if(kv.Name == "feetSpacing")
                {
                    
                    continue;
                }

                if(kv.Name == "hasTranslationDoF")
                {
                    
                    continue;
                }

                // unknown key
                m_context.AddMessage(MessageTypes.UnknownProperty, kv.Value, ".extensions.VRM.humanoid", kv.Name);
            }
        }
    }

}
