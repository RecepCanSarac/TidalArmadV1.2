using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.iOS;

public class BottomTower : MonoBehaviour
{
    public float distance;

    public LayerMask layerMask;
    private TowerObject obj;
    public Transform hitPoint;
    private float attackRate = 0;
    public GameObject supportBullet;
    public Transform point;

    public Transform towerHead;

    private Transform nearestEnemy;
    private void Start()
    {
        obj = GetComponent<TowerObject>();
        attackRate = obj.TowerData.attackSpeed;
    }
    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(hitPoint.position, hitPoint.right, distance, layerMask);

        if (hit.collider != null)
        {
            if (hit == true)
            {
                nearestEnemy = hit.collider.gameObject.transform;
                if (nearestEnemy != null)
                {
                    Attack();
                }
                else
                {
                    Debug.Log("Boþþþþþþ");
                }
                Debug.DrawLine(hitPoint.position, hit.point, Color.green);
            }
        }
        else
        {
            nearestEnemy = null;
            Debug.DrawLine(hitPoint.position, hit.point, Color.red);
        }
    }

    private void Attack()
    {
        attackRate += Time.deltaTime;

        if (attackRate > obj.TowerData.attackSpeed / 1)
        {
            if (nearestEnemy != null)
            {
                if (supportBullet != null)
                {
                    GameObject bullet = Instantiate(supportBullet, transform.position, Quaternion.identity);

                    SupportBullet bulletMovement = bullet.GetComponent<SupportBullet>();
                    if (bulletMovement != null)
                    {
                        bulletMovement.SetTarget(nearestEnemy);
                    }
                }
                else
                {
                    obj.SpawnBullet(nearestEnemy.position, towerHead.localScale.x);
                }

                attackRate = 0;
            }
        }
    }
}
