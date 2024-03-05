using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] 
    private Button _editButton;
    [SerializeField] 
    private TMP_Text _editButtonText;

    private void OnEnable()
    {
        _editButton.onClick.AddListener(OnEditButtonClick);
    }
    private void OnDisable()
    {
        _editButton.onClick.RemoveListener(OnEditButtonClick);
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
}
