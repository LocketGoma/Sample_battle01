using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobMovement : MonoBehaviour
{
    [Header("Base Speed")]

    public float speed = 1f;

    [Header("Internal Data")]
    [SerializeField]
    private bool isEnemy;
    [SerializeField]
    private int speedGap = 1000;         //speed / speedGap
    private Vector3 moveVector;
    


    private void Awake()
    {
        isEnemy = false;
    }
    // Start is called before the first frame update
    void Start()                    //외부에서 호출하면 이게 바로 바뀌나?
    {
        if (isEnemy == false&&speed>0)
        {
            speed *= -1;        //방향 뒤집기
        }

        moveVector = new Vector3(speed/speedGap, 0, 0);

    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveVector, Space.World);                         //월드 좌표계 기준 move vector 값 만큼 이동.
    }


    public bool EnemyChanged()      //토글, 호출시 다음 '적/아군 여부' 를 리턴함.
    {
        if (isEnemy == true)
        {
            isEnemy = false;
        }
        else if (isEnemy == false)
        {
            isEnemy = true;
        }


        return getIsEnemy();
    }
    public bool getIsEnemy()
    {
        return isEnemy;
    }

}
