using Unity.VisualScripting;
using UnityEngine;

public class CrossCollider : MonoBehaviour
{
    [SerializeField] protected GameObject objectOnCross;

    private void OnTriggerStay2D(Collider2D collision)
    {
        objectOnCross=collision.gameObject.transform.parent.gameObject; ;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        objectOnCross=null;
    }
}