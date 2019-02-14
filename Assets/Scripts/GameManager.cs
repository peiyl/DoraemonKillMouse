using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    /// <summary>
    /// 游戏的三种状态
    /// </summary>
    public enum GameState
    {
        START,
        GAME,
        END
    }
    //存储三个ui界面的引用
    private GameObject m_StartUI;
    private GameObject m_GameUI;
    private GameObject m_EndUI;
    private Text m_TextScore;   //当前分数
    private Text m_TextTime;    //时间
    private Text m_AddScore;    //总分数
    private Text m_AddT;
    
    //当前的游戏状态
    private GameState gameState;
    //武器脚本
    private Weapon m_Weapon;
    //老鼠
    private MousesManager m_MousesManager;
    //分数。
    private int score = 0;
    //计时
    private float time = 0;
    //时间标志位
    private bool startTime = false;

	void Start () {
        //持有三个ui的引用
        m_StartUI = GameObject.Find("StartUI");
        m_GameUI = GameObject.Find("GameUI");
        m_EndUI = GameObject.Find("EndUI");
        m_TextScore = GameObject.Find("Score").GetComponent<Text>();
        m_TextTime = GameObject.Find("Times").GetComponent<Text>();
        m_AddScore = GameObject.Find("AddScore").GetComponent<Text>();
        m_AddT = GameObject.Find("AddT").GetComponent<Text>();
        //人物脚本
        m_Weapon = GameObject.Find("Player").GetComponent<Weapon>();
        //老鼠脚本
        m_MousesManager = GameObject.Find("Mouses").GetComponent<MousesManager>();
        //改变游戏状态
        ChangeGameState(GameState.START);
	}
    void Update()
    {
        if(startTime)
        {
            time += Time.deltaTime;
            m_TextTime.text = "时间:" + time + "秒";
            if(m_MousesManager.mNum >= 10)
            {
                ChangeGameState(GameState.END);
                m_AddScore.text = "击杀了：" + score + "只老鼠";
                m_AddT.text = "我们坚持了：" + time + "秒";
                //重置相关数据
                m_MousesManager.mNum = 0;
                startTime = false;
                time = 0;
                score = 0;
            }
        }

    }
    /// <summary>
    /// 开始计时
    /// </summary>
    public void StartTime()
    {
        startTime = true;
    }
    /// <summary>
    /// 计算击杀数
    /// </summary>
    public void AddScore()
    {
        score++;
        m_TextScore.text = "击杀数：" + score ;
    }
    /// <summary>
    /// 游戏状态转换方法
    /// </summary>
    /// <param name="state"></param>
	public void ChangeGameState(GameState state)
    {
        //存储传递过来的状态
        gameState = state;
        if(gameState == GameState.START)
        {
            m_StartUI.SetActive(true);
            m_GameUI.SetActive(false);
            m_EndUI.SetActive(false);
        }
        else if(gameState == GameState.GAME)
        {
            m_StartUI.SetActive(false);
            m_GameUI.SetActive(true);
            m_EndUI.SetActive(false);
            //控制角色
            m_Weapon.ChangeCanMove(true);
            m_MousesManager.StartCreateMouses();
            //开始计时
            StartTime();
            //同步UI
            m_TextScore.text = "击杀数：" + score;
        }
        else if(gameState == GameState.END)
        {
            m_StartUI.SetActive(false);
            m_GameUI.SetActive(false);
            m_EndUI.SetActive(true);
            m_Weapon.ChangeCanMove(false);
            m_MousesManager.StopCreateMouses();
            m_MousesManager.RemoveMouses();
        }
    }
}
