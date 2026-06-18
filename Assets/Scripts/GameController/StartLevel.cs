using System;
using UnityEngine;

public class StartLevel : MonoBehaviour
{
    [SerializeField] int level=1;
    [SerializeField] private SusBarAndScore hudManager;
    [SerializeField] private GameObject endLevel;
    [SerializeField] private GameObject victoryPanel;
    [SerializeField] private GameObject losePanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        Time.timeScale = 1f;
        GameController.Instance.GetComponentGC(hudManager, endLevel, losePanel, victoryPanel);
        GameController.Instance.SetScoreStarLevel(level);
    }
}
