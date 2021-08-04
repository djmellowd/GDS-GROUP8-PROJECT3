using UnityEngine;
using System.Collections;

public class control : MonoBehaviour
{
	[SerializeField] private Camera cam;

	float distance = 10;
	void OnMouseDrag()
	{
		Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
		Vector3 objPosition = cam.ScreenToWorldPoint(mousePosition);
		transform.position = objPosition;
	}
}
