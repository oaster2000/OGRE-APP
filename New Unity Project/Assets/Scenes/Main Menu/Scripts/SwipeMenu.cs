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

	public float left, top, right, bottom, delay, lerp_speed;

	private float time_since_release = float.MaxValue;


	void realign()
	{
		for (int i = 0; i < contents.Length; i++)
		{

				int difference = i - current;
				float delta = (contents[current].rect.width + min_spacing) * difference;
				contents[i].offsetMin = new Vector2(left + delta, bottom);
				contents[i].offsetMax = new Vector2(right + delta, top);
				//appropriately space each element of the sliding menu


		}


	}

	void Start()
    {

		this.realign();
		


	}



    // Update is called once per frame
    void Update()
    {
		float min = Mathf.Infinity;
		current = 0;
		for(int i = 0; i < contents.Length;i++)
		{
			if (Mathf.Abs(contents[i].position.x - contents[i].rect.width * 1.5f) < min)
			{
				current = i;
				min = Mathf.Abs(contents[i].position.x);
				
			}

		}



		if(Input.touchCount == 0 && !Input.GetMouseButton(0))
		{
			time_since_release += Time.deltaTime;

			if (time_since_release >= delay)
			{


				centre.anchoredPosition = new Vector2(Mathf.Lerp(centre.anchoredPosition.x,contents[current].anchoredPosition.x * -1.0f,lerp_speed), centre.anchoredPosition.y);
			}

		}
		else
		{
			time_since_release = 0.0f;
		}
	}
}
