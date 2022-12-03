using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Equipment : Item
{
    public Equipment()
    {
        amount = 1;
    }

    public override void onDoubleClick()
    {
        Debug.Log($"This is a {this.GetType().Name}, with name {name}");
    }
}

