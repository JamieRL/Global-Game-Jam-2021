using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{

    protected Camera _camera;

    // Start is called before the first frame update
    void Start()
    {
         _camera = Camera.main;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 current = _camera.transform.position;
        current.y = transform.position.y;
        current.z = transform.position.z;

        transform.position = current;
    }
}
