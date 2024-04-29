using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtCorder.Algorithm.SegmentTree
{
    public class Node
    {
        public int Start, End; // 半開区間 [Start, End) を表す
        public long Value; // このノードが表す区間の合計値
        public Node Left, Right; // 子ノード

        public Node(int start, int end)
        {
            Start = start;
            End = end;
        }
    }
}
