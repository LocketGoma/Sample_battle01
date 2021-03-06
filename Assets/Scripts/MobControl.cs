﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobControl : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("기본 수치")]
    [Range(0,100)]
    public int Damage=10;          //공격력
    [Range(0,10000)]
    public int Health=100;          //체력
    [Range(0,100)]
    public int Defence=0;         //방어력 (감쇄 데미지 = (데미지/방어력) +1 (무조건 데미지 1은 들어가도록)
    [Range(1, 10)]
    public int AttackSpeed=2;     //공격 빈도 (5초당 N회)
    [Range(2, 60)]
    public int RespawnTime=10;

    [Header("Target")]
    private GameObject enemy;

    //데미지 공식 : (공격력 / 방어력)+1, 크리티컬시 2.5배 데미지, 크리티컬 확률 공식 = ?


    void Start()
    {
        enemy = null;
    }

    public int getRespawnTime()
    {
        return RespawnTime;
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("On");
        if (collision.gameObject.tag == gameObject.tag)
        {
            Physics2D.IgnoreCollision(collision.collider, this.GetComponent<Collider2D>());            
        }
        if (enemy == null)
        {
            if (collision.gameObject.tag != "default" && collision.gameObject.tag != gameObject.tag)
            {
                enemy = collision.gameObject;

            }
        }


    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == gameObject.tag)
        {
            Physics2D.IgnoreCollision(collision.collider, this.GetComponent<Collider2D>());            
        }


    }

}
