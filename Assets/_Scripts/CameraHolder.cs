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
        Quaternion mouseRot = Quaternion.Euler(-mouseMove.y, mouseMove.x, 0f);
        
        Vector3 newRot = transform.rotation.eulerAngles + mouseRot.eulerAngles;
        //newRot = new Vector3(Mathf.Clamp(newRot.x, 0f, 50f), newRot.y, 0f);
        //Debug.Log(newRot);
        transform.rotation = Quaternion.Euler(newRot);
        
        player.moveDirection = transform.forward * player.rawIpnut.y + transform.right * player.rawIpnut.x;
     
        player.SetBodyRotation();
    }
}
