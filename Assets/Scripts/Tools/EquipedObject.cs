using UnityEngine;

public class EquipedObject : MonoBehaviour
{
    [SerializeField] private PlayerInputController inputController;
    [SerializeField] private GameObject crossAir;
    
    
    private void Update()
    {
        HandleCrossPosition();
        HandleNormalize();
    }

    private void HandleCrossPosition()
    {
        Vector3 temPosition = crossAir.transform.position;
        Vector2 inputUser = inputController.MoveData;

        if (inputUser.x != 0)
        {
            temPosition.x = Mathf.Sign(inputUser.x);
            temPosition.y = 0;
        }
        else if(inputUser.y != 0)
        {
            temPosition.y = Mathf.Sign(inputUser.y);
            temPosition.x = 0;
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
