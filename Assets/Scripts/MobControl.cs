using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobControl : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("기본 수치")]
    [Range(0,100)]
    public int Damage;          //공격력
    [Range(0,10000)]
    public int Health;          //체력
    [Range(0,100)]
    public int Defence;         //방어력
    [Range(1, 10)]
    public int AttackSpeed;     //공격 빈도 (5초당 N회)

    //데미지 공식 : (공격력 / 방어력)+1, 크리티컬시 2.5배 데미지, 크리티컬 확률 공식 = ?


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("On");
        if (collision.gameObject.tag == gameObject.tag)
        {
            Physics2D.IgnoreCollision(collision.collider, this.GetComponent<Collider2D>());            
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
