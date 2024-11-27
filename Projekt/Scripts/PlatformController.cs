using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public float clampxPos, clampxNeg;
    public float clampyPos, clampyNeg;
    public float speed;

    float value = 0;

    public GameObject pacman;

    public bool isPlaying = true;

    public GameObject[] points;
    private float elapsedTime;
    public float interval;


    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= interval)
            {
                foreach (GameObject point in points)
                {
                    point.SetActive(true);
                }
                elapsedTime = 0f;
            }


            if (Input.GetKey(KeyCode.S))
            {
                gameObject.transform.Rotate(new Vector3(0, 0, 1), Space.Self);

            }
            if (Input.GetKey(KeyCode.A))
            {
                gameObject.transform.Rotate(new Vector3(0, 1, 0), Space.Self);
            }
            if (Input.GetKey(KeyCode.D))

            {
                gameObject.transform.Rotate(new Vector3(0, -1, 0), Space.Self);
            }

            if (Input.GetKey(KeyCode.Q))
            {
                gameObject.transform.Rotate(new Vector3(-1, 0, 0), Space.Self);
                pacman.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                pacman.transform.parent = this.transform;

            }
            if (Input.GetKey(KeyCode.E))
            {
                gameObject.transform.Rotate(new Vector3(1, 0, 0), Space.Self);
                pacman.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                pacman.transform.parent = this.transform;

            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                pacman.transform.parent = null;
                pacman.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            }
            if (Input.GetKeyUp(KeyCode.Q))
            {
                pacman.transform.parent = null;
                pacman.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                pacman.transform.position = new Vector3(-4.429534f, 1, 10.7351f);
            }
        }
    }

}
