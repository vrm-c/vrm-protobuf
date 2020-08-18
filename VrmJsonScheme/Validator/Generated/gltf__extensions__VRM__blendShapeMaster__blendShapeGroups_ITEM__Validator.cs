// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .extensions.VRM.blendShapeMaster.blendShapeGroups[{0}]
    public class gltf__extensions__VRM__blendShapeMaster__blendShapeGroups_ITEM__Validator
    {
        ValidationContext m_context;

        public gltf__extensions__VRM__blendShapeMaster__blendShapeGroups_ITEM__Validator(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            foreach(var kv in json.EnumerateObject())
            {

                if(kv.Name == "name")
                {
                    
                    continue;
                }

                if(kv.Name == "presetName")
                {
                    
                    continue;
                }

                if(kv.Name == "binds")
                {
                    new gltf__extensions__VRM__blendShapeMaster__blendShapeGroups_ITEM__binds__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "materialValues")
                {
                    new gltf__extensions__VRM__blendShapeMaster__blendShapeGroups_ITEM__materialValues__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "isBinary")
                {
                    
                    continue;
                }

                // unknown key
                m_context.AddMessage(MessageTypes.UnknownProperty, kv.Value, ".extensions.VRM.blendShapeMaster.blendShapeGroups[{0}]", kv.Name);
            }
        }
    }

}
