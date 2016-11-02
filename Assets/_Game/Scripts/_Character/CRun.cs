// Author:
// [LongTianhong]
//
// Copyright (C) 2014 Nanjing Xiaoxi Network Technology Co., Ltd. (http://www.mogoomobile.com)

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Game {

	public class CRun : CBase {

		public float Speed = 10;
		private Vector3 _dir;

		void Start() {
			cState.FSM.OnRunIn += o => {
				Move((Vector3)o);
			};
		}

		void Update() {
			if (cState.State == CharacterFSM.State.Run) {
				transform.LookAt(transform.position + _dir);
				transform.Translate(_dir * Speed * Time.deltaTime, Space.World);
			}
		}

		public void Move(Vector3 dir) {
			this._dir = dir.normalized;
		}

	}
}