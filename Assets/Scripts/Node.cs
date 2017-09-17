using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    [HideInInspector] public GameObject turret;
    [HideInInspector] public TurretBlueprint turretBlueprint;
    [HideInInspector] public bool isUpgraded = false;

    private Renderer rend;
    private Color startColor;
    private BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;

        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    public Vector3 BuildPosition
    {
        get
        {
            return transform.position + positionOffset;
        }
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild)
            return;

        BuildTurret(buildManager.TurretToBuild);
    }

    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Not enough money");
            return;
        }

        turretBlueprint = blueprint;

        PlayerStats.Money -= turretBlueprint.cost;

        GameObject turret = Instantiate(turretBlueprint.prefab, BuildPosition, Quaternion.identity);
        this.turret = turret;

        GameObject effect = Instantiate(buildManager.buildEffect, BuildPosition, Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("Turret build!");
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Not enough money");
            return;
        }

        PlayerStats.Money -= turretBlueprint.upgradeCost;

        Destroy(this.turret);

        GameObject turret = Instantiate(turretBlueprint.upgradedPrefab, BuildPosition, Quaternion.identity);
        this.turret = turret;

        GameObject effect = Instantiate(buildManager.buildEffect, BuildPosition, Quaternion.identity);
        Destroy(effect, 5f);

        isUpgraded = true;

        Debug.Log("Turret upgraded!");
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        if (buildManager.HasMoney)
            rend.material.color = hoverColor;
        else
            rend.material.color = notEnoughMoneyColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
