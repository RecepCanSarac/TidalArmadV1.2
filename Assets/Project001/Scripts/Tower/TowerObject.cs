using System;
using System.Reflection;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TowerObject : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Transform bulletSpawnPoint;
    [SerializeField] TextMeshPro bulletText;

    public SOTowerLevel TowerData { get; set; }

    public SOTowerLevel tower;
    SOBullet bulletData;
    private int bulletIndex;
    private int bulletCount;

    public string Name;

    private Transform Ship;

    public event Action<TowerObject> OnLeftClickEvent;
    public event Action<TowerObject> OnBulletIsEnd;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (SceneManager.GetActiveScene().name == "StoreScene")
            {
                OnLeftClickEvent?.Invoke(this);
            }
        }
    }
    private void Start()
    {
        Ship = GameObject.FindGameObjectWithTag("Ship").transform;
        if (transform.position.x > Ship.transform.position.x)
        {
           transform.localScale = new Vector3(2, 2, 2);
        }
        else
        {
           transform.localScale = new Vector3(-2, 2, 2);
        }
    }
    public int GetBulletIndex() => bulletIndex;
    public int GetBulletCount() => bulletCount;

    private string BuildBulletText()
    {
        StringBuilder sb = new StringBuilder();

        sb.Length = 0;

        if (bulletData is not null)
        {
            switch (bulletData.capacityType)
            {
                case BulletCapacityType.Infinity:
                    sb.Append("Inf.");

                    break;
                case BulletCapacityType.Limited:
                    sb.Append(bulletCount);

                    break;
            }
        }

        return sb.ToString();
    }

    public void LoadBullet(SOBullet bullet, int index, int count)
    {
        bulletData = bullet;
        bulletIndex = index;
        bulletCount = count;
        if (bulletText != null)
        {
            bulletText.text = BuildBulletText();    
        }
        
    }

    public void OnChangeTower(SOBullet bullet, int index, int count)
    {
        ChangeBullet(bullet, index, count);
    }
    public void ChangeBullet(SOBullet bullet, int index, int count)
    {
        bulletData = bullet;
        bulletIndex = index;
        bulletCount = count;

        bulletText.text = BuildBulletText();
    }

    public void OnBuyBullet(SOBullet bullet, int index)
    {
        bulletData = bullet;
        bulletIndex = index;

        if (bullet.capacityType is BulletCapacityType.Infinity)
        {
            bulletCount = 0;
        }
        else
        {
            bulletCount += bullet.bulletCapacity;
        }

        bullet.Added();
        if (bulletText != null)
        {
            bulletText.text = BuildBulletText();
        }
      
        //Add 
    }

    public bool Attackable()
    {
        if (bulletData.capacityType is BulletCapacityType.Infinity)
            return true;
        else
        {
            if (bulletCount > 0)
            {
                return true;
            }
            return false;
        }
    }

    public void SpawnBullet(Vector3 targetPoint, float scaleFactor)
    {
        if (!Attackable()) return;

        BulletObject bullet = BulletManager.instance.GetBulletFromPool(bulletIndex, bulletSpawnPoint.position)?.GetComponent<BulletObject>();

        if (bulletData is null)
        {
            bullet.gameObject.SetActive(false);
            return;
        }

        if (bulletData.capacityType is BulletCapacityType.Limited)
        {
            bulletCount--;
        }

        bulletText.text = BuildBulletText();

        if (bulletData.capacityType is BulletCapacityType.Limited && bulletCount <= 0)
        {
            OnBulletIsEnd?.Invoke(this);
        }

        bullet.Set(targetPoint, scaleFactor);
    }
}