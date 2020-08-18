// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .extensions.VRM.secondaryAnimation.boneGroups[{0}]
    public class gltf__extensions__VRM__secondaryAnimation__boneGroups_ITEM__Validator
    {
        ValidationContext m_context;

        public gltf__extensions__VRM__secondaryAnimation__boneGroups_ITEM__Validator(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            foreach(var kv in json.EnumerateObject())
            {

                if(kv.Name == "comment")
                {
                    
                    continue;
                }

                if(kv.Name == "stiffiness")
                {
                    
                    continue;
                }

                if(kv.Name == "gravityPower")
                {
                    
                    continue;
                }

                if(kv.Name == "gravityDir")
                {
                    new gltf__extensions__VRM__secondaryAnimation__boneGroups_ITEM__gravityDir__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "dragForce")
                {
                    
                    continue;
                }

                if(kv.Name == "center")
                {
                    
                    continue;
                }

                if(kv.Name == "hitRadius")
                {
                    
                    continue;
                }

                if(kv.Name == "bones")
                {
                    new gltf__extensions__VRM__secondaryAnimation__boneGroups_ITEM__bones__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "colliderGroups")
                {
                    new gltf__extensions__VRM__secondaryAnimation__boneGroups_ITEM__colliderGroups__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                // unknown key
                m_context.AddMessage(MessageTypes.UnknownProperty, kv.Value, ".extensions.VRM.secondaryAnimation.boneGroups[{0}]", kv.Name);
            }
        }
    }

}
