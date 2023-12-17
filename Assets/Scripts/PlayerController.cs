using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator PlayerNator;

    public float MovingSpeed = 1f;

    private bool isWalking;
    private bool isFlipped;

    private SpriteRenderer playerSprite;

    // Start is called before the first frame update
    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
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
}
