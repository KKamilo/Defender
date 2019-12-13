using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorEnemy : MonoBehaviour
{
    public GameObject enemigo1;
    public GameObject enemigo2;

    public GameObject enemigo3;

    [Space]
    public int numeroEnemigosOleada;
    public float  frecuanciEnemigo= 5;
    [Space]
    public int numOleadas;
    public float  frecuanciaOleadas=5;

    int contadorDeOleada = 0;
    int contadorDeOleadas = 0;
    bool oleadaEnCurso = true;
    
    void Awake()
    {
        numeroEnemigosOleada= Random.Range(2,15); 
        numOleadas= Random.Range(2,5); 
    }
    void Start()
    {  
           
        CrearOleadas();
    }
    void FixedUpdate()
    {
        if (!oleadaEnCurso)
        {
            if (contadorDeOleadas < numOleadas)
            {
                oleadaEnCurso = true;
                Invoke("CrearOleadas", frecuanciaOleadas);
            }
        }
        else
        {
            contadorDeOleadas=0;
        }
    }
    void CrearEnemigo()
    {
        if (GameManager.gameIsOver== false)
        {
            int n = Random.Range(0,3);
            GameObject enemigo;
            switch(n)
            {
            case 0:
                enemigo = Instantiate(enemigo1, transform.position, Quaternion.identity);

            break;
            case 1:
                enemigo = Instantiate(enemigo2, transform.position, Quaternion.identity);

            break;
            case 2:
                enemigo = Instantiate(enemigo3, transform.position, Quaternion.identity);

            break;
            }
        }
        
    }

    void LlamarOleada()
    {
        CrearOleada(numeroEnemigosOleada, frecuanciEnemigo);
    }
    void CrearOleada(int numEnemy, float frecuencia)
    {
        CrearEnemigo();
        contadorDeOleada++;
        if (contadorDeOleada < numEnemy)
        {
            oleadaEnCurso = true;
            Invoke("LlamarOleada", frecuencia);
        }
        else
        {
            CancelInvoke("LlamarOleada");
            contadorDeOleada = 0;
            oleadaEnCurso = false;
        }
    }
    void CrearOleadas()
    {
        CrearOleada(numeroEnemigosOleada, frecuanciEnemigo);
        contadorDeOleadas++;
    }
}
