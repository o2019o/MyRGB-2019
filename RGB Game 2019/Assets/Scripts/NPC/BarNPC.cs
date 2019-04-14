using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarNPC : MonoBehaviour {
    private TweenPosition tween;
    private GameObject quset;
    private UILabel qusetLabel;
    private GameObject okButton,closeButton,acceptButton,cancelButton;
    public int killCount = 0;
    private bool isInTack = false;
    private PlayerStatus ps;
	// Use this for initialization
	void Start () {
        ps = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>();
        quset = GameObject.Find("Quset_UI");
        tween = quset.GetComponent<TweenPosition>();
        qusetLabel = quset.transform.GetChild(0).GetComponent < UILabel>();
        okButton = quset.transform.GetChild(1).gameObject;
        closeButton = quset.transform.GetChild(2).gameObject;
        acceptButton = quset.transform.GetChild(3).gameObject;
        cancelButton = quset.transform.GetChild(4).gameObject;
        okButton.GetComponent<UIButton>().onClick.Add(new EventDelegate(OnOKbutClick));
        closeButton.GetComponent<UIButton>().onClick.Add(new EventDelegate(OnCancelButClick));
        acceptButton.GetComponent<UIButton>().onClick.Add(new EventDelegate(OnAcceptButClick));
        cancelButton.GetComponent<UIButton>().onClick.Add(new EventDelegate(OnCancelButClick));
    }
    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(isInTack)
            {
                ShowTaskProgres();               
            }
            else
            {
                ShowTaskDes();               
            }
            SetTweenPos();
        }
    }
    bool isShow = false;
	public void SetTweenPos()
    {
        if(!isShow)
        {
            isShow = true;
            tween.PlayForward();
        }
        else
        {
            isShow = false;
            tween.PlayReverse();
        }
    }
    public void OnAcceptButClick()
    {
        ShowTaskProgres();
        isInTack = true;
    }
    public void OnOKbutClick()
    {
        if(killCount >= 10)
        {
            ps.GetCoins(1000);
            killCount = 0;
            ShowTaskDes();
            isInTack = false;
        }
        else
        {
            tween.PlayReverse();
        }
    }
    private void OnCancelButClick()
    {
        tween.PlayReverse();
    }
    private void ShowTaskDes()
    {
        qusetLabel.text = "任务：\n你要杀死10只狼\n\n奖励：\n1000金币";
        okButton.SetActive(false);
        acceptButton.SetActive(true);
        cancelButton.SetActive(true);
    }
    private void ShowTaskProgres()
    {
        qusetLabel.text = "任务：" + "\n" + "你已经杀死了" + killCount + "只狼\n\n奖励：\n1000金币";
        okButton.SetActive(true);
        acceptButton.SetActive(false);
        cancelButton.SetActive(false);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
