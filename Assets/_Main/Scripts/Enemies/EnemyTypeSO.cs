using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/EnemyType")]
public class EnemyTypeSO : ScriptableObject
{
    public string NameString;
    public Transform EnemyPrefab;
    public float MoveSpeed;
}
