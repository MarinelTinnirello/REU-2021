using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagement : MonoBehaviour
{
    #region Variables
    public static UIManagement instance;

    [Header("Key Count Texts")]
    [SerializeField] private Text[] keyCountTexts;
    [SerializeField] private Text[] keyAvgTexts;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setCountText(int index, int val)
    {
        keyCountTexts[index].text = val.ToString();
    }

    public void setAvgText(int index, int val)
    {
        keyAvgTexts[index].text = val.ToString();
    }
}
