namespace EPAM_Task5.Task1.CustomBinaryTree
{
    /// <summary>
    /// implements a node
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Node<T>
    {


        /// <summary>
        /// right node
        /// </summary>
        public Node<T> RNode
        { 
            get;
            set;
        }


        /// <summary>
        /// left node
        /// </summary>
        public Node<T> LNode 
        { 
            get;
            set;
        }


        /// <summary>
        /// node value
        /// </summary>
        public T Data 
        {
            get;
            set; 
        }


        /// <summary>
        /// initialization the node
        /// </summary>
        /// <param name="data"></param>
        public Node(T data)
        {
            LNode = null;
            RNode = null;
            Data = data;
        }

      
    }
}
