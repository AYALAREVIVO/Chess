using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
   
    struct Location
    {
        public Location(int row, char column)
        {
            if (row <= 8 && row >= 1)
                this.row =  row;
            else
            {
                Console.WriteLine("error");
                this.row = 8-row;
            }
            this.columnN = column - 'a';
            this.rowN =8- row;
           
            if (column <= 'h' && column >= 'a')
                this.column = column;
            else
            {
                Console.WriteLine("error");
                this.column = column;
            }
            //Row = row;
            //Column = column;
        }
        private int row;
        public int Row
        {
            get { return row; }
            set
            {
                if (value <= 8 && value >= 1)
                    row = value;
                else { Console.WriteLine("error");
                    this.row = value; }               
            }
        }
        private char column;

        public char Column
        {
            get { return column; }
            set
            {
                if (value <= 'h' && value >= 'a')
                    column = value;
                else { Console.WriteLine("error");
                    this.column = value; }              
            }
        }
        private int rowN;
        public int RowN
        {
            get { return rowN; }
            set { rowN = value; }
        }
        private int columnN;
        public int ColumnN
        {
            get { return columnN; }
            set { columnN = value; }
        }
        public string ToString()
        {
            return row.ToString()+column.ToString();
        }
    }
}
