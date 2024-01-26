using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{

    public static UnityAction OnInventory;

    public static UnityAction CamerMoveRight;
    public static UnityAction CamerMoveLeft;
    public static UnityAction CamerMoveUp;
    public static UnityAction CamerMoveDown;
    public static UnityAction CenterCamera;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ShowInventory();
        MoveCameraHorizontal();
        MoveCameraVertical();
        CenterCamerToPlayer();
    }

    void ShowInventory()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            OnInventory.Invoke();
        }
    }

    void MoveCameraHorizontal()
    {
        if (Input.GetKey(KeyCode.D))
        {
            CamerMoveRight.Invoke();
        }
        if (Input.GetKey(KeyCode.A))
        {
            CamerMoveLeft.Invoke();
        }


    }

    void MoveCameraVertical()
    {
        if (Input.GetKey(KeyCode.W))
        {
            CamerMoveUp.Invoke();
        }
        if (Input.GetKey(KeyCode.S))
        {
            CamerMoveDown.Invoke();
        }
    }

    void CenterCamerToPlayer()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            CenterCamera.Invoke();
        }
    }
}
