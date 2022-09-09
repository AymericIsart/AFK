using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public static gameManager instance;

    [HideInInspector]
    public soundManager soundManager;

    [HideInInspector]
    public itemManager itemManager;

    [HideInInspector]
    public playerManager playerManager;

    [HideInInspector]
    public cameraManager cameraManager;

    [HideInInspector]
    public UIManager uiManager;

    public enum state
    { START, INGAME, DEAD };

    public state gamestate = state.START;

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
        itemManager = GetComponent<itemManager>();

        soundManager.playSound("menu theme");
    }

    public void resetGame()
    {
        cameraManager.resetCam();
        playerManager.resetPlayer();
        uiManager.startGameUi();
        itemManager.resetItems();
        gamestate = state.INGAME;
        soundManager.stopSound("menu theme");
        soundManager.playSound("main theme");
    }
}