using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    public delegate void delEventArgs(object sender, EventArgs e);
    class King : Piece
    {
        public event delEventArgs ds;

        public King(Location l, Color c, bool alive) : base(l, c, alive)
        {

        }
        public override bool GetWay(Location l, out Location[] arrLocation, ref Situation situation)
        {
            arrLocation = new Location[1];
            if (l.RowN == this.Location.RowN && l.ColumnN == this.Location.ColumnN)
                return false;
            if ((Math.Abs(this.Location.ColumnN - l.ColumnN) + Math.Abs(this.Location.RowN - l.RowN) == 1))
            {
                arrLocation[0] = l;
                return true;
            }
            
            return false;
        }
        public override void Alive(bool a)
        {
            EventArgs e = new EventArgs();
            if (a == false)
                ds(this,e);
        }
     

    }
}
