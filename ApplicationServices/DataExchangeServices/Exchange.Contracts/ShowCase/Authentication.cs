using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Exchange.Contracts.ShowCase
{
    [DataContractAttribute(Name = "AuthenticationResponse", Namespace = "http://schemas.datacontract.org/2004/07/Security.Authentication")]
    [System.SerializableAttribute()]
    public partial class AuthenticationResponse : object, IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
    {

        [System.NonSerializedAttribute()]
        private ExtensionDataObject extensionDataField;

        [OptionalFieldAttribute()]
        private string AuthenticationCookieField;

        [OptionalFieldAttribute()]
        private DefaultClaimSet[] ClaimSetsField;

        [OptionalFieldAttribute()]
        private AuthenticationResponseErrorCode ErrorCodeField;

        [OptionalFieldAttribute()]
        private string ErrorMessageField;

        [OptionalFieldAttribute()]
        private bool HasErrorField;

        [global::System.ComponentModel.BrowsableAttribute(false)]
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

        [DataMemberAttribute()]
        public string AuthenticationCookie
        {
            get
            {
                return this.AuthenticationCookieField;
            }
            set
            {
                if ((object.ReferenceEquals(this.AuthenticationCookieField, value) != true))
                {
                    this.AuthenticationCookieField = value;
                    this.RaisePropertyChanged("AuthenticationCookie");
                }
            }
        }

        [DataMemberAttribute()]
        public DefaultClaimSet[] ClaimSets
        {
            get
            {
                return this.ClaimSetsField;
            }
            set
            {
                if ((object.ReferenceEquals(this.ClaimSetsField, value) != true))
                {
                    this.ClaimSetsField = value;
                    this.RaisePropertyChanged("ClaimSets");
                }
            }
        }

        [DataMemberAttribute()]
        public AuthenticationResponseErrorCode ErrorCode
        {
            get
            {
                return this.ErrorCodeField;
            }
            set
            {
                if ((this.ErrorCodeField.Equals(value) != true))
                {
                    this.ErrorCodeField = value;
                    this.RaisePropertyChanged("ErrorCode");
                }
            }
        }

        [DataMemberAttribute()]
        public string ErrorMessage
        {
            get
            {
                return this.ErrorMessageField;
            }
            set
            {
                if ((object.ReferenceEquals(this.ErrorMessageField, value) != true))
                {
                    this.ErrorMessageField = value;
                    this.RaisePropertyChanged("ErrorMessage");
                }
            }
        }

        [DataMemberAttribute()]
        public bool HasError
        {
            get
            {
                return this.HasErrorField;
            }
            set
            {
                if ((this.HasErrorField.Equals(value) != true))
                {
                    this.HasErrorField = value;
                    this.RaisePropertyChanged("HasError");
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

    [DataContractAttribute(Name = "DefaultClaimSet", Namespace = "http://schemas.xmlsoap.org/ws/2005/05/identity")]
    [System.SerializableAttribute()]
    public partial class DefaultClaimSet : ClaimSet
    {

        [OptionalFieldAttribute()]
        private Claim[] ClaimsField;

        [OptionalFieldAttribute()]
        private ClaimSet IssuerField;

        [DataMemberAttribute()]
        public Claim[] Claims
        {
            get
            {
                return this.ClaimsField;
            }
            set
            {
                if ((object.ReferenceEquals(this.ClaimsField, value) != true))
                {
                    this.ClaimsField = value;
                    this.RaisePropertyChanged("Claims");
                }
            }
        }

        [DataMemberAttribute()]
        public ClaimSet Issuer
        {
            get
            {
                return this.IssuerField;
            }
            set
            {
                if ((object.ReferenceEquals(this.IssuerField, value) != true))
                {
                    this.IssuerField = value;
                    this.RaisePropertyChanged("Issuer");
                }
            }
        }
    }

    [DataContractAttribute(Name = "AuthenticationResponseErrorCode", Namespace = "http://schemas.datacontract.org/2004/07/Security.Authentication")]
    public enum AuthenticationResponseErrorCode : int
    {

        [EnumMemberAttribute()]
        None = 0,

        [EnumMemberAttribute()]
        AuthenticationFailed = 1,

        [EnumMemberAttribute()]
        DatabaseNotFound = 2,

        [EnumMemberAttribute()]
        EmptyPassword = 3,

        [EnumMemberAttribute()]
        LoginDisabled = 4,

        [EnumMemberAttribute()]
        LoginExpired = 5,

        [EnumMemberAttribute()]
        PasswordExpired = 6,

        [EnumMemberAttribute()]
        SingleSignOnDisabled = 7,

        [EnumMemberAttribute()]
        ConfigurationException = 8,
    }

    [DataContractAttribute(Name = "ClaimSet", Namespace = "http://schemas.xmlsoap.org/ws/2005/05/identity")]
    [SerializableAttribute()]
    [KnownTypeAttribute(typeof(DefaultClaimSet))]
    public partial class ClaimSet : object, IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
    {

        [NonSerializedAttribute()]
        private ExtensionDataObject extensionDataField;

        [global::System.ComponentModel.BrowsableAttribute(false)]
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

    [DataContractAttribute(Name = "Claim", Namespace = "http://schemas.xmlsoap.org/ws/2005/05/identity")]
    [SerializableAttribute()]
    [KnownTypeAttribute(typeof(AuthenticationResponse))]
    [KnownTypeAttribute(typeof(AuthenticationResponseErrorCode))]
    [KnownTypeAttribute(typeof(Dictionary<string, string>))]
    [KnownTypeAttribute(typeof(Dictionary<string, Claim[]>))]
    [KnownTypeAttribute(typeof(DefaultClaimSet[]))]
    [KnownTypeAttribute(typeof(DefaultClaimSet))]
    [KnownTypeAttribute(typeof(ClaimSet))]
    [KnownTypeAttribute(typeof(Claim[]))]
    public partial class Claim : object, IExtensibleDataObject, INotifyPropertyChanged
    {

        [System.NonSerializedAttribute()]
        private ExtensionDataObject extensionDataField;

        [OptionalFieldAttribute()]
        private string ClaimTypeField;

        [OptionalFieldAttribute()]
        private object ResourceField;

        [OptionalFieldAttribute()]
        private string RightField;

        [global::System.ComponentModel.BrowsableAttribute(false)]
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

        [DataMemberAttribute()]
        public string ClaimType
        {
            get
            {
                return this.ClaimTypeField;
            }
            set
            {
                if ((object.ReferenceEquals(this.ClaimTypeField, value) != true))
                {
                    this.ClaimTypeField = value;
                    this.RaisePropertyChanged("ClaimType");
                }
            }
        }

        [DataMemberAttribute()]
        public object Resource
        {
            get
            {
                return this.ResourceField;
            }
            set
            {
                if ((object.ReferenceEquals(this.ResourceField, value) != true))
                {
                    this.ResourceField = value;
                    this.RaisePropertyChanged("Resource");
                }
            }
        }

        [DataMemberAttribute()]
        public string Right
        {
            get
            {
                return this.RightField;
            }
            set
            {
                if ((object.ReferenceEquals(this.RightField, value) != true))
                {
                    this.RightField = value;
                    this.RaisePropertyChanged("Right");
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
