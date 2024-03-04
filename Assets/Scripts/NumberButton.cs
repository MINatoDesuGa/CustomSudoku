using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NumberButton : MonoBehaviour
{
    [SerializeField] 
    private Button _numberButton;
    [SerializeField] 
    private TMP_Text _numberText;

    private int number;

    private void Start()
    {
        number = int.Parse(_numberText.text);
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
        if (GlobalVariables.SelectedNumberCell == null) return;

        GlobalVariables.SelectedNumberCell.CellText.text = _numberText.text;

        switch (GlobalVariables.CurrentGameMode) {
            case GlobalVariables.GameMode.Play:
                GlobalVariables.SelectedNumberCell.CellText.fontStyle = FontStyles.Normal;
                break;
            case GlobalVariables.GameMode.Edit:
                GlobalVariables.SelectedNumberCell.CellText.fontStyle = FontStyles.Bold;
                GlobalVariables.LockableButtons.Add(GlobalVariables.SelectedNumberCell.CellButton);
                break;
        }

        GlobalVariables.ResetSelectedNumberCell();
    }
}
