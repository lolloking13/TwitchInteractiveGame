using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCharacterLifeSystem : MonoBehaviour
{
    public int lifeAmount = 100;

    [Header("UI Elements")]
    public Image lifeFillImage;

    public void ManageLife(int i) {
        lifeAmount += i;

        if (lifeAmount < 0) {

        }

        updateUIElements();
    }

    void updateUIElements() {
        lifeFillImage.fillAmount = (float)lifeAmount / 100;
    }
}
