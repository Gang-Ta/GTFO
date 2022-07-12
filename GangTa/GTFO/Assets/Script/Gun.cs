using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // -총알 자국
    public ParticleSystem bulletImpact;

    void Start()
    {
    }

    void Update()
    {
        //만약 마우스왼쪽버튼을 누르면
        if (Input.GetButtonDown("Fire1"))
        {
            //광선을 만든다. (원점, 방향);
            //(메인카메라 위치, 바라보고 있는 방향)
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

            //그 시선을 이용해서 바라봤는데 만약 닿은곳이 있다면. Physics ( 물리Class )  
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo)) //out은 매개변수에 대입했을때 함수 호출시 매개변수에 넣은 변수의 값도 대입된다.
            {
                // 닿은곳에 총알 자국을 가져다 놓는다.

                // (hitInfo.transform.position 물체 위치가 아니라 물체의 겉면을 알고 싶기에 position을 구하지 않는다.)
                // bulletImpact.transform.position = hitInfo.transform.position; 

                //실제로 부딪힌 위치 point
                bulletImpact.transform.position = hitInfo.point;

                //총알 자국 VFX를 재생한다.
                bulletImpact.Stop();
                bulletImpact.Play();

                //총알 자국 방향을 닿은곳에 Normal방향으로 회전한다.
                // 총알자국의 forward방향과 닿은 곳의 Normal방향을 일치시킨다.
                bulletImpact.transform.forward = hitInfo.normal;
            }
        }
    }
}
