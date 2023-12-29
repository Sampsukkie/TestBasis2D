using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPlayerController : MonoBehaviour
{
    public GameObject PlayerBlocker;

    public KeyCode StartButton_Key;

    private bool isGameStarted;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(StartButton_Key) && !isGameStarted)
        {
            PlayerBlocker.SetActive(false);
            rb.AddForce(Vector3.up * 200f);
            isGameStarted = true;
        }
    }
}
