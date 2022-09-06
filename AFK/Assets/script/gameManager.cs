using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public static gameManager instance;

    [HideInInspector]
    public soundManager soundManager;

    [HideInInspector]
    public playerManager playerManager;

    [HideInInspector]
    public cameraManager cameraManager;

    [HideInInspector]
    public UIManager uiManager;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        soundManager = GetComponent<soundManager>();
        playerManager = GetComponent<playerManager>();
        cameraManager = GetComponent<cameraManager>();
        uiManager = GetComponent<UIManager>();
    }

    public void resetGame()
    {
        cameraManager.resetCam();
        playerManager.resetPlayer();
        uiManager.startGameUi();
    }
}