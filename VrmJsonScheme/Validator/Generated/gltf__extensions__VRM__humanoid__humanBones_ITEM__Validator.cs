// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .extensions.VRM.humanoid.humanBones[{0}]
    public class gltf__extensions__VRM__humanoid__humanBones_ITEM__Validator
    {
        ValidationContext m_context;

        public gltf__extensions__VRM__humanoid__humanBones_ITEM__Validator(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            foreach(var kv in json.EnumerateObject())
            {

                if(kv.Name == "bone")
                {
                    
                    continue;
                }

                if(kv.Name == "node")
                {
                    
                    continue;
                }

                if(kv.Name == "useDefaultValues")
                {
                    
                    continue;
                }

                if(kv.Name == "min")
                {
                    new gltf__extensions__VRM__humanoid__humanBones_ITEM__min__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "max")
                {
                    new gltf__extensions__VRM__humanoid__humanBones_ITEM__max__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "center")
                {
                    new gltf__extensions__VRM__humanoid__humanBones_ITEM__center__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "axisLength")
                {
                    
                    continue;
                }

                // unknown key
                m_context.AddMessage(MessageTypes.UnknownProperty, kv.Value, ".extensions.VRM.humanoid.humanBones[{0}]", kv.Name);
            }
        }
    }

}
