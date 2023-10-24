using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BulletDescriptionUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bulletNameText;
    [SerializeField] private TextMeshProUGUI bulletDescriptionText;
    [SerializeField] private TextMeshProUGUI buyButtonText;

    [SerializeField] private Button buyButton;

    public delegate void OnBuy(SOBullet bullet);
    public OnBuy onBuy;

    private SOBullet bullet;

    private void Start()
    {
        buyButton.onClick.AddListener(() => onBuy?.Invoke(bullet));
    }

    public void SetPanel(SOBullet bullet)
    {
        this.bullet = bullet;

        bulletNameText.text = bullet.bulletName;
        bulletDescriptionText.text = bullet.GetDescription();
        buyButtonText.text = "Buy " + bullet.bulletPrice;

        buyButton.interactable = bullet.IsBuyable();
    }

}