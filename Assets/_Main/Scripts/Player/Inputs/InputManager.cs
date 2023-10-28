using UnityEngine;

public static class InputManager
{
    private static PlayerInputActions playerInputActions;

    static InputManager()
    {
        playerInputActions = new PlayerInputActions();

        playerInputActions.Player.Enable();
    }

    public static Vector2 GetDirection() => playerInputActions.Player.Movement.ReadValue<Vector2>();
}
