using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScrenManagment : MonoBehaviour
{
    [SerializeField] private Button StartBTN;
    [SerializeField] private Button ContinueBTN;
    [SerializeField] private Button QuitBTN;


    private void Start()
    {
        StartBTN.onClick.AddListener(StartGame);
        QuitBTN.onClick.AddListener(QuidGame);
        ContinueBTN.onClick.AddListener(ContinueGame);
    }
    public void StartGame()
    {
        SceneManager.LoadScene("ShipSelectedScene");
    }

    public void ContinueGame()
    {
        //Not Yet
    }
    public void QuidGame()
    {
        Application.Quit();
    }
}
