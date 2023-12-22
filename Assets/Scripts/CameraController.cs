using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Player;
    public float followTime = 1f;

    private Vector3 offset;
    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        offset = transform.position - Player.transform.position;
    }

    void LateUpdate()
    {
        Vector3 targetPosition = Player.transform.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, followTime);
    }
}
