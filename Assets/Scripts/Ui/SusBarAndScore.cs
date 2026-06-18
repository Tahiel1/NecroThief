using TMPro;
using UnityEngine;
using Slider = UnityEngine.UI.Slider;

public class SusBarAndScore : MonoBehaviour
{
    [SerializeField] private Slider susSlider;
    [SerializeField] private float maxSus=100f;

    private int winScore;
    public int WinScore => winScore;

    [SerializeField] private TextMeshProUGUI scoreText;

    private void Start()
    {
        if (susSlider != null)
        {
            susSlider.value = 0f;
            susSlider.minValue = 0f;
            susSlider.maxValue = maxSus;
        }
    }
    
    public void fillSus(float value)
    {
        if (!susSlider) return;

        susSlider.value = value;

        if (susSlider.value < 0)
        {
            susSlider.value = 0f;
        }
        if (susSlider.value >= maxSus)
        {
            GameController.Instance.LoseLevel();
        }
    }


    public void UpdateScoreUI(int currentScore)
    {
        scoreText.text = "$"+currentScore.ToString() +" / $"+ winScore.ToString();
        if(currentScore>=winScore) GameController.Instance.GetMaxMoney();
    }

    public void SetScoreStarLevel(int level, int score)
    {
        switch (level)
        {
            case 1:
                winScore = 100;
                break;
            case 2:
                winScore = 125;
                break;
            case 3:
                winScore = 250;
                break;
        }
        UpdateScoreUI(score);
    }
}
