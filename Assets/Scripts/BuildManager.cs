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

    public TurretBlueprint TurretToBuild
    {
        get { return turretToBuild; }
        // Select Turret To Build
        set
        {
            turretToBuild = value;
            DeselectNode();
        }
    }

    public GameObject buildEffect;
    public GameObject sellEffect;
    public NodeUI nodeUI;

    private TurretBlueprint turretToBuild;
    private Node selectedNode;
    
    public void SelectNode(Node node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }
}
