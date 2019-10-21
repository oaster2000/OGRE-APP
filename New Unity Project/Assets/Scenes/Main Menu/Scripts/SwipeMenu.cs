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
	private DeviceOrientation prev_orientation;

	void realign()
	{
		for (int i = 0; i < contents.Length; i++)
		{
			float dim = 100;
			Debug.Log(Input.deviceOrientation);

			if(Input.deviceOrientation == DeviceOrientation.Portrait || Input.deviceOrientation == DeviceOrientation.PortraitUpsideDown || Input.deviceOrientation == DeviceOrientation.Unknown)
			{
				dim = contents[current].rect.width;

			}else if(Input.deviceOrientation == DeviceOrientation.LandscapeLeft || Input.deviceOrientation == DeviceOrientation.LandscapeRight)
			{
				dim = contents[current].rect.height;
			}

				int difference = i - current;
				float delta = (dim + min_spacing) * difference;
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

		if ((Input.deviceOrientation == DeviceOrientation.Portrait && (prev_orientation == DeviceOrientation.LandscapeLeft || prev_orientation == DeviceOrientation.LandscapeRight))
			|| (prev_orientation == DeviceOrientation.Portrait && (Input.deviceOrientation == DeviceOrientation.LandscapeLeft || Input.deviceOrientation == DeviceOrientation.LandscapeRight)))
		{

			realign();
			
			prev_orientation = Input.deviceOrientation;


		}




		float min = Mathf.Infinity;
		current = 0;
		for(int i = 0; i < contents.Length;i++)
		{
			if (Mathf.Abs(contents[i].position.x - (contents[i].rect.width + min_spacing)) < min)
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
