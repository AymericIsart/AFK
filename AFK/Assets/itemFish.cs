using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemFish : itemActivable
{
    [SerializeField]
    private item fishDies;

    private bool hasBeenFedToday = false;
    private bool isDead = false;

    public override void activate()
    {
        if (!hasBeenFedToday && !isDead)
        {
            base.activate();
            hasBeenFedToday = true;
        }
    }

    public override void resetAfterDayPass()
    {
        if (hasBeenFedToday)
        {
            Debug.Log("blue was fed, still alive");
            hasBeenFedToday = false;
        }
        else
        {
            if (!isDead)
            {
                //dies
                Debug.Log("blue dies !");
                isDead = true;
                gameManager.instance.playerManager.consumeItem(fishDies);
            }
        }
    }

    public override void resetItem()
    {
        base.resetItem();
        hasBeenFedToday = false;
        isDead = false;
    }
}