using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    [Header("Components")]
    [SerializeField] private SusBarAndScore hudManager;
    [SerializeField] private GameObject endLevel;
    [SerializeField] private GameObject victoryPanel;
    [SerializeField] private GameObject losePanel;

    [Header("Game Data")]
    private int score=0;
    [SerializeField] private float suspicion;
    private int maxLevel = 1;
    [SerializeField] private int allLevels = 3;
    public int MaxLevel => maxLevel;
    

    private void Awake()
    {
        
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

   
    public void AddScore(int amount)
    {
        score += amount;

        
        if (hudManager != null)
        {
            hudManager.UpdateScoreUI(score);
        }
    }

    
    public void UpdateSuspicion(float addSus)
    {
        suspicion = suspicion + addSus;

        if (hudManager != null)
        {
            hudManager.fillSus(suspicion);
        }
    }

    public void SetScoreStarLevel(int level)
    {
        score = 0;
        hudManager.SetScoreStarLevel(level,score);
    }

    public void addMaxLevel(int level)
    {
        if (maxLevel == level && maxLevel < allLevels)
        {
            maxLevel += 1;
        }
    }
    public void GetMaxMoney()
    {
        endLevel.SetActive(true);
    }
    public void WinLevel()
    {
        victoryPanel.SetActive(true);
    }

    public void LoseLevel()
    {
        losePanel.SetActive(true);
    }
    public void GetComponentGC(SusBarAndScore susBar, GameObject otherEndLevel, GameObject otherLosePanel, GameObject otherVictoryPanel)
    {
        Debug.Log("Asignando componentes");
        hudManager = susBar;
        endLevel = otherEndLevel;
        losePanel = otherLosePanel;
        victoryPanel = otherVictoryPanel;
        suspicion = 0f;
    }
}
