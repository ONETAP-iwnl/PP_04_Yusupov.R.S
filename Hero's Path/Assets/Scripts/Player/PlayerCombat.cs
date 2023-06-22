using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    public int maxHealth = 100; // Максимальное количество хитпоинтов игрока
    public int damage; // Урон, который наносит игрок

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

    private void Attack()
    {
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

    private void Die()
    {
        
        Destroy(gameObject);
    }
}
