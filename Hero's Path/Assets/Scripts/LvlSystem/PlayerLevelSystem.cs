using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevelSystem : MonoBehaviour
{
    [System.Serializable]
    public class EnemyExperienceData
    {
        public EnemyController enemy; // Ссылка на компонент EnemyController
        public int experienceReward; // Количество опыта, получаемого за убийство данного врага
    }

    public int currentLevel = 1; // Текущий уровень игрока
    public int experience = 0; // Текущий опыт игрока
    public int experiencePerLevel = 100; // Опыт, необходимый для повышения уровня
    public int maxLevel = 10; // Максимальный уровень игрока
    public int[] damagePerLevel; // Массив урона для каждого уровня
    public EnemyExperienceData[] enemyExperienceData; // Массив данных об опыте для каждого врага

    private int currentDamage; // Текущий урон игрока

    private void Start()
    {
        currentDamage = damagePerLevel[currentLevel - 1];
    }

    public void AddExperience(int amount)
    {
        experience += amount;

        // Проверяем, достиг ли игрок определенного уровня
        if (currentLevel < maxLevel)
        {
            // Если опыт превышает необходимое количество для повышения уровня
            if (experience >= experiencePerLevel)
            {
                LevelUp();
            }
        }
    }

    private void LevelUp()
    {
        // Увеличиваем уровень игрока
        currentLevel++;

        // Повышаем урон игрока на соответствующий уровню урон
        if (currentLevel <= damagePerLevel.Length)
        {
            currentDamage = damagePerLevel[currentLevel - 1];
        }
        else
        {
            // Если массив урона исчерпан, просто удваиваем урон
            currentDamage *= 2;
        }

        // Сбрасываем опыт до 0
        experience = 0;
    }

    // Метод для нанесения урона врагу
    public void DealDamage(EnemyController enemy)
    {
        enemy.TakeDamage(currentDamage);
    }

    // Метод, вызываемый при убийстве врага
    public void EnemyKilled(EnemyController enemy)
    {
        // Ищем данные об опыте для данного врага
        foreach (EnemyExperienceData data in enemyExperienceData)
        {
            if (data.enemy == enemy)
            {
                AddExperience(data.experienceReward);
                break;
            }   
        }
    }
}
