using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
public class PlaneController : MonoBehaviour
{

    public GameObject plane;

    public Vector3 shotDIr;
    public TMP_Text points;

    public bool isPlaneGame;


    public Vector3[] yawVector;
    public Vector3[] pitchVector;

    public Vector3[] postVector;

    public GameObject bulletSpawnPoint;
    public GameObject bullet;
    public AudioClip bulletClip;
    public AudioSource bulletSource;
    public AudioSource propSource;


    public ParticleSystem fireEffect;

    public int score;
    public TMP_Text pointText;


    // Update is called once per frame
    private void Start()
    {
        pointText.transform.parent.gameObject.SetActive(false);
    }
    void Update()
    {
        if (!isPlaneGame)
        {
            score = 0;

        }
        if (isPlaneGame)
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                GunFire();
            }

            //Brug lerp til fly controls. Til feks tilting
            //Tilt op skal også bruge lidt lerp så det ikke ser så jagged ud. Så den f.eks. flyver op på den rigtige højde

            if (Input.GetKeyDown(KeyCode.A))
            {
                transform.position = postVector[0];
                transform.eulerAngles = yawVector[0];

            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                transform.position = postVector[2];
                transform.eulerAngles = yawVector[2];
            }
            else if (!Input.anyKey)
            {
                transform.position = postVector[1];
                transform.eulerAngles = yawVector[1];
            }
        }
        else
        {
            propSource.Pause();
        }
    }
    void GameOver()
    {
        pointText.text = $"Points:{score}";
        pointText.transform.parent.gameObject.SetActive(true);
    }
    void GunFire()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(bulletSpawnPoint.transform.position, shotDIr, out hitInfo))
        {
            Debug.DrawRay(bulletSpawnPoint.transform.position, shotDIr * hitInfo.distance, Color.yellow);
            GameObject hitTarget = hitInfo.transform.gameObject;
            if (hitTarget.tag == "Point")
            {
                score++;
            }
            Destroy(hitTarget);

        }
        bulletSource.Play();
        ParticleSystem newPS = Instantiate(fireEffect, fireEffect.transform.position, fireEffect.transform.rotation);
        newPS.Play();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            if (isPlaneGame)
            {
                GameOver();
            }
        }
    }
}
