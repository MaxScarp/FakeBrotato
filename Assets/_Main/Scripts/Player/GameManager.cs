using UnityEngine;

public static class GameManager
{
    public static int EnemyTotalAmount { get; set; }

    private static Player player;

    public static Player GetPlayer() => player;

    public static void SetPlayer(Player _player)
    {
        player = _player;

        EnemyTotalAmount = 0;
    }

    public static void TestInit()
    {
        player = new GameObject().AddComponent<Player>();
    }
}
