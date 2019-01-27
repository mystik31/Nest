using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDetector : MonoBehaviour
{
    Vector3 checkPoint;

    // Start is called before the first frame update
    void Start()
    {
        checkPoint = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10)
        {
            transform.position = checkPoint;
        }
    }
}
