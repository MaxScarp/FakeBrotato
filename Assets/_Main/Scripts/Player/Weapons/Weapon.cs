using UnityEngine;

public enum WeaponType
{
    MELEE,
    RANGED
}

public abstract class Weapon : MonoBehaviour
{
    protected enum State
    {
        SEARCHING_FOR_ENEMIES,
        ROTATE_TO_ENEMY,
        ATTACKING_TO_ENEMY,
        ATTACKING_TO_HOME,
    }

    [SerializeField] protected Transform visualPrefab;

    protected WeaponTypeSO weaponType;
    protected Transform target;
    protected State state;

    private void Awake()
    {
        weaponType = GetComponent<WeaponTypeHolder>().WeaponType;
        visualPrefab.GetComponent<SpriteRenderer>().sprite = weaponType.Sprite;
        state = State.SEARCHING_FOR_ENEMIES;
    }

    protected abstract void ChangeState(State newState);

    protected abstract void AttackEnemy();

    protected virtual void RotateToEnemy()
    {
        if (target == null)
        {
            ChangeState(State.SEARCHING_FOR_ENEMIES);
            return;
        }

        Vector2 direction = (target.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (Quaternion.Angle(transform.rotation, targetRotation) <= weaponType.DeltaRotationDegrees && Vector2.Distance(transform.position, target.position) <= weaponType.AttackRange)
        {
            ChangeState(State.ATTACKING_TO_ENEMY);
            return;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * weaponType.RotationSpeed);
    }

    protected virtual void SearchForEnemies()
    {
        Collider2D[] collider2DArray = Physics2D.OverlapCircleAll(transform.position, weaponType.SightRange, weaponType.EnemyLayerMask);
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
