﻿using Hover.Core.Cursors;
using Hover.Core.Items.Types;
using Hover.Core.Utils;
using Hover.InterfaceModules.Cast;
using UnityEngine;

namespace HoverDemos.CastCubes.Inputs {

	/*================================================================================================*/
	public class DemoAdjustMainSceneForVive : HoverSceneAdjust {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override bool IsReadyToAdjust() {
			return (FindObjectOfType<HovercastInterface>() != null);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void PerformAdjustments() {
			HovercastInterface cast = FindObjectOfType<HovercastInterface>();
			DemoHovercastCustomizer castCustom = cast.GetComponent<DemoHovercastCustomizer>();

			Deactivate(UnityUtil.FindComponentAll<Camera>("MainCamera").gameObject);
			Deactivate(UnityUtil.FindComponentAll<HoverItemDataSelector>("Re-orient"));

			castCustom.StandardFollowCursor = CursorType.LeftPinky;
			castCustom.SwitchedFollowCursor = CursorType.RightPinky;
			castCustom.StandardInteractionCursor = CursorType.RightMiddle;
			castCustom.SwitchedInteractionCursor = CursorType.LeftMiddle;
		}

	}

}
