using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;

public class Firepoint : MonoBehaviour
{
    [SerializeField]
    GameObject bulletpf;

    [SerializeField]
    Transform firepoint;

    [SerializeField]
    float speed = 10f, firerate;

    float nextfire;

    PhotonView view;
    void Awake()
    {
        view = GetComponent<PhotonView>();
    }

    public void Fire()
    {

        if (Time.time > nextfire && view.IsMine)
        {
            nextfire = Time.time + firerate;

            GameObject bullet = Instantiate(bulletpf, firepoint.position, firepoint.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity =
                new Vector3(firepoint.position.x, firepoint.position.y, firepoint.position.z) * speed;
        }
            
    }
}
