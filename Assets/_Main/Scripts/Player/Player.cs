using UnityEngine;

public class Player : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public IPlayerInput PlayerInput { get; set; }

    private void Awake()
    {
        if (PlayerInput == null)
        {
            PlayerInput = new PlayerInput();
        }
    }

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector3 direction = PlayerInput.MovementDirection;
        transform.position += direction * MoveSpeed * Time.deltaTime;
    }
}
