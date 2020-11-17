using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public Camera mainCamera;

	public GameObject drawableRoad;
	private GameObject currentRoad;

	private LineRenderer lineRenderer;
	private EdgeCollider2D edgeCollider;

	private List<Vector2> mousePositions;

	// Start is called before the first frame update
	void Start() {
		mousePositions = new List<Vector2>();
	}

	// Update is called once per frame
	void Update() {
		if (Input.GetMouseButtonDown(0)) {
			CreateRoad();
		}

		if (Input.GetMouseButton(0)) {
			Vector2 mousePositionCurr = mainCamera.ScreenToWorldPoint(Input.mousePosition);
			if (Vector2.Distance(mousePositionCurr, mousePositions[mousePositions.Count - 1]) > 0.1f) {
				ExtendRoad(mousePositionCurr);
			}
		}
	}

	void CreateRoad() {
		currentRoad = Instantiate(drawableRoad, Vector2.zero, Quaternion.identity);
		lineRenderer = currentRoad.GetComponent<LineRenderer>();
		edgeCollider = currentRoad.GetComponent<EdgeCollider2D>();
		mousePositions.Clear();
		mousePositions.Add(mainCamera.ScreenToWorldPoint(Input.mousePosition));
		mousePositions.Add(mainCamera.ScreenToWorldPoint(Input.mousePosition));
		lineRenderer.SetPosition(0, mousePositions[0]);
		lineRenderer.SetPosition(1, mousePositions[1]);
		edgeCollider.points = mousePositions.ToArray();
	}

	void ExtendRoad(Vector2 mousePosition) {
		mousePositions.Add(mousePosition);
		int positionCount = lineRenderer.positionCount;
		positionCount++;
		lineRenderer.positionCount = positionCount;
		lineRenderer.SetPosition(positionCount - 1, mousePosition);
		edgeCollider.points = mousePositions.ToArray();
	}
}