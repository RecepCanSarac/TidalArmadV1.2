using UnityEngine;
using UnityEngine.UI;

public class TowerUpgraderUI : MonoBehaviour
{
    [SerializeField] Button towerUpgradePanelButton;
    [SerializeField] Button bulletUpgradePanelButton;
    [SerializeField] GameObject bulletUpgradePanelObje;

    [SerializeField] private UpgradePanelUI upgradePanelUI;
    [SerializeField] private BulletUpgradeUI bulletUpgradeUI;

    private TowerSlotObject currentSlot;


    bool isActive = false;

    private void Start()
    {
        towerUpgradePanelButton.onClick.AddListener(delegate { ClickTowerUpgradeButton(); });
        bulletUpgradePanelButton.onClick.AddListener(delegate { ClickBulletPanel(); });
    }

    public void Setup(TowerSlotObject currentSlot)
    {
        transform.position = Camera.main.WorldToScreenPoint(currentSlot.transform.position);

        towerUpgradePanelButton.interactable = !currentSlot.TowerUpgradeCompleted();

        if (this.currentSlot != null && this.currentSlot != currentSlot)
        {
            isActive = true;
        }
        else
        {
            isActive = !isActive;
        }

        this.currentSlot = currentSlot;

        if (isActive)
        {
            foreach (var slot in currentSlot.buildableTowerList)
            {
                Show();
                if (slot.type == TowerType.CanBuyBUllet)
                {
                    bulletUpgradePanelButton.interactable = true;
                    bulletUpgradePanelObje.SetActive(true);
                }
                else
                {
                    bulletUpgradePanelButton.interactable = false;
                    bulletUpgradePanelObje.SetActive(false);
                }
            }
            if (!currentSlot.TowerUpgradeCompleted())
                upgradePanelUI.SetupPanel(this.currentSlot);
        }
        else
        {
            Hide();
        }
    }

    void ClickTowerUpgradeButton()
    {
        isActive = false;
        upgradePanelUI.Show();
        Hide();
    }
    void ClickBulletPanel()
    {
        bulletUpgradeUI.SetupPanel(this.currentSlot);
        isActive = false;
        Hide();
    }

    public void Show() => gameObject.SetActive(true);
    public void Hide() => gameObject.SetActive(false);
}