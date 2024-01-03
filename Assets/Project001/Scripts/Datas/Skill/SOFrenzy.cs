using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Frenzy", menuName = "Skills/Frenzy")]
public class SOFrenzy : SOSkill
{
    private GameObject ship;
    private List<EnemyMoveController> enemyMoveControllers = new List<EnemyMoveController>();

    public SOBullet[] bullets;
    public float[] bulletsDamage;

    public float enemyDamage;

    public override void Skill()
    {
        ship = GameObject.FindGameObjectWithTag("Ship");

        if (isActive)
        {
            ApplyFrenzyEffects();
        }
        else
        {
            RemoveFrenzyEffects();
        }
    }

    private void ApplyFrenzyEffects()
    {
        ship.GetComponent<ShipController>().currentSpeed = 0f;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemyObject in enemies)
        {
            EnemyMoveController enemyMoveControllerComponent = enemyObject.GetComponent<EnemyMoveController>();
            if (enemyMoveControllerComponent != null && !enemyMoveControllers.Contains(enemyMoveControllerComponent))
            {
                enemyMoveControllers.Add(enemyMoveControllerComponent);
                if (enemyMoveControllerComponent.enemy != null)
                {
                    enemyMoveControllerComponent.enemy.Damage -= enemyDamage;
                }
            }
        }

        for (int i = 0; i < bullets.Length; i++)
        {
            bullets[i].bulletDamage -= bulletsDamage[i];
        }
    }

    private void RemoveFrenzyEffects()
    {
        ship.GetComponent<ShipController>().currentSpeed = ship.GetComponent<ShipController>().ship.speed;

        foreach (EnemyMoveController enemyMoveControllerComponent in enemyMoveControllers)
        {
            if (enemyMoveControllerComponent.enemy != null)
            {
                enemyMoveControllerComponent.enemy.Damage += enemyDamage;
            }
        }
        enemyMoveControllers.Clear();

        for (int i = 0; i < bullets.Length; i++)
        {
            bullets[i].bulletDamage += bulletsDamage[i];
        }
    }
}
