﻿// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .buffers[{0}].extensions
    public class gltf__buffers_ITEM__extensions__Validator
    {
        ValidationContext m_context;

        public gltf__buffers_ITEM__extensions__Validator(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            foreach(var kv in json.EnumerateObject())
            {

                // unknown key
                m_context.AddMessage(MessageTypes.UnknownProperty, kv.Value, ".buffers[{0}].extensions", kv.Name);
            }
        }
    }

}
