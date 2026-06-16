using UnityEngine;
using UnityEngine.UI;


public class ShowLevels : MonoBehaviour
{
    [SerializeField] private Button[] buttons;

    private void Awake()
    {
        int unlockedLevel = GameController.Instance.MaxLevel;
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
        for(int i=0; i < unlockedLevel; i++)
        {
            buttons[i].interactable = true;
        }
    }
}
