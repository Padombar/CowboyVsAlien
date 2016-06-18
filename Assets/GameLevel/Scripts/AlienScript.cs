using UnityEngine;
using System.Collections;
using Random = System.Random;

public class AlienScript : MonoBehaviour
{
    private bool onylOneHit = true;
    private AudioSource alienHit;
    private GameObject player;
    private float timeSinceLastShot = 20;
    private float shootingSpeed = 1;
    public GameObject munition;
    private AudioSource laser;
    

    // Use this for initialization
    void Start()
    {
        alienHit = GameObject.Find("Alien_wird_getroffen").GetComponent<AudioSource>();
        player = GameObject.FindWithTag("Player");
        laser = GameObject.Find("Laser Sound").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //ROTATE Alien towards player and onyl rotate around the y axis
        Quaternion old = transform.rotation;
        Vector3 playerPos = player.transform.position;
        transform.LookAt(playerPos);
        transform.rotation = new Quaternion(old.x, transform.rotation.y, old.z, old.w);


        if (timeSinceLastShot > shootingSpeed + Util.Random.NextDouble()*4)
        {
            timeSinceLastShot = 0;
            //let the raycast start higher so it is a the level of the eys
            Vector3 rayStart = transform.position;
            rayStart.y += 2;
            Ray playeRay = new Ray(rayStart, playerPos - rayStart);
            RaycastHit info;
            if (Physics.Raycast(playeRay, out info, 2000))
            {
                if (info.collider.CompareTag("Player"))
                {
                    Vector3 shotstart = rayStart;
                    shotstart.z += 0.5f;
                    ShootAtPlayer(shotstart, playerPos);
                }
            }
        }
        else
        {
            timeSinceLastShot += Time.deltaTime;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("PlayerShoot") && onylOneHit)
        {
            onylOneHit = false;
            alienHit.Play();
            Destroy(gameObject);
        }
    }
    
    private void ShootAtPlayer(Vector3 spawnpoint,Vector3 player)
    {
        GameObject shot = Instantiate(munition, spawnpoint, munition.transform.rotation) as GameObject;
        laser.Play();
        shot.GetComponent<Rigidbody>().AddForce((player - spawnpoint).normalized * 50, ForceMode.VelocityChange);
        
    }
}