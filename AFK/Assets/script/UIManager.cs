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

    public void startGameUi()
    {
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

        deathMsg.text = dthMsg;
    }

    public void updateValues(int d, float m)
    {
        money.text = m.ToString() + "$";
        days.text = d.ToString() + " days";
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