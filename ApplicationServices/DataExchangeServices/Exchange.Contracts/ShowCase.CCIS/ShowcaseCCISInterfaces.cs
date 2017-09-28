using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
//using Clerk.CaseManagement.CCIS.Contracts.Model.Reply;
//using Clerk.CaseManagement.CCIS.Contracts.Model.SearchCriteria;
//using Clerk.CaseManagement.CCIS.Contracts;
using System.Xml.Serialization;

namespace Exchange.Contracts.Showcase.CCIS
{

    [ServiceContractAttribute]
    public interface IShowcaseCCISPushInterface
    {
        [OperationContractAttribute]
        Dictionary<string, string> PushCCIS(int DataExchangeTransactionLogID = 0, int CaseID = 0, DateTime dtFromDate = default(DateTime), DateTime dtToDate = default(DateTime));
    }

    //[ServiceContractAttribute]
    //public interface ICCISPullService : Clerk.CMS.CCIS.ICCISPullService
    //{

    //}

    [ServiceContract(Namespace = "http://CiviTek/CCIS")]
    public interface ICCISPullService
    {
        [OperationContract]
        CCISAttorneyResult PullCCISAttorney(string ucn, int caseViewUserRole);
        [OperationContract]
        CCISCaseResult PullCCISCase(string ucn, int caseViewUserRole);
        [OperationContract]
        CCISChargeResult PullCCISCharge(string ucn, string chargeSequenceNumber, int caseViewUserRole);
        [OperationContract]
        CCISCourtEventResult PullCCISCourtEvent(string ucn, int caseViewUserRole);
        [OperationContract]
        CCISCourtEventMapResult PullCCISCourtEventMap(int caseViewUserRole);
        [OperationContract]
        CCISCaseProgressDocketResult PullCCISDocket(string ucn, int noOfRecordsPerPage, int startPageNumber, int caseViewUserRole);
        [OperationContract]
        CCISDocketMapResult PullCCISDocketMap(int caseViewUserRole);
        [OperationContract]
        CCISFilingResult PullCCISFiling(string ucn, int caseViewUserRole);
        [OperationContract]
        CCISFinancialSummaryResult PullCCISFinancialSummary(string ucn, int caseViewUserRole);
        [OperationContract]
        CCISJudgeHistoryResult PullCCISJudgeHistory(string ucn, int caseViewUserRole);
        [OperationContract]
        CCISJudgeMapResult PullCCISJudgeMap(int caseViewUserRole);
        [OperationContract]
        CCISOBTSResult PullCCISOBTS(string ucn, int caseViewUserRole);
        [OperationContract]
        CCISParcelResult PullCCISParcel(string ucn, int caseViewUserRole);
        [OperationContract]
        CCISPartyResult PullCCISParty(string ucn, int caseViewUserRole);
        [OperationContract]
        CCISPartyTypeResult PullCCISPartyType(string ucn, int caseViewUserRole);
        [OperationContract]
        CCISReopenResult PullCCISReopen(string ucn, int caseViewUserRole);
        [OperationContract]
        CCISSentenceResult PullCCISSentence(string ucn, string chargeSequenceNumber, int caseViewUserRole);
        [OperationContract]
        CCISWarrantSummonsCapiasResult PullCCISWarrantSummonsCapias(string ucn, int caseViewUserRole);
        [OperationContract]
        byte[] PullDocketImage(string ucn, string documentID, int pageNumber, string includeAnnotations, int caseViewUserRole);
        [OperationContract]
        CCISDocketImageResult PullDocketImageWithType(string ucn, string documentID, int pageNumber, string includeAnnotations, int caseViewUserRole);
    }


    //[ServiceContract(Name = "ICcisGetService", Namespace = "https://30prod.volusiaccis.org/ccis")]
    //[ServiceKnownType(typeof(AsmRole))]
    //[ServiceKnownType(typeof(CaseIdentifierType))]
    //[ServiceKnownType(typeof(CodeRecordReply))]
    //[ServiceKnownType(typeof(CodeRecordType))]
    //[ServiceKnownType(typeof(MaxScheduleType))]
    //[ServiceKnownType(typeof(ResultStatus))]
    //[WsdlDocumentation("Service contract implemented by Clerk systems to reply to requests for case data. CCIS and Judicial viewers will rely on this contract to request case data.")]

