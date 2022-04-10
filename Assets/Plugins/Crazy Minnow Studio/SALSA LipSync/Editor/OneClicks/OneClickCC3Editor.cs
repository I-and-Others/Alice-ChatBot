using UnityEditor;
using UnityEngine;

namespace CrazyMinnow.SALSA.OneClicks
{
	/// <summary>
	/// RELEASE NOTES:
	///		2.5.1 (2021-06-29):
	///			~ Tweaks to SALSA, EmoteR, and Silence Analyzer settings.
	///			~ 't' and 'f' swapped in Visemes.
	/// 	2.5.0 (2020-08-20):
	/// 		REQUIRES: SALSA LipSync Suite v2.5.0+, does NOT work with prior versions.
	/// 		REQUIRES: OneClickBase v2.5.0+
	/// 		+ Support for Eyes module v2.5.0+
	/// 		+ Adds Advanced Dynamics Silence Analyzer to character.
	/// 		~ Tweaks to SALSA settings.
	///		2.3.0 (2020-02-02):
	/// 		~ updated to operate with SALSA Suite v2.3.0+
	/// 		NOTE: Does not work with prior versions of SALSA Suite (before v2.3.0)
	/// 	2.1.9 (2019-09-15):
	/// 		+ added support for merged UV exports which add suffix "_merged" to mesh object names, now allows
	/// 			any suffix.
	/// 	2.1.8 (2019-09-10):
	/// 		+ added support for DAZ-based meshes in CC3 (eyes).
	/// 		~ tuned support for DAZ-based meshes in CC3 (salsa).
	///		2.1.7 (2019-09-04):
	///			+ added support for "game" base mesh exports.
	///			+ added support for DAZ-based meshes in CC3 (salsa/emoter only).
	/// 	2.1.6 (2019-07-25):
	/// 		~ adjusted visemes ee, oo for better general model presentation.
	/// 	2.1.5 (2019-07-17):
	/// 		~ now uses regex option for blendshape searches (salsa,emoter) to handle 3DXchange exported names.
	/// 	2.1.4 (2019-07-08):
	/// 		! corrected blendshape name in EmoteR:flare.
	/// 	2.1.3 (2019-07-07):
	/// 		~ durations added to bone component types.
	/// 	2.1.2 (2019-07-03):
	/// 		- confirmed operation with Base 2.1.2
	///			~ updated viseme (oo).
	/// 	2.1.1 (2019-06-28):
	/// 		+ 2018.4+ check for prefab and warn > then unpack or cancel.
	/// 	2.1.0:
	/// 		~ convert from editor code to full engine code and move to Plugins.
	///		2.0.0-BETA : Initial release.
	/// ==========================================================================
	/// PURPOSE: This script provides simple, simulated lip-sync input to the
	///		Salsa component from text/string values. For the latest information
	///		visit crazyminnowstudio.com.
	/// ==========================================================================
	/// DISCLAIMER: While every attempt has been made to ensure the safe content
	///		and operation of these files, they are provided as-is, without
	///		warranty or guarantee of any kind. By downloading and using these
	///		files you are accepting any and all risks associated and release
	///		Crazy Minnow Studio, LLC of any and all liability.
	/// ==========================================================================
	/// </summary>

	public class OneClickCC3Editor : Editor
	{
		[MenuItem("GameObject/Crazy Minnow Studio/SALSA LipSync/One-Clicks/CC3")]
		public static void OneClickSetup()
		{
			GameObject go = Selection.activeGameObject;

#if UNITY_2018_3_OR_NEWER
				if (PrefabUtility.IsPartOfAnyPrefab(go))
				{
					if (EditorUtility.DisplayDialog(
													OneClickBase.PREFAB_ALERT_TITLE,
													OneClickBase.PREFAB_ALERT_MSG,
													"YES", "NO"))
					{
						PrefabUtility.UnpackPrefabInstance(go, PrefabUnpackMode.OutermostRoot, InteractionMode.AutomatedAction);
						ApplyOneClick(go);
					}
				}
				else
				{
					ApplyOneClick(go);
				}
#else
			ApplyOneClick(go);
#endif
		}

		private static void ApplyOneClick(GameObject go)
		{
			OneClickCC3.Setup(go, AssetDatabase.LoadAssetAtPath<AudioClip>(OneClickBase.RESOURCE_CLIP));
			OneClickCC3Eyes.Setup(Selection.activeGameObject);
		}
	}
}