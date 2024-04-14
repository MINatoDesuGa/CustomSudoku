using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class NumberButton : MonoBehaviour
{
    [SerializeField] 
    private Button _numberButton;
    [SerializeField] 
    private TMP_Text _numberText;

    private int _number;

    [SerializeField]
    private SudokuValidator _sudokuValidator;
    private void Start()
    {
        _number = int.Parse(_numberText.text);
    }

    private void OnEnable()
    {
        _numberButton.onClick.AddListener(OnNumberButtonClick);
    }

    private void OnDisable()
    {
        _numberButton.onClick.RemoveListener(OnNumberButtonClick);
    }

    private void OnNumberButtonClick()
    {
        //theres no need to proceed if SelectedNumberCell is null 
        if (GlobalVariables.SelectedNumberCell == null) return;

        //this sets the selected number cell text with the number button text that is clicked
        GlobalVariables.SelectedNumberCell.CellText.text = _numberText.text;
        _sudokuValidator.UpdateCellValue(
                GlobalVariables.SelectedNumberCell.CellRow,
                GlobalVariables.SelectedNumberCell.CellColumn,
                _number
            );

        //checks current game mode
        switch (GlobalVariables.CurrentGameMode) {
            //play mode
            case GlobalVariables.GameMode.Play:
                //sets selected number cell text font style to normal
                GlobalVariables.SelectedNumberCell.CellText.fontStyle = FontStyles.Normal;
                break;
            //edit mode
            case GlobalVariables.GameMode.Edit:
                //sets selected number cell text font style to bold
                GlobalVariables.SelectedNumberCell.CellText.fontStyle = FontStyles.Bold;
                //adds selected number cell button to LockableButton Set
                GlobalVariables.LockableButtons.Add(GlobalVariables.SelectedNumberCell.CellButton);
                break;
        }
        
        GlobalVariables.ResetSelectedNumberCell();
        GameEventManager.NumberCellEntered?.Invoke();
    }
}
