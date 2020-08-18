// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .meshes[{0}].primitives[{1}].extensions.KHR_draco_mesh_compression
    public class gltf__meshes_ITEM__primitives_ITEM__extensions__KHR_draco_mesh_compression__Validator
    {
        ValidationContext m_context;

        public gltf__meshes_ITEM__primitives_ITEM__extensions__KHR_draco_mesh_compression__Validator(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            foreach(var kv in json.EnumerateObject())
            {

                if(kv.Name == "extensions")
                {
                    new gltf__meshes_ITEM__primitives_ITEM__extensions__KHR_draco_mesh_compression__extensions__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "extras")
                {
                    new gltf__meshes_ITEM__primitives_ITEM__extensions__KHR_draco_mesh_compression__extras__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "bufferView")
                {
                    
                    continue;
                }

                if(kv.Name == "attributes")
                {
                    new gltf__meshes_ITEM__primitives_ITEM__extensions__KHR_draco_mesh_compression__attributes__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                // unknown key
                m_context.AddMessage(MessageTypes.UnknownProperty, kv.Value, ".meshes[{0}].primitives[{1}].extensions.KHR_draco_mesh_compression", kv.Name);
            }
        }
    }

}
