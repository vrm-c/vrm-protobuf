// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .extensions.VRM.meta
    public class gltf__extensions__VRM__meta__Validator
    {
        ValidationContext m_context;

        public gltf__extensions__VRM__meta__Validator(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            foreach(var kv in json.EnumerateObject())
            {

                if(kv.Name == "title")
                {
                    
                    continue;
                }

                if(kv.Name == "version")
                {
                    
                    continue;
                }

                if(kv.Name == "author")
                {
                    
                    continue;
                }

                if(kv.Name == "contactInformation")
                {
                    
                    continue;
                }

                if(kv.Name == "reference")
                {
                    
                    continue;
                }

                if(kv.Name == "texture")
                {
                    
                    continue;
                }

                if(kv.Name == "allowedUserName")
                {
                    
                    continue;
                }

                if(kv.Name == "violentUssageName")
                {
                    
                    continue;
                }

                if(kv.Name == "sexualUssageName")
                {
                    
                    continue;
                }

                if(kv.Name == "commercialUssageName")
                {
                    
                    continue;
                }

                if(kv.Name == "otherPermissionUrl")
                {
                    
                    continue;
                }

                if(kv.Name == "licenseName")
                {
                    
                    continue;
                }

                if(kv.Name == "otherLicenseUrl")
                {
                    
                    continue;
                }

                // unknown key
                m_context.AddMessage(MessageTypes.UnknownProperty, kv.Value, ".extensions.VRM.meta", kv.Name);
            }
        }
    }

}
