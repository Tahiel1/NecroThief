using UnityEngine;

public class IsSteallingCollider : MonoBehaviour, IisSus
{
    public void addSus(int amount)
    {
        GameController.Instance.UpdateSuspicion(amount);
    }
}
