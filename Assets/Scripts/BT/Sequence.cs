public class Sequence : Node
{
    public override bool Execute()
    {
        foreach (var child in children)
        {
            if (!child.Execute())
            {
                return false;
            }
        }
        return true;
    }
}
