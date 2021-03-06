using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startPosX, startPosY;

    public GameObject cam;
    public float parallaxEffectX;
    public float parallaxEffectY;

    // Start is called before the first frame update
    void Start()
    {
        startPosX = transform.position.x;
        startPosY = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float temp = cam.transform.position.x * (1 - parallaxEffectX);
        float distX = cam.transform.position.x * parallaxEffectX;
        float distY = cam.transform.position.y * parallaxEffectY;

        transform.position = new Vector3(startPosX + distX, startPosY + distY, transform.position.z);

        if (temp > startPosX + length) startPosX += length;
        else if (temp < startPosX - length) startPosX -= length;
    }
}
