// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // 
    public class gltf__Validator
    {
        ValidationContext m_context;

        public gltf__Validator(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            foreach(var kv in json.EnumerateObject())
            {

                if(kv.Name == "extensions")
                {
                    new gltf__extensions__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "extras")
                {
                    new gltf__extras__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "extensionsUsed")
                {
                    new gltf__extensionsUsed__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "extensionsRequired")
                {
                    new gltf__extensionsRequired__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "accessors")
                {
                    new gltf__accessors__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "animations")
                {
                    new gltf__animations__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "asset")
                {
                    new gltf__asset__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "buffers")
                {
                    new gltf__buffers__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "bufferViews")
                {
                    new gltf__bufferViews__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "cameras")
                {
                    new gltf__cameras__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "images")
                {
                    new gltf__images__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "materials")
                {
                    new gltf__materials__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "meshes")
                {
                    new gltf__meshes__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "nodes")
                {
                    new gltf__nodes__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "samplers")
                {
                    new gltf__samplers__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "scene")
                {
                    
                    continue;
                }

                if(kv.Name == "scenes")
                {
                    new gltf__scenes__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "skins")
                {
                    new gltf__skins__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "textures")
                {
                    new gltf__textures__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                // unknown key
                m_context.AddMessage(MessageTypes.UnknownProperty, kv.Value, "", kv.Name);
            }
        }
    }

}
