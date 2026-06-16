using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuPanel;

    private PlayerInput _inputActions;
    private bool _isPaused = false;

    private void Awake()
    {
        _inputActions = new PlayerInput();
    }

    private void OnEnable()
    {
        _inputActions.Player.Pause.performed += TogglePause;
        _inputActions.UI.Unpause.performed += TogglePause;

        _inputActions.Player.Enable();
        _inputActions.UI.Disable();
    }

    private void OnDisable()
    {
        _inputActions.Player.Pause.performed -= TogglePause;
        _inputActions.UI.Unpause.performed -= TogglePause;

        _inputActions.Player.Disable();
        _inputActions.UI.Disable();
    }

    private void TogglePause(InputAction.CallbackContext context)
    {
        _isPaused = !_isPaused;

        if (_isPaused)
        {
            Time.timeScale = 0f;
            pauseMenuPanel.SetActive(true);

            _inputActions.Player.Disable();
            _inputActions.UI.Enable();
        }
        else
        {
            Time.timeScale = 1f;
            pauseMenuPanel.SetActive(false);

            _inputActions.UI.Disable();
            _inputActions.Player.Enable();
        }
    }

    public void Contine()
    {
        Time.timeScale = 1f;
        pauseMenuPanel.SetActive(false);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
