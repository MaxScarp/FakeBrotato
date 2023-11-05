public class WeaponRanged : Weapon
{
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
        }

        state = newState;
    }

    protected override void AttackEnemy()
    {

    }
}
