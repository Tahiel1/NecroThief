using UnityEngine;

public class SlingshotAmmo : MonoBehaviour
{

    [SerializeField] private float speed = 3f;
    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ICanDestroy canDestroy = collision.GetComponent<ICanDestroy>();
        if (canDestroy != null)
        {
            collision.GetComponent<ICanDestroy>().DestroyObject();
        }
    }
}
