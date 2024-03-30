using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="cardStats",menuName ="newCard")]
public class CardStats : ScriptableObject
{
    public Sprite card_Image;
    public string card_Text;
}
