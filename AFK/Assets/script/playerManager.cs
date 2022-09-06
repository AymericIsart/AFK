using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerManager : MonoBehaviour
{
    [Header("slider")]
    [SerializeField]
    private float[] amounts;

    [SerializeField]
    private Image[] sliders;

    [SerializeField]
    private float minAmount, maxAmount;

    [Header("death msg")]
    [SerializeField]
    private string[] msgMinAmount;

    [SerializeField]
    private string[] msgMaxAmount;

    [Header("money")]
    [SerializeField]
    private float startMoney;

    [SerializeField]
    private float moneyGainPerDay;

    private float playerMoney;

    private bool isDead = true;

    private void OnValidate()
    {
        if (amounts.Length != 3)
        {
            Debug.LogWarning("Don't change the field's array size!");
            Array.Resize(ref amounts, 3);
        }

        if (sliders.Length != 3)
        {
            Debug.LogWarning("Don't change the field's array size!");
            Array.Resize(ref sliders, 3);
        }

        if (msgMinAmount.Length != 3)
        {
            Debug.LogWarning("Don't change the field's array size!");
            Array.Resize(ref msgMinAmount, 3);
        }

        if (msgMaxAmount.Length != 3)
        {
            Debug.LogWarning("Don't change the field's array size!");
            Array.Resize(ref msgMaxAmount, 3);
        }
    }

    private void Update()
    {
        if (!isDead)
        {
            for (int i = 0; i < 3; i++)
            {
                sliders[i].fillAmount -= (amounts[i] / 100) * Time.deltaTime;
                checkGameOver(i);
            }
        }
    }

    public void consumeItem(items s)
    {
        if (playerMoney < s.price)
        {
            Debug.Log("not enough money");
            return;
        }
        for (int i = 0; i < 3; i++)
        {
            sliders[i].fillAmount += (s.amounts[i] / 100);
            checkGameOver(i);
        }
    }

    private void checkGameOver(int i)
    {
        if (sliders[i].fillAmount <= (minAmount / 100))
        {
            playerDied(msgMinAmount[i]);
        }
        else if (sliders[i].fillAmount >= (maxAmount / 100))
        {
            playerDied(msgMaxAmount[i]);
        }
    }

    public void resetPlayer()
    {
        isDead = false;
        playerMoney = startMoney;
        for (int i = 0; i < 3; i++)
        {
            sliders[i].fillAmount = 0.5f;
        }
    }

    private void playerDied(string msg)
    {
        isDead = true;
        gameManager.instance.uiManager.gameOverUi(msg);
        gameManager.instance.cameraManager.resetCam();
    }
}