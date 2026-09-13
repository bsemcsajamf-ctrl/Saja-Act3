using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private PlayerNetwork player;

    void Update()
    {
        if (player == null)
        {
            foreach (PlayerNetwork p in FindObjectsOfType<PlayerNetwork>())
            {
                if (p.IsOwner)
                {
                    player = p;
                    break;
                }
            }

            return;
        }

        scoreText.text =
            "Score: " + player.Score.Value;
    }
}