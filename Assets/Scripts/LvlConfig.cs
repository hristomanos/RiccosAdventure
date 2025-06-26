using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Config/Levels")]
public class LvlConfig : ScriptableObject
{
   [SerializeField] public int NumberOfCarrots;
}
