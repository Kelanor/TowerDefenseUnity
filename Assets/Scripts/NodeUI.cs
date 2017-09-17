using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour 
{
	public GameObject ui;
    public Button upgradeButton;
    public Text upgradeCost;

	private Node target;

	public void SetTarget(Node t)
	{
		target = t;

		transform.position = target.BuildPosition;

        if (!t.isUpgraded)
        {
            upgradeCost.text = "$" + t.turretBlueprint.upgradeCost;
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "DONE";
            upgradeButton.interactable = false;
        }

		ui.SetActive(true);
	}

	public void Hide()
	{
		ui.SetActive(false);
	}

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }
}
