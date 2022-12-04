using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDebugger : MonoBehaviour
{
    public TMP_InputField Idinput;
    public ItemDatabase database;
    public TMP_Text errorLabel;

    public void AddItemToInventory()
    {
        var IDRequest = Idinput.text;

        if (IDRequest.Length > 0)
        {
            int id = int.Parse(IDRequest);
            Item item = database.getItemWithID(id);
            if (item != null)
            {
                errorLabel.text = $"Found {item.name}";
            }
            else
            {
                errorLabel.text = $"Error: No item found with ID {id}";
            }
        } else
        {
            Idinput.text = "0";
        }
    }
}
