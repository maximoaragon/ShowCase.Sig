using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Exchange.Contracts.ShowCase;

namespace Exchange.Contracts.Services
{
    using Oasis.LegalXml.CourtFiling.v40.Civil;
    using Oasis.LegalXml.CourtFiling.v40.Core;
    using Oasis.LegalXml.CourtFiling.v40.Docketing;
    using Oasis.LegalXml.CourtFiling.v40.Domestic;
    using Oasis.LegalXml.CourtFiling.v40.Ecf;
    using Oasis.LegalXml.CourtFiling.v40.Filing;
    using Oasis.LegalXml.CourtFiling.v40.Juvenile;
    using Oasis.LegalXml.CourtFiling.v40.WebServiceMessagingProfile;

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace = "urn:oasis:names:tc:legalxml-courtfiling:wsdl:WebServiceMessagingProfile-Definitio" +
        "ns-4.0", ConfigurationName = "FilingReviewMDE.FilingReviewMDEPort")]
    public interface FilingReviewMDEPort
    {

        // CODEGEN: Generating message contract since the operation ReviewFiling is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action = "urn:oasis:names:tc:legalxml-courtfiling:wsdl:WebServiceMessagingProfile-Definitio" +
            "ns-4.0/FilingReviewMDEPort/ReviewFiling", ReplyAction = "urn:oasis:names:tc:legalxml-courtfiling:wsdl:WebServiceMessagingProfile-Definitio" +
            "ns-4.0/FilingReviewMDEPort/ReviewFilingResponse")]
        //[System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        //[System.ServiceModel.ServiceKnownTypeAttribute(typeof(MeasureType1))]
        //[System.ServiceModel.ServiceKnownTypeAttribute(typeof(MetadataType))]
        //[System.ServiceModel.ServiceKnownTypeAttribute(typeof(@decimal))]
        //[System.ServiceModel.ServiceKnownTypeAttribute(typeof(AugmentationType))]
        //[System.ServiceModel.ServiceKnownTypeAttribute(typeof(ComplexObjectType))]
        ReviewFilingResponse ReviewFiling(ReviewFilingRequest request);

        // CODEGEN: Generating message contract since the operation NotifyDocketingComplete is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action = "urn:oasis:names:tc:legalxml-courtfiling:wsdl:WebServiceMessagingProfile-Definitio" +
            "ns-4.0/FilingReviewMDEPort/NotifyDocketingComplete", ReplyAction = "urn:oasis:names:tc:legalxml-courtfiling:wsdl:WebServiceMessagingProfile-Definitio" +
            "ns-4.0/FilingReviewMDEPort/NotifyDocketingCompleteResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        //[System.ServiceModel.ServiceKnownTypeAttribute(typeof(MeasureType1))]
        //[System.ServiceModel.ServiceKnownTypeAttribute(typeof(MetadataType))]
        //[System.ServiceModel.ServiceKnownTypeAttribute(typeof(@decimal))]
        //[System.ServiceModel.ServiceKnownTypeAttribute(typeof(AugmentationType))]
        //[System.ServiceModel.ServiceKnownTypeAttribute(typeof(ComplexObjectType))]
        NotifyDocketingCompleteResponse NotifyDocketingComplete(NotifyDocketingCompleteRequest request);

        // CODEGEN: Generating message contract since the operation NotifyFilingStatusChange is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action = "urn:oasis:names:tc:legalxml-courtfiling:wsdl:WebServiceMessagingProfile-Definitio" +
            "ns-4.0/FilingReviewMDEPort/NotifyFilingStatusChange", ReplyAction = "urn:oasis:names:tc:legalxml-courtfiling:wsdl:WebServiceMessagingProfile-Definitio" +
            "ns-4.0/FilingReviewMDEPort/NotifyFilingStatusChangeResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        //[System.ServiceModel.ServiceKnownTypeAttribute(typeof(MeasureType1))]
        //[System.ServiceModel.ServiceKnownTypeAttribute(typeof(MetadataType))]
        //[System.ServiceModel.ServiceKnownTypeAttribute(typeof(@decimal))]
        //[System.ServiceModel.ServiceKnownTypeAttribute(typeof(AugmentationType))]
        //[System.ServiceModel.ServiceKnownTypeAttribute(typeof(ComplexObjectType))]
        NotifyFilingStatusChangeResponse NotifyFilingStatusChange(NotifyFilingStatusChangeRequest request);
    }


    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface FilingReviewMDEPortChannel : FilingReviewMDEPort, System.ServiceModel.IClientChannel
    {
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class FilingReviewMDEPortClient : System.ServiceModel.ClientBase<FilingReviewMDEPort>, FilingReviewMDEPort
    {

        public FilingReviewMDEPortClient()
        {
        }

        public FilingReviewMDEPortClient(string endpointConfigurationName) :
            base(endpointConfigurationName)
        {
        }

        public FilingReviewMDEPortClient(string endpointConfigurationName, string remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }

        public FilingReviewMDEPortClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }

        public FilingReviewMDEPortClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
            base(binding, remoteAddress)
        {
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ReviewFilingResponse FilingReviewMDEPort.ReviewFiling(ReviewFilingRequest request)
        {
            return base.Channel.ReviewFiling(request);
        }

        public ReviewFilingResponse ReviewFiling(ReviewFilingRequestMessageType ReviewFilingRequestMessage)
        {
            ReviewFilingRequest inValue = new ReviewFilingRequest();
            inValue.ReviewFilingRequestMessage = ReviewFilingRequestMessage;
            ReviewFilingResponse retVal = ((FilingReviewMDEPort)(this)).ReviewFiling(inValue);
            return retVal;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        NotifyDocketingCompleteResponse FilingReviewMDEPort.NotifyDocketingComplete(NotifyDocketingCompleteRequest request)
        {
            return base.Channel.NotifyDocketingComplete(request);
        }

        public NotifyDocketingCompleteResponse NotifyDocketingComplete(RecordDocketingCallbackMessageType RecordDocketingCallbackMessage)
        {
            NotifyDocketingCompleteRequest inValue = new NotifyDocketingCompleteRequest();
            inValue.RecordDocketingCallbackMessage = RecordDocketingCallbackMessage;
            NotifyDocketingCompleteResponse retVal = ((FilingReviewMDEPort)(this)).NotifyDocketingComplete(inValue);
            return retVal;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        NotifyFilingStatusChangeResponse FilingReviewMDEPort.NotifyFilingStatusChange(NotifyFilingStatusChangeRequest request)
        {
            return base.Channel.NotifyFilingStatusChange(request);
        }

        public NotifyFilingStatusChangeResponse NotifyFilingStatusChange(FilingStatusResponseMessageType FilingStatusResponseMessage)
        {
            NotifyFilingStatusChangeRequest inValue = new NotifyFilingStatusChangeRequest();
            inValue.FilingStatusResponseMessage = FilingStatusResponseMessage;
            NotifyFilingStatusChangeResponse retVal = ((FilingReviewMDEPort)(this)).NotifyFilingStatusChange(inValue);
            return retVal;
        }
    }
}

