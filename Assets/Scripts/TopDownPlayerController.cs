using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownPlayerController : MonoBehaviour
{
    public Animator playerNator;

    public float PlayerSpeed = 1f;

    void Start()
    {
        
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 moveVector = new Vector3(horizontal, vertical, 0f);
        moveVector = moveVector.normalized;
        transform.position += moveVector * PlayerSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.S))
        {
            playerNator.SetBool("backward", true);
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            playerNator.SetBool("backward", false);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            playerNator.SetBool("forward", true);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            playerNator.SetBool("forward", false);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            playerNator.SetBool("goRight", true);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            playerNator.SetBool("goRight", false);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            playerNator.SetBool("goLeft", true);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            playerNator.SetBool("goLeft", false);
        }
    }
}
