using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public ItemDatabase database;

    // Start is called before the first frame update
    void Start()
    {
        database.SetItemIDs();
    }
}
