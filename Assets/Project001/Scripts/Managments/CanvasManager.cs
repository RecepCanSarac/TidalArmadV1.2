using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    #region Singleton
    public static CanvasManager instance;
    private void Awake() => instance = this;
    #endregion

    //Variables
    public TowerBuilderUI TowerBuilderUI => towerBuilderUI;
    [SerializeField] TowerBuilderUI towerBuilderUI;

    public TowerUpgraderUI TowerUpgraderUI => towerUpgraderUI;
    [SerializeField] TowerUpgraderUI towerUpgraderUI;

    [SerializeField] NotificationPanel notificationPanel;

    public void SetNotify(string text)
    {
        notificationPanel.gameObject.SetActive(true);
        notificationPanel.SetText(text);
    }


}