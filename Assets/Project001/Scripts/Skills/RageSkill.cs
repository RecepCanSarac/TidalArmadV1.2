using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RageSkill : MonoBehaviour, ISelectedSkill
{
    public List<SOTowerLevel> towers = new List<SOTowerLevel>();
    public float Timer;
    private GameObject[] towerObjects;
    public float speed;
    private List<float> currentSpeed = new List<float>();

    private int number = 0;
    bool active = false;
    private void Start()
    {
        number = 0;
    }
    private void Update()
    {
        if (active == true)
        {
            StartCoroutine(timer());
        }
    }
    public void ActivitedSkill()
    {
        towerObjects = GameObject.FindGameObjectsWithTag("Tower");

        foreach (var towerObject in towerObjects)
        {
            TowerObject towerComponent = towerObject.GetComponent<TowerObject>();

            if (towerComponent != null)
            {
                towers.Add(towerComponent.tower);
            }
        }
        for (int i = 0; i < towerObjects.Length; i++)
        {
            currentSpeed.Add(towerObjects[i].GetComponent<TowerObject>().tower.attackSpeed);
        }
        active = true;
        Debug.Log(active);
    }


    IEnumerator timer()
    {
        if (number == 0)
        {
            for (int i = 0; i < currentSpeed.Count; i++)
            {
                towers[i].attackSpeed -= speed;
            }
            number++;
        }
        yield return new WaitForSeconds(Timer);

        for (int i = 0; i < currentSpeed.Count; i++)
        {
            towers[i].attackSpeed = currentSpeed[i];
            towers.Clear();
            currentSpeed.Clear();
            Array.Clear(towerObjects, 0, towerObjects.Length);

        }
        active = false;
        Debug.Log(active);
    }
}

