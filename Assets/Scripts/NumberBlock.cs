using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberBlock : MonoBehaviour
{
    [SerializeField]
    private List<NumberCell> _numberCells;

    private void OnEnable()
    {
        GlobalVariables.NumberCellClicked += HighlightSameNumbers;
        GlobalVariables.NumberCellEntered += ResetHighlightedNumbers;
    }

    private void OnDisable()
    {
        GlobalVariables.NumberCellClicked -= HighlightSameNumbers;
        GlobalVariables.NumberCellEntered -= ResetHighlightedNumbers;
    }

    private void HighlightSameNumbers()
    {
        foreach (var cell in _numberCells)
        {
            if (cell == null || cell.CellText.text.Equals(string.Empty)) continue;

            if(GlobalVariables.SelectedNumberCell.CellText.text == cell.CellText.text)
            {
                cell.CellImage.color = Color.yellow;
            }

            if (GlobalVariables.SelectedNumberCell.CellText.text != cell.CellText.text && cell.CellImage.color == Color.yellow)
            {
                cell.CellImage.color = Color.white;
            }
        }
    }

    private void ResetHighlightedNumbers()
    {
        foreach (var cell in _numberCells)
        {
            if (cell == null || cell.CellText.text.Equals(string.Empty)) continue;

            if(cell.CellImage.color ==  Color.yellow)
            {
                cell.CellImage.color = Color.white;
            }
        }
    }
}
