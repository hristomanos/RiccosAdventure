using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] LvlConfig lvlconfig;
    [SerializeField] UiManager uImanager;
 
    void Start()
    {
        uImanager.InitializeScore(lvlconfig.NumberOfCarrots);
    }
}
