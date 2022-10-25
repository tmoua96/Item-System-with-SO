using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "CharacterHealthData")]
	public sealed class CharacterHealthDataGameEventListener : BaseGameEventListener<CharacterHealthData, CharacterHealthDataGameEvent, CharacterHealthDataUnityEvent>
	{
	}
}