#if !DISABLE_PLAYFABENTITY_API
using PlayFab.AddonModels;

namespace PlayFab.Events
{
    public partial class PlayFabEvents
    {
        public event PlayFabRequestEvent<CreateOrUpdateAppleRequest> OnAddonCreateOrUpdateAppleRequestEvent;
        public event PlayFabResultEvent<CreateOrUpdateAppleResponse> OnAddonCreateOrUpdateAppleResultEvent;
        public event PlayFabRequestEvent<CreateOrUpdateFacebookRequest> OnAddonCreateOrUpdateFacebookRequestEvent;
        public event PlayFabResultEvent<CreateOrUpdateFacebookResponse> OnAddonCreateOrUpdateFacebookResultEvent;
        public event PlayFabRequestEvent<CreateOrUpdateFacebookInstantGamesRequest> OnAddonCreateOrUpdateFacebookInstantGamesRequestEvent;
        public event PlayFabResultEvent<CreateOrUpdateFacebookInstantGamesResponse> OnAddonCreateOrUpdateFacebookInstantGamesResultEvent;
        public event PlayFabRequestEvent<CreateOrUpdateGoogleRequest> OnAddonCreateOrUpdateGoogleRequestEvent;
        public event PlayFabResultEvent<CreateOrUpdateGoogleResponse> OnAddonCreateOrUpdateGoogleResultEvent;
        public event PlayFabRequestEvent<CreateOrUpdateKongregateRequest> OnAddonCreateOrUpdateKongregateRequestEvent;
        public event PlayFabResultEvent<CreateOrUpdateKongregateResponse> OnAddonCreateOrUpdateKongregateResultEvent;
        public event PlayFabRequestEvent<CreateOrUpdateNintendoRequest> OnAddonCreateOrUpdateNintendoRequestEvent;
        public event PlayFabResultEvent<CreateOrUpdateNintendoResponse> OnAddonCreateOrUpdateNintendoResultEvent;
        public event PlayFabRequestEvent<CreateOrUpdatePSNRequest> OnAddonCreateOrUpdatePSNRequestEvent;
        public event PlayFabResultEvent<CreateOrUpdatePSNResponse> OnAddonCreateOrUpdatePSNResultEvent;
        public event PlayFabRequestEvent<CreateOrUpdateSteamRequest> OnAddonCreateOrUpdateSteamRequestEvent;
        public event PlayFabResultEvent<CreateOrUpdateSteamResponse> OnAddonCreateOrUpdateSteamResultEvent;
        public event PlayFabRequestEvent<CreateOrUpdateToxModRequest> OnAddonCreateOrUpdateToxModRequestEvent;
        public event PlayFabResultEvent<CreateOrUpdateToxModResponse> OnAddonCreateOrUpdateToxModResultEvent;
        public event PlayFabRequestEvent<CreateOrUpdateTwitchRequest> OnAddonCreateOrUpdateTwitchRequestEvent;
        public event PlayFabResultEvent<CreateOrUpdateTwitchResponse> OnAddonCreateOrUpdateTwitchResultEvent;
        public event PlayFabRequestEvent<DeleteAppleRequest> OnAddonDeleteAppleRequestEvent;
        public event PlayFabResultEvent<DeleteAppleResponse> OnAddonDeleteAppleResultEvent;
        public event PlayFabRequestEvent<DeleteFacebookRequest> OnAddonDeleteFacebookRequestEvent;
        public event PlayFabResultEvent<DeleteFacebookResponse> OnAddonDeleteFacebookResultEvent;
        public event PlayFabRequestEvent<DeleteFacebookInstantGamesRequest> OnAddonDeleteFacebookInstantGamesRequestEvent;
        public event PlayFabResultEvent<DeleteFacebookInstantGamesResponse> OnAddonDeleteFacebookInstantGamesResultEvent;
        public event PlayFabRequestEvent<DeleteGoogleRequest> OnAddonDeleteGoogleRequestEvent;
        public event PlayFabResultEvent<DeleteGoogleResponse> OnAddonDeleteGoogleResultEvent;
        public event PlayFabRequestEvent<DeleteKongregateRequest> OnAddonDeleteKongregateRequestEvent;
        public event PlayFabResultEvent<DeleteKongregateResponse> OnAddonDeleteKongregateResultEvent;
        public event PlayFabRequestEvent<DeleteNintendoRequest> OnAddonDeleteNintendoRequestEvent;
        public event PlayFabResultEvent<DeleteNintendoResponse> OnAddonDeleteNintendoResultEvent;
        public event PlayFabRequestEvent<DeletePSNRequest> OnAddonDeletePSNRequestEvent;
        public event PlayFabResultEvent<DeletePSNResponse> OnAddonDeletePSNResultEvent;
        public event PlayFabRequestEvent<DeleteSteamRequest> OnAddonDeleteSteamRequestEvent;
        public event PlayFabResultEvent<DeleteSteamResponse> OnAddonDeleteSteamResultEvent;
        public event PlayFabRequestEvent<DeleteToxModRequest> OnAddonDeleteToxModRequestEvent;
        public event PlayFabResultEvent<DeleteToxModResponse> OnAddonDeleteToxModResultEvent;
        public event PlayFabRequestEvent<DeleteTwitchRequest> OnAddonDeleteTwitchRequestEvent;
        public event PlayFabResultEvent<DeleteTwitchResponse> OnAddonDeleteTwitchResultEvent;
        public event PlayFabRequestEvent<GetAppleRequest> OnAddonGetAppleRequestEvent;
        public event PlayFabResultEvent<GetAppleResponse> OnAddonGetAppleResultEvent;
        public event PlayFabRequestEvent<GetFacebookRequest> OnAddonGetFacebookRequestEvent;
        public event PlayFabResultEvent<GetFacebookResponse> OnAddonGetFacebookResultEvent;
        public event PlayFabRequestEvent<GetFacebookInstantGamesRequest> OnAddonGetFacebookInstantGamesRequestEvent;
        public event PlayFabResultEvent<GetFacebookInstantGamesResponse> OnAddonGetFacebookInstantGamesResultEvent;
        public event PlayFabRequestEvent<GetGoogleRequest> OnAddonGetGoogleRequestEvent;
        public event PlayFabResultEvent<GetGoogleResponse> OnAddonGetGoogleResultEvent;
        public event PlayFabRequestEvent<GetKongregateRequest> OnAddonGetKongregateRequestEvent;
        public event PlayFabResultEvent<GetKongregateResponse> OnAddonGetKongregateResultEvent;
        public event PlayFabRequestEvent<GetNintendoRequest> OnAddonGetNintendoRequestEvent;
        public event PlayFabResultEvent<GetNintendoResponse> OnAddonGetNintendoResultEvent;
        public event PlayFabRequestEvent<GetPSNRequest> OnAddonGetPSNRequestEvent;
        public event PlayFabResultEvent<GetPSNResponse> OnAddonGetPSNResultEvent;
        public event PlayFabRequestEvent<GetSteamRequest> OnAddonGetSteamRequestEvent;
        public event PlayFabResultEvent<GetSteamResponse> OnAddonGetSteamResultEvent;
        public event PlayFabRequestEvent<GetToxModRequest> OnAddonGetToxModRequestEvent;
        public event PlayFabResultEvent<GetToxModResponse> OnAddonGetToxModResultEvent;
        public event PlayFabRequestEvent<GetTwitchRequest> OnAddonGetTwitchRequestEvent;
        public event PlayFabResultEvent<GetTwitchResponse> OnAddonGetTwitchResultEvent;
    }
}
#endif
