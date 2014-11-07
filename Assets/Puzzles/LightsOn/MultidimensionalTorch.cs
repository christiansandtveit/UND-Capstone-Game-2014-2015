//Michael Schilling
//CSci 448
using UnityEngine;
using System.Collections;

[System.Serializable]
public class MultidimensionalTorch
{
	public Torch[] torchArray = new Torch[0];
	
	public Torch this[int index]
	{
		get
		{
			return torchArray[index];
		}
		
		set
		{
			torchArray[index] = value;
		}
	}
	
	public int Length
	{
		get
		{
			return torchArray.Length;
		}
	}
}
