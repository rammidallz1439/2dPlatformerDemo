using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;
   
    [SerializeField]
    private TMP_Text scoreText;

    private void Start()
    {
        manager = this;
       
        AddScore(PlayerPrefs.GetInt("CoinData"));
    }
   


    public void AddScore(int score)
    {
        scoreText.text =  "Coins :" + score.ToString();
    }
}
