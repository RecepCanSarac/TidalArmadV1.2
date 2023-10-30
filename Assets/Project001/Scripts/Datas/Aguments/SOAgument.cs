using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Agument",menuName = "Aguments/Agument")]
public class SOAgument : ScriptableObject
{
    public int AgumentIndex;
    public Image agumentImage;
    public string agumentName;
    public string agumentDescreption;

    public GameObject Agument;
}
