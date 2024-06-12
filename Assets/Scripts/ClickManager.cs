using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickManager : MonoBehaviour
{
    Camera mainCamera;
    [SerializeField] LayerMask EnemyLayer;
    [SerializeField] int Score = 10;
    [SerializeField] int AutoClickNum;
    void Start()
    {
        mainCamera = Camera.main;
    }
    public void OnClickAutoClickBtn()
    {
        StartCoroutine(AutoClick());
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();
        Vector2 worldPos = mainCamera.ScreenToWorldPoint(mousePos);

        RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);
        if (hit.collider != null)
        {
            if (1 << hit.collider.gameObject.layer == EnemyLayer)
            {
                UIManager.Instance.AddScore(Score);
            }
        }
    }

    IEnumerator AutoClick()
    {
        for(int i = 0; i< AutoClickNum; i++)
        {
            UIManager.Instance.AddScore(Score);
            yield return new WaitForSecondsRealtime(0.1f);
        }
        
    }
    
}
