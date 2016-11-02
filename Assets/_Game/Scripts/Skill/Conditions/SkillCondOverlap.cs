// Author:
// [LongTianhong]
//
// Copyright (C) 2014 Nanjing Xiaoxi Network Technology Co., Ltd. (http://www.mogoomobile.com)

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Game {

	public class SkillCondOverlap : SkillConditionBase {

		[SerializeField]
		private float _radius;

		[SerializeField]
		private bool _affectEnemy=true;


		void Awake() {
			skillBase.OnSpawn += OverlapAffect;
		}

		protected virtual void OverlapAffect() {
			var layer = _affectEnemy ? skillBase.skillInfo.User.cAttack.EnemyLayer : skillBase.skillInfo.User.cAttack.AllyLayer;
			var colliders = Physics.OverlapSphere(transform.position, _radius, layer);
			List<CBase> toAffects = new List<CBase>();
			foreach (var c in colliders) {
				if (c.attachedRigidbody != null) {
					var cbase = c.attachedRigidbody.GetComponent<CHealth>();
					if (cbase != null) {
						toAffects.Add(cbase);
					}
				}
			}
			foreach (var c in toAffects) {
				Affect(c);
			}

		}

		void OnDrawGizmos() {
			Gizmos.DrawWireSphere(transform.position, _radius);
		}


	}
}