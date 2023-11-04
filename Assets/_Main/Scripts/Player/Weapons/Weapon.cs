using UnityEngine;

public class Weapon : MonoBehaviour
{
    private enum State
    {
        SEARCHING_FOR_ENEMIES,
        ROTATE_TO_ENEMY,
        ATTACKING_TO_ENEMY,
        ATTACKING_TO_HOME,
    }

    [SerializeField] private LayerMask enemyLayerMask;
    [SerializeField] private float rotationSpeed = 30f;
    [SerializeField] private float movementSpeed = 15f;
    [SerializeField] private float sightRange = 6f;
    [SerializeField] private float attackRange = 4.5f;
    [SerializeField] private float deltaMovement = 0.05f;
    [SerializeField] private float deltaRotationDegrees = 10f;

    private WeaponTypeSO weaponType;
    private Transform target;
    private State state;

    private void Awake()
    {
        weaponType = GetComponent<WeaponTypeHolder>().WeaponType;
        state = State.SEARCHING_FOR_ENEMIES;
    }

    private void Update()
    {
        switch (state)
        {
            case State.SEARCHING_FOR_ENEMIES:
                SearchForEnemies();
                break;
            case State.ROTATE_TO_ENEMY:
                SearchForEnemies();
                RotateToEnemy();
                break;
            case State.ATTACKING_TO_ENEMY:
                AttackEnemy();
                break;
            case State.ATTACKING_TO_HOME:
                GoHome();
                break;
        }
    }

    private void ChangeState(State newState)
    {
        switch (newState)
        {
            case State.SEARCHING_FOR_ENEMIES:
                break;
            case State.ROTATE_TO_ENEMY:
                break;
            case State.ATTACKING_TO_ENEMY:
                break;
            case State.ATTACKING_TO_HOME:
                break;
        }

        state = newState;
    }

    private void AttackEnemy()
    {
        if (target == null || HasArrived(transform.position, target.position))
        {
            ChangeState(State.ATTACKING_TO_HOME);
            return;
        }

        transform.position = Vector2.MoveTowards(transform.position, target.position, Time.deltaTime * movementSpeed);
    }

    private void GoHome()
    {
        if (HasArrived(transform.position, transform.parent.position))
        {
            ChangeState(State.SEARCHING_FOR_ENEMIES);
            return;
        }

        transform.position = Vector2.MoveTowards(transform.position, transform.parent.position, Time.deltaTime * movementSpeed);
    }

    private bool HasArrived(Vector2 actual, Vector2 expected) => Vector2.Distance(actual, expected) <= deltaMovement;

    private void RotateToEnemy()
    {
        if (target == null)
        {
            ChangeState(State.SEARCHING_FOR_ENEMIES);
            return;
        }

        Vector2 direction = (target.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (Quaternion.Angle(transform.rotation, targetRotation) <= deltaRotationDegrees && Vector2.Distance(transform.position, target.position) <= attackRange)
        {
            ChangeState(State.ATTACKING_TO_ENEMY);
            return;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }

    private void SearchForEnemies()
    {
        Collider2D[] collider2DArray = Physics2D.OverlapCircleAll(transform.position, sightRange, enemyLayerMask);
        if (collider2DArray.Length > 0)
        {
            target = FindNearestTarget(collider2DArray);

            if (target != null)
            {
                ChangeState(State.ROTATE_TO_ENEMY);
            }
        }
    }

    private Transform FindNearestTarget(Collider2D[] collider2DArray)
    {
        float minDistanceFromEnemy = float.MaxValue;
        Transform targetEnemyTransform = collider2DArray[0].transform;
        for (int i = 0; i < collider2DArray.Length; i++)
        {
            float testDistanceFromEnemy = Vector2.Distance(transform.position, collider2DArray[i].transform.position);
            if (testDistanceFromEnemy < minDistanceFromEnemy)
            {
                minDistanceFromEnemy = testDistanceFromEnemy;
                targetEnemyTransform = collider2DArray[i].transform;
            }
        }

        return targetEnemyTransform;
    }
}
