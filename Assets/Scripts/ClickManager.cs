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
    private float _clickTimeCount = 0.0f;
    private float _curTimer = 0.0f;
    void Start()
    {
        mainCamera = Camera.main;
    }
    public void OnClickAutoClickBtn()
    {
        StartCoroutine(AutoClick());
    }
    private void Update()
    {
        _clickTimeCount += Time.deltaTime;

        if (_clickTimeCount - _curTimer > 0.5f)
        {
            PlayerManager.Instance.StopPlayerAttack();
            _clickTimeCount = 0.0f;
            _curTimer = 0.0f;
        }
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();
        Vector2 worldPos = mainCamera.ScreenToWorldPoint(mousePos);

        if (context.started)
        {
            RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);
            if (hit.collider != null)
            {
                if (1 << hit.collider.gameObject.layer == EnemyLayer)
                {
                    PlayerManager.Instance.PlayerAttack();
                }
            }
        } 
        else if (context.canceled)
        {
            _curTimer = _clickTimeCount;           
        }
    }

    IEnumerator AutoClick()
    {
        for(int i = 0; i< AutoClickNum; i++)
        {
            PlayerManager.Instance.PlayerAttack();
            yield return new WaitForSecondsRealtime(0.1f);
        }
        
    }

    public void OnClickAttackUpBtn()
    {

    }
    
}
