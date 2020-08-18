using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    void Update()
    {
        transform.position = player.position + offset;
    }

    public void SetDirection(string direction)
    {
        Vector3 temp = transform.rotation.eulerAngles;
        if(direction == "up")
        {
            offset = new Vector3(0.0f, 1.0f, -5.0f);
            temp.y = 0.0f;
        }
        else if (direction == "down")
        {
            offset = new Vector3(0.0f, 1.0f, 5.0f);
            temp.y = 180.0f;
        } else if (direction == "left")
        {
            offset = new Vector3(4.0f, 1.0f, 0.0f);
            temp.y = -90.0f;
        }
        else if (direction == "right")
        {
            offset = new Vector3(-4.0f, 1.0f, 0.0f);
            temp.y = 90.0f;
        }
        transform.rotation = Quaternion.Euler(temp);
    }
}
