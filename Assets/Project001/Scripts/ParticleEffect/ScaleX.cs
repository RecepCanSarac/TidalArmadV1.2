using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleX : MonoBehaviour
{
    private Transform gemTransform; // Gemiyi ba�lamak i�in
    private ParticleSystem particle;
    private float originalScaleX;

    void Start()
    {
        gemTransform = GameObject.FindGameObjectWithTag("Ship").transform;
        particle = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (gemTransform.localScale.x < 0)
        {

        }
    }
}
