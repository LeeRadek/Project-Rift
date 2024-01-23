using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    public ObjectReferencer objectReference;


    private NavMeshAgent agent;
    private NavMeshPath path;



    void Start()
    {
        agent = GetComponent<NavMeshAgent>();


    }

    public void Move(Vector3 pos)
    {
        agent.SetDestination(pos);
    }

    public void DrawPath()
    {

    }
}
