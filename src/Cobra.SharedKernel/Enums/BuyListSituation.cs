using System.ComponentModel;

namespace Cobra.SharedKernel.Enums
{
    public enum BuyListSituation : byte
    {
        [Description("Aguardando")]
        Awaiting = 0,
        [Description("Analisando")]
        Analyzing = 1,
        [Description("Solicitando Inspeção")]
        RequestingInspection = 2,
        [Description("Aguardando Inspeção")]
        AwaitingInspection = 3,
        [Description("Aguardando Término da Inspeção")]
        WaitingForInspectionToFinish = 4,
        [Description("Aceito Totalmente")]
        TotalyAccepted = 5,
        [Description("Aceito Parcialmente")]
        PartialAccepted = 6,
        [Description("Negado")]
        Denied = 7,
        [Description("Contra a Proposta de Venda")]
        AgainstSaleProposal = 8,
        [Description("Contra a Proposta de Compra")]
        AgainstPurchaseProposal = 9,
        [Description("Cancelado Pelo Comprador")]
        CancelledByBuyer = 10,
        [Description("Cancelado Pelo Vendedor")]
        CancelledBySeller = 11,
        [Description("Na Fila de Pagamentos")]
        InThePaymentQueue = 12,
        [Description("Pagamento Realizado")]
        PaymentMade = 13,
        [Description("Aguardando Retirada")]
        AwaitingWithdrawal = 14,
        [Description("Retirada Realizada")]
        WithdrawalPerformed = 15,
        [Description("Finalizado")]
        Finalizado = 16
    }
}