namespace Puzzle8;

public abstract class SearchAlgorithm
{
    public abstract List<State> Solve(State initial, State goal);
}
