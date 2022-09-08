using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deactivateOnDisable : MonoBehaviour
{
    [SerializeField]
    private GameObject[] objToDisable;

    private void OnDisable()
    {
        foreach (GameObject g in objToDisable)
        {
            g.SetActive(false);
        }
    }
}