using System;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    #region Singleton
    public static BulletManager instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion


    [SerializeField] private List<BulletPool> bulletPools = new List<BulletPool>();

    public Dictionary<int, Queue<GameObject>> bulletDictionary = new Dictionary<int, Queue<GameObject>>();

    private void Start()
    {
        for (int i = 0; i < bulletPools.Count; i++)
        {
            Queue<GameObject> bulletQueue = new Queue<GameObject>();

            for (int count = 0; count < bulletPools[i].count; count++)
            {
                GameObject bullet = Instantiate(bulletPools[i].bulletData.bulletPrefab, Vector3.zero, Quaternion.identity, transform);
                bullet.SetActive(false);

                bulletQueue.Enqueue(bullet);
            }
            bulletDictionary.Add(i, bulletQueue);
        }
    }

    public int GetBulletCount() => bulletPools.Count;
    public SOBullet GetBulletData(int index) => bulletPools[index].bulletData;

    public GameObject GetBulletFromPool(int index, Vector3 position)
    {
        if (!bulletDictionary.ContainsKey(index))
        {
            Debug.Log("Index not found in pool");
            return null;
        }

        if (index > bulletPools.Count - 1)
        {
            Debug.Log("Index out");
            return null;
        }

        Queue<GameObject> queue = bulletDictionary[index];

        if (queue.Count > 0)
        {
            GameObject bullet = queue.Dequeue();
            bullet.SetActive(true);
            bullet.transform.position = position;


            queue.Enqueue(bullet);
            return bullet;
        }

        Debug.Log("Pool Empty");
        return null;

    }

}

[Serializable]
public class BulletPool
{
    public SOBullet bulletData;
    public int count;
}
