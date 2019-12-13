using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Torreta : MonoBehaviour
{
    public Transform target;
    public AudioSource disparo;

    public float rango= 10f;
    public float fireRare= 1f;
    public float FireCountdown= 0;


    public GameObject balaPrefat;
    public Transform balas;
    void Start()
    {
        InvokeRepeating("UpdateTarget",0f,0.5f);
    }

    void UpdateTarget ()
    {
        GameObject[] enemigos= GameObject.FindGameObjectsWithTag("Enemy");
        float distanciaE= Mathf.Infinity; // Mathf.Infinity es para indicar que no tenemos un enemigo identificado
        GameObject nearesEnemy= null; // Almacena al enemigo mas cercano para poder disparar
        foreach (GameObject enemy in enemigos)
        {
            float distanciAEnemy= Vector3.Distance(transform.position,enemy.transform.position);
            if(distanciAEnemy < distanciaE)
            {
                distanciaE= distanciAEnemy;
                nearesEnemy= enemy;
            }
        }
        if (nearesEnemy != null && distanciaE <= rango)
        {
            target= nearesEnemy.transform;
        }
        else
        target= null;
    }
    void Update()
    {
        if (target == null)
        {
            return;
        }
        if (FireCountdown <= 0)
        {
            Shoot();
            FireCountdown= 1f/fireRare;
        }
        FireCountdown-= Time.deltaTime;
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color= Color.green;
        Gizmos.DrawWireSphere(transform.position,rango);
    }
    void Shoot()
    {
        if(GameManager.gameIsOver== false)
        {
            GameObject bulletGO= (GameObject) Instantiate(balaPrefat,balas.position, balas.rotation);
            Bullet bullet= bulletGO.GetComponent<Bullet>();
            if (bullet != null)
            {
            bullet.Skeek(target);
            disparo.Play();
            }
        }
        
    }
    private void FixedUpdate()
    {
        transform.LookAt(target);
    }
}
