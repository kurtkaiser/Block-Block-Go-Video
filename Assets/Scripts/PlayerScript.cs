using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody rigid;
    public float moveForce = 50.0f;
    public CameraScript mainCamera;
    private int level = 1;
    public Text levelText;

    public GameManager gameManager;

    void Update()
    {
        if (Input.GetKey("up") || Input.GetKey("w"))
        {
            rigid.AddForce(0, 0, moveForce * Time.deltaTime, ForceMode.VelocityChange);
            mainCamera.SetDirection("up");
        }
        if (Input.GetKey("down") || Input.GetKey("s"))
        {
            rigid.AddForce(0, 0, -moveForce * Time.deltaTime, ForceMode.VelocityChange);
            mainCamera.SetDirection("down");
        }
        if (Input.GetKey("right") || Input.GetKey("d"))
        {
            rigid.AddForce(moveForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            mainCamera.SetDirection("right");
        }
        if (Input.GetKey("left") || Input.GetKey("a"))
        {
            rigid.AddForce(-moveForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            mainCamera.SetDirection("left");
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        
        if (collider.tag == "Exit")
        {
            PlayerRespawn();
            level = level + 1;
            moveForce += 20.0f;
            gameManager.NextLevel();
        }
        levelText.text = level.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            // Ground Color 
            Color[] options = { Color.white, Color.black, Color.green };
            Color newColor = options[Random.Range(0, options.Length)];
            GameObject.Find("Ground").GetComponent<Renderer>().material.color = newColor;
            level = 1;
            moveForce = 25.0f;
            PlayerRespawn();
        }
        levelText.text = level.ToString();
    }

    void PlayerRespawn()
    {
        transform.position = new Vector3(12.25f, 1.5f, -13.5f);
        transform.rotation = Quaternion.Euler(-90, 0, 90);
    }
}
