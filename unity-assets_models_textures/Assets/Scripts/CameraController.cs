using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;

    public float mouseSpeed = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // get mouse input
        
        if(Input.GetMouseButton(1))
        {
            offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * mouseSpeed, Vector3.up) * Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * mouseSpeed, Vector3.left) * offset;
            transform.position = player.transform.position + offset;
            transform.LookAt(player.transform.position);
        }
        else
        {
            transform.position = player.transform.position + offset;
        }
        
        /*
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * mouseSpeed, Vector3.up) * Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * mouseSpeed, Vector3.left) * offset;
        transform.position = player.transform.position + offset;
        transform.LookAt(player.transform.position);*/
    }
}
