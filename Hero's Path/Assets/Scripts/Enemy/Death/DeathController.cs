using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathController : MonoBehaviour
{
   public Transform player; // Ссылка на игрока
    public List<Vector2> waypoints; // Список точек, по которым враг будет передвигаться
    public float speed = 2f; // Скорость движения врага

    public float attackDelay = 2f; // Задержка перед атакой
    private float attackTimer; // Таймер для атаки

    private int currentWaypointIndex = 0; // Индекс текущей точки назначения
    private bool isAttacking = false; // Флаг атаки

    private Animator animator; // Компонент аниматора
    private SpriteRenderer spriteRenderer; // Компонент отображения спрайта

    public int maxHealth = 100; // Максимальное количество хитпоинтов игрока
    public int damage = 10; // Урон, который наносит игрок

    public int currentHealth; // Текущее количество хитпоинтов игрока
    private int damageTaken; // Количество полученного урона
    private int damageDealt; // Количество нанесенного урона

    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        attackTimer = attackDelay; // Инициализируем таймер атаки
    }

    private void Update()
    {
        if (isAttacking)
        {
            // Проверяем таймер атаки
            if (attackTimer <= 0f)
            {
                // Враг атакует игрока
                // Воспроизведите анимацию атаки или выполняйте другую логику атаки

                // Сбрасываем таймер атаки
                attackTimer = attackDelay;
            }
            else
            {
                // Обновляем таймер атаки
                attackTimer -= Time.deltaTime;
            }
        }
        else
        {
            // Враг следует за точками
            if (waypoints.Count > 0)
            {
                Vector2 targetPosition = waypoints[currentWaypointIndex];
                Vector3 targetPosition3D = new Vector3(targetPosition.x, targetPosition.y, transform.position.z);
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

                // Если враг достиг текущей точки назначения, переключитесь на следующую точку
                if (transform.position == targetPosition3D)
                {
                    currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;
                }
            }
        }

        // Проверяем положение игрока и разворачиваем врага при необходимости
        if (player.position.x > transform.position.x)
        {
            spriteRenderer.flipX = true; // Враг разворачивается вправо
        }
        else if (player.position.x < transform.position.x)
        {
            spriteRenderer.flipX = false; // Враг разворачивается влево
        }

        // Устанавливаем параметры анимации
        animator.SetBool("IsAttack", isAttacking);
        animator.SetBool("IsWalk", waypoints.Count > 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isAttacking = true;
        }
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isAttacking = false;
        }
    }
}
