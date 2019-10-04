using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class fz : MonoBehaviour
{
    public GameObject gm1;
    public GameObject gm2;
    public GameObject gm3;
    Ray ry;
    RaycastHit hit;
    int sel;
    int msel;
    bool bl;
    public Material m1;
    public Material m2;
    public Material m3;
    public Color c1;
    public Color c2;
    public Text txt;
    void Start()
    {
        m1.color = c1;
        m2.color = c1;
        m3.color = c1;
        gm1.SetActive(false);
        gm2.SetActive(false);
        gm3.SetActive(false);
        sel = -1;
        msel = -1;
    }

    // Update is called once per frame
    void Update()
    {
        ry =Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ry, out hit,1000))
        {
            if(hit.collider.gameObject.tag=="f1") //厨房
            {
                sel = 1;
            }
            else if(hit.collider.gameObject.tag == "f2")
            {
                sel = 2;
            }
            else if (hit.collider.gameObject.tag == "f3")
            {
                sel = 3;
            }
            else
            {
                sel = -1;
            }
        }
        else
        {
            sel = -1;
        }

        if(Input.GetMouseButtonDown(0))
        {
            if(sel!=-1)
            {
                msel = sel;
            }
        }
        if(sel==1|| msel==1)
        {
            gm1.SetActive(true);
        }
        else
        {
            gm1.SetActive(false);
        }

        if (sel == 2 || msel == 2)
        {
            gm2.SetActive(true);
        }
        else
        {
            gm2.SetActive(false);
        }

        if (sel == 3 || msel == 3)
        {
            gm3.SetActive(true);
        }
        else
        {
            gm3.SetActive(false);
        }

        if (msel==1)
        {
            txt.text = "客厅";
        }
        else if(msel==2)
        {
            txt.text = "厨房";
        }
        else if (msel == 3)
        {
            txt.text = "卧室书房";
        }
    }
    public void Onbtnc()
    {
        if(msel==1)
        {
            if (m1.color==c1)
            {
                m1.color = c2;
            }
            else
            {
                m1.color = c1;
            }
        }
        else if(msel==2)
        {
            if (m2.color == c1)
            {
                m2.color = c2;
            }
            else
            {
                m2.color = c1;
            }
        }
        else if (msel == 3)
        {
            if (m3.color == c1)
            {
                m3.color = c2;
            }
            else
            {
                m3.color = c1;
            }
        }
    }
    private void OnApplicationQuit()
    {
        m1.color = c1;
        m2.color = c1;
        m3.color = c1;
    }
}
