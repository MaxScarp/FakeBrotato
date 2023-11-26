using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Projectile")]
public class ProjectileTypeSO : ScriptableObject
{
    public string StringName;
    public Sprite Sprite;
    public ProjectileType ProjectileType;
    public float Speed;
}
