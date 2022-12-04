using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName ="Inventory Database")]
public class ItemDatabase : ScriptableObject
{
    [SerializeField] private List<Item> _itemMasterList;

    public void SetItemIDs()
    {
        _itemMasterList = new List<Item>();
        
        //get all items from folder Resources/Ttems
        var itemsFromReseources = UnityEngine.Resources.LoadAll<Item>("Item Objects").OrderBy(i => i.id).ToList();

        var hasIDInRange = itemsFromReseources.Where(i => i.id != -1 && i.id < itemsFromReseources.Count).OrderBy(i => i.id).ToList();
        var hasIDNotInRange = itemsFromReseources.Where(i => i.id != -1 && i.id >= itemsFromReseources.Count).OrderBy(i => i.id).ToList();
        var noID = itemsFromReseources.Where(i => i.id == -1).ToList();

        var index = 0;
        for (int i = 0; i < itemsFromReseources.Count; i++)
        {
            Debug.Log($"Checking ID {i}");
            var itemToAdd = hasIDInRange.Find(d => d.id == i);

            if (itemToAdd != null)
            {
                Debug.Log($"Found item {itemToAdd} which has an id of {itemToAdd.id}");
                _itemMasterList.Add(itemToAdd);
            }
            else if (index < noID.Count)
            {
                noID[index].id = i;
                Debug.Log($"Setting item {noID[index]} which has an invalid id to the id of {i}");
                itemToAdd = noID[index];
                index++;
                _itemMasterList.Add(itemToAdd);
            }
#if UNITY_EDITOR
            if (itemToAdd) EditorUtility.SetDirty(itemToAdd);
#endif

        }

        foreach (var item in hasIDNotInRange)
        {
            _itemMasterList.Add(item);
#if UNITY_EDITOR
            if (item) EditorUtility.SetDirty(item);
#endif
        }

#if UNITY_EDITOR
        AssetDatabase.SaveAssets();
#endif
    }

    public Item getItemWithID(int id)
    {
        return _itemMasterList.Find(i => i.id == id);
    }
}
