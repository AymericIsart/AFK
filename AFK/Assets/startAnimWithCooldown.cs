using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startAnimWithCooldown : MonoBehaviour
{
    [SerializeField]
    int countTime;

    [SerializeField]
    Animator anim;

    bool isActive = false;
    public void startCountDown()
    {
        if (!isActive)
        {
            StartCoroutine(countdown());
        }
    }

    IEnumerator countdown()
    {
        isActive = true;
        yield return new WaitForSeconds(countTime);
        anim.Play("DoorAnimation", 0, 0);
        isActive = false;
    }
}
