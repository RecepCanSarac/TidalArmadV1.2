using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShipSelectManagment : MonoBehaviour
{
    [SerializeField] Button[] ShipImage;
    [SerializeField] TextMeshProUGUI shipNameTxt;
    [SerializeField] TextMeshProUGUI shipDescriptionTxt;
    [SerializeField] TextMeshProUGUI UpperSlotNumTxt;
    [SerializeField] TextMeshProUGUI SupportSlotNumTxt;
    [SerializeField] TextMeshProUGUI LowerSlotNumTxt;
    [SerializeField] Button Button;

    public ShipSelectData shipSelectData = new ShipSelectData();

    private int randomNum;

    private void Start()
    {
        Button.onClick.AddListener(NextScene);
        List<int> availableIndices = Enumerable.Range(0, shipSelectData.Contents.Count).ToList();

        for (int i = 0; i < ShipImage.Length; i++)
        {

            int randomIndex = UnityEngine.Random.Range(0, availableIndices.Count);
            int selectedIndex = availableIndices[randomIndex];


            int selectedNum = selectedIndex;
            availableIndices.RemoveAt(randomIndex);


            ShipImage[i].image.sprite = shipSelectData.Contents[selectedIndex].shipIcon;

            ShipImage[i].onClick.AddListener(delegate { Setup(selectedNum); });
        }
    }
    private void Setup(int index)
    {
        shipNameTxt.text = shipSelectData.Contents[index].Name;
        shipDescriptionTxt.text = shipSelectData.Contents[index].Description;
        UpperSlotNumTxt.text = shipSelectData.Contents[index].UpperSlotNum.ToString();
        SupportSlotNumTxt.text = shipSelectData.Contents[index].SupportSlotNum.ToString();
        LowerSlotNumTxt.text = shipSelectData.Contents[index].LowerSlotNum.ToString();
        ShipSpawnerManagment.instance.shipSpawn.SpawnPrefab = shipSelectData.Contents[index].shipPrefab.shipUpgrade[0].ShipPrefab;
    }

    private void NextScene()
    {
        SceneManager.LoadScene("MapGenerator");
    }
}
[Serializable]
public class ShipSelectData
{
    public List<ShipSelectContent> Contents = new();
}
[Serializable]
public class ShipSelectContent
{
    [Header("Base")]
    public string Name;
    public string Description;


    [Header("NumberValue")]
    public int UpperSlotNum;
    public int SupportSlotNum;
    public int LowerSlotNum;
    [Space]

    public Sprite shipIcon;

    public SOShipUpgradeble shipPrefab;
}