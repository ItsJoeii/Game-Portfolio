using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffSet;

    public GameObject notEnoughForUpgradePopUp;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    void Start()
    {
        //Gets the start color from the nodes
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    void Update()
    {

    }

    public Vector3 GetBuildPosition()
    {
        //Change the position of the turret
        return transform.position + positionOffSet;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        //If there is no turret it will select the node
        if(turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        //If it's able to build it will continue the script
        if (!buildManager.AbleToBuild)
            return;

        BuildTurret(buildManager.GetTurretToBuild());
    }

    void BuildTurret(TurretBlueprint blueprint)
    {
        //If the player doesn't have enough money to buy a turret
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Not enough money to build the turret");

            return;
        }

        //The money gets subtracted of the player
        PlayerStats.Money -= blueprint.cost;

        //Builds the turret
        GameObject _turret = (GameObject)Instantiate(blueprint.Prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBlueprint = blueprint;

        //Spawns a particlesystem and destroys itself after 5 seconds
        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        //Plays a sound
        FindObjectOfType<AudioManager>().Play("BuildSound");

        Debug.Log("Turret build.");
    }

    public void FirstUpgradeTurret()
    {
        //If the player doesn't have enough money to upgrade the turret it will activate the notEnoughForUpgradePopUp
        if (PlayerStats.Money < turretBlueprint.firstUpgradeCost)
        {
            Debug.Log("Not enough money to upgrade the turret");
            notEnoughForUpgradePopUp.SetActive(true);
            StartCoroutine("UpgradePopUp");
            return;
        }
        else
        {
            //If the player has enough money to upgrade the turret it will subtract the money of the player, destroys the old turret and puts a new turret on top of it and spawns a particlesystem for 5 seconds that destroys itself after
            //It also sets the isUpgraded boolean to true
            PlayerStats.Money -= turretBlueprint.firstUpgradeCost;

            FindObjectOfType<AudioManager>().Play("UpgradeTurret");

            //Destroy the current turret
            Destroy(turret);

            //Build upgraded turret
            GameObject _turret = (GameObject)Instantiate(turretBlueprint.firstUpgradePrefab, GetBuildPosition(), Quaternion.identity);
            turret = _turret;

            GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
            Destroy(effect, 5f);

            isUpgraded = true;

            Debug.Log("Turret upgraded.");
        }


    }

    IEnumerator UpgradePopUp()
    {
        //Waits for 3 seconds to deactivate the notEnoughForUpgradePopUp gameobject
        yield return new WaitForSeconds(3f);
        notEnoughForUpgradePopUp.SetActive(false);

    }

    public void SellTurret()
    {
        //The player sells the turret and gets X amount of gold. It spawns a particlesystem that destroys itself after 5 seconds and the isUpgraded boolean goes to false and there wont be a turretBlueprint anymore on the node
        PlayerStats.Money += turretBlueprint.GainSoldTurretCost();

        GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        isUpgraded = false;
        Destroy(turret);
        turretBlueprint = null;
    }

    void OnMouseEnter()
    {
        //If the player has enough gold to buy the turret, the node color will go grey
        //If the player doesnt have enough gold to buy it, the node color will go red
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.AbleToBuild)
            return;

        if (buildManager.HasEnoughMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
    }

    void OnMouseExit()
    {
        //The node color will go to normal
        rend.material.color = startColor;
    }

}
