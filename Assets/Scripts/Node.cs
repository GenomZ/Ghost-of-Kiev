using UnityEngine.EventSystems;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    //public Vector3 positionOffset;

    private GameObject turret;

    private Renderer rend;
    private Color startColor;
    BuildManager buildManager;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    private void OnMouseDown()
    {
        if (buildManager.GetTurretToBuild() == null)
        {
            return;
        }

        
        if (turret != null)
        {
            Debug.Log("CANT BUILD HERE");
            return;
        }

        //Build a turret
        GameObject turretToBuild = buildManager.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position, transform.rotation); //transform.position + positionOffset

    }
    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        
        if (buildManager.GetTurretToBuild() == null)
        {
            return;
        }
        
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
