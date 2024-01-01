using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public enum BulletCapacityType { Infinity, Limited }

[CreateAssetMenu(fileName = "New Bullet", menuName = "Data/Bullet")]
public class SOBullet : ScriptableObject
{
    public string bulletID;

    public string bulletName;
    public string bulletDescription;
    public Sprite bulletIcon;
    public int bulletPrice;

    public BulletCapacityType capacityType;
    public int bulletCapacity;

    public float bulletDamage;
    public float bulletSpeed;
    public float bulletSlowEnemy;

    public GameObject bulletPrefab;

    private StringBuilder descriptionBuild = new();
    public string GetDescription()
    {
        descriptionBuild.Length = 0;

        descriptionBuild.Append(bulletDescription);

        if (capacityType == BulletCapacityType.Infinity)
        {
            descriptionBuild.Append("Capacity: Infinity.");
        }
        else
        {
            descriptionBuild.Append("Capacity:" + bulletCapacity);
        }

        return descriptionBuild.ToString();
    }

    public bool IsBuyable()
    {
        return bulletPrice <= EconomyManager.instance.Gold;
    }

    public void Added() => EconomyManager.instance.DecreaseGold(bulletPrice);
}