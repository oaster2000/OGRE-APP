using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColourSwitcher : MonoBehaviour
{
    public Color[] palette1 = new Color[1];
    public Color[] palette2 = new Color[1];
    public Color[] palette3 = new Color[1];
    public Color[] palette4 = new Color[1];
    public Color[] palette5 = new Color[1];
    public Color[] palette6 = new Color[1];

    public Material p1Floor;
    public Material p1Wall;

    public Material p2Floor;
    public Material p2Wall;

    public Material p3Floor;
    public Material p3Wall;

    public Material p4Floor;
    public Material p4Wall;

    public Material p5Floor;
    public Material p5Wall;

    public Material p6Floor;
    public Material p6Wall;


    public GameObject[] color1;
    public GameObject[] color2;
    public GameObject wall;
    public GameObject floor;

    public int whatPalette = 1;

    void Update()
    {
        if(whatPalette == 1)
        {
            for(int i = 0; i < color1.Length; i++)
            {
                if (color1[i].GetComponent<Image>())
                {
                    color1[i].GetComponent<Image>().color = palette1[0];
                }

            }
            for (int i = 0; i < color2.Length; i++)
            {
                if (color2[i].GetComponent<Image>())
                    color2[i].GetComponent<Image>().color = palette1[1];
            }
            wall.GetComponent<MeshRenderer>().material = p1Wall;
            floor.GetComponent<MeshRenderer>().material = p1Floor;
        }
        if (whatPalette == 2)
        {
            for (int i = 0; i < color1.Length; i++)
            {
                if (color1[i].GetComponent<Image>())
                    color1[i].GetComponent<Image>().color = palette2[0];
            }
            for (int i = 0; i < color2.Length; i++)
            {
                if (color2[i].GetComponent<Image>())
                    color2[i].GetComponent<Image>().color = palette2[1];
            }
            wall.GetComponent<MeshRenderer>().material = p2Wall;
            floor.GetComponent<MeshRenderer>().material = p2Floor;
        }
        if (whatPalette == 3)
        {
            for (int i = 0; i < color1.Length; i++)
            {
                if (color1[i].GetComponent<Image>())
                    color1[i].GetComponent<Image>().color = palette3[0];
            }
            for (int i = 0; i < color2.Length; i++)
            {
                if (color2[i].GetComponent<Image>())
                    color2[i].GetComponent<Image>().color = palette3[1];
            }
            wall.GetComponent<MeshRenderer>().material = p3Wall;
            floor.GetComponent<MeshRenderer>().material = p3Floor;
        }
        if (whatPalette == 4)
        {
            for (int i = 0; i < color1.Length; i++)
            {
                if (color1[i].GetComponent<Image>())
                    color1[i].GetComponent<Image>().color = palette4[0];
            }
            for (int i = 0; i < color2.Length; i++)
            {
                if (color2[i].GetComponent<Image>())
                    color2[i].GetComponent<Image>().color = palette4[1];
            }
            wall.GetComponent<MeshRenderer>().material = p4Wall;
            floor.GetComponent<MeshRenderer>().material = p4Floor;
        }
        if (whatPalette == 5)
        {
            for (int i = 0; i < color1.Length; i++)
            {
                if (color1[i].GetComponent<Image>())
                    color1[i].GetComponent<Image>().color = palette5[0];
            }
            for (int i = 0; i < color2.Length; i++)
            {
                if (color2[i].GetComponent<Image>())
                    color2[i].GetComponent<Image>().color = palette5[1];
            }
            wall.GetComponent<MeshRenderer>().material = p5Wall;
            floor.GetComponent<MeshRenderer>().material = p5Floor;
        }
        if (whatPalette == 6)
        {
            for (int i = 0; i < color1.Length; i++)
            {
                if (color1[i].GetComponent<Image>())
                    color1[i].GetComponent<Image>().color = palette6[0];
            }
            for (int i = 0; i < color2.Length; i++)
            {
                if (color2[i].GetComponent<Image>())
                    color2[i].GetComponent<Image>().color = palette6[1];
            }
            wall.GetComponent<MeshRenderer>().material = p6Wall;
            floor.GetComponent<MeshRenderer>().material = p6Floor;
        }
    }

    public void setPalette(int number)
    {
        whatPalette = number;
    }
}
