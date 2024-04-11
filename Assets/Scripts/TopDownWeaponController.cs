using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownWeaponController : MonoBehaviour
{
    public bool IsAbleFire;

    public float FireRecover;

    public GameObject Weapon;

    public Transform WeaponTransform;

    private Camera mainCam;

    private float timer;

    private Vector3 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        {
            mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

            Vector3 rotation = mousePos - transform.position;

            float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0, 0, rotZ);


            if (!IsAbleFire)
            {
                timer += Time.deltaTime;
                if (timer > FireRecover)
                {
                    IsAbleFire = true;
                    timer = 0;
                }
            }

            if (Input.GetMouseButtonDown(0) && IsAbleFire)
            {
                IsAbleFire = false;
                Instantiate(Weapon, WeaponTransform.position, Quaternion.identity);
            }
        }
    }
}
