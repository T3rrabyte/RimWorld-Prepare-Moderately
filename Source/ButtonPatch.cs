﻿using System;
using RimWorld;
using Verse;
using HarmonyLib;
using UnityEngine;

namespace PrepareModerately {
	[HarmonyPatch(typeof(Page_ConfigureStartingPawns), "DoWindowContents")]
	public class ButtonPatch {
		[HarmonyPostfix]
		public static void Postfix(Rect rect, Page_ConfigureStartingPawns __instance) {
			Vector2 buttonDimensions = new Vector2(150, 38);
			if (!Widgets.ButtonText(new Rect((rect.x + rect.width) / 2 - buttonDimensions.x / 2, rect.y - 45, buttonDimensions.x, buttonDimensions.y), "Prepare Moderately")) { return; }
			try {
				PrepareModerately.Instance.originalPage = __instance;
				Find.WindowStack.Add(PrepareModerately.Instance.page);
			} catch (Exception e) { Log.Warning("Failed to instantiate Prepare Moderately (unexpected exception).\n" + e.StackTrace); }
		}
	}
}