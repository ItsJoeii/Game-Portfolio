using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretUI : MonoBehaviour
{
    private Node target;

    public GameObject ui;
    public Button upgradeButton;

    public Text upgradeCostText;
    public Text sellCostText;

    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();

        if (!target.isUpgraded)
        {
            upgradeCostText.text = target.turretBlueprint.firstUpgradeCost.ToString();
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCostText.text = "Maxed Out";
            upgradeButton.interactable = false;
        }

        sellCostText.text = target.turretBlueprint.GainSoldTurretCost().ToString();

        ui.SetActive(true);
    }

    public void HideUI()
    {
        ui.SetActive(false);
    }

    public void FirstUpgrade()
    {
        target.FirstUpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void SellTurret()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }

}
