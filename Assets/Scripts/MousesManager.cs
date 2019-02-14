using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousesManager : MonoBehaviour {
    public GameObject prefab_Mouses;
    private Transform m_Transform;
    public int mNum=0;
	void Start () {
        m_Transform = gameObject.GetComponent<Transform>();
	}
    /// <summary>
    /// 生成
    /// </summary>
    public void StartCreateMouses()
    {
        InvokeRepeating("Mouses", 1.0f, 2.0f);
    }
    /// <summary>
    /// 停止生成
    /// </summary>
    public void StopCreateMouses()
    {
        CancelInvoke();
    }
    /// <summary>
    /// 清除
    /// </summary>
    public void RemoveMouses()
    {
        Transform[] m = m_Transform.GetComponentsInChildren<Transform>();
        for(int i =1;i<m.Length;i++)
        {
            GameObject.Destroy(m[i].gameObject);
        }
    }
    /// <summary>
    /// 生成老鼠
    /// </summary>
	void Mouses()
    {
        for(int i=0;i<2;i++)
        {
            //生成老鼠的位置
            Vector3 pos = new Vector3(Random.Range(-8.0f, 8.0f), Random.Range(1.0f, 5.0f), Random.Range(10.0f, 20.0f));
            //实例化物体
            GameObject mo = Instantiate(prefab_Mouses, pos, Quaternion.identity);
            //生成的物体保存到父物体
            mo.GetComponent<Transform>().SetParent(m_Transform);
            mNum++;
            Debug.Log("G" + mNum);
        }
    }
    
}
