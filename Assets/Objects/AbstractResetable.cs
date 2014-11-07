//Michael Schilling
//CSci 448
using UnityEngine;
using System.Collections;

public abstract class AbstractResetable : MonoBehaviour, IResetable {
    abstract public void Reset();
}
