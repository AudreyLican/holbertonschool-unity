using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    private Transform trsf;
    private Vector3 offset;

    public GameObject player;
    public float turnSpeed = 4f;

    public bool isInverted = false; // Toggle in the Inspector

    // Start is called before the first frame update
    void Start()
    {
        isInverted = false; // Ensure it's always unchecked at game start
        trsf = GetComponent<Transform>();
        offset = trsf.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * turnSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * turnSpeed;

        // Apply Y-axis inversion if enabled
        float invertedMouseY = isInverted ? -mouseY : mouseY;

        // Rotate the camera base on mouse mouvement
        offset = Quaternion.AngleAxis(mouseX, Vector3.up) * 
            Quaternion.AngleAxis(mouseY, Vector3.left) * offset;
        
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
