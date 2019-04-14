using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryDes : MonoBehaviour {
    public static UIInventoryDes Instence;
    private UILabel label;
    private float timer;
    private void Awake()
    {
        Instence = this;

    }
    void Start () {
        label = GetComponentInChildren<UILabel>();
        gameObject.SetActive(false);
    }
	private string  GetFoodInfo(ObjectInfo info)
    {
        string str = "";
        str += "名字：" + info.name + "\n";
        str += "+HP：" + info.hp + "\n";
        str += "+MP：" + info.mp + "\n";
        str += "出售价：" + info.price_sell + "\n";
        str += "购买价：" + info.price_buy + "\n";
        return str;
    }
    public void ShowItemDes(int id)
    {
        transform.position = UICamera.currentCamera.ScreenToWorldPoint(Input.mousePosition);
        ObjectInfo info = ObjectsInfo._instance.GetObjectInfoById(id);
        gameObject.SetActive(true);
        timer = 0.1f;
        string dse = "";
        switch (info.type)
        {
            case ObjectType.Drug:
                dse = GetFoodInfo(info);
                break;
            case ObjectType.Equip:
                break;
        }
        label.text = dse;
    }
	// Update is called once per frame
	void Update () {
		if(gameObject.activeInHierarchy == true)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                gameObject.SetActive(false);
            }
        }
	}
}
