using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SafeBox : MonoBehaviour, ICanThiefTools
{
    [SerializeField] private int money=50;
    public int Money => money;
    [SerializeField] int successCount;
    [SerializeField] int maxSuccess = 3;

    [SerializeField] private TextMeshProUGUI remaininSuccessCount;

    private void Awake()
    {
        remaininSuccessCount.text = null;
    }
    public void FailSteal()
    {
        successCount--;
        if(successCount < 0) successCount = 0;
        ShowSucces();
    }
    public void addSuccess()
    {
        successCount++;
        ShowSucces();
        if (successCount >= maxSuccess) StealMoney();
    }
    public void StealMoney()
    {
        GameController.Instance.AddScore(money);
        money = 0;
        remaininSuccessCount.text = null;
    }
    public bool IsStealable()
    {
        bool isStealable = (money != 0);
        if (isStealable) ShowSucces();
        return isStealable;
    }
    private void ShowSucces()
    {
        int succesText = maxSuccess - successCount;
        remaininSuccessCount.text= succesText.ToString();
    }

}
