using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reversi
{
    public class Engine
    {
        public int BoardWidth { get; private set; }
        public int BoardHeight { get; private set; }

        private int[,] board;
        public int NextPlayerNumber { get; private set; } = 1;

        private static int OponentNumber( int playerNumber)
        {
            return (playerNumber == 1) ? 2 : 1;
        }
        private bool areCoordinatesCorrect(int width, int height)
        {
            return width >= 0 && width < BoardWidth &&
                height >= 0 && height < BoardHeight;
        }
        public int GetFieldState(int width, int height)
        {
            if(!areCoordinatesCorrect(width, height))
            {
                throw new Exception("Nieprawidłowe współrzędne pola!");
            }
            return board[width, height];
        }

        private void ClearBoard()
        {
            for(int i =0; i<BoardWidth; i++)
            {
                for(int j = 0; j < BoardHeight; j++)
                {
                    board[i, j] = 0;
                }
            }
            int middleWidth = BoardWidth / 2;
            int middleHeight = BoardHeight / 2;
            board[middleHeight - 1, middleWidth - 1] = board[middleWidth, middleHeight] = 1;
            board[middleWidth - 1, middleHeight] = board[middleWidth, middleHeight - 1] = 2;
        }
        public Engine( int initialPlayer, int boardWidth = 8, int boardHeight = 8)
        {
            if(initialPlayer < 1 || initialPlayer > 2)
            {
                throw new Exception("Nieprawidłowy numer gracza rozpoczynającego grę!");
            }
            BoardWidth = boardWidth;
            BoardHeight = boardHeight;
            board = new int[BoardWidth, BoardHeight];
            ClearBoard();
            NextPlayerNumber = initialPlayer;
        }
    }
}
