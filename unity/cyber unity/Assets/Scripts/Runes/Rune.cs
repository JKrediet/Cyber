using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Rune", menuName = "NewRuneVairable/Rune", order = 1)]
public class Rune : ScriptableObject
{
    public GameObject runeObject;

    [Header("RuneVariable")]
    public string runeName;
    public Sprite runeDesc;
    [Header("RuneRewards")]
    public int skillPoint;
}
