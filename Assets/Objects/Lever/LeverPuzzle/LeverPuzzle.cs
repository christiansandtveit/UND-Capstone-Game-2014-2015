//Michael Schilling
//CSci 448
using UnityEngine;
using System.Collections;

public class LeverPuzzle : MonoBehaviour {

	public puzzleLever[] leversInPuzzle; // this is important for order
	private int currentLeverIndex = 0;
	public Activatable ItemToActivate;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < leversInPuzzle.Length; i++)
		{
			leversInPuzzle[i].master = this;
			leversInPuzzle[i].INDEX = i;
		}
	}

	public void LeverActivated(int leverCount)
	{
		if (leverCount == currentLeverIndex)
		{
			currentLeverIndex++;
			if (currentLeverIndex == leversInPuzzle.Length)
			{
				ItemToActivate.Activate ();
				print ("puzzle complete!");
			}
		}
		else
		{
			currentLeverIndex = 0;
			for (int i = 0; i < leversInPuzzle.Length; i++)
			{
				leversInPuzzle[i].Deactivate();
			}
		}
	}
}
