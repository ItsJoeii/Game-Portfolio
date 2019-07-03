using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake()
    {
        //Checks if there are multiple buildmanagers in the scene
        if (instance != null)
        {
            Debug.Log("There are more than 1 BuildManager in the scene");
            return;
        }

        instance = this;
    }

    public void Update()
    {
        //When you right click you deselect the turretUI
        if (Input.GetMouseButtonDown(1))
        {
            DeselectNode();
        }
    }

    public GameObject buildEffect;
    public GameObject sellEffect;

    private Node selectedNode;
    private TurretBlueprint turretToBuild;

    public TurretUI turretUI;

    public bool AbleToBuild { get { return turretToBuild != null; } }
    public bool HasEnoughMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void SelectNode(Node node)
    {
        if(selectedNode == node)
        {
            //When you click on the same node the turretUI will disappear
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;

        turretUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        //Deselects the turretUI
        selectedNode = null;
        turretUI.HideUI();
    }

    public void SelectTurretToBuild(TurretBlueprint turretBlueprint)
    {
        //When clicking in the shop the turretUI disappear if it's open
        turretToBuild = turretBlueprint;
        DeselectNode();
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }

}