    //public interface ICcisGetService
    //{
    //    [OperationContract]
    //    CaseSearchReply ExecuteCaseSearch(AsmRole asmRole, string replyToUrl, int maxResult, CcisCaseSearchCriteria searchCriteria);
    //    [OperationContract]
    //    CourtEventSearchReply ExecuteCourtEventSearch(AsmRole asmRole, CcisCourtEventCriteria searchCriteria);
    //    [OperationContract]
    //    DocumentKeywordSearchReply ExecuteDocumentKeywordSearch(AsmRole asmRole, CcisDocumentKeywordSearchCriteria criteria);
    //    [OperationContract]
    //    FlexQueryReply ExecuteFlexQuery(string replyToUrl, string credential, string queryId, CcisFleaQueryCriteriaList criteria);
    //    [OperationContract]
    //    CaseAssessmentReply GetAssessments(AsmRole asmRole, CaseIdentifierType identifierType, string identifier);
    //    [OperationContract]
    //    CaseBondReply GetBonds(AsmRole asmRole, CaseIdentifierType identifierType, string identifier);
    //    [OperationContract]
    //    CaseBookingReply GetBookings(AsmRole asmRole, CaseIdentifierType identifierType, string identifier);
    //    [OperationContract]
    //    CaseMasterReply GetCase(AsmRole asmRole, CaseIdentifierType identifierType, string identifier);
    //    [OperationContract]
    //    CaseChargeReply GetCharge(AsmRole asmRole, CaseIdentifierType identifierType, string identifier);
    //    [OperationContract]
    //    CaseChargeCitationReply GetCitation(AsmRole asmRole, CaseIdentifierType identifierType, string identifier, int chargeSequence);
    //    [OperationContract]
    //    CodeRecordReply GetCodeTable(CodeRecordType codeRecordType);
    //    [OperationContract]
    //    CaseCourtEventReply GetCourtEvents(AsmRole asmRole, CaseIdentifierType identifierType, string identifier);
    //    [OperationContract]
    //    CaseDivisionAssignmentReply GetDivisionAssignment(AsmRole asmRole, CaseIdentifierType identifierType, string identifier);
    //    [OperationContract]
    //    CaseFilingReply GetFiling(AsmRole asmRole, string filingId);
    //    [OperationContract]
    //    ElectronicDocumentReply GetFilingDocument(AsmRole asmRole, CaseIdentifierType identifierType, string identifier, string filingId, string pageNumber, string documentId, string redact);
    //    [OperationContract]
    //    CaseFilingReply GetFilings(AsmRole asmRole, CaseIdentifierType identifierType, string identifier, int filingsPerPage, int pageNumber);
    //    [OperationContract]
    //    CaseJudgeAssignmentReply GetJudgeAssignment(AsmRole asmRole, CaseIdentifierType identifierType, string identifier);
    //    [OperationContract]
    //    ElectronicDocumentReply GetNoteDocument(AsmRole asmRole, CaseIdentifierType identifierType, string identifier, string noteId, string pageNumber, string documentId, string redact);
    //    [OperationContract]
    //    CaseNoteReply GetNotes(AsmRole asmRole, CaseIdentifierType identifierType, string identifier);
    //    [OperationContract]
    //    CaseParcelReply GetParcels(AsmRole asmRole, CaseIdentifierType identifierType, string identifier);
    //    [OperationContract]
    //    CasePartyReply GetParties(AsmRole asmRole, CaseIdentifierType identifierType, string identifier, bool returnAddressInfo, bool returnEmailInfo, bool returnPhoneInfo, bool returnMugshots, PartyRepresentationOptionType representationOption);
    //    [OperationContract]
    //    CasePartyReply GetParty(AsmRole asmRole, string partyTrackingId, bool returnAddressInfo, bool returnEmailInfo, bool returnPhoneInfo, bool returnMugshots, PartyRepresentationOptionType representationOption);
    //    [OperationContract]
    //    MugshotImageReply GetPartyMugshotImage(AsmRole asmRole, string partyTrackingId, string mugshotId);
    //    [OperationContract]
    //    CasePaymentReply GetPayments(AsmRole asmRole, CaseIdentifierType identifierType, string identifier);
    //    [OperationContract]
    //    CaseReopenReply GetReopens(AsmRole asmRole, CaseIdentifierType identifierType, string identifier);
    //    [OperationContract]
    //    RepresentationReply GetRepresentation(RepresentationIdentifierType identifierType, string identifier);
    //    [OperationContract]
    //    CaseChargeSentenceReply GetSentence(AsmRole asmRole, CaseIdentifierType identifierType, string identifier, int chargeSequence);
    //    [OperationContract]
    //    CaseWritOfArrestReply GetWritOfArrest(AsmRole asmRole, CaseIdentifierType identifierType, string identifier);
    //    [OperationContract]
    //    SubmitVorRequestReply SubmitVorRequest(AsmRole asmRole, CaseIdentifierType identifierType, string identifier, string filingId, string documentId, string emailAddress);
    //}

