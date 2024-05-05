using System;
using System.Collections.Generic;
using System.Formats.Tar;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDotNetCore.Basis
{
    public class ThreadTips
    {
        public void Run()
        {
            // murableなコード
            List<MutablePos> mPosList = GetMutableList();

            MoveMutablePositionList(10, mPosList);

            // immutableなコード
            List<ImmutablePos> iPosList = GetImmutableList();

            MoveImmutablePositionList(10, iPosList);
        }

        private List<MutablePos> GetMutableList()
        {
            return new List<MutablePos>()
            {
                new MutablePos(2, 5, 100),
                new MutablePos(4, 15, 200),
                new MutablePos(6, 25, 300)
            };
        }

        private List<ImmutablePos> GetImmutableList()
        {
            return new List<ImmutablePos>()
            {
                new ImmutablePos(2, 5, 100),
                new ImmutablePos(4, 15, 200),
                new ImmutablePos(6, 25, 300)
            };
        }

        private void MoveMutablePositionList(int delta, List<MutablePos> list)
        {
            foreach (var pos in list)
            {
                pos.X += delta;
                pos.Y += delta;
                pos.Z += delta;
            }
        }

        private void MoveImmutablePositionList(int delta, List<ImmutablePos> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i] = list[i].Update(delta);
            }
        }

        class MutablePos
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Z { get; set; }

            public MutablePos(int x, int y, int z)
            {
                X = x;
                Y = y;
                Z = z;
            }
        }

        class ImmutablePos
        {
            public int X { get; }
            public int Y { get; }
            public int Z { get; }

            public ImmutablePos(int x, int y, int z)
            {
                X = x;
                Y = y;
                Z = z;
            }

            public ImmutablePos Update(int delta)
            {
                return new ImmutablePos(X + delta, Y + delta, Z + delta);
            }
        }
    }
}
