using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickingUp : MonoBehaviour
{
    private Inventory inventory;
    public GameObject Item;
    public bool canPickUp;
    public int things;
    public GameObject pickUpText;

    public bool pick;
    public GameObject itemToPickUp;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GetComponent<Inventory>();
        things = 0;

        pick = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if(canPickUp == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                inventory.PickedUpItem(Item.GetComponent<ThisItem>().thisItem);
                Destroy(Item);
                Item = null;
                pick = true;
                canPickUp = false; 

            }
        }

        if (canPickUp == true)
        {
            pickUpText.SetActive(true);
        }
        else
        {
            pickUpText.SetActive(false);
        }
    }

   void OnTriggerEnter(Collider col)
    {
        if (col.tag == "item")
        {
            itemToPickUp = col.gameObject;
            Item = col.gameObject;
            canPickUp = true; 
        }
    }

    void OnTriggerExit(Collider col)
    {
        if(col.tag == "item")
        {
            itemToPickUp = null; 
            Item = null;
            canPickUp = false; 
        }
    }
}
