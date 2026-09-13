using Unity.Netcode;
using UnityEngine;

public class Coin : NetworkBehaviour
{
    public int points = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (!IsServer)
            return;

        PlayerNetwork player = other.GetComponent<PlayerNetwork>();

        if (player == null)
            return;

        player.Score.Value += points;

        AnnounceCollectionClientRpc(
            player.OwnerClientId,
            points
        );

        NetworkObject.Despawn();
    }

    [ClientRpc]
    private void AnnounceCollectionClientRpc(
        ulong playerId,
        int pointsEarned)
    {
        string msg =
            $"Player {playerId + 1} collected a Coin! +{pointsEarned} Points";

        Debug.Log(msg);

        if (AnnouncementManager.Instance != null)
        {
            AnnouncementManager.Instance.ShowAnnouncement(msg);
        }
    }
}