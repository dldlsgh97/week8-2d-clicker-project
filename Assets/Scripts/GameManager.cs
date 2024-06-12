using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Camera mainCamera;
    [SerializeField] LayerMask EnemyLayer;
    [SerializeField] int Score = 10;
    void Start()
    {
        mainCamera = Camera.main;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            ClickEnemy();
        }
    }

    void ClickEnemy()
    {
        Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider != null)
        {
            if (1 << hit.collider.gameObject.layer == EnemyLayer)
            {
                UIManager.Instance.AddScore(Score);
            }
        }
    }
}
