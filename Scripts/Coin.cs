using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    [SerializeField]
    Text cointxt;

    void Update()
    {
        cointxt.text = PlayerController.coinNum.ToString();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            StartCoroutine(CoinAdd());
        }
    }

    IEnumerator CoinAdd()
    {
        PlayerController.coinNum++;

        yield return new WaitForSeconds(0.1f);

        gameObject.SetActive(false);
    }
}
