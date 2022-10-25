using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	[CreateAssetMenu(
	    fileName = "StatusEffectEventDataGameEvent.asset",
	    menuName = SOArchitecture_Utility.GAME_EVENT + "Custom/Status Effect",
	    order = 120)]
	public sealed class StatusEffectEventDataGameEvent : GameEventBase<StatusEffectEventData>
	{
	}
}