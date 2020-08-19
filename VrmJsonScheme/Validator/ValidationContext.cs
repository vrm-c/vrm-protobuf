using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace VrmValidator
{
    public enum MessageTypes
    {
        // 未知のプロパティ
        UnknownProperty,

        // 期待される型と違う
        InvalidType,

        // 最低値を下回る
        MinimumException,

        // index が 指し示す array が無い
        ArrayNotExists,

        // index が array の長さを超えている
        ArrayExceedLength,
    }

    public struct Message
    {
        public MessageTypes MessageType;
        public string JsonPath;
        public string ValueText;
        // public string Description;

        public override string ToString()
        {

            return $"{MessageType}: {JsonPath} => {ValueText}";
        }
    }

    public class ValidationContext
    {
        public readonly List<Message> Messages = new List<Message>();

        public List<object> m_indexStack = new List<object>();

        /// <summary>
        /// ".meshes[].primitives[].attributes{}" から .meshes[0].primitives[1].attributes{POSITION} を作る
        /// </summary>
        string IndexedJsonPath(string jsonPath)
        {
            return $"{string.Format(jsonPath, m_indexStack.ToArray())}";
        }

        JsonElement m_root;

        public ValidationContext(JsonElement root)
        {
            m_root = root;
        }

        public void Push(object index)
        {
            m_indexStack.Add(index);
        }

        public void Pop()
        {
            m_indexStack.RemoveAt(m_indexStack.Count - 1);
        }


        /// <summary>
        /// '.', '[]', '{}' で文字列を分離する
        /// </summary>
        static IEnumerable<string> SplitJsonPath(string jsonPath)
        {
            var i = 1;
            var head = i;
            for (; i < jsonPath.Length;)
            {
                switch (jsonPath[i])
                {
                    case '.':
                        {
                            var split = jsonPath.Substring(head, i - head);
                            yield return split;
                            ++i;
                            head = i;
                        }
                        break;

                    case '[':
                        {
                            var split = jsonPath.Substring(head, i - head);
                            yield return split;
                            int j = i;
                            for (j = i; j < jsonPath.Length; ++j)
                            {
                                if (jsonPath[j] == ']')
                                {
                                    break;
                                }
                            }
                            head = i;
                            i = j + 1;
                        }
                        {
                            var split = jsonPath.Substring(head, i - head);
                            yield return split;
                            ++i;
                            head = i;
                        }
                        break;

                    case '{':
                        throw new NotImplementedException();

                    default:
                        ++i;
                        break;
                }
            }

            {
                var split = jsonPath.Substring(head, i - head);
                yield return split;
            }
        }

        void GetNodes(JsonElement current, ArraySegment<string> path, List<int> nodes)
        {
            if (!path.Any())
            {
                nodes.Add(current.GetArrayLength());
                return;
            }

            var split = path.First();
            if (split[0] == '[')
            {
                var splitValue = split.Substring(1, split.Length - 2);
                if (splitValue == "*")
                {
                    foreach (var next in current.EnumerateArray())
                    {
                        GetNodes(next, path.Slice(1), nodes);
                    }
                }
                else
                {
                    var splitIndex = int.Parse(splitValue);
                    var next = current.EnumerateArray().Skip(splitIndex).First();
                    GetNodes(next, path.Slice(1), nodes);
                }
            }
            else
            {
                foreach (var kv in current.EnumerateObject())
                {
                    if (kv.Name == split)
                    {
                        var next = current.GetProperty(split);
                        GetNodes(next, path.Slice(1), nodes);
                        return;
                    }
                }

                // no prop
                nodes.Add(-1);
            }
        }

        public bool TryGetArrayLength(string jsonPath, out int length)
        {
            var current = m_root;

            var splitted = SplitJsonPath(IndexedJsonPath(jsonPath)).ToArray();
            var lengthList = new List<int>();
            GetNodes(m_root, splitted, lengthList);

            length = -1;
            foreach (var value in lengthList)
            {
                if (length == -1)
                {
                    length = value;
                }
                else
                {
                    if (value != length)
                    {
                        // primitive間でモーフの内容が違う
                        return false;
                    }
                }
            }
            return true;
        }

        public void AddMessage(MessageTypes msg, object value, string jsonPath, string propName)
        {
            var path = IndexedJsonPath(jsonPath);
            if (!string.IsNullOrEmpty(propName))
            {
                path += $".{propName}";
            }
            var valueText = "";
            if (value is JsonElement json)
            {
                if (json.ValueKind == JsonValueKind.Object)
                {
                    valueText = "[object]";
                }
                else if (json.ValueKind == JsonValueKind.Array)
                {
                    valueText = "[array]";
                }
                else
                {
                    valueText = value.ToString();
                }
            }
            else
            {
                valueText = value.ToString();
            }
            Messages.Add(new Message
            {
                MessageType = msg,
                JsonPath = path,
                ValueText = valueText
            });
        }
    }
}
