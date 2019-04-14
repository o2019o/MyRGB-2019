using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStutas : MonoBehaviour {
    public static UIStutas Instance;
    private void Awake()
    {
        Instance = this;
    }
    public UILabel attackL, defL, speedL, pointL, summaryL;
    public GameObject attackBut, defBut, speedBut;
    private TweenPosition tween;
    private PlayerStatus ps;
	// Use this for initialization
	void Start () {
        ps = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>();
        tween = GetComponent<TweenPosition>();

        attackL = GameObject.Find("AttackLabel").GetComponent<UILabel>();
        defL = GameObject.Find("DefLabel").GetComponent<UILabel>();
        speedL = GameObject.Find("SpeedLabel").GetComponent<UILabel>();
        pointL = GameObject.Find("Point_remain_Label").GetComponent<UILabel>();
        summaryL = GameObject.Find("ZongJieLabel (1)").GetComponent<UILabel>();

        attackBut = GameObject.Find("AttackBut");
        attackBut.GetComponent<UIButton>().onClick.Add(new EventDelegate(OnAttackClick));
        defBut = GameObject.Find("DefBut");
        defBut.GetComponent<UIButton>().onClick.Add(new EventDelegate(OnDefClick));
        speedBut = GameObject.Find("SpeedBut");
        speedBut.GetComponent<UIButton>().onClick.Add(new EventDelegate(OnSpeedClick));
    }
    bool isShow = false;
    public void SetTweenPos()
    {
        if(!isShow)
        {
            tween.PlayForward();isShow = true;
        }
        else
        {
            tween.PlayReverse();isShow = false;
        }
    }
    private void OnSpeedClick()
    {
        bool success = ps.GetPoints();
        if(success)
        {
            ps.addSpeed++;
            UpdateShow();
        }
    }

    private void OnDefClick()
    {
        bool success = ps.GetPoints();
        if (success)
        {
            ps.addDef++;
            UpdateShow();
        }
    }

    private void OnAttackClick()
    {
        bool success = ps.GetPoints();
        if (success)
        {
            ps.addAttack++;
            UpdateShow();
        }
    }
    private void UpdateShow()
    {
        attackL.text = ps.attack + "+" + ps.addAttack;
        defL.text = ps.def + "+" + ps.addDef;
        speedL.text = ps.speed + "+" + ps.addSpeed;
        pointL.text = ps.point_remain.ToString();
        summaryL.text= "伤害:" + (ps.attack + ps.addAttack) +
            "\u3000" + "防御:" + (ps.def + ps.addDef) +
            "\u3000" + "速度:" + (ps.speed + ps.addSpeed);
        if (ps.point_remain > 0)
        {
            attackBut.SetActive(true);
            defBut.SetActive(true);
            speedBut.SetActive(true);
        }
        else
        {
            attackBut.SetActive(false);
            defBut.SetActive(false);
            speedBut.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update () {
        UpdateShow();

    }
}
