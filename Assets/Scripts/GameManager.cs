using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ClickManager ClickManager;
    public UIManager UIManager;
    public EnemyManager EnemyManager;

    public static GameManager Instance;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }


}
