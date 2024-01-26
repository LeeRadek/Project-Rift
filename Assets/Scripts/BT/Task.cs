public interface ITaskLogic
{
    bool Execute();
}

public class Task : Node
{
    private readonly ITaskLogic taskLogic;

    public Task(ITaskLogic logic)
    {
        taskLogic = logic;
    }

    public override bool Execute()
    {
        return taskLogic.Execute();
    }

}

