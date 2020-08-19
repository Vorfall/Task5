using System;
using System.Diagnostics.CodeAnalysis;

namespace EPAM_Task5.Task1
{
    /// <summary>
    /// student
    /// </summary>
    public class Student : IComparable<Student>
    {


        /// <summary>
        /// student name
        /// </summary>
        public string StudentName
        {
            get;
            set; 
        }


        /// <summary>
        /// test name
        /// </summary>
        public string Test
        { 
            get;
            set; 
        }


        /// <summary>
        /// test date
        /// </summary>
        public DateTime Date
        {
            get;
            set; 
        }

        /// <summary>
        /// test score
        /// </summary>
        private int _score;


        /// <summary>
        /// score
        /// </summary>
        public int Score
        {
            get => _score;

            set
            {
                if (value >= 0 && value <= 100)
                {
                    _score = value;
                }
                else 
                {
                    throw new ArgumentException("The score must be between 0 and 100"); 
                }
            }
        }


        /// <summary>
        /// sort list
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo([AllowNull] Student other) => Score.CompareTo(other.Score);


        /// <summary>
        /// calculates the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode() => StudentName.GetHashCode() ^ Test.GetHashCode() ^ Date.GetHashCode() ^ Score.GetHashCode();


        /// <summary>
        /// creates and returns a string representation of the object
        /// </summary>
        /// <returns>String representation</returns>
        public override string ToString() => string.Format($"Student Name: {StudentName}\n" +
                                                           $"Test Name: {Test}\n" +
                                                           $"Date: {Date:dd.MM.yyyy}\n" +
                                                           $"Result Test: {Score}");


        /// <summary>
        /// equal the current object with the specified object
        /// </summary>
        /// <param name="data">Any object</param>
        /// <returns>True or False</returns>
        public override bool Equals(object data)
        {
            if (data.GetType() == GetType())
            {
                var studentTest = (Student)data;

                return ((studentTest.StudentName == StudentName) && (studentTest.Test == Test) && (studentTest.Date == Date) && (studentTest.Score == Score));
               
            }
            else
            {
                return false;
            }
            
        }

     
        
    }
}
