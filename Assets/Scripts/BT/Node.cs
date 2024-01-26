using System.Collections.Generic;

public abstract class Node
{
    protected readonly List<Node> children = new List<Node>();

    public void AddChild(Node child)
    {
        children.Add(child);
    }

    public abstract bool Execute();
}
