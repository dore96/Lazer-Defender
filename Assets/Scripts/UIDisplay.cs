using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private Slider slider;
    [SerializeField] private Health health;

    [Header("Score")] 
    [SerializeField] private TextMeshProUGUI scoreText;
    private ScoreKeeper score;
    
    void Awake()
    {
        score = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        slider.maxValue = health.GetHealth();
    }

    void Update()
    {
        slider.value = health.GetHealth();
        scoreText.text = score.GetPlayerScore().ToString("000000000");
    }
}
