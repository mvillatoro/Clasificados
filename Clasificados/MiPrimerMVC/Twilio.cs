using Twilio;

namespace MiPrimerMVC
{
    class Twilio
    {
        public void MensajeTwilio(string mensaje)
        {
            string AccountSid = "AC8ab7cb90cd64afe27c1188f8e8100011";
            string AuthToken = "0abcbaa1a03106130d7438539773ec72";
            var twilio = new TwilioRestClient(AccountSid, AuthToken);
            var message = twilio.SendMessage("+12017625616", "+50498701833", mensaje);
        }
    }
}