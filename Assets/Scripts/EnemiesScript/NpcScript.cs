using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class NpcScript : MonoBehaviour
{
    [Header ("Movement")]
    [SerializeField] protected float speed = 5f;
    [SerializeField] protected float stopTime = 5f;
    [SerializeField] protected float moveTime = 4f;

    [Header ("Cone of vision information")]
    [SerializeField] protected GameObject coneOfVisionPivot;
    [SerializeField] protected GameObject coneOfVision;

    protected float leftView = 270f;
    protected float rightView = 90f;
    protected float upView = 180f;
    protected float downView = 0f;

    protected Vector3 direction;
    protected bool isMoving = false;

    void Start()
    {
        StartCoroutine(RoutineNpcLifecycle());
    }

    void Update()
    {
        if (isMoving)
        {
            HandleMovement();
        }
    }

    protected void HandleMovement()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    // Ciclo de vida del NPC: Elige dirección -> Se mueve -> Se detiene
    protected IEnumerator RoutineNpcLifecycle()
    {
        while (true) // Bucle infinito independiente para cada NPC
        {
            ChangeDirection();
            isMoving = true;

            yield return new WaitForSeconds(moveTime);

            isMoving = false;

            yield return new WaitForSeconds(stopTime);
        }
    }

    protected virtual void ChangeDirection()
    {
        int randomDirection = Random.Range(1, 5);
        switch (randomDirection)
        {
            case 1:
                coneOfVisionPivot.transform.rotation = Quaternion.Euler(0, 0, downView);
                direction = Vector3.down;
                break;
            case 2:
                coneOfVisionPivot.transform.rotation = Quaternion.Euler(0, 0, leftView);
                direction = Vector3.left;
                break;
            case 3:
                coneOfVisionPivot.transform.rotation = Quaternion.Euler(0, 0, upView);
                direction = Vector3.up;
                break;
            case 4:
                coneOfVisionPivot.transform.rotation = Quaternion.Euler(0, 0, rightView);
                direction = Vector3.right;
                break;
        }
    }
}
