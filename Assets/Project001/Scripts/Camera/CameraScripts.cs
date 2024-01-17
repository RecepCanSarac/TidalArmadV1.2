using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScripts : MonoBehaviour
{
    private Transform ship;

    public float speed;

    public float offsetY;
   
    private void Update()
    {
        ship = GameObject.FindGameObjectWithTag("Ship").transform;
        if (ship != null)
        {
            Vector3 hedefKonum = new Vector3(ship.position.x, ship.position.y + offsetY, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, hedefKonum, speed * Time.deltaTime);
        }
    }
}
