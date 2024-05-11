using System.Text.Json.Serialization;

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
        public class Request {
            [JsonPropertyName("version")]
            public string Version { get; set; }
            [JsonPropertyName("hashItems")]
            public string HashItems { get; set; }
            [JsonPropertyName("lang")]
            [FormElementName("lang")]
            public string Lang { get; set; }
            [JsonPropertyName("okUrl")]
            [FormElementName("okUrl")]
            public string OkUrl { get; set; }
            [JsonPropertyName("failUrl")]
            [FormElementName("failUrl")]
            public string FailUrl { get; set; }
            [JsonPropertyName("txnCode")]
            [FormElementName("txnCode")]
            public string TxnCode { get; set; }
            [JsonPropertyName("paymentModel")]
            [FormElementName("paymentModel")]
            public string PaymentModel { get; set; }
            [JsonPropertyName("requestDateTime")]
            [FormElementName("requestDateTime")]
            public string RequestDateTime { get; set; }
            [JsonPropertyName("randomNumber")]
            [FormElementName("randomNumber")]
            public string RandomNumber { get; set; }
            [JsonPropertyName("institutionCode")]
            public string InstitutionCode { get; set; }
            [JsonPropertyName("terminal")]
            public Terminal Terminal { get; set; }
            [JsonPropertyName("card")]
            public Card Card { get; set; }
            [JsonPropertyName("insurancePan")]
            public InsurancePan InsurancePan { get; set; }
            [JsonPropertyName("order")]
            public Order Order { get; set; }
            [JsonPropertyName("reward")]
            public Reward Reward { get; set; }
            [JsonPropertyName("transaction")]
            public Transaction Transaction { get; set; }
            [JsonPropertyName("customer")]
            public Customer Customer { get; set; }
            [JsonPropertyName("recurring")]
            public Recurring Recurring { get; set; }
            [JsonPropertyName("plannedDate")]
            public PlannedDate PlannedDate { get; set; }
            [JsonPropertyName("payByLink")]
            public PayByLink PayByLink { get; set; }
            [JsonPropertyName("secureTransaction")]
            public SecureTransaction SecureTransaction { get; set; }
            [JsonPropertyName("subMerchant")]
            public SubMerchant SubMerchant { get; set; }
            [JsonPropertyName("b2b")]
            public B2B B2B { get; set; }
            [JsonPropertyName("sgk")]
            public SGK SGK { get; set; }
            [JsonPropertyName("hash")]
            [FormElementName("hash")]
            public string Hash { get; set; }
        }
        public class Response {
            [JsonPropertyName("txnCode")]
            public string TxnCode { get; set; }
            [JsonPropertyName("responseCode")]
            public string ResponseCode { get; set; }
            [JsonPropertyName("hash")]
            public string Hash { get; set; }
            [JsonPropertyName("responseMessage")]
            public string ResponseMessage { get; set; }
            [JsonPropertyName("hostResponseCode")]
            public string HostResponseCode { get; set; }
            [JsonPropertyName("hostMessage")]
            public string HostMessage { get; set; }
            [JsonPropertyName("txnDateTime")]
            public string TxnDateTime { get; set; }
            [JsonPropertyName("terminal")]
            public Terminal Terminal { get; set; }
            [JsonPropertyName("card")]
            public Card Card { get; set; }
            [JsonPropertyName("order")]
            public Order Order { get; set; }
            [JsonPropertyName("transaction")]
            public Transaction Transaction { get; set; }
            [JsonPropertyName("campaign")]
            public Campaign Campaign { get; set; }
            [JsonPropertyName("reward")]
            public Reward Reward { get; set; }
            [JsonPropertyName("recurring")]
            public Recurring Recurring { get; set; }
            [JsonPropertyName("plannedDate")]
            public PlannedDate PlannedDate { get; set; }
            [JsonPropertyName("interest")]
            public Interest Interest { get; set; }
            [JsonPropertyName("subMerchant")]
            public SubMerchant SubMerchant { get; set; }
            [JsonPropertyName("b2b")]
            public B2B B2B { get; set; }
            [JsonPropertyName("linkValidTerm")]
            public float? LinkValidTerm { get; set; }
            [JsonPropertyName("merchantId")]
            public float? MerchantId { get; set; }
            [JsonPropertyName("linkExpireDate")]
            public string LinkExpireDate { get; set; }
            [JsonPropertyName("merchantOrderId")]
            public string MerchantOrderId { get; set; }
            [JsonPropertyName("referenceId")]
            public string ReferenceId { get; set; }
            [JsonPropertyName("token")]
            public string Token { get; set; }
            [JsonPropertyName("header")]
            public Header Header { get; set; }
            [JsonPropertyName("linkDetail")]
            public LinkDetail LinkDetail { get; set; }
            [JsonPropertyName("installmentConditionList")]
            public List<InstallmentCond> InstallmentConditionList { get; set; }
            [JsonPropertyName("txnDetailList")]
            public List<TxnDetail> TxnDetailList { get; set; }
            [JsonPropertyName("error")]
            public Error Error { get; set; }
        }
        public class Terminal {
            [JsonPropertyName("merchantSafeId")]
            [FormElementName("merchantSafeId")]
            public string MerchantSafeId { get; set; }
            [JsonPropertyName("terminalSafeId")]
            [FormElementName("terminalSafeId")]
            public string TerminalSafeId { get; set; }
        }
        public class Card {
            [JsonPropertyName("cardHolderName")]
            public string CardHolderName { get; set; }
            [JsonPropertyName("cardNumber")]
            [FormElementName("creditCard")]
            public string CardNumber { get; set; }
            [JsonPropertyName("cardCode")]
            [FormElementName("cvv")]
            public string CardCode { get; set; }
            [JsonPropertyName("cardExpiry")]
            [FormElementName("expiredDate")]
            public string CardExpiry { get; set; }
        }
        public class Customer {
            [JsonPropertyName("emailAddress")]
            [FormElementName("emailAddress")]
            public string EmailAddress { get; set; }
            [JsonPropertyName("ipAddress")]
            public string IpAddress { get; set; }
        }
        public class InsurancePan {
            [JsonPropertyName("binNumber")]
            public string BinNumber { get; set; }
            [JsonPropertyName("cardLastFourParam")]
            public string CardLastFourParam { get; set; }
            [JsonPropertyName("identityNumber")]
            public string IdentityNumber { get; set; }
        }
        public class Order {
            [JsonPropertyName("orderId")]
            [FormElementName("orderId")]
            public string OrderId { get; set; }
            [JsonPropertyName("orderTrackId")]
            public string OrderTrackId { get; set; }
        }
        public class PayByLink {
            [JsonPropertyName("linkTxnCode")]
            public string LinkTxnCode { get; set; }
            [JsonPropertyName("linkTransferType")]
            public string LinkTransferType { get; set; }
            [JsonPropertyName("mobilePhoneNumber")]
            public string MobilePhoneNumber { get; set; }
            [JsonPropertyName("email")]
            public string Email { get; set; }
        }
        public class PlannedDate {
            [JsonPropertyName("firstPlannedDate")]
            public string FirstPlannedDate { get; set; }
        }
        public class Recurring {
            [JsonPropertyName("numberOfPayments")]
            public int? NumberOfPayments { get; set; }
            [JsonPropertyName("frequencyInterval")]
            public int? FrequencyInterval { get; set; }
            [JsonPropertyName("frequencyCycle")]
            public string FrequencyCycle { get; set; }
            [JsonPropertyName("recurringOrder")]
            public int? RecurringOrder { get; set; }
        }
        public class SecureTransaction {
            [JsonPropertyName("secureId")]
            public string SecureId { get; set; }
            [JsonPropertyName("secureEcomInd")]
            public string SecureEcomInd { get; set; }
            [JsonPropertyName("secureData")]
            public string SecureData { get; set; }
            [JsonPropertyName("secureMd")]
            public string SecureMd { get; set; }
        }
        public class B2B {
            [JsonPropertyName("identityNumber")]
            public string IdentityNumber { get; set; }
        }
        public class SGK {
            [JsonPropertyName("surchargeAmount")]
            public float? SurchargeAmount { get; set; }
        }
        public class SubMerchant {
            [JsonPropertyName("subMerchantId")]
            [FormElementName("subMerchantId")]
            public string SubMerchantId { get; set; }
        }
        public class Campaign {
            [JsonPropertyName("additionalInstallment")]
            public int? AdditionalInstallment { get; set; }
            [JsonPropertyName("deferingDate")]
            public string DeferingDate { get; set; }
            [JsonPropertyName("deferingMonth")]
            public int? DeferingMonth { get; set; }
        }
        public class Header {
            [JsonPropertyName("returnCode")]
            public string ReturnCode { get; set; }
            [JsonPropertyName("returnMessage")]
            public string ReturnMessage { get; set; }
        }
        public class InstallmentCond {
            [JsonPropertyName("installmentCount")]
            public float? InstallmentCount { get; set; }
            [JsonPropertyName("installmentType")]
            public string InstallmentType { get; set; }
            [JsonPropertyName("cardType")]
            public string CardType { get; set; }
        }
        public class Interest {
            [JsonPropertyName("interestRate")]
            public float? InterestRate { get; set; }
            [JsonPropertyName("interestAmount")]
            public float? InterestAmount { get; set; }
        }
        public class LinkDetail {
            [JsonPropertyName("linkTransferType")]
            public string LinkTransferType { get; set; }
            [JsonPropertyName("mobilePhoneNumber")]
            public string MobilePhoneNumber { get; set; }
            [JsonPropertyName("email")]
            public string Email { get; set; }
            [JsonPropertyName("linkValidTerm")]
            public float? LinkValidTerm { get; set; }
            [JsonPropertyName("amount")]
            public float? Amount { get; set; }
            [JsonPropertyName("currency")]
            public int? Currency { get; set; }
            [JsonPropertyName("installmentCount")]
            public float? InstallmentCount { get; set; }
            [JsonPropertyName("referenceId")]
            public string ReferenceId { get; set; }
            [JsonPropertyName("errorCode")]
            public string ErrorCode { get; set; }
            [JsonPropertyName("errorMessage")]
            public string ErrorMessage { get; set; }
            [JsonPropertyName("linkExpireDate")]
            public string LinkExpireDate { get; set; }
            [JsonPropertyName("linkStatus")]
            public string LinkStatus { get; set; }
            [JsonPropertyName("installmentType")]
            public float? InstallmentType { get; set; }
        }
        public class Reward {
            [JsonPropertyName("ccbRewardAmount")]
            [FormElementName("ccbRewardAmount")]
            public float? CcbRewardAmount { get; set; }
            [JsonPropertyName("pcbRewardAmount")]
            [FormElementName("pcbRewardAmount")]
            public float? PcbRewardAmount { get; set; }
            [JsonPropertyName("xcbRewardAmount")]
            [FormElementName("xcbRewardAmount")]
            public float? XcbRewardAmount { get; set; }
            [JsonPropertyName("ccbEarnedRewardAmount")]
            public float? CcbEarnedRewardAmount { get; set; }
            [JsonPropertyName("ccbBalanceRewardAmount")]
            public float? CcbBalanceRewardAmount { get; set; }
            [JsonPropertyName("ccbRewardDesc")]
            public string CcbRewardDesc { get; set; }
            [JsonPropertyName("pcbEarnedRewardAmount")]
            public float? PcbEarnedRewardAmount { get; set; }
            [JsonPropertyName("pcbBalanceRewardAmount")]
            public float? PcbBalanceRewardAmount { get; set; }
            [JsonPropertyName("pcbRewardDesc")]
            public string PcbRewardDesc { get; set; }
            [JsonPropertyName("xcbEarnedRewardAmount")]
            public float? XcbEarnedRewardAmount { get; set; }
            [JsonPropertyName("xcbBalanceRewardAmount")]
            public float? XcbBalanceRewardAmount { get; set; }
            [JsonPropertyName("xcbRewardDesc")]
            public string XcbRewardDesc { get; set; }
        }
        public class Transaction {
            [JsonPropertyName("amount")]
            [FormElementName("amount")]
            public float? Amount { get; set; }
            [JsonPropertyName("currency")]
            [FormElementName("currencyCode")]
            public int? Currency { get; set; }
            [JsonPropertyName("motoInd")]
            public int? MotoInd { get; set; }
            [JsonPropertyName("installment")]
            [FormElementName("installCount")]
            public int? Installment { get; set; }
            [JsonPropertyName("authCode")]
            public string AuthCode { get; set; }
            [JsonPropertyName("rrn")]
            public string Rrn { get; set; }
            [JsonPropertyName("batchNumber")]
            public int? BatchNumber { get; set; }
            [JsonPropertyName("stan")]
            public int? Stan { get; set; }
        }
        public class TxnDetail {
            [JsonPropertyName("txnCode")]
            public string TxnCode { get; set; }

            [JsonPropertyName("responseCode")]
            public string ResponseCode { get; set; }

            [JsonPropertyName("responseMessage")]
            public string ResponseMessage { get; set; }

            [JsonPropertyName("hostResponseCode")]
            public string HostResponseCode { get; set; }

            [JsonPropertyName("hostMessage")]
            public string HostMessage { get; set; }

            [JsonPropertyName("txnDateTime")]
            public string TxnDateTime { get; set; }

            [JsonPropertyName("plannedDateTime")]
            public string PlannedDateTime { get; set; }

            [JsonPropertyName("terminalSafeId")]
            public string TerminalSafeId { get; set; }

            [JsonPropertyName("merchantSafeId")]
            public string MerchantSafeId { get; set; }

            [JsonPropertyName("orderId")]
            public string OrderId { get; set; }

            [JsonPropertyName("orderTrackId")]
            public string OrderTrackId { get; set; }

            [JsonPropertyName("authCode")]
            public string AuthCode { get; set; }

            [JsonPropertyName("rrn")]
            public string Rrn { get; set; }

            [JsonPropertyName("batchNumber")]
            public int? BatchNumber { get; set; }

            [JsonPropertyName("stan")]
            public int? Stan { get; set; }

            [JsonPropertyName("settlementId")]
            public string SettlementId { get; set; }

            [JsonPropertyName("txnStatus")]
            public string TxnStatus { get; set; }

            [JsonPropertyName("amount")]
            public float? Amount { get; set; }

            [JsonPropertyName("currencyCode")]
            public int? Currency { get; set; }

            [JsonPropertyName("motoInd")]
            public int? MotoInd { get; set; }

            [JsonPropertyName("installCount")]
            public int? Installment { get; set; }

            [JsonPropertyName("ccbRewardAmount")]
            public float? CcbRewardAmount { get; set; }

            [JsonPropertyName("pcbRewardAmount")]
            public float? PcbRewardAmount { get; set; }

            [JsonPropertyName("xcbRewardAmount")]
            public float? XcbRewardAmount { get; set; }

            [JsonPropertyName("preAuthStatus")]
            public string PreAuthStatus { get; set; }

            [JsonPropertyName("preAuthCloseAmount")]
            public float? PreAuthCloseAmount { get; set; }

            [JsonPropertyName("preAuthPartialCancelAmount")]
            public float? PreAuthPartialCancelAmount { get; set; }

            [JsonPropertyName("preAuthCloseDate")]
            public string PreAuthCloseDate { get; set; }

            [JsonPropertyName("maskedCardNumber")]
            public string MaskedCardNumber { get; set; }

            [JsonPropertyName("recurringOrder")]
            public int? RecurringOrder { get; set; }

            [JsonPropertyName("requestType")]
            public string RequestType { get; set; }

            [JsonPropertyName("requestStatus")]
            public string RequestStatus { get; set; }

            [JsonPropertyName("cancelDate")]
            public string CancelDate { get; set; }

            [JsonPropertyName("tryCount")]
            public int? TryCount { get; set; }

            [JsonPropertyName("xid")]
            public string Xid { get; set; }

            [JsonPropertyName("paymentModel")]
            public string PaymentModel { get; set; }

            [JsonPropertyName("eci")]
            public string Eci { get; set; }

            [JsonPropertyName("secureData")]
            public string SecureData { get; set; }

            [JsonPropertyName("orgOrderId")]
            public string OrgOrderId { get; set; }
        }
        public class Error {
            [JsonPropertyName("code")]
            public string Code { get; set; }
            [JsonPropertyName("message")]
            public string Message { get; set; }
            [JsonPropertyName("errors")]
            public List<Errors> Errors { get; set; }
        }
        public class Errors {
            [JsonPropertyName("code")]
            public string Code { get; set; }
            [JsonPropertyName("message")]
            public string Message { get; set; }
        }
        public class FormElementNameAttribute : Attribute {
            public string Key { get; }
            public FormElementNameAttribute(string key) {
                Key = key;
            }
        }
    }
}