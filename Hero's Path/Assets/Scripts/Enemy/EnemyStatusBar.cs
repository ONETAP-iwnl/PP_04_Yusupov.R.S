using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;

public class EnemyStatusBar : MonoBehaviour
{
    public Image Health; // Ссылка на компонент SpriteRenderer полоски здоровья
    public EnemyController enemyController; // Ссылка на скрипт управления игроком


    private void Start()
    {
        
    }

    private void Update()
    {
        // Обновляем ширину полоски здоровья в зависимости от текущего здоровья игрока
        if (enemyController != null)
        {
            float healthPercentage = Mathf.Clamp01((float)enemyController.currentHealth / enemyController.maxHealth);
            Health.fillAmount = healthPercentage % 100;
        }
    }
}
