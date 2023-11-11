using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(fileName = "AgumentSystem", menuName = "System/AgumentSystem")]
public class SOAgumentSystem : ScriptableObject
{
    public List<AgumentList> Aguments = new List<AgumentList>();
}

[Serializable]
public class AgumentList
{
    public SOAgument agument;
    public bool available;
}
