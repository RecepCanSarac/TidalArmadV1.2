using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NotificationPanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI notiftText;

    public void SetText(string text)
    {
        notiftText.text = text;
    }
}