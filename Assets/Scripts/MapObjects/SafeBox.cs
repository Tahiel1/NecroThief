using Unity.VisualScripting;
using UnityEngine;

public class SafeBox : MonoBehaviour, ICanThiefTools
{
    [SerializeField] private int money=50;
    public int Money => money;
    [SerializeField] int successCount;
    public void FailSteal()
    {
        successCount--;
        if(successCount < 0) successCount = 0;
    }
    public void addSuccess()
    {
        successCount++;
        if (successCount >= 3) StealMoney();
    }
    public void StealMoney()
    {
        GameController.Instance.AddScore(money);
        money = 0;
    }
    public bool IsStealable()
    {
        bool isStealabel = (money != 0);
        return isStealabel;
    }

}
