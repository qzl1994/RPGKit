// Author:
// [LongTianhong]
//
// Copyright (C) 2014 Nanjing Xiaoxi Network Technology Co., Ltd. (http://www.mogoomobile.com)

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Game {

	public class GameManager : Singleton<GameManager> {

		void Start() {
			var heroData = GameClient.Client.Ins.Game.ChoosedHero;
			var heroGO = Instantiate(Resources.Load(heroData.Prefab), Vector3.zero, Quaternion.identity) as GameObject;
			var heroCom = heroGO.AddComponent<Hero>();
			heroCom.InitAllCom(heroData);
			PlayerController.Ins.hero = heroCom;
			GameCamera.Ins.Target = heroGO.transform;
		}


	}
}