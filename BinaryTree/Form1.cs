using System.IO;

namespace BinaryTree
{
    public partial class Form1 : Form
    {
        List<string> list = new List<string>();
        string filePath = "C:\\Users\\RBT\\source\\repos\\BinaryTree\\BinaryTree\\text.txt";
        BinaryTree<string> tree = new BinaryTree<string>();
        List<int> listInt = new List<int> { 5, 3, 7, 1, 2, 8, 6, 9 };

        public Form1()
        {
            InitializeComponent();


        }


        private async void button1_Click(object sender, EventArgs e)
        {
            TreeNode node = treeView1.SelectedNode;
            using (StreamReader reader = new StreamReader(filePath))
            {
                string text = await reader.ReadToEndAsync();
                string[] elements = text.Split(' ');
                foreach (string element in elements)
                {
                    list.Add(element);
                    textBox1.Text += (element + ' ');
                }
            }

            for (int i = 0; i < list.Count; i++)
            {
                tree.Add(list[i]);


            }
            // Создание и настройка TreeView


            // Вывод бинарного дерева в TreeView
            tree.DisplayTreeView(treeView1);


            //treeView1.Nodes.Add("Parent");
            //treeView1.Nodes[0].Nodes.Add("Child 1");
            //treeView1.Nodes[0].Nodes.Add("Child 2");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            foreach (var item in tree.Preorder())
            {
                textBox1.Text += item + ", ";

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

            textBox1.Clear();
            foreach (var item in tree.Postorder())
            {
                textBox1.Text += item + ", ";


            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += tree.Search("B");
        }
    }
}