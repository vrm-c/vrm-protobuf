// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .extensions.VRM.humanoid.humanBones[{0}].min
    public class gltf__extensions__VRM__humanoid__humanBones_ITEM__min__Validator
    {
        ValidationContext m_context;

        public gltf__extensions__VRM__humanoid__humanBones_ITEM__min__Validator(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            foreach(var kv in json.EnumerateObject())
            {

                if(kv.Name == "x")
                {
                    
                    continue;
                }

                if(kv.Name == "y")
                {
                    
                    continue;
                }

                if(kv.Name == "z")
                {
                    
                    continue;
                }

                // unknown key
                m_context.AddMessage(MessageTypes.UnknownProperty, kv.Value, ".extensions.VRM.humanoid.humanBones[{0}].min", kv.Name);
            }
        }
    }

}
