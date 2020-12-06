using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScroll : MonoBehaviour {
    [SerializeField] float ScrollSpeed = 0.5f;
    Material myMaterial;
    Vector2 offset;
	// Use this for initialization
	void Start () {
        myMaterial = GetComponent<Renderer>().material;
        offset = new Vector2(0f, ScrollSpeed);
	}
	
	// Update is called once per frame
	void Update () {
        myMaterial.mainTextureOffset += offset * Time.deltaTime;

    }
}
