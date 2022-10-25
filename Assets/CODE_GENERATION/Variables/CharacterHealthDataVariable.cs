using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public class CharacterHealthDataEvent : UnityEvent<CharacterHealthData> { }

	[CreateAssetMenu(
	    fileName = "CharacterHealthDataVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "Custom/CharacterHealthData",
	    order = 120)]
	public class CharacterHealthDataVariable : BaseVariable<CharacterHealthData, CharacterHealthDataEvent>
	{
	}
}