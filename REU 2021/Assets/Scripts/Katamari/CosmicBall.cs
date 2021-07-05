using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosmicBall : MonoBehaviour
{
    #region Variables
    [Header("Ball values")]
    public float growthScale = 0.01f;
    public float ballSize = 1;

    [Header("Camera Angles")]
    private float facingAngle = 0;
    private float x = 0;
    private float z = 0;
    private Vector2 unitV2;

    [Header("Camera")]
    public GameObject camera;
    private float disToCam = 5;

    [Header("Audio")]
    private AudioSource audioSource;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        input();
        //GameManagement.instance.hasBeatGame(ballSize);
    }

    void FixedUpdate()
    {
        applyForce();
    }

    #region Utilities
    private void input()
    {
        // Controls
        if (GameManagement.instance.isInjuryAware)
        {
            if (UIBallManagement.instance.isTurn)
            {
                x = Input.GetAxis("HorizontalAD") * Time.deltaTime * -100;
                z = Input.GetAxis("VerticalWS") * Time.deltaTime * 500;
            }
            else
            {
                x = Input.GetAxis("HorizontalLeftRight") * Time.deltaTime * -100;
                z = Input.GetAxis("VerticalUpDown") * Time.deltaTime * 500;
            }
        }
        else
        {
            x = Input.GetAxis("Horizontal") * Time.deltaTime * -100;
            z = Input.GetAxis("Vertical") * Time.deltaTime * 500;
        }

        // Facing angle
        facingAngle += x;
        unitV2 = new Vector2(Mathf.Cos(facingAngle * Mathf.Deg2Rad), Mathf.Sin(facingAngle * Mathf.Deg2Rad));
    }

    private void applyForce()
    {
        // applies force behind ball
        this.transform.GetComponent<Rigidbody>().AddForce(new Vector3(unitV2.x, 0, unitV2.y) * z * 3);
        // sets camera position behind ball
        camera.transform.position = new Vector3(-unitV2.x * disToCam, disToCam, -unitV2.y * disToCam) + this.transform.position;
    }
    #endregion

    #region Collision
    void OnTriggerEnter(Collider other)
    {
        StickyItem stickyItem = other.gameObject.GetComponent<StickyItem>();
        float categorySize = Categories.instance.categorySize[stickyItem.category];

        /** if collided object has tag and it's category size is less than ball size,
         * add to ball
         * grow in size
        **/
        if ((stickyItem) && (categorySize <= ballSize))
        {
            if (0 < ballSize)
            {
                Categories.instance.setCurrCategorySize(categorySize);

                // Grow
                transform.localScale += new Vector3(growthScale, growthScale, growthScale);
                ballSize += growthScale;
                disToCam += 0.08f;
                other.enabled = false;  // if not disabled, child objects also pick things up

                // Add
                other.transform.SetParent(this.transform);
                UIBallManagement.instance.setBallSizeText(ballSize);
                ZoneManagement.instance.incrementZoneCount(stickyItem.zone);
            }
        }
    }
    #endregion
}
