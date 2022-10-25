using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	[CreateAssetMenu(
	    fileName = "EquipmentEventDataGameEvent.asset",
	    menuName = SOArchitecture_Utility.GAME_EVENT + "Custom/Equipment",
	    order = 120)]
	public sealed class EquipmentEventDataGameEvent : GameEventBase<EquipmentEventData>
	{
	}
}