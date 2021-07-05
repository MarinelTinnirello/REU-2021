using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneManagement : MonoBehaviour
{
    #region Variables
    public static ZoneManagement instance;

    #region Zone counts
    [Header("Zone Counts")]
    public int[] zones;
    #endregion
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        instance = this; 
    }

    #region Counts
    public int incrementZoneCount(int zoneNum)
    {
        return zones[zoneNum]++;
    }
    #endregion
}
