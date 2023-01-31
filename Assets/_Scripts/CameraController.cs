using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector2 sensitivity;
    public Vector3 positionOffset;
    public Vector3 rotationOffset;
    public Transform camera;
    public PlayerController player;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (!player || !camera) return;

        Vector2 mouseMove = player.MouseDelta * sensitivity * Time.deltaTime;

        //transform.position = player.transform.position;
        //transform.Rotate(-mouseMove.y, mouseMove.x, 0f);
        //camera.position = transform.localPosition + positionOffset;
        //camera.rotation = Quaternion.Euler(rotationOffset + transform.localRotation.eulerAngles);
        //transform.rotation = Quaternion.Euler(rotationOffset + cameraHolder.rotation.eulerAngles);
    }
}
