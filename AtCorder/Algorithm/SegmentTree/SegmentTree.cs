using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtCorder.Algorithm.SegmentTree
{
    public class SegmentTree
    {
        private Node Root = null;
        private int[] Arr; // 元の配列

        public SegmentTree(int[] arr)
        {
            Arr = arr;
            Root = Build(0, arr.Length);
        }

        // セグメント木の構築
        private Node Build(int start, int end)
        {
            Node node = new Node(start, end);

            if (start + 1 == end)
            {
                // 葉ノードの場合
                node.Value = Arr[start];
                return node;
            }

            int mid = (start + end) / 2;
            node.Left = Build(start, mid);
            node.Right = Build(mid, end);

            // 非葉ノードの値は子ノードの値の総和
            node.Value = node.Left.Value + node.Right.Value;

            return node;
        }

        // 区間 [l, r) の合計値を求める
        public long Query(int l, int r)
        {
            return Query(Root, l, r);
        }

        private long Query(Node node, int l, int r)
        {
            if (node.Start == l && node.End == r)
            {
                // 完全に一致した場合はそのノードの値を返す
                return node.Value;
            }

            // 一部しか区間に含まれない場合は子ノードを再帰的に探索
            int mid = (node.Start + node.End) / 2;
            long leftSum = 0, rightSum = 0;
            if (l < mid)
            {
                leftSum = Query(node.Left, l, Math.Min(mid, r));
            }
            if (r > mid)
            {
                rightSum = Query(node.Right, Math.Max(l, mid), r);
            }
            return leftSum + rightSum;
        }
    }
}
