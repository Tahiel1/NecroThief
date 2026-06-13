using Unity.Mathematics;
using UnityEngine;

public class CrossAirPos : MonoBehaviour
{
    [SerializeField] protected PlayerInputController inputController;
    [SerializeField] private GameObject crossAir;
    
    
    private void Update()
    {
        HandleCrossPosition();
        HandleNormalize();
    }

    private void HandleCrossPosition()
    {
        //Hago que la posisión de la mira cambie al rededor del jugador dependiendo de hacia donde se haya movio por última vez (sin contar diagonales)
        Vector3 temPosition = crossAir.transform.position;

        Vector2 inputUser = inputController.MoveData;

        if (inputUser.x != 0)
        {
            temPosition.x = Mathf.Sign(inputUser.x);
            temPosition.y = 0;
            if (inputUser.x > 0)
            {
                crossAir.transform.rotation = Quaternion.Euler(0, 0, -90);
            }
            else
            {
                crossAir.transform.rotation = Quaternion.Euler(0, 0, 90);
            }

        }
        else if(inputUser.y != 0)
        {
            temPosition.y = Mathf.Sign(inputUser.y);
            temPosition.x = 0;
            if (inputUser.y > 0)
            {
                crossAir.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                crossAir.transform.rotation = Quaternion.Euler(0, 0, 180);
            }
        }
        else
        {
            return;
        }
        crossAir.transform.position = temPosition + transform.position;
    }
    private void HandleNormalize()
    {
        (crossAir.transform.position).Normalize();
    }
}
