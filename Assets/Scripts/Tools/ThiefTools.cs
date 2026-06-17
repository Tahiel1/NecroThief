using UnityEngine;

public class ThiefTools : Pickpoquet, IisSus
{
    public void addSus(int amount)
    {
        GameController.Instance.UpdateSuspicion(amount);
    }

    protected override void OnTriggerStay2D(Collider2D collision)
    {
        base.OnTriggerStay2D(collision);
    }
}
