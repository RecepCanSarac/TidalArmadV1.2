using System.Collections.Generic;
using UnityEngine;

public class AgumentUIManager : MonoBehaviour
{
    public SOAgumentSystem AgumentSystem;
    public AgumentUI[] agumentUI;

    private void Start()
    {
        SetRandomAgument();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SetRandomAgument();
        }
    }

    public void SetRandomAgument()
    {
        if (AgumentSystem.Aguments.Count == 0)
        {
            Debug.LogWarning("Agument listesi boþ!");
            return;
        }

        List<int> availableIndices = new List<int>();
        for (int i = 0; i < AgumentSystem.Aguments.Count; i++)
        {
            if (AgumentSystem.Aguments[i].available)
            {
                availableIndices.Add(i);
            }
        }

        if (availableIndices.Count == 0)
        {
            Debug.LogWarning("Kullanýlabilir argüman bulunamadý!");
            return;
        }

        for (int i = 0; i < agumentUI.Length; i++)
        {
            int randomIndex = availableIndices[Random.Range(0, availableIndices.Count)];

            agumentUI[i].Setup(AgumentSystem.Aguments[randomIndex].agument);

            //AgumentSystem.Aguments[randomIndex].available = false;

            availableIndices.Remove(randomIndex);
        }
    }
}
