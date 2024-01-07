using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NumberCell : MonoBehaviour
{
    public Button cellButton;
    public Image cellImage;
    public TMP_Text cellText;

    private void OnEnable()
    {
        cellButton.onClick.AddListener(OnCellButtonClick);
    }

    private void OnDisable()
    {
        cellButton.onClick.RemoveListener(OnCellButtonClick);
    }

    private void OnCellButtonClick()
    {
        GameManager.instance.SelectedNumberCell = this;
        cellImage.color = Color.yellow;
    }
}
