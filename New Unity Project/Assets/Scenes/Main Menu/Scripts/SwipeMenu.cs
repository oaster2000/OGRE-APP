using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeMenu : MonoBehaviour
{
	// Start is called before the first frame update


	public RectTransform centre;

	public RectTransform[] contents;

	public int current;
	public int min_spacing_h, min_spacing_v;
	private int min_spacing;
	public float left, top, right, bottom, delay, lerp_speed;

	private float time_since_release = float.MaxValue;
	private DeviceOrientation prev_orientation;

	void realign()
	{
		for (int i = 0; i < contents.Length; i++)
		{

			Debug.Log(Input.deviceOrientation);
			min_spacing = (prev_orientation == DeviceOrientation.LandscapeLeft || prev_orientation == DeviceOrientation.LandscapeRight) ? min_spacing_h : min_spacing_v;
			// if landscape then min spacing is horizontal otherwise assume vertical

			int difference = i - current;
			float delta = (contents[0].rect.width + min_spacing) * difference;
			contents[i].anchoredPosition = new Vector2(delta,0);
			//contents[i].offsetMin = new Vector2(left + delta, bottom);
			//contents[i].offsetMax = new Vector2(right + delta, top);
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

		if ((Input.deviceOrientation == DeviceOrientation.Portrait && (prev_orientation == DeviceOrientation.LandscapeLeft || prev_orientation == DeviceOrientation.LandscapeRight))
			|| (prev_orientation == DeviceOrientation.Portrait && (Input.deviceOrientation == DeviceOrientation.LandscapeLeft || Input.deviceOrientation == DeviceOrientation.LandscapeRight)))
		{

			//realign();

			prev_orientation = Input.deviceOrientation;


		}




		float min = Mathf.Abs(contents[0].position.x); ;
		current = 0;
		for(int i = 1; i < contents.Length;i++)
		{
			if (Mathf.Abs(contents[i].position.x - ((contents[i].rect.width + min_spacing)*2.5f)) < min)
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
