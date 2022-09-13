using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform[] playerPrefabTransforms;
    private GameObject playerCharacter;

    public override void OnStartServer()
    {
        SpawnCharacter();
    }

    private void SpawnCharacter()
    {
        if (!isServer)
        {
            return;
        }

        playerCharacter = Instantiate(playerPrefab, playerPrefabTransforms[Random.Range(0, 4)].position,
            Quaternion.identity);
        NetworkServer.SpawnWithClientAuthority(playerCharacter, connectionToClient);
    }
}