using EPAM_Task5.Task2.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EPAM_Task5_Test.Task2_Test
{
    /// <summary>
    /// testing class booksCollection
    /// </summary>
    public class BooksCollectionUnitTest
    {
        private BooksCollection<Book> _booksCollection;
        private Book[] _booksArray;

        /// <summary>
        /// booksCollectionUnitTest test objects
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            _booksCollection = new BooksCollection<Book>(new List<Book>
            {
                new Book() { FullName = "1",
                             Genre = "4",
                             PlaceOfWriting = "Minsk",
                             Price = 123.45m },
                new Book() { FullName = "2",
                             Genre = "5",
                             PlaceOfWriting = "Gomel",
                             Price = 666.66m },
                new Book() { FullName = "3",
                             Genre = "6",
                             PlaceOfWriting = "Brest",
                             Price = 9999.99m }
            });

            _booksArray = new Book[]
            {
                new Book() { FullName = "2",
                             Genre = "5",
                             PlaceOfWriting = "Gomel",
                             Price = 666.66m },

                new Book() { FullName = "3",
                             Genre = "6",
                             PlaceOfWriting = "Brest",
                             Price = 9999.99m },

                new Book(),
            };
        }

        /// <summary>
        /// tests method Add
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="genre"></param>
        /// <param name="placeOfWriting"></param>
        /// <param name="salary"></param>
        [TestCase("Kerry", "Horror", "State of Maine", 1111.11)]
        [TestCase("Ilya", "Fantasy", "State of Maine", 2222.22)]
        public void Test_Add(string fullName, string genre, string placeOfWriting, decimal salary)
        {
            var book = new Book { FullName = fullName, Genre = genre, PlaceOfWriting = placeOfWriting, Price = salary };
            _booksCollection.Add(book);
            Assert.AreEqual(_booksCollection[_booksCollection.Count - 1], book);
        }

        /// <summary>
        /// tests method Clear
        /// </summary>
        [Test]
        public void Test_Clear()
        {
            _booksCollection.Clear();
            var actualResult = 0;
            Assert.AreEqual(_booksCollection.Count, actualResult);
        }

        /// <summary>
        /// tests method Contains
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="genre"></param>
        /// <param name="placeOfWriting"></param>
        /// <param name="salary"></param>
        /// <param name="actualResult">Is contain</param>
        [TestCase("1", "4", "Minsk", 123.45, true)]
        [TestCase("Kerry", "Horror", "State of Maine", 1111.11, false)]
        public void Test_Contains(string fullName, string genre, string placeOfWriting, decimal salary, bool actualResult)
        {
            var book = new Book { FullName = fullName, Genre = genre, PlaceOfWriting = placeOfWriting, Price = salary };
            bool result = _booksCollection.Contains(book);
            Assert.AreEqual(result, actualResult);
        }

        /// <summary>
        /// tests method CopyTo
        /// </summary>
        [Test]
        public void Test_CopyTo()
        {
            var resultArray = new Book[]
            {
                new Book() { FullName = "1",
                             Genre = "4",
                             PlaceOfWriting = "Minsk",
                             Price = 123.45m },

                new Book() { FullName = "2",
                             Genre = "5",
                             PlaceOfWriting = "Gomel",
                             Price = 666.66m },

                new Book() { FullName = "3",
                             Genre = "6",
                             PlaceOfWriting = "Brest",
                             Price = 9999.99m }
            };

            _booksCollection.CopyTo(_booksArray, 0);
            CollectionAssert.AreEqual(resultArray, _booksArray);
        }

        /// <summary>
        /// tests method Remove
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="genre"></param>
        /// <param name="placeOfWriting"></param>
        /// <param name="salary"></param>
        /// <param name="actualResult">Is removed</param>
        [TestCase("1", "4", "Minsk", 123.45, true)]
        [TestCase("Kerry", "Horror", "State of Maine", 1111.11, false)]
        public void Test_Remove(string fullName, string genre, string placeOfWriting, decimal salary, bool actualResult)
        {
            var book = new Book { FullName = fullName, Genre = genre, PlaceOfWriting = placeOfWriting, Price = salary };
            bool result = _booksCollection.Remove(book);
            Assert.AreEqual(result, actualResult);
        }
    }
}
