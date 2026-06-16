using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    [Header("Components")]
    [SerializeField] private SusBarAndScore hudManager;

    [Header("Game Data")]
    private int score=0;
    private float suspicion;
    private int maxLevel = 1;
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
        if (maxLevel == level)
        {
            maxLevel += 1;
        }
    }
}
