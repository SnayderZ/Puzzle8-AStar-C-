namespace Puzzle8;

public class AStarSearch : SearchAlgorithm
{
    public override List<State> Solve(State initial, State goal)
    {
        var open = new List<Node> { new Node(initial, null, 0, initial.Heuristic(goal)) };
        var closed = new HashSet<State>();

        while (open.Count > 0)
        {
            var current = open.OrderBy(n => n.F).First();

            if (current.State.IsGoal(goal))
                return BuildPath(current);

            open.Remove(current);
            closed.Add(current.State);

            foreach (var successor in current.State.GetSuccessors())
            {
                if (closed.Contains(successor))
                    continue;

                int g = current.G + 1;
                int h = successor.Heuristic(goal);
                var node = new Node(successor, current, g, h);

                var existing = open.FirstOrDefault(n => n.State.Equals(successor));
                if (existing == null || node.F < existing.F)
                {
                    open.Remove(existing);
                    open.Add(node);
                }
            }
        }

        return null;
    }

    private List<State> BuildPath(Node node)
    {
        var path = new List<State>();
        while (node != null)
        {
            path.Insert(0, node.State);
            node = node.Parent;
        }
        return path;
    }
}
