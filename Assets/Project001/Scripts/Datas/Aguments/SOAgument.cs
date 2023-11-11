
using UnityEngine;

[CreateAssetMenu(fileName = "Agument",menuName = "Aguments/Agument")]
public class SOAgument : ScriptableObject
{
    public string AgumentTag;
    public int AgumentIndex;
    public Sprite agumentImage;
    public string agumentName;
    public string agumentDescreption;
    public GameObject Agument;
}
