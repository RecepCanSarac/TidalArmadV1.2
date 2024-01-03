using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ForceWithin", menuName = "Skills/ForceWithin")]
public class SOForceWithin : SOSkill
{
    public float enemySpeed = 5f;
    public float distanceToKeep = 5f;  // Gemiden uzakta tutmak istedi�iniz mesafe

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

        // Ekrandaki t�m d��manlar� bul
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemyObject in enemies)
        {
            Rigidbody2D enemyRigidbody2D = enemyObject.GetComponent<Rigidbody2D>();

            if (enemyRigidbody2D != null)
            {
                // D��man�n bulundu�u konum
                Vector2 enemyPosition = enemyObject.transform.position;

                // D��man�n gemiye olan yatay uzakl���
                float distanceToShipX = Mathf.Abs(enemyPosition.x - shipPosition.x);

                // D��man� gemiden belirli bir mesafede tutmak i�in yeni pozisyon
                Vector2 targetPosition = enemyPosition;

                // Gemi sa� taraftaysa d��man� sola do�ru f�rlat
                if (enemyPosition.x < shipPosition.x)
                {
                    targetPosition.x -= distanceToKeep;
                }
                // Gemi sol taraftaysa d��man� sa�a do�ru f�rlat
                else
                {
                    targetPosition.x += distanceToKeep;
                }

                // D��man� yeni pozisyona hareket ettir
                enemyRigidbody2D.MovePosition(Vector2.MoveTowards(enemyPosition, targetPosition, enemySpeed * Time.deltaTime));
            }
        }

        // T�m d��manlar f�rlat�ld�ktan sonra listeyi temizle
        ClearEnemyList();
    }

    private void ClearEnemyList()
    {
        // E�er gerekiyorsa d��manlar� i�eren listeyi temizle
        // �rnek: allEnemies.Clear();
    }
}   
