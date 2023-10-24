using System.Collections.Generic;
using UnityEngine;

public class BulletUpgradeUI : MonoBehaviour
{
    private BulletManager bulletManager;

    [SerializeField] private Transform content;

    [SerializeField] List<BulletSlotUI> bulletSlots = new List<BulletSlotUI>();


    [Header("Desc Panel")]
    [SerializeField] private BulletDescriptionUI descPanel;

    private BulletSlotUI selectedSlot;
    private TowerSlotObject currentSlot;

    private void Start()
    {
        bulletManager = BulletManager.instance;

        for (int i = 0; i < bulletSlots.Count; i++)
        {
            int index = i;

            bulletSlots[i].OnClick += (slot) => SelectSlot(index);
        }

        SelectSlot(0);
    }

    private void SelectSlot(int index)
    {
        if (selectedSlot is not null)
        {

            descPanel.onBuy = null;
        }

        selectedSlot = bulletSlots[index];
        descPanel.onBuy += (bullet) => BuyBullet(bullet, index);

        descPanel.SetPanel(bulletManager.GetBulletData(index));
    }

    private void BuyBullet(SOBullet bullet, int index)
    {
        currentSlot.BuyBullet(bullet, index);
        content.gameObject.SetActive(false);
    }

    public void SetupPanel(TowerSlotObject currentSlot)
    {
        CloseSlot();

        this.currentSlot = currentSlot;

        for (int i = 0; i < bulletManager.GetBulletCount(); i++)
        {
            int index = i;

            bulletSlots[i].gameObject.SetActive(true);
            bulletSlots[i].Set(bulletManager.GetBulletData(index));
        }
        SelectSlot(0);

        content.gameObject.SetActive(true);
    }

    private void CloseSlot()
    {
        foreach (BulletSlotUI slot in bulletSlots)
        {
            slot.gameObject.SetActive(false);
        }
    }
}
