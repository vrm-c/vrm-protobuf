using System;
using System.IO;
using System.Text.Json;

namespace VrmValidator
{
    struct ByteReader
    {
        byte[] m_bytes;
        public int Position
        {
            get;
            private set;
        }

        public bool IsEnd => Position >= m_bytes.Length;

        public ByteReader(byte[] bytes)
        {
            m_bytes = bytes;
            Position = 0;
        }

        public int Int32()
        {
            var value = BitConverter.ToInt32(m_bytes, Position);
            Position += 4;
            return value;
        }

        public ArraySegment<byte> Bytes(int length)
        {
            var s = new ArraySegment<byte>(m_bytes, Position, length);
            Position += length;
            return s;
        }
    }

    struct Glb
    {
        public ArraySegment<byte> Json;

        public void Parse(byte[] bytes)
        {
            var r = new ByteReader(bytes);
            var magic = r.Int32();
            if (magic != 0x46546C67)
            {
                throw new Exception();
            }

            var version = r.Int32();
            if (version != 2)
            {
                throw new Exception();
            }

            var length = r.Int32();
            while (r.Position < length)
            {
                var chunkLength = r.Int32();
                var chunkType = r.Int32();
                var chunkData = r.Bytes(chunkLength);
                if (chunkType == 0x4E4F534A)
                {
                    Json = chunkData;
                }
            }
        }
    }

    public static class Validator
    {
        public static ValidationContext Validate(string path)
        {
            var bytes = File.ReadAllBytes(path);

            var ext = Path.GetExtension(path).ToLower();
            switch (ext)
            {
                case ".gltf":
                    return Validate(bytes);

                case ".glb":
                case ".vrm":
                    {
                        Glb glb = default;
                        glb.Parse(bytes);
                        return Validate(glb.Json);
                    }

                default:
                    throw new NotImplementedException();
            }
        }

        public static ValidationContext Validate(ArraySegment<byte> bytes)
        {
            var options = new JsonDocumentOptions
            {

            };

#if DEBUG
            // var jsonString = Encoding.UTF8.GetString(bytes);
            // Console.WriteLine(jsonString);
#endif

            using (var document = JsonDocument.Parse(bytes, options))
            {
                return Validate(document.RootElement);
            }
        }

        static ValidationContext Validate(JsonElement root)
        {
            var context = new ValidationContext(root);
            var validator = new gltf__Validator(context);
            validator.Validate(root);
            foreach (var msg in context.Messages)
            {
                Console.WriteLine(msg);
            }
            return context;
        }
    }
}
