using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class ClickManager : MonoBehaviour
{
    public static ClickManager Instance;
    Camera mainCamera;
    [SerializeField] LayerMask EnemyLayer;
    [SerializeField] int Score = 10;
    [SerializeField] int AutoClickNum;
    private float _clickTimeCount = 0.0f;
    private float _curTimer = 0.0f;
    [SerializeField] int AttackLevel = 1;
    public int AttackUpCost = 10;
    public int AutoClickCost = 10;
    [SerializeField] int Attack_Up = 10;
    bool _isClick = false;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        mainCamera = Camera.main;
    }
    public void OnClickAutoClickBtn()
    {
        if (!_isClick)
        {
            StartCoroutine(AutoClick());
        }
        
    }
    private void Update()
    {
        _clickTimeCount += Time.deltaTime;

        if (_clickTimeCount - _curTimer > 0.5f)
        {
            PlayerManager.Instance.StopPlayerAttack();
            EnemyManager.Instance.StopDamage();
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
        _isClick = true;
        for(int i = 0; i< AutoClickNum; i++)
        {
            PlayerManager.Instance.PlayerAttack();
            yield return new WaitForSecondsRealtime(0.1f);
        }

        _isClick = !_isClick;
    }

    public void OnClickAttackUpBtn()
    {
        if(GameManager.Instance.Gold > AttackUpCost)
        {
            GameManager.Instance.Gold -= AttackUpCost;
            AttackLevel++;
            AttackUpCost = AttackLevel * Attack_Up;
            PlayerManager.Instance.PlayerAttackUp(AttackLevel * Attack_Up);
            UIManager.Instance.UpdateUI();
        }
    }
    
}
