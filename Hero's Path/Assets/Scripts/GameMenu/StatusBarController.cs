using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusBarController : MonoBehaviour
{
    private RectTransform rectTransform;
    private Camera mainCamera;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        mainCamera = Camera.main;

        // ��������� ������� ����� � ����� ������� ����
        rectTransform.anchorMin = new Vector2(0, 1);
        rectTransform.anchorMax = new Vector2(0, 1);
    }

    private void LateUpdate()
    {
        // �������� ������� StatusBar � �������� �����������
        Vector3 screenPos = new Vector3(rectTransform.rect.width * 0.5f, Screen.height - rectTransform.rect.height * 0.5f, 0f);

        // ����������� ������� �� �������� ��������� �� viewport ����������
        Vector3 viewportPos = mainCamera.ScreenToViewportPoint(screenPos);

        // ����������� viewport ���������� � ������� ����������
        Vector3 worldPos = mainCamera.ViewportToWorldPoint(viewportPos);
        worldPos.z = 0f;

        // ������������� ������� StatusBar
        transform.position = worldPos;
    }
}
