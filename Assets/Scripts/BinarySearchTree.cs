using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets
{
    class BinarySearchTree
    {
        TreeNode Root { get; set; }

        public BinarySearchTree(TreeNode root)
        {
            Root = root;
        }

        public static TreeNode GenerateRandomTree(int min, int max)
        {
            Random rand = new Random();
            int root = rand.Next(min, max + 1);
            TreeNode treeRoot = new TreeNode(root);
            Dictionary<int, int> map = new Dictionary<int, int>();

            for (int i=min; i <= max; i++)
            {
                map.Add(i, i);
            }

            treeRoot = new TreeNode(root);
            map.Remove(root);

            while (map.Count > 0)
            {
                int randNum = rand.Next(min, max + 1);
                if (map.Remove(randNum))
                {
                    treeRoot.Add(randNum);
                    Console.WriteLine($"Adding {randNum}...");
                }
            }


            return treeRoot;
        }

    }

    class TreeNode
    {
        public int Val { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }

        public TreeNode(int val, TreeNode left=null, TreeNode right=null)
        {
            Val = val;
            Left = left;
            Right = right;
        }

        public void Add(int add)
        {
            TreeNode newNode;
            if (add > Val)
            {
                Right = new TreeNode(add);
                //if (Right == null || Right.Val > add)
                //{
                //    newNode = new TreeNode(add, null, Right);
                //    Right = newNode;
                //}
                //else
                //{
                //    Right.Add(add);
                //}                
            }
            else
            {
                Left = new TreeNode(add);
                //if (Left == null || Left.Val < add)
                //{
                //    newNode = new TreeNode(add, Left, null);
                //    Left = newNode;
                //}
                //else
                //{
                //    Left.Add(add);
                //}
            }
        }
    }
}
