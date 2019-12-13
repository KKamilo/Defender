using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemiMover : MonoBehaviour
{
    public NavMeshAgent agent;
    public Camera camara;

    public float saludInicial= 100;
    public float salud;
    public int moneyGain=35;
    [Header("Unity Stuff")]
    public Image barraDeSalud;

    void Awake()
    {
        camara = Camera.main;
        salud= saludInicial;
    }
    void Start()
    {
        int n = UnityEngine.Random.Range(0, 2);
        switch(n)
        {
            case 0:
            agent.destination = GameObject.Find("Meta1").transform.position;
            //print("meta 1" +GameObject.Find("Meta1").transform.position);
            break;
            case 1:
            agent.destination = GameObject.Find("Meta2").transform.position;
            print("meta 2" +GameObject.Find("Meta2").transform.position);

            break;
        }

        Debug.Log("Ataco en meta: "+ (n+1));    
    }

    public void TakeDamage (int amount)
    {
        salud= salud- amount;
        barraDeSalud.fillAmount= salud/ saludInicial;

        if (salud<=0)
        {
            Die();
        }
    }

    private void Die()
    {
        Currency.moneda += moneyGain;
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision colicion)
    {
        if (colicion.gameObject.tag=="Player")
        {
            EndPath();
        }
    }

    private void EndPath()
    {
        Currency.lives--;
        Destroy(gameObject);
    }
}
