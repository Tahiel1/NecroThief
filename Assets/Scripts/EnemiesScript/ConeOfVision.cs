using UnityEngine;

public class ConeOfVision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IisSus isSus = collision.gameObject.GetComponent<IisSus>();
        if (isSus != null) {
            isSus.addSus(10);
        }
    }
}
