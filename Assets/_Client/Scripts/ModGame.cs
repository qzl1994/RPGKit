// Author:
// [LongTianhong]
//
// Copyright (C) 2014 Nanjing Xiaoxi Network Technology Co., Ltd. (http://www.mogoomobile.com)

using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameClient {

	public class ModGame : MonoBehaviour {
		[NonSerialized]
		public HeroData ChoosedHero;

		public void StartGame() {
			SceneManager.LoadScene("Game");
		}

	}
}