using EPAM_Task5.Task1;
using EPAM_Task5.Task1.CustomBinaryTree;
using EPAM_Task5.Task1.FileWork;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace EPAM_Task5_Test.Task1_Test
{
    /// <summary>
    /// testing class FileExtension
    /// </summary>
    public class FileExtensionUnitTest
    {
        private string _filePath;
        private string _xmlFileContent;
        private BinaryTree<Student> _binaryTree;

        /// <summary>
        /// FileExtensionUnitTest test objects
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _filePath = @"..\..\..\..\EPAM_Task5\Task1\BinaryTree\BinaryTree.xml";

            var studentTests = new List<Student>
            {
                new Student { StudentName = "aaa",
                              Test = "bbb",
                              Date = new DateTime(2012, 10, 23),
                              Score = 87 },

                new Student { StudentName = "aaa",
                              Test = "bbb",
                              Date = new DateTime(2012, 10, 23),
                              Score = 45 },

                new Student { StudentName = "aaa",
                              Test = "bbb",
                              Date = new DateTime(2012, 10, 23),
                              Score = 13 },

                new Student { StudentName = "aaa",
                              Test = "bbb",
                              Date = new DateTime(2012, 10, 23),
                              Score = 92 },

                new Student { StudentName = "aaa",
                              Test = "bbb",
                              Date = new DateTime(2012, 10, 23),
                              Score = 33 },
            };

            _binaryTree = new BinaryTree<Student>(studentTests);

            _xmlFileContent = "<?xml version=\"1.0\"?>\r\n" +
                              "<ArrayOfStudent xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n" +
                              "  <Student>\r\n" +
                              "    <StudentName>aaa</StudentName>\r\n" +
                              "    <Test>bbb</Test>\r\n" +
                              "    <Date>2012-10-23T00:00:00</Date>\r\n" +
                              "    <Score>87</Score>\r\n" +
                              "  </Student>\r\n" +
                              "  <Student>\r\n" +
                              "    <StudentName>aaa</StudentName>\r\n" +
                              "    <Test>bbb</Test>\r\n" +
                              "    <Date>2012-10-23T00:00:00</Date>\r\n" +
                              "    <Score>45</Score>\r\n" +
                              "  </Student>\r\n" +
                              "  <Student>\r\n" +
                              "    <StudentName>aaa</StudentName>\r\n" +
                              "    <Test>bbb</Test>\r\n" +
                              "    <Date>2012-10-23T00:00:00</Date>\r\n" +
                              "    <Score>13</Score>\r\n" +
                              "  </Student>\r\n" +
                              "  <Student>\r\n" +
                              "    <StudentName>aaa</StudentName>\r\n" +
                              "    <Test>bbb</Test>\r\n" +
                              "    <Date>2012-10-23T00:00:00</Date>\r\n" +
                              "    <Score>33</Score>\r\n" +
                              "  </Student>\r\n" +
                              "  <Student>\r\n" +
                              "    <StudentName>aaa</StudentName>\r\n" +
                              "    <Test>bbb</Test>\r\n" +
                              "    <Date>2012-10-23T00:00:00</Date>\r\n" +
                              "    <Score>92</Score>\r\n" +
                              "  </Student>\r\n" +
                              "</ArrayOfStudent>";
        }

        /// <summary>
        /// tests method SerializeBinaryTree
        /// </summary>
        [Test]
        public void Test_SerializeBinaryTree()
        {
            FileExtension.SerializeTree(_filePath, _binaryTree);

            string Score;
            string actualScore;

            using (var streamReader = new StreamReader(_filePath))
            {
                Score = streamReader.ReadToEnd();
                actualScore = _xmlFileContent;
            }

            Assert.AreEqual(Score, actualScore);
        }

        /// <summary>
        /// tests method DeserializeBinaryTree
        /// </summary>
        [Test]
        public void Test_DeserializeBinaryTree()
        {
            BinaryTree<Student> newBinaryTree = FileExtension.DeserializeTree(_filePath);
            Assert.AreEqual(newBinaryTree, _binaryTree);
        }
    }
}
