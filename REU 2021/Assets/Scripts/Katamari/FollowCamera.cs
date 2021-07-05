using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    #region Variables
    public GameObject ball;
    private Vector3 offset;
    #endregion

    void Start()
    {
        offset = new Vector3(0, 1.5f, 0);
    }

    void Update()
    {
        transform.LookAt(ball.transform.position + offset);
    }
}
