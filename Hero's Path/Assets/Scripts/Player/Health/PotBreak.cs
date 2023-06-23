using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotBreak : MonoBehaviour
{
     public GameObject heartPrefab; // Префаб сердечка

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(PlayerCombat.isAttacking);
        // Проверяем столкновение с атакой игрока
        if (collision.CompareTag("Player"))
        {
            // Разбиваем кувшин
            BreakPot();

            // Выпадение сердечка
            DropHeart();
            
        }
    }

    private void BreakPot()
    {
        Destroy(gameObject);
        
    }

    private void DropHeart()
    {
        // Создаем экземпляр сердечка из префаба
        GameObject heart = Instantiate(heartPrefab, transform.position, Quaternion.identity);

        // Добавляем силу вниз, чтобы сердечко выпало
        heart.transform.position += new Vector3(0f, -1f, 0f);
    }
}
