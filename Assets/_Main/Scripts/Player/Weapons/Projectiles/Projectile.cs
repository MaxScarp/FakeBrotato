using UnityEngine;

public enum ProjectileType
{
    WATER
}

public class Projectile : MonoBehaviour
{
    private const string BACKGROUND = "Background";

    [SerializeField] private Transform visualPrefab;

    private ProjectileTypeSO projectileType;

    private void Awake()
    {
        projectileType = GetComponent<ProjectileTypeHolder>().ProjectileType;
        visualPrefab.GetComponent<SpriteRenderer>().sprite = projectileType.Sprite;
    }

    private void Update()
    {
        transform.position += transform.right * projectileType.Speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(BACKGROUND) || collision.GetComponent<Enemy>())
        {
            Destroy(gameObject);
        }
    }
}
