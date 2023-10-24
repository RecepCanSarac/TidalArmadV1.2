using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BulletSlotUI : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image slotIcon;

    public event Action<int> OnClick;

    private SOBullet bullet;

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClick?.Invoke(transform.GetSiblingIndex());
    }

    public void Set(SOBullet bullet)
    {
        this.bullet = bullet;
        slotIcon.sprite = bullet.bulletIcon;
    }
}
