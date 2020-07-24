using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HealthCare.Mobile.ServiceLayer.Authentications
{
    public class FirebaseAuthentication
    {
        //private HttpClient _httpClient = new HttpClient();
        private class FireBaseEmailAuthRequest
        {
            public string email;
            public string password;
            public bool returnSecureToken;
        }

        private class FireBaseEmailAuthResponse
        {
            public string idToken;
            public string email;
            public string refreshToken;
            public string expiresIn;
            public string localId;
            public bool registered;
        }

        public class FireBaseStringConstants
        {
            public const string ErrorKey = "error";
            public const string ErrorMessageKey = "message";
        }

        public async Task<string> HandleFirebaseAuthentication(bool IsLoginMode, string email, string emailpassword)
        {
            string fireBaseEmailAuthURL = string.Empty;
            string responseStr = string.Empty;
            string authStatus = string.Empty;
            HttpClient _httpClient = new HttpClient();

            if (IsLoginMode)
                fireBaseEmailAuthURL = "https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=AIzaSyDesy12EjKKzZZOgBBmm7MA4R8s_elsIrw";
            else
                fireBaseEmailAuthURL = "https://identitytoolkit.googleapis.com/v1/accounts:signUp?key=AIzaSyDesy12EjKKzZZOgBBmm7MA4R8s_elsIrw";

            try
            {
                FireBaseEmailAuthRequest firebaseAuthRequestObj = new FireBaseEmailAuthRequest();
                firebaseAuthRequestObj.email = email;
                firebaseAuthRequestObj.password = emailpassword;
                firebaseAuthRequestObj.returnSecureToken = true;
                HttpResponseMessage httpResMsg = await _httpClient.PostAsync(fireBaseEmailAuthURL, new StringContent(JsonConvert.SerializeObject(firebaseAuthRequestObj)));
                responseStr = await httpResMsg.Content.ReadAsStringAsync();
                FireBaseEmailAuthResponse resObj = JsonConvert.DeserializeObject<FireBaseEmailAuthResponse>(responseStr);


                //------Error Handling---------------
                JObject jsonResObj = JObject.Parse(responseStr);
                if (jsonResObj.ContainsKey(FireBaseStringConstants.ErrorKey))    //Error msg returned from Firebase Service.
                {
                    string ErrCode = jsonResObj[FireBaseStringConstants.ErrorKey][FireBaseStringConstants.ErrorMessageKey].ToString();
                    authStatus = GetErrorMessageFromErrorCode(ErrCode);
                }
                //-----------------------------------

            }
            catch (Exception ex)
            {
                authStatus = ex.Message;
            }

            return authStatus;
        }

        public string GetErrorMessageFromErrorCode(string ErrCode)
        {
            string errMsg = string.Empty;
            switch (ErrCode)
            {
                case "EMAIL_EXISTS":
                    errMsg = "The email address is already registered with us.";
                    break;
                case "OPERATION_NOT_ALLOWED":
                    errMsg = "Password sign-in is disabled for this app.";
                    break;

                case "TOO_MANY_ATTEMPTS_TRY_LATER":
                    errMsg = "We have blocked all requests from this device due to unusual activity. Try again later.";
                    break;

                case "EMAIL_NOT_FOUND":
                    errMsg = "This Email is not registered with us";
                    break;

                case "INVALID_PASSWORD":
                    errMsg = "Email ID or Password is incorrect";
                    break;

                case "USER_DISABLED":
                    errMsg = "The user account has been disabled by an administrator.";
                    break;

                case "ERR_CONNECTION_RESET":
                    errMsg = "Could not connect to server. Please check internet connection or try again later";
                    break;

                default:
                    errMsg = "Error in Authenticating User";
                    break;
            }

            return errMsg;
        }
    }
}
