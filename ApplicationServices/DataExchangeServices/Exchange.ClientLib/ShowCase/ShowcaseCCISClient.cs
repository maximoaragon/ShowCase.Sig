using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using Exchange.Contracts.Showcase.CCIS;
//using Clerk.CaseManagement.CCIS.Contracts;
//using Clerk.CaseManagement.CCIS.Contracts.Model.Reply;

namespace Exchange.ClientLib
{
    public class ShowcaseCCISPushClient : ClientBase<IShowcaseCCISPushInterface>, IShowcaseCCISPushInterface
    {
        public Dictionary<string, string> PushCCIS(int DataExchangeTransactionLogID = 0, int CaseID = 0, DateTime dtFromDate = default(DateTime), DateTime dtToDate = default(DateTime))
        {
            return base.Channel.PushCCIS(DataExchangeTransactionLogID, CaseID, dtFromDate, dtToDate);
        }

        public System.Threading.Tasks.Task<Dictionary<string, string>> PushCCISAsync(int DataExchangeTransactionLogID = 0, int CaseID = 0, DateTime dtFromDate = default(DateTime), DateTime dtToDate = default(DateTime))
        {
            throw new NotImplementedException();
            //return base.Channel.PushCCISDue(CaseID);
        }

    }

    //public class CCIS3GetServiceClient : ClientBase<ICcisGetService>, ICcisGetService
    //{

    //    public CaseSearchReply ExecuteCaseSearch(AsmRole asmRole, string replyToUrl, int maxResult, Clerk.CaseManagement.CCIS.Contracts.Model.SearchCriteria.CcisCaseSearchCriteria searchCriteria)
    //    {
    //        return base.Channel.ExecuteCaseSearch(asmRole, replyToUrl, maxResult, searchCriteria);
    //    }

    //    public CourtEventSearchReply ExecuteCourtEventSearch(AsmRole asmRole, Clerk.CaseManagement.CCIS.Contracts.Model.SearchCriteria.CcisCourtEventCriteria searchCriteria)
    //    {
    //        return base.Channel.ExecuteCourtEventSearch(asmRole, searchCriteria);
    //    }

    //    public DocumentKeywordSearchReply ExecuteDocumentKeywordSearch(AsmRole asmRole, Clerk.CaseManagement.CCIS.Contracts.Model.SearchCriteria.CcisDocumentKeywordSearchCriteria criteria)
    //    {
    //        return base.Channel.ExecuteDocumentKeywordSearch(asmRole, criteria);
    //    }

    //    public FlexQueryReply ExecuteFlexQuery(string replyToUrl, string credential, string queryId, Clerk.CaseManagement.CCIS.Contracts.Model.SearchCriteria.CcisFleaQueryCriteriaList criteria)
    //    {
    //        return base.Channel.ExecuteFlexQuery(replyToUrl, credential, queryId, criteria);
    //    }

    //    public CaseAssessmentReply GetAssessments(AsmRole asmRole, CaseIdentifierType identifierType, string identifier)
    //    {
    //        return base.Channel.GetAssessments(asmRole, identifierType, identifier);
    //    }

    //    public CaseBondReply GetBonds(AsmRole asmRole, CaseIdentifierType identifierType, string identifier)
    //    {
    //        return base.Channel.GetBonds(asmRole, identifierType, identifier);
    //    }

    //    public CaseBookingReply GetBookings(AsmRole asmRole, CaseIdentifierType identifierType, string identifier)
    //    {
    //        return base.Channel.GetBookings(asmRole, identifierType, identifier);
    //    }

    //    public CaseMasterReply GetCase(AsmRole asmRole, CaseIdentifierType identifierType, string identifier)
    //    {
    //        return base.Channel.GetCase(asmRole, identifierType, identifier);
    //    }

    //    public CaseChargeReply GetCharge(AsmRole asmRole, CaseIdentifierType identifierType, string identifier)
    //    {
    //        return base.Channel.GetCharge(asmRole, identifierType, identifier);
    //    }

    //    public CaseChargeCitationReply GetCitation(AsmRole asmRole, CaseIdentifierType identifierType, string identifier, int chargeSequence)
    //    {
    //        return base.Channel.GetCitation(asmRole, identifierType, identifier, chargeSequence);
    //    }

    //    public CodeRecordReply GetCodeTable(CodeRecordType codeRecordType)
    //    {
    //        return base.Channel.GetCodeTable(codeRecordType);
    //    }

    //    public CaseCourtEventReply GetCourtEvents(AsmRole asmRole, CaseIdentifierType identifierType, string identifier)
    //    {
    //        return base.Channel.GetCourtEvents(asmRole, identifierType, identifier);
    //    }

    //    public CaseDivisionAssignmentReply GetDivisionAssignment(AsmRole asmRole, CaseIdentifierType identifierType, string identifier)
    //    {
    //        return base.Channel.GetDivisionAssignment(asmRole, identifierType, identifier);
    //    }

    //    public CaseFilingReply GetFiling(AsmRole asmRole, string filingId)
    //    {
    //        return base.Channel.GetFiling(asmRole, filingId);
    //    }

    //    public ElectronicDocumentReply GetFilingDocument(AsmRole asmRole, CaseIdentifierType identifierType, string identifier, string filingId, string pageNumber, string documentId, string redact)
    //    {
    //        return base.Channel.GetFilingDocument(asmRole, identifierType, identifier, filingId, pageNumber, documentId, redact);
    //    }

    //    public CaseFilingReply GetFilings(AsmRole asmRole, CaseIdentifierType identifierType, string identifier, int filingsPerPage, int pageNumber)
    //    {
    //        return base.Channel.GetFilings(asmRole, identifierType, identifier, filingsPerPage, pageNumber);
    //    }

    //    public CaseJudgeAssignmentReply GetJudgeAssignment(AsmRole asmRole, CaseIdentifierType identifierType, string identifier)
    //    {
    //        return base.Channel.GetJudgeAssignment(asmRole, identifierType, identifier);
    //    }

    //    public ElectronicDocumentReply GetNoteDocument(AsmRole asmRole, CaseIdentifierType identifierType, string identifier, string noteId, string pageNumber, string documentId, string redact)
    //    {
    //        return base.Channel.GetNoteDocument(asmRole, identifierType, identifier, noteId, pageNumber, documentId, redact);
    //    }

    //    public CaseNoteReply GetNotes(AsmRole asmRole, CaseIdentifierType identifierType, string identifier)
    //    {
    //        return base.Channel.GetNotes(asmRole, identifierType, identifier);
    //    }

    //    public CaseParcelReply GetParcels(AsmRole asmRole, CaseIdentifierType identifierType, string identifier)
    //    {
    //        return base.Channel.GetParcels(asmRole, identifierType, identifier);
    //    }

    //    public CasePartyReply GetParties(AsmRole asmRole, CaseIdentifierType identifierType, string identifier, bool returnAddressInfo, bool returnEmailInfo, bool returnPhoneInfo, bool returnMugshots, PartyRepresentationOptionType representationOption)
    //    {
    //        return base.Channel.GetParties(asmRole, identifierType, identifier, returnAddressInfo, returnEmailInfo, returnPhoneInfo, returnMugshots, representationOption);
    //    }

    //    public CasePartyReply GetParty(AsmRole asmRole, string partyTrackingId, bool returnAddressInfo, bool returnEmailInfo, bool returnPhoneInfo, bool returnMugshots, PartyRepresentationOptionType representationOption)
    //    {
    //        return base.Channel.GetParty(asmRole, partyTrackingId, returnAddressInfo, returnEmailInfo, returnPhoneInfo, returnMugshots, representationOption);
    //    }

    //    public MugshotImageReply GetPartyMugshotImage(AsmRole asmRole, string partyTrackingId, string mugshotId)
    //    {
    //        return base.Channel.GetPartyMugshotImage(asmRole, partyTrackingId, mugshotId);
    //    }

    //    public CasePaymentReply GetPayments(AsmRole asmRole, CaseIdentifierType identifierType, string identifier)
    //    {
    //        return base.Channel.GetPayments(asmRole, identifierType, identifier);
    //    }

    //    public CaseReopenReply GetReopens(AsmRole asmRole, CaseIdentifierType identifierType, string identifier)
    //    {
    //        return base.Channel.GetReopens(asmRole, identifierType, identifier);
    //    }

    //    public RepresentationReply GetRepresentation(RepresentationIdentifierType identifierType, string identifier)
    //    {
    //        return base.Channel.GetRepresentation(identifierType, identifier);
    //    }

    //    public CaseChargeSentenceReply GetSentence(AsmRole asmRole, CaseIdentifierType identifierType, string identifier, int chargeSequence)
    //    {
    //        return base.Channel.GetSentence(asmRole, identifierType, identifier, chargeSequence);
    //    }

    //    public CaseWritOfArrestReply GetWritOfArrest(AsmRole asmRole, CaseIdentifierType identifierType, string identifier)
    //    {
    //        return base.Channel.GetWritOfArrest(asmRole, identifierType, identifier);
    //    }

