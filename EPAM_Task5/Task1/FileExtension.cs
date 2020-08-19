using EPAM_Task5.Task1.CustomBinaryTree;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace EPAM_Task5.Task1.FileWork
{
    /// <summary>
    /// writing and reading the binary tree
    /// </summary>
    public static class FileExtension
    {
        /// <summary>
        /// reads the binary tree from xml file
        /// </summary>
        /// <param name="path"></param>
        /// <param name="tree"></param>
        public static void SerializeTree(string path, BinaryTree<Student> tree)
        {
            var studentTests = new List<Student>();
            tree.ConvertingTreeToListTests(tree.Root, studentTests);
            
            using (var stream = new FileStream(path, FileMode.Open))
            {
                var xmlSerializer = new XmlSerializer(studentTests.GetType());
                xmlSerializer.Serialize(stream, studentTests);
            }
        }

        /// <summary>
        /// writes the binary tree to xml file
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static BinaryTree<Student> DeserializeTree(string path)
        {
            using (var stream = new FileStream(path, FileMode.Open))
            {
                var xmlSerializer = new XmlSerializer(typeof(List<Student>));
                var studentTests = (List<Student>)xmlSerializer.Deserialize(stream);
                return new BinaryTree<Student>(studentTests);
            }
        }
    }
}
