using UnityEngine;

public class Player : MonoBehaviour
{
    public IPlayerInput PlayerInput { get; set; }

    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private Transform playerPrefab;

    private void Awake()
    {
        GameManager.SetPlayer(this);

        if (PlayerInput == null)
        {
            PlayerInput = new PlayerInput();
        }
    }

    private void Update()
    {
        HandleMovement();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }

    private void HandleMovement()
    {
        Vector3 direction = PlayerInput.MovementDirection;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}
