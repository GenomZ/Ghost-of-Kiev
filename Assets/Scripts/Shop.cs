using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void PurchuseGroundTurret()
    {
        Debug.Log("Ground Turret Selected");
        buildManager.SetTurretToBuild(buildManager.groundTurretPrefab);
    }

    public void PurchuseAATurret()
    {
        Debug.Log("AA Turret Selected");
        buildManager.SetTurretToBuild(buildManager.aaTurretPrefab);
    }

    public void PurchuseBlockadeTurret()
    {
        Debug.Log("Blockade Selected");
        buildManager.SetTurretToBuild(buildManager.blockadePrefab);
    }
}
