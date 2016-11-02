// Author:
// [LongTianhong]
//
// Copyright (C) 2014 Nanjing Xiaoxi Network Technology Co., Ltd. (http://www.mogoomobile.com)

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Game {

	public class Hero : CBase {

		public static Hero ins;

		void Awake() {
			OnValidate();
			ins = this;
		}

		void Start() {
			cAttack.EnemyLayer = LayerMamanger.Ins.Enemy;
			cAttack.AllyLayer = LayerMamanger.Ins.Player;
			LayerMamanger.SetLayerRecursion(gameObject, LayerMamanger.Ins.Player);
		}

		void OnDestroy() {
			ins = null;
		}



	}
}