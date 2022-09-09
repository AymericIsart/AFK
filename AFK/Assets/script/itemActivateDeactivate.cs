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

    int countdownReclick = 1;
    bool canActivate = true;
    Coroutine closeCountdown;

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
        Debug.Log(canActivate);
        if (canActivate)
        {
            Debug.Log("here");
            StartCoroutine(countdownBtClick());
            base.activate();
            isActivate = !isActivate;
            if (isActivate)
            {
                thisItem = itemDeactivate;
                if (deactivateAfterCooldown > 0)
                {
                    closeCountdown = StartCoroutine(cooldown());
                }
            }
            else
            {
                if(closeCountdown != null)
                {
                    StopCoroutine(closeCountdown);
                }
                thisItem = itemActivate;
            }
        }
    }

    IEnumerator countdownBtClick()
    {
        canActivate = false;
        Debug.Log("cor false");
        yield return new WaitForSeconds(countdownReclick);
        Debug.Log("cor true");
        canActivate = true;
    }

    public override void resetItem()
    {
        StopAllCoroutines();
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