using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class AutoNetworkButtons : MonoBehaviour
{
    void Start()
    {
        CreateButton("HOST", new Vector2(-10, -10), StartHost);
        CreateButton("CLIENT", new Vector2(-10, -60), StartClient);
        CreateButton("SERVER", new Vector2(-10, -110), StartServer);
    }

    void CreateButton(string text, Vector2 pos, UnityEngine.Events.UnityAction action)
    {
        Canvas canvas = FindObjectOfType<Canvas>();

        if (canvas == null)
        {
            Debug.LogError("No Canvas found in scene!");
            return;
        }

        // Create Button
        GameObject buttonObj = new GameObject(text);
        buttonObj.transform.SetParent(canvas.transform, false);

        RectTransform rect = buttonObj.AddComponent<RectTransform>();

        rect.anchorMin = new Vector2(1, 1);
        rect.anchorMax = new Vector2(1, 1);
        rect.pivot = new Vector2(1, 1);

        rect.sizeDelta = new Vector2(120, 40);
        rect.anchoredPosition = pos;

        Image image = buttonObj.AddComponent<Image>();
        image.color = Color.white;

        Button button = buttonObj.AddComponent<Button>();
        button.onClick.AddListener(action);

        // Create Text
        GameObject textObj = new GameObject("Text");
        textObj.transform.SetParent(buttonObj.transform, false);

        Text txt = textObj.AddComponent<Text>();
        txt.text = text;
        txt.alignment = TextAnchor.MiddleCenter;
        txt.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        txt.color = Color.black;

        RectTransform textRect = textObj.GetComponent<RectTransform>();
        textRect.anchorMin = Vector2.zero;
        textRect.anchorMax = Vector2.one;
        textRect.offsetMin = Vector2.zero;
        textRect.offsetMax = Vector2.zero;
    }

    public void StartHost()
    {
        if (!NetworkManager.Singleton.IsListening)
        {
            NetworkManager.Singleton.StartHost();
            Debug.Log("HOST STARTED");
        }
    }

    public void StartClient()
    {
        if (!NetworkManager.Singleton.IsListening)
        {
            NetworkManager.Singleton.StartClient();
            Debug.Log("CLIENT STARTED");
        }
    }

    public void StartServer()
    {
        if (!NetworkManager.Singleton.IsListening)
        {
            NetworkManager.Singleton.StartServer();
            Debug.Log("SERVER STARTED");
        }
    }
}