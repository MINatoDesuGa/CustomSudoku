using System.Collections.Generic;
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
        switch(GlobalVariables.CurrentGameMode)
        {
            case GlobalVariables.GameMode.Play:
                GlobalVariables.CurrentGameMode = GlobalVariables.GameMode.Edit;
                _editButtonText.text = "E";
                break;
            case GlobalVariables.GameMode.Edit:
                GlobalVariables.CurrentGameMode = GlobalVariables.GameMode.Play;
                _editButtonText.text = "P";
                break;
        }

        HandleButtonLock();
    }

    private void HandleButtonLock()
    {
        bool active = (GlobalVariables.CurrentGameMode == GlobalVariables.GameMode.Edit);
        foreach(Button button in GlobalVariables.LockedButtons)
        {
            button.interactable = active;
        }
    }
}
