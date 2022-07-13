using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    public GameObject groundTurretPrefab;
    public GameObject aaTurretPrefab;
    public GameObject blockadePrefab;

    //private void Start()
    //{
    //    turretToBuild = standardTurretPrefab;
    //}

    private GameObject turretToBuild = null;
    //private bool sellFlag = false;

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }
}
