using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Nodos : MonoBehaviour
{
    BuildMana buildMana;
    private Renderer rend;
    public GameObject torreta;

    public Color hoverColor;
    public Color notEnoughMoneyColor;
    private Color startColor;
    public Vector3 positionActual;

    void Start()
    {
        rend= GetComponent<Renderer>();
       startColor= rend.material.color;

       buildMana= BuildMana.instace;
    }
    public Vector3 GetBuildPosition()
    {
        return transform.position+ positionActual;
    }
    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if(!buildMana.CanBuild)
            return;

        if (torreta != null)
        {
            Debug.Log("No se puede construir allí! TODO: Display or scrren.");
            return;
        }
        buildMana.BuildTurreOn (this);
       /* GameObject torretaBuild = buildMana.GetTurretToBuild();
        torreta= (GameObject)Instantiate(torretaBuild, transform.position+positionActual, transform.rotation);*/
    }
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }


        if(!buildMana.CanBuild)
            return;
        if (buildMana.HasMoney)
        {
            rend.material.color= hoverColor;
        }
        else
        {
            rend.material.color= notEnoughMoneyColor;
        }
        
    }
    void OnMouseExit()
    {
        rend.material.color= startColor;
    }
    
}
