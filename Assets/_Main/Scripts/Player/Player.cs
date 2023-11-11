using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public IPlayerInput PlayerInput { get; set; }

    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private Transform playerPrefab;
    [SerializeField] private Transform[] weaponPositionArray;
    [SerializeField] private WeaponTypeSO weaponType;

    private Dictionary<Transform, WeaponTypeSO> positionWeaponTypeDictionary;

    private void Awake()
    {
        GameManager.SetPlayer(this);

        if (PlayerInput == null)
        {
            PlayerInput = new PlayerInput();
        }

        positionWeaponTypeDictionary = new Dictionary<Transform, WeaponTypeSO>();
        foreach (Transform weaponPosition in weaponPositionArray)
        {
            positionWeaponTypeDictionary.Add(weaponPosition, null);
        }
    }

    private void Start()
    {
        for (int i = 0; i < positionWeaponTypeDictionary.Count; i++)
        {
            Instantiate(weaponType.WeaponPrefab, weaponPositionArray[i].position, Quaternion.identity, weaponPositionArray[i]);
            positionWeaponTypeDictionary[weaponPositionArray[i]] = weaponType;
        }
    }

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector3 direction = PlayerInput.MovementDirection;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}
