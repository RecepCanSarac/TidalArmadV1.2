using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipSpawnerManagment : MonoBehaviour
{
    #region Singleton
    public static ShipSpawnerManagment instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion
    public SOShipSpawn shipSpawn;
    public bool isSpawn;

    private void Start()
    {
        isSpawn = false;
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex >= 3 && !isSpawn)
        {
            Instantiate(shipSpawn.SpawnPrefab, shipSpawn.spawnPos, Quaternion.identity);
            isSpawn = true;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene("Game01");
            isSpawn = false;
        }
    }
}