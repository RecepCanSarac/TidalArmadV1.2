using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Frenzy", menuName = "Skills/Frenzy")]
public class SOFrenzy : SOSkill
{
    private GameObject ship;


    private List<EnemyMoveController> enemyMoveController = new List<EnemyMoveController>();

    public SOBullet[] bullets;

    public float[] bulletsDamage;


    public float EnemyDamage;
    public override void Skill()
    {
        if (isActive == true)
        {
            ship = GameObject.FindGameObjectWithTag("Ship");

            ship.GetComponent<ShipController>().currentSpeed -= ship.GetComponent<ShipController>().currentSpeed;
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            foreach (GameObject enemyObject in enemies)
            {
                EnemyMoveController enemyMoveControllerComponent = enemyObject.GetComponent<EnemyMoveController>();

                if (enemyMoveControllerComponent != null)
                {
                    enemyMoveController.Add(enemyMoveControllerComponent);

                }
            }
            for (int i = 0; i < enemyMoveController.Count; i++)
            {
                enemyMoveController[i].enemy.Damage -= EnemyDamage;
            }

            for(int i = 0;i < bullets.Length; i++)
            {
                bullets[i].bulletDamage -= bulletsDamage[i];
            }
        }
        else
        {
            ship = GameObject.FindGameObjectWithTag("Ship");
            ship.GetComponent<ShipController>().currentSpeed += ship.GetComponent<ShipController>().ship.speed;
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            foreach (GameObject enemyObject in enemies)
            {
                EnemyMoveController enemyMoveControllerComponent = enemyObject.GetComponent<EnemyMoveController>();

                if (enemyMoveControllerComponent != null)
                {
                    enemyMoveController.Remove(enemyMoveControllerComponent);
                }
            }
            for (int i = 0; i < enemyMoveController.Count; i++)
            {
                enemyMoveController[i].enemy.Damage += EnemyDamage;
            }
            for (int i = 0; i < bullets.Length; i++)
            {
                bullets[i].bulletDamage += bulletsDamage[i];
            }
        }
    }
}
