using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    public float Joystick_Horizontal
    {
        get
        {
            return Input.GetAxis("Horizontal");
        }
    }
    public float Joystick_Vertical
    {
        get
        {
            return Input.GetAxis("Vertical");
        }
    }
    public KeyCode Button_TopLeft = KeyCode.H;
    public KeyCode Button_TopCenter = KeyCode.J;
    public KeyCode Button_TopRight = KeyCode.K;
    public KeyCode Button_BottomLeft = KeyCode.B;
    public KeyCode Button_BottomCenter = KeyCode.N;
    public KeyCode Button_BottomRight = KeyCode.K;
    void Awake()
    {
        base.Awake();
    }
}