    //    public SubmitVorRequestReply SubmitVorRequest(AsmRole asmRole, CaseIdentifierType identifierType, string identifier, string filingId, string documentId, string emailAddress)
    //    {
    //        return base.Channel.SubmitVorRequest(asmRole, identifierType, identifier, filingId, documentId, emailAddress);
    //    }
    //}

    public class CCISPullServiceClient : ClientBase<ICCISPullService>, ICCISPullService
    {

        public CCISAttorneyResult PullCCISAttorney(string ucn, int caseViewUserRole)
        {
            return base.Channel.PullCCISAttorney(ucn, caseViewUserRole);
        }

        public CCISCaseResult PullCCISCase(string ucn, int caseViewUserRole)
        {
            return base.Channel.PullCCISCase(ucn, caseViewUserRole);
        }

        public CCISChargeResult PullCCISCharge(string ucn, string chargeSequenceNumber, int caseViewUserRole)
        {
            return base.Channel.PullCCISCharge(ucn, chargeSequenceNumber, caseViewUserRole);
        }

        public CCISCourtEventResult PullCCISCourtEvent(string ucn, int caseViewUserRole)
        {
            return base.Channel.PullCCISCourtEvent(ucn, caseViewUserRole);
        }

        public CCISCourtEventMapResult PullCCISCourtEventMap(int caseViewUserRole)
        {
            return base.Channel.PullCCISCourtEventMap(caseViewUserRole);
        }

        public CCISCaseProgressDocketResult PullCCISDocket(string ucn, int noOfRecordsPerPage, int startPageNumber, int caseViewUserRole)
        {
            return base.Channel.PullCCISDocket(ucn, noOfRecordsPerPage, startPageNumber, caseViewUserRole);
        }

        public CCISDocketMapResult PullCCISDocketMap(int caseViewUserRole)
        {
            return base.Channel.PullCCISDocketMap(caseViewUserRole);
        }

        public CCISFilingResult PullCCISFiling(string ucn, int caseViewUserRole)
        {
            return base.Channel.PullCCISFiling(ucn, caseViewUserRole);
        }

        public CCISFinancialSummaryResult PullCCISFinancialSummary(string ucn, int caseViewUserRole)
        {
            return base.Channel.PullCCISFinancialSummary(ucn, caseViewUserRole);
        }

        public CCISJudgeMapResult PullCCISJudgeMap(int caseViewUserRole)
        {
            return base.Channel.PullCCISJudgeMap(caseViewUserRole);
        }

        public CCISJudgeHistoryResult PullCCISJudgeHistory(string ucn, int caseViewUserRole)
        {
            return base.Channel.PullCCISJudgeHistory(ucn, caseViewUserRole);
        }

        public CCISOBTSResult PullCCISOBTS(string ucn, int caseViewUserRole)
        {
            return base.Channel.PullCCISOBTS(ucn, caseViewUserRole);
        }

        public CCISParcelResult PullCCISParcel(string ucn, int caseViewUserRole)
        {
            return base.Channel.PullCCISParcel(ucn, caseViewUserRole);
        }

        public CCISPartyResult PullCCISParty(string ucn, int caseViewUserRole)
        {
            return base.Channel.PullCCISParty(ucn, caseViewUserRole);
        }

        public CCISPartyTypeResult PullCCISPartyType(string ucn, int caseViewUserRole)
        {
            return base.Channel.PullCCISPartyType(ucn, caseViewUserRole);
        }

        public CCISReopenResult PullCCISReopen(string ucn, int caseViewUserRole)
        {
            return base.Channel.PullCCISReopen(ucn, caseViewUserRole);
        }

        public CCISSentenceResult PullCCISSentence(string ucn, string chargeSequenceNumber, int caseViewUserRole)
        {
            return base.Channel.PullCCISSentence(ucn, chargeSequenceNumber, caseViewUserRole);
        }

        public CCISWarrantSummonsCapiasResult PullCCISWarrantSummonsCapias(string ucn, int caseViewUserRole)
        {
            return base.Channel.PullCCISWarrantSummonsCapias(ucn, caseViewUserRole);
        }

        public byte[] PullDocketImage(string ucn, string documentID, int pageNumber, string includeAnnotations, int caseViewUserRole)
        {
            return base.Channel.PullDocketImage(ucn, documentID, pageNumber, includeAnnotations, caseViewUserRole);
        }

        public CCISDocketImageResult PullDocketImageWithType(string ucn, string documentID, int pageNumber, string includeAnnotations, int caseViewUserRole)
        {
            return base.Channel.PullDocketImageWithType(ucn, documentID, pageNumber, includeAnnotations, caseViewUserRole);
        }

    }
}
