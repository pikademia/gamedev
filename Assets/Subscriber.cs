using UnityEngine;
using UnityEngine.UI;

public class Subscriber : MonoBehaviour
{
    [SerializeField] GameObject NewVideoPanel;
    [SerializeField] Button linkButton;

    private void OnEnable()
    {
        Youtuber.NewVideo += OnNewVideo;
    }

    private void OnDisable()
    {
        Youtuber.NewVideo -= OnNewVideo;
    }

    void OnNewVideo(string link)
    {
        linkButton.onClick.AddListener(()=> Application.OpenURL(link));
        NewVideoPanel.SetActive(true);
    }

    public void ClosePanel()
    {
        NewVideoPanel.SetActive(false);
    }


}
