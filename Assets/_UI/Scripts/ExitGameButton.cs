// Author:
// [LongTianhong]
//
// Copyright (C) 2014 Nanjing Xiaoxi Network Technology Co., Ltd. (http://www.mogoomobile.com)

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace Game {

	public class ExitGameButton : MonoBehaviour, IPointerClickHandler {
		public void OnPointerClick(PointerEventData eventData) {
			Application.LoadLevel("Menu");
			Time.timeScale = 1f;
		}
	}
}