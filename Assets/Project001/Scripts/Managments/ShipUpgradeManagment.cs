using UnityEngine;
using UnityEngine.UI;

public class ShipUpgradeManagment : MonoBehaviour
{
    public SOShipSpawn shipSpawn;

    [SerializeField] Button upgradeBtn;
    int indexNum = 0;
    private void Start()
    {
        //upgradeNumber veriyi getirme
        indexNum = PlayerPrefs.GetInt(nameof(indexNum));
        upgradeBtn.onClick.AddListener(delegate { ShipUpgrade(); });
        GameObject ship = GameObject.FindGameObjectWithTag("Ship");
        Destroy(ship);
        shipSpawn.SpawnPrefab = shipSpawn.SpawnPrefab.GetComponent<ShipController>().upgradeble.shipUpgrade[indexNum].ShipPrefab;
    }
    private void Update()
    {
        Debug.Log(indexNum);
        //UpgradeNumber Kay�t Veri silme
        if (Input.GetKeyDown(KeyCode.L))
        {
            PlayerPrefs.DeleteKey(nameof(indexNum));
        }

        if (EconomyManager.instance.Gold < shipSpawn.SpawnPrefab.GetComponent<ShipController>().upgradeble.shipUpgrade[indexNum].price)
        {
            upgradeBtn.interactable = false;
        }
        else
        {
            upgradeBtn.interactable = true;
        }
    }

    public void ShipUpgrade()
    {
        if (EconomyManager.instance.Gold >= shipSpawn.SpawnPrefab.GetComponent<ShipController>().upgradeble.shipUpgrade[indexNum].price)
        {
          
            indexNum++;
            GameObject ship = GameObject.FindGameObjectWithTag("Ship");
            Destroy(ship);

            Instantiate(shipSpawn.SpawnPrefab.GetComponent<ShipController>().upgradeble.shipUpgrade[indexNum].ShipPrefab, new Vector2(0, -10), Quaternion.identity);
            shipSpawn.SpawnPrefab = shipSpawn.SpawnPrefab.GetComponent<ShipController>().upgradeble.shipUpgrade[indexNum].ShipPrefab;
            SaveLoadTower.instance.Load();
            EconomyManager.instance.DecreaseGold(shipSpawn.SpawnPrefab.GetComponent<ShipController>().upgradeble.shipUpgrade[indexNum].price);

            //upgradeNumber veriyi kaydetme
            PlayerPrefs.SetInt(nameof(indexNum), indexNum);
        }

    }
}