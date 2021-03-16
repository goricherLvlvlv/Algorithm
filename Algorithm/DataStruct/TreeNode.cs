using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.DataStruct
{
    public class TreeNode
    {
        #region static variable
        public static TreeNode Empty = new TreeNode();
        #endregion

        #region variable
        private readonly int? flag;
        public int val;
        public TreeNode left;
        public TreeNode right;
        #endregion

        #region override
        public static bool operator ==(TreeNode node1, TreeNode node2)
        {
            if (node1 is null && node2 is null)
            {
                return true;
            }
            else if (node1 is null)
            {
                return node2.Equals(node1);
            }
            else
            {
                return node1.Equals(node2);
            }

        }

        public static bool operator !=(TreeNode node1, TreeNode node2)
        {
            return !(node1 == node2);
        }

        public override bool Equals(object obj)
        {
            // 特殊的判空逻辑
            if (obj == null && this.flag == null)
            {
                return true;
            }

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion

        #region construct
        public TreeNode() => this.flag = null;

        public TreeNode(int val, TreeNode left = null, TreeNode right = null)
        {
            this.flag = val;
            this.val = val;
            this.left = left;
            this.right = right;
        }

        // 横向建立二叉树
        public TreeNode(params int?[] arr)
        {
            if (arr[0] == null)
            {
                return;
            }

            this.flag = arr[0].Value;
            this.val = arr[0].Value;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(this);

            for (int i = 1; i < arr.Length; ++i)
            {
                // 存在队列头
                queue.TryPeek(out TreeNode curRoot);
                TreeNode node;
                if (arr[i] != null)
                {
                    node = new TreeNode(arr[i].Value);
                    queue.Enqueue(node);
                }
                else
                {
                    node = TreeNode.Empty;
                }

                if (curRoot == null)
                {
                    continue;
                }
                else if (curRoot.left is null)
                {
                    curRoot.left = node;
                }
                else if (curRoot.right is null)
                {
                    curRoot.right = node;
                }
                else
                {
                    queue.Dequeue();
                    queue.TryPeek(out curRoot);
                    curRoot.left = node;
                }
            }
        }
        #endregion

        #region function

        public void PreOrderTraversal()
        {
            if (this == null) return;

            Console.WriteLine(this.val);
            left?.PreOrderTraversal();
            right?.PreOrderTraversal();
        }

        public void InOrderTraversal()
        {
            if (this == null) return;

            left?.InOrderTraversal();
            Console.WriteLine(this.val);
            right?.InOrderTraversal();
        }

        public void PostOrderTraversal()
        {
            if (this == null) return;

            left?.PostOrderTraversal();
            right?.PostOrderTraversal();
            Console.WriteLine(this.val);
        }

        #endregion
    }
}
