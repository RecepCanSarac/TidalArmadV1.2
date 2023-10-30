using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "AgumentSystem",menuName = "Agument/AgumentSystem")]
public class SOAgumentSystem : ScriptableObject
{
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;

    public List<AgumentList> Aguments = new List<AgumentList>();


    public void GetAgument(Image AgumentImage)
    {
        
    }

}

[Serializable]
public class AgumentList
{
    public SOAgument agument;
    public bool available;
}
