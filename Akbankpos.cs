namespace Akbankpos {
    public enum MODE {
        Test,
        Prod
    }
    public class Akbankpos {
        public string Mode { get; set; }
        public string Endpoint { get; set; }
        public string MerchantId { get; set; }
        public string TerminalId { get; set; }
        public string SecretKey { get; set; }
        public void SetMerchantId(string merchantid) {
            MerchantId = merchantid;
        }
        public void SetTerminalId(string terminalid) {
            TerminalId = terminalid;
        }
        public void SetSecretKey(string secretkey) {
            SecretKey = secretkey;
        }
        public Akbankpos(MODE mode) {
            Endpoint = mode switch {
                MODE.Test => "https://apipre.akbank.com",
                MODE.Prod => "https://api.akbank.com",
                _ => null
            };
        }
    }
}