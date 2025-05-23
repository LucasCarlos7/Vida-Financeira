using VF.Core.Enums;

namespace VF.Core.Entities;

public class ExpenseTransaction : Transaction
{
    public FormPaymentEnum FormPayment { get; set; }
    public PaymentConditionEnum PaymentCondition { get; set; }
    public CreditCard? CreditCard { get; set; }
    public Account? Account { get; set; }
    public int? Installments { get; set; }
    public bool? IsPaid { get; set; } // Indica se o gasto foi já debitou da conta/cartão.

    // public Invoice? Invoice { get; set; }
}
