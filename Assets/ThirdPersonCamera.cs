using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonCamera : MonoBehaviour
{
    public GameObject player;
    public GameObject camera;
    
    private float _mouseX;
    private float _mouseY;

    // Update is called once per frame
    void LateUpdate()
    {
        var direction = new Vector3(0, 0, - 10f);
        var rotation = Quaternion.Euler(_mouseY, _mouseX, 0f);
        transform.position = player.transform.position + (rotation * direction);
        camera.transform.LookAt(player.transform);
    }

    public void ChangeAngle(InputAction.CallbackContext c)
    {
        _mouseX += c.ReadValue<Vector2>().x * Time.deltaTime;
        _mouseY -= c.ReadValue<Vector2>().y * Time.deltaTime;
        _mouseY = Mathf.Clamp(_mouseY, 10f, 50f);
    }
}
