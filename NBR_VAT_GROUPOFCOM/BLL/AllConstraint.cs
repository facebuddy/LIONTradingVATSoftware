using System;
namespace NBR_VAT_GROUPOFCOM.BLL
{
    public class AllConstraint
    {
        public const short categoryLevel = 1;

        public const short subCategoryLevel = 2;

        public const short CDTaxId = 1;

        public const short RDTaxId = 2;

        public const short SDTaxId = 3;

        public const short VATTaxId = 4;

        public const short AITTaxId = 5;

        public const short ATVTaxId = 6;

        public const short TTITaxId = 7;

        public const double TRIAL_PERIOD = 10;

        public const string secretKey = "TCLMNOPQRSTUVWXYZ";

        public const string ACTIVATE_URL = "activate";

        public const string DEMO_EXTEND = "extenddemoperiod";

        public const string SERVICE_PACK_UPDATE = "updateservicepack";

        public const string APP_NAME = "NBR_VAT";

        public const string licenseExpire = "Your License Has been Expired.";

        public const string userLimitExceed = "User Limit Exceed ";

        public const string needInternetConnection = "You Need Internet Connection For further Process";

        public const string connectionCheckSite = "google.com";

        public const string stradjustMessage = "amount had already adjusted.";

        public const string strSaveSuccessMessage = "Successfully Saved.";

        public const string straveSuccessMessage = " Save Successfully.";

        public const string strSaveFailMessage = "Failed to save.";

        public const string strUpdateSuccesMessage = "Successfully Updated.";

        public const string strUdpateFailMessage = "Fail to Update.";

        public const string strCommonValidationMessage = " is mandatory. ";

        public const string strDeleteSuccess = "Successfully Deleted.";

        public const string strDeleteFail = "Fail to delete.";

        public const string strNoRecordMsg = "No Record Found.";

        public const string strNumericValueMsg = "Please insert numeric value.";

        public const string invalidExportMsg = "No data found to export";

        public const string strNoRecord = "Please Add Item first..";

        public const string saveSuccessMessage = "saved successfully.";

        public const string isExist = "Same combination of data already exist(item,tax value,Effective Date)";

        public const string strSaveSuccessMessageExtend = "Successfully added. Please add Bank Information & Owner Information. ";

        public const string mendatoryMsg = " is mandatory. ";

        public const string nonAccessPageMsg = "You are not authorized for this page.";

        public const string errorMessage = "Some error has occured.";

        public const string selectUser = "Please select a user first..";

        public const string strCustomerName = "Customer Name";

        public const string directoryPath = "C:\\SynchronizeDataFiles_";

        public const string zipDirectoryPath = "C:\\SynchronizeData\\";

        public const string filePassword = "142536";

        public const short designationFamId = 5;

        public const short userLevelAdminId = 1;

        public const string lastUpdateDate = "021012";

        public const string SSFPAgreementStartDate = "01/10/2007";

        public const short MCodeTypeForCodeName = 1;

        public const short MCodeTypeForCodeValue = 2;

        public const short MCodeTypeForCodeValue1stAnd2nd = 3;

        public const short MCodeTypeForCodeDates = 4;

        public const short MCodeTypeForCodeWithParent = 5;

        public const short MCodeTypeForCodeValuesAndDates = 6;

        public static int userLevelMasterId;

        public static int costCenterMasterId;

        public static int measurementTypeMasterId;

        public static int PropertyTypeM;

        public static int PropertyTypeD_Design;

        public static int PropertyTypeD_Stick;

        public static int PropertyTypeD_Packet_Type;

        public static int PropertyTypeD_Bandroll;

        static AllConstraint()
        {
            AllConstraint.userLevelMasterId = 2;
            AllConstraint.costCenterMasterId = 3;
            AllConstraint.measurementTypeMasterId = 4;
            AllConstraint.PropertyTypeM = 5;
            AllConstraint.PropertyTypeD_Design = 7;
            AllConstraint.PropertyTypeD_Stick = 8;
            AllConstraint.PropertyTypeD_Packet_Type = 9;
            AllConstraint.PropertyTypeD_Bandroll = 10;
        }

        public AllConstraint()
        {
        }

        public enum enmServiceSpotType
        {
            AssistantServicePromotor = 65,
            ServicePoint = 80,
            SatelliteTeam = 84
        }

        public enum userActionType
        {
            Create,
            Update,
            Delete,
            Search
        }
    }
}
