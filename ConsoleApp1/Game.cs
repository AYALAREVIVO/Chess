using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    
    class Game
    {
      
        public Game()
        {
             
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    GameMat[i, j] = null;
                }

            }
            for (int i = 0; i < gameMat.GetLength(0); i++)
            {
                gameMat[1, i] = new Pawn(new Location(7, (char)('a' + i)), Color.Black, true);
                gameMat[6, i] = new Pawn(new Location(2, (char)('a' + i)), Color.White, true);
            }

            gameMat[0, 0] = new Rook(new Location(8, 'a'), Color.Black, true);
            gameMat[0, 7] = new Rook(new Location(8, 'h'), Color.Black, true);
            gameMat[7, 7] = new Rook(new Location(1, 'h'), Color.White, true);
            gameMat[7, 0] = new Rook(new Location(1, 'a'), Color.White, true);

            gameMat[0, 1] = new Horse(new Location(8, 'b'), Color.Black, true);
            gameMat[0, 6] = new Horse(new Location(8, 'g'), Color.Black, true);
            gameMat[7, 1] = new Horse(new Location(1, 'b'), Color.White, true);
            gameMat[7, 6] = new Horse(new Location(1, 'g'), Color.White, true);

            gameMat[0, 2] = new Bishop(new Location(8, 'c'), Color.Black, true);
            gameMat[0, 5] = new Bishop(new Location(8, 'f'), Color.Black, true);
            gameMat[7, 2] = new Bishop(new Location(1, 'c'), Color.White, true);
            gameMat[7, 5] = new Bishop(new Location(1, 'f'), Color.White, true);

            gameMat[0, 3] = new Queen(new Location(8, 'd'), Color.Black, true);
            gameMat[7, 3] = new Queen(new Location(1, 'd'), Color.White, true);

            gameMat[0, 4] = new King(new Location(8, 'd'), Color.Black, true);
            gameMat[7, 4] = new King(new Location(1, 'd'), Color.White, true);
           

            King p1 = GameMat[0, 4] as King ;
           p1.ds += new delEventArgs(EndGame);
            King p2 = GameMat[7, 4] as King;
            p2.ds += new delEventArgs(EndGame);
        }
        private Piece[,] gameMat = new Piece[8, 8];
        private Color turn = Color.White;

        public Piece[,] GameMat
        {
            get { return gameMat; }
            //set { turn = value; }
        }
        public Color Turn
        {
            get { return turn == Color.White ? Color.Black : Color.White; }
            //set { turn = value; }
        }
        private bool endOfGame = false;

        public void EndGame(object sender,EventArgs e)
        {
            this.endOfGame = true;
        }
        //  private Location newLocation;
        private Location nowLocation;

        public void select(string nowLoc)
        {
            Location l = new Location(nowLoc[0] - 48, nowLoc[1]);

            //  newLocation = new Location(newLoc[0] - 48, newLoc[1]);  
             if(gameMat[l.RowN, l.ColumnN]==null)
            {
                Console.WriteLine("error location!!!");
            }
            else if (gameMat[l.RowN, l.ColumnN].Color == turn)
            {
                nowLocation = new Location(nowLoc[0] - 48, nowLoc[1]);
                turn = Turn;
            }
        }

        public bool Move(Location newLoc)
        {
            Location[] arrLocation;
            Situation s = Situation.doesNotMatter;
            bool isLegal = gameMat[nowLocation.RowN, nowLocation.ColumnN].GetWay(newLoc, out arrLocation, ref s);
            if (!isLegal)
                Console.WriteLine("error moving");
            else
            {
                if (s == Situation.doesNotMatter)
                {
                    if (gameMat[arrLocation[0].RowN, arrLocation[0].ColumnN] != null)
                    {
                        if (gameMat[arrLocation[0].RowN, arrLocation[0].ColumnN].Color !=
                       gameMat[nowLocation.RowN, nowLocation.ColumnN].Color)
                        {
                            gameMat[arrLocation[0].RowN, arrLocation[0].ColumnN].Alive(false);
                        }
                        else if (gameMat[arrLocation[0].RowN, arrLocation[0].ColumnN].Color ==
                           gameMat[nowLocation.RowN, nowLocation.ColumnN].Color)
                            return false;
                    }
                    if (gameMat[arrLocation[0].RowN, arrLocation[0].ColumnN] != null)
                        gameMat[arrLocation[0].RowN, arrLocation[0].ColumnN].Alive(false);
                    gameMat[arrLocation[0].RowN, arrLocation[0].ColumnN] = gameMat[nowLocation.RowN, nowLocation.ColumnN];
                    gameMat[arrLocation[0].RowN, arrLocation[0].ColumnN].Location = newLoc;
                    gameMat[nowLocation.RowN, nowLocation.ColumnN] = null;
                    return true;
                }
                if (s == Situation.lastEmpty)
                {
                    int i;
                    if (turn == Color.White)
                    {
                        i = arrLocation.Length - 1;
                    }
                    else
                    {
                        i = 0 ;
                    }
                    if (gameMat[arrLocation[i].RowN, arrLocation[i].ColumnN] == null)
                    {
                        gameMat[arrLocation[i].RowN, arrLocation[i].ColumnN] = gameMat[nowLocation.RowN, nowLocation.ColumnN];
                        gameMat[arrLocation[i].RowN, arrLocation[i].ColumnN].Location = newLoc;
                        gameMat[nowLocation.RowN, nowLocation.ColumnN] = null;
                        return true;
                    }
                }
                if (s == Situation.lastOccupied)
                {
                    int i;
                    if (turn == Color.White)
                    {
                        i = 1;
                    }
                    else
                    {
                        i = 0;
                    }
                    if (gameMat[arrLocation[i].RowN, arrLocation[i].ColumnN] != null &&
                        gameMat[arrLocation[i].RowN, arrLocation[i].ColumnN].Color == turn)
                    {
                        gameMat[arrLocation[i].RowN, arrLocation[i].ColumnN].Alive(false);
                        gameMat[arrLocation[i].RowN, arrLocation[i].ColumnN] = gameMat[nowLocation.RowN, nowLocation.ColumnN];
                        gameMat[arrLocation[i].RowN, arrLocation[i].ColumnN].Location = newLoc;

                        gameMat[nowLocation.RowN, nowLocation.ColumnN] = null;
                        return true;
                    }
                }
                if (s == Situation.regular)
                {
                    int i;
                    for (i = 1; i < arrLocation.Length - 1; i++)
                    {
                        if (gameMat[arrLocation[i].RowN, arrLocation[i].ColumnN] != null)
                            return false;
                    }
                    if (turn == Color.White)
                    {
                        i = 0;
                    }
                    if (turn == Color.White)
                    {
                        i =arrLocation.Length - 1;

                    }
                    if (gameMat[arrLocation[i].RowN, arrLocation[i].ColumnN] == null ||
                       gameMat[arrLocation[i].RowN, arrLocation[i].ColumnN].Color == turn)
                    {
                        gameMat[arrLocation[i].RowN, arrLocation[i].ColumnN].Alive(false);
                        gameMat[arrLocation[i].RowN, arrLocation[i].ColumnN] = gameMat[nowLocation.RowN, nowLocation.ColumnN];
                        gameMat[arrLocation[i].RowN, arrLocation[i].ColumnN].Location = newLoc;

                        gameMat[nowLocation.RowN, nowLocation.ColumnN] = null;
                    }
                }
            }
            return false;
        }
    }
}

