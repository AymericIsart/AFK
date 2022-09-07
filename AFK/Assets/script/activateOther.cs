using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateOther : MonoBehaviour
{
    [SerializeField]
    private GameObject other;

    public void showPopUp()
    {
        other.SetActive(true);
    }
}