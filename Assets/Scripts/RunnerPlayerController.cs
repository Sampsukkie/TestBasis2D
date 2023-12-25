using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerPlayerController : MonoBehaviour
{
    public float PlayerSpeed;

    public KeyCode BoostKey;
    public KeyCode SwitchKey;

    public GameObject W1;
    public GameObject W2;

    private bool isAbleMove;
    private bool isW1;

    private float boostTempo = 5f;
    private float nextBoost;

    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isW1 = true;
        W2.SetActive(false);
    }

    void Update()
    {
        if (rb.velocity.magnitude < PlayerSpeed && isAbleMove)
        {
            rb.AddForce(Vector3.right * PlayerSpeed);
        }

        if (Input.GetKeyDown(BoostKey) && Time.time > nextBoost)
        {
            nextBoost = Time.time + boostTempo;

            rb.AddForce(Vector3.left * 3000f);
            rb.AddForce(Vector3.up * 1500f);
        }

        if (Input.GetKeyDown(SwitchKey))
        {
            if (isW1)
            {
                CameraController.Instance.SetCamBGColor();
                W1.SetActive(false);
                W2.SetActive(true);
                isW1 = false;
            }
            else
            {
                CameraController.Instance.SetCamBGColor();
                W1.SetActive(true);
                W2.SetActive(false);
                isW1 = true;
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Stopper"))
        {
            isAbleMove = false;
        }
    }
}
