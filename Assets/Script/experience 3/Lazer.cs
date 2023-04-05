using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    public Transform lazer_start;
    LineRenderer line;
    public ScreenManager screen;
    public GameObject mark;
    float maxDistance = 100.0f;

    bool first_hit = true;
    void Start()
    {
        gameObject.transform.Rotate(new Vector3((float)Random.Range(-100, 100) / 100, 0, 0));
        line = gameObject.GetComponent<LineRenderer>();
        line.enabled = true;
    }

    void Update()
    {
        // 計算雷射光束的方向
        Vector3 direction = lazer_start.transform.forward;

        // 計算雷射光束的起點
        Vector3 origin = lazer_start.transform.position;
        Ray ray = new Ray(origin, direction);
        RaycastHit hit;
        line.SetPosition(0, ray.origin);
        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            line.SetPosition(1, hit.point); //設定第二個 Line Render 第二個點位置，即可連成一條線
            // 記錄
            Vector3 point = hit.point;
            Vector3 normal = hit.normal;
            // 計算雷射光束的反彈方向
            Vector3 reflect = Vector3.Reflect(direction, normal);
            Ray second_ray = new Ray(point, reflect);
            if(Physics.Raycast(second_ray, out hit, maxDistance))
            {
                line.SetPosition(2, hit.point);
                if(first_hit)
                {
                    mark.transform.position = hit.point;
                    first_hit = false;
                    //Instantiate(mark, hit.point, mark.transform.rotation, mark.transform.parent);
                }
                // print(hit.point);
                if(hit.point.y > screen.max_y){
                    screen.line.SetPosition(0, new Vector3(screen.transform.position.x, hit.point.y, screen.transform.position.z));
                    screen.max_y = hit.point.y;
                }
                if(hit.point.y < screen.min_y){
                    screen.line.SetPosition(1, new Vector3(screen.transform.position.x, hit.point.y, screen.transform.position.z));
                    screen.min_y = hit.point.y;
                }
                
            }
        }
        else
        {
            line.SetPosition(1, ray.GetPoint(maxDistance)); //如果都沒打到物體，就發射 100 這麼長的射線
        }
    }

}