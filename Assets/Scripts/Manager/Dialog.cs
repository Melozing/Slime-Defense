using TMPro;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI contentText;
    public TextMeshProUGUI timeText;

    public void Show(bool isShow)
    {
        gameObject.SetActive(isShow);
    }

    public void UpdateDialog(string title, string content, string timeTextNew)
    {
        if (titleText)
        {
            titleText.text = title;
        }
        if (contentText)
        {
            contentText.text = content;
        }
        if (timeText)
        {
            timeText.text = timeTextNew;
        }
    }
}
