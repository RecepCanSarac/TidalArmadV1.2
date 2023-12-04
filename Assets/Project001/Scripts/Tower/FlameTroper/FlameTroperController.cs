using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FlameTroperController : MonoBehaviour
{
    private TowerObject tower;
    public Transform point;

    public Transform attackPoint;

    Transform nearestEnemy = null;
    public LayerMask mask;

    public GameObject effect;

    float attackRate = 0;
    bool attacking;
    private void Start()
    {
        tower = GetComponent<TowerObject>();
        attackRate = tower.tower.attackSpeed;
    }

    private void Update()
    {
        if (attacking && nearestEnemy != null)
        {
            Attack();
        }
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, tower.tower.detectRange, mask);

        if (enemies.Length > 0)
        {
            Transform newNearestEnemy = enemies.OrderBy((x) => Vector2.Distance(transform.position, x.transform.position)).FirstOrDefault().transform;

            if (newNearestEnemy != nearestEnemy)
            {
                nearestEnemy = newNearestEnemy;
                attacking = true;
            }
        }
        else
        {
            attacking = false;
            nearestEnemy = null;
        }

    }
    void Attack()
    {
        attackRate += Time.deltaTime;
        if (nearestEnemy != null)
        {
            if (attackRate > tower.TowerData.attackSpeed / 1)
            {
                Debug.Log(this.gameObject.name);

                effect.GetComponent<ParticleSystem>().Play();
                attackRate = 0;
            }
            
        }

    }

}
