namespace Puzzle8;

public class Puzzle8
{
    public State InitialState { get; private set; }
    public State GoalState { get; private set; }

    public Puzzle8()
    {
        InitialState = new State(new int[3, 3]
        {
                {2,8,3},
                {1,6,4},
                {7,0,5}
        });

        GoalState = new State(new int[3, 3]
        {
                {1,2,3},
                {8,0,4},
                {7,6,5}
        });
    }

    public void PlayManual()
    {
        var current = new State((int[,])InitialState.Board.Clone());
        Console.WriteLine("\n=== Modo Manual ===");
        Console.WriteLine("Usa W (arriba), S (abajo), A (izquierda), D (derecha) y X (Salir)");

        while (!current.IsGoal(GoalState))
        {
            current.Print();
            Console.Write("\nMovimiento: ");
            var key = Console.ReadKey().Key;
            Console.WriteLine();

            if (key == ConsoleKey.X)
            {
                Console.WriteLine("\nHas salido del juego.");
                break; 
            }

            current = Move(current, key);
            Console.Clear();
        }

        if (current.IsGoal(GoalState))
            Console.WriteLine("🎉 ¡Felicidades, alcanzaste el estado objetivo!");
    }


    private State Move(State current, ConsoleKey key)
    {
        (int x, int y) = current.FindZero();
        int[,] b = (int[,])current.Board.Clone();

        switch (key)
        {
            case ConsoleKey.W when x > 0:
                b[x, y] = b[x - 1, y];
                b[x - 1, y] = 0;
                break;
            case ConsoleKey.S when x < 2:
                b[x, y] = b[x + 1, y];
                b[x + 1, y] = 0;
                break;
            case ConsoleKey.A when y > 0:
                b[x, y] = b[x, y - 1];
                b[x, y - 1] = 0;
                break;
            case ConsoleKey.D when y < 2:
                b[x, y] = b[x, y + 1];
                b[x, y + 1] = 0;
                break;
        }
        return new State(b);
    }
}
