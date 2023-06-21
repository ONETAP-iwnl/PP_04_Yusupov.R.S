using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusBar : MonoBehaviour
{
    public Image Health; // Ссылка на компонент SpriteRenderer полоски здоровья
    public PlayerCombat playerController; // Ссылка на скрипт управления игроком


    private void Start()
    {
        
    }

    private void Update()
    {
        // Обновляем ширину полоски здоровья в зависимости от текущего здоровья игрока
        if (playerController != null)
        {
            float healthPercentage = Mathf.Clamp01((float)playerController.currentHealth / playerController.maxHealth);
            Health.fillAmount = healthPercentage % 100;
        }
    }
}
