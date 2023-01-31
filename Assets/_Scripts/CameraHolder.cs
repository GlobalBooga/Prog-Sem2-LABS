using UnityEngine;

public class CameraHolder : MonoBehaviour
{
    public Vector2 sensitivity;
    public PlayerController player;
    public Vector3 cameraHolderOffset;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }

    private void Update()
    {
        if (!player) return;

        Vector2 mouseMove = player.MouseDelta * sensitivity * Time.deltaTime;

        transform.position = player.transform.position + cameraHolderOffset;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(-mouseMove.y, mouseMove.x, 0f));

        player.moveDirection = transform.forward * player.rawIpnut.y + transform.right * player.rawIpnut.x;
     
        player.SetBodyRotation();
    }
}
