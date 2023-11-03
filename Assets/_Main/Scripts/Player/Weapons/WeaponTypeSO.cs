using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Weapon")]
public class WeaponTypeSO : ScriptableObject
{
    public string stringName;
    public Sprite sprite;
    public Transform WeaponPrefab;
}
