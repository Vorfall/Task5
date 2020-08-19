using System;
using System.Runtime.Serialization;

namespace EPAM_Task5.Task2.Models
{
    /// <summary>
    /// book
    /// </summary>
    [Serializable]
    [DataContract]
    public class Book
    {
        public Book()
        {
        }

        [DataMember]
        public string FullName { get; set; }

        [DataMember]
        public string PlaceOfWriting { get; set; }

        [DataMember]
        public string Genre { get; set; }

        [DataMember(Order = 2)]
        public decimal Price { get; set; }

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

            var book = (Book)obj;

            return ((book.FullName == this.FullName) && (book.PlaceOfWriting == this.PlaceOfWriting) &&
                    (book.Genre == this.Genre) && (book.Price == this.Price));
        }

        /// <summary>
        /// calculates the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode() => FullName.GetHashCode() ^ PlaceOfWriting.GetHashCode() ^ Genre.GetHashCode() ^ Price.GetHashCode();
        

        /// <summary>
        ///The method creates and returns a string representation
        /// </summary>
        /// <returns>String representation</returns>
        public override string ToString() => string.Format($"FullName: {this.FullName}\n" +
                                                           $"PlaceOfWriting: {this.PlaceOfWriting}\n" +
                                                           $"Genre: {this.Genre}\n" +
                                                           $"Price: {this.Price,6:f2}");
        

        /// <summary>
        /// sets a value to Price if Price is null
        /// </summary>
        /// <param name="context"></param>
        [OnDeserializing]
        private void SetSalaryDefault(StreamingContext context)
        {
            Price = 111.3m;
        }
    }
}
