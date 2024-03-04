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
        switch(GlobalVariables.CurrentGameMode)
        {
            case GlobalVariables.GameMode.Play:
                GlobalVariables.CurrentGameMode = GlobalVariables.GameMode.Edit;
                _editButtonText.text = "E";
                HandleButtonLock(true);
                break;
            case GlobalVariables.GameMode.Edit:
                GlobalVariables.CurrentGameMode = GlobalVariables.GameMode.Play;
                _editButtonText.text = "P";
                HandleButtonLock(false);
                break;
        }

        
    }

    private void HandleButtonLock(bool active)
    {
        foreach(Button button in GlobalVariables.LockableButtons)
        {
            button.interactable = active;
        }
    }
}
