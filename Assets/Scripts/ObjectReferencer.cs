using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Object Referencer", menuName = "ScriptableObjects/Reference", order = 0)]
public class ObjectReferencer : ScriptableObject
{
    public GameObject reference;
}
