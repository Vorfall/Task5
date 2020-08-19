using EPAM_Task5.Task2;
using EPAM_Task5.Task2.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;

namespace EPAM_Task5_Test.Task2_Test
{
    /// <summary>
    /// Class for testing class Serializer.
    /// </summary>
    public class SerializerUnitTest
    {
        private string _xmlPath;
        private string _binaryPath;
        private string _jsonPath;
        private string _xmlCollectionPath;
        private string _binaryCollectionPath;
        private string _jsonCollectionPath;
        private Book _book;
        private BooksCollection<Book> _booksCollection;

        /// <summary>
        /// Initializes SerializerUnitTest test objects.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _binaryPath = @"..\..\..\..\EPAM_Task5\Task2\Resources\BinaryFile.dat";
            _xmlPath = @"..\..\..\..\EPAM_Task5\Task2\Resources\XmlFile.xml";
            _jsonPath = @"..\..\..\..\EPAM_Task5\Task2\Resources\JsonFile.json";

            _binaryCollectionPath = @"..\..\..\..\EPAM_Task5\Task2\Resources\BinaryFileCollection.dat";
            _xmlCollectionPath = @"..\..\..\..\EPAM_Task5\Task2\Resources\XmlFileCollection.xml";
            _jsonCollectionPath = @"..\..\..\..\EPAM_Task5\Task2\Resources\JsonFileCollection.json";

            _book = new Book() { FullName = "Ivan",
                                 Genre = "gsfgaaaaa",
                                 PlaceOfWriting = "OOO" };

            _booksCollection = new BooksCollection<Book>(new List<Book>
            {
                new Book() { FullName = "fsfsdf",
                             Genre = "sgsgsfg",
                             PlaceOfWriting = "sgsgs" },

                new Book() { FullName = "ldmbslk",
                             Genre = "sghhgdgs",
                             PlaceOfWriting = "htyhfbg" },

                new Book() { FullName = "gwpgjwn",
                             Genre = "pvww",
                             PlaceOfWriting = "vnxcmvbsdl" }
            });
        }

        /// <summary>
        /// The method tests method SerializeToBinary with  BooksCollection and  Books.
        /// </summary>
        [Test]
        public void Test_SerializeCollectionAndObjectToBinaryFile()
        {
            Serializer<BooksCollection<Book>>.SerializeToBinary(_binaryCollectionPath, _booksCollection);
            Serializer<Book>.SerializeToBinary(_binaryPath, _book);
            var fileInfoCollection = new FileInfo(_binaryCollectionPath);
            var fileInfoObject = new FileInfo(_binaryPath);
            Assert.IsTrue(fileInfoCollection.Length > 0);
            Assert.IsTrue(fileInfoObject.Length > 0);
        }

        /// <summary>
        /// The method tests method DeserializeFromBinary with  BooksCollection and  Books.
        /// </summary>
        [Test]
        public void Test_DeserializeCollectionAndObjectFromBinaryFile()
        {
            BooksCollection<Book> resultCollection = Serializer<BooksCollection<Book>>.DeserializeFromBinary(_binaryCollectionPath);
            Book result = Serializer<Book>.DeserializeFromBinary(_binaryPath);
            Assert.AreEqual(resultCollection, _booksCollection);
            Assert.AreEqual(result, _book);
        }

        /// <summary>
        /// The method tests method SerializeToXml with  BooksCollection and  Books.
        /// </summary>
        [Test]
        public void Test_SerializeCollectionAndObjectToXmlFile()
        {
            Serializer<BooksCollection<Book>>.SerializeToXml(_xmlCollectionPath, _booksCollection);
            Serializer<Book>.SerializeToXml(_xmlPath, _book);
            var fileInfoCollection = new FileInfo(_xmlCollectionPath);
            var fileInfoObject = new FileInfo(_xmlPath);
            Assert.IsTrue(fileInfoCollection.Length > 0);
            Assert.IsTrue(fileInfoObject.Length > 0);
        }

        /// <summary>
        /// tests method DeserializeFromXml with  BooksCollection and  Books.
        /// </summary>
        [Test]
        public void Test_DeserializeCollectionAndObjectFromXmlFile()
        {
            BooksCollection<Book> resultCollection = Serializer<BooksCollection<Book>>.DeserializeFromXml(_xmlCollectionPath);
            Book result = Serializer<Book>.DeserializeFromXml(_xmlPath);
            Assert.AreEqual(resultCollection, _booksCollection);
            Assert.AreEqual(result, _book);
        }

        /// <summary>
        /// tests method SerializeToJson with  BooksCollection and  Books
        /// </summary>
        [Test]
        public void Test_SerializeCollectionAndObjectToJsonFile()
        {
            Serializer<BooksCollection<Book>>.SerializeToJson(_jsonCollectionPath, _booksCollection);
            Serializer<Book>.SerializeToJson(_jsonPath, _book);
            var fileInfoCollection = new FileInfo(_jsonCollectionPath);
            var fileInfoObject = new FileInfo(_jsonPath);
            Assert.IsTrue(fileInfoCollection.Length > 3);
            Assert.IsTrue(fileInfoObject.Length > 3);
        }

        /// <summary>
        /// tests method DeserializeFromJson with  BooksCollection and  Books
        /// </summary>
        [Test]
        public void Test_DeserializeCollectionAndObjectFromJsonFile()
        {
            BooksCollection<Book> resultCollection = Serializer<BooksCollection<Book>>.DeserializeFromJson(_jsonCollectionPath);
            Book result = Serializer<Book>.DeserializeFromJson(_jsonPath);
            Assert.AreEqual(resultCollection, _booksCollection);
            Assert.AreEqual(result, _book);
        }
    }
}