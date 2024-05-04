using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] 
    private Button _editButton;
    [SerializeField]
    private Button _resetHUD;
    [SerializeField] 
    private TMP_Text _editButtonText;

    [Header("GameOver Panel")]
    [SerializeField]
    private GameObject _gameOverPanel;
    [SerializeField]
    private TMP_Text _solveCountText;
    [SerializeField]
    private Button _resetButton;
    [SerializeField]
    private Button _quitButton;

    private void OnEnable()
    {
        _editButton.onClick.AddListener(OnEditButtonClick);
        GameEventManager.OnGameOver += OnGameOver;
        _resetButton.onClick.AddListener(OnResetClick);
        _quitButton.onClick.AddListener(OnQuitClick);
        _resetHUD.onClick.AddListener(OnResetClick);
    }
    private void OnDisable()
    {
        _editButton.onClick.RemoveListener(OnEditButtonClick);
        GameEventManager.OnGameOver -= OnGameOver;
        _resetHUD.onClick.RemoveListener(OnResetClick);
        _resetButton.onClick.RemoveListener(OnResetClick);
        _quitButton.onClick.RemoveListener(OnQuitClick);
    }
    
    private void OnEditButtonClick()
    {
        GlobalVariables.ResetSelectedNumberCell();
        //checks current game mode state
        switch(GlobalVariables.CurrentGameMode)
        {
            //play mode
            case GlobalVariables.GameMode.Play:
                //sets current game mode to edit mode
                GlobalVariables.CurrentGameMode = GlobalVariables.GameMode.Edit;
                //changes display header text to E (will be changed later)
                _editButtonText.text = "E";
                //enables buttons that are locked
                HandleButtonLock(true);
                break;
            //edit mode
            case GlobalVariables.GameMode.Edit:
                //sets current game mode to play mode
                GlobalVariables.CurrentGameMode = GlobalVariables.GameMode.Play;
                //changes display header text to P (will be changed later)
                _editButtonText.text = "P";
                //disables buttons that can be locked
                HandleButtonLock(false);
                break;
        }

        
    }
    /// <summary>
    /// enables/disables the Lockable buttons 
    /// </summary>
    /// <param name="active">
    /// true for active, false for inactive
    /// </param> 
    private void HandleButtonLock(bool active)
    {
        foreach(Button button in GlobalVariables.LockableButtons)
        {
            button.interactable = active;
        }
    }
    private void OnResetClick()
    {
        GameEventManager.OnReset?.Invoke();
        HandleButtonLock(true);
        GlobalVariables.LockableButtons.Clear();
        _gameOverPanel.SetActive(false);
    }
    private void OnQuitClick()
    {
        Application.Quit();
    }
    private void OnGameOver()
    {
        _gameOverPanel.SetActive(true);
        _solveCountText.text = "Solve Count\n"+ PlayerPrefs.GetInt("SolveCount").ToString();
    }
}
