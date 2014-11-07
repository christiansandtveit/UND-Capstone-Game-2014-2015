//Michael Schilling
//CSci 448
using UnityEngine;
using System.Collections;

public class FallingPlatformManager : AbstractResetable
{

	public override void Reset()
	{
		FallingPlatform[] allPlatforms = GameObject.FindObjectsOfType<FallingPlatform>();
		for (int i = 0; i < allPlatforms.Length; i++)
		{
			allPlatforms[i].Reset();
		}
	}
}
