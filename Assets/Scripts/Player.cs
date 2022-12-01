using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    private const float SPEED = 50f;
    [SerializeField] private UI_Inventory uiInventory;
    private Inventory inventory;

    private void Awake()
    {
        Instance = this;

        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
    }
}
