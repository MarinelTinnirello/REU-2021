using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIBallManagement : MonoBehaviour
{
    #region Variables
    public static UIBallManagement instance;

    [Header("Controllers")]
    public bool isTurn;         // false has WASD, true has Arrows
    public float duration;
    private float currTime;

    [Header("UI Components")]
    [SerializeField] private GameObject controls;
    [SerializeField] private TMP_Text ballSizeText;
    [SerializeField] private TMP_Text wasdText;
    [SerializeField] private TMP_Text arrowsText;
    [SerializeField] private Image image;

    [Header("Audio")]
    private AudioSource audioSource;
    #endregion

    void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();

        // if the Mode is set to be Injury-Aware, use controls
        if (!GameManagement.instance.isInjuryAware)
        {
            controls.SetActive(false);
        }
    }

    void Update()
    {
        timer();
    }

    #region Utilities
    public void setBallSizeText(float ballSize)
    {
        if (ballSizeText != null)
        {
            ballSizeText.text = "Size:  " + Math.Round(ballSize, 2).ToString() + "m";
        }
    }

    public void timer()
    {
        float val = 1;

        currTime -= Time.deltaTime;
        val = currTime / duration;
        image.fillAmount = val;

        if (currTime <= 0)
        {
            currTime = duration;
            image.fillAmount = 1;

            isTurn = !isTurn;
            setControllerText();
        }
    }

    public void setControllerText()
    {
        if (isTurn)
        {
            wasdText.gameObject.SetActive(true);
            arrowsText.gameObject.SetActive(false);
        }
        else
        {
            wasdText.gameObject.SetActive(false);
            arrowsText.gameObject.SetActive(true);
        }

        if (GameManagement.instance.isInjuryAware)
        {
            audioSource.Play();
        }
    }
    #endregion
}
