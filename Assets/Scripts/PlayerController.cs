using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator PlayerNator;

    public float MovingSpeed = 1f;

    public int Collectibles;

    private bool isWalking;
    private bool isFlipped;

    private SpriteRenderer playerSprite;

    private ShakeController shake;

    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();

        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<ShakeController>();
    }

    void Update()
    {
        float movingDirection = Input.GetAxisRaw("Horizontal");

        transform.position += Vector3.right * movingDirection * MovingSpeed * Time.deltaTime;

        isWalking = movingDirection != 0f;

        PlayerNator.SetBool("Walking", isWalking);

        if (movingDirection < 0f && !isFlipped)
        {
            playerSprite.flipX = true;
            isFlipped = true;
        }
        else if (movingDirection > 0f && isFlipped)
        {
            playerSprite.flipX = false;
            isFlipped = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            Collectibles++;
            Destroy(other.gameObject);

            if (Collectibles == 4)
            {

            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            shake.CamShake();
        }
    }
}
