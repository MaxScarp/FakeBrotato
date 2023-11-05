using UnityEngine;

public class WeaponMelee : Weapon
{
    [SerializeField] private float movementSpeed = 15f;
    [SerializeField] private float deltaMovement = 0.05f;

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
            case State.ATTACKING_TO_HOME:
                break;
        }

        state = newState;
    }

    protected override void AttackEnemy()
    {
        if (target == null || HasArrived(transform.position, target.position))
        {
            ChangeState(State.ATTACKING_TO_HOME);
            return;
        }

        transform.position = Vector2.MoveTowards(transform.position, target.position, Time.deltaTime * movementSpeed);
    }

    private bool HasArrived(Vector2 actual, Vector2 expected) => Vector2.Distance(actual, expected) <= deltaMovement;

    private void GoHome()
    {
        if (HasArrived(transform.position, transform.parent.position))
        {
            ChangeState(State.SEARCHING_FOR_ENEMIES);
            return;
        }

        transform.position = Vector2.MoveTowards(transform.position, transform.parent.position, Time.deltaTime * movementSpeed);
    }
}
