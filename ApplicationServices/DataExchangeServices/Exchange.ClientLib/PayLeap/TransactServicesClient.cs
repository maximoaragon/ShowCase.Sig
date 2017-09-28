using Exchange.Contracts.PayLeap;
using Exchange.Contracts.PayLeap.Services;
using System.IO;
using System.ServiceModel;

namespace Exchange.ClientLib.PayLeap
{
    public partial class TransactServicesClient : ClientBase<ITransactServices>, ITransactServices
    {

        public TransactServicesClient()
        {
        }

        public TransactServicesClient(string endpointConfigurationName) :
                base(endpointConfigurationName)
        {
        }

        public TransactServicesClient(string endpointConfigurationName, string remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public TransactServicesClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public TransactServicesClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
                base(binding, remoteAddress)
        {
        }

        public Response CreateTransactionSession(string username, string password)
        {
            return base.Channel.CreateTransactionSession(username, password);
        }

        public Response CreateTransactionSession1()
        {
            return base.Channel.CreateTransactionSession1();
        }

        public Response CreateTransactionSession2(Stream input)
        {
            return base.Channel.CreateTransactionSession2(input);
        }

        public int ValidCard(string CardNumber, string ExpDate)
        {
            return base.Channel.ValidCard(CardNumber, ExpDate);
        }

        public int ValidCard2(Stream input)
        {
            return base.Channel.ValidCard2(input);
        }

        public bool ValidCardLength(string CardNumber)
        {
            return base.Channel.ValidCardLength(CardNumber);
        }

        public bool ValidCardLength2(Stream input)
        {
            return base.Channel.ValidCardLength2(input);
        }

        public bool ValidExpDate(string ExpDate)
        {
            return base.Channel.ValidExpDate(ExpDate);
        }

        public bool ValidExpDate2(Stream input)
        {
            return base.Channel.ValidExpDate2(input);
        }

        public bool ValidMod10(string CardNumber)
        {
            return base.Channel.ValidMod10(CardNumber);
        }

        public bool ValidMod102(Stream input)
        {
            return base.Channel.ValidMod102(input);
        }

        public Response ProcessCreditCard(string UserName, string Password, string TransType, string CardNum, string ExpDate, string MagData, string NameOnCard, string Amount, string InvNum, string PNRef, string Zip, string Street, string CVNum, string ExtData)
        {
            return base.Channel.ProcessCreditCard(UserName, Password, TransType, CardNum, ExpDate, MagData, NameOnCard, Amount, InvNum, PNRef, Zip, Street, CVNum, ExtData);
        }

        public Response ProcessCreditCard1()
        {
            return base.Channel.ProcessCreditCard1();
        }

        public Response ProcessCreditCard2(Stream input)
        {
            return base.Channel.ProcessCreditCard2(input);
        }

        public Response ProcessCheck(string UserName, string Password, string TransType, string CheckNum, string TransitNum, string AccountNum, string Amount, string MICR, string NameOnCheck, string DL, string SS, string DOB, string StateCode, string CheckType, string ExtData)
        {
            return base.Channel.ProcessCheck(UserName, Password, TransType, CheckNum, TransitNum, AccountNum, Amount, MICR, NameOnCheck, DL, SS, DOB, StateCode, CheckType, ExtData);
        }

        public Response ProcessCheck2(Stream input)
        {
            return base.Channel.ProcessCheck2(input);
        }

        public Response ProcessGiftCard(string UserName, string Password, string TransType, string CardNum, string ExpDate, string MagData, string Amount, string InvNum, string PNRef, string ExtData)
        {
            return base.Channel.ProcessGiftCard(UserName, Password, TransType, CardNum, ExpDate, MagData, Amount, InvNum, PNRef, ExtData);
        }

        public Response ProcessGiftCard2(Stream input)
        {
            return base.Channel.ProcessGiftCard2(input);
        }

        public Response ProcessEBTCard(string UserName, string Password, string TransType, string CardNum, string ExpDate, string MagData, string NameOnCard, string Amount, string InvNum, string PNRef, string Pin, string RegisterNum, string SureChargeAmt, string CashBackAmt, string ExtData)
        {
            return base.Channel.ProcessEBTCard(UserName, Password, TransType, CardNum, ExpDate, MagData, NameOnCard, Amount, InvNum, PNRef, Pin, RegisterNum, SureChargeAmt, CashBackAmt, ExtData);
        }

        public Response ProcessEBTCard2(Stream input)
        {
            return base.Channel.ProcessEBTCard2(input);
        }

        public Response ProcessDebitCard(string UserName, string Password, string TransType, string CardNum, string ExpDate, string MagData, string NameOnCard, string Amount, string InvNum, string PNRef, string Pin, string RegisterNum, string SureChargeAmt, string CashBackAmt, string ExtData)
        {
            return base.Channel.ProcessDebitCard(UserName, Password, TransType, CardNum, ExpDate, MagData, NameOnCard, Amount, InvNum, PNRef, Pin, RegisterNum, SureChargeAmt, CashBackAmt, ExtData);
        }

        public Response ProcessDebitCard2(Stream input)
        {
            return base.Channel.ProcessDebitCard2(input);
        }

        public Response ProcessDebitOrCreditCard(string username, string password, string transtype, string cardnum, string expdate, string nameoncard, string magdata, string cvnum, string amount, string pnref, string extdata)
        {
            return base.Channel.ProcessDebitOrCreditCard(username, password, transtype, cardnum, expdate, nameoncard, magdata, cvnum, amount, pnref, extdata);
        }

        public Response ProcessDebitOrCreditCard1()
        {
            return base.Channel.ProcessDebitOrCreditCard1();
        }

        public Response ProcessDebitOrCreditCard2(Stream input)
        {
            return base.Channel.ProcessDebitOrCreditCard2(input);
        }

        public Response GetPinDebitStatus(string username, string password, string pnref)
        {
            return base.Channel.GetPinDebitStatus(username, password, pnref);
        }

        public Response GetPinDebitStatus2(Stream input)
        {
            return base.Channel.GetPinDebitStatus2(input);
        }

        public Response CheckBinForPinDebit(string userName, string password, string cardNum)
        {
            return base.Channel.CheckBinForPinDebit(userName, password, cardNum);
        }

        public Response CheckBinForPinDebit1()
        {
            return base.Channel.CheckBinForPinDebit1();
        }

        public Response CheckBinForPinDebit2(Stream input)
        {
            return base.Channel.CheckBinForPinDebit2(input);
        }

        public Response InitiatePinDebit(string userName, string password, string cardNum, string amount, string languageCode)
        {
            return base.Channel.InitiatePinDebit(userName, password, cardNum, amount, languageCode);
        }

        public Response InitiatePinDebit1()
        {
            return base.Channel.InitiatePinDebit1();
        }

        public Response InitiatePinDebit2(Stream input)
        {
            return base.Channel.InitiatePinDebit2(input);
        }

        public Response ProcessPinDebit(string username, string password, string transtype, string cardnum, string expdate, string nameoncard, string amount, string pnref, string pinreferenceid, string extdata)
        {
            return base.Channel.ProcessPinDebit(username, password, transtype, cardnum, expdate, nameoncard, amount, pnref, pinreferenceid, extdata);
        }

        public Response ProcessPinDebit1()
        {
            return base.Channel.ProcessPinDebit1();
        }

        public Response ProcessPinDebit2(Stream input)
        {
            return base.Channel.ProcessPinDebit2(input);
        }

        public Response ProcessCreditCardWithToken(string transactionKey, string transactionToken, string amount, string extdata)
        {
            return base.Channel.ProcessCreditCardWithToken(transactionKey, transactionToken, amount, extdata);
        }

        public Response ProcessCreditCardWithToken1()
        {
            return base.Channel.ProcessCreditCardWithToken1();
        }

        public Response ProcessCreditCardWithToken2(Stream input)
        {
            return base.Channel.ProcessCreditCardWithToken2(input);
        }
    }
}
