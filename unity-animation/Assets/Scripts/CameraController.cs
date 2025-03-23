using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    private Transform trsf;
    private Vector3 offset;
    //private Quaternion cameraRotation;

    public GameObject player;
    public float turnSpeed = 4f;

    public bool isInverted; // Toggle in the Inspector

    void Start()
    {
        trsf = GetComponent<Transform>();
        offset = trsf.position - player.transform.position;

        //cameraRotation = trsf.rotation; // save orientation

        isInverted = PlayerPrefs.GetInt("InvertY", 0) == 1; // Load the saved invert setting from PlayerPrefs
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * turnSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * turnSpeed;

        // Apply Y-axis inversion if enabled
        if (isInverted)
        {
            mouseY = -mouseY; // Invert the mouse Y movement
        }
        
        offset = Quaternion.AngleAxis(mouseX, Vector3.up) * 
            Quaternion.AngleAxis(mouseY, Vector3.left) * offset; // Rotate the camera base on mouse mouvement

        // Update camera position
        trsf.position = player.transform.position + offset;
        transform.LookAt(player.transform.position);

        // Reset camera if player falls
        if (player.transform.position.y < -10f) // Same threshold as in PLayerController
        {
            ResetCamera();
        }
    }

    private void ResetCamera()
    {
        trsf.position = player.transform.position + offset;
    }
}
