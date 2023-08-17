namespace BinaryTree
{
   
    class BinaryTreeNode<T> : IComparable<T>, IComparable where T: IComparable, IComparable<T>
    {
        public T Data { get; set; }
        public BinaryTreeNode<T> Left { get; set; }
        public BinaryTreeNode<T> Right { get; set; }

        public BinaryTreeNode(T data) {
            Data = data;  
        }

        public BinaryTreeNode(T data, BinaryTreeNode<T> left, BinaryTreeNode<T> right) {
            Data = data;
            Left = left;
            Right = right;
        }
        public void Add(T data) {
            var node = new BinaryTreeNode<T>(data);
            if (node.Data.CompareTo(Data) == -1)
            {

                if (Left == null)
                {
                    Left = node;
                }
                else
                {
                    Left.Add(data);

                }

            }
            else {
                if (Right == null)
                {
                    Right = node;

                }
                else {
                    Right.Add(data);
                
                
                }
            
            
            }
        }
        public int CompareTo(object obj)
        {
            if (obj is BinaryTreeNode<T> item)
            {
                return Data.CompareTo(item);

            }
            else {
                throw new Exception("Несовпадение типов");
            
            }

        }
        public int CompareTo(T other) {

            return Data.CompareTo(other);
        }
        public override string ToString()
        {
            return Data.ToString();
        }

    }


}
