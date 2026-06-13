using UnityEngine;

public class ThiefTools : Pickpoquet, IisSus
{
    public void addSus(int amount)
    {
        GameController.Instance.UpdateSuspicion(amount);
    }
}
