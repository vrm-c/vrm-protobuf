// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .extensions.VRM.blendShapeMaster.blendShapeGroups[{0}].materialValues[{1}]
    public class gltf__extensions__VRM__blendShapeMaster__blendShapeGroups_ITEM__materialValues_ITEM__Validator
    {
        ValidationContext m_context;

        public gltf__extensions__VRM__blendShapeMaster__blendShapeGroups_ITEM__materialValues_ITEM__Validator(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            foreach(var kv in json.EnumerateObject())
            {

                if(kv.Name == "materialName")
                {
                    
                    continue;
                }

                if(kv.Name == "propertyName")
                {
                    
                    continue;
                }

                if(kv.Name == "targetValue")
                {
                    new gltf__extensions__VRM__blendShapeMaster__blendShapeGroups_ITEM__materialValues_ITEM__targetValue__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                // unknown key
                m_context.AddMessage(MessageTypes.UnknownProperty, kv.Value, ".extensions.VRM.blendShapeMaster.blendShapeGroups[{0}].materialValues[{1}]", kv.Name);
            }
        }
    }

}
