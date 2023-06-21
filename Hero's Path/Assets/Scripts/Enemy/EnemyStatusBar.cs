using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatusBar : MonoBehaviour
{
    public SpriteRenderer healthBarSprite; // Ссылка на компонент SpriteRenderer полоски здоровья
    public Transform enemyTransform; // Ссылка на трансформ врага
    public Vector2 offset; // Смещение позиции полоски здоровья относительно врага

    private float initialHealthBarWidth; // Начальная ширина полоски здоровья

    private void Start()
    {
        // Получаем начальную ширину полоски здоровья
        initialHealthBarWidth = healthBarSprite.size.x;
    }

    private void Update()
    {
        // Обновляем позицию и ширину полоски здоровья в зависимости от текущего здоровья врага
        if (enemyTransform != null)
        {
           Vector2 desiredPosition = enemyTransform.position;
            transform.position = new Vector3(desiredPosition.x, desiredPosition.y, transform.position.z);
            
            float healthPercentage = Mathf.Clamp01((float)enemyTransform.GetComponent<DeathController>().currentHealth / enemyTransform.GetComponent<DeathController>().maxHealth);
            healthBarSprite.size = new Vector2(initialHealthBarWidth * healthPercentage, healthBarSprite.size.y);
        }
    }
}
