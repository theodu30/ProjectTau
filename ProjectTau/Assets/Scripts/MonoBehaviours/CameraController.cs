using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform tr;

    public float CameraPanningSpeed = 5f;

    private void Awake()
    {
        tr = transform;
    }

    private void Update()
    {
        // Pan with Right-Click
        // Zoom with MouseWheel

        if (InputManager.instance.IsMoveEngaged())
        {
            Vector2 move = InputManager.instance.MoveDelta();
            Vector3 movement = -move.y * tr.forward + -move.x * tr.right;
            tr.position += CameraPanningSpeed * Time.deltaTime * movement;
        }
    }
}
