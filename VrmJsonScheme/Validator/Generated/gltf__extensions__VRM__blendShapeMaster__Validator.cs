// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .extensions.VRM.blendShapeMaster
    public class gltf__extensions__VRM__blendShapeMaster__Validator
    {
        ValidationContext m_context;

        public gltf__extensions__VRM__blendShapeMaster__Validator(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            foreach(var kv in json.EnumerateObject())
            {

                if(kv.Name == "blendShapeGroups")
                {
                    new gltf__extensions__VRM__blendShapeMaster__blendShapeGroups__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                // unknown key
                m_context.AddMessage(MessageTypes.UnknownProperty, kv.Value, ".extensions.VRM.blendShapeMaster", kv.Name);
            }
        }
    }

}
