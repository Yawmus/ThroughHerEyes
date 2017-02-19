using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Dialogue : MonoBehaviour {

	Queue<string> buffer = new Queue<string>();
	Text t, p, x;
	GameObject bg1, bg2;
	float timer = 0;

	// Use this for initialization
	void Awake () {
		bg1 = transform.FindChild ("Container1").gameObject;
		bg2 = transform.FindChild ("Container2").gameObject;
		p = bg1.transform.FindChild("BG1").FindChild ("Person").GetComponent<Text>();
		t = bg1.transform.FindChild("BG2").FindChild ("Text").GetComponent<Text>();
		x = bg2.transform.FindChild("BG3").FindChild ("Text").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= 2.7f)
		{
			if(buffer.Count != 0)
			{
				string str = buffer.Dequeue();
				string[] temp = Regex.Split(str, ": ");
				if(temp.Length == 1)
				{
					bg2.SetActive(true);
					bg1.SetActive(false);
					x.text = str;
				}
				else
				{
					bg1.SetActive(true);
					bg2.SetActive(false);
					p.text = temp[0];
					t.text = temp[1];
				}
				timer = 0;
			}
			else
			{
				bg1.SetActive(false);
				bg2.SetActive(false);
			}
		}
	}

	public void Say(string message)
	{
		buffer.Enqueue (message);
	}
}
