using UnityEngine;
using System.Collections;

public class OpenPipe : NavigationBehaviour{
	
	public float splRad=100f;
	public float ringRad=12.5f;
//	public Vector3[][] ringsPoints;//private int _segments[][];
	private Transform[] lines;	
	private Transform splChild;
	
	public int segments=16;
	
	private void GenerateSplineNodes () {
		float maxFunc = Mathf.PI/2;
		for (int i=0;i<segments; i++){
			float bias=(i/(float)segments)*maxFunc;
			GameObject node = spline.AddSplineNode();
			node.name=""+i;
			node.transform.localPosition = new Vector3(Mathf.Sin(bias)*splRad,0f,Mathf.Cos(bias)*splRad);
			node.transform.localRotation = Quaternion.Euler(new Vector3(0f,bias*Mathf.Rad2Deg+90,0f));
			node.transform.parent = splChild;
		}
	}
	
	private Vector3 RotateAroundPoint(Vector3 point, Vector3 pivot, Quaternion angle){
    	return angle * ( point - pivot) + pivot;
    }
	
	// Use this for initialization
	void Awake () {
		splChild = new GameObject("Spline").transform;
		splChild.parent=transform;
		
		GenerateSplineNodes();
		
		lines = new Transform[12];
		
		for (int i=0; i<12; i++){
			Transform line = new GameObject("Line").transform;
			line.parent=transform;
			line.gameObject.AddComponent<LineRenderer>();
			lines[i]=line;
			float rBias = (i/12f)*(2*Mathf.PI);
			line.position = Vector3.zero;
			lines[i].gameObject.GetComponent<LineRenderer>().SetVertexCount(segments);
			for (int j=0; j<segments;j++){
				SplineNode node=spline.SplineNodes[j];
				lines[i].gameObject.GetComponent<LineRenderer>().SetPosition(j,
					node.transform.position+RotateAroundPoint(new Vector3(Mathf.Cos(rBias)*ringRad,Mathf.Sin(rBias)*ringRad, 0f), Vector3.zero, node.transform.rotation));
				lines[i].gameObject.GetComponent<LineRenderer>().useWorldSpace=false;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
