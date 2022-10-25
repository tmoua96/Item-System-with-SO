using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[CreateAssetMenu(
	    fileName = "EquipmentSOCollection.asset",
	    menuName = SOArchitecture_Utility.COLLECTION_SUBMENU + "Custom/Equipment",
	    order = 120)]
	public class EquipmentSOCollection : Collection<EquipmentSO>
	{
	}
}