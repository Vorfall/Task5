using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace EPAM_Task5.Task2.Models
{
    /// <summary>
    /// books collection
    /// </summary>
    /// <typeparam name="T">book</typeparam>
    [Serializable]
    [DataContract]
    public class BooksCollection<T> : ICollection<T> where T : Book
    {
        [DataMember]
        private List<T> _books;

        /// <summary>
        /// initialise books collection
        /// </summary>
        /// <param name="booksCollection"></param>
        public BooksCollection(IEnumerable<T> booksCollection)
        {
            _books = booksCollection.ToList();
        }

        /// <summary>
        /// interacting with the books collection
        /// </summary>
        /// <param name="index"></param>
        /// <returns>book</returns>
        public T this[int index]
        {
            get => _books[index];
            set => _books[index] = value;
        }

        /// <summary>
        /// removes the book from the books collection
        /// </summary>
        /// <param name="item">book</param>
        /// <returns>True or False</returns>
        public bool Remove(T item) => _books.Remove(item);



        public int Count => _books.Count;

        public bool IsReadOnly => false;

        /// <summary>
        /// adds book to the books collection
        /// </summary>
        /// <param name="item">book</param>
        public void Add(T item) => _books.Add(item);
        

        /// <summary>
        /// clears the books collection
        /// </summary>
        public void Clear() => _books.Clear();
        

        /// <summary>
        /// checks if the book is contained in the books collection
        /// </summary>
        /// <param name="item">book</param>
        /// <returns>True or False</returns>
        public bool Contains(T item) => _books.Contains(item);
        

        /// <summary>
        /// copys the books collection into array
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(T[] array, int arrayIndex) => _books.CopyTo(array, arrayIndex);
        

        /// <summary>
        /// gets enumerator
        /// </summary>
        /// <returns>Enumerator</returns>
        public IEnumerator<T> GetEnumerator() => _books.GetEnumerator();


        /// <summary>
        /// calculates the hash code for the current object
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode() => _books.Select(obj => obj.GetHashCode() >> 32).Sum();



        /// <summary>
        /// equal the current object with the specified object
        /// </summary>
        /// <param name="obj">Any object</param>
        /// <returns>True or False</returns>
        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            var booksCollection = (BooksCollection<Book>)obj;

            if (Count != booksCollection.Count)
            {
                return false;
            }

            for (var i = 0; i < Count; i++)
            {
                if (!_books[i].Equals(booksCollection._books[i]))
                {
                    return false;
                }
            }

            return true;
        }

      
        /// <summary>
        /// creates and returns a string representation of the object
        /// </summary>
        /// <returns>String representation</returns>
        public override string ToString()
        {
            var booksString = "books:\n\n";

            foreach (Book book in _books)
            {
                booksString += book.ToString() + "\n\n";
            }

            return booksString;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        
    }
}
