using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb;

    [SerializeField]
    float speed;

    [SerializeField]
    InputAction input;

    Vector2 movedir = Vector2.zero;

    Vector3 minbound, maxbound;

    PhotonView phview;

    public static int coinNum;

    SpriteRenderer rend;

    GameObject endgame;

    public static bool defeat, win;

    void Start()
    {
        
        endgame = GameObject.Find("EndGame"); 

        if (endgame != null)
             endgame.SetActive(false);

        phview = GetComponent<PhotonView>();

        rend = GetComponent<SpriteRenderer>();

        coinNum = 0; 
        
        minbound = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        maxbound = Camera.main.ScreenToWorldPoint
            (new Vector3(Screen.width, Screen.height, 0));

        SetColor();
    }

    void OnEnable()
    {
        input.Enable();
    }

    void OnDisable()
    {
        input.Disable();
    }

    void Update()
    {
       
       if (phview.IsMine)
       {
            movedir = input.ReadValue<Vector2>();  
            
            rb.velocity = new Vector2(movedir.x * speed, movedir.y * speed);    
            
            SetBounds();

            SetRotation();

            CheckHealth();

       }
    }

    void SetBounds()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minbound.x + 1, maxbound.x - 1),
           Mathf.Clamp(transform.position.y, minbound.y + 1, maxbound.y - 1), transform.position.z);
    }

    void SetRotation()
    {
        if (movedir != Vector2.zero)
        {
            Quaternion targetRot = Quaternion.LookRotation(transform.forward, movedir);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRot,
                500f * Time.deltaTime);

            rb.MoveRotation(rotation);
        }
    }

    void SetColor()
    {
        if (phview.IsMine)
            rend.color = Color.green;
    }

    void CheckHealth()
    {
        var hp =  gameObject.GetComponent<Health>().currentvalue;

        if (hp <= 0 && phview != null)
        {
            endgame.SetActive(true);

            if (phview.IsMine)
                defeat = true;

            else
                win = true;
            
        }

    }
}
