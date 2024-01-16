using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelPassManagment : MonoBehaviour
{
    #region Singleton
    public static LevelPassManagment instance;
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

    public ShipSpawnerManagment ship;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void mapGanerator()
    {
        SceneManager.LoadScene("MapGenerator");
        ShipSpawnerManagment.instance.isSpawn = false;
    }
}
