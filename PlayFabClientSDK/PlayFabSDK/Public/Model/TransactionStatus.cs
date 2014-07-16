
namespace PlayFab.Model
{
	
	public enum TransactionStatus
	{
		CreateCart,
		Init,
		Approved,
		Succeeded,
		FailedByProvider,
		RefundPending,
		Refunded,
		RefundFailed,
		ChargedBack,
		FailedByUber,
		Revoked,
		TradePending,
		Upgraded,
		Other,
		Failed
	}
}