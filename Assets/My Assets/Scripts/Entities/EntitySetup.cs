using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EntitySetup : MonoBehaviour
{
    public TextMeshPro entityUserName;

    public void SetupEntity(string userName, Color userNameColor) {
        entityUserName.text = userName;
        entityUserName.color = userNameColor;
    }
}
