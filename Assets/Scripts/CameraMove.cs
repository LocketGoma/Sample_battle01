using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraMove : MonoBehaviour
{
    public Camera cameraObject;
    public GameObject BackgroundMap;
    
    [Range(-5,5)]
    public float dragSpeed = 2;

    [Range(0,48)]
    public float lockMovement = 18; // 카메라 움직임 범위 제한

    [SerializeField]
    private Vector3 dragOrigin;
    private bool locking=false;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {        
        if (Input.GetMouseButtonDown(0)&&locking==false)
        {
            dragOrigin = Input.mousePosition;
            locking = true;
            return;
        }
        if (Input.GetMouseButtonUp(0)||locking==false)
        {       //???
            locking = false;
            return;
        }


        Vector3 pos = cameraObject.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
        Vector3 move = new Vector3(pos.x * dragSpeed, 0, 0);            //'움직이고 싶은 정도'를 담게 됨. 좌 -> 우 : +, 우 -> 좌 : -


        Debug.Log(move.x);

        if (Math.Abs(transform.position.x+move.x) > lockMovement)       //가끔 튕겨져나가는? 버그같은게 보이는데 나중에 확인해놓을것.
        {
            move = new Vector3(0, 0, 0);
        }


        transform.Translate(move, Space.World);                         //월드 좌표계 기준 move vector 값 만큼 이동.
        BackgroundMap.transform.Translate(move, Space.World);

    }

}
