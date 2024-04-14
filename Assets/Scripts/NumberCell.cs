using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NumberCell : MonoBehaviour
{
    public Button CellButton;
    public Image CellImage;
    public TMP_Text CellText;

    private void OnEnable()
    {
        CellButton.onClick.AddListener(OnCellButtonClick);
    }

    private void OnDisable()
    {
        CellButton.onClick.RemoveListener(OnCellButtonClick);
    }

    private void OnCellButtonClick()
    {
        GlobalVariables.WinTrack = 0;
        GlobalVariables.ResetSelectedNumberCell();
        //sets selected number cell to this cell
        GlobalVariables.SelectedNumberCell = this;
        //sets color to yellow to highlight
        CellImage.color = Color.yellow;

        GameEventManager.NumberCellClicked?.Invoke();
    }
}
