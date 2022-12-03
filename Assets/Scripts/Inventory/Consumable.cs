using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Consumable : Item
{
    public Consumable()
    {

    }

    public override void onDoubleClick()
    {
        Debug.Log($"This is a {this.GetType().Name}, with name {name} and amount {amount}");
        --amount;
    }
}
