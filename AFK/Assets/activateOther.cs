using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateOther : itemActivable
{
    [SerializeField]
    private GameObject other;

    public override void showPopUp()
    {
        other.SetActive(true);
    }
}