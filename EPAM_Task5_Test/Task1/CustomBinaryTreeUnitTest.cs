using EPAM_Task5.Task1;
using EPAM_Task5.Task1.CustomBinaryTree;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace EPAM_Task5_Test.Task1_Test
{
    /// <summary>
    /// testing class CustumBinaryTree.
    /// </summary>
    public class CustomBinaryTreeUnitTest
    {
        private List<Student> _studentTests;
        private BinaryTree<Student> _binaryTree;

        /// <summary>
        /// CustomBinaryTreeUnitTest test objects.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _studentTests = new List<Student>
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

            _binaryTree = new BinaryTree<Student>(_studentTests);
        }

        /// <summary>
        /// tests constructor CustomBinaryTree
        /// </summary>
        [Test]
        public void Test_CustomBinaryTree()
        {
            var result = new BinaryTree<Student>(_studentTests);

            Assert.AreEqual(result, _binaryTree);
        }

        /// <summary>
        /// tests method Add
        /// </summary>
        [Test]
        public void Test_Add()
        {
            var studentTest = new Student { StudentName = "aaa", Test = "bbb", Date = new DateTime(2012, 10, 23), Score = 56 };
            _binaryTree.Add(studentTest);

            var actualResult = new BinaryTree<Student>(_studentTests);
            actualResult.Add(studentTest);

            Assert.AreEqual(_binaryTree, actualResult);
        }

        /// <summary>
        /// tests method Add throw ArgumentException.
        /// </summary>
        [Test]
        public void Test_Add_ThrowArgumentException()
        {
            var studentTest = new Student { StudentName = "aaa", Test = "bbb", Date = new DateTime(2012, 10, 23), Score = 87 };
            Assert.That(() => _binaryTree.Add(studentTest), Throws.ArgumentException);
        }

        /// <summary>
        /// tests method TreeBalancing.
        /// </summary>
        [Test]
        public void Test_TreeBalancing()
        {
            var studentTests = new List<Student>
            {
                new Student { StudentName = "aaa",
                              Test = "bbb",
                              Date = new DateTime(2012, 10, 23),
                              Score = 45 },

                new Student { StudentName = "aaa",
                              Test = "bbb",
                              Date = new DateTime(2012, 10, 23),
                              Score = 87 },

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

            var actualResult = new BinaryTree<Student>(studentTests);

            _binaryTree.TreeBalancing();

            Assert.AreEqual(_binaryTree, actualResult);
        }

        /// <summary>
        /// tests method ConvertTreeToStudentTestsList.
        /// </summary>
        [Test]
        public void Test_ConvertTreeToStudentTestsList()
        {
            var actualResult = new List<Student>
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
                              Score = 33 },

                new Student { StudentName = "aaa",
                              Test = "bbb",
                              Date = new DateTime(2012, 10, 23),
                              Score = 92 },
            };

            var result = new List<Student>();
            _binaryTree.ConvertingTreeToListTests(_binaryTree.Root, result);

            Assert.AreEqual(result, actualResult);
        }
    }
}