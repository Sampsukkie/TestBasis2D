using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public Animator PlayerNator;

    public float MovingSpeed = 1f;

    public GameObject Apple;

    public int Collectibles;

    private bool isWalking;
    private bool isFlipped;
    private bool isOnGround;
    private bool isInPickable;
    private bool isCarryingApple;

    private SpriteRenderer playerSprite;

    private ShakeController shake;

    private Rigidbody2D rb;

    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();

        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<ShakeController>();

        rb = GetComponent<Rigidbody2D>();
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

        if (Input.GetKeyDown(KeyCode.W) && isOnGround)
        {
            rb.AddForce(Vector2.up * 1500);
        }

        if (Input.GetKeyDown(KeyCode.S) && isInPickable)
        {
            Apple.SetActive(false);
            isCarryingApple = true;
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
                GoToWinScene();
            }
        }

        if (other.gameObject.CompareTag("Pickable"))
        {
            isInPickable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickable"))
        {
            isInPickable = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            CameraShake();
        }

        if (collider.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }

    }

    private void OnCollisionExit2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Ground"))
        {
            isOnGround = false;
        }
    }

    public void CameraShake()
    {
        shake.CamShake();
    }

    public void GoToWinScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
