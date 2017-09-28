
using System.ServiceModel;
using System.IO;

namespace Exchange.Contracts.PayLeap.Services
{
    [ServiceContract(ConfigurationName = "PayLeap.Services.ITransactServices")]
    public interface ITransactServices
    {

        [OperationContract(Action = "http://tempuri.org/ITransactServices/CreateTransactionSession", ReplyAction = "http://tempuri.org/ITransactServices/CreateTransactionSessionResponse")]
        Response CreateTransactionSession(string username, string password);

        [OperationContract(Action = "http://tempuri.org/ITransactServices/CreateTransactionSession1", ReplyAction = "http://tempuri.org/ITransactServices/CreateTransactionSession1Response")]
        Response CreateTransactionSession1();

        [OperationContract(Action = "http://tempuri.org/ITransactServices/CreateTransactionSession2", ReplyAction = "http://tempuri.org/ITransactServices/CreateTransactionSession2Response")]
        Response CreateTransactionSession2(Stream input);

        [OperationContract(Action = "http://tempuri.org/ITransactServices/ValidCard", ReplyAction = "http://tempuri.org/ITransactServices/ValidCardResponse")]
        int ValidCard(string CardNumber, string ExpDate);

        [OperationContract(Action = "http://tempuri.org/ITransactServices/ValidCard2", ReplyAction = "http://tempuri.org/ITransactServices/ValidCard2Response")]
        int ValidCard2(Stream input);

        [OperationContract(Action = "http://tempuri.org/ITransactServices/ValidCardLength", ReplyAction = "http://tempuri.org/ITransactServices/ValidCardLengthResponse")]
        bool ValidCardLength(string CardNumber);

        [OperationContract(Action = "http://tempuri.org/ITransactServices/ValidCardLength2", ReplyAction = "http://tempuri.org/ITransactServices/ValidCardLength2Response")]
        bool ValidCardLength2(Stream input);

        [OperationContract(Action = "http://tempuri.org/ITransactServices/ValidExpDate", ReplyAction = "http://tempuri.org/ITransactServices/ValidExpDateResponse")]
        bool ValidExpDate(string ExpDate);

        [OperationContract(Action = "http://tempuri.org/ITransactServices/ValidExpDate2", ReplyAction = "http://tempuri.org/ITransactServices/ValidExpDate2Response")]
        bool ValidExpDate2(Stream input);

        [OperationContract(Action = "http://tempuri.org/ITransactServices/ValidMod10", ReplyAction = "http://tempuri.org/ITransactServices/ValidMod10Response")]
        bool ValidMod10(string CardNumber);

        [OperationContract(Action = "http://tempuri.org/ITransactServices/ValidMod102", ReplyAction = "http://tempuri.org/ITransactServices/ValidMod102Response")]
        bool ValidMod102(Stream input);

        [OperationContract(Action = "http://tempuri.org/ITransactServices/ProcessCreditCard", ReplyAction = "http://tempuri.org/ITransactServices/ProcessCreditCardResponse")]
        Response ProcessCreditCard(string UserName, string Password, string TransType, string CardNum, string ExpDate, string MagData, string NameOnCard, string Amount, string InvNum, string PNRef, string Zip, string Street, string CVNum, string ExtData);

        [OperationContract(Action = "http://tempuri.org/ITransactServices/ProcessCreditCard1", ReplyAction = "http://tempuri.org/ITransactServices/ProcessCreditCard1Response")]
        Response ProcessCreditCard1();

        [OperationContract(Action = "http://tempuri.org/ITransactServices/ProcessCreditCard2", ReplyAction = "http://tempuri.org/ITransactServices/ProcessCreditCard2Response")]
        Response ProcessCreditCard2(Stream input);

        [OperationContract(Action = "http://tempuri.org/ITransactServices/ProcessCheck", ReplyAction = "http://tempuri.org/ITransactServices/ProcessCheckResponse")]
        Response ProcessCheck(string UserName, string Password, string TransType, string CheckNum, string TransitNum, string AccountNum, string Amount, string MICR, string NameOnCheck, string DL, string SS, string DOB, string StateCode, string CheckType, string ExtData);

        [OperationContract(Action = "http://tempuri.org/ITransactServices/ProcessCheck2", ReplyAction = "http://tempuri.org/ITransactServices/ProcessCheck2Response")]
        Response ProcessCheck2(Stream input);

        [OperationContract(Action = "http://tempuri.org/ITransactServices/ProcessGiftCard", ReplyAction = "http://tempuri.org/ITransactServices/ProcessGiftCardResponse")]
        Response ProcessGiftCard(string UserName, string Password, string TransType, string CardNum, string ExpDate, string MagData, string Amount, string InvNum, string PNRef, string ExtData);

        [OperationContract(Action = "http://tempuri.org/ITransactServices/ProcessGiftCard2", ReplyAction = "http://tempuri.org/ITransactServices/ProcessGiftCard2Response")]
        Response ProcessGiftCard2(Stream input);

        [OperationContract(Action = "http://tempuri.org/ITransactServices/ProcessEBTCard", ReplyAction = "http://tempuri.org/ITransactServices/ProcessEBTCardResponse")]
        Response ProcessEBTCard(string UserName, string Password, string TransType, string CardNum, string ExpDate, string MagData, string NameOnCard, string Amount, string InvNum, string PNRef, string Pin, string RegisterNum, string SureChargeAmt, string CashBackAmt, string ExtData);

        [OperationContract(Action = "http://tempuri.org/ITransactServices/ProcessEBTCard2", ReplyAction = "http://tempuri.org/ITransactServices/ProcessEBTCard2Response")]
        Response ProcessEBTCard2(Stream input);

        [OperationContract(Action = "http://tempuri.org/ITransactServices/ProcessDebitCard", ReplyAction = "http://tempuri.org/ITransactServices/ProcessDebitCardResponse")]
        Response ProcessDebitCard(string UserName, string Password, string TransType, string CardNum, string ExpDate, string MagData, string NameOnCard, string Amount, string InvNum, string PNRef, string Pin, string RegisterNum, string SureChargeAmt, string CashBackAmt, string ExtData);

        [OperationContract(Action = "http://tempuri.org/ITransactServices/ProcessDebitCard2", ReplyAction = "http://tempuri.org/ITransactServices/ProcessDebitCard2Response")]
        Response ProcessDebitCard2(Stream input);

        [OperationContract(Action = "http://tempuri.org/ITransactServices/ProcessDebitOrCreditCard", ReplyAction = "http://tempuri.org/ITransactServices/ProcessDebitOrCreditCardResponse")]
        Response ProcessDebitOrCreditCard(string username, string password, string transtype, string cardnum, string expdate, string nameoncard, string magdata, string cvnum, string amount, string pnref, string extdata);

        [OperationContract(Action = "http://tempuri.org/ITransactServices/ProcessDebitOrCreditCard1", ReplyAction = "http://tempuri.org/ITransactServices/ProcessDebitOrCreditCard1Response")]
        Response ProcessDebitOrCreditCard1();

        [OperationContract(Action = "http://tempuri.org/ITransactServices/ProcessDebitOrCreditCard2", ReplyAction = "http://tempuri.org/ITransactServices/ProcessDebitOrCreditCard2Response")]
        Response ProcessDebitOrCreditCard2(Stream input);

        [OperationContract(Action = "http://tempuri.org/ITransactServices/GetPinDebitStatus", ReplyAction = "http://tempuri.org/ITransactServices/GetPinDebitStatusResponse")]
        Response GetPinDebitStatus(string username, string password, string pnref);

        [OperationContract(Action = "http://tempuri.org/ITransactServices/GetPinDebitStatus2", ReplyAction = "http://tempuri.org/ITransactServices/GetPinDebitStatus2Response")]
        Response GetPinDebitStatus2(Stream input);

        [OperationContract(Action = "http://tempuri.org/ITransactServices/CheckBinForPinDebit", ReplyAction = "http://tempuri.org/ITransactServices/CheckBinForPinDebitResponse")]
        Response CheckBinForPinDebit(string userName, string password, string cardNum);

        [OperationContract(Action = "http://tempuri.org/ITransactServices/CheckBinForPinDebit1", ReplyAction = "http://tempuri.org/ITransactServices/CheckBinForPinDebit1Response")]
        Response CheckBinForPinDebit1();

        [OperationContract(Action = "http://tempuri.org/ITransactServices/CheckBinForPinDebit2", ReplyAction = "http://tempuri.org/ITransactServices/CheckBinForPinDebit2Response")]
        Response CheckBinForPinDebit2(Stream input);

        [OperationContract(Action = "http://tempuri.org/ITransactServices/InitiatePinDebit", ReplyAction = "http://tempuri.org/ITransactServices/InitiatePinDebitResponse")]
        Response InitiatePinDebit(string userName, string password, string cardNum, string amount, string languageCode);

        [OperationContract(Action = "http://tempuri.org/ITransactServices/InitiatePinDebit1", ReplyAction = "http://tempuri.org/ITransactServices/InitiatePinDebit1Response")]
        Response InitiatePinDebit1();

        [OperationContract(Action = "http://tempuri.org/ITransactServices/InitiatePinDebit2", ReplyAction = "http://tempuri.org/ITransactServices/InitiatePinDebit2Response")]
        Response InitiatePinDebit2(Stream input);

        [OperationContract(Action = "http://tempuri.org/ITransactServices/ProcessPinDebit", ReplyAction = "http://tempuri.org/ITransactServices/ProcessPinDebitResponse")]
        Response ProcessPinDebit(string username, string password, string transtype, string cardnum, string expdate, string nameoncard, string amount, string pnref, string pinreferenceid, string extdata);

        [OperationContract(Action = "http://tempuri.org/ITransactServices/ProcessPinDebit1", ReplyAction = "http://tempuri.org/ITransactServices/ProcessPinDebit1Response")]
        Response ProcessPinDebit1();

        [OperationContract(Action = "http://tempuri.org/ITransactServices/ProcessPinDebit2", ReplyAction = "http://tempuri.org/ITransactServices/ProcessPinDebit2Response")]
        Response ProcessPinDebit2(Stream input);

        [OperationContract(Action = "http://tempuri.org/ITransactServices/ProcessCreditCardWithToken", ReplyAction = "http://tempuri.org/ITransactServices/ProcessCreditCardWithTokenResponse")]
        Response ProcessCreditCardWithToken(string transactionKey, string transactionToken, string amount, string extdata);

        [OperationContract(Action = "http://tempuri.org/ITransactServices/ProcessCreditCardWithToken1", ReplyAction = "http://tempuri.org/ITransactServices/ProcessCreditCardWithToken1Response")]
        Response ProcessCreditCardWithToken1();

        [OperationContract(Action = "http://tempuri.org/ITransactServices/ProcessCreditCardWithToken2", ReplyAction = "http://tempuri.org/ITransactServices/ProcessCreditCardWithToken2Response")]
        Response ProcessCreditCardWithToken2(Stream input);
    }
}
