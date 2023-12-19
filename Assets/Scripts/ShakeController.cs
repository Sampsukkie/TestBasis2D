using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeController : MonoBehaviour
{
    public Animator CamNator;

    public void CamShake()
    {
        CamNator.SetTrigger("shake");
    }
}
