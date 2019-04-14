using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour {
    public static UIInventory Instance;
    private List<UIInventoryItemGrid> itemGridList = new List<UIInventoryItemGrid>();
    private UILabel coinLabel;
    public int cionCount = 1000;
    private TweenPosition tween;
    public GameObject inventoryItem;


    private void Awake()
    {
        Instance = this;
        foreach(UIInventoryItemGrid grid in GetComponentsInChildren<UIInventoryItemGrid>())
        {
            itemGridList.Add(grid);
        }
        tween = GetComponent<TweenPosition>();
        coinLabel = GameObject.Find("CoinLabel").GetComponent<UILabel>();
    }

    private bool isShow = false;
    public void SetTweemPos()
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
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.F))
        {
            int aa = Random.Range(1001, 1004);
            GetItemId(aa,1);
        }
	}
    public void GetItemId(int id,int count=1)
    {
        UIInventoryItemGrid grid = null;
        foreach(UIInventoryItemGrid temp in itemGridList)
        {
            if(temp.gridId == id)
            {
                grid = temp;break;
            }
        }
        if(grid != null)
        {
            grid.PulsCount(count);
        }
        else
        {
            foreach (UIInventoryItemGrid temp in itemGridList)
            {
                if (temp.gridId == 0)
                {
                    grid = temp; break;
                }
            }
            if(grid != null)
            {
                GameObject item = Instantiate(inventoryItem);
                item.transform.SetParent(grid.transform);
                item.transform.localPosition = Vector3.zero;
                item.transform.localScale = Vector3.one;
                grid.SetGirdId(id,count);
            }
        }
    }
    public bool GetCoinCount(int count)
    {
        if(cionCount > count)
        {
            cionCount -= count;
            coinLabel.text = cionCount.ToString();
            return true;
        }
        return false;
    }
}
