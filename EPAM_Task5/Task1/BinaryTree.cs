using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPAM_Task5.Task1.CustomBinaryTree
{
    /// <summary>
    /// binary tree.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinaryTree<T> where T : Student
    {
        /// <summary>
        /// Binary tree root.
        /// </summary>
        public Node<T> Root
        {
            get;
            set;
        }


        /// <summary>
        /// The method adds a value to the binary tree.
        /// </summary>
        /// <param name="value"></param>
        public void Add(T value)
        {
            Node<T> nNode = this.Root;
            Node<T> pNode = null;

            while (nNode != null)
            {
                pNode = nNode;

                if (nNode.Data.CompareTo(value) == -1)
                {
                    nNode = nNode.RNode;
                }
                else if (nNode.Data.CompareTo(value) == 1)
                    {
                        nNode = nNode.LNode;
                    }
                     else
                     {
                          throw new ArgumentException("");
                      }
            }

            Node<T> newNode = new Node<T>(value);

            if (this.Root == null)
            {
                this.Root = newNode;
            }
            else
            {
                if (pNode.Data.CompareTo(value) == -1)
                {
                    pNode.RNode = newNode;
                }
                else
                {
                    pNode.LNode = newNode;
                }
            }
        }


        /// <summary>
        /// initialization binary tree
        /// </summary>
        /// <param name="TestsCollection"></param>
        public BinaryTree(IEnumerable<T> TestsCollection)
        {
            foreach (T studentTest in TestsCollection)
            {
                this.Add(studentTest);
            }
        }

        /// <summary>
        /// balances the tree.
        /// </summary>
        public void TreeBalancing()
        {
            List<Node<T>> nodes = new List<Node<T>>();
            ConvertTreeToNodesList(this.Root, nodes);

            int nodesCount = nodes.Count;
            this.Root = ConvertTreeToBalancedTree(nodes, 0, nodesCount - 1);
        }

       
        /// <summary>
        /// converts the tree to the tests list
        /// </summary>
        /// <param name="node"></param>
        /// <param name="studentTestsCollection"></param>
        public void ConvertingTreeToListTests(Node<T> node, IList<T> studentTestsCollection)
        {
            if (node == null)
            {
                return;
            }

            studentTestsCollection.Add(node.Data);
            ConvertingTreeToListTests(node.LNode, studentTestsCollection);
            ConvertingTreeToListTests(node.RNode, studentTestsCollection);
        }

        /// <summary>
        /// converts the tree to the balanced tree
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns>Tree root</returns>
        private Node<T> ConvertTreeToBalancedTree(List<Node<T>> nodes, int start, int end)
        {
            if (start > end)
            {
                return null;
            }

            int middle = (start + end) / 2;
            Node<T> node = nodes[middle];

            node.LNode = ConvertTreeToBalancedTree(nodes, start, middle - 1);
            node.RNode = ConvertTreeToBalancedTree(nodes, middle + 1, end);

            return node;
        }

        /// <summary>
        /// converts the tree to the nodes list
        /// </summary>
        /// <param name="root"></param>
        /// <param name="nodes"></param>
        private void ConvertTreeToNodesList(Node<T> root, List<Node<T>> nodes)
        {
            if (root == null)
            {
                return;
            }

            ConvertTreeToNodesList(root.LNode, nodes);
            nodes.Add(root);
            ConvertTreeToNodesList(root.RNode, nodes);
        }

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

            BinaryTree<Student> binaryTree = (BinaryTree<Student>)obj;

            List<Student> newStudentTests = new List<Student>();
            List<T> thisStudentTests = new List<T>();
             
            binaryTree.ConvertingTreeToListTests(binaryTree.Root, newStudentTests);
            this.ConvertingTreeToListTests(this.Root, thisStudentTests);

            if (thisStudentTests.Count == newStudentTests.Count)
            {
                for (var i = 0; i < newStudentTests.Count; i++)
                {
                    if (!newStudentTests[i].Equals(thisStudentTests[i]))
                    {
                        return false;
                    }
                }

                return true; 
            }

            return false;
        }

        /// <summary>
        /// calculates the hash code for the current object
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            List<T> TestsStudent = new List<T>();
            this.ConvertingTreeToListTests(this.Root, TestsStudent);

            return TestsStudent.Select(obj => obj.GetHashCode() >> 32).Sum();
        }

        /// <summary>
        /// creates and returns a string representation of the object.
        /// </summary>
        public override string ToString()
        {
            List<T> thisStudentTests = new List<T>();
            this.ConvertingTreeToListTests(this.Root, thisStudentTests);

            var stringBuilder = new StringBuilder();

            foreach (T studentTest in thisStudentTests)
            {
                stringBuilder.Append(studentTest);
                stringBuilder.Append("\n\n");
            }

            return stringBuilder.ToString();
        }

       
    }
}
