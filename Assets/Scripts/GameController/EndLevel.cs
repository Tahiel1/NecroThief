using UnityEngine;

public class EndLevel : MonoBehaviour
{
    [SerializeField] private int m_Level = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            GameController.Instance.addMaxLevel(m_Level);
            GameController.Instance.WinLevel();
        }
    }
}
