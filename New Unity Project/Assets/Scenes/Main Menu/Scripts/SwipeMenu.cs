using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeMenu : MonoBehaviour
{
	// Start is called before the first frame update


	public RectTransform centre;

	public RectTransform[] contents;

	public int current;
	public int min_spacing;

	public float left, top, right, bottom;

	void Start()
    {
		for(int i = 0; i < contents.Length;i++)
		{
			if(i == current)
			{
				contents[i].offsetMin = new Vector2(left,bottom);
				contents[i].offsetMax = new Vector2(right, top);
				Debug.Log(contents[i].rect.width);


			}
			else
			{
				int difference = i - current;
				float delta = (contents[current].rect.width + min_spacing) * difference;
				contents[i].offsetMin = new Vector2(left + delta, bottom);
				contents[i].offsetMax = new Vector2(right + delta, top);
				//appropriately space each element of the sliding menu
			}


		}



        
    }



    // Update is called once per frame
    void Update()
    {

		for(int i = 0; i < contents.Length;i++)
		{


		}
        
    }
}
