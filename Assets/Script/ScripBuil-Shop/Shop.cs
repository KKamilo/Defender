using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public BluepintTurret torretaStandard;
    public BluepintTurret  torretaFire;
    public BluepintTurret  torretaPlasma;

    BuildMana buildMana;
    void Start ()
    {
        buildMana = BuildMana.instace;
    }
    public void SelectTurrent()
    {
        Debug.Log("Torre estandar");
        buildMana.SetTurrentBuild(torretaStandard);
    }
    
    public void SelectTurrentFire()
    {
        Debug.Log("Torre de fuego");
        buildMana.SetTurrentBuild(torretaFire);

    }

    public void SelectTurrentPlasma()
    {
        Debug.Log("Torre de plasma");
        buildMana.SetTurrentBuild(torretaPlasma);

    }
}
