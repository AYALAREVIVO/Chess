using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Horse: Piece
    {
                public Horse(Location l, Color c, bool alive) : base(l, c, alive)
        {

        }
        public override bool GetWay(Location l, out Location[] arrLocation, ref Situation situation)
        {
            arrLocation = new Location[1];
            if (l.RowN == this.Location.RowN && l.ColumnN == this.Location.ColumnN)
                return false;
            situation = Situation.doesNotMatter;
            situation = Situation.doesNotMatter;
            if ((Math.Abs(this.Location.ColumnN - l.ColumnN) == 2 && Math.Abs(this.Location.RowN - l.RowN) == 1)
               || (Math.Abs(this.Location.ColumnN - l.ColumnN) == 1 && Math.Abs(this.Location.RowN - l.RowN) == 2))
            {
                arrLocation[0] = l;
                return true;
            }
            return false;
        }
    }
}
