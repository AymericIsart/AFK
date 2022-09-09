using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startAnimWithCooldown : MonoBehaviour
{
    [SerializeField]
    private int countTime;

    [SerializeField]
    private Animator anim;

    private bool isActive = false;

    public void startCountDown(string soundName)
    {
        if (!isActive)
        {
            StartCoroutine(countdown(soundName));
        }
    }

    private IEnumerator countdown(string s)
    {
        isActive = true;
        yield return new WaitForSeconds(countTime);
        anim.Play("DoorAnimation", 0, 0);
        gameManager.instance.soundManager.playSound("buzzer");
        isActive = false;
        yield return new WaitForSeconds(1);
        gameManager.instance.soundManager.playSound(s);
    }
}