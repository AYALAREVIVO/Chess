using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Bishop: Piece
    {
        public Bishop(Location l, Color c, bool alive):base(l, c, alive)
        {

        }
        public override bool GetWay(Location l, out Location[] arrLocation, ref Situation situation)
        {
            arrLocation = new Location[arrLength(this.Location, l)];

            if (l.RowN == this.Location.RowN && l.ColumnN == this.Location.ColumnN)
                return false;
            situation = Situation.regular;          
             if (Math.Abs(this.Location.ColumnN - l.ColumnN) == Math.Abs(this.Location.RowN - l.RowN))
            {
                if (this.Location.RowN < l.RowN)
                    Function.checkDiagonal(this.Location, l, ref arrLocation);
                else
                    Function.checkDiagonal(l, this.Location, ref arrLocation);
                return true;
            }
            return false;
        }
  

    }
}
