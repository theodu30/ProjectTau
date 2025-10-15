using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform tr;
    public Transform Camera;

    public float CameraPanningSpeed = 5f;
    public Vector2 ZoomExtrema;
    public Vector4 CameraPanningExtrema;

    float zoomValue = 0f;

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
            Vector3 tempPos = tr.position + CameraPanningSpeed * Time.deltaTime * movement;
            tempPos.x = Mathf.Clamp(tempPos.x, CameraPanningExtrema.x, CameraPanningExtrema.y);
            tempPos.z = Mathf.Clamp(tempPos.z, CameraPanningExtrema.z, CameraPanningExtrema.w);
            tr.position = tempPos;
        }
        float zoomDelta = InputManager.instance.ZoomDelta();
        if (zoomDelta != 0f)
        {
            float tempZoom = zoomValue + zoomDelta;
            if (tempZoom >= ZoomExtrema.x && tempZoom <= ZoomExtrema.y)
            {
                zoomValue = tempZoom;
                Camera.position += zoomDelta * Camera.forward;
            }
        }
    }
}
