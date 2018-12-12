using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform Rectile_Camera;
    public float range = 20f;

    public GameObject Bullet_Emitter;
    public GameObject Bullet;

    public float Bullet_Speed;

    // Use this for initialization
    void Start()
    {
        StartCoroutine("ShootBullet");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Rectile_Camera != null)
        {
            transform.LookAt(Rectile_Camera);
            transform.rotation *= Quaternion.Euler(0, 120, 0);
        }
    }
 
    IEnumerator ShootBullet()
    {
        while(true)
        {
            yield return new WaitForSeconds(3.5f);
            GameObject Temporary_Bullet;
            Temporary_Bullet = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;
            Temporary_Bullet.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
            Rigidbody Temporary_RigidBody = Temporary_Bullet.GetComponent<Rigidbody>();
            Temporary_RigidBody.AddForce(Bullet_Emitter.transform.forward * Bullet_Speed);
            Destroy(Temporary_Bullet, 10.0f);
        }
    }
}