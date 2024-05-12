# Akbankpos.NET
Akbank POS API with .NET

# Installation
```bash
dotnet add package Akbankpos --version 1.0.0
```

# Satış
```c#
namespace Akbankpos {
    internal class Program {
        static void Main(string[] args) {
            var akbankpos = new Akbankpos(MODE.Test); // Çalışma ortamı
            akbankpos.SetMerchantId("2023090417500272654BD9A49CF07574"); // Mağaza numarası
            akbankpos.SetTerminalId("2023090417500284633D137A249DBBEB"); // Terminal numarası
            akbankpos.SetSecretKey("3230323330393034313735303032363031353172675f357637355f3273387373745f7233725f73323333383737335f323272383774767276327672323531355f"); // Mağaza anahtarı
            var request = new Akbankpos.Request { Card = new(), Transaction = new() };
            request.Card.SetCardNumber("5218076007402834"); // Kart numarası
            request.Card.SetCardExpiry("11", "40"); // Son kullanma tarihi - AA,YY
            request.Card.SetCardCode("820"); // Kart arkasındaki 3 haneli numara
            request.Transaction.SetAmount("1.00", "TRY"); // Satış tutarı ve para birimi
            request.Transaction.SetInstallment("1"); // Taksit sayısı
            var response = akbankpos.Auth(request);
            if (response != null) {
                Console.WriteLine(Akbankpos.Json(response));
            }
        }
    }
}
```