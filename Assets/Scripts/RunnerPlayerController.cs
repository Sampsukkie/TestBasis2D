using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerPlayerController : MonoBehaviour
{
    public float PlayerSpeed;

    private float boostTempo = 5f;
    private float nextBoost;

    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (rb.velocity.magnitude < PlayerSpeed)
        {
            rb.AddForce(Vector3.right * PlayerSpeed);
        }

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextBoost)
        {
            nextBoost = Time.time + boostTempo;

            rb.AddForce(Vector3.left * 3000f);
            rb.AddForce(Vector3.up * 1500f);
        }
    }
}
