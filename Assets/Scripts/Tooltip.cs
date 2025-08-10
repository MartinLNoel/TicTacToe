using UnityEngine;
using TMPro;

public class Tooltip : MonoBehaviour
{
    public GameObject tooltip;           // The panel that shows the tooltip
    public TextMeshProUGUI tooltipTitle;
    public TextMeshProUGUI tooltipDescription;
    public TextMeshProUGUI gameMode;

    public void ShowTooltip()
    {
        tooltip.SetActive(true);         // Show tooltip

        if (gameMode.text == "Classic")
        {
            tooltipTitle.text = "Classic Mode";
            tooltipDescription.text =
            "\n1. First to 3 in a row wins." +
            "\n2. Ends when board is full or someone wins.";
        }
        else if (gameMode.text == "Roman")
        {
            tooltipTitle.text = "Roman Mode";
            tooltipDescription.text =
            "\n1. First to 3 in a row wins." +
            "\n 2. Each player has 3 tokens." +
            "\n3. Once all tokens placed, remove 1 to place another.";
        }
    }

    public void HideTooltip()
    {
        tooltip.SetActive(false);        // Hide tooltip
    }
}
