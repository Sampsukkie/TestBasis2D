using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance;

    public Camera MainCam;

    public Color W1Color;
    public Color W2Color;

    public float followTime = 1f;

    public GameObject Player;

    private bool isSkyColor;

    private Vector3 offset;
    private Vector3 velocity = Vector3.zero;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != null)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        offset = transform.position - Player.transform.position;

        isSkyColor = true;
    }

    void LateUpdate()
    {
        Vector3 targetPosition = Player.transform.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, followTime);
    }

    public void SetCamBGColor()
    {
        if (isSkyColor)
        {
            MainCam.backgroundColor = W2Color;
            isSkyColor = false;
        }
        else
        {
            MainCam.backgroundColor = W1Color;
            isSkyColor = true;
        }
    }
}
