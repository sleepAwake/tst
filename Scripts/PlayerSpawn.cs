using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    Text nickname;

    [SerializeField]
    float minposX, maxposX, minposY, maxposY;

    PhotonView view;
    void Start()
    {
        Vector2 pos = new Vector2(Random.Range(minposX, maxposX), Random.Range(minposY, maxposY));

        GameObject p = PhotonNetwork.Instantiate(player.name, pos, Quaternion.identity) as GameObject;

        p.name = "Player" + PhotonNetwork.PlayerList.Length;

        nickname.text = "Player" + PhotonNetwork.PlayerList.Length;
    }

}
