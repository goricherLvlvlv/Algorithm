using System;
using System.Collections.Generic;
using System.Text;
using Algorithm.DataStruct;

namespace Algorithm.Leetcode
{
    class _124
    {
        int ans = int.MinValue;
        public int MaxPathSum(TreeNode root)
        {
            Cal(root);
            return ans;
        }

        int Cal(TreeNode root)
        {
            if (root is null) return 0;

            int left = Math.Max(0, Cal(root.left));
            int right = Math.Max(0, Cal(root.right));

            // 更新结果
            ans = Math.Max(ans, left + right + root.val);

            // 返回值只能走一条路, 左路或者右路, 这是该节点能贡献的最大值
            return Math.Max(left, right) + root.val;
        }
    }
}
