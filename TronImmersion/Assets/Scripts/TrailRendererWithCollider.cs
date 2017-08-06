using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailRendererWithCollider : MonoBehaviour {

	public TrailRenderer trail;
	public Vector3[] m_newVertices;
	public Vector2[] m_newUV;
	public int[] m_newTriangles;

	GameObject trailMesh;
	MeshCollider meshCollider;
	MeshFilter filtermesh;


	void Awake()
	{
		//trail.GetComponent<TrailRenderer>();
	}
	void Start() {
		Mesh mesh = new Mesh();
		GetComponent<MeshFilter>().mesh = mesh;
		mesh.vertices = m_newVertices;
		mesh.uv = m_newUV;
		mesh.triangles = m_newTriangles;
	}

	void Update() {
		Mesh mesh = GetComponent<MeshFilter>().mesh;
		Vector3[] vertices = mesh.vertices;
		Vector3[] normals = mesh.normals;
		int i = 0;
		while (i < vertices.Length) {
			vertices[i] += normals[i] * Mathf.Sin(Time.time);
			i++;
		}
		mesh.vertices = vertices;
		Debug.Log(mesh.vertices);

		gameObject.AddComponent<MeshCollider>();
		gameObject.GetComponent<MeshCollider>().sharedMesh = mesh;
		meshCollider = gameObject.GetComponent<MeshCollider>();
		
	}

}
