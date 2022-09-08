using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemActivateDeactivate : itemActivable
{
    [SerializeField]
    private item itemActivate;

    [SerializeField]
    private item itemDeactivate;

    private bool isActivate = false;

    [SerializeField]
    private int deactivateAfterCooldown;

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

    private void Start()
    {
        thisItem = itemActivate;
    }

    public override void activate()
    {
        base.activate();
        isActivate = !isActivate;
        if (isActivate)
        {
            thisItem = itemDeactivate;
            if (deactivateAfterCooldown > 0)
            {
                StartCoroutine(cooldown());
            }
        }
        else
        {
            StopAllCoroutines();
            thisItem = itemActivate;
        }
    }

    public override void resetItem()
    {
        base.resetItem();
        isActivate = false;
        itemDeactivate.events.Invoke();
    }

    private IEnumerator cooldown()
    {
        yield return new WaitForSeconds(deactivateAfterCooldown);
        activate();
    }
}