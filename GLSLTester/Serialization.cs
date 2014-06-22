using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace GLSLTester
{
    static class Serialization
    {
        public static void Export<T>(T objectToSerialize, string filename)
        {
            byte[] objectBytes;
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, objectToSerialize);
                objectBytes = stream.ToArray();

                BinaryWriter writer = new BinaryWriter(File.Open(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite));
                writer.Write(objectBytes);
                writer.Close();
            }
        }

        public static T Import<T>(string filename)
        {
            BinaryReader reader = new BinaryReader(File.Open(filename, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite));
            byte[] objectBytes = new byte[reader.BaseStream.Length];
            reader.Read(objectBytes, 0, objectBytes.Length);
            reader.Close();

            T serializedObject;
            using (MemoryStream stream = new MemoryStream(objectBytes))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                serializedObject = (T)formatter.Deserialize(stream);
            }

            return serializedObject;
        }
    }
}
