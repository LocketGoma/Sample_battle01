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
    

    [Header("Inner Data")]
    [SerializeField]
    private int respawnTime;            //고정 데이터 : 리스폰 시간 (재 제작 가능 시간)
    private int cooltime;               //고정 데이터 : "남은" 리스폰 시간
    private Vector3 Spawnpoint;         //고정 데이터 : 스폰 위치 (public data 편집)
    private bool respawnLock = false;

    private void Awake()
    {        
        Spawnpoint = new Vector3(rawSpawnpoint.position.x, rawSpawnpoint.position.y, layerdata);
        respawnTime = Mob.GetComponent<MobControl>().getRespawnTime();
        cooltime = respawnTime;
    }

    public void LaunchMob()
    {


        if (respawnLock == false)
        {
            try
            {
                Instantiate(Mob, Spawnpoint, rawSpawnpoint.rotation);
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);

                //return false;
            }
            finally
            {
                StartCoroutine("RespawnClock");
            }
        }
        else
            Debug.Log("쿨타임:"+ cooltime);


        //return true;
    }
    IEnumerator RespawnClock()           //쿨타임!
    {        
        respawnLock = true;
        while (true)
        {
            Debug.Log(cooltime);
            yield return new WaitForSecondsRealtime(1);
            
            if (cooltime-- < 1)
            {
                respawnLock = false;
                cooltime = respawnTime;
                Debug.Log("now can respawn");
                StopCoroutine("RespawnClock");
                yield break;
            }
        }
    }
    

}
