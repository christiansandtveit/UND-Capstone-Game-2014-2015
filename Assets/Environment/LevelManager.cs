//Michael Schilling
//CSci 448
using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
    public void Reset()
    {
        AbstractResetable[] restables = FindObjectsOfType<AbstractResetable>();
        foreach (AbstractResetable item in restables)
        {
            item.Reset();
        }

		Carriable[] carriables = FindObjectsOfType<Carriable>();
		foreach (Carriable c in carriables)
		{
			if (c.isBeingCarried) Destroy(c.gameObject);
		}
    }
}
