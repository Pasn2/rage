using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject objectToFollow;
    [SerializeField] Vector2 offset;
    [SerializeField] float speed;
    
    void Update()
    {
        Vector3 newPos = new Vector3(objectToFollow.transform.position.x + offset.x, objectToFollow.transform.position.y + offset.y, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, speed * Time.deltaTime);
    }
}
