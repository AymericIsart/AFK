using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class activateOther : MonoBehaviour
{
    [SerializeField]
    private UnityEvent leEvent;

    public void showPopUp()
    {
        leEvent.Invoke();
    }
}