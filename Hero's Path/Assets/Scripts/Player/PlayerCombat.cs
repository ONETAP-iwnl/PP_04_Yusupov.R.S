using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField]
    GameObject DiedCanvas;
    public Animator animator;
    private PauseMenu pause;
    public int maxHealth = 100; // Максимальное количество хитпоинтов игрока
    public int damage; // Урон, который наносит игрок

    public static bool isAttacking; // Флаг атаки
    public int currentHealth; // Текущее количество хитпоинтов игрока
    private int damageTaken; // Количество полученного урона
    private int damageDealt; // Количество нанесенного урона
    private float attackRange = 3f;


    // Update is called once per frame
    void Update() {

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }

    }

    public void Attack()
    {
        isAttacking = true;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, attackRange); // Получаем все коллайдеры в заданном радиусе атаки

        foreach (Collider2D collider in colliders)
        {
            EnemyController enemy = collider.GetComponent<EnemyController>(); // Получаем компонент EnemyController на объекте врага
            

            if (enemy != null)
            {
                enemy.TakeDamage(damage); // Наносим урон врагу
                damageDealt += damage; // Увеличиваем количество нанесенного урона
            }
        }
        animator.SetTrigger("Attack");
        Debug.Log(isAttacking);
        isAttacking = false;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount; // Вычитаем полученный урон из текущих хитпоинтов игрока
        damageTaken += amount; // Увеличиваем количество полученного урона

        if (currentHealth <= 0)
        {
            Die(); // Вызываем функцию смерти, если хитпоинты опустились до нуля или ниже
        }
    }


    public void Heal(int amount)
    {
        currentHealth += amount;

        // Ограничиваем здоровье максимальным значением
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }


    private void Die()
    {
        DiedCanvas.SetActive(true);
        Destroy(gameObject);
    }
}
