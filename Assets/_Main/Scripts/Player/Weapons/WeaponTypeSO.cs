using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Weapon")]
public class WeaponTypeSO : ScriptableObject
{
    public string StringName;
    public Sprite Sprite;
    public WeaponType WeaponType;
    public LayerMask EnemyLayerMask;
    public float SightRange = 6f;
    public float AttackRange = 4.5f;
    public float RotationSpeed = 30f;
    public float DeltaRotationDegrees = 10f;
    public float WaitTimerMax = 1f;
    public Transform WeaponPrefab;
}
