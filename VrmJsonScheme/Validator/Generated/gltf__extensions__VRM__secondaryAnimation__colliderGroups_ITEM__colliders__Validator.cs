﻿// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{

    // .extensions.VRM.secondaryAnimation.colliderGroups[{0}].colliders
    public class gltf__extensions__VRM__secondaryAnimation__colliderGroups_ITEM__colliders__Validator
    {
        ValidationContext m_context;

        public gltf__extensions__VRM__secondaryAnimation__colliderGroups_ITEM__colliders__Validator(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            int i=0;
            foreach(var item in json.EnumerateArray())
            {
                m_context.Push(i++);
                new gltf__extensions__VRM__secondaryAnimation__colliderGroups_ITEM__colliders_ITEM__Validator(m_context).Validate(item);
                m_context.Pop();
            }
        }
    }

}
