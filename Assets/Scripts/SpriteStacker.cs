using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteStacker : MonoBehaviour {
	public List<Sprite> Sprites;
	public float OffsetX = 0;
	public float OffsetY = 0;
	float CurrentX = 0;
	float CurrentY = 0;
	public float RotationSpeed = 1;
	List<GameObject> spriteCollection;

	// Use this for initialization
	void Start () {
		spriteCollection = new List<GameObject>();
		int count = 0;
		foreach (Sprite s in Sprites){
			
			GameObject spriteGameObject = new GameObject(gameObject.name+" Sprite "+count.ToString());
			SpriteRenderer spriteRenderer = spriteGameObject.AddComponent<SpriteRenderer>();
			spriteRenderer.sprite = s;
			spriteRenderer.sortingOrder = count;
			spriteRenderer.sortingLayerID = gameObject.GetComponent<SpriteRenderer>().sortingLayerID;
			spriteGameObject.transform.position = new Vector3(CurrentX,CurrentY,0);
			spriteGameObject.transform.rotation = gameObject.transform.rotation;
			spriteGameObject.transform.SetParent(gameObject.transform);
			spriteCollection.Add(spriteGameObject);
			CurrentX = CurrentX+OffsetX;
			CurrentY = CurrentY+OffsetY;
			count++;
		}
	}
	
	// Update is called once per frame
	void Update () {
		foreach(GameObject g in spriteCollection){
			g.transform.Rotate(new Vector3(0f,0f,RotationSpeed));
		}
	}
}
