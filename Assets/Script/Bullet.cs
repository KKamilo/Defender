using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    public int damage=20;
    public GameObject impacto;

    public void Skeek(Transform _target)
    {
        target= _target;
    }
    

    // Update is called once per frame
    void Update()
    {
        if (target== null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir= target.position - transform.position;
        float distanciaThisFrame= speed * Time.deltaTime;

        if (dir.magnitude <= distanciaThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanciaThisFrame, Space.World);
        transform.LookAt(target);
    }

    void HitTarget()
    {
        GameObject efectoOfImpacto= (GameObject) Instantiate(impacto, transform.position, transform.rotation);
        Destroy(efectoOfImpacto,2f);

        Daño(target);
        Destroy(gameObject);
    }

    private void Daño(Transform enemy)
    {
        EnemiMover enemi= enemy.GetComponent<EnemiMover>();
        if (enemi != null)
        {
            enemi.TakeDamage(damage);
        }
        
        
    }
}
