using Unity.VisualScripting;
using UnityEngine;

public class ThiefTools : Pickpoquet, IisSus
{
    public void addSus(int amount)
    {
        GameController.Instance.UpdateSuspicion(amount);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        ICanThiefTools canThiefTools = collision.GetComponent<ICanThiefTools>();
        if (canThiefTools != null&& canThiefTools.IsStealable()) 
        {
            objectOnCross = collision.gameObject;
        }
    }
    protected override void OnTriggerExit2D(Collider2D collision)
    {
        if (isStealing)
        {
            Debug.Log("No robaste");
            objectOnCross.GetComponent<ICanThiefTools>().FailSteal();
        }
        if (collision.gameObject == objectOnCross)
            objectOnCross = null;
    }

    protected override void Steal()
    {
        Debug.Log("Robaste");
        objectOnCross.GetComponent<ICanThiefTools>().addSuccess();
    }
    public override void DidntSteal()
    {
        Debug.Log("no robaste");
        objectOnCross.GetComponent<ICanThiefTools>().FailSteal();
        objectOnCross = null;
        isStealing = false;
    }

}
