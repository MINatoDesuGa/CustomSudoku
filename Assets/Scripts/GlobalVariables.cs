using System.Collections.Generic;
using UnityEngine.UI;

public static class GlobalVariables
{
    public enum GameMode
    {
        Play,
        Edit
    }

    public static GameMode CurrentGameMode = GameMode.Edit;
    public static HashSet<Button> LockedButtons = new HashSet<Button>();
    public static NumberCell SelectedNumberCell;
}
