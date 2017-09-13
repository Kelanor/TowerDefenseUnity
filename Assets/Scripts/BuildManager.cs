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

    public GameObject standartTurretToBuild;

    private GameObject turretToBuild;

    void Start()
    {
        turretToBuild = standartTurretToBuild;
    }

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
}
