using UnityEngine;
public abstract class SOAgument : ScriptableObject
{
    public bool used = false;
    public bool isActive;
    public string AgumentTag;
    public int AgumentIndex;
    public Sprite agumentImage;
    public string agumentName;
    public string agumentDescreption;

    public abstract void AugmenFunc();

}

