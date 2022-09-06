using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cameraManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] cameras;

    [SerializeField]
    private GameObject btLeft;

    [SerializeField]
    private GameObject btRight;

    private int currentCam = 1;

    private void Start()
    {
        btLeft.GetComponent<Button>().onClick.AddListener(delegate { slide(true); });
        btRight.GetComponent<Button>().onClick.AddListener(delegate { slide(false); });
    }

    public void slide(bool left)
    {
        cameras[currentCam].SetActive(false);

        if (left)
        {
            currentCam--;
        }
        else
        {
            currentCam++;
        }

        cameras[currentCam].SetActive(true);

        if (currentCam == cameras.Length - 1)
        {
            btRight.SetActive(false);
        }
        else
        {
            btRight.SetActive(true);
        }

        if (currentCam == 0)
        {
            btLeft.SetActive(false);
        }
        else
        {
            btLeft.SetActive(true);
        }
    }
}