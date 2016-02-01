//Economy CloudScript Example

handlers.GrantItemToUser = function(args)
{
	//args.itemId, args.catalogVersion
	var params = {};
	params.PlayFabId = currentPlayerId;
	
	if(typeof(args.catalogVersion) == undefined && args.catalogVersion != null)
	{
		params.CatalogVersion = args.catalogVersion;
	}

	// take in either a string and convert to array, or an array
	params.ItemIds = typeof(args.itemId) == String ? [args.itemId] : args.itemId;
	
	return server.GrantItemsToUser(params);
}


handlers.GrantItemToCharacter = function(args)
{
	//args.characterId, args.itemId, args.catalogVersion
	var params = {};
	params.PlayFabId = currentPlayerId;
	params.CharacterId = args.characterId

	if(typeof(args.catalogVersion) == undefined && args.catalogVersion != null)
	{
		params.CatalogVersion = args.catalogVersion;
	}
	
	// take in either a string and convert to array, or an array
	params.ItemIds = typeof(args.itemId) == String ? [args.itemId] : args.itemId;
	
	return server.GrantItemsToCharacter(params);
}


handlers.UpdateCharacterVcBalance = function(args)
{
	//args.characterId, args.vc, args.amount
	
	var params = {};
	params.CharacterId = args.characterId;
	params.PlayFabId = currentPlayerId;
	params.VirtualCurrency = args.vc;

	if(args.amount >= 0)
	{
		params.Amount = args.amount;
		return server.AddCharacterVirtualCurrency(params);
	}
	else
	{
		params.Amount = args.amount * -1;
		return server.SubtractCharacterVirtualCurrency(params);
	}
}


handlers.UpdateUserVcBalance = function(args)
{
	// args.vc, args.amount
	
	var params = {};
	params.PlayFabId = currentPlayerId;
	params.VirtualCurrency = args.vc;

	if(args.amount >= 0)
	{
		params.Amount = args.amount;
		return server.AddUserVirtualCurrency(params);
	}
	else
	{
		params.Amount = args.amount * -1;
		return server.SubtractUserVirtualCurrency(params);
	}
}


