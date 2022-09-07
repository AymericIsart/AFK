using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemManager : MonoBehaviour
{
    public item[] itemList;

    private void OnValidate()
    {
        foreach (item s in itemList)
        {
            if (s.amountsDirect.Length != 3)
            {
                Debug.LogWarning("Don't change the field's array size!");
                Array.Resize(ref s.amountsDirect, 3);
            }
            if (s.amountsTime.Length != 3)
            {
                Debug.LogWarning("Don't change the field's array size!");
                Array.Resize(ref s.amountsTime, 3);
            }
        }
    }

    private void Update()
    {
        //for mouse
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "interactable")
                {
                    Debug.Log(hit.transform.name);
                    consumeItem(hit.transform.name);
                }
            }
        }

        //for touchScreen
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "interactable")
                {
                    Debug.Log(hit.transform.name);
                    consumeItem(hit.transform.name);
                }
            }
        }
    }

    public void consumeItem(string name)
    {
        item s = findItem(name);
        if (s != null)
        {
            gameManager.instance.playerManager.consumeItem(s);
        }
        else
        {
            Debug.LogError("item with name " + name + " does not exist");
        }
    }

    public item findItem(string name)
    {
        return Array.Find(itemList, item => item.name == name);
    }
}