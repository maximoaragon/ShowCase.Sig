using System;
using System.Runtime.Serialization;

namespace Exchange.Contracts.Imaging
{
    [DataContractAttribute(Name = "FileTransferObject", Namespace = "http://schemas.datacontract.org/2004/07/ImagingServer.model.file")]
    [SerializableAttribute()]
    public partial class FileTransferObject : object, IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
    {

        [NonSerializedAttribute()]
        private ExtensionDataObject extensionDataField;

        [OptionalFieldAttribute()]
        private int ContainerIDField;

        [OptionalFieldAttribute()]
        private string ContainerTypeField;

        [OptionalFieldAttribute()]
        private byte[] FileDataField;

        [OptionalFieldAttribute()]
        private string FileExtensionField;

        [OptionalFieldAttribute()]
        private string FileHandleField;

        [OptionalFieldAttribute()]
        private int FileIDField;

        [OptionalFieldAttribute()]
        private string FilePathField;

        [OptionalFieldAttribute()]
        private string MetadataField;

        [OptionalFieldAttribute()]
        private int PageCountField;

        [OptionalFieldAttribute()]
        private bool SecuredField;

        [OptionalFieldAttribute()]
        private int SeqPositionField;

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
        public int ContainerID
        {
            get
            {
                return this.ContainerIDField;
            }
            set
            {
                if ((this.ContainerIDField.Equals(value) != true))
                {
                    this.ContainerIDField = value;
                    this.RaisePropertyChanged("ContainerID");
                }
            }
        }

        [DataMemberAttribute()]
        public string ContainerType
        {
            get
            {
                return this.ContainerTypeField;
            }
            set
            {
                if ((object.ReferenceEquals(this.ContainerTypeField, value) != true))
                {
                    this.ContainerTypeField = value;
                    this.RaisePropertyChanged("ContainerType");
                }
            }
        }

        [DataMemberAttribute()]
        public byte[] FileData
        {
            get
            {
                return this.FileDataField;
            }
            set
            {
                if ((object.ReferenceEquals(this.FileDataField, value) != true))
                {
                    this.FileDataField = value;
                    this.RaisePropertyChanged("FileData");
                }
            }
        }

        [DataMemberAttribute()]
        public string FileExtension
        {
            get
            {
                return this.FileExtensionField;
            }
            set
            {
                if ((object.ReferenceEquals(this.FileExtensionField, value) != true))
                {
                    this.FileExtensionField = value;
                    this.RaisePropertyChanged("FileExtension");
                }
            }
        }

        [DataMemberAttribute()]
        public string FileHandle
        {
            get
            {
                return this.FileHandleField;
            }
            set
            {
                if ((object.ReferenceEquals(this.FileHandleField, value) != true))
                {
                    this.FileHandleField = value;
                    this.RaisePropertyChanged("FileHandle");
                }
            }
        }

        [DataMemberAttribute()]
        public int FileID
        {
            get
            {
                return this.FileIDField;
            }
            set
            {
                if ((this.FileIDField.Equals(value) != true))
                {
                    this.FileIDField = value;
                    this.RaisePropertyChanged("FileID");
                }
            }
        }

        [DataMemberAttribute()]
        public string FilePath
        {
            get
            {
                return this.FilePathField;
            }
            set
            {
                if ((object.ReferenceEquals(this.FilePathField, value) != true))
                {
                    this.FilePathField = value;
                    this.RaisePropertyChanged("FilePath");
                }
            }
        }

        [DataMemberAttribute()]
        public string Metadata
        {
            get
            {
                return this.MetadataField;
            }
            set
            {
                if ((object.ReferenceEquals(this.MetadataField, value) != true))
                {
                    this.MetadataField = value;
                    this.RaisePropertyChanged("Metadata");
                }
            }
        }

        [DataMemberAttribute()]
        public int PageCount
        {
            get
            {
                return this.PageCountField;
            }
            set
            {
                if ((this.PageCountField.Equals(value) != true))
                {
                    this.PageCountField = value;
                    this.RaisePropertyChanged("PageCount");
                }
            }
        }

        [DataMemberAttribute()]
        public bool Secured
        {
            get
            {
                return this.SecuredField;
            }
            set
            {
                if ((this.SecuredField.Equals(value) != true))
                {
                    this.SecuredField = value;
                    this.RaisePropertyChanged("Secured");
                }
            }
        }

        [DataMemberAttribute()]
        public int SeqPosition
        {
            get
            {
                return this.SeqPositionField;
            }
            set
            {
                if ((this.SeqPositionField.Equals(value) != true))
                {
                    this.SeqPositionField = value;
                    this.RaisePropertyChanged("SeqPosition");
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
