using UnityEngine;

public class WeaponRanged : Weapon
{
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Transform projectilePrefab;

    private bool haveShot;

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
            case State.WAIT:
                Waiting();
                break;
        }
    }

    protected override void ChangeState(State newState)
    {
        switch (newState)
        {
            case State.SEARCHING_FOR_ENEMIES:
                break;
            case State.ROTATE_TO_ENEMY:
                break;
            case State.ATTACKING_TO_ENEMY:
                break;
            case State.WAIT:
                ResetTimer();
                break;
        }

        state = newState;
    }

    protected override void AttackEnemy()
    {
        if (!haveShot)
        {
            haveShot = true;
            Instantiate(projectilePrefab, shootPoint.position, transform.rotation, transform.parent);
        }

        ChangeState(State.WAIT);
    }

    private void Waiting()
    {
        waitTimer -= Time.deltaTime;
        if (waitTimer <= 0f)
        {
            haveShot = false;
            ChangeState(State.SEARCHING_FOR_ENEMIES);
        }
    }
}
