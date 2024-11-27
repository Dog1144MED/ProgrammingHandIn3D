using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneObstacle : MonoBehaviour
{
    public Vector3 speed;
    // Update is called once per frame
    void Update()
    {
       transform.Translate(speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
