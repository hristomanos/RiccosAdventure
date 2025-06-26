using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] LvlConfig lvlconfig;
    [SerializeField] UiManager uImanager;

    // Start is called before the first frame update
    void Start()
    {
        uImanager.InitializeScore(lvlconfig.NumberOfCarrots);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
