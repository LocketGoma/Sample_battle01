using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobLaunch : MonoBehaviour
{
    [Header("Mob type")]
    public GameObject Mob;
    [Header("Spawn Location")]
    public Transform rawSpawnpoint;
    [Header("Spawn cost")]
    public int SpawnCost=100;
    public int Cooltime = 5;

    [Header("Layer")]
    [SerializeField]
    private int layerdata = 0;
    private Vector3 Spawnpoint;

    private void Awake()
    {        
        Spawnpoint = new Vector3(rawSpawnpoint.position.x, rawSpawnpoint.position.y, layerdata);     
    }

    public void LaunchMob()
    {
        try{
            Instantiate(Mob,Spawnpoint,rawSpawnpoint.rotation);
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);

            //return false;
        }


        //return true;
    }

}
