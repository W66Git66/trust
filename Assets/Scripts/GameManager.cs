using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManager : Singleton<GameManager> 
{ 
    
{
<<<<<<< HEAD
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
=======
    public SceneStats _curStats;

    private float bossAttackTime;
    private float PlayerWaitTime;

    private bool isPlayer1 = false;
    private bool isPlayer2 = false;

    private Card bossCard;
    private Card playerCard1;
    private Card playerCard2;
    private void Update()
    {
        
    }

    private void Round()
    {
        switch(_curStats)
        {
            case SceneStats.BossRound1:
                bossCard = CardManager.Instance.GetNormalCard(out playerCard1,out playerCard2);
                break;
            case SceneStats.BossRound2:

                break;
            case SceneStats.PlayerRound:

                break;

        }
>>>>>>> 524b03a0e9a06951287b79e0464ae09350043411
    }
}

public enum SceneStats    
{
    BossRound1,
    BossRound2,
    PlayerRound,
}

