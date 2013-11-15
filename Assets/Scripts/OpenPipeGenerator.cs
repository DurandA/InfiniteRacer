using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NavigationBehaviour))]
public class OpenPipeGenerator : MonoBehaviour{
	
	public float splRad=200f;
	public float ringRad=25f;
//	public Vector3[][] ringsPoints;//private int _segments[][];
	private Transform[] lines;	
	private Transform splChild;
	
	public int segments=16;
	
	private void GenerateSplineNodes () {
		float arc = Mathf.PI/2;
		for (int i=0;i<segments; i++){
			float bias=(i/(float)segments)*arc;
			GameObject node = GetComponent<NavigationBehaviour>().spline.AddSplineNode();
			node.name=""+i;
			
			node.transform.parent = splChild;
			node.transform.localPosition = new Vector3(Mathf.Cos(bias)*splRad-splRad,0f,Mathf.Sin(bias)*splRad);
			node.transform.localRotation = Quaternion.Euler(new Vector3(0f,bias*-Mathf.Rad2Deg/*-90*/,0f));
			
		}
	}
	
	private Vector3 RotateAroundPoint(Vector3 point, Vector3 pivot, Quaternion angle){
    	return angle * ( point - pivot) + pivot;
    }
	
	// Use this for initialization
	void Start () {
		splChild = new GameObject("Spline").transform;
		splChild.parent=transform;
		splChild.localPosition=Vector3.zero;
		splChild.localRotation=Quaternion.identity;
		
		GenerateSplineNodes();
		
		lines = new Transform[12];
		
		for (int i=0; i<12; i++){
			Transform line = new GameObject("Line").transform;
			line.parent=transform;
			line.localPosition=Vector3.zero;
			line.localRotation=Quaternion.identity;
			line.gameObject.AddComponent<LineRenderer>();
			lines[i]=line;
			float rBias = (i/12f)*(2*Mathf.PI);
			lines[i].gameObject.GetComponent<LineRenderer>().SetVertexCount(segments);
			for (int j=0; j<segments;j++){
				SplineNode node=GetComponent<NavigationBehaviour>().spline.SplineNodes[j];
				lines[i].gameObject.GetComponent<LineRenderer>().useWorldSpace=false;
				lines[i].gameObject.GetComponent<LineRenderer>().SetPosition(j,
					node.transform.localPosition+RotateAroundPoint(new Vector3(Mathf.Cos(rBias)*ringRad,Mathf.Sin(rBias)*ringRad, 0f), Vector3.zero, node.transform.localRotation));
				
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
