// Author:
// [LongTianhong]
//
// Copyright (C) 2014 Nanjing Xiaoxi Network Technology Co., Ltd. (http://www.mogoomobile.com)

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Game {

	public class EnemySpawner : MonoBehaviour {

		public float RandomRadius = 50f;

		public float Interval = 5f;

		private float timer = 0f;


		void Update() {
			timer += Time.deltaTime;
			if (timer >= Interval) {
				timer = 0f;
				SpawnEnemy();
			}
		}

		void SpawnEnemy(){
			int random = Random.Range(0, GameClient.Client.Ins.Enemy.EnemyDatas.Length);
			var enemyData = GameClient.Client.Ins.Enemy.EnemyDatas[random];
			var randomPos = new Vector3(
				transform.position.x + Random.Range(-RandomRadius, RandomRadius),
				0f,
				transform.position.z + Random.Range(-RandomRadius, RandomRadius));
			var enemyGo = Instantiate(Resources.Load(enemyData.Prefab), randomPos, Quaternion.identity) as GameObject;
			var enemyCom = enemyGo.AddComponent<Enemy>();
			enemyCom.InitAllCom(enemyData);


		}


		void OnDrawGizmosSelected() {
			Gizmos.DrawWireSphere(transform.position, RandomRadius);
		}
	}
}