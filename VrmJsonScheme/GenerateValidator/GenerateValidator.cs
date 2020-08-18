using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Vrm.JsonSchema;
using Vrm.JsonSchema.Schemas;

namespace VrmValidator
{
    public class ValidatorGenerator
    {
        public struct Configuration
        {
            public string Prefix;
            public string Suffix;
        }

        const string BEGIN = @"// this code is generated. don't modify this code.
using System.Text.Json;

namespace VrmValidator
{
";

        const string END = @"
}
";

        const string OBJECT_BEGIN = @"
    // ${json_path}
    public class ${class_name}
    {
        ValidationContext m_context;

        public ${class_name}(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            foreach(var kv in json.EnumerateObject())
            {
";

        const string OBJECT_PROP = @"
                if(kv.Name == ""${prop_name}"")
                {
                    ${validation}
                    continue;
                }
";

        const string OBJECT_END = @"
                // unknown key
                m_context.AddMessage(MessageTypes.UnknownProperty, kv.Value, ""${json_path}"", kv.Name);
            }
        }
    }
";

        const string ARRAY = @"
    // ${json_path}
    public class ${class_name}
    {
        ValidationContext m_context;

        public ${class_name}(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            int i=0;
            foreach(var item in json.EnumerateArray())
            {
                m_context.Push(i++);
                ${validation}
                m_context.Pop();
            }
        }
    }
";

        const string DICT = @"
    // ${json_path}
    public class ${class_name}
    {
        ValidationContext m_context;

        public ${class_name}(ValidationContext context)
        {           
            m_context = context;
        }

        public void Validate(JsonElement json)
        {
            foreach(var kv in json.EnumerateObject())
            {
                m_context.Push(kv.Name);
                ${validation}
                m_context.Pop();
            }
        }
    }
";

        const string INT_MINIMUM = @"
                {
                    if(${value}.ValueKind == JsonValueKind.Number)
                    {
                        var value = ${value}.GetInt32();
                        if(value < ${minimum})
                        {
                            m_context.AddMessage(MessageTypes.MinimumException, value, ""${json_path}"", null);
                        }
                        else{
                            // OK
                        }
                    }
                    else{
                        m_context.AddMessage(MessageTypes.InvalidType, ${value}, ""${json_path}"", null);
                    }
                }
";

        const string INT_INDEXTARGET = @"
                {
                    if(${value}.ValueKind == JsonValueKind.Number)
                    {
                        var value = ${value}.GetInt32();
                        if(value < 0)
                        {
                            m_context.AddMessage(MessageTypes.MinimumException, value, ""${json_path}"", null);
                        }
                        else{
                            // OK
                        }
                        if(m_context.TryGetArrayLength(""${target}"", out int length))
                        {
                            if(value >= length)
                            {
                                m_context.AddMessage(MessageTypes.ArrayExceedLength, ${value}, ""${json_path}"", null);
                            }
                            else{
                                // OK
                            }
                        }
                        else
                        {
                            m_context.AddMessage(MessageTypes.ArrayNotExists, ${value}, ""${json_path}"", null);
                        }
                    }
                    else{
                        m_context.AddMessage(MessageTypes.InvalidType, ${value}, ""${json_path}"", null);
                    }
                }
";

        static string RenderTemplate(string template, Dictionary<string, string> map)
        {
            return Regex.Replace(template, @"\$\{(\w+)\}", (Match match) => map[match.Groups[1].Value]);
        }

        static string ToClassName(JsonSchemaBase schema, in Configuration config)
        {
            return $"{config.Prefix}{schema.ClassName}{config.Suffix}";
        }

        static string JsonPathFormat(string jsonPath)
        {
            int index = 0;
            var sb = new StringBuilder();
            for (int i = 0; i < jsonPath.Length; ++i)
            {
                if (jsonPath[i] == '[' || jsonPath[i] == '{')
                {
                    sb.Append($"[{{{index++}}}]");
                    ++i;
                }
                else
                {
                    sb.Append(jsonPath[i]);
                }
            }
            return sb.ToString();
        }

        static string GetValidation(JsonSchemaBase schema, string value, in Configuration config)
        {
            if (schema is ObjectJsonSchema obj)
            {
                var className = ToClassName(schema, config);
                return $"new {className}(m_context).Validate({value});";
            }
            else if (schema is ArrayJsonSchema array)
            {
                var className = ToClassName(schema, config);
                return $"new {className}(m_context).Validate({value});";
            }
            else if (schema is DictionaryJsonSchema dict)
            {
                var className = ToClassName(schema, config);
                return $"new {className}(m_context).Validate({value});";
            }
            else
            {
                var sb = new StringBuilder();
                if (schema is IntegerJsonSchema integer)
                {
                    if (integer.Minimum.HasValue)
                    {
                        sb.AppendLine(RenderTemplate(INT_MINIMUM, new Dictionary<string, string>{
                        {"value", value},
                        {"json_path", JsonPathFormat(schema.JsonPath)},
                        {"minimum", $"{integer.Minimum.Value}"},
                    }));
                    }
                    if (!string.IsNullOrEmpty(integer.IndexTargetJsonPath))
                    {
                        sb.AppendLine(RenderTemplate(INT_INDEXTARGET, new Dictionary<string, string>
                    {
                        {"value", value},
                        {"json_path", JsonPathFormat(schema.JsonPath)},
                        {"target", $"{integer.IndexTargetJsonPath}"},
                    }));
                    }

                }
                if (!string.IsNullOrEmpty(schema.HardCode))
                {
                    sb.AppendLine(RenderTemplate(schema.HardCode, new Dictionary<string, string>
                    {
                        {"value", value},
                        {"json_path", JsonPathFormat(schema.JsonPath)},
                    }));
                }
                return sb.ToString();
            }
        }

        static void Generate(StreamWriter w, JsonSchemaBase schema, in Configuration config)
        {
            if (schema is ObjectJsonSchema obj)
            {
                var className = ToClassName(obj, config);

                w.Write(RenderTemplate(OBJECT_BEGIN, new Dictionary<string, string>{
                    {"class_name", className},
                    {"json_path", JsonPathFormat(obj.JsonPath)},
                }));

                if (!string.IsNullOrEmpty(obj.HardCode))
                {
                    w.WriteLine(RenderTemplate(obj.HardCode, new Dictionary<string, string>
                    {
                        {"value", "json"},
                        {"json_path", JsonPathFormat(schema.JsonPath)},
                    }));
                }

                foreach (var kv in obj.Properties)
                {
                    w.Write(RenderTemplate(OBJECT_PROP, new Dictionary<string, string>{
                    {"class_name", ToClassName(kv.Value, config)},
                    {"prop_name", kv.Key},
                    {"validation", GetValidation(kv.Value, "kv.Value", config)},
                }));
                }

                w.Write(RenderTemplate(OBJECT_END, new Dictionary<string, string>
                {
                    {"class_name", className},
                    {"json_path", JsonPathFormat(schema.JsonPath)},
                }));
            }
            else if (schema is ArrayJsonSchema array)
            {
                var className = ToClassName(schema, config);

                w.Write(RenderTemplate(ARRAY, new Dictionary<string, string>{
                    {"class_name", className},
                    {"json_path", JsonPathFormat(schema.JsonPath)},
                    {"validation", GetValidation(array.Items, "item", config)},
                }));
            }
            else if (schema is DictionaryJsonSchema dict)
            {
                var className = ToClassName(schema, config);

                w.Write(RenderTemplate(DICT, new Dictionary<string, string>{
                    {"class_name", className},
                    {"json_path", JsonPathFormat(schema.JsonPath)},
                    {"validation", GetValidation(dict.AdditionalProperties, "kv.Value", config)},
                }));
            }
        }

        static void ClearFolder(DirectoryInfo dir)
        {
            Console.WriteLine($"clear: {dir}");

            foreach (FileInfo file in dir.GetFiles())
            {
                file.Delete();
            }

            foreach (DirectoryInfo child in dir.GetDirectories())
            {
                child.Delete(true);
            }
        }

        public static void GenerateTo(JsonSchemaSource root, DirectoryInfo dir, in Configuration config, bool clearFolder)
        {
            if (dir.Exists)
            {
                if (dir.EnumerateFileSystemInfos().Any())
                {
                    if (!clearFolder)
                    {
                        Console.WriteLine($"{dir} is not empty.");
                        return;
                    }

                    // clear
                    ClearFolder(dir);
                }
            }
            else
            {
                Console.WriteLine($"create: {dir}");
                dir.Create();
            }

            FileStream s = null;
            StreamWriter w = null;

            foreach (var source in root.Traverse())
            {
                var schema = source.Create();
                if (schema is ObjectJsonSchema
                    || schema is ArrayJsonSchema
                    || schema is DictionaryJsonSchema)
                {
                    if (s != null)
                    {
                        w.Write(END);
                        w.Dispose();
                        s.Dispose();
                    }
                    var path = Path.Combine(dir.FullName, $"{config.Prefix}{schema.ClassName}{config.Suffix}.cs");
                    s = new FileStream(path, FileMode.Create);
                    w = new StreamWriter(s, Encoding.UTF8);
                    w.Write(BEGIN);
                }
                Generate(w, schema, config);
            }
            w.Write(END);
            w.Dispose();
            s.Dispose();
        }
    }
}