    //[ServiceContractAttribute]
    //public interface ICCISPullService
    //{
    //    [OperationContract]
    //    CCISAttorneyResult PullCCISAttorney(string ucn, int caseViewUserRole);
    //    [OperationContract]
    //    CCISCaseResult PullCCISCase(string ucn, int caseViewUserRole);
    //    [OperationContract]
    //    CCISChargeResult PullCCISCharge(string ucn, string chargeSequenceNumber, int caseViewUserRole);
    //    [OperationContract]
    //    CCISCourtEventResult PullCCISCourtEvent(string ucn, int caseViewUserRole);
    //    [OperationContract]
    //    CCISCourtEventMapResult PullCCISCourtEventMap(int caseViewUserRole);
    //    [OperationContract]
    //    CCISCaseProgressDocketResult PullCCISDocket(string ucn, int noOfRecordsPerPage, int startPageNumber, int caseViewUserRole);
    //    [OperationContract]
    //    CCISDocketMapResult PullCCISDocketMap(int caseViewUserRole);
    //    [OperationContract]
    //    CCISFilingResult PullCCISFiling(string ucn, int caseViewUserRole);
    //    [OperationContract]
    //    CCISFinancialSummaryResult PullCCISFinancialSummary(string ucn, int caseViewUserRole);
    //    [OperationContract]
    //    CCISJudgeMapResult PullCCISJudgeMap(int caseViewUserRole);
    //    [OperationContract]
    //    CCISJudgeHistoryResult PullCCISJudgeHistory(string ucn, int caseViewUserRole);
    //    [OperationContract]
    //    CCISOBTSResult PullCCISOBTS(string ucn, int caseViewUserRole);
    //    [OperationContract]
    //    CCISParcelResult PullCCISParcel(string ucn, int caseViewUserRole);
    //    [OperationContract]
    //    CCISPartyResult PullCCISParty(string ucn, int caseViewUserRole);
    //    [OperationContract]
    //    CCISPartyTypeResult PullCCISPartyType(string ucn, int caseViewUserRole);
    //    [OperationContract]
    //    CCISReopenResult PullCCISReopen(string ucn, int caseViewUserRole);
    //    [OperationContract]
    //    CCISSentenceResult PullCCISSentence(string ucn, string chargeSequenceNumber, int caseViewUserRole);
    //    [OperationContract]
    //    CCISWarrantSummonsCapiasResult PullCCISWarrantSummonsCapias(string ucn, int caseViewUserRole);
    //    [OperationContract]
    //    byte[] PullDocketImage(string ucn, string documentID, int pageNumber, string includeAnnotations, int caseViewUserRole);
    //}


}
