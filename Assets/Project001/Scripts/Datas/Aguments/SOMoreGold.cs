using UnityEngine;

[CreateAssetMenu(fileName = "MoreGold", menuName = "Aguments/MoreGold")]
public class SOMoreGold : SOAgument
{
    public int Gold;
    public SOEnemy[] enemies;

    public override void AugmenFunc()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].Gold += Gold;
        }
    }
}
