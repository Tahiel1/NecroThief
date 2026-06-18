using UnityEngine;

public class IsSteallingCollider : MonoBehaviour, IisSus
{
    [SerializeField] private ThiefTools tiefToolsScript;
    [SerializeField] private Pickpoquet pickpoquetScript;
    public void addSus(int amount)
    {
        GameController.Instance.UpdateSuspicion(amount);
        if (pickpoquetScript)
            if (pickpoquetScript.IsStealing) pickpoquetScript.DidntSteal();
        if(tiefToolsScript)
            if(tiefToolsScript.IsStealing) tiefToolsScript.DidntSteal();
    }
}
