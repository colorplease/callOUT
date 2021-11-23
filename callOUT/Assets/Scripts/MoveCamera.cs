using UnityEngine;

public class MoveCamera : MonoBehaviour {

     [SerializeField] private float sensX;
    [SerializeField] private float sensY;

    Camera cam;

    float mouseX;
    float mouseY;

    [SerializeField] float mouseMultiplier = 0.01f;

    float xRotation;
    float yRotation;

    void Start()
    {
        cam = GameObject.Find("eyes").GetComponent<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        MyInput();
        ControlCamera();
    }

    void MyInput()
    {
        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");

        yRotation += mouseX * sensX * mouseMultiplier * 2;
        xRotation -= mouseY * sensY * mouseMultiplier * 2;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

    }

    void ControlCamera()
    {
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
