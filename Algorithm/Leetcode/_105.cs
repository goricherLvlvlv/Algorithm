using Algorithm.DataStruct;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.Leetcode
{
    class _105
    {
        Dictionary<int, int> inorderMap = new Dictionary<int, int>();
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            for (int i = 0; i < inorder.Length; ++i)
            {
                inorderMap[inorder[i]] = i;
            }
            return build(preorder, 0, preorder.Length - 1, inorder, 0, inorder.Length - 1);
        }

        public TreeNode build(int[] preorder, int preBeginIdx, int preEndIdx, int[] inorder, int inBeginIdx, int inEndIdx)
        {
            if (preBeginIdx > preEndIdx || inBeginIdx > inEndIdx)
            {
                return null;
            }

            TreeNode node = new TreeNode(preorder[preBeginIdx]);
            // 寻找下标
            int idx = inorderMap[node.val];
            int leftLength = idx - inBeginIdx;
            node.left = build(preorder, preBeginIdx + 1, preBeginIdx + leftLength, inorder, inBeginIdx, idx - 1);
            node.right = build(preorder, preBeginIdx + leftLength + 1, preEndIdx, inorder, idx + 1, inEndIdx);

            return node;
        }
    }
}
