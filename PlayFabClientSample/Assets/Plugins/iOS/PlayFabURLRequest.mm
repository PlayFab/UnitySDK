// #define DISABLE_IDFA // If you need to disable IDFA for your game, uncomment this

#import <AdSupport/ASIdentifierManager.h>

static const char* MakeStringCopy(const char* string)
{
    if (string == NULL)
        return NULL;
    
    char* res = (char*)malloc(strlen(string) + 1);
    strcpy(res, string);
    return res;
}

extern "C"
{
#ifndef DISABLE_IDFA
    const char* getIdfa()
    {
        if([[ASIdentifierManager sharedManager] isAdvertisingTrackingEnabled])
        {
             NSString* idfa = [[[ASIdentifierManager sharedManager] advertisingIdentifier] UUIDString];
             return MakeStringCopy([idfa UTF8String]); // You have to copy the array before you can return it to Unity/C#
        }
        return nil;
    }

    bool getAdvertisingDisabled()
    {
        return ![[ASIdentifierManager sharedManager] isAdvertisingTrackingEnabled];
    }
#endif // DISABLE_IDFA

}
