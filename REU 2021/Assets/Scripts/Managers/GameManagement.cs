using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
    #region Variables
    public static GameManagement instance;

    [Header("Modes")]
    public bool isDebugMode;
    public bool isGameMode;
    public bool isInjuryAware;

    [Header("Controllers")]
    public float winSize = 5;
    public bool hasWon;
    #endregion

    void Awake()
    {
        instance = this;
    }

    #region Controller Utilities
    public void hasBeatGame(float ballSize)
    {
        if (ballSize >= winSize)
        {
            hasWon = true;
            Debug.Log("Beat game");
        }
    }
    #endregion
}
