using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Keypress
{
    #region Structs
    [System.Serializable]
    public struct TemporalMeasurements
    {
        public float timestamp;
        public string trackedKey;
        public int pressedCount;
        public int pressedAvg;

        public TemporalMeasurements(float time, string key, int count, int avg)
        {
            timestamp = time;
            trackedKey = key;
            pressedCount = count;
            pressedAvg = avg;
        }
    }

    [System.Serializable]
    public struct SpatialMeasurements
    {
        public float timestamp;
        public int zoneId;
        public int zoneCount;

        public SpatialMeasurements(float time, int id, int count)
        {
            timestamp = time;
            zoneId = id;
            zoneCount = count;
        }
    }
    #endregion

    #region Variables
    public KeyCode trackedKey;
    public int pressCount;
    public int pressAvg;

    #region Google Sheets
    [HideInInspector] public static string boardName = "";
    #endregion

    #region Utilities
    private float timer = 0.0f;
    public float time = 60.0f;
    public bool hasTimePassed = false;
    #endregion
    #endregion

    public Keypress(KeyCode keyToTrack)
    {
        trackedKey = keyToTrack;
    }

    #region Google Sheets
    [UnityEditor.MenuItem("Google Sheets/Upload")]
    public void UploadMeasurements()
    {
        TemporalMeasurements[] tm = new TemporalMeasurements[5];

        tm[1].timestamp = 1.11f;
        tm[2].pressedCount = 25;
        tm[4].trackedKey = "W";

        string name = "01";


    }
    #endregion

    #region Utilities
    public void checkIfTimePassed(float time)
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
