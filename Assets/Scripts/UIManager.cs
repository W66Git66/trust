using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{   
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="npcStats">npc的状态</param>
    /// <param name="damage">造成的伤害</param>

}
