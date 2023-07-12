using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject Player;
    public float MinX, MaxX;

    private void Start()
    {
        Vector2 _randomPosition = new Vector2(Random.Range(MinX, MaxX), 0f);
        PhotonNetwork.Instantiate (Player.name, _randomPosition, Quaternion.identity);
    }
}
