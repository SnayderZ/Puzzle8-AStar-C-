namespace Puzzle8;

public class Node
{
    public State State { get; }
    public Node Parent { get; }
    public int G { get; }
    public int H { get; }
    public int F => G + H;

    public Node(State state, Node parent, int g, int h)
    {
        State = state;
        Parent = parent;
        G = g;
        H = h;
    }
}
