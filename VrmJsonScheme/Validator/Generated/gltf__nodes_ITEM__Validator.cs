// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .nodes[{0}]
    public class gltf__nodes_ITEM__Validator
    {
        ValidationContext m_context;

        public gltf__nodes_ITEM__Validator(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            foreach(var kv in json.EnumerateObject())
            {

                if(kv.Name == "extensions")
                {
                    new gltf__nodes_ITEM__extensions__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "extras")
                {
                    new gltf__nodes_ITEM__extras__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "name")
                {
                    
                    continue;
                }

                if(kv.Name == "camera")
                {
                    
                    continue;
                }

                if(kv.Name == "children")
                {
                    new gltf__nodes_ITEM__children__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "skin")
                {
                    
                    continue;
                }

                if(kv.Name == "matrix")
                {
                    new gltf__nodes_ITEM__matrix__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "mesh")
                {
                    
                    continue;
                }

                if(kv.Name == "rotation")
                {
                    new gltf__nodes_ITEM__rotation__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "scale")
                {
                    new gltf__nodes_ITEM__scale__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "translation")
                {
                    new gltf__nodes_ITEM__translation__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "weights")
                {
                    new gltf__nodes_ITEM__weights__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                // unknown key
                m_context.AddMessage(MessageTypes.UnknownProperty, kv.Value, ".nodes[{0}]", kv.Name);
            }
        }
    }

}
