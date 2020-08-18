using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    void Start()
    {
        ChangeColor();
    }

    public void ChangeColor() 
    {
        // Change Color 
        Color[] options = { Color.red, Color.green, Color.magenta, Color.yellow, Color.cyan};
        Color newColor = options[Random.Range(0, options.Length)];
        gameObject.GetComponent<Renderer>().material.color = newColor;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            ChangeColor();
        }
    }
}
