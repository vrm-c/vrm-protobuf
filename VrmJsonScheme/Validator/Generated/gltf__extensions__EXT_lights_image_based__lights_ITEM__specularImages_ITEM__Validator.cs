// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .extensions.EXT_lights_image_based.lights[{0}].specularImages[{1}]
    public class gltf__extensions__EXT_lights_image_based__lights_ITEM__specularImages_ITEM__Validator
    {
        ValidationContext m_context;

        public gltf__extensions__EXT_lights_image_based__lights_ITEM__specularImages_ITEM__Validator(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            int i=0;
            foreach(var item in json.EnumerateArray())
            {
                m_context.Push(i++);
                
                {
                    if(item.ValueKind == JsonValueKind.Number)
                    {
                        var value = item.GetInt32();
                        if(value < 0)
                        {
                            m_context.AddMessage(MessageTypes.MinimumException, value, ".extensions.EXT_lights_image_based.lights[{0}].specularImages[{1}][{2}]", null);
                        }
                        else{
                            // OK
                        }
                    }
                    else{
                        m_context.AddMessage(MessageTypes.InvalidType, item, ".extensions.EXT_lights_image_based.lights[{0}].specularImages[{1}][{2}]", null);
                    }
                }


                m_context.Pop();
            }
        }
    }

}
