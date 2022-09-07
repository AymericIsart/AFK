using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemWithCooldown : itemActivable
{
    [SerializeField]
    private int cooldownTime;

    private bool canConsume = true;

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
        base.resetItem();
        StopAllCoroutines();
        canConsume = true;
    }

    private IEnumerator countdown()
    {
        canConsume = false;
        yield return new WaitForSeconds(cooldownTime);
        canConsume = true;
    }
}