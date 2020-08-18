// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .extensions.VRM.materialProperties[{0}]
    public class gltf__extensions__VRM__materialProperties_ITEM__Validator
    {
        ValidationContext m_context;

        public gltf__extensions__VRM__materialProperties_ITEM__Validator(ValidationContext context)
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

                if(kv.Name == "shader")
                {
                    
                    continue;
                }

                if(kv.Name == "renderQueue")
                {
                    
                    continue;
                }

                if(kv.Name == "floatProperties")
                {
                    new gltf__extensions__VRM__materialProperties_ITEM__floatProperties__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "vectorProperties")
                {
                    new gltf__extensions__VRM__materialProperties_ITEM__vectorProperties__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "textureProperties")
                {
                    new gltf__extensions__VRM__materialProperties_ITEM__textureProperties__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "keywordMap")
                {
                    new gltf__extensions__VRM__materialProperties_ITEM__keywordMap__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "tagMap")
                {
                    new gltf__extensions__VRM__materialProperties_ITEM__tagMap__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                // unknown key
                m_context.AddMessage(MessageTypes.UnknownProperty, kv.Value, ".extensions.VRM.materialProperties[{0}]", kv.Name);
            }
        }
    }

}
