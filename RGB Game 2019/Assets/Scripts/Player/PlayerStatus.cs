using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour {

    public int grade = 1;
    public int hp = 100;
    public int mp = 100;
    public int coin = 200;

    public int attack = 20;
    public int addAttack = 0;
    public int def = 20;
    public int addDef = 0;
    public int speed = 20;
    public int addSpeed = 20;
    public int point_remain = 0;

    public void GetCoins(int count)
    {
        coin += count;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
