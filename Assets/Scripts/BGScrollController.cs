using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScrollController : MonoBehaviour
{
    public float ScrollSpeed = 5f;

    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * ScrollSpeed * Time.deltaTime;

        if (transform.position.x < -18.5)
        {
            transform.position = startPosition;
        }
    }
}
