using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretBlueprint
{
    //Turret stats
    public GameObject Prefab;
    public int cost;

    public GameObject firstUpgradePrefab;
    public int firstUpgradeCost;

    public GameObject secondUpgradePrefab;
    public int secondUpgradeCost;

    public int GainSoldTurretCost()
    {
        return cost / 2;
    }

}
