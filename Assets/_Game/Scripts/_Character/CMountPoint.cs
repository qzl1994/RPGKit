// Author:
// [LongTianhong]
//
// Copyright (C) 2014 Nanjing Xiaoxi Network Technology Co., Ltd. (http://www.mogoomobile.com)

using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Game {
	public enum MountPoint {
		Head, LeftHand, LeftWeapon, RightHand, RightWeapon, Body, Foot, BodyFront, Custom1, Custom2, Custom3
	}

	[System.Serializable]
	public struct MountPointWithTrans {
		public MountPoint type;
		public Transform trans;
	}

	public class CMountPoint : CBase {

		private Dictionary<MountPoint, Transform> _mpDic;
		[SerializeField]
		private List<MountPointWithTrans> _mpList;

		void Awake() {
			_mpDic=new Dictionary<MountPoint, Transform>();
			foreach (var mp in _mpList) {
				_mpDic.Add(mp.type, mp.trans);
			}
		}

		public Transform this[MountPoint mp] {
			get {
				return _mpDic[mp];
			}
		}

		[ContextMenu("AutoCreate")]
		internal void AutoCreate() {
			_mpList = new List<MountPointWithTrans>();
			foreach (var mpName in Enum.GetValues(typeof(MountPoint))) {
				var mp = new GameObject("mp_" + mpName).transform;
				mp.SetParent(gameObject.transform, false); _mpList.Add(new MountPointWithTrans() {
					type = (MountPoint)mpName,
					trans = mp
				});
			}
		}

	}
}