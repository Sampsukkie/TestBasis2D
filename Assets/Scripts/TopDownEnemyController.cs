using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownEnemyController : MonoBehaviour
{
    public bool IsOnRotate; 

    public float EnemySpeed; 
    public float Radius; 

    public GameObject Player; 

    public LayerMask L_Player; 

    public Vector3 direction; 

    private Animator enemyNator;

    private Rigidbody2D rb;

    private Vector2 movement;

    private bool isPlayerInRange; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        enemyNator = GetComponent<Animator>();
    }

    void Update()
    {
        enemyNator.SetBool("isMoving", isPlayerInRange);

        isPlayerInRange = Physics2D.OverlapCircle(transform.position, Radius, L_Player);

        direction = Player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        direction.Normalize();
        movement = direction;

        if (IsOnRotate)
        {
            enemyNator.SetFloat("X", direction.x);
            enemyNator.SetFloat("Y", direction.y);
        }
    }

    private void FixedUpdate()
    {
        if (isPlayerInRange)
        {
            MoveEnemy(movement);
        }
    }

    private void MoveEnemy(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * EnemySpeed * Time.deltaTime));
    }
}
