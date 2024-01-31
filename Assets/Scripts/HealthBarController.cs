using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{

    public Image SlideImg;

    [SerializeField] [Range(0, 1)] float progress = 100f;

    void Update()
    {
        SlideImg.fillAmount = progress;
        Quaternion.Euler(new Vector3(0f, 0f, -progress * 100));
    }

    public void LoseProgress()
    {
        progress = progress - 0.01f;
    }
}
