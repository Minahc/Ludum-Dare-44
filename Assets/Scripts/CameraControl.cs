using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void FixedUpdate() {
        Vector3 position = new Vector3(GameObject.FindGameObjectWithTag("Player").transform.position.x, GameObject.FindGameObjectWithTag("Player").transform.position.y,-10);
        transform.position = position;
    }
}
