using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Exchange.Contracts.Imaging
{
    [DataContract(Name = "ImageTransferObject", Namespace = "http://schemas.datacontract.org/2004/07/ImagingServer.model.image")]
    [Serializable()]
    public partial class ImageTransferObject : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
    {

        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BranchLocationCodeField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CaseNameField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CaseTitleField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CaseTypeCodeField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private char[] ClientDataField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CourtTypeCodeField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CourtTypeDescriptionField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DocketCodeField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DocketNameField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int HostImageAdapterIDField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int HostImageContainerIDField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int HostImageIDField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string HostImageTypeField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IRIField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ImageClientIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ImageEncodingType ImageEncodingTypeField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private byte[] ImageObjectDataField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ImagePathField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ImageRedactionType ImageRedactionTypeField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool InsertImageCompleteField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string JudgeDivisionCodeField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PageNumberField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool PerformExtractionField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool PerformRedactionField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.Dictionary<string, string> VendorSpecificPropertiesField;

        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
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

        [System.Runtime.Serialization.DataMemberAttribute()]
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

        [System.Runtime.Serialization.DataMemberAttribute()]
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

        [System.Runtime.Serialization.DataMemberAttribute()]
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

        [System.Runtime.Serialization.DataMemberAttribute()]
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

        [System.Runtime.Serialization.DataMemberAttribute()]
        public char[] ClientData
        {
            get
            {
                return this.ClientDataField;
            }
            set
            {
                if ((object.ReferenceEquals(this.ClientDataField, value) != true))
                {
                    this.ClientDataField = value;
                    this.RaisePropertyChanged("ClientData");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
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

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CourtTypeDescription
        {
            get
            {
                return this.CourtTypeDescriptionField;
            }
            set
            {
                if ((object.ReferenceEquals(this.CourtTypeDescriptionField, value) != true))
                {
                    this.CourtTypeDescriptionField = value;
                    this.RaisePropertyChanged("CourtTypeDescription");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DocketCode
        {
            get
            {
                return this.DocketCodeField;
            }
            set
            {
                if ((object.ReferenceEquals(this.DocketCodeField, value) != true))
                {
                    this.DocketCodeField = value;
                    this.RaisePropertyChanged("DocketCode");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DocketName
        {
            get
            {
                return this.DocketNameField;
            }
            set
            {
                if ((object.ReferenceEquals(this.DocketNameField, value) != true))
                {
                    this.DocketNameField = value;
                    this.RaisePropertyChanged("DocketName");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int HostImageAdapterID
        {
            get
            {
                return this.HostImageAdapterIDField;
            }
            set
            {
                if ((this.HostImageAdapterIDField.Equals(value) != true))
                {
                    this.HostImageAdapterIDField = value;
                    this.RaisePropertyChanged("HostImageAdapterID");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int HostImageContainerID
        {
            get
            {
                return this.HostImageContainerIDField;
            }
            set
            {
                if ((this.HostImageContainerIDField.Equals(value) != true))
                {
                    this.HostImageContainerIDField = value;
                    this.RaisePropertyChanged("HostImageContainerID");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int HostImageID
        {
            get
            {
                return this.HostImageIDField;
            }
            set
            {
                if ((this.HostImageIDField.Equals(value) != true))
                {
                    this.HostImageIDField = value;
                    this.RaisePropertyChanged("HostImageID");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
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

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string IRI
        {
            get
            {
                return this.IRIField;
            }
            set
            {
                if ((object.ReferenceEquals(this.IRIField, value) != true))
                {
                    this.IRIField = value;
                    this.RaisePropertyChanged("IRI");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ImageClientId
        {
            get
            {
                return this.ImageClientIdField;
            }
            set
            {
                if ((object.ReferenceEquals(this.ImageClientIdField, value) != true))
                {
                    this.ImageClientIdField = value;
                    this.RaisePropertyChanged("ImageClientId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public ImageEncodingType ImageEncodingType
        {
            get
            {
                return this.ImageEncodingTypeField;
            }
            set
            {
                if ((this.ImageEncodingTypeField.Equals(value) != true))
                {
                    this.ImageEncodingTypeField = value;
                    this.RaisePropertyChanged("ImageEncodingType");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte[] ImageObjectData
        {
            get
            {
                return this.ImageObjectDataField;
            }
            set
            {
                if ((object.ReferenceEquals(this.ImageObjectDataField, value) != true))
                {
                    this.ImageObjectDataField = value;
                    this.RaisePropertyChanged("ImageObjectData");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ImagePath
        {
            get
            {
                return this.ImagePathField;
            }
            set
            {
                if ((object.ReferenceEquals(this.ImagePathField, value) != true))
                {
                    this.ImagePathField = value;
                    this.RaisePropertyChanged("ImagePath");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public ImageRedactionType ImageRedactionType
        {
            get
            {
                return this.ImageRedactionTypeField;
            }
            set
            {
                if ((this.ImageRedactionTypeField.Equals(value) != true))
                {
                    this.ImageRedactionTypeField = value;
                    this.RaisePropertyChanged("ImageRedactionType");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool InsertImageComplete
        {
            get
            {
                return this.InsertImageCompleteField;
            }
            set
            {
                if ((this.InsertImageCompleteField.Equals(value) != true))
                {
                    this.InsertImageCompleteField = value;
                    this.RaisePropertyChanged("InsertImageComplete");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
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

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PageNumber
        {
            get
            {
                return this.PageNumberField;
            }
            set
            {
                if ((this.PageNumberField.Equals(value) != true))
                {
                    this.PageNumberField = value;
                    this.RaisePropertyChanged("PageNumber");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool PerformExtraction
        {
            get
            {
                return this.PerformExtractionField;
            }
            set
            {
                if ((this.PerformExtractionField.Equals(value) != true))
                {
                    this.PerformExtractionField = value;
                    this.RaisePropertyChanged("PerformExtraction");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool PerformRedaction
        {
            get
            {
                return this.PerformRedactionField;
            }
            set
            {
                if ((this.PerformRedactionField.Equals(value) != true))
                {
                    this.PerformRedactionField = value;
                    this.RaisePropertyChanged("PerformRedaction");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.Dictionary<string, string> VendorSpecificProperties
        {
            get
            {
                return this.VendorSpecificPropertiesField;
            }
            set
            {
                if ((object.ReferenceEquals(this.VendorSpecificPropertiesField, value) != true))
                {
                    this.VendorSpecificPropertiesField = value;
                    this.RaisePropertyChanged("VendorSpecificProperties");
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
