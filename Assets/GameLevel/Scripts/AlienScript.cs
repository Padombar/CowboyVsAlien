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
    private Animation animation;
    private bool sawPlayer;
    private string nextAnimation = "";
    private bool aiming;
    private bool dieAfterAnimation;
    private bool nowYouCanDie;


    // Use this for initialization
    void Start()
    {
        alienHit = GameObject.Find("Alien_wird_getroffen").GetComponent<AudioSource>();
        player = GameObject.FindWithTag("Player");
        laser = GameObject.Find("Laser Sound").GetComponent<AudioSource>();
        animation = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {

        if (dieAfterAnimation)
        {
            if (nowYouCanDie && !animation.isPlaying)
            {
                Destroy(gameObject);
            }

            if (!animation.IsPlaying("rig|action_dying_while_aiming"))
            {
                animation.Play("rig|action_dying_while_aiming");
                nowYouCanDie = true;
            }
        }

        //ROTATE Alien towards player and onyl rotate around the y axis
        Quaternion old = transform.rotation;
        Vector3 playerPos = player.transform.position;
        transform.LookAt(playerPos);
        transform.rotation = new Quaternion(old.x, transform.rotation.y, old.z, old.w);

        Vector3 rayStart2 = transform.position;
        rayStart2.y += 2;
        Ray playeRay2 = new Ray(rayStart2, playerPos - rayStart2);
        RaycastHit info2;
        if (!sawPlayer && Physics.Raycast(playeRay2, out info2, 2000))
        {
            if (info2.collider.CompareTag("Player"))
            {
                sawPlayer = true;
            }
        }


        if (!animation.isPlaying && nextAnimation != "")
        {
            animation.Play("rig|"+nextAnimation);
        }

        if (!sawPlayer)
        {
            nextAnimation = "action_resting";
        }

        if (sawPlayer && !aiming)
        {
            nextAnimation = "resting_to_aiming";
            aiming = true;
        }


        if (aiming && timeSinceLastShot > shootingSpeed + Util.Random.NextDouble()*4)
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
                    if (!animation.IsPlaying("rig|action_shooting"))
                    {
                        nextAnimation = "action_shooting";
                    }
                    else
                    {

                        Vector3 shotstart = transform.position;
                        for (int i = 0; i < transform.childCount; i++)
                        {
                            if (transform.GetChild(i).gameObject.name == "ShootPoint")
                            {
                                shotstart = transform.GetChild(i).position;
                            }
                        }
                        ShootAtPlayer(shotstart, playerPos);
                    }
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
            dieAfterAnimation = true;
        }
    }
    
    private void ShootAtPlayer(Vector3 spawnpoint,Vector3 player)
    {
        GameObject shot = Instantiate(munition, spawnpoint, munition.transform.rotation) as GameObject;
        laser.Play();
        shot.GetComponent<Rigidbody>().AddForce((player - spawnpoint).normalized * 50, ForceMode.VelocityChange);
        
    }
}