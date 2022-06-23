using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class IsometricCamera : MonoBehaviour
{
    public float scrollSpeed = 5f;
    public GameObject target;
    // Start is called before the first frame update
    private Camera camera;
    public InputActionReference scroll;

    void Start()
    {
        camera=GetComponent<Camera>();
        scroll.action.Enable();
        scroll.action.performed += (ctx) =>
        {
            camera.orthographicSize -= ctx.ReadValue<float>() * scrollSpeed * Time.deltaTime;
        };
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float distance = 25;

        transform.position = target.transform.position + new Vector3(-30, 25, -30);
        //transform.position = target.transform.position + new Vector3(-5, 5, -5);

        //transform.position = Vector3.Lerp(transform.position, target.transform.position + new Vector3(-25, 25, -25), 0.5f * Time.deltaTime);
        //camera.transform.LookAt(target.transform);
    }
}
