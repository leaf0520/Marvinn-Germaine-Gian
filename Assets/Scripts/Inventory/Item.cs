using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Item : ScriptableObject
{
    public Sprite sprite;
    public int id;
    public new string name;
    [TextArea(3,5)]
    public string description;
    [SerializeField] public int amount;

    public int Amount { protected set => amount = value; get => amount; }


    //override to make item do stuff when clicked
    abstract public void onDoubleClick();
}
 