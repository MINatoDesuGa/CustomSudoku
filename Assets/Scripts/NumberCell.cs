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
        GlobalVariables.SelectedNumberCell = this;
        CellImage.color = Color.yellow;
    }
}
