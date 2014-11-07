//Michael Schilling
//CSci 448
using UnityEngine;
using System.Collections;

public class LightsOn : MonoBehaviour {

	public MultidimensionalTorch[] torchArray = new MultidimensionalTorch[3];
	public Activatable ItemToActivate;

	public void TorchToggled(int x, int y)
	{
		print ("toggle " + x + ", " + y);

		if (x > 0)
		{
			print ("1");
			print("torchArray["+(x-1)+"]["+y+"].Toggle(); " + torchArray[(x-1)][y].name);
			torchArray[(x-1)][y].Toggle();
		}

		if (y > 0)
		{
			print ("2");
			print("torchArray["+x+"]["+(y-1)+"].Toggle(); " + torchArray[x][(y-1)].name);
			torchArray[x][(y-1)].Toggle();
		}

		if(y < 2)
		{
			print ("3");
			print("torchArray["+x+"]["+(y+1)+"].Toggle(); " + torchArray[x][(y+1)].name);
			torchArray[x][(y+1)].Toggle();
		}

		if (x < 2)
		{
			print ("4");
			print("torchArray["+(x+1)+"]["+y+"].Toggle(); " + torchArray[(x+1)][y].name);
			torchArray[(x+1)][y].Toggle();
		}

		if (CheckForSuccess())
		{
			ItemToActivate.Activate();
			print ("WOOOO!!!!");
		}

	}

	bool CheckForSuccess()
	{
		for (int i = 0; i < torchArray.Length; i++)
		{
			for (int j = 0; j < torchArray[i].Length; j++)
			{
				if (!torchArray[i][j].Active)
				{
					return false;
				}
			}
		}
		return true;
	}
}
