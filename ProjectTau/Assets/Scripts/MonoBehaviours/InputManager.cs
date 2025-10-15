using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance = null;

    public DefaultInputSystem inputs;
    DefaultInputSystem.PlayerActions actions;

    bool isMoveEngaged = false;
    Vector2 moveDelta;
    float zoomDelta;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            inputs = new();
            inputs.Enable();
            actions = inputs.Player;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        isMoveEngaged = actions.ActivateMove.IsPressed();
        if (isMoveEngaged)
        {
            moveDelta = actions.Move.ReadValue<Vector2>();
        }
        zoomDelta = actions.Zoom.ReadValue<float>();
    }

    public bool IsMoveEngaged() => isMoveEngaged;
    public Vector2 MoveDelta()
    {
        if (isMoveEngaged)
        {
            return moveDelta;
        }
        return Vector2.zero;
    }
    public float ZoomDelta() => zoomDelta;
}
