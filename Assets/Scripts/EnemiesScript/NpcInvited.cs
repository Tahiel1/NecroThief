using UnityEngine;

public class NpcInvited : NpcScript, IisStealable
{
    [SerializeField] private int money=25;
    [SerializeField] private int failStealPen=15;
    public void StealMoney()
    {
        GameController.Instance.AddScore(money);
        money = 0;
    }

    public void FailSteal()
    {
        GameController.Instance.UpdateSuspicion(failStealPen);
    }
}
