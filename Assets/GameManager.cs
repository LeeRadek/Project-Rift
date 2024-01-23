using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public AIController selectedPlayer;
    private Vector3 dir;

    public LineRenderer lineRen;
    public GameObject inventoryPanel;
    public ScriptableObject inventory;


    void Start()
    {
        GameController.OnInventory += ShowInventory;
        lineRen = selectedPlayer.GetComponent<LineRenderer>();
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("There will be one instace of this object in the scene");
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        GetDirection();
        DrawTrack();
        SpawnTrace();
        
    }

    void GetDirection()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector2 mousePos = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mousePos);
            RaycastHit hit;



            if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity))
            {
                dir = hit.point;
                MoveToPoint();
            }
        }
    }

    void MoveToPoint()
    {
        selectedPlayer.Move(dir);
    }

    void DrawTrack()
    {
        NavMeshAgent agent = selectedPlayer.GetComponent<NavMeshAgent>();
        List<Vector3> pathPoints = new List<Vector3>(agent.path.corners);
        List<Vector3> currentPath = new List<Vector3>(agent.path.corners);



        if (currentPath.Count > 1 && !AreReachedPoints(pathPoints, currentPath))
        {
            pathPoints.RemoveAt(0);
        }

        pathPoints.AddRange(currentPath);

        lineRen.positionCount = pathPoints.Count;
        for (int i = 0; i < pathPoints.Count; i++)
        {
            lineRen.SetPosition(i, pathPoints[i]);
        }
    }

    bool AreReachedPoints(List<Vector3> list1, List<Vector3> list2)
    {
        if (list1.Count != list2.Count)
        {
            return false;
        }
        for (int i = 0; i > list1.Count; i++)
        {
            if (list1[i] != list2[i])
            {
                return false;
            }
        }
        return true;
    }

    void SpawnTrace()
    {
        Vector2 mousePos = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePos);

        RaycastHit hit;
        
        if(Physics.Raycast(ray, out hit, Mathf.Infinity, 10))
        {
            Canvas canv = hit.collider.gameObject.transform.GetChild(0).GetComponent<Canvas>();
            bool isVisable = false;

            
            if (canv != null)
            {
                canv.gameObject.SetActive(!canv.gameObject.activeSelf);
            }
        }
    }

    void ShowInventory()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);

    }
}
