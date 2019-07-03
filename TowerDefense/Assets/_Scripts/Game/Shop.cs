using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [Header("Blueprints")]
    public TurretBlueprint standardTurret;
    public TurretBlueprint missleLauncher;
    public TurretBlueprint laserBeamer;

    BuildManager buildManager;

	// Use this for initialization
	void Start ()
    {
        buildManager = BuildManager.instance;
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    // Select the turrets in the shop
    public void SelectFirstTurret()
    {
        //Selects turret 1
        Debug.Log("First Turret Selected");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectSecondTurret()
    {
        //Selects turret 2
        Debug.Log("Second Turret Selected");
        buildManager.SelectTurretToBuild(missleLauncher);
    }

    public void SelectThirdTurret()
    {
        //Selects turret 3
        Debug.Log("Third Turret Selected");
        buildManager.SelectTurretToBuild(laserBeamer);
    }

}
