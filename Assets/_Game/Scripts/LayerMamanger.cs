// Author:
// [LongTianhong]
//
// Copyright (C) 2014 Nanjing Xiaoxi Network Technology Co., Ltd. (http://www.mogoomobile.com)

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Game {

	public class LayerMamanger : Singleton<LayerMamanger> {

		public LayerMask Player;
		public LayerMask Enemy;


		public static void SetLayer(GameObject g, LayerMask layer) {
			g.layer = GetLayerIndex(layer);
		}

		public static void SetLayerRecursion(GameObject g, LayerMask layer) {
			g.layer = GetLayerIndex(layer);
			foreach (Transform child in g.transform) {
				SetLayerRecursion(child.gameObject, layer);
			}
		}

		public static void SetLyaerRecursion(GameObject g, int layer) {
			g.layer = layer;
			foreach (Transform child in g.transform) {
				SetLayerRecursion(child.gameObject, layer);
			}
		}

		public static int GetLayerIndex(LayerMask layer) {
			string l = System.Convert.ToString(layer.value, 2);
			return l.Length - 1;
		}
	}
}