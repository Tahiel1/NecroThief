using Unity.VisualScripting;
using UnityEngine;

public class CrossCollider : MonoBehaviour
{
    [SerializeField] protected GameObject objectOnCross;

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        IisStealable isStealable = collision.GetComponent<IisStealable>();
        if(isStealable!=null && isStealable.IsStealable())
            objectOnCross=collision.gameObject;
    }
    
}