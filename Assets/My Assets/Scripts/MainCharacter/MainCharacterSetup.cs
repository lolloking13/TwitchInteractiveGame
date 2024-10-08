using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainCharacterSetup : MonoBehaviour
{
    public TextMeshPro entityUserName;

    private void Start() {
        SetupEntity(PlayerPrefs.GetString("UserChannelName"), new Color(1f,0,1f));
    }

    public void SetupEntity(string userName, Color userNameColor) {
        entityUserName.text = userName;
        entityUserName.color = userNameColor;
    }
}
