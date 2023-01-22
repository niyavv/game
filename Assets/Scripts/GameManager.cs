using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using DefaultNamespace;

public class GameManager : MonoBehaviour
{
    public int score;
   
    public TMP_Text ScoreText;

    private void Awake()
    {
        Events.ScoreIncreasedEvent += OnScoreIncreased;
    }

    private void OnDestroy()
    {
        Events.ScoreIncreasedEvent -= OnScoreIncreased;
    }

    private void OnScoreIncreased(ScoreData obj)
    {
        UpdateScore(obj.scoreToAdd);
    }

    private void Start()
    {
        score = 0;//score de�eri 0 olsun 
        ScoreText.text = score.ToString();
    }

    private void UpdateScore(int amount)//updatescore fonksiyonu
    {
        score+= amount;//score'u bir artt�r
        ScoreText.text = score.ToString();//int tan�mlanan score u string ifadeye d�n��t�r
    }
}
