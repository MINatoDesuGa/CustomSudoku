using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public NumberCell SelectedNumberCell;

    [SerializeField] private Button editButton;

    [SerializeField] private TMP_Text editButtonText;

    public static bool isEditMode = true;
    public static HashSet<Button> LockedButtons = new HashSet<Button>();

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(instance);
    }

    private void OnEnable()
    {
        editButton.onClick.AddListener(OnEditButtonClick);
    }
    private void OnDisable()
    {
        editButton.onClick.RemoveListener(OnEditButtonClick);
    }
    
    private void OnEditButtonClick()
    {
        if(isEditMode)
        {
            isEditMode = false;
            editButtonText.text = "P";
        } else
        {
            isEditMode = true;
            editButtonText.text = "E";
        }
        HandleButtonLock();
    }

    private void HandleButtonLock()
    {
        foreach(Button button in LockedButtons)
        {
            button.interactable = isEditMode;
        }
    }
}
