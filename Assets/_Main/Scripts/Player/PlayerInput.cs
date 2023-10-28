using UnityEngine;

public class PlayerInput : IPlayerInput
{
    public Vector2 MovementDirection => InputManager.GetDirection();
}
