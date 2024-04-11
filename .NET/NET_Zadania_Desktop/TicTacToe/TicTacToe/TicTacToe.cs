using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    internal class TicTacToe
    {
        protected List<int[]> Board;
        protected bool Turn;

        public TicTacToe()
        {
            this.Board = new List<int[]>(); 
            for (int i = 0; i < 3; i++)
                this.Board.Add(new int[] { 0, 0, 0 });
        }
        public void GetValueOnPos(int a, int b) 
        {
            Console.WriteLine(this.Board[a][b]);
        }

        public void DisplayBoard()
        {
            Console.WriteLine("");
            String Line = "";
            Console.WriteLine("=================");
            foreach (var X in this.Board)
            {
                foreach (var Y in X)
                {
                    Line += $"| {Y} | ";
                }
                Console.WriteLine(Line);
                Console.WriteLine("=================");
                Line = "";
            }
        }

        public String GetChar()
        {
            return (this.Turn) ? "X" : "O";
        }
    
        private void NextTurn()
        {
            _ = (this.Turn) ? this.Turn = false : this.Turn = true;
        }

        public void MakeMove(int Y, int X)
        {
            this.Board[Y][X] = (this.Turn) ? -1 : 1;
            NextTurn();
        }

        private bool CheckHorizontaly()
        {
            int Counter = 0;
            foreach (var X in this.Board)
            {
                foreach(var Y in X)
                    Counter += Y;
                if (Counter == this.Board.Count || Counter == -this.Board.Count) return true;
                Counter = 0;
            }
            return false;
        }

        private bool CheckVerticaly()
        {
            int Counter = 0;
            for (int i = 0; i < this.Board.Count; i++) { 
                foreach( var X in this.Board)
                    Counter += X[i];
                if (Counter == this.Board.Count || Counter == -this.Board.Count) return true;
                Counter = 0;
            }
            return false;
        }

        private bool CheckDiagonaly() 
        {
            int Counter = 0; // \
            for(int i = 0; i < this.Board.Count; i++)
                Counter += this.Board[i][i];
            if (Counter == this.Board.Count || Counter == -this.Board.Count) return true;

            Counter = 0;

            for (int i = this.Board.Count-1; i >= 0; i--)// /
                Counter += this.Board[i][i];
            if (Counter == this.Board.Count || Counter == -this.Board.Count) return true;

            return false;
        }
    
        public bool CheckFullBoard()
        {
            foreach (var row in this.Board)
                foreach(var field in row)
                    if(field == 0) 
                        return false;
            return true;
        }

        public bool IsOver()
        {
            return (CheckDiagonaly() || CheckVerticaly() || CheckHorizontaly() || CheckFullBoard());
        }

        public bool GetTurn()
        {
            return this.Turn;
        }
    }
}
  