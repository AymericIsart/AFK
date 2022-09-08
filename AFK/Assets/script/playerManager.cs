using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class playerManager : MonoBehaviour
{
    [Header("slider")]
    [SerializeField]
    private float[] startAmounts;

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

    [Header("day time")]
    [SerializeField]
    private float timeBetweenDays;

    private float playerMoney;
    private int days;
    private float[] amounts = new float[3];

    private void OnValidate()
    {
        if (startAmounts.Length != 3)
        {
            Debug.LogWarning("Don't change the field's array size!");
            Array.Resize(ref startAmounts, 3);
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
        if (gameManager.instance.gamestate == gameManager.state.INGAME)
        {
            for (int i = 0; i < 3; i++)
            {
                sliders[i].fillAmount -= (amounts[i] / 100) * Time.deltaTime;
                checkGameOver(i);
            }
        }
    }

    public void consumeItem(item s)
    {
        if (playerMoney < s.price)
        {
            Debug.Log("not enough money");
            gameManager.instance.uiManager.eventAnimShow("Not enough Money !");
            return;
        }
        gameManager.instance.uiManager.eventAnimShow(s.description);
        playerMoney -= s.price;
        gameManager.instance.uiManager.updateValues(days, playerMoney, -s.price);
        for (int i = 0; i < 3; i++)
        {
            sliders[i].fillAmount += (s.amountsDirect[i] / 100);
            if (s.amountsTime[i].infinite)
            {
                amounts[i] -= s.amountsTime[i].amount;
            }
            else if (s.amountsTime[i].timeInSecond > 0)
            {
                StartCoroutine(addAmountOverTime(s.amountsTime[i].timeInSecond, s.amountsTime[i].amount, i));
            }
            checkGameOver(i);
        }
        s.events.Invoke();
    }

    private IEnumerator addAmountOverTime(int t, float amount, int pos)
    {
        amounts[pos] -= amount;
        yield return new WaitForSeconds(t);
        amounts[pos] += amount;
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
        StopAllCoroutines();
        playerMoney = startMoney;
        days = 1;
        for (int i = 0; i < 3; i++)
        {
            amounts[i] = startAmounts[i];
        }
        gameManager.instance.uiManager.updateValues(days, playerMoney, 0);
        InvokeRepeating("dayHasPassed", timeBetweenDays, timeBetweenDays);
        for (int i = 0; i < 3; i++)
        {
            sliders[i].fillAmount = 0.5f;
        }
    }

    public void winMoney(int v)
    {
        playerMoney += v;
        gameManager.instance.uiManager.updateValues(days, playerMoney, v);
    }

    private void dayHasPassed()
    {
        playerMoney += moneyGainPerDay;
        days++;
        gameManager.instance.uiManager.updateValues(days, playerMoney, moneyGainPerDay);

        //special fish case
        gameManager.instance.itemManager.resetDay();
    }

    private void playerDied(string msg)
    {
        gameManager.instance.gamestate = gameManager.state.DEAD;
        CancelInvoke("dayHasPassed");
        gameManager.instance.uiManager.gameOverUi(msg);
        gameManager.instance.cameraManager.resetCam();
    }
}