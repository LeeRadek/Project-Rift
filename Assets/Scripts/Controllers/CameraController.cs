using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraController : MonoBehaviour
{
    public int speed = 1;

    

    void Start()
    {
        GameController.CamerMoveRight += MoveRight;
        GameController.CamerMoveLeft += MoveLeft;
        GameController.CamerMoveUp += MoveUp;
        GameController.CamerMoveDown += MoveDown;
        GameController.CenterCamera += CenterCamera;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void MoveRight()
    {
        Vector3 moveVector = new Vector3(1 * speed, 0, 0);

        transform.position += moveVector * Time.deltaTime;
        print("worls");
    }

    void MoveLeft()
    {
        Vector3 moveVector = new Vector3(-1 * speed, 0, 0);

        transform.position += moveVector * Time.deltaTime;
    }

    void MoveUp()
    {
        Vector3 moveVector = new Vector3(0, 0, 1 * speed);

        transform.position += moveVector * Time.deltaTime;
    }

    void MoveDown()
    {
        Vector3 moveVector = new Vector3(0, 0, -1 * speed);

        transform.position += moveVector * Time.deltaTime;
    }
    
    void CenterCamera()
    {
        Vector3 centerPos = new Vector3(GameManager.Instance.selectedPlayer.transform.position.x, transform.position.y, GameManager.Instance.selectedPlayer.transform.position.z);

        transform.position = centerPos;
    }

}
