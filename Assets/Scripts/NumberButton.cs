using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NumberButton : MonoBehaviour
{
    [SerializeField] private Button numberButton;
    [SerializeField] private TMP_Text numberText;

    private int number;

    private void Start()
    {
        number = int.Parse(numberText.text);
    }

    private void OnEnable()
    {
        numberButton.onClick.AddListener(OnNumberButtonClick);
    }

    private void OnDisable()
    {
        numberButton.onClick.RemoveListener(OnNumberButtonClick);
    }

    private void OnNumberButtonClick()
    {
        NumberCell __selectedNumberCell = GameManager.instance.SelectedNumberCell;
        if (__selectedNumberCell != null)
        {
            __selectedNumberCell.cellText.text = numberText.text;

            if(GameManager.isEditMode)
            {
                __selectedNumberCell.cellText.fontStyle = FontStyles.Bold;
            } else
            {
                __selectedNumberCell.cellText.fontStyle = FontStyles.Normal;
            }

            __selectedNumberCell.cellImage.color = Color.white;

            GameManager.LockedButtons.Add(__selectedNumberCell.cellButton);
            GameManager.instance.SelectedNumberCell = null;
        }
    }
}
