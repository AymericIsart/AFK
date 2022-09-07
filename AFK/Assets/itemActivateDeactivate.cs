using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemActivateDeactivate : itemActivable
{
    [SerializeField]
    private item itemDeactivate;

    private bool isActivate = false;

    private void OnValidate()
    {
        if (itemDeactivate.amountsDirect.Length != 3)
        {
            Debug.LogWarning("Don't change the field's array size!");
            Array.Resize(ref itemDeactivate.amountsDirect, 3);
        }
        if (itemDeactivate.amountsTime.Length != 3)
        {
            Debug.LogWarning("Don't change the field's array size!");
            Array.Resize(ref itemDeactivate.amountsTime, 3);
        }
    }

    public override void activate()
    {
        if (isActivate)
        {
            Debug.Log("parent activate " + itemDeactivate.name);
            gameManager.instance.playerManager.consumeItem(itemDeactivate);
        }
        else
        {
            base.activate();
        }
        isActivate = !isActivate;
    }

    public override void resetItem()
    {
        base.resetItem();
        isActivate = false;
    }
}