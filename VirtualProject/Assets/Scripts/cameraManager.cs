using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraManager : MonoBehaviour
{
    public Camera m_Camera;
    public Transform m_player;

    void Start()
    {
    }

    void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        Vector3 position = m_player.position;
        position.Set(m_player.position.x, m_player.position.y, transform.position.z);
        m_Camera.transform.SetPositionAndRotation(position, Quaternion.identity);
    }
}
