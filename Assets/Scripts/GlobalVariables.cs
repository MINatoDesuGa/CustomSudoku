using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class GlobalVariables
{
    public static Action NumberCellClicked;
    public static Action NumberCellEntered;

    public static int WinTrack;
    public enum GameMode
    {
        Play,
        Edit
    }

    public static GameMode CurrentGameMode = GameMode.Edit;
    public static HashSet<Button> LockableButtons = new HashSet<Button>();
    public static NumberCell SelectedNumberCell;
    /// <summary>
    /// resets selected number cell state (unselect)
    /// </summary>
    public static void ResetSelectedNumberCell()
    {
        if (SelectedNumberCell == null) return;

        SelectedNumberCell.CellImage.color = Color.white;
        SelectedNumberCell = null;
    }
}
