using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gameUI;

    [SerializeField]
    private GameObject startUI;

    [SerializeField]
    private GameObject deathUI;

    [SerializeField]
    private Text deathMsg;

    public void startGameUi()
    {
        startUI.SetActive(false);
        deathUI.SetActive(false);
        gameUI.SetActive(true);
    }

    public void gameOverUi(string dthMsg)
    {
        startUI.SetActive(false);
        deathUI.SetActive(true);
        gameUI.SetActive(false);

        deathMsg.text = dthMsg;
    }
}