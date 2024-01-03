using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ForceWithin", menuName = "Skills/ForceWithin")]
public class SOForceWithin : SOSkill
{
    public float enemySpeed = 5f;
    public float distanceToKeep = 5f;  // Gemiden uzakta tutmak istediðiniz mesafe

    public override void Skill()
    {
        if (isActive)
        {
            ApplyFrenzyEffects();
        }
        else
        {
            ClearEnemyList();
        }
    }

    private void ApplyFrenzyEffects()
    {
        // Geminin konumu
        Vector3 shipPosition = GameObject.FindGameObjectWithTag("Ship").transform.position;

        // Ekrandaki tüm düþmanlarý bul
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemyObject in enemies)
        {
            Rigidbody2D enemyRigidbody2D = enemyObject.GetComponent<Rigidbody2D>();

            if (enemyRigidbody2D != null)
            {
                // Düþmanýn bulunduðu konum
                Vector2 enemyPosition = enemyObject.transform.position;

                // Düþmanýn gemiye olan yatay uzaklýðý
                float distanceToShipX = Mathf.Abs(enemyPosition.x - shipPosition.x);

                // Düþmaný gemiden belirli bir mesafede tutmak için yeni pozisyon
                Vector2 targetPosition = enemyPosition;

                // Gemi sað taraftaysa düþmaný sola doðru fýrlat
                if (enemyPosition.x < shipPosition.x)
                {
                    targetPosition.x -= distanceToKeep;
                }
                // Gemi sol taraftaysa düþmaný saða doðru fýrlat
                else
                {
                    targetPosition.x += distanceToKeep;
                }

                // Düþmaný yeni pozisyona hareket ettir
                enemyRigidbody2D.MovePosition(Vector2.MoveTowards(enemyPosition, targetPosition, enemySpeed * Time.deltaTime));
            }
        }

        // Tüm düþmanlar fýrlatýldýktan sonra listeyi temizle
        ClearEnemyList();
    }

    private void ClearEnemyList()
    {
        // Eðer gerekiyorsa düþmanlarý içeren listeyi temizle
        // Örnek: allEnemies.Clear();
    }
}   
