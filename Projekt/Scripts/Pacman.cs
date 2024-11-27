using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacman : MonoBehaviour
{
    public GameObject[] portals;

    public Vector3 maxVelocity;

    Vector3 startPost;
    // Start is called before the first frame update
    void Start()
    {
        startPost = transform.position;
    }
   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("AboveMap"))
        {
            transform.position = startPost;
            gameObject.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Point"))
        {
            this.gameObject.GetComponent<AudioSource>().Play();
            other.gameObject.SetActive(false);
            other.gameObject.GetComponent<PointScript>().particleEffect.SetActive(true);

            other.gameObject.GetComponent<PointScript>().particleEffect.transform.parent = null;
            //Destroy(other.gameObject.GetComponent<PointScript>().particleEffect, 10);
            //Destroy(other.gameObject);
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().score++;

        }
        /* Not used yet
        if (other.gameObject.CompareTag("Portal"))
        {
            Vector3 oldVel = gameObject.GetComponent<Rigidbody>().linearVelocity;
            Vector3 oldTransform = transform.position;
            if (other.gameObject.name == "Portal01Left")
            {

                gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
                gameObject.GetComponent<Rigidbody>().linearVelocity = new Vector3(Mathf.Clamp(oldVel.x, -maxVelocity.x, maxVelocity.x), 0, 0) * -1;
                gameObject.transform.position = new Vector3(portals[2].gameObject.transform.position.x, oldTransform.y, portals[2].gameObject.transform.position.z);
            }
            else if (other.gameObject.name == "Portal02Left")
            {
                gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
                gameObject.GetComponent<Rigidbody>().linearVelocity = new Vector3(Mathf.Clamp(oldVel.x, -maxVelocity.x, maxVelocity.x), 0, 0) * -1;
                gameObject.transform.position = new Vector3(portals[3].gameObject.transform.position.x, oldTransform.y, portals[3].gameObject.transform.position.z);
            }
            if (other.gameObject.name == "Portal01Right")
            {
                gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
                gameObject.GetComponent<Rigidbody>().linearVelocity = new Vector3(Mathf.Clamp(oldVel.x, -maxVelocity.x, maxVelocity.x), 0, 0) * -1;
                gameObject.transform.position = new Vector3(portals[0].gameObject.transform.position.x, oldTransform.y, portals[0].gameObject.transform.position.z);
            }
            if (other.gameObject.name == "Portal02Right")
            {
                gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
                gameObject.GetComponent<Rigidbody>().linearVelocity = new Vector3(Mathf.Clamp(oldVel.x, -maxVelocity.x, maxVelocity.x), 0, 0) * -1;
                gameObject.transform.position = new Vector3(portals[1].gameObject.transform.position.x, oldTransform.y, portals[1].gameObject.transform.position.z);
            }
        }*/
    }
}
