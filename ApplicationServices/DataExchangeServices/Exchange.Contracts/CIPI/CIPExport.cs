﻿using System.Xml.Serialization;

// 
// This source code was auto-generated by xsd, Version=4.0.30319.1.
// 

namespace Exchange.Contracts.CIPI
{

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class CIPExport
    {

        private CIPExportIncident[] itemsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Incident", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public CIPExportIncident[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CIPExportIncident
    {

        private string case_noField;

        private CIPExportIncidentRelationships[] relationshipsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string case_no
        {
            get
            {
                return this.case_noField;
            }
            set
            {
                this.case_noField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Relationships", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public CIPExportIncidentRelationships[] Relationships
        {
            get
            {
                return this.relationshipsField;
            }
            set
            {
                this.relationshipsField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CIPExportIncidentRelationships
    {

        private CIPExportIncidentRelationshipsRelationship[] relationshipField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Relationship", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public CIPExportIncidentRelationshipsRelationship[] Relationship
        {
            get
            {
                return this.relationshipField;
            }
            set
            {
                this.relationshipField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CIPExportIncidentRelationshipsRelationship
    {

        private string bar_noField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string bar_no
        {
            get
            {
                return this.bar_noField;
            }
            set
            {
                this.bar_noField = value;
            }
        }
    }
}