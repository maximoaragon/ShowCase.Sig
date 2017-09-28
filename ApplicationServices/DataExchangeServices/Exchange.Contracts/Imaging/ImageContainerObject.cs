using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Exchange.Contracts.Imaging
{
    [DataContractAttribute(Name = "ImageContainerObject", Namespace = "http://schemas.datacontract.org/2004/07/ImagingServer.model.image")]
    [Serializable()]
    public partial class ImageContainerObject : object, IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
    {

        [System.NonSerializedAttribute()]
        private ExtensionDataObject extensionDataField;

        [OptionalFieldAttribute()]
        private string BranchLocationCodeField;

        [OptionalFieldAttribute()]
        private string CaseNameField;

        [OptionalFieldAttribute()]
        private string CaseTitleField;

        [OptionalFieldAttribute()]
        private string CaseTypeCodeField;

        [OptionalFieldAttribute()]
        private string CourtTypeCodeField;

        [OptionalFieldAttribute()]
        private string HostImageTypeField;

        [OptionalFieldAttribute()]
        private string JudgeDivisionCodeField;

        [OptionalFieldAttribute()]
        private string UserIDField;

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
        public string BranchLocationCode
        {
            get
            {
                return this.BranchLocationCodeField;
            }
            set
            {
                if ((object.ReferenceEquals(this.BranchLocationCodeField, value) != true))
                {
                    this.BranchLocationCodeField = value;
                    this.RaisePropertyChanged("BranchLocationCode");
                }
            }
        }

        [DataMemberAttribute()]
        public string CaseName
        {
            get
            {
                return this.CaseNameField;
            }
            set
            {
                if ((object.ReferenceEquals(this.CaseNameField, value) != true))
                {
                    this.CaseNameField = value;
                    this.RaisePropertyChanged("CaseName");
                }
            }
        }

        [DataMemberAttribute()]
        public string CaseTitle
        {
            get
            {
                return this.CaseTitleField;
            }
            set
            {
                if ((object.ReferenceEquals(this.CaseTitleField, value) != true))
                {
                    this.CaseTitleField = value;
                    this.RaisePropertyChanged("CaseTitle");
                }
            }
        }

        [DataMemberAttribute()]
        public string CaseTypeCode
        {
            get
            {
                return this.CaseTypeCodeField;
            }
            set
            {
                if ((object.ReferenceEquals(this.CaseTypeCodeField, value) != true))
                {
                    this.CaseTypeCodeField = value;
                    this.RaisePropertyChanged("CaseTypeCode");
                }
            }
        }

        [DataMemberAttribute()]
        public string CourtTypeCode
        {
            get
            {
                return this.CourtTypeCodeField;
            }
            set
            {
                if ((object.ReferenceEquals(this.CourtTypeCodeField, value) != true))
                {
                    this.CourtTypeCodeField = value;
                    this.RaisePropertyChanged("CourtTypeCode");
                }
            }
        }

        [DataMemberAttribute()]
        public string HostImageType
        {
            get
            {
                return this.HostImageTypeField;
            }
            set
            {
                if ((object.ReferenceEquals(this.HostImageTypeField, value) != true))
                {
                    this.HostImageTypeField = value;
                    this.RaisePropertyChanged("HostImageType");
                }
            }
        }

        [DataMemberAttribute()]
        public string JudgeDivisionCode
        {
            get
            {
                return this.JudgeDivisionCodeField;
            }
            set
            {
                if ((object.ReferenceEquals(this.JudgeDivisionCodeField, value) != true))
                {
                    this.JudgeDivisionCodeField = value;
                    this.RaisePropertyChanged("JudgeDivisionCode");
                }
            }
        }

        [DataMemberAttribute()]
        public string UserID
        {
            get
            {
                return this.UserIDField;
            }
            set
            {
                if ((object.ReferenceEquals(this.UserIDField, value) != true))
                {
                    this.UserIDField = value;
                    this.RaisePropertyChanged("UserID");
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
