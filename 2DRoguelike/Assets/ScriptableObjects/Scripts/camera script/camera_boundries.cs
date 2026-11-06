using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_boundries : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    public float xMin, xMax;
    public float yMin, yMax;
    void Start()
    {
        offset = transform.position - player.transform.position;
    }
    // went with a late update because i dont w
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, xMin, xMax),
            Mathf.Clamp(transform.position.y, yMin, yMax),
            transform.position.z
            );
    }
}
