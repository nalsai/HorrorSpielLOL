using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCollider : MonoBehaviour {
    

	void Start () {
        StartCoroutine(LOL());
    }

    IEnumerator LOL () {

        yield return new WaitForEndOfFrame();
        MeshCollider sc = gameObject.AddComponent(typeof(MeshCollider)) as MeshCollider;
    }
}
