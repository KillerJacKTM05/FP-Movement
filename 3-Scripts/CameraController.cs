using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public Camera camera;

    [SerializeField] [Range(0, 10f)] private float VerticalRotationSpeed = 1f;
    [SerializeField] [Range(0, 10f)] private float HorizontalRotationSpeed = 1f;
    [SerializeField] [Range(0, 180f)] private float VerMaxCamAngle = 90f;
    [SerializeField] [Range(0, -180f)] private float VerMinCamAngle = -90f;


    private float VerRotation = 0f;
    private float HorRotation = 0f;
    private float MouseVer;
    private float MouseHor;
    void Start()
    {
        camera = Camera.main;

    }


    void Update()
    {

        GetMouseInput();
        ManageCamera();
    }

    private void GetMouseInput()
    {
        MouseVer = Input.GetAxis("Mouse Y") * VerticalRotationSpeed;
        MouseHor = Input.GetAxis("Mouse X") * HorizontalRotationSpeed;

        VerRotation -= MouseVer;
        HorRotation += MouseHor;
    }
    private void ManageCamera()
    {
        VerRotation = Mathf.Clamp(VerRotation, VerMinCamAngle, VerMaxCamAngle);
        camera.transform.eulerAngles = new Vector3(VerRotation, HorRotation, 0);
        player.transform.eulerAngles = new Vector3(0, HorRotation, 0);
    }
}
