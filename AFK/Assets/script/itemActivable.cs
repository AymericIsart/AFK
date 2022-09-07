using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemActivable : MonoBehaviour
{
    [SerializeField]
    private item thisItem;

    private void OnValidate()
    {
        if (thisItem.amountsDirect.Length != 3)
        {
            Debug.LogWarning("Don't change the field's array size!");
            Array.Resize(ref thisItem.amountsDirect, 3);
        }
        if (thisItem.amountsTime.Length != 3)
        {
            Debug.LogWarning("Don't change the field's array size!");
            Array.Resize(ref thisItem.amountsTime, 3);
        }
    }

    public virtual void activate()
    {
        Debug.Log("parent activate " + thisItem.name);
        gameManager.instance.playerManager.consumeItem(thisItem);
    }

    public virtual void resetItem()
    {
        Debug.Log("parent reset " + thisItem.name);
    }

    public virtual void resetAfterDayPass()
    {
    }
}