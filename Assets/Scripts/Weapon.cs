using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    private Ray ray;
    private RaycastHit hit;
    private Transform m_Transform;
    private Transform m_Point;//枪口位置
    public GameObject die;
    private AudioSource m_AudioSource;
    private bool canMove = false;//是否可以控制
    private GameManager m_GameManager;
    private MousesManager m_MousesManager;//老鼠
    void Start () {
        m_Transform = gameObject.GetComponent<Transform>();
        m_Point = m_Transform.Find("Point");
        m_AudioSource = gameObject.GetComponent<AudioSource>();
        m_GameManager = GameObject.Find("UI").GetComponent<GameManager>();
        m_MousesManager = GameObject.Find("Mouses").GetComponent<MousesManager>();
    }
    public void ChangeCanMove(bool state)
    {
        canMove = state;
    }
	void Update () {
        //标志位。是否可以控制武器
        if(canMove)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                //控制手臂朝向碰撞点
                m_Transform.LookAt(hit.point);
                //绘制测试线
                Debug.DrawLine(m_Point.position, hit.point, Color.green);
                //飞盘射击
                if (hit.collider.tag == "Mouse" && Input.GetMouseButtonDown(0))
                {
                    //计算击杀数
                    m_GameManager.AddScore();
                    //播放射击音效
                    m_AudioSource.Play();
                    //保存碰撞点
                    Vector3 position = hit.collider.transform.position;
                    //消除方块
                    GameObject.Destroy(hit.collider.gameObject);
                    //在该点实例化一个球
                    GameObject.Instantiate(die, position, Quaternion.identity);
                    //记录老鼠总数
                    m_MousesManager.mNum--;
                }
            }
        }
        
	}
    
}
