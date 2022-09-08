using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class itemWithCooldown : itemActivable
{
    [SerializeField]
    private int cooldownTime;

    private bool canConsume = true;

    [SerializeField]
    private UnityEvent eventAfterCooldown;

    public override void activate()
    {
        if (canConsume)
        {
            base.activate();
            StartCoroutine(countdown());
        }
    }

    public override void resetItem()
    {
        eventAfterCooldown.Invoke();
        base.resetItem();
        StopAllCoroutines();
        canConsume = true;
    }

    private IEnumerator countdown()
    {
        canConsume = false;
        yield return new WaitForSeconds(cooldownTime);
        canConsume = true;
        eventAfterCooldown.Invoke();
    }
}