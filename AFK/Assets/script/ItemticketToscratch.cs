using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemticketToscratch : itemActivable
{
    [SerializeField]
    private int chanceToWin2, chanceToWin10, chanceToWin100;

    [SerializeField]
    private Text winText;

    [SerializeField]
    private Button playButton;

    public override void activate()
    {
        base.activate();

        int n = Random.Range(1, 100);

        //base item if loose
        item t = new item();
        t.name = "Loose";
        t.amountsDirect[2] = -10;

        if (n <= chanceToWin2)
        {
            //win 2
            Debug.Log("win 2$");
            t.name = "2$";
            t.amountsDirect[2] = 10;
            gameManager.instance.playerManager.winMoney(2);
        }
        else if (n > chanceToWin2 && n <= chanceToWin2 + chanceToWin10)
        {
            //win 10
            Debug.Log("win 10$");
            t.name = "10$";
            t.amountsDirect[2] = 20;
            gameManager.instance.playerManager.winMoney(10);
        }
        else if (n > chanceToWin2 + chanceToWin10 && n <= chanceToWin2 + chanceToWin10 + chanceToWin100)
        {
            //win 100
            Debug.Log("win 100$");
            t.name = "100$";
            t.amountsDirect[2] = 30;
            gameManager.instance.playerManager.winMoney(100);
        }
        else
        {
            //loose
            Debug.Log("loose");
        }
        gameManager.instance.playerManager.consumeItem(t);
        winText.text = t.name;
        playButton.enabled = false;
    }

    public override void resetItem()
    {
        base.resetItem();
    }
}