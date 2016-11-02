using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class GameCamera : Singleton<GameCamera>{

	public Transform Target;
	public Vector3 PosOffset;
	public Vector3 Rotation;

	// Update is called once per frame
	void Update() {
		if (Target != null) {
			transform.position = Target.position + PosOffset;
			transform.eulerAngles = Rotation;
		}
	}
}
