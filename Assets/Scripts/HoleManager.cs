using UnityEngine;
using System.Collections.Generic;
using DG.Tweening;

[RequireComponent(typeof(Magnet))]

public class HoleManager : MonoBehaviour
{
    [Header("Hole mesh")]
    [SerializeField] private MeshFilter meshFilter;
    [SerializeField] private MeshCollider meshCollider;

    [Header("Hole vertices radius")]
    [SerializeField] private Vector2 moveLimits;
    [SerializeField] private float radius;
    [SerializeField] private Transform holeCenter;
    [SerializeField] private Transform rotatingCircle;

    [Space]
    [SerializeField] float moveSpeed;

    private Magnet magnet;
    private bool isMoving;
    private bool isActive;
    private Mesh mesh;
    private List<int> holeVertices = new List<int>();
    private List<Vector3> offsets = new List<Vector3>();
    private int holeVerticesCount;

    private float x, y;
    private Vector3 touchPosition, targetPosition;

    private void Awake()
    {
        magnet = GetComponent<Magnet>();
    }

    private void Update()
    {
        if (!isActive)
        {
            return;
        }
            
#if UNITY_EDITOR

        isMoving = Input.GetMouseButton(0);

        if (isMoving)
        {
            UpdateHoleMoving();
            UpdateHoleVerticesPosition();
        }

#else
		isMoving = Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved;

		if (isMoving) 
		{
			UpdateHoleMoving();
			UpdateHoleVerticesPosition();
		}
#endif
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(holeCenter.position, radius);
    }

    public void Activate()
    {
        isActive = true;
        magnet.Activate();
    }

    public void Deactivate()
    {
        isActive = false;
        magnet.Deactivate();
    }

    public void Initialize()
    {
        mesh = meshFilter.mesh;
        StartCircleRotationAnimation();
        InitializeHoleVertices();
        Activate();
    }

    private void StartCircleRotationAnimation()
    {
        rotatingCircle.DORotate(new Vector3(90f, 0f, -90f), .2f)
            .SetEase(Ease.Linear)
            .From(new Vector3(90f, 0f, 0f))
            .SetLoops(-1, LoopType.Incremental);
    }

    private void UpdateHoleMoving()
    {
        x = Input.GetAxis("Mouse X");
        y = Input.GetAxis("Mouse Y");

        touchPosition = Vector3.Lerp(holeCenter.position,
            holeCenter.position + new Vector3(x, 0f, y),
            moveSpeed * Time.deltaTime);

        targetPosition = new Vector3(Mathf.Clamp(touchPosition.x, -moveLimits.x, moveLimits.x),
            touchPosition.y, Mathf.Clamp(touchPosition.z, -moveLimits.y, moveLimits.y));

        holeCenter.position = targetPosition;
    }

    private void UpdateHoleVerticesPosition()
    {
        var vertices = mesh.vertices;

        for (int i = 0; i < holeVerticesCount; i++)
        {
            vertices[holeVertices[i]] = holeCenter.position + offsets[i];
        }

        mesh.vertices = vertices;
        meshFilter.mesh = mesh;
        meshCollider.sharedMesh = mesh;
    }

    private void InitializeHoleVertices()
    {
        for (int i = 0; i < mesh.vertices.Length; i++)
        {
            float distance = Vector3.Distance(holeCenter.position, mesh.vertices[i]);

            if (distance < radius)
            {
                holeVertices.Add(i);
                offsets.Add(mesh.vertices[i] - holeCenter.position);
            }
        }

        holeVerticesCount = holeVertices.Count;
    }
}
