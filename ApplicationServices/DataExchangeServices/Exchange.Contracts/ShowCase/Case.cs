using System;
using System.Runtime.Serialization;

namespace Exchange.Contracts.ShowCase
{
    [DataContract]
    public class Case 
    {
        [DataMember]
        public int CaseID { get; set; }
        [DataMember]
        public string CaseNumber { get; set; }
        [DataMember]
        public string UCN { get; set; }
        [DataMember]
        public string CourtTypeDescription { get; set; }
        [DataMember]
        public DateTime? FileDate { get; set; }
        [DataMember]
        public string JudgeName { get; set; }
        [DataMember]
        public DateTime? CreateDate { get; set; }
        [DataMember]
        public string SANumber { get; set; }
        [DataMember]
        public int? Counts { get; set; }
        [DataMember]
        public DateTime? OffenseDate { get; set; }
        [DataMember]
        public int? CaseStatusID { get; set; }
        [DataMember]
        public decimal? LegalPetition { get; set; }
        [DataMember]
        public DateTime? LegalPetitionDate { get; set; }
        [DataMember]
        public string SupplementalPetition { get; set; }
        [DataMember]
        public DateTime? SupplementalPetitionDate { get; set; }
        [DataMember]
        public Agency Agency { get; set; }
        //(SELECT AgencyName, ORI FROM tblAgency WHERE AgencyID = c.AgencyID FOR XML PATH ('Agency'), TYPE)     
        [DataMember]
        public Attorney AssistantStateAttorney { get; set; }
        //(SELECT AttorneyName, BarNumber FROM tblAttorney WHERE AttorneyID = c.AsstStateAttorneyID FOR XML PATH ('AssistantStateAttorney'), TYPE)
        [DataMember]
        public Attorney AssistantPublicDefender { get; set; }
        //(SELECT AttorneyName, BarNumber FROM tblAttorney WHERE AttorneyID = c.AsstPublicDefenderID FOR XML PATH ('AssistantPublicDefender'), TYPE)
        [DataMember]
        public Attorney AttorneyForDefense { get; set; }
        //(SELECT AttorneyName, BarNumber FROM tblAttorney WHERE AttorneyID = c.AttyForDefenseID FOR XML PATH ('AttorneyForDefense'), TYPE)
        [DataMember]
        public decimal? WaiverOfRightToCounsel { get; set; }
        [DataMember]
        public decimal? JuryTrial { get; set; }
        [DataMember]
        public DateTime? TrialDate { get; set; }
        [DataMember]
        public decimal? DisposedBeforeTrial { get; set; }
        [DataMember]
        public DateTime? ReopenDate { get; set; }
        [DataMember]
        public string DivisionName { get; set; }
        [DataMember]
        public DateTime? DateBooked { get; set; }
        [DataMember]
        public DateTime? ArrestDate { get; set; }
        [DataMember]
        public string ReopenReason { get; set; }
        [DataMember]
        public DateTime? ReopenCloseDate { get; set; }
        [DataMember]
        public DateTime? AppealDate { get; set; }
        [DataMember]
        public string Disposition { get; set; }
        [DataMember]
        public DateTime? DispositionDate { get; set; }
        [DataMember]
        public decimal? Contested { get; set; }
        [DataMember]
        public string JudgeAtDisposition { get; set; }
        //(SELECT JudgeName FROM tblJudge WHERE JudgeID = c.JudgeID) AS JudgeAtDisposition
        [DataMember]
        public int? CasePhase { get; set; }
        [DataMember]
        public string NameAtArrest { get; set; }
        [DataMember]
        public string IncidentNumber { get; set; }
        [DataMember]
        public string NameCheck { get; set; }
        [DataMember]
        public int? VOPCount { get; set; }
        [DataMember]
        public decimal? CourtAptAtty { get; set; }
        [DataMember]
        public int? TrialType { get; set; }
        [DataMember]
        public DateTime? DateAffPrinted { get; set; }
        [DataMember]
        public string CallCenterNumber { get; set; }
        [DataMember]
        public string Authority { get; set; }
        [DataMember]
        public Attorney AttorneyForDefense2 { get; set; }
        //(SELECT AttorneyName, BarNumber FROM tblAttorney WHERE AttorneyID = c.AttyForDefenseID2 FOR XML PATH ('AttorneyForDefense2'), TYPE)
        [DataMember]
        public Attorney AssistantStateAttorney2 { get; set; }
        //(SELECT AttorneyName, BarNumber FROM tblAttorney WHERE AttorneyID = c.AsstStateAttorneyID2 FOR XML PATH ('AssistantStateAttorney2'), TYPE)
        [DataMember]
        public decimal? FingerPrintsTaken { get; set; }
        [DataMember]
        public decimal? Adoption { get; set; }
        [DataMember]
        public int? NumberOfDefendants { get; set; }
        [DataMember]
        public decimal? Indigent { get; set; }
        [DataMember]
        public decimal? Destroyed { get; set; }
        [DataMember]
        public DateTime? DestroyedDate { get; set; }
        [DataMember]
        public decimal? Witness { get; set; }
        [DataMember]
        public string EstateValue { get; set; }
        [DataMember]
        public int? AgeAtFiling { get; set; }
        [DataMember]
        public decimal? Incompetent { get; set; }
        [DataMember]
        public DateTime? CapiasIssuedDate { get; set; }
        [DataMember]
        public string LegacyCaseNumber { get; set; }
        [DataMember]
        public decimal? Abortion { get; set; }
        [DataMember]
        public int? ContinuanceRequestState { get; set; }
        [DataMember]
        public int? ContinuanceRequestDefense { get; set; }
        [DataMember]
        public int? ContinuanceRequestCourt { get; set; }
        [DataMember]
        public int? ContinuanceRequestStipulation { get; set; }
        [DataMember]
        public string BookingSheetNumber { get; set; }
        [DataMember]
        public string DCNumber { get; set; }
        [DataMember]
        public string VehicleMake { get; set; }
        [DataMember]
        public string VehicleStyle { get; set; }
        [DataMember]
        public string VehicleColor { get; set; }
        [DataMember]
        public string VehicleTagNumber { get; set; }
        [DataMember]
        public string VehicleTagState { get; set; }
        [DataMember]
        public string YearTagExpires { get; set; }
        [DataMember]
        public int? VehicleYear { get; set; }
        [DataMember]
        public string OBTSNumber { get; set; }
        [DataMember]
        public string GeographicIndicator { get; set; }
        [DataMember]
        public string CrimeLocation { get; set; }
        [DataMember]
        public Officer Officer { get; set; }
        //(SELECT (LastName + ', ' + FirstName + ' ' + MiddleName) AS OfficerName, BadgeNumber FROM tblOfficer WHERE OfficerID = c.OfficerID FOR XML PATH ('Officer'), TYPE)
        [DataMember]
        public string CollectionAgencyName { get; set; }
        //(SELECT CollectionAgencyName FROM tblCollectionAgency WHERE CollectionAgencyID = c.CollectionAgencyID FOR XML PATH, TYPE) AS CollectionAgencyName
        [DataMember]
        public DateTime? SpeedyTrialDueDate { get; set; }
        [DataMember]
        public DateTime? SpeedyTrialDemandDate { get; set; }
        [DataMember]
        public DateTime? SpeedyTrialWaivedDate { get; set; }
    }
}
