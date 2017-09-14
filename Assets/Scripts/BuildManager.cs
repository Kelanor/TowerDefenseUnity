using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
#region Singleton
    public static BuildManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }

        instance = this;
    }
#endregion
    
    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public GameObject buildEffect;

    private TurretBlueprint turretToBuild;

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }

    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not enough money");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

        GameObject turret = Instantiate(turretToBuild.prefab, node.BuildPosition, Quaternion.identity);
        node.turret = turret;

        GameObject effect = Instantiate(buildEffect, node.BuildPosition, Quaternion.identity);

        Destroy(effect, 5f);
        Debug.Log("Turret built! Money left: " + PlayerStats.Money);
    }
}
