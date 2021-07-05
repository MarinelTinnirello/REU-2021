using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Categories : MonoBehaviour
{
    #region Variables
    public static Categories instance;

    [Header("Category Attributes")]
    public float currCategory;
    public float[] categorySize;
    public bool[] isCategoryUnlocked;
    #endregion

    void Awake()
    {
        instance = this;
        currCategory = categorySize[0];
    }

    void Update()
    {
        for (int i = 0; i < categorySize.Length; i++)
        {
            if (currCategory >= categorySize[i])
            {
                isCategoryUnlocked[i] = true;

                setTriggers(isCategoryUnlocked[i], categorySize[i]);
            }
        }
    }

    public void setTriggers(bool isUnlocked, float size)
    {
        StickyItem[] arr = FindObjectsOfType<StickyItem>();

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i].category <= size && isUnlocked == true)
            {
                arr[i].gameObject.GetComponent<Collider>().isTrigger = true;
            }
        }
    }

    public float setCurrCategorySize(float size)
    {
        return currCategory = size;
    }

    public void turnOnIndicators(GameObject go)
    {
        if (go.GetComponent<Outline>())
        {
            go.GetComponent<Outline>().enabled = true;
        }
    }

    public void turnOffIndicators(GameObject go)
    {
        if (go.GetComponent<Outline>())
        {
            go.GetComponent<Outline>().enabled = false;
        }
    }
}
