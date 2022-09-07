using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gameUI;

    [SerializeField]
    private GameObject worldCanvas;

    [SerializeField]
    private GameObject startUI;

    [SerializeField]
    private GameObject deathUI;

    [SerializeField]
    private GameObject popUp;

    [SerializeField]
    private Text popUpText;

    [SerializeField]
    private Text deathMsg;

    [SerializeField]
    private Text money;

    [SerializeField]
    private Text days;

    private itemActivable currItem;

    public void startGameUi()
    {
        startUI.SetActive(false);
        deathUI.SetActive(false);
        popUp.SetActive(false);
        gameUI.SetActive(true);
        worldCanvas.SetActive(true);
    }

    public void gameOverUi(string dthMsg)
    {
        startUI.SetActive(false);
        deathUI.SetActive(true);
        gameUI.SetActive(false);
        worldCanvas.SetActive(false);
        popUp.SetActive(false);

        deathMsg.text = dthMsg;
    }

    public void showPopUp(itemActivable itemScript)
    {
        currItem = itemScript;
        popUpText.text = itemScript.thisItem.name;
        popUp.SetActive(true);
    }

    public void activateCurrItem()
    {
        currItem.activate();
    }

    public void updateValues(int d, float m)
    {
        money.text = m.ToString() + "$";
        days.text = d.ToString() + " days";
    }
}