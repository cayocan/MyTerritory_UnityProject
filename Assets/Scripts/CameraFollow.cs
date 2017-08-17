using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Vector3 offset;

    private Transform playerTransform;

    private void OnEnable()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update () {
        this.transform.position = playerTransform.position + offset;
        this.transform.LookAt(playerTransform);
	}
}
