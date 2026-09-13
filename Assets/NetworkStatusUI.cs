using TMPro;
using Unity.Netcode;
using UnityEngine;

public class NetworkStatusUI : MonoBehaviour
{
    public TextMeshProUGUI statusText;

    void Update()
    {
        if (NetworkManager.Singleton == null)
        {
            statusText.text = "Not Connected";
            return;
        }

        if (NetworkManager.Singleton.IsHost)
        {
            statusText.text = "HOST";
        }
        else if (NetworkManager.Singleton.IsServer)
        {
            statusText.text = "SERVER";
        }
        else if (NetworkManager.Singleton.IsClient)
        {
            statusText.text = "CLIENT";
        }
        else
        {
            statusText.text = "Not Connected";
        }
    }
}