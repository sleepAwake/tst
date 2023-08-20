using UnityEngine;
using UnityEngine.UI;

public class NicknameFollowPlayer : MonoBehaviour
{
    [SerializeField]
    Vector3 offset;

    [SerializeField]
    Text nickname;

    void Update()
    {
        nickname.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position + offset;

    }
}
