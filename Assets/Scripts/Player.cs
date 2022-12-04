using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private UI_Inventory uiInventory;
    public Inventory inventory;

    private void Awake()
    {
        inventory = new Inventory();
        //uiInventory.SetInventory(inventory);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("ItemDrop"))
        {
            GameObject drop = collision.gameObject;
            inventory.AddItem(drop.GetComponent<ItemDrop>().itemdata);
            Debug.Log("Drop Collected!");

            Object.Destroy(drop);
        }
    }

}
