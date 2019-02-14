using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameReset : MonoBehaviour {
    private GameManager m_GameManager;
    void Awake()
    {
        Button m_Button = GetComponent<Button>();
        m_Button.onClick.AddListener(myClick);//为button事件添加监听器，当监听到Click事件时，回调myClick函数
        m_GameManager = GameObject.Find("UI").GetComponent<GameManager>();
    }
    void myClick()
    {
        m_GameManager.ChangeGameState(GameManager.GameState.START);
    }
}
