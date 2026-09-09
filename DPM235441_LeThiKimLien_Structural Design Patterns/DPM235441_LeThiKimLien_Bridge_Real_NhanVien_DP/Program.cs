// Real-world Bridge pattern: Employee payment system with flexible payment methods
using DPM235441_LeThiKimLien_Bridge_Real_NhanVien_DP;

Console.WriteLine("=== Employee Payment Processing System ===\n");

// Create payment methods
IPaymentMethod bankTransfer = new BankTransferPayment();
IPaymentMethod cash = new CashPayment();

// Create employees with different payment methods
Employee fullTimeWithBank = new FullTimeEmployee("Lê Thị Kim Liên", 25000, bankTransfer);
Employee partTimeWithCash = new PartTimeEmployee("Nguyễn Văn A", 150, cash);

// Process payments
Console.WriteLine(fullTimeWithBank.PayEmployee());
Console.WriteLine();
Console.WriteLine(partTimeWithCash.PayEmployee());
