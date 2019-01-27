using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        if (player.transform.position.x + offset.x > -7 && player.transform.position.x + offset.x < 408.0)
            transform.position = new Vector3(player.transform.position.x + offset.x, 10, -10);
    }

    public void ResetCamera()
    {
        transform.position = new Vector3(0, 0, -10);
    }
}
