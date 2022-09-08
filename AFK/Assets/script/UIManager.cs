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
    private Text deathMsg;

    [SerializeField]
    private GameObject[] popUps;

    [SerializeField]
    private Text money;

    [SerializeField]
    private Text days;

    [SerializeField]
    private Text moneyGO;

    [SerializeField]
    private Text daysGO;

    [Header("money loss anim")]
    [SerializeField]
    private Animator lossAnim;

    [SerializeField]
    private Text lossText;

    [Header("event anim")]
    [SerializeField]
    private Animator eventAnim;

    [SerializeField]
    private Text eventText;

    public void startGameUi()
    {
        lossText.text = "";
        lossAnim.Play("moneyLossAnim", 0, 0);
        startUI.SetActive(false);
        deathUI.SetActive(false);
        gameUI.SetActive(true);
        worldCanvas.SetActive(true);
        foreach (GameObject g in popUps)
        {
            g.SetActive(false);
        }
    }

    public void gameOverUi(string dthMsg)
    {
        startUI.SetActive(false);
        deathUI.SetActive(true);
        gameUI.SetActive(false);
        worldCanvas.SetActive(false);
        foreach (GameObject g in popUps)
        {
            g.SetActive(false);
        }
        moneyGO.text = money.text;
        daysGO.text = days.text;

        deathMsg.text = dthMsg;
    }

    public void updateValues(int d, float m, float price)
    {
        money.text = m.ToString() + "$";
        days.text = d.ToString() + " days";

        if (price != 0)
        {
            if (price > 0)
            {
                lossText.color = Color.green;
            }
            else
            {
                lossText.color = Color.red;
            }
            lossText.text = price.ToString() + "$";
            lossAnim.Play("moneyLossAnim", 0, 0);
        }
    }

    public void eventAnimShow(string s)
    {
        Debug.Log(s);
        if (s != "" && s != null)
        {
            eventText.text = s;
            eventAnim.Play("eventAnim", 0, 0);
        }
    }

    public bool isAnyPopUpActif()
    {
        foreach (GameObject g in popUps)
        {
            if (g.activeSelf)
            {
                return true;
            }
        }
        return false;
    }
}