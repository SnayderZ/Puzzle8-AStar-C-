namespace Puzzle8
{
    public class State
    {
        public int[,] Board { get; private set; }
        public const int Size = 3;

        public State(int[,] board)
        {
            Board = (int[,])board.Clone();
        }

        public IEnumerable<State> GetSuccessors()
        {
            (int x, int y) = FindZero();

            int[][] moves = new int[][]
            {
                new int[]{-1,0}, new int[]{1,0}, new int[]{0,-1}, new int[]{0,1}
            };

            foreach (var m in moves)
            {
                int newX = x + m[0], newY = y + m[1];
                if (IsValid(newX, newY))
                {
                    int[,] newBoard = (int[,])Board.Clone();
                    newBoard[x, y] = newBoard[newX, newY];
                    newBoard[newX, newY] = 0;
                    yield return new State(newBoard);
                }
            }
        }

        public int Heuristic(State goal)
        {
            int dist = 0;
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                {
                    int val = Board[i, j];
                    if (val != 0)
                    {
                        (int gx, int gy) = goal.FindValue(val);
                        dist += Math.Abs(i - gx) + Math.Abs(j - gy);
                    }
                }
            return dist;
        }

        public bool IsGoal(State goal)
        {
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    if (Board[i, j] != goal.Board[i, j])
                        return false;
            return true;
        }

        public (int, int) FindZero()
        {
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    if (Board[i, j] == 0) return (i, j);
            return (-1, -1);
        }

        public (int, int) FindValue(int value)
        {
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    if (Board[i, j] == value) return (i, j);
            return (-1, -1);
        }

        private bool IsValid(int x, int y) => x >= 0 && y >= 0 && x < Size && y < Size;

        public void Print()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                    Console.Write(Board[i, j] == 0 ? "  " : $"{Board[i, j]} ");
                Console.WriteLine();
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is not State other) return false;
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    if (Board[i, j] != other.Board[i, j])
                        return false;
            return true;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            foreach (var v in Board) hash = hash * 31 + v;
            return hash;
        }
    }
}
