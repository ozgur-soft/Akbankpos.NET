using System.Globalization;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
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
            public decimal? LinkValidTerm { get; set; }
            [JsonPropertyName("merchantId")]
            public decimal? MerchantId { get; set; }
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
            public List<Installment> InstallmentList { get; set; }
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
            [JsonPropertyName("cvv2")]
            [FormElementName("cvv")]
            public string CardCode { get; set; }
            [JsonPropertyName("expireDate")]
            [FormElementName("expiredDate")]
            public string CardExpiry { get; set; }
            public void SetCardNumber(string cardnumber) {
                CardNumber = cardnumber;
            }
            public void SetCardExpiry(string cardmonth, string cardyear) {
                CardExpiry = cardmonth + cardyear;
            }
            public void SetCardCode(string cardcode) {
                CardCode = cardcode;
            }
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
            public void SetOrderId(string orderid) {
                OrderId = orderid;
            }
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
            [FormElementName("b2bIdentityNumber")]
            public string IdentityNumber { get; set; }
        }
        public class SGK {
            [JsonPropertyName("surchargeAmount")]
            public decimal? SurchargeAmount { get; set; }
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
        public class Installment {
            [JsonPropertyName("installmentCount")]
            public decimal? InstallmentCount { get; set; }
            [JsonPropertyName("installmentType")]
            public string InstallmentType { get; set; }
            [JsonPropertyName("cardType")]
            public string CardType { get; set; }
        }
        public class Interest {
            [JsonPropertyName("interestRate")]
            public decimal? InterestRate { get; set; }
            [JsonPropertyName("interestAmount")]
            public decimal? InterestAmount { get; set; }
        }
        public class LinkDetail {
            [JsonPropertyName("linkTransferType")]
            public string LinkTransferType { get; set; }
            [JsonPropertyName("mobilePhoneNumber")]
            public string MobilePhoneNumber { get; set; }
            [JsonPropertyName("email")]
            public string Email { get; set; }
            [JsonPropertyName("linkValidTerm")]
            public decimal? LinkValidTerm { get; set; }
            [JsonPropertyName("amount")]
            public decimal? Amount { get; set; }
            [JsonPropertyName("currency")]
            public int? Currency { get; set; }
            [JsonPropertyName("installmentCount")]
            public decimal? InstallmentCount { get; set; }
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
            public decimal? InstallmentType { get; set; }
        }
        public class Reward {
            [JsonPropertyName("ccbRewardAmount")]
            [FormElementName("ccbRewardAmount")]
            public decimal? CcbRewardAmount { get; set; }
            [JsonPropertyName("pcbRewardAmount")]
            [FormElementName("pcbRewardAmount")]
            public decimal? PcbRewardAmount { get; set; }
            [JsonPropertyName("xcbRewardAmount")]
            [FormElementName("xcbRewardAmount")]
            public decimal? XcbRewardAmount { get; set; }
            [JsonPropertyName("ccbEarnedRewardAmount")]
            public decimal? CcbEarnedRewardAmount { get; set; }
            [JsonPropertyName("ccbBalanceRewardAmount")]
            public decimal? CcbBalanceRewardAmount { get; set; }
            [JsonPropertyName("ccbRewardDesc")]
            public string CcbRewardDesc { get; set; }
            [JsonPropertyName("pcbEarnedRewardAmount")]
            public decimal? PcbEarnedRewardAmount { get; set; }
            [JsonPropertyName("pcbBalanceRewardAmount")]
            public decimal? PcbBalanceRewardAmount { get; set; }
            [JsonPropertyName("pcbRewardDesc")]
            public string PcbRewardDesc { get; set; }
            [JsonPropertyName("xcbEarnedRewardAmount")]
            public decimal? XcbEarnedRewardAmount { get; set; }
            [JsonPropertyName("xcbBalanceRewardAmount")]
            public decimal? XcbBalanceRewardAmount { get; set; }
            [JsonPropertyName("xcbRewardDesc")]
            public string XcbRewardDesc { get; set; }
        }
        public class Transaction {
            [JsonPropertyName("amount")]
            [FormElementName("amount")]
            public decimal? Amount { get; set; }
            [JsonPropertyName("currencyCode")]
            [FormElementName("currencyCode")]
            public int? Currency { get; set; }
            [JsonPropertyName("motoInd")]
            public int? MotoInd { get; set; }
            [JsonPropertyName("installCount")]
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
            public void SetAmount(string amount, string currency) {
                Amount = decimal.Parse(amount, CultureInfo.InvariantCulture);
                Currency = currency switch {
                    "TRY" => 949,
                    "YTL" => 949,
                    "TRL" => 949,
                    "TL" => 949,
                    "USD" => 840,
                    "EUR" => 978,
                    "GBP" => 826,
                    "JPY" => 392,
                    _ => int.TryParse(currency, out var code) ? code : null
                };
            }
            public void SetInstallment(string installment) {
                Installment = int.TryParse(installment, out var count) ? count : 1;
            }
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
            public decimal? Amount { get; set; }

            [JsonPropertyName("currencyCode")]
            public int? Currency { get; set; }

            [JsonPropertyName("motoInd")]
            public int? MotoInd { get; set; }

            [JsonPropertyName("installCount")]
            public int? Installment { get; set; }

            [JsonPropertyName("ccbRewardAmount")]
            public decimal? CcbRewardAmount { get; set; }

            [JsonPropertyName("pcbRewardAmount")]
            public decimal? PcbRewardAmount { get; set; }

            [JsonPropertyName("xcbRewardAmount")]
            public decimal? XcbRewardAmount { get; set; }

            [JsonPropertyName("preAuthStatus")]
            public string PreAuthStatus { get; set; }

            [JsonPropertyName("preAuthCloseAmount")]
            public decimal? PreAuthCloseAmount { get; set; }

            [JsonPropertyName("preAuthPartialCancelAmount")]
            public decimal? PreAuthPartialCancelAmount { get; set; }

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
        public string Random(int n) {
            var chars = "0123456789ABCDEF";
            var random = new StringBuilder();
            for (var i = 0; i < n; i++) {
                var index = new Random().Next(0, chars.Length - 1);
                random.Append(chars[index]);
            }
            return random.ToString();
        }
        public static string Hash(string payload, string secret) {
            using var hmac = new HMACSHA512(Encoding.UTF8.GetBytes(secret));
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(payload));
            return Convert.ToBase64String(hash);
        }
        public static string Hash3d(Dictionary<string, string> form, string[] parameters, string secret) {
            var items = new List<string>();
            foreach (var parameter in parameters) {
                items.Add(form[parameter]);
            }
            var plain = string.Join("", items);
            return Hash(plain, secret);
        }
        public Dictionary<string, string> Form3d(Request data) {
            var form = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
            var elements = data.GetType().GetProperties().Where(x => x.GetCustomAttribute<FormElementNameAttribute>() != null);
            foreach (var element in elements) {
                var key = element.GetCustomAttribute<FormElementNameAttribute>().Key;
                var value = element.GetValue(data)?.ToString();
                if (!string.IsNullOrEmpty(value)) {
                    form.Add(key, value);
                }
            }
            if (data.Terminal != null) {
                var billto_elements = data.Terminal.GetType().GetProperties().Where(x => x.GetCustomAttribute<FormElementNameAttribute>() != null);
                foreach (var element in billto_elements) {
                    var key = element.GetCustomAttribute<FormElementNameAttribute>().Key;
                    var value = element.GetValue(data.Terminal)?.ToString();
                    if (!string.IsNullOrEmpty(value)) {
                        form.Add(key, value);
                    }
                }
            }
            if (data.Card != null) {
                var card_elements = data.Card.GetType().GetProperties().Where(x => x.GetCustomAttribute<FormElementNameAttribute>() != null);
                foreach (var element in card_elements) {
                    var key = element.GetCustomAttribute<FormElementNameAttribute>().Key;
                    var value = element.GetValue(data.Card)?.ToString();
                    if (!string.IsNullOrEmpty(value)) {
                        form.Add(key, value);
                    }
                }
            }
            if (data.Customer != null) {
                var customer_elements = data.Customer.GetType().GetProperties().Where(x => x.GetCustomAttribute<FormElementNameAttribute>() != null);
                foreach (var element in customer_elements) {
                    var key = element.GetCustomAttribute<FormElementNameAttribute>().Key;
                    var value = element.GetValue(data.Customer)?.ToString();
                    if (!string.IsNullOrEmpty(value)) {
                        form.Add(key, value);
                    }
                }
            }
            if (data.Order != null) {
                var order_elements = data.Order.GetType().GetProperties().Where(x => x.GetCustomAttribute<FormElementNameAttribute>() != null);
                foreach (var element in order_elements) {
                    var key = element.GetCustomAttribute<FormElementNameAttribute>().Key;
                    var value = element.GetValue(data.Order)?.ToString();
                    if (!string.IsNullOrEmpty(value)) {
                        form.Add(key, value);
                    }
                }
            }
            if (data.Transaction != null) {
                var transaction_elements = data.Transaction.GetType().GetProperties().Where(x => x.GetCustomAttribute<FormElementNameAttribute>() != null);
                foreach (var element in transaction_elements) {
                    var key = element.GetCustomAttribute<FormElementNameAttribute>().Key;
                    var value = element.GetValue(data.Transaction)?.ToString();
                    if (!string.IsNullOrEmpty(value)) {
                        form.Add(key, value);
                    }
                }
            }
            if (data.Reward != null) {
                var reward_elements = data.Reward.GetType().GetProperties().Where(x => x.GetCustomAttribute<FormElementNameAttribute>() != null);
                foreach (var element in reward_elements) {
                    var key = element.GetCustomAttribute<FormElementNameAttribute>().Key;
                    var value = element.GetValue(data.Reward)?.ToString();
                    if (!string.IsNullOrEmpty(value)) {
                        form.Add(key, value);
                    }
                }
            }
            if (data.SubMerchant != null) {
                var submerchant_elements = data.SubMerchant.GetType().GetProperties().Where(x => x.GetCustomAttribute<FormElementNameAttribute>() != null);
                foreach (var element in submerchant_elements) {
                    var key = element.GetCustomAttribute<FormElementNameAttribute>().Key;
                    var value = element.GetValue(data.SubMerchant)?.ToString();
                    if (!string.IsNullOrEmpty(value)) {
                        form.Add(key, value);
                    }
                }
            }
            return form;
        }
        public Response PreAuth(Request data) {
            data.Version = "1.00";
            data.Terminal ??= new() { MerchantSafeId = MerchantId, TerminalSafeId = TerminalId };
            data.RequestDateTime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fff");
            data.RandomNumber = Random(128);
            data.TxnCode = "1004";
            data.Transaction.MotoInd = 0;
            return _Transaction(data);
        }
        public Response Auth(Request data) {
            data.Version = "1.00";
            data.Terminal ??= new() { MerchantSafeId = MerchantId, TerminalSafeId = TerminalId };
            data.RequestDateTime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fff");
            data.RandomNumber = Random(128);
            data.TxnCode = "1000";
            data.Transaction.MotoInd = 0;
            return _Transaction(data);
        }
        public Response PreAuth3d(Request data) {
            data.Version = "1.00";
            data.Terminal ??= new() { MerchantSafeId = MerchantId, TerminalSafeId = TerminalId };
            data.RequestDateTime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fff");
            data.RandomNumber = Random(128);
            data.TxnCode = "3004";
            data.PaymentModel = "3D";
            data.Order ??= new() { OrderId = Guid.NewGuid().ToString() };
            var parameters = new string[] { "paymentModel", "txnCode", "merchantSafeId", "terminalSafeId", "orderId", "lang", "amount", "ccbRewardAmount", "pcbRewardAmount", "xcbRewardAmount", "currencyCode", "installCount", "okUrl", "failUrl", "emailAddress", "subMerchantId", "creditCard", "expiredDate", "cvv", "randomNumber", "requestDateTime", "b2bIdentityNumber" };
            var form = Form3d(data);
            data.Hash = Hash3d(form, parameters, SecretKey);
            return _Transaction(data);
        }
        public Response Auth3d(Request data) {
            data.Version = "1.00";
            data.Terminal ??= new() { MerchantSafeId = MerchantId, TerminalSafeId = TerminalId };
            data.RequestDateTime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fff");
            data.RandomNumber = Random(128);
            data.TxnCode = "3000";
            data.PaymentModel = "3D";
            data.Order ??= new() { OrderId = Guid.NewGuid().ToString() };
            var parameters = new string[] { "paymentModel", "txnCode", "merchantSafeId", "terminalSafeId", "orderId", "lang", "amount", "ccbRewardAmount", "pcbRewardAmount", "xcbRewardAmount", "currencyCode", "installCount", "okUrl", "failUrl", "emailAddress", "subMerchantId", "creditCard", "expiredDate", "cvv", "randomNumber", "requestDateTime", "b2bIdentityNumber" };
            var form = Form3d(data);
            data.Hash = Hash3d(form, parameters, SecretKey);
            return _Transaction(data);
        }
        public Response PostAuth(Request data) {
            data.Version = "1.00";
            data.Terminal ??= new() { MerchantSafeId = MerchantId, TerminalSafeId = TerminalId };
            data.RequestDateTime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fff");
            data.RandomNumber = Random(128);
            data.TxnCode = "1005";
            return _Transaction(data);
        }
        public Response Refund(Request data) {
            data.Version = "1.00";
            data.Terminal ??= new() { MerchantSafeId = MerchantId, TerminalSafeId = TerminalId };
            data.RequestDateTime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fff");
            data.RandomNumber = Random(128);
            data.TxnCode = "1002";
            return _Transaction(data);
        }
        public Response Cancel(Request data) {
            data.Version = "1.00";
            data.Terminal ??= new() { MerchantSafeId = MerchantId, TerminalSafeId = TerminalId };
            data.RequestDateTime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fff");
            data.RandomNumber = Random(128);
            data.TxnCode = "1003";
            return _Transaction(data);
        }
        public Response _Transaction(Request data) {
            var payload = JsonSerializer.Serialize(data, new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping });
            using var http = new HttpClient();
            using var request = new HttpRequestMessage(HttpMethod.Post, Endpoint + "/api/v1/payment/virtualpos/transaction/process") { Content = new StringContent(payload, null, MediaTypeNames.Application.Json), Headers = { { "auth-hash", Hash(payload, SecretKey) } } };
            using var response = http.Send(request);
            if (response.IsSuccessStatusCode) {
                using var stream = response.Content.ReadAsStream();
                var result = JsonSerializer.Deserialize<Response>(stream);
                return result;
            } else {
                using var stream = response.Content.ReadAsStream();
                var result = JsonSerializer.Deserialize<Error>(stream);
                return new() { Error = result };
            }
        }
        public static string Json<T>(T data) where T : class {
            return JsonSerializer.Serialize(data, new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, WriteIndented = true, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping });
        }
    }
}