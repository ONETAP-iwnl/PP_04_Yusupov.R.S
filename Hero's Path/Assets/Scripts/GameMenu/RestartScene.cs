using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{
    public void RestartScen()
    {
        // Получаем индекс текущей загруженной сцены
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Загружаем сцену с тем же индексом
        SceneManager.LoadScene(currentSceneIndex);
    }
}
