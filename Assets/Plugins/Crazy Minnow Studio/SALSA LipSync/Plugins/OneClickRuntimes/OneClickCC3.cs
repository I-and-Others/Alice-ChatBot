using UnityEngine;

namespace CrazyMinnow.SALSA.OneClicks
{
	public class OneClickCC3 : OneClickBase
	{
		/// <summary>
		/// RELEASE NOTES:
		/// 2021-06-29: updated visemes, tweaked tongue and shapes to correspond to
		///		latest Minnow preferences. Added "Darrin's Tweaks" to SALSA, EmoteR,
		///		and Silence Analyzer.
		/// 2019-07-25: updated visemes ee, oo.
		/// 2019-07-17: updated blendshape search to use regex.
		/// 2019-06-29: updated viseme (oo).
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
		public static void Setup(GameObject gameObject, AudioClip clip)
		{
			////////////////////////////////////////////////////////////////////////////////////////////////////////////
			//	SETUP Requirements:
			//		use NewExpression("expression name") to start a new viseme/emote expression.
			//		use AddShapeComponent to add blendshape configurations, passing:
			//			- string array of shape names to look for.
			//			  : string array can be a single element.
			//			  : string array can be a single regex search string.
			//			    note: useRegex option must be set true.
			//			- optional string name prefix for the component.
			//			- optional blend amount (default = 1.0f).
			//			- optional regex search option (default = false).

			Init();

			#region SALSA-Configuration
			NewConfiguration(OneClickConfiguration.ConfigType.Salsa);
			{
				////////////////////////////////////////////////////////
				// SMR regex searches (enable/disable/add as required).
				AddSmrSearch("^CC_(base|game)_Body.*$");
				AddSmrSearch("^CC_(base|game)_Tongue.*$");
				AddSmrSearch("^genesis([238])?(fe)?(male)?\\.shape.*$");
				AddSmrSearch("^genesis[238](fe)?maleeyelashes\\.shape.*$");
				AddSmrSearch("^emotiguy.*\\.shape.*$");


				////////////////////////////////////////////////////////
				// Adjust SALSA settings to taste...
				// - data analysis settings
				autoAdjustAnalysis = true;
				autoAdjustMicrophone = false;
				audioUpdateDelay = 0.095f;
				// - advanced dynamics settings
				loCutoff = 0.015f;
				hiCutoff = 0.75f;
				useAdvDyn = true;
				advDynPrimaryBias = 0.50f;
				useAdvDynJitter = false;
				advDynJitterAmount = 0.10f;
				advDynJitterProb = 0.20f;
				advDynSecondaryMix = 0.0f;
				emphasizerTrigger = 0.0f;

				////////////////////////////////////////////////////////
				// Viseme setup...

				NewExpression("w");
				AddBoneComponent("^CC_Base_Teeth02$",
					new TformBase(new Vector3(-0.08919834f, 0.02136874f, 6.878996E-05f),
					new Quaternion(0.9989499f, -0.04581843f, 5.542967E-07f, 2.483174E-07f),
					new Vector3(1f, 1f, 1f)),
					0.11f, 0f, 0.06f,
					"CC_Base_Teeth02",
					false, true, true);
				AddShapeComponent(new []{"^Mouth_Lips_Open.*$"}, 0.11f, 0f, 0.06f, "Mouth_Lips_Open", 0.274f, true);
				AddShapeComponent(new []{"^Mouth_Pucker.*$"}, 0.11f, 0f, 0.06f, "Mouth_Pucker", 0.947f, true);
				AddShapeComponent(new []{"^Jaw_Rotate_D.*$"}, 0.11f, 0f, 0.06f, "Jaw_Rotate_D", 0.03f, true); // specific to daz-imported model
				AddShapeComponent(new []{"^W_OO.*$"}, 0.11f, 0f, 0.06f, "W_OO", 0.3f, true); // specific to daz-imported model

				NewExpression("f");
				AddBoneComponent("^CC_Base_Teeth02$",
					new TformBase(new Vector3(-0.0324338f, 0.007857325f, 2.743636E-05f),
					new Quaternion(0.9980999f, -0.06161553f, -3.538369E-06f, 4.562023E-08f),
					new Vector3(0.9999998f, 0.9999998f, 1f)),
					0.11f, 0f, 0.06f,
					"CC_Base_Teeth02",
					false, true, true);
				AddShapeComponent(new []{"^Mouth_Lips_Open.*$"}, 0.11f, 0f, 0.06f, "Mouth_Lips_Open", 0.184f, true);
				AddShapeComponent(new []{"^Mouth_Top_Lip_Up.*$"}, 0.11f, 0f, 0.06f, "Mouth_Top_Lip_Up", 1f, true);
				AddShapeComponent(new []{"^Mouth_Bottom_Lip_Under.*$"}, 0.11f, 0f, 0.06f, "Mouth_Bottom_Lip_Under", 0.93f, true);
				AddShapeComponent(new []{"^Mouth_Smile.*$"}, 0.11f, 0f, 0.06f, "Mouth_Smile", 0.346f, true);
				AddShapeComponent(new []{"^Jaw_Rotate_D.*$"}, 0.11f, 0f, 0.06f, "Jaw_Rotate_D", 0.045f, true); // specific to daz-imported model

				NewExpression("t");
				AddBoneComponent("^CC_Base_Teeth02$",
					new TformBase(new Vector3(-0.08919264f, 0.02130297f, 6.758845E-05f),
					new Quaternion(0.9997423f, -0.02270268f, -9.837181E-05f, -7.784013E-05f),
					new Vector3(1f, 1f, 1f)),
					0.11f, 0f, 0.06f,
					"CC_Base_Teeth02",
					false, true, true);
				AddShapeComponent(new []{"^Lip_Open.*$"}, 0.11f, 0f, 0.06f, "Lip_Open", 0.791f, true);
				AddShapeComponent(new []{"^Tongue_Raise.*$"}, 0.11f, 0f, 0.06f, "Tongue_Raise", 0.388f, true);
				AddShapeComponent(new []{"^Mouth_Smile.*$"}, 0.11f, 0f, 0.06f, "Mouth_Smile", 0.304f, true);
				AddShapeComponent(new []{"^K_G.*$"}, 0.11f, 0f, 0.06f, "K_G", 1.0f, true); // specific to daz-imported model

				NewExpression("th");
				AddBoneComponent("^CC_Base_Teeth02$",
					new TformBase(new Vector3(-0.08920127f, 0.02119994f, 6.596436E-05f),
					new Quaternion(0.9974532f, -0.07132349f, -0.0001023601f, -7.284068E-05f),
					new Vector3(1f, 1f, 1f)),
					0.11f, 0f, 0.06f,
					"CC_Base_Teeth02",
					false, true, true);
				// AddShapeComponent(new []{"^Tongue_Raise.*$"}, 0.11f, 0f, 0.06f, "Tongue_Raise", 0.091f, true);
				AddShapeComponent(new []{"^Mouth_Lips_Open.*$"}, 0.11f, 0f, 0.06f, "Mouth_Lips_Open", 0.591f, true);
				AddShapeComponent(new []{"^Mouth_Bottom_Lip_Under.*$"}, 0.11f, 0f, 0.06f, "Mouth_Bottom_Lip_Under", 0.938f, true);
				// AddShapeComponent(new []{"^Mouth_Top_Lip_Up.*$"}, 0.11f, 0f, 0.06f, "Mouth_Top_Lip_Up", 0.828f, true);
				AddShapeComponent(new []{"^Tongue_Out.*$"}, 0.11f, 0f, 0.06f, "Tongue_Out", 0.587f, true);
				AddShapeComponent(new []{"^Mouth_Blow.*$"}, 0.11f, 0f, 0.06f, "Mouth_Blow", 0.357f, true);
				AddShapeComponent(new []{"^TH.*$"}, 0.11f, 0f, 0.06f, "TH", 0.468f, true); // specific to daz-imported model

				NewExpression("ow");
				AddBoneComponent("^CC_Base_Teeth02$",
					new TformBase(new Vector3(-0.08919986f, 0.0212258f, 6.63704E-05f),
					new Quaternion(0.9962508f, -0.0865129f, 2.735796E-07f, 2.003616E-07f),
					new Vector3(1f, 1f, 1f)),
					0.11f, 0f, 0.06f,
					"CC_Base_Teeth02",
					false, true, true);
				AddShapeComponent(new []{"^Tongue_Narrow.*$"}, 0.11f, 0f, 0.06f, "Tongue_Narrow", 0.341f, true);
				AddShapeComponent(new []{"^Tongue_Lower.*$"}, 0.11f, 0f, 0.06f, "Tongue_Lower", 0.532f, true);
				AddShapeComponent(new []{"^Mouth_Lips_Open.*$"}, 0.11f, 0f, 0.06f, "Mouth_Lips_Open", 0.649f, true);
				AddShapeComponent(new []{"^Mouth_Blow.*$"}, 0.11f, 0f, 0.06f, "Mouth_Blow", 0.735f, true);
				AddShapeComponent(new []{"^Oh.*$"}, 0.11f, 0f, 0.06f, "Oh", 0.432f, true); // specific to daz-imported model

				NewExpression("ee");
				AddBoneComponent("^CC_Base_Teeth02$",
					new TformBase(new Vector3(-0.03243628f, 0.007824888f, 2.743544E-05f),
					new Quaternion(0.9995517f, -0.02994212f, -1.526135E-05f, -1.278058E-05f),
					new Vector3(1f, 0.9999964f, 0.9999963f)),
					0.11f, 0f, 0.06f,
					"CC_Base_Teeth02",
					false, true, true);
				AddShapeComponent(new []{"^Mouth_Smile.*$"}, 0.11f, 0f, 0.06f, "Mouth_Smile", 0.856f, true);
				AddShapeComponent(new []{"^Mouth_Widen.*$"}, 0.11f, 0f, 0.06f, "Mouth_Widen", 0.95f, true);
				AddShapeComponent(new []{"^Lip_Open.*$"}, 0.11f, 0f, 0.06f, "Lip_Open", 0.79f, true);
				AddShapeComponent(new []{"^Mouth_Top_Lip_Up.*$"}, 0.11f, 0f, 0.06f, "Mouth_Top_Lip_Up", 0.256f, true);
				AddShapeComponent(new []{"^Mouth_Bottom_Lip_Down.*$"}, 0.11f, 0f, 0.06f, "Mouth_Bottom_Lip_Down", 0.432f, true);
				AddShapeComponent(new []{"^Jaw_Rotate_D.*$"}, 0.11f, 0f, 0.06f, "Jaw_Rotate_D", 0.11f, true); // specific to daz-imported model
				AddShapeComponent(new []{"^EE.*$"}, 0.11f, 0f, 0.06f, "EE", 0.24f, true); // specific to daz-imported model

				NewExpression("oo");
				AddBoneComponent("^CC_Base_Teeth02$",
					new TformBase(new Vector3(-0.03243638f, 0.007819163f, 2.743462E-05f),
					new Quaternion(0.9785977f, -0.2057828f, -1.172147E-05f, 1.539989E-06f),
					new Vector3(0.9999998f, 0.9999998f, 1f)),
					0.11f, 0f, 0.06f,
					"CC_Base_Teeth02",
					false, true, true);
				AddShapeComponent(new []{"^Tongue_Lower.*$"}, 0.11f, 0f, 0.06f, "Tongue_Lower", 1f, true);
				AddShapeComponent(new []{"^Mouth_Lips_Open.*$"}, 0.11f, 0f, 0.06f, "Mouth_Lips_Open", 0.422f, true);
				AddShapeComponent(new []{"^Mouth_Open.*$"}, 0.11f, 0f, 0.06f, "Mouth_Open", 0.964f, true);
				AddShapeComponent(new []{"^Mouth_Pucker_Open.*$"}, 0.11f, 0f, 0.06f, "Mouth_Pucker_Open", 0.517f, true);
			}
			#endregion // SALSA-configuration

			#region EmoteR-Configuration
			NewConfiguration(OneClickConfiguration.ConfigType.Emoter);
			{
				////////////////////////////////////////////////////////
				// SMR regex searches (enable/disable/add as required).
				AddSmrSearch("^CC_(base|game)_Body$");
				AddSmrSearch("^genesis([238])?(fe)?(male)?\\.shape.*$");
				AddSmrSearch("^genesis[238](fe)?maleeyelashes\\.shape.*$");
				AddSmrSearch("^emotiguy.*\\.shape.*$");

				useRandomEmotes = false;
				isChancePerEmote = true;
				numRandomEmotesPerCycle = 0;
				randomEmoteMinTimer = 1f;
				randomEmoteMaxTimer = 2f;
				randomChance = 0.5f;
				useRandomFrac = false;
				randomFracBias = 0.5f;
				useRandomHoldDuration = false;
				randomHoldDurationMin = 0.1f;
				randomHoldDurationMax = 0.5f;

				////////////////////////////////////////////////////////
				// Emote setup...

				NewExpression("exasper");
				AddEmoteFlags(false, true, false, 1f, true);
				AddShapeComponent(new []{"^Cheek_Blow_L.*$"}, 0.2f, 0.1f, 0.15f, "Cheek_Blow_L", 0.297f, true);
				AddShapeComponent(new []{"^Cheek_Blow_R.*$"}, 0.2f, 0.1f, 0.15f, "Cheek_Blow_R", 0.199f, true);
				AddShapeComponent(new []{"^Brow_Raise_L.*$"}, 0.2f, 0.1f, 0.15f, "Brow_Raise_L", 0.555f, true);
				AddShapeComponent(new []{"^Brow_Raise_Inner_R.*$"}, 0.2f, 0.1f, 0.15f, "Brow_Raise_Inner_R", 0.52f, true);

				NewExpression("soften");
				AddEmoteFlags(false, true, false, 1f);
				AddShapeComponent(new []{"^Mouth_Smile.*$"}, 0.2f, 0.1f, 0.15f, "Mouth_Smile", 0.45f, true);
				AddShapeComponent(new []{"^Eye_Squint_L.*$"}, 0.2f, 0.1f, 0.15f, "Eye_Squint_L", 0.45f, true);
				AddShapeComponent(new []{"^Eye_Squint_R.*$"}, 0.2f, 0.1f, 0.15f, "Eye_Squint_R", 0.45f, true);
				AddShapeComponent(new []{"^Brow_Raise_Inner_L.*$"}, 0.2f, 0.1f, 0.15f, "Brow_Raise_Inner_L", 0.45f, true);
				AddShapeComponent(new []{"^Brow_Raise_Inner_R.*$"}, 0.2f, 0.1f, 0.15f, "Brow_Raise_Inner_R", 0.45f, true);

				NewExpression("browsUp");
				AddEmoteFlags(false, true, false, 1f);
				AddShapeComponent(new []{"^Brow_Raise_L.*$"}, 0.2f, 0.1f, 0.15f, "Brow_Raise_L", 0.907f, true);
				AddShapeComponent(new []{"^Brow_Raise_R.*$"}, 0.25f, 0.2f, 0.1f, "Brow_Raise_R", 0.72f, true);
				AddShapeComponent(new []{"^Brow_Raise_Inner_R.*$"}, 0.25f, 0.2f, 0.15f, "Brow_Raise_Inner_R", 0.68f, true);
				AddShapeComponent(new []{"^Brow_Raise_Inner_L.*$"}, 0.2f, 0.08f, 0.15f, "Brow_Raise_Inner_L", 0.687f, true);

				NewExpression("browUp");
				AddEmoteFlags(false, true, false, 1f);
				AddShapeComponent(new []{"^Brow_Raise_R.*$"}, 0.2f, 0.1f, 0.15f, "Brow_Raise_R", 0.946f, true);
				AddShapeComponent(new []{"^Brow_Raise_Inner_R.*$"}, 0.2f, 0.1f, 0.15f, "Brow_Raise_Inner_R", 0.457f, true);
				AddShapeComponent(new []{"^Brow_Raise_Inner_L.*$"}, 0.2f, 0.1f, 0.15f, "Brow_Raise_Inner_L", 0.749f, true);

				NewExpression("squint");
				AddEmoteFlags(false, true, false, 1f);
				AddShapeComponent(new []{"^Brow_Drop_L.*$"}, 0.2f, 0.1f, 0.15f, "Brow_Drop_L", 0.311f, true);
				AddShapeComponent(new []{"^Brow_Drop_R.*$"}, 0.2f, 0.1f, 0.15f, "Brow_Drop_R", 0.45f, true);
				AddShapeComponent(new []{"^Eye_Squint_L.*$"}, 0.2f, 0.1f, 0.15f, "Eye_Squint_L", 0.45f, true);
				AddShapeComponent(new []{"^Eye_Squint_R.*$"}, 0.2f, 0.1f, 0.15f, "Eye_Squint_R", 0.45f, true);
				AddShapeComponent(new []{"^Brow_Raise_Inner_R.*$"}, 0.2f, 0.1f, 0.15f, "Brow_Raise_Inner_R", 0.381f, true);

				NewExpression("focus");
				AddEmoteFlags(false, true, false, 1f);
				AddShapeComponent(new []{"^Cheek_Raise_L.*$"}, 0.2f, 0.1f, 0.15f, "Cheek_Raise_L", 0.5f, true);
				AddShapeComponent(new []{"^Cheek_Raise_R.*$"}, 0.2f, 0.05f, 0.1f, "Cheek_Raise_R", 0.5f, true);
				AddShapeComponent(new []{"^Eye_Squint_L.*$"}, 0.2f, 0.1f, 0.15f, "Eye_Squint_L", 0.35f, true);
				AddShapeComponent(new []{"^Eye_Squint_R.*$"}, 0.2f, 0.1f, 0.15f, "Eye_Squint_R", 0.35f, true);

				NewExpression("flare");
				AddEmoteFlags(false, true, false, 1f);
				AddShapeComponent(new []{"^Nose_Flanks_Raise.*$"}, 0.2f, 0.1f, 0.15f, "Nose_Flanks_Raise", 0.45f, true);

				NewExpression("scrunch");
				AddEmoteFlags(false, true, false, 1f);
				AddShapeComponent(new []{"^Nose_Scrunch.*$"}, 0.2f, 0.1f, 0.15f, "Nose_Scrunch", 0.65f, true);
			}
			#endregion // EmoteR-configuration

			DoOneClickiness(gameObject, clip);

			if (selectedObject.GetComponent<SalsaAdvancedDynamicsSilenceAnalyzer>() == null)
				selectedObject.AddComponent<SalsaAdvancedDynamicsSilenceAnalyzer>();

			// Darrin's Tweaks
			salsa.useTimingsOverride = true;
			salsa.globalDurON = 0.125f;
			salsa.globalDurOffBalance = -0.180f;
			salsa.globalNuanceBalance = -0.213f;

			emoter.NumRandomEmphasizersPerCycle = 4;
			emoter.FindEmote("exasper").frac = 0.628f;
			emoter.FindEmote("soften").frac = 0.705f;
			emoter.FindEmote("browsUp").frac = 0.469f;
			emoter.FindEmote("browUp").frac = 0.817f;
			emoter.FindEmote("squint").frac = 0.782f;
			emoter.FindEmote("focus").frac = 1f;
			emoter.FindEmote("flare").frac = 1f;
			emoter.FindEmote("scrunch").frac = 0.853f;

			var silenceAnalyzer = selectedObject.GetComponent<SalsaAdvancedDynamicsSilenceAnalyzer>();
			silenceAnalyzer.silenceThreshold = 0.9f;
			silenceAnalyzer.timingStartPoint = 0.4f;
			silenceAnalyzer.timingEndVariance = 0.7f;
			silenceAnalyzer.silenceSampleWeight = 0.98f;
			silenceAnalyzer.bufferSize = 512;
		}
	}
}

