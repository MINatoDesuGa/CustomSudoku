using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SudokuValidator : MonoBehaviour
{
    private int[,] _cell = new int[9,9];
    
    public void UpdateCellValue(int row, int col, int value)
    {
        _cell[row, col] = value;
    }

    private void ValidateOnCellsFilled()
    {
        CheckRows();
        CheckColumns();
    }

    private void CheckRows()
    {

    }
    private void CheckColumns()
    {

    }
}
