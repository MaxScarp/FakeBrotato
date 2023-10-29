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
