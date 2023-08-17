using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BinaryTree
{
    class BinaryTree<T> where T : IComparable, IComparable<T>
    {
        public BinaryTreeNode<T> Root { get; set; }
        public int Count { get; set; }
        public void Add(T data) { 

            if (Root == null) {
                Root = new BinaryTreeNode<T>(data);
                Count = 1;
                return;
        
            }
            Root.Add(data);
            Count++;

        }
        public List<T> Preorder() {
            var list = new List<T>();

            if (Root == null) {
                return list;
            }
            return Preorder(Root);
        }
        public List<T> Preorder(BinaryTreeNode<T> node) { 
            var list = new List<T>();
            if(node!= null) {
                list.Add(node.Data);
                if (node.Left != null) { 
                    list.AddRange(Preorder(node.Left)); 
                }
                if(node.Right != null) 
                {
                    list.AddRange(Preorder(node.Right));
                }
            
            }
            return list;

        }
        public List<T> Postorder()
        {
            var list = new List<T>();

            if (Root == null)
            {
                return list;
            }
            return Postorder(Root);
        }
        public List<T> Postorder(BinaryTreeNode<T> node)
        {
            var list = new List<T>();
            if (node != null)
            {
                if (node.Left != null)
                {
                    list.AddRange(Postorder(node.Left));
                }
                if (node.Right != null)
                {
                    list.AddRange(Postorder(node.Right));
                }
                list.Add(node.Data);

            }
            return list;

        }
        
        public bool Search(string value)
        {
            return SearchRecursive(Root, value);
        }

        private bool SearchRecursive(BinaryTreeNode<T> current, string data)
        {
            if (current == null)
            {
                return false;
            }

            if (String.Compare(data, current.Data.ToString()) == 0)
            {
                return true;
            }
            else if (String.Compare(data, current.Data.ToString()) < 0)
            {
                return SearchRecursive(current.Left, data);
            }
            else
            {
                return SearchRecursive(current.Right, data);
            }
        }
        public void DisplayTreeView(TreeView treeView)
        {
            treeView.Nodes.Clear();
            if (Root != null)
            {
                TreeNode rootNode = new TreeNode(Root.Data.ToString());
                treeView.Nodes.Add(rootNode);
                DisplayTreeViewRecursive(Root, rootNode);
            }
        }

        private void DisplayTreeViewRecursive(BinaryTreeNode<T> current, TreeNode parentNode)
        {
            if (current.Left != null)
            {
                TreeNode leftNode = new TreeNode(current.Left.Data.ToString());
                parentNode.Nodes.Add(leftNode);
                DisplayTreeViewRecursive(current.Left, leftNode);
            }

            if (current.Right != null)
            {
                TreeNode rightNode = new TreeNode(current.Right.Data.ToString());
                parentNode.Nodes.Add(rightNode);
                DisplayTreeViewRecursive(current.Right, rightNode);
            }
        }


    }

}
