using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Died : MonoBehaviour {
    private Rigidbody m_rigidbody;

    void Start () {
        m_rigidbody = gameObject.GetComponent<Rigidbody>();
        Invoke("Die", 1.5f);
	}
    void Update()
    {
        m_rigidbody.AddForce(Vector3.forward*0.1f, ForceMode.Impulse);
    }
    void Die () {
        GameObject.Destroy(gameObject);
        
    }
}
