using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelController : MonoBehaviour
{
    private TowerObject tower;

    public GameObject barrel;
    public Transform point;
    public LayerMask mask;

    private float nextTimeFireRate;

    private void Start()
    {
        tower = GetComponent<TowerObject>();
    }

    private void FixedUpdate()
    {
        Collider2D[] col = Physics2D.OverlapCircleAll(transform.position, tower.tower.detectRange, mask);

        if (col.Length > 0)
        {
            shoot();
        }
        else
        {
            col = null;
        }
    }

    private void shoot()
    {
        nextTimeFireRate += Time.deltaTime;
        if (nextTimeFireRate > tower.tower.attackSpeed / 1)
        {
            GameObject bar = Instantiate(barrel, point.position,Quaternion.identity);
            bar.GetComponent<Rigidbody2D>().velocity = transform.right * 100 * Time.deltaTime;
            nextTimeFireRate = 0;
        }
    }
}
