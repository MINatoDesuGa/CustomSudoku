using UnityEngine;

public class TouchFunctions : MonoBehaviour
{
    public static System.Action OnDoubleTap;

    [SerializeField]
    private float doubleTapThreshold = 0.3f;
    private int tapCount;

    private void Update()
    {
        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                tapCount++;
                StartCoroutine(SingleOrDoubleTap());
            }
        }

    }
    private System.Collections.IEnumerator SingleOrDoubleTap()
    {
        yield return new WaitForSeconds(doubleTapThreshold);

        if (tapCount == 1)
        {
            Debug.Log("is single tapped");
            tapCount = 0;
        }
        else if (tapCount == 2)
        {
            Debug.Log("is Double tapped");
            tapCount = 0;
            OnDoubleTap?.Invoke();
            if (GlobalVariables.SelectedNumberCell == null) yield break;
            GlobalVariables.SelectedNumberCell.CellText.text = string.Empty;
            GlobalVariables.LockableButtons.Remove(GlobalVariables.SelectedNumberCell.CellButton);
            GlobalVariables.ResetSelectedNumberCell();
            
        }
    }
}
