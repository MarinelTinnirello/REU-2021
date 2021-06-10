using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypressCount : MonoBehaviour
{
    #region Variables
    #region Key Counts
    [Header("WASD Key Counts")]
    private int wCount = 0;
    private int aCount = 0;
    private int sCount = 0;
    private int dCount = 0;

    [Header("Arrow Key Counts")]
    private int leftCount = 0;
    private int rightCount = 0;
    private int upCount = 0;
    private int downCount = 0;

    [Header("Other Key Counts")]
    private int leftClickCount = 0;
    private int rightClickCount = 0;
    private int spCount = 0;
    #endregion

    #region Key Counts Per Minute
    [Header("WASD Key Counts")]
    private int wAvg = 0;
    private int aAvg = 0;
    private int sAvg = 0;
    private int dAvg = 0;

    [Header("Arrow Key Counts")]
    private int leftAvg = 0;
    private int rightAvg = 0;
    private int upAvg = 0;
    private int downAvg = 0;

    [Header("Other Key Counts")]
    private int leftClickAvg = 0;
    private int rightClickAvg = 0;
    private int spAvg = 0;
    #endregion

    [SerializeField] private float time = 60.0f;
    private float timer = 0.0f;
    private bool hasTimePassed = false;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkKeyPressed();
        checkIfMinutePassed(time);
    }

    #region Key Checks
    private void checkKeyPressed()
    {
        #region WASD
        if (Input.GetKeyDown(KeyCode.W))
        {
            wCount++;
            UIManagement.instance.setCountText(0, wCount);

            if (hasTimePassed)
            {
                wAvg = countPerMinute(time, wCount, wAvg);
                wCount = resetCount(wCount);
                UIManagement.instance.setAvgText(0, wAvg);
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            aCount++;
            UIManagement.instance.setCountText(1, aCount);

            if (hasTimePassed)
            {
                aAvg = countPerMinute(time, aCount, aAvg);
                aCount = resetCount(aCount);
                UIManagement.instance.setAvgText(1, aAvg);
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            sCount++;
            UIManagement.instance.setCountText(2, sCount);

            if (hasTimePassed)
            {
                sAvg = countPerMinute(time, sCount, sAvg);
                sCount = resetCount(sCount);
                UIManagement.instance.setAvgText(2, sAvg);
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            dCount++;
            UIManagement.instance.setCountText(3, dCount);

            if (hasTimePassed)
            {
                dAvg = countPerMinute(time, dCount, dAvg);
                dCount = resetCount(dCount);
                UIManagement.instance.setAvgText(3, dAvg);
            }
        }
        #endregion

        #region Arrows
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            leftCount++;
            UIManagement.instance.setCountText(4, leftCount);

            if (hasTimePassed)
            {
                leftAvg = countPerMinute(time, leftCount, leftAvg);
                leftCount = resetCount(leftCount);
                UIManagement.instance.setAvgText(4, leftAvg);
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rightCount++;
            UIManagement.instance.setCountText(5, rightCount);

            if (hasTimePassed)
            {
                rightAvg = countPerMinute(time, rightCount, rightAvg);
                rightCount = resetCount(rightCount);
                UIManagement.instance.setAvgText(5, rightAvg);
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            upCount++;
            UIManagement.instance.setCountText(6, upCount);

            if (hasTimePassed)
            {
                upAvg = countPerMinute(time, upCount, upAvg);
                upCount = resetCount(upCount);
                UIManagement.instance.setAvgText(6, upAvg);
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            downCount++;
            UIManagement.instance.setCountText(7, downCount);

            if (hasTimePassed)
            {
                downAvg = countPerMinute(time, downCount, downAvg);
                downCount = resetCount(downCount);
                UIManagement.instance.setAvgText(7, downAvg);
            }
        }
        #endregion
    }

    private int countPerMinute(float time, int charCount, int charAvg)
    {
        return charAvg = charCount / (int)time;
    }

    private int resetCount(int charCount)
    {
        hasTimePassed = false;

        return charCount = 0;
    }
    #endregion

    #region Utilities
    private void checkIfMinutePassed(float time)
    {            
        timer += Time.deltaTime;

        if (timer > time)
        {
            timer = 0.0f;
            hasTimePassed = true;
        }
    }
    #endregion
}
