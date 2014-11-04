using System;
namespace PlayFab.Serialization.JsonFx
{
	/** Explicitly declare this member to be serialized.
	 * \see JsonOptInAttribute
	 */
	public class JsonMemberAttribute : Attribute
	{
		public JsonMemberAttribute ()
		{
		}
	}
}

