using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerManager : MonoBehaviour
{
    [SerializeField]
    private float[] amounts;

    [SerializeField]
    private Image[] sliders;

    [SerializeField]
    private float minAmount, maxAmount;

    [SerializeField]
    private string[] msgMinAmount;

    [SerializeField]
    private string[] msgMaxAmount;

    private bool isDead = false;

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

    public void resetPlayer()
    {
        isDead = false;
        for (int i = 0; i < 3; i++)
        {
            sliders[i].fillAmount = 0.5f;
        }
    }

    // Update is called once per frame
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
            Debug.Log("game over min : " + i);
            Debug.Log(msgMinAmount[i]);
            playerDied();
        }
        else if (sliders[i].fillAmount >= (maxAmount / 100))
        {
            Debug.Log("game over max : " + i);
            Debug.Log(msgMaxAmount[i]);
            playerDied();
        }
    }

    private void playerDied()
    {
        isDead = true;
        gameManager.instance.cameraManager.resetCam();
    }
}