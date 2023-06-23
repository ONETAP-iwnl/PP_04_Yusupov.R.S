using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healthAmount = 20; // Количество восстанавливаемого здоровья

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Проверяем столкновение с игроком
        if (collision.CompareTag("Player"))
        {
            // Получаем компонент PlayerHealth у игрока
            PlayerCombat playerHealth = collision.GetComponent<PlayerCombat>();

            if (playerHealth != null)
            {
                // Восстанавливаем здоровье игрока
                playerHealth.Heal(healthAmount);

                // Уничтожаем сердечко
                Destroy(gameObject);
            }
        }
    }
}
