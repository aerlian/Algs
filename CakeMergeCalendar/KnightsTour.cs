using System;
using System.Diagnostics;

namespace CakeMergeCalendar
{
    public class KnightsTour
    {
        public class Move
        {
            public int X { get; }
            public int Y { get; }

            public Move(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        public class Position
        {
            public int X { get; }
            public int Y { get; }

            public Position(int x, int y)
            {
                X = x;
                Y = y;
            }

            public Position ApplyMove(Move m)
            {
                return new Position(X + m.X, Y + m.Y);
            }

            public bool IsLegalMove(Move m)
            {
                var position = ApplyMove(m);

                return (position.X < BoardDimension && position.X >= 0 && position.Y < BoardDimension && position.Y >= 0) && _board[position.X, position.Y] == 0;
            }
        }

        private const int BoardDimension = 8;
        private static int _moveCount;
        private static Position _currentPosition;
        private static int[,] _board;
        private static Move[] _moves = new Move[] 
        {
            new Move(2, 1),
            new Move(1, 2),

            new Move(-1, 2),
            new Move(-2, 1),

            new Move(-2, -1),
            new Move(-1, -2),

            new Move(1, -2),
            new Move(2, -1),


        };
  
        public static bool MarkPosition(Position position)
        {
            _board[position.X, position.Y] = ++_moveCount;
            return _moveCount == BoardDimension * BoardDimension;
        }

        public static void ClearPosition(Position position)
        {
            _board[position.X, position.Y] = 0;

            --_moveCount;
        }

        public static void KnightsTourMain()
        {
            _moveCount = 0;
            InitializeBoard();

            _currentPosition = new Position(0, 0);
            KnightsTourImpl(_currentPosition);
            DumpBoard();
        }

        private static void InitializeBoard()
        {
            _board = new int[BoardDimension, BoardDimension];
        }

        private static bool KnightsTourImpl(Position position)
        {
            var isGameOver = MarkPosition(position);

            //DumpBoard();
            //System.Threading.Thread.Sleep(1000);

            if (isGameOver)
            {
                //DumpBoard();
                return true;
            }

            foreach(var move in _moves)
            {
                if (position.IsLegalMove(move))
                {
                    var nextPosition = position.ApplyMove(move);
                    
                    isGameOver = KnightsTourImpl(nextPosition);

                    if (isGameOver)
                    {
                        //DumpBoard();
                        return true;
                    }
                }
                else
                {
                    continue;
                }                
            }

            if (!isGameOver)
            {
                ClearPosition(position);
            }

            if (isGameOver)
            {
                DumpBoard();
            }
            
            return isGameOver;
        }

        private static void DumpBoard()
        {
            for (var i = 0; i < BoardDimension; i++) {
                for(var j = 0; j < BoardDimension; j++)
                {
                    Console.Write($"{_board[i, j]:00} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
