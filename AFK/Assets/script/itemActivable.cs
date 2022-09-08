using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class itemActivable : MonoBehaviour
{
    public item thisItem;
    public UnityEvent resetEvent;

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
        gameManager.instance.playerManager.consumeItem(thisItem);
    }

    public virtual void resetItem()
    {
        resetEvent.Invoke();
    }

    public virtual void resetAfterDayPass()
    {
    }
}