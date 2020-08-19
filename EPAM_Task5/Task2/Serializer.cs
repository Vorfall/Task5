using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;


namespace EPAM_Task5.Task2
{
    /// <summary>
    /// reads and writes data
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class Serializer<T>
    {
        /// <summary>
        /// writes the data to the binary file
        /// </summary>
        /// <param name="path"></param>
        /// <param name="obj"></param>
        public static void SerializeToBinary(string path, T obj)
        {
            File.WriteAllText(path, string.Empty);

            using (var fileStream = new FileStream(path, FileMode.Open))
            {
                var binarySerializer = new BinaryFormatter();
                binarySerializer.Serialize(fileStream, obj);
            }
        }

        /// <summary>
        /// writes the data from the binary file
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static T DeserializeFromBinary(string path)
        {
            using (var fileStream = new FileStream(path, FileMode.Open))
            {
                var binarySerializer = new BinaryFormatter();
                return (T)binarySerializer.Deserialize(fileStream);
            }
        }

        /// <summary>
        /// writes the data to the xml file
        /// </summary>
        /// <param name="path"></param>
        /// <param name="obj"></param>
        public static void SerializeToXml(string path, T obj)
        {
            File.WriteAllText(path, string.Empty);

            using (var fileStream = new FileStream(path, FileMode.Open))
            {
                var xmlSerializer = new DataContractSerializer(typeof(T));
                xmlSerializer.WriteObject(fileStream, obj);
            }
        }

        /// <summary>
        /// writes the data from the xml file
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static T DeserializeFromXml(string path)
        {
            using (var fileStream = new FileStream(path, FileMode.Open))
            {
                var xmlSerializer = new DataContractSerializer(typeof(T));
                return (T)xmlSerializer.ReadObject(fileStream);
            }
        }

        /// <summary>
        /// writes the data to the json file
        /// </summary>
        /// <param name="path"></param>
        /// <param name="obj"></param>
        public static void SerializeToJson(string path, T obj)
        {
            File.WriteAllText(path, string.Empty);

            using (var fileStream = new FileStream(path, FileMode.Open))
            {
                var jsonSerializer = new DataContractJsonSerializer(typeof(T));
                jsonSerializer.WriteObject(fileStream, obj);
            }
        }

        /// <summary>
        /// writes the data from the json file
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static T DeserializeFromJson(string path)
        {
            using (var fileStream = new FileStream(path, FileMode.Open))
            {
                var jsonSer = new DataContractJsonSerializer(typeof(T));
                return (T)jsonSer.ReadObject(fileStream);
            }
        }

    }
}
