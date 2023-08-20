using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    [SerializeField]
    GameObject cointxt, winner;

    void Update()
    {
        if (winner.activeInHierarchy)
        {
            cointxt.GetComponent<Text>().text = PlayerController.coinNum.ToString();

            if (PlayerController.defeat == true)
            {
                winner.GetComponent<Text>().text = "Player2";
            }

            else if (PlayerController.win == true)
            {
                winner.GetComponent<Text>().text = "Player1";
            }
        }
    }
}
