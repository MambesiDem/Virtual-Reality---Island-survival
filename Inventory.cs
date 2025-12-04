//using System.Collections.Generic;
//using UnityEngine;

//public class Inventory : MonoBehaviour
//{
//    public static Inventory Instance { get; private set; }

//    // Make items accessible to UIManager and other scripts
//    public Dictionary<string, int> items { get; private set; } = new Dictionary<string, int>();

//    private void Awake()
//    {
//        if (Instance == null)
//            Instance = this;
//        else
//            Destroy(gameObject);
//    }

//    // Updated to allow specifying an amount
//    public void AddItem(string item, int amount = 1)
//    {
//        if (items.ContainsKey(item))
//            items[item] += amount;
//        else
//            items[item] = amount;

//        Debug.Log($"Added {item}. Now have {items[item]}.");
//        UIManager.Instance.UpdateInventory(items);
//    }

//    public bool UseItem(string item, int amount = 1)
//    {
//        if (items.ContainsKey(item) && items[item] >= amount)
//        {
//            items[item] -= amount;
//            Debug.Log($"Used {item}. Remaining {items[item]}.");
//            UIManager.Instance.UpdateInventory(items);
//            return true;
//        }
//        return false;
//    }

//    public Dictionary<string, int> GetItems()
//    {
//        return items;
//    }
//}
//using System.Collections.Generic;
//using UnityEngine;

//public class Inventory : MonoBehaviour
//{
//    public static Inventory Instance { get; private set; }
//    public Dictionary<string, int> items { get; private set; } = new Dictionary<string, int>();

//    private void Awake()
//    {
//        if (Instance == null) Instance = this;
//        else Destroy(gameObject);
//    }

//    public void AddItem(string item, int amount = 1)
//    {
//        if (items.ContainsKey(item)) items[item] += amount;
//        else items[item] = amount;

//        Debug.Log($"Added {item}. Now have {items[item]}.");
//        UIManager.Instance?.UpdateInventory(items);
//    }

//    public bool UseItem(string item, int amount = 1)
//    {
//        if (items.ContainsKey(item) && items[item] >= amount)
//        {
//            items[item] -= amount;
//            UIManager.Instance?.UpdateInventory(items);
//            return true;
//        }
//        return false;
//    }
//}
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; }

    public Dictionary<string, int> items { get; private set; } = new Dictionary<string, int>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddItem(string item, int amount = 1)
    {
        if (items.ContainsKey(item))
            items[item] += amount;
        else
            items[item] = amount;

        Debug.Log($"Added {item}. Now have {items[item]}.");
        UIManager.Instance.UpdateInventory(items);
    }

    public bool UseItem(string item, int amount = 1)
    {
        if (items.ContainsKey(item) && items[item] >= amount)
        {
            items[item] -= amount;
            Debug.Log($"Used {item}. Remaining {items[item]}.");
            if(item == "Log")
            {
                UIManager.Instance.UpdateInventory(items);
            }
            return true;
        }
        return false;
    }

    public Dictionary<string, int> GetItems()
    {
        return items;
    }
}
