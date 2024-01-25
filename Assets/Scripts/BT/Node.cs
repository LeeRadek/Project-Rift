using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Node
{
    protected readonly List<Node> children = new List<Node>();

    public void AddChild(Node child)
    {
        children.Add(child);
    }

    public abstract bool Execute();
}
