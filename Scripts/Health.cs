using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{   
    GameObject hpbar;

    public float maxvalue, currentvalue;

    [SerializeField]
    Vector3 offset;

    void Awake()
    {
        hpbar = GameObject.Find("Image");

        currentvalue = maxvalue;
    }

    void Update()
    {
        hpbar.GetComponent<Image>().fillAmount = currentvalue / maxvalue;

        hpbar.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position + offset;
    }

    public void TakeDmg(int dmg)
    {
        currentvalue -= dmg;
    }
 
}
