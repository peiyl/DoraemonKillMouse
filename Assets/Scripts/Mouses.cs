using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouses : MonoBehaviour
{
    private Transform m_Transform;
    private float M1 = 0.5f;//幅度
    void Start()
    {
        m_Transform = gameObject.GetComponent<Transform>();
        MouseM();
    }

    private void MouseM()
    {
        InvokeRepeating("MouseMove3", 0.1f, 0.1f);
    }
    /// <summary>
    /// 判断老鼠在哪个位置
    /// </summary>
    /// <param name="X"></param>
    /// <param name="Y"></param>
    /// <returns></returns>
    private static int MouseMove2(float X, float Y)
    {
        int a ;
        if(X<=-7)
        {
            if (Y <= 2) a = 0;
            else if (Y < 4) a = 1;
            else a = 2;
        }
        else if (X <7)
        {
            if (Y <= 2) a = 3;
            else if (Y < 4) a = 4;
            else a = 5;
        }
        else
        {
            if (Y <= 2) a = 6;
            else if (Y < 4) a = 7;
            else a = 8;
        }
        return a;
    }
    /// <summary>
    /// 移动方向
    /// </summary>
    void MouseMove3()
    {
        int a = MouseMove2(m_Transform.position.x, m_Transform.position.y);
        switch(a)
        {
            case 0:
                m_Transform.Translate(new Vector3(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 0) * M1);
                break;
            case 1:
                m_Transform.Translate(new Vector3(Random.Range(0.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0) * M1);
                break;
            case 2:
                m_Transform.Translate(new Vector3(Random.Range(0.0f, 1.0f), Random.Range(-1.0f, 0.0f), 0) * M1);
                break;
            case 3:
                m_Transform.Translate(new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(0.0f, 1.0f), 0) * M1);
                break;
            case 4:
                m_Transform.Translate(new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0) * M1);
                break;
            case 5:
                m_Transform.Translate(new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 0.0f), 0) * M1);
                break;
            case 6:
                m_Transform.Translate(new Vector3(Random.Range(-1.0f, 0.0f), Random.Range(0.0f, 1.0f), 0) * M1);
                break;
            case 7:
                m_Transform.Translate(new Vector3(Random.Range(-1.0f, 0.0f), Random.Range(-1.0f, 1.0f), 0) * M1);
                break;
            case 8:
                m_Transform.Translate(new Vector3(Random.Range(-1.0f, 0.0f), Random.Range(-1.0f, 0.0f), 0) * M1);
                break;
        }   
    }
   
}
