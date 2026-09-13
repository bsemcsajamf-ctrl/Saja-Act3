using TMPro;
using UnityEngine;

public class AnnouncementManager : MonoBehaviour
{
    public static AnnouncementManager Instance;

    public TextMeshProUGUI announcementText;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowAnnouncement(string message)
    {
        announcementText.text = message;

        CancelInvoke();
        Invoke(nameof(ClearAnnouncement), 1f);
    }

    private void ClearAnnouncement()
    {
        announcementText.text = "";
    }
}