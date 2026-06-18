using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class NpcScript : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] protected float speed = 5f;
    [SerializeField] protected float stopTime = 5f;
    [SerializeField] protected float moveTime = 4f;
    [SerializeField] protected SpriteRenderer bodySprite;

    //Variables para delimitar las coordenadas máximas y mínimas del mapa
    [Header("Map Bounds")]
    [SerializeField] protected float minX = -10f;
    [SerializeField] protected float maxX = 10f;
    [SerializeField] protected float minY = -5f;
    [SerializeField] protected float maxY = 5f;

    [Header("Cone of vision information")]
    [SerializeField] protected GameObject coneOfVisionPivot;
    [SerializeField] protected GameObject coneOfVision;

    protected float leftView = 270f;
    protected float rightView = 90f;
    protected float upView = 180f;
    protected float downView = 0f;

    protected Vector3 direction;
    protected bool isMoving = false;

    private Coroutine lifecycleCoroutine;
    private bool isDistracted = false;

    private void OnEnable()
    {
        DestructibleObject.OnObjectDestroyed += InvestigateNoise;
    }

    // NUEVO: Es vital desuscribirse si el NPC muere o se destruye para evitar errores de memoria
    private void OnDisable()
    {
        DestructibleObject.OnObjectDestroyed -= InvestigateNoise;
    }

    void Start()
    {
        lifecycleCoroutine = StartCoroutine(RoutineNpcLifecycle());
    }

    void Update()
    {
        if (isMoving && !isDistracted)
        {
            HandleMovement();
        }
    }

    protected void HandleMovement()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    protected IEnumerator RoutineNpcLifecycle()
    {
        while (true)
        {
            ChangeDirection();
            isMoving = true;
            yield return new WaitForSeconds(moveTime);

            isMoving = false;
            yield return new WaitForSeconds(stopTime);
        }
    }

    private void InvestigateNoise(Vector3 noisePosition)
    {
        if (isDistracted) return;

        if (lifecycleCoroutine != null)
        {
            StopCoroutine(lifecycleCoroutine);
        }

        isMoving = false;

        //Iniciamos la reacción de alerta
        lifecycleCoroutine = StartCoroutine(RoutineReactionToNoise(noisePosition));
    }

    private IEnumerator RoutineReactionToNoise(Vector3 targetPosition)
    {
        isDistracted = true;

        // Calculamos la dirección relativa hacia el ruido
        Vector3 directionToNoise = targetPosition - transform.position;

        // Cambiamos el cono de visión hacia donde ocurrió el ruido
        if (Mathf.Abs(directionToNoise.x) > Mathf.Abs(directionToNoise.y))
        {
            // El ruido fue más horizontal que vertical
            ApplyDirectionSettings(directionToNoise.x > 0 ? 4 : 2); // 4 = Right, 2 = Left
        }
        else
        {
            // El ruido fue más vertical que horizontal
            ApplyDirectionSettings(directionToNoise.y > 0 ? 3 : 1); // 3 = Up, 1 = Down
        }

        // Nos quedamos mirando fijamente
        yield return new WaitForSeconds(stopTime);

        isDistracted = false;

        //Retomamos el ciclo de vida normal
        lifecycleCoroutine = StartCoroutine(RoutineNpcLifecycle());
    }

    protected virtual void ChangeDirection()
    {
        int randomDirection = Random.Range(1, 5);
        ApplyDirectionSettings(randomDirection);

        Vector3 predictedTarget = transform.position + (direction * speed * moveTime);

        if (predictedTarget.x <= minX || predictedTarget.x >= maxX ||
            predictedTarget.y <= minY || predictedTarget.y >= maxY)
        {
            Debug.Log("Se va a salir el NPC");
            ChangeDirection();
        }
    }

    /*private void TryRandomValidDirection()
    {
        int[] directions = { 1, 2, 3, 4 };

        foreach (int dirKey in directions)
        {
            ApplyDirectionSettings(dirKey);
            Vector3 checkTarget = transform.position + (direction * speed * moveTime);

            if (checkTarget.x > minX && checkTarget.x < maxX &&
                checkTarget.y > minY && checkTarget.y < maxY)
            {
                return;
            }
        }
    }*/

    private void ApplyDirectionSettings(int directionKey)
    {
        switch (directionKey)
        {
            case 1:
                coneOfVisionPivot.transform.rotation = Quaternion.Euler(0, 0, downView);
                direction = Vector3.down;
                break;
            case 2:
                coneOfVisionPivot.transform.rotation = Quaternion.Euler(0, 0, leftView);
                direction = Vector3.left;
                bodySprite.flipX = false;
                break;
            case 3:
                coneOfVisionPivot.transform.rotation = Quaternion.Euler(0, 0, upView);
                direction = Vector3.up;
                break;
            case 4:
                coneOfVisionPivot.transform.rotation = Quaternion.Euler(0, 0, rightView);
                direction = Vector3.right;
                bodySprite.flipX = true;
                break;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 center = new Vector3((minX + maxX) / 2f, (minY + maxY) / 2f, 0f);
        Vector3 size = new Vector3(maxX - minX, maxY - minY, 0.1f);
        Gizmos.DrawWireCube(center, size);
    }
}
