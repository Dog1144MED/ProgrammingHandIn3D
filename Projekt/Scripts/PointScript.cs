using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScript : MonoBehaviour
{
    public Vector3 rotateSpeed;
    public AudioSource audioSource;
    public GameObject particleEffect;
    public float particleTime;

    void Update()
    {
        
        transform.Rotate((rotateSpeed * Time.deltaTime),Space.Self);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Pacman"))
        {
           
            gameObject.SetActive(false);
            particleEffect.SetActive(true);
            particleEffect.transform.parent = null;
            Destroy(particleEffect, particleTime);
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().score++;
            
        }
    }
}
