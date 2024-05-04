using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SudokuValidator : MonoBehaviour
{
    private int[,] _cell = new int[9,9];
    [SerializeField]
    private bool _isRowValid = false;
    [SerializeField]
    private bool _isColValid = false;
    public void UpdateCellValue(int row, int col, int value)
    {
        _cell[row, col] = value;

       // GridStatus();
        ValidateOnCellsFilled();
    }

    private void ValidateOnCellsFilled()
    {
        CheckRowsAndColumns();
    }

    private void CheckRowsAndColumns()
    {
        _isRowValid = true;
        _isColValid = true;
        for (int i = 0; i < 9; ++i)
        {
            HashSet<int> cellRows = new HashSet<int>();
            HashSet<int> cellCols = new HashSet<int> ();
            for(int j = 0; j < 9; ++j)
            {
                //row check
                if (_cell[i,j] == 0 || cellRows.Contains(_cell[i,j]))
                {
                    _isRowValid = false;
                    break;
                }
                //col check
                if (_cell[j, i] == 0 || cellCols.Contains(_cell[j, i]))
                {
                    _isColValid = false;
                    break;
                }
                cellRows.Add(_cell[i,j]);
                cellCols.Add(_cell[j, i]);
            }
            if (!_isRowValid) break;
            if (!_isColValid) break;
        }

        if( _isRowValid && _isColValid) {
            Debug.Log("Solved!");
            PlayerPrefs.SetInt("SolveCount", PlayerPrefs.GetInt("SolveCount") + 1);
            GameEventManager.OnGameOver?.Invoke();
        }

        //Debug.Log($"IsRowValid: {_isRowValid}\n IsColValid: {_isColValid}");
    }

    private void GridStatus()
    {
        print("Current Cell status:\n");
        for (int i = 0; i < 9; ++i)
        {
            string temp = "";
            for (int j = 0; j < 9; ++j)
            {
                temp += (_cell[i, j].ToString() + " ");
            }
            print(temp);
        }
    }
}
