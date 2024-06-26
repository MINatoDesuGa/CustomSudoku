using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberBlock : MonoBehaviour
{
    [SerializeField]
    private List<NumberCell> _numberCells;

    private void OnEnable()
    {
        GameEventManager.NumberCellClicked += HighlightSameNumbers;
        GameEventManager.NumberCellEntered += ResetHighlightedNumbers;
        TouchFunctions.OnDoubleTap += ResetHighlightedNumbers;
        GameEventManager.OnReset += OnReset;
    }

    private void OnDisable()
    {
        GameEventManager.NumberCellClicked -= HighlightSameNumbers;
        GameEventManager.NumberCellEntered -= ResetHighlightedNumbers;
        TouchFunctions.OnDoubleTap -= ResetHighlightedNumbers;
        GameEventManager.OnReset -= OnReset;
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
    private void OnReset()
    {
        foreach (var cell in _numberCells)
        {
            cell.CellText.text = string.Empty;
            
        }
    }
}
