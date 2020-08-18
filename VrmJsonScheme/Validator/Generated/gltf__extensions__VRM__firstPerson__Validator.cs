// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .extensions.VRM.firstPerson
    public class gltf__extensions__VRM__firstPerson__Validator
    {
        ValidationContext m_context;

        public gltf__extensions__VRM__firstPerson__Validator(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            foreach(var kv in json.EnumerateObject())
            {

                if(kv.Name == "firstPersonBone")
                {
                    
                    continue;
                }

                if(kv.Name == "firstPersonBoneOffset")
                {
                    new gltf__extensions__VRM__firstPerson__firstPersonBoneOffset__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "meshAnnotations")
                {
                    new gltf__extensions__VRM__firstPerson__meshAnnotations__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "lookAtTypeName")
                {
                    
                    continue;
                }

                if(kv.Name == "lookAtHorizontalInner")
                {
                    new gltf__extensions__VRM__firstPerson__lookAtHorizontalInner__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "lookAtHorizontalOuter")
                {
                    new gltf__extensions__VRM__firstPerson__lookAtHorizontalOuter__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "lookAtVerticalDown")
                {
                    new gltf__extensions__VRM__firstPerson__lookAtVerticalDown__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                if(kv.Name == "lookAtVerticalUp")
                {
                    new gltf__extensions__VRM__firstPerson__lookAtVerticalUp__Validator(m_context).Validate(kv.Value);
                    continue;
                }

                // unknown key
                m_context.AddMessage(MessageTypes.UnknownProperty, kv.Value, ".extensions.VRM.firstPerson", kv.Name);
            }
        }
    }

}
