using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameBullet : MonoBehaviour
{
    private ParticleSystem system;
    public SOTowerLevel level;
    private Transform ship;
    void Start()
    {
        system = GetComponent<ParticleSystem>();
        ship = GameObject.FindGameObjectWithTag("Ship").transform;
    }
    void Update()
    {
        if (transform.position.x < ship.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (transform.position.x > ship.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
    }
}

