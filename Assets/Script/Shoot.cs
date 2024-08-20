using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject Projectile;
    public GameObject[] FireFeedback;
    public Transform ProjectileSpawnPos;

    private bool _canShoot = true;
    public float ShootCD;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && _canShoot == true)
        {
            StartCoroutine(Shooting());
        }
    }

    IEnumerator Shooting()
    {
        _canShoot = false;

        foreach (GameObject feedback in FireFeedback) 
        {
            GameObject feedbacks = GameObject.Instantiate(feedback, ProjectileSpawnPos.position, ProjectileSpawnPos.rotation);
            Destroy(feedbacks,1f);
        }

        GameObject.Instantiate(Projectile, ProjectileSpawnPos.position, ProjectileSpawnPos.rotation);
        yield return new WaitForSeconds(ShootCD);
        _canShoot = true;
    }
}
