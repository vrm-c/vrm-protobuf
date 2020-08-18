// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .meshes[{0}]
    public class gltf__meshes_ITEM__Validator
    {
        ValidationContext m_context;

        public gltf__meshes_ITEM__Validator(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            foreach(var kv in json.EnumerateObject())
            {

                if(kv.Name == "extensions")
                {
                    new gltf__meshes_ITEM__extensions__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "extras")
                {
                    new gltf__meshes_ITEM__extras__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "name")
                {
                    
                    continue;
                }

                if(kv.Name == "primitives")
                {
                    new gltf__meshes_ITEM__primitives__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "weights")
                {
                    new gltf__meshes_ITEM__weights__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                // unknown key
                m_context.AddMessage(MessageTypes.UnknownProperty, kv.Value, ".meshes[{0}]", kv.Name);
            }
        }
    }

}
