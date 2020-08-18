// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .meshes[{0}].primitives[{1}].extensions.KHR_draco_mesh_compression.extensions
    public class gltf__meshes_ITEM__primitives_ITEM__extensions__KHR_draco_mesh_compression__extensions__Validator
    {
        ValidationContext m_context;

        public gltf__meshes_ITEM__primitives_ITEM__extensions__KHR_draco_mesh_compression__extensions__Validator(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            foreach(var kv in json.EnumerateObject())
            {

                // unknown key
                m_context.AddMessage(MessageTypes.UnknownProperty, kv.Value, ".meshes[{0}].primitives[{1}].extensions.KHR_draco_mesh_compression.extensions", kv.Name);
            }
        }
    }

}
