using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemManager : MonoBehaviour
{
    public items[] itemList;

    private void OnValidate()
    {
        foreach (items s in itemList)
        {
            if (s.amounts.Length != 3)
            {
                Debug.LogWarning("Don't change the field's array size!");
                Array.Resize(ref s.amounts, 3);
            }
        }
    }

    public void consumeItem(string name)
    {
        items s = findItem(name);
        if (s != null)
        {
            gameManager.instance.playerManager.consumeItem(s);
        }
        else
        {
            Debug.LogError("item with name " + name + " does not exist");
        }
    }

    public items findItem(string name)
    {
        return Array.Find(itemList, item => item.name == name);
    }
}