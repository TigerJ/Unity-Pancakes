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

    public enum RotationStyle { Constant, Targeted }
    public bool generateAtRuntime = true;

    [HideInInspector]
    public GameObject RotationTarget;
    [HideInInspector]
    public RotationStyle rotationStyle;
    [HideInInspector]
    public float RotationSpeed = 1;
    void Start () {
		if(generateAtRuntime == true){
			StackGen();
		}
	}
	void Update () {        
        foreach (Transform spriteContainer in gameObject.transform)
        {
            if (spriteContainer.name == gameObject.name + " Sprite Container")
            {
                foreach (Transform stacked in spriteContainer.transform)
                {
                    if (rotationStyle == RotationStyle.Constant)
                        stacked.Rotate(new Vector3(0f, 0f, RotationSpeed));
                    if (rotationStyle == RotationStyle.Targeted)
                    {
                        Vector3 targetPosition = RotationTarget.transform.position;
						Vector3 direction = targetPosition - gameObject.transform.position;
						float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
						stacked.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                    }
                }
            }
        }
	}
	public void StackGen(){
		int count = 0;
		GameObject spriteContainer = new GameObject(gameObject.name+" Sprite Container");
		spriteContainer.transform.SetParent(gameObject.transform);
		foreach (Sprite s in Sprites){	
			GameObject spriteGameObject = new GameObject(gameObject.name+" Sprite "+count.ToString());
			SpriteRenderer spriteRenderer = spriteGameObject.AddComponent<SpriteRenderer>();
			spriteRenderer.sprite = s;
			spriteRenderer.sortingOrder = count;
			spriteRenderer.sortingLayerID = gameObject.GetComponent<SpriteRenderer>().sortingLayerID;
			spriteRenderer.sharedMaterial = gameObject.GetComponent<SpriteRenderer>().sharedMaterial;
			spriteGameObject.transform.position = new Vector3(gameObject.transform.position.x + CurrentX,gameObject.transform.position.y + CurrentY, 0);
			spriteGameObject.transform.rotation = gameObject.transform.rotation;
			spriteGameObject.transform.SetParent(spriteContainer.transform);
			CurrentX = CurrentX+OffsetX;
			CurrentY = CurrentY+OffsetY;
			count++;
		}
		generateAtRuntime = false;
	}
}
