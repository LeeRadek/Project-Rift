using UnityEngine;

public class RotateToCamera : MonoBehaviour
{
    RectTransform rect;
    void Start()
    {
        rect = GetComponent<RectTransform>();
    }


    void Update()
    {
        rect.localRotation = Camera.main.transform.rotation;
    }
}
