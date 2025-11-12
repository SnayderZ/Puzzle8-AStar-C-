namespace Puzzle8
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== 8-Puzzle Search (A*) ===");
            Console.WriteLine("1. Resolver automáticamente");
            Console.WriteLine("2. Jugar manualmente");
            Console.Write("Elige una opción: ");
            string opcion = Console.ReadLine();

            Puzzle8 puzzle = new Puzzle8();

            if (opcion == "1")
            {
                AStarSearch search = new AStarSearch();
                State initial = puzzle.InitialState;
                State goal = puzzle.GoalState;

                Console.WriteLine("\nBuscando solución con A* (heurística Manhattan)...\n");

                List<State> solution = search.Solve(initial, goal);

                if (solution != null)
                {
                    Console.WriteLine($"Solución encontrada en {solution.Count - 1} movimientos:\n");
                    foreach (var state in solution)
                    {
                        state.Print();
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("No se encontró solución.");
                }
            }
            else
            {
                puzzle.PlayManual();
            }

            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
