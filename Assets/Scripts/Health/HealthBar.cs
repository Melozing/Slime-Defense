using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private HealthPlayer playerHealthPlayer;
    [SerializeField] private Image currentHealthBar;
    [SerializeField] private float startingHealth;

    private void Update() {
        currentHealthBar.fillAmount = playerHealthPlayer.currentHealthPlayer / startingHealth;
    }
}
