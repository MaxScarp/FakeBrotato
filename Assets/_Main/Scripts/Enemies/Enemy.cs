using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyTypeSO enemyType;

    private Transform target;
    private Vector3 moveDirection;
    private float moveSpeed;

    private void Awake()
    {
        enemyType = GetComponent<EnemyTypeHolder>().EnemyType;
        moveDirection = Vector3.zero;

        moveSpeed = enemyType.MoveSpeed;
    }

    private void Start()
    {
        target = GameManager.GetPlayer().transform;
    }

    private void Update()
    {
        HandleMovement();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Projectile>() || collision.collider.GetComponent<Weapon>())
        {
            Destroy(gameObject);
        }
    }

    private void HandleMovement()
    {
        moveDirection = Vector3.zero;

        if (target != null)
        {
            moveDirection = (target.transform.position - transform.position).normalized;
        }

        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}
