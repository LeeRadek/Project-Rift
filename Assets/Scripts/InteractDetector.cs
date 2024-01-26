using UnityEngine;

public class InteractDetector : MonoBehaviour
{
    private LayerMask interactMask = 10;

    public delegate void AddItemToInventory(ItemCreator item, int itemAmount);
    public static event AddItemToInventory AddItem;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == interactMask.value)
        {
            //Debug.Log("Interact with " +  other.gameObject.name);
            if (other.gameObject.GetComponent<ItemPickUp>().item != null)
            {

                int amount;
                ItemCreator Item = ScriptableObject.CreateInstance<ItemCreator>();
                Item = other.gameObject.GetComponent<ItemPickUp>().item;
                amount = other.gameObject.GetComponent<ItemPickUp>().amout;

                AddItem(Item, amount);

            }
        }
    }


}
