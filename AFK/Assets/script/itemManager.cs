using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class itemManager : MonoBehaviour
{
    private List<itemActivable> itemsScripts = new List<itemActivable>();

    private int fingerID = -1;

    private void Awake()
    {
#if !UNITY_EDITOR
     fingerID = 0;
#endif
    }

    private void Start()
    {
        //fill itemScripts
        GameObject[] items = GameObject.FindGameObjectsWithTag("interactable");
        foreach (GameObject g in items)
        {
            if (g.GetComponent<itemActivable>())
            {
                itemsScripts.Add(g.GetComponent<itemActivable>());
            }
        }
    }

    private void Update()
    {
        //for mouse
        if (Input.GetMouseButtonDown(0) && !gameManager.instance.uiManager.isAnyPopUpActif())
        {
            if (EventSystem.current.IsPointerOverGameObject(fingerID))    // is the touch on the GUI
            {
                // GUI Action
                return;
            }
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "interactable")
                {
                    Debug.Log("click " + hit.transform.name);
                    if (hit.transform.GetComponent<itemActivable>())
                    {
                        hit.transform.GetComponent<itemActivable>().activate();
                    }
                    else if (hit.transform.GetComponent<activateOther>())
                    {
                        hit.transform.GetComponent<activateOther>().showPopUp();
                    }
                }
            }
        }

        //for touchScreen
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began && !gameManager.instance.uiManager.isAnyPopUpActif())
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "interactable")
                {
                    Debug.Log("click " + hit.transform.name);
                    if (hit.transform.GetComponent<itemActivable>())
                    {
                        hit.transform.GetComponent<itemActivable>().activate();
                    }
                    else if (hit.transform.GetComponent<activateOther>())
                    {
                        hit.transform.GetComponent<activateOther>().showPopUp();
                    }
                }
            }
        }
    }

    public void resetItems()
    {
        foreach (itemActivable s in itemsScripts)
        {
            s.resetItem();
        }
    }

    public void resetDay()
    {
        foreach (itemActivable s in itemsScripts)
        {
            s.resetAfterDayPass();
        }
    }
}