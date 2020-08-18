// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .extensions.VRM.blendShapeMaster.blendShapeGroups[{0}].binds[{1}]
    public class gltf__extensions__VRM__blendShapeMaster__blendShapeGroups_ITEM__binds_ITEM__Validator
    {
        ValidationContext m_context;

        public gltf__extensions__VRM__blendShapeMaster__blendShapeGroups_ITEM__binds_ITEM__Validator(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            foreach(var kv in json.EnumerateObject())
            {

                if(kv.Name == "mesh")
                {
                    
                {
                    if(kv.Value.ValueKind == JsonValueKind.Number)
                    {
                        var value = kv.Value.GetInt32();
                        if(value < 0)
                        {
                            m_context.AddMessage(MessageTypes.MinimumException, value, ".extensions.VRM.blendShapeMaster.blendShapeGroups[{0}].binds[{1}].mesh", null);
                        }
                        else{
                            // OK
                        }
                    }
                    else{
                        m_context.AddMessage(MessageTypes.InvalidType, kv.Value, ".extensions.VRM.blendShapeMaster.blendShapeGroups[{0}].binds[{1}].mesh", null);
                    }
                }


                    continue;
                }

                if(kv.Name == "index")
                {
                    
                {
                    if(kv.Value.ValueKind == JsonValueKind.Number)
                    {
                        var value = kv.Value.GetInt32();
                        if(value < 0)
                        {
                            m_context.AddMessage(MessageTypes.MinimumException, value, ".extensions.VRM.blendShapeMaster.blendShapeGroups[{0}].binds[{1}].index", null);
                        }
                        else{
                            // OK
                        }
                    }
                    else{
                        m_context.AddMessage(MessageTypes.InvalidType, kv.Value, ".extensions.VRM.blendShapeMaster.blendShapeGroups[{0}].binds[{1}].index", null);
                    }
                }


                    continue;
                }

                if(kv.Name == "weight")
                {
                    
                    continue;
                }

                // unknown key
                m_context.AddMessage(MessageTypes.UnknownProperty, kv.Value, ".extensions.VRM.blendShapeMaster.blendShapeGroups[{0}].binds[{1}]", kv.Name);
            }
        }
    }

}
