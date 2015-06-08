
static NSString* ToNSString(const char* c_string)
{
    return c_string == NULL ? nil : [NSString stringWithUTF8String:c_string];
}

static const char* EventHandler = "_PlayFabGO";

static const char* MakeNSStringCopy(const NSString* string)
{
    if (string == nil)
        return NULL;
    const char* str = string.UTF8String;
    char* res = (char*)malloc(strlen(str) + 1);
    strcpy(res, str);
    return res;
}

static const char* MakeStringCopy(const char* string)
{
    if (string == NULL)
        return NULL;
    
    char* res = (char*)malloc(strlen(string) + 1);
    strcpy(res, string);
    return res;
}

static const char* MakeDataCopy(NSData *data)
{
    if (data == NULL || data.length == 0)
        return NULL;
    
    char* res = (char*)malloc(data.length + 1);
    memcpy(res, data.bytes, data.length);
    res[data.length] = '\0';
    return res;
}

extern "C"
{

    void pf_make_http_request(const char* url, const char* method, int numHeaders, const char* headers[], const char* headerValues[], const char* postBody, int requestId)
    {
        NSString* urlStr = ToNSString(url);
        NSString* methodStr = ToNSString(method);
        NSString* bodyStr = ToNSString(postBody);
        
        NSURL *aUrl = [NSURL URLWithString:urlStr];
        NSMutableURLRequest *request = [NSMutableURLRequest requestWithURL:aUrl
                                                               cachePolicy:NSURLRequestUseProtocolCachePolicy
                                                           timeoutInterval:60.0];
        [request setHTTPMethod:methodStr];
        
        for(int i=0;i<numHeaders;i++)
        {
            [request setValue:ToNSString(headerValues[i]) forHTTPHeaderField:ToNSString(headers[i]) ];
        }
        
        NSString *postString = bodyStr;
        [request setHTTPBody:[postString dataUsingEncoding:NSUTF8StringEncoding]];
        
        
        [NSURLConnection sendAsynchronousRequest:request queue:[NSOperationQueue mainQueue] completionHandler:
            ^(NSURLResponse *response, NSData *data, NSError *connectionError)
            {
                
                if(connectionError)
                {
                    const char* errDesc = connectionError.description.UTF8String;
                    int maxLen = strlen(errDesc) + 32;
                    char* replyBuffer = (char*)malloc(maxLen+1);
                    snprintf(replyBuffer, maxLen, "%i:%s", requestId, errDesc);
                    replyBuffer[maxLen] = '\0';
                    UnitySendMessage(EventHandler, "OnHttpError", replyBuffer);
                    return;
                }
                
                int maxLen = data.length + 32;
                char* replyBuffer = (char*)malloc(maxLen+1);
                int written = snprintf(replyBuffer, maxLen, "%i:", requestId);
                memcpy(replyBuffer+written, data.bytes, data.length);
                replyBuffer[written+data.length] = '\0';
                UnitySendMessage(EventHandler, "OnHttpResponse", replyBuffer);
            }
        ];

    }
}