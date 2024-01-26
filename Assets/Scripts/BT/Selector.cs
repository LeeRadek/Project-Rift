public class Selector : Node
{
    public override bool Execute()
    {
        foreach (var child in children)
        {
            if (child.Execute())
            {
                return true;
            }
        }
        return false;
    }


}
