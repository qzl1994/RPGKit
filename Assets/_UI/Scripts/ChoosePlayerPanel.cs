// Author:
// [LongTianhong]
//
// Copyright (C) 2014 Nanjing Xiaoxi Network Technology Co., Ltd. (http://www.mogoomobile.com)

using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameClient;
using UnityEngine.UI;

namespace UI {

	public class ChoosePlayerPanel : MonoBehaviour {


		public GameObject PlayerItemPrefab;

		public GridLayoutGroup Grid;
		private RectTransform _gridRectTransform;
		public ScrollRect Scroll;

		private List<PlayerChooseItem> _items;

		private float _widthPerItem;

		void Awake() {
			_items=new List<PlayerChooseItem>();
			_gridRectTransform = Grid.GetComponent<RectTransform>();
			_widthPerItem = Scroll.content.rect.width;
		}

		void OnEnable() {
			var playerDatas = Client.Ins.Player.HeroDatas;
			foreach (var playerData in playerDatas) {
				InsertItem(playerData);
			}
		}

		void OnDisable(){
			foreach (var item in _items){
				Destroy(item.gameObject);
			}
			_items.Clear();
		}

		public void InsertItem(HeroData data) {
			PlayerChooseItem item = Instantiate(PlayerItemPrefab).GetComponent<PlayerChooseItem>();
			item.Init(data);
			_items.Add(item);
			item.transform.SetParent(_gridRectTransform);
			item.transform.localScale = Vector3.one;
			var rect = Scroll.content.rect;
			rect.width = _widthPerItem * _items.Count;
			Scroll.content.sizeDelta = new Vector2(rect.width, rect.height);
		}


	}
}