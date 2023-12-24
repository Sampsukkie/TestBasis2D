using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerPlayerController : MonoBehaviour
{
    public float PlayerSpeed;

    private bool isAbleMove;

    private float boostTempo = 5f;
    private float nextBoost;

    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            isAbleMove = true;
        }

        if (rb.velocity.magnitude < PlayerSpeed && isAbleMove)
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

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Stopper"))
        {
            isAbleMove = false;
        }
    }
}
