using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public enum Color { White, Black }
    public enum Situation
    { regular, lastEmpty, lastOccupied, doesNotMatter }

     class  Function
    {
        public static void checkStraightRow(Location nowLoc, Location newLoc, ref Location[] arrLocation)
        {
            int j = 0;
            for (int i = nowLoc.Row ; i <= newLoc.Row; i++, j++)
            {
                arrLocation[j].Row = i;
                arrLocation[j].Column = nowLoc.Column;
            }
        }
        public static void checkStraightCol(Location nowLoc, Location newLoc, ref Location[] arrLocation)
        {
            int j = 0;
            for (int i = nowLoc.Column ; i <= newLoc.Column; i++, j++)
            {
                arrLocation[j].Column = (char)(i);
                arrLocation[j].Row = newLoc.Row;
            }
        }
        public static void checkDiagonal(Location nowLoc, Location newLoc, ref Location[] arrLocation)
        {
            int j, i, k = 0;
            if (nowLoc.Column < newLoc.Column)
                for (i = nowLoc.ColumnN , j = nowLoc.RowN ; i <= newLoc.ColumnN; i++, j++,k++)
                {
                    arrLocation[k].Column = (char)(i + 'a');
                    arrLocation[k].Row = j+1;
                }
            else
            {
                for (i = nowLoc.ColumnN , j = nowLoc.RowN; i >= newLoc.ColumnN; i--, j++,k++)
                {
                    arrLocation[k].Column = (char)(i + 'a');
                    arrLocation[k].Row = j+1;
                }
            }
        }
        
    }
}
