using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMana : MonoBehaviour
{
    public static BuildMana instace;
    public GameObject torretaStandard;
    public GameObject torretaFire;
    public GameObject torretaPlasma;
    private BluepintTurret turretToBuild;

    public GameObject buildEffect;

    void Awake ()
    {
        if (instace != null)
        {
            Debug.LogError("Mas de un administrador de edicion en escena");
            return;
        }
        instace= this;
    }
   public bool CanBuild {get{return turretToBuild!= null;}}
   public bool HasMoney {get{return Currency.moneda >= turretToBuild.cost;}}
   public void BuildTurreOn (Nodos nodo)
   {
       if (Currency.moneda< turretToBuild.cost)
       {
           Debug.Log("No tienes Dinero suficiente para comprar");
           return;
       }
        Currency.moneda -= turretToBuild.cost;

       GameObject torre=(GameObject) Instantiate(turretToBuild.prefad, nodo.GetBuildPosition(), Quaternion.identity);
       nodo.torreta= torre;

       GameObject effect=(GameObject)Instantiate(buildEffect, nodo.GetBuildPosition(), Quaternion.identity);
       Destroy(effect, 5f);

       Debug.Log("Torreta Costruida! Dinero restante: "+ Currency.moneda);
   }
    public void SetTurrentBuild(BluepintTurret turret)
    {
        turretToBuild= turret;
    }
}
