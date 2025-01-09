using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 20f;
    private float turnSpeed = 45f;
    private float horizontalInput = 0;
    private float forwardInput = 0;
    public Camera mainCamera;
    public Camera secondCamera;
    private bool isSecondCameraActive = true;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera.gameObject.SetActive(true);
        secondCamera.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * Time.deltaTime * forwardInput * speed);
        transform.Rotate(Vector3.up * Time.deltaTime * horizontalInput * turnSpeed);

        if (Input.GetButtonDown("switch camera"))
        {
            isSecondCameraActive = !isSecondCameraActive;
            mainCamera.gameObject.SetActive(!isSecondCameraActive);
            secondCamera.gameObject.SetActive(isSecondCameraActive);
        }
    }
}