using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Exchange.Contracts.PayLeap
{
    [DataContract(Name = "Response", Namespace = "http://www.payleap.com/payments")]
    [Serializable()]
    public class Response :  IExtensibleDataObject, INotifyPropertyChanged
    {

        [System.NonSerialized()]
        private ExtensionDataObject extensionDataField;

        [OptionalField()]
        private string AuthCodeField;

        [OptionalField()]
        private string ExponentField;

        [OptionalField()]
        private string ExtDataField;

        [OptionalField()]
        private string GUIDField;

        [OptionalField()]
        private string GetAVSResultField;

        [OptionalField()]
        private string GetAVSResultTXTField;

        [OptionalField()]
        private string GetCVResultField;

        [OptionalField()]
        private string GetCVResultTXTField;

        [OptionalField()]
        private string GetCommercialCardField;

        [OptionalField()]
        private string GetGetOrigResultField;

        [OptionalField()]
        private string GetStreetMatchTXTField;

        [OptionalField()]
        private string GetZipMatchTXTField;

        [OptionalField()]
        private string HistoryField;

        [OptionalField()]
        private string HostCodeField;

        [OptionalField()]
        private string HostURLField;

        [OptionalField()]
        private string InNetworkField;

        [OptionalField()]
        private string InnerErrorCodeField;

        [OptionalField()]
        private string InnerErrorMessageField;

        [OptionalField()]
        private string InvNumField;

        [OptionalField()]
        private string KeyPointerField;

        [OptionalField()]
        private string MessageField;

        [OptionalField()]
        private string Message1Field;

        [OptionalField()]
        private string Message2Field;

        [OptionalField()]
        private string ModulusField;

        [OptionalField()]
        private string NetworkIdField;

        [OptionalField()]
        private string PNRefField;

        [OptionalField()]
        private string PinReferenceIdField;

        [OptionalField()]
        private string ProcessedAsCreditCardField;

        [OptionalField()]
        private string QualifiedInternetPinField;

        [OptionalField()]
        private string QualifiedKioskField;

        [OptionalField()]
        private string QualifiedPinField;

        [OptionalField()]
        private string QualifiedPinlessField;

        [OptionalField()]
        private string QualifiedRecurringField;

        [OptionalField()]
        private string ReceiptURLField;

        [OptionalField()]
        private string RespMSGField;

        [OptionalField()]
        private string ResultField;

        [OptionalField()]
        private string SessionIdField;

        [OptionalField()]
        private string StatusField;

        [OptionalField()]
        private string TokenNumberField;

        [OptionalField()]
        private string TransactionTokenField;

        [OptionalField()]
        private string WorkingKeyField;

        [global::System.ComponentModel.Browsable(false)]
        public ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public string AuthCode
        {
            get
            {
                return this.AuthCodeField;
            }
            set
            {
                if ((object.ReferenceEquals(this.AuthCodeField, value) != true))
                {
                    this.AuthCodeField = value;
                    this.RaisePropertyChanged("AuthCode");
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public string Exponent
        {
            get
            {
                return this.ExponentField;
            }
            set
            {
                if ((object.ReferenceEquals(this.ExponentField, value) != true))
                {
                    this.ExponentField = value;
                    this.RaisePropertyChanged("Exponent");
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public string ExtData
        {
            get
            {
                return this.ExtDataField;
            }
            set
            {
                if ((object.ReferenceEquals(this.ExtDataField, value) != true))
                {
                    this.ExtDataField = value;
                    this.RaisePropertyChanged("ExtData");
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public string GUID
        {
            get
            {
                return this.GUIDField;
            }
            set
            {
                if ((object.ReferenceEquals(this.GUIDField, value) != true))
                {
                    this.GUIDField = value;
                    this.RaisePropertyChanged("GUID");
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public string GetAVSResult
        {
            get
            {
                return this.GetAVSResultField;
            }
            set
            {
                if ((object.ReferenceEquals(this.GetAVSResultField, value) != true))
                {
                    this.GetAVSResultField = value;
                    this.RaisePropertyChanged("GetAVSResult");
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public string GetAVSResultTXT
        {
            get
            {
                return this.GetAVSResultTXTField;
            }
            set
            {
                if ((object.ReferenceEquals(this.GetAVSResultTXTField, value) != true))
                {
                    this.GetAVSResultTXTField = value;
                    this.RaisePropertyChanged("GetAVSResultTXT");
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public string GetCVResult
        {
            get
            {
                return this.GetCVResultField;
            }
            set
            {
                if ((object.ReferenceEquals(this.GetCVResultField, value) != true))
                {
                    this.GetCVResultField = value;
                    this.RaisePropertyChanged("GetCVResult");
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public string GetCVResultTXT
        {
            get
            {
                return this.GetCVResultTXTField;
            }
            set
            {
                if ((object.ReferenceEquals(this.GetCVResultTXTField, value) != true))
                {
                    this.GetCVResultTXTField = value;
                    this.RaisePropertyChanged("GetCVResultTXT");
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public string GetCommercialCard
        {
            get
            {
                return this.GetCommercialCardField;
            }
            set
            {
                if ((object.ReferenceEquals(this.GetCommercialCardField, value) != true))
                {
                    this.GetCommercialCardField = value;
                    this.RaisePropertyChanged("GetCommercialCard");
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public string GetGetOrigResult
        {
            get
            {
                return this.GetGetOrigResultField;
            }
            set
            {
                if ((object.ReferenceEquals(this.GetGetOrigResultField, value) != true))
                {
                    this.GetGetOrigResultField = value;
                    this.RaisePropertyChanged("GetGetOrigResult");
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public string GetStreetMatchTXT
        {
            get
            {
                return this.GetStreetMatchTXTField;
            }
            set
            {
                if ((object.ReferenceEquals(this.GetStreetMatchTXTField, value) != true))
                {
                    this.GetStreetMatchTXTField = value;
                    this.RaisePropertyChanged("GetStreetMatchTXT");
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public string GetZipMatchTXT
        {
            get
            {
                return this.GetZipMatchTXTField;
            }
            set
            {
                if ((object.ReferenceEquals(this.GetZipMatchTXTField, value) != true))
                {
                    this.GetZipMatchTXTField = value;
                    this.RaisePropertyChanged("GetZipMatchTXT");
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public string History
        {
            get
            {
                return this.HistoryField;
            }
            set
            {
                if ((object.ReferenceEquals(this.HistoryField, value) != true))
                {
                    this.HistoryField = value;
                    this.RaisePropertyChanged("History");
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public string HostCode
        {
            get
            {
                return this.HostCodeField;
            }
            set
            {
                if ((object.ReferenceEquals(this.HostCodeField, value) != true))
                {
                    this.HostCodeField = value;
                    this.RaisePropertyChanged("HostCode");
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public string HostURL
        {
            get
            {
                return this.HostURLField;
            }
            set
            {
                if ((object.ReferenceEquals(this.HostURLField, value) != true))
                {
                    this.HostURLField = value;
                    this.RaisePropertyChanged("HostURL");
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public string InNetwork
        {
            get
            {
                return this.InNetworkField;
            }
            set
            {
                if ((object.ReferenceEquals(this.InNetworkField, value) != true))
                {
                    this.InNetworkField = value;
                    this.RaisePropertyChanged("InNetwork");
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public string InnerErrorCode
        {
            get
            {
                return this.InnerErrorCodeField;
            }
            set
            {
                if ((object.ReferenceEquals(this.InnerErrorCodeField, value) != true))
                {
                    this.InnerErrorCodeField = value;
                    this.RaisePropertyChanged("InnerErrorCode");
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public string InnerErrorMessage
        {
            get
            {
                return this.InnerErrorMessageField;
            }
            set
            {
                if ((object.ReferenceEquals(this.InnerErrorMessageField, value) != true))
                {
                    this.InnerErrorMessageField = value;
                    this.RaisePropertyChanged("InnerErrorMessage");
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public string InvNum
        {
            get
            {
                return this.InvNumField;
            }
            set
            {
                if ((object.ReferenceEquals(this.InvNumField, value) != true))
                {
                    this.InvNumField = value;
                    this.RaisePropertyChanged("InvNum");
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public string KeyPointer
        {
            get
            {
                return this.KeyPointerField;
            }
            set
            {
                if ((object.ReferenceEquals(this.KeyPointerField, value) != true))
                {
                    this.KeyPointerField = value;
                    this.RaisePropertyChanged("KeyPointer");
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public string Message
        {
            get
            {
                return this.MessageField;
            }
            set
            {
                if ((object.ReferenceEquals(this.MessageField, value) != true))
                {
                    this.MessageField = value;
                    this.RaisePropertyChanged("Message");
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public string Message1
        {
            get
            {
                return this.Message1Field;
            }
            set
            {
                if ((object.ReferenceEquals(this.Message1Field, value) != true))
                {
                    this.Message1Field = value;
                    this.RaisePropertyChanged("Message1");
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public string Message2
        {
            get
            {
                return this.Message2Field;
            }
            set
            {
                if ((object.ReferenceEquals(this.Message2Field, value) != true))
                {
                    this.Message2Field = value;
                    this.RaisePropertyChanged("Message2");
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public string Modulus
        {
            get
            {
                return this.ModulusField;
            }
            set
            {
                if ((object.ReferenceEquals(this.ModulusField, value) != true))
                {
                    this.ModulusField = value;
                    this.RaisePropertyChanged("Modulus");
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public string NetworkId
        {
            get
            {
                return this.NetworkIdField;
            }
            set
            {
                if ((object.ReferenceEquals(this.NetworkIdField, value) != true))
                {
                    this.NetworkIdField = value;
                    this.RaisePropertyChanged("NetworkId");
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public string PNRef
        {
            get
            {
                return this.PNRefField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PNRefField, value) != true))
                {
                    this.PNRefField = value;
                    this.RaisePropertyChanged("PNRef");
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public string PinReferenceId
        {
            get
            {
                return this.PinReferenceIdField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PinReferenceIdField, value) != true))
                {
                    this.PinReferenceIdField = value;
                    this.RaisePropertyChanged("PinReferenceId");
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public string ProcessedAsCreditCard
        {
            get
            {
                return this.ProcessedAsCreditCardField;
            }
            set
            {
                if ((object.ReferenceEquals(this.ProcessedAsCreditCardField, value) != true))
                {
                    this.ProcessedAsCreditCardField = value;
                    this.RaisePropertyChanged("ProcessedAsCreditCard");
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public string QualifiedInternetPin
        {
            get
            {
                return this.QualifiedInternetPinField;
            }
            set
            {
                if ((object.ReferenceEquals(this.QualifiedInternetPinField, value) != true))
                {
                    this.QualifiedInternetPinField = value;
                    this.RaisePropertyChanged("QualifiedInternetPin");
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public string QualifiedKiosk
        {
            get
            {
                return this.QualifiedKioskField;
            }
            set
            {
                if ((object.ReferenceEquals(this.QualifiedKioskField, value) != true))
                {
                    this.QualifiedKioskField = value;
                    this.RaisePropertyChanged("QualifiedKiosk");
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public string QualifiedPin
        {
            get
            {
                return this.QualifiedPinField;
            }
            set
            {
                if ((object.ReferenceEquals(this.QualifiedPinField, value) != true))
                {
                    this.QualifiedPinField = value;
                    this.RaisePropertyChanged("QualifiedPin");
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public string QualifiedPinless
        {
            get
            {
                return this.QualifiedPinlessField;
            }
            set
            {
                if ((object.ReferenceEquals(this.QualifiedPinlessField, value) != true))
                {
                    this.QualifiedPinlessField = value;
                    this.RaisePropertyChanged("QualifiedPinless");
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public string QualifiedRecurring
        {
            get
            {
                return this.QualifiedRecurringField;
            }
            set
            {
                if ((object.ReferenceEquals(this.QualifiedRecurringField, value) != true))
                {
                    this.QualifiedRecurringField = value;
                    this.RaisePropertyChanged("QualifiedRecurring");
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public string ReceiptURL
        {
            get
            {
                return this.ReceiptURLField;
            }
            set
            {
                if ((object.ReferenceEquals(this.ReceiptURLField, value) != true))
                {
                    this.ReceiptURLField = value;
                    this.RaisePropertyChanged("ReceiptURL");
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public string RespMSG
        {
            get
            {
                return this.RespMSGField;
            }
            set
            {
                if ((object.ReferenceEquals(this.RespMSGField, value) != true))
                {
                    this.RespMSGField = value;
                    this.RaisePropertyChanged("RespMSG");
                }
            }
        }

        [DataMember()]
        public string Result
        {
            get
            {
                return this.ResultField;
            }
            set
            {
                if ((object.ReferenceEquals(this.ResultField, value) != true))
                {
                    this.ResultField = value;
                    this.RaisePropertyChanged("Result");
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public string SessionId
        {
            get
            {
                return this.SessionIdField;
            }
            set
            {
                if ((object.ReferenceEquals(this.SessionIdField, value) != true))
                {
                    this.SessionIdField = value;
                    this.RaisePropertyChanged("SessionId");
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public string Status
        {
            get
            {
                return this.StatusField;
            }
            set
            {
                if ((object.ReferenceEquals(this.StatusField, value) != true))
                {
                    this.StatusField = value;
                    this.RaisePropertyChanged("Status");
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public string TokenNumber
        {
            get
            {
                return this.TokenNumberField;
            }
            set
            {
                if ((object.ReferenceEquals(this.TokenNumberField, value) != true))
                {
                    this.TokenNumberField = value;
                    this.RaisePropertyChanged("TokenNumber");
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public string TransactionToken
        {
            get
            {
                return this.TransactionTokenField;
            }
            set
            {
                if ((object.ReferenceEquals(this.TransactionTokenField, value) != true))
                {
                    this.TransactionTokenField = value;
                    this.RaisePropertyChanged("TransactionToken");
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public string WorkingKey
        {
            get
            {
                return this.WorkingKeyField;
            }
            set
            {
                if ((object.ReferenceEquals(this.WorkingKeyField, value) != true))
                {
                    this.WorkingKeyField = value;
                    this.RaisePropertyChanged("WorkingKey");
                }
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
