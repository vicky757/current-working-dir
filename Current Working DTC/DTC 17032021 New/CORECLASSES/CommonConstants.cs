using System;
using System.Runtime.InteropServices;
using System.Collections;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Globalization;

namespace ClassList
{
    #region Public Enum


   
    //Punit sept '08
    /// <summary>
    /// Contains the information about the special ranges plc. These plc contains two tag value ranges.
    /// </summary>
    public enum SpecialRangePLC
    {
        Allen_Bradley_DF1_Compactlogix = 178,
        Allen_Bradley_DF1 = 27,
        Allen_Bradley_DH485 = 7
        //Allen_Bradley_DF1_Micrologix = 250,
        //Siemens_S7_300_Series_PLCs = 77
    }

    /// <summary>
    /// Used to Show/Hide System Tags.
    /// </summary>
    public enum ShowHideSystemTag
    {
        Both,
        SystemOnly,
        UserDefinedOnly,
        None
    }


    /// <summary>
    /// 
    /// </summary>
    public enum HMILadderType
    {
        HMI,
        Ladder,
        HMI_Ladder
    }

    public enum IECBlockType
    {
        LD,
        FBD,
        ST,
        IL,//IEC_IL_Sammed
        SFC,//SFC_change  
        SFC_CHILD
    }

    /// <summary>
    /// 
    /// </summary>
    public enum DeleteScreenMessage
    {
        UsedInPowerOnTask,
        UsedInGotoScreenTask,
        UsedInAssociatedScreen,
        DataEntryObjectAssigned,
        None
    }
    /// <summary>
    /// 
    /// </summary>
    public enum DeleteTagMessage
    {
        UsedTag,
        SystemTag,
        UsedInDataLogger,
        UsedInLadder,
        UsedInAlarm,
        UsedInDataWindow,//Sammed
        UsedInSerialDriver,//SS_UniversalDriverIECEnable
        None,
        UsedInDataLoggerExternal, //Data_Logging_Modification Vijay
        UsedInFTP,   //SS_FTP
        UsedInNode, //SS_ReconnectCntrl
        UsedInTimerElement, //Ashok Timer Element
        UsedInRecipe, //Recipe_usage
        UsedInDataLoggerQT //DataLogging_QT_Vijay										 
    }

    /// <summary>
    /// 
    /// </summary>
    public enum OverlappingMessage
    {
        NotAllowedOverlappingObjects,
        Group,
        None
    }
    /// <summary>
    /// 
    /// </summary>
    public enum MesgBoxIcon
    {
        Error = 0,
        Warning,
        Information,
        Question,
        None
    }

    //umesh  6th july
    /// <summary>
    /// The enum will be used to show global block errors while adding new block.
    /// </summary>
    public enum GlobalBlockError
    {
        NodePresentBlockAbsent,
        NodePresentBlockPresent,
        None
    }
    //Ashok USB
    public enum DownloadingStatusMessagesQT
    {
        strPrizmNotConnected
    }
    /// <summary>
    /// The enum is used to raise errors through core classes such as
    /// Node address already present, Node name already present, Invalidprocol - if
    /// different protocol is assigned to existing protocol com port e.g. if com1 has 
    /// GE protocol then only GE Protocols different models can be added on same port,  
    /// other protocol can not be assigned.
    /// </summary>
    public enum AddNode
    {
        NodeAddressPresent,
        NodeAddressPresentOnCom1,
        NodeAddressPresentOnCom2,
        NodeAddressPresentOnCom3,
        NodeNamePresent,
        InvalidProtocol,
        MultiNodeNotValid,
        NodeLimitExceed,
        MultiNodeNotValidForPrduct, //Sanjay_02.05.13
        None
    }
    /// <summary>
    /// 
    /// </summary>
    public enum AddAlarmTag
    {
        TagAlreadyAssigned,
        AlarmPresnt,
        GroupPresent,
        None
    }
    public enum UploadButtonStatusGoOnline
    {
        onlineWithoutUpload = 1,
        onlineWithDownload,
        onlineWithUpload
    }
    //Ashok Status
    public enum DownloadingStatusMessagesForQT
    {
        strUploading,
        strDownloading,
        strReady,
        strProductMismatch,
        strCRCMismatch,
        strPrizmNotReady,
        strPrizmNotResponding,
        strCommunicationTimeout,
        strProjectCompiling,
        strProjectSaving,
        strDownloadComplete,
        strUploadComplete,
        strCommunicationAborted,
        strApplicationNotPresent,
        strDeviceIsNotConnected,
        strRestartDevice,
        strConnectingtoPrizm,
        strVersionUpdateAvilable,
        strUploadingApplication,
        strUploadingLoggedData,
        strUploadingHistoricalAlarmData,
        strLoggedDataNotPresent,
        strHistoricalDataNotPresent,
        strVerifyingPassword,//SD_EnblePSWForUpload
        strPasswordMismatch//SD_EnblePSWForUpload  
    }
    /// <summary>
    /// 
    /// </summary>
    public enum DownloadingStatusMessages
    {
        strConnectingtoPrizm,
        strSearchingPrizm,

        strUploading,
        strDownloading,
        strReady,
        strProductMismatch,
        strCRCMismatch,
        strPrizmNotReady,
        strPrizmNotResponding,
        strCommunicationTimeout,
        strReconnectUnitProperly,
        strProductNotSupported,
        strErrorFirmwareFileCreation,
        strErrorApplicationFileCreation,
        strPortIsBusyOrUnavailable,
        strProjectCompiling,
        strProjectSaving,
        strDownloadComplete,
        strUploadComplete,
        strCommunicationAborted,
        strModeMismatch, //FP_CODE  R12  Haresh// Location changed
        strErrorModeMismatch,
        strExpansionMismatch,
        strDataLogNotSupported,
        strHisAlarmNotSupported,
        strApplicationNotPresent,
        strPLCNotSupportedToMPLC,
        strWaitDeviceIsInitializing,//Issue 333 SP 9.10.12
        strHisAlarmAndLoggedDataNotSupported,//issue_939_FL100_sammed
        strBootBlock1,
        strVerifyingPassword,//SD_EnblePSWForUpload
        strPasswordMismatch,//SD_EnblePSWForUpload
        strCheckingDeviceInformation, //AN_CheckingDeviceInfo 		   
        strApplication = 256,
        strFirmware = 256 << 1,
        strLadder = 256 << 2,
        strFont = 256 << 3,
        strLoggedData = 256 << 4,
        strHistAlarmData = 256 << 5, //manik
        strExpansionFirmware = 256 << 6, //Pravin
        #region FP_Ethernet_Implementation-AMIT
        strDownloadEthernetSettings = 256 << 7,
        #endregion
        strBootBlock = 256 << 8
    }


    /// <summary>
    /// 
    /// </summary>
    public enum RectBorderStyle
    {
        None = Border3DStyle.Adjust,
        Bump = Border3DStyle.Bump,
        Etched = Border3DStyle.Etched,
        Flat = Border3DStyle.Flat,
        Raised = Border3DStyle.Raised,
        Sunken = Border3DStyle.Sunken,
        Frame
    }
    #region SS_Totalizer
    public enum TotalizerFlowType
    {
        Mass_Flow_Meter = 0
    }
    public struct stTotalizerInfo  //SS_Totalizer
    {
        public bool isDefined;
        public int flowType;
        public int flowTagID;
        public int flowEnggUnitTagID;
        public int flowTimeUnitTagID;

        public int totTagID;
        public int totEnggUnitTagID;
        public int totEnableTagID;
        public int totCLearTagID;

        public bool isPulseDefined;
        public int pulsePertotUnitTagID;
        public int pulseOutputBitTagID;
        public int pulseDurationTagID;
        public int pulseEnggUnitTagID;
    }
    #endregion

    #region SG_BluetoothConfiguration
    public struct stBluetoothConfig
    {
        public bool isDefined;
        public int BtPairStatTgId;
        public int StartStopSpreyTgId;
        public int PauseResumeSpreyTgId;
        public int LED1TgId;
        public int LED2TgId;
        public int LED3TgId;
        public int LED4TgId;
        public int DeviceIdTgId;
        public int APNTgId;
        public int ServerIPAddrTgId;
        public int UserNameTgId;
        public int PasswordTgId;
        public int PortNoTgId;
        public int FarmerNameTgId;
        public int FarmerNoTgId;
        public int BookingIdTgId;
        public int AcresTgId;
        public int CropIdTgId;
        public int OperatorNoTgId;
        public int BatteryVoltageTgId;
        public int EngineTempTgId;
        public int FuelLevelTgId;
        public int OilPressureTgId;
        public int HMR_hhTgId;
        public int BLEResetTgId;
        public int RPMTgId;
        public int AIReserved1TgId;
        public int AIReserved2TgId;
        public int MaintenanceDueTgId;
        public int LowBatteryTgId;
        public int LowFuelLevelTgId;
        public int OverspeedTgId;
        public int UnderspeedTgId;
        public int LowPressureTgId;
        public int StartFailTgId;
        public int StopFailTgId;
        public int FlowSensor1TgId;
        public int FlowSensor2TgId;
        public int FlowSensor3TgId;
        public int SpeedTgId;
        public int EngineTempStatusTgId;
        public int FotaTgId;
        public int SprinklerTgId;
        public int EngineStartTgId;
        public int EngineStopTgId;
        public int DIReserved2TgId;
        public int DoubleStopTgId;
        public int UpgradeAvailableTgId;
        public int SignalStrengthTgId;
        public int BLEMACIdTgId;
        public int FirmwareUpgradeTgId;
        public int FotaServerIPTgId;
        public int FotaServerPortNoTgId;
        public int FotaDestinationPathTgId;
        public int FotaUserNameTgId;
        public int FotaPasswordTgId;
        public int LatitudeTgId;
        public int LongitudeTgId;
    }
    #endregion

    /// <summary>
    /// 
    /// </summary>
    public enum FrameAlignment
    {
        TopLeft_BottomRight,
        TopRight_BottomLeft
    }
    /// <summary>
    /// 
    /// </summary>
    public enum TaskCodeHighByte
    {
        SetRTC = 9,
        KeysSpecificTasks = 14
    }
    /// <summary>
    /// 
    /// </summary>
    public enum RTCSettings
    {
        IncrementYear = 0,
        IncrementMonth,
        IncrementDate,
        IncrementHour,
        IncrementMinute,
        IncrementSecond,
        IncrementDayOfWeek,
        DecrementYear,
        DecrementMonth,
        DecrementDate,
        DecrementHour,
        DecrementMinute,
        DecrementSecond,
        DecrementDayOfWeek
    }
    /// <summary>
    /// 
    /// </summary>
    public enum RegisterTagOperationType
    {
        EQUAL = 0,
        NOT_EQUAL,
        LESS,
        LESS_THAN_EQUAL,
        GREATER,
        GTEATER_THAN_EQUAL
    }
    /// <summary>
    /// 
    /// </summary>
    public enum CoilTagOperationType
    {
        COIL_ON = 0,
        COIL_OFF

    }
    /// <summary>
    /// 
    /// </summary>
    public enum OperandType
    {
        NUMBER = 0,
        TAG,
        NONE
    }
    /// <summary>
    /// 
    /// </summary>
    public enum FlashSpeed
    {
        SLOW = 0,
        MEDIUM,
        FAST
    }
    /// <summary>
    /// 
    /// </summary>
    public enum ShowWhen
    {
        WITHIN_RANGE_OR_ON = 1,
        OUT_OF_RANGE_OR_OFF
    }
    /// <summary>
    /// 
    /// </summary>
    public enum AsciiValueOfNumbers
    {
        ZERO = 48,
        ONE,
        TWO,
        THREE,
        FOUR,
        FIVE,
        SIX,
        SEVEN,
        EIGHT,
        NINE,
        TEN,
        ELEVEN,
        TWELVE,
        THIRTEEN,
        FOURTEEN,
        FIFTEEN,
        SIXTEEN,
        SEVENTEEN,
        EIGHTEEN,
        NINETEEN,
        TWENTY,
        TWENTYONE,
        TWENTYTWO,
        TWENTYTHREE,
        TWENTYFOUR,
        TWENTYFIVE,
        TWENTYSIX,
        TWENTYSEVEN,
        TWENTYEIGHT,
        TWENTYNINE,
        THIRTY,
        THIRTYONE,
        THIRTYTWO,
        THIRTYTHREE,
        THIRTYFOUR,
        THIRTYFIVE,
        THIRTYSIX,
        THIRTYSEVEN,
        THIRTYEIGHT,
        THIRTYNINE,
        FOURTY
    }
    /// <summary>
    /// 
    /// </summary>
    public enum Numbers
    {
        ZERO,
        ONE,
        TWO,
        THREE,
        FOUR,
        FIVE,
        SIX,
        SEVEN,
        EIGHT,
        NINE,
        TEN,
        ELEVEN,
        TWELVE,
        THIRTEEN,
        FOURTEEN,
        FIFTEEN,
        SIXTEEN,
        SEVENTEEN,
        EIGHTEEN,
        NINETEEN,
        TWENTY,
        TWENTYONE,
        TWENTYTWO,
        TWENTYTHREE,
        TWENTYFOUR,
        TWENTYFIVE,
        TWENTYSIX,
        TWENTYSEVEN,
        TWENTYEIGHT,
        TWENTYNINE,
        THIRTY,
        THIRTYONE,
        THIRTYTWO,
        THIRTYTHREE,
        THIRTYFOUR,
        THIRTYFIVE,
        THIRTYSIX,
        THIRTYSEVEN,
        THIRTYEIGHT,
        THIRTYNINE,
        FOURTY


    }
    /// <summary>
    /// 
    /// </summary>
    public enum BorderType
    {
        NONE = 0,
        SINGLE,
        DOUBLE
    }
    /// <summary>
    /// 
    /// </summary>
    public enum PrizmFont
    {
        FIVExSEVEN = 0,
        TENxFOURTEEN,
        TWENTYxTWENTYFOUR,         // this is for font 20 X 28
        SEVENxFOURTEEN
    }
    /// <summary>
    /// 
    /// </summary>
    public enum NumberType
    {
        UNSIGNED = 0,
        SIGNED,
        HEXADECIMAL,
        BCD,
        BINARY,
        FLOAT,
        ASCII,
        ASCII_NUMERIC,
        SCIENTIFIC_NOTATION, //Exponential data type addition
        Long_FLOAT//Support_LREAL_SY
    }
    #region StratonDataType Change Sanjay
    public enum stratonDataType
    {
        // BOOL=0,
        SINT = 0,
        USINT,
        BYTE,
        INT,
        UINT,
        WORD,
        DINT,
        UDINT,
        DWORD,
        LINT,
        REAL,
        LREAL,
        TIME,
        STRING
    }
    #endregion
    /// <summary>
    /// 
    /// </summary>
    public enum CloseAction
    {
        YES,
        NO,
        NONE
    }
    /// <summary>
    /// 
    /// </summary>
    public enum ProjectSaveInvocation
    {
        SAVE,
        SAVEAS,
        DOWNLOAD,
        SIMULATION,
        PROJECT_CLOSE,
        APPLICATION_CLOSE
    }
    /// <summary>
    /// 
    /// </summary>
    public enum SimulationErrorType
    {
        BATCH_FILE_NOT_PRESENT,
        SIMULATION_FILE_NOT_PRESENT,
        SIMULATION_ALREADY_RUNNING,
        NONE
    }
    /// <summary>
    /// 
    /// </summary>
    public enum DirtyFlagType
    {
        PROJECT,
        USER,
        BOTH,
        NONE
    }
    /// <summary>
    /// 
    /// </summary>

    public enum ErrorType
    {
        TAG_NOT_DEFINED,
        TAG_NAME_NOT_SET,
        SCREEN_NOT_DEFINED,
        POPUP_SCREEN_NOT_DEFINED,
        INVALID_OBJECT_PRESENT,
        OVERLAP_OBJECT,
        NO_SCREEN_PRESENT,
        NO_NOIMAGEBMP_PRESENT,
        NoIMAGEPICTURE_PRESENT,
        NO_USERDEFINETAG_PRESENT,
        UNDEFINEDTAG_PRESENT,
        NO_BASESCREEN_PRESENT,
        NONE,
        LADDER_ERROR_LINE_OPEN, //Ladder_Change_R8
        LADDER_ERROR_BRANCH_OPEN,
        LADDER_ERROR_BRANCH_SHORT,
        LADDER_ERROR_OBJECT_ACROSS_BRANCH,
        LADDER_ERROR_INVALID_OP_INST_LOCATION_,
        LADDER_ERROR_INVALID_IP_INST_LOCATION_,
        LADDER_ERROR_NO_VERTICALLINE, //Ladder_Change_R9
        LADDER_ERROR_INSTRUCTION_IN_ENDINSTRUCTION,
        LADDER_ERROR_INSTRUCTION_IN_RETINSTRUCTION,
        LADDER_ERROR_INVALID_LOCATION_VLINK,
        LADDER_ERROR_OPERAND_NOT_DEFINED,//Ladder_Change_R10
        LADDER_ERROR_INCOMPLETE_FIRST_RUNG_LINE,
        LADDER_ERROR_EMPTY_BLOCK_NAME_CALL, //Ladder_Change_R11
        LADDER_ERROR_NUMBEROFLINES_EXCEEDED_IN_RUNG, //FP_CODE  R12  Haresh
        LADDER_ERROR_INVALID_LOCATION_END,
        LADDER_ERROR_INVALID_LOCATION_RET,
        LADDER_ERROR_INVALID_IO_ADDRESS,//End
        LADDER_ERROR_DUPLICATE_USE_OF_TIMER_ADDRESS,
        LADDER_ERROR_INSTRUCTION_IN_NEXTINSTRUCTION,
        LADDER_ERROR_INSTRUCTION_IN_MCR_INSTRUCTION,
        LADDER_ERROR_INSTRUCTION_IN_JCR_INSTRUCTION,
        LADDER_ERROR_INSTRUCTION_RETURN_IN_OTHER_BLOCK,
        LADDER_ERROR_INSTRUCTION_ENABLE_DISABLE_IN_OTHER_BLOCK,
        LADDER_ERROR_INSTRUCTION_END_IN_SUBROUTINE_BLOCK,
        SCREEN_BS_TASK_BYTES,
        SCREEN_WS_TASK_BYTES,
        SCREEN_AH_TASK_BYTES,
        SCREEN_KEYS_TASK_BYTES,
        LADDER_ERROR_ADDRESS_NOT_SUPPORTED,
        LADDER_ERROR_OPERAND_OVER_RANGE,
        LADDER_ERROR_TABLESIZE_OPERAND_OVER_RANGE,
        LADDER_ERROR_INSTRUCTION_INPUT_HLINK_ERROR,
        ALARM_ERROR_COLUMN_OUTSIDE_SCREEN,
        //Changes AMIT M-05 18-05-2010
        LADDER_ERROR_INVALID_NEXT_INST_LOCATION_,
        //End

        //FP_CODE Pravin Invalid Exp Addr
        LADDER_ERROR_INVALID_EXP_MW_BIT,
        LADDER_ERROR_INVALID_EXP_MW_REGSITER,
        //End

        //Sammed
        LADDER_ERROR_INVALID_NEXT_INST,//Issue_native_659_sammed
        LADDER_ERROR_INVALID_FOR_INST,//Issue_native_659_sammed
        LADDER_ERROR_INVALID_FOR_INST_1,//Issue_native_659_sammed
        LADDER_ERROR_INVALID_FOR_NEXT_INST,//Issue_native_659_sammed
        //End
        LADDER_ERROR_DUPLICATE_USE_OF_COUNTER_ADDRESS, //Issue_928 Vijay
        LADDER_ERROR_SUB_CALL_USED_MAIN, //Call_Inst_Change
        LADDER_ERROR_SUB_CALL_USED_TI,
        //WebServer change
        #region WebServer change
        WEBSCREEN_TAG_COUNT_EXCEED,
        #endregion
        //End
        #region AccessLevel_ScreenProp_SY
        AT_LEAST_ONE_BASESCREEN_HAS_ACCESSLEVEL_VALUE_ZERO,
        #endregion
        TREND_ERROR_NOT_USE_MORE_THAN_FOUR,//Use max 4 trend object for each screen sammedb
        LADDER_ERROR_INVALID_JCS_JCR_INST, //Haresh JCS_JCR_Change
        LADDER_ERROR_INVALID_MCS_MCR_INST,
        SPEEDOMETER_ERROR_INVALID_METER_DRAW,//speedometer_sammedb
        SPEEDOMETER_ERROR_INVALID_ARC_PERCENTAGE_VALUE,//SP_Meter_SB
        EMAIL_EMPTY_TO,//EmailKD
        TAG_NOT_ASSIGNED,//EmailKD
        #region Cursor_Object_Vijay
        CURSOR_ERROR_NOT_USE_MORE_THAN_ONE,
        CURSOR_ERROR_DEFAULT_SIZE_LARGE
        #endregion
    }


    /// <summary>
    /// 
    /// </summary>
    public enum LadderEditorMode
    {
        MODE_OFFLINE,
        MODE_ONLINE,
        MODE_ONLINE_EDIT,
        MODE_DEBUG
    }


    /// <summary>
    /// 
    /// </summary>
    public enum WarningType
    {
        OUTSIDE_SCREEN_BOUNDARY,
        #region RC1_Issue1703
        MAX_OBJECT_ONSCREEN,
        #endregion
        NONE,
        OBJECTNOTIMPORTED, //Import_Screen_AMIT
        TASK_NOT_IMPORTED,
        EMAIL_EMPTY_SUBJECT//EmailKD
    }

    public enum UserType : byte
    {

        APPLICATIONDEVELOPER,
        SYSTEMUSER,
        ADMINISTRATOR
    }

    /// <summary>
    /// 
    /// </summary>
    public enum AdditionalRights : byte
    {
        NORIGHTS,
        CANCONFIGURE,
        CANEXECUTE,
        CANUPLOAD,
        CANDOWNLOAD,
        CANCONFIGURELADDERLOGIC,
        CANCREATENEWPROJECT
    }
    /// <summary>
    /// 
    /// </summary>
    public enum ScreenProperties
    {
        DisplayScreen, PrintScreen, PrintDisplayScreen
    }
    /// <summary>
    /// 
    /// </summary>
    //Ladder_Change
    public enum ScreenType
    {
        Base,
        Popup,
        Ladder,
        Template,
        Factory,
        GSM, //Factory:added by snehal //GWY_900_SanjayY

        //WebServer Change
        #region WebServer Change
        WebScreen
        #endregion
    }
    /// <summary>
    /// 
    /// </summary>
    public enum PlaceEqual
    {
        Horizontal, Vertical
    }
    /// <summary>
    /// 
    /// </summary>
    public enum BoolValues
    {
        NO, YES
    }
    /// <summary>
    /// 
    /// </summary>
    public enum AlignMiddle
    {
        Horizontal,
        Vertical,
        HorizontalwrtShape,
        VerticalwrtShape

    }
    /// <summary>
    /// 
    /// </summary>
    public enum TextAlignment
    {
        Left = 0, Right, Center
    }
    /// <summary>
    /// 
    /// </summary>
    public enum TextObjectBorders
    {
        Single = 1, Double
    }
    /// <summary>
    /// 
    /// </summary>
    public enum MakeEqual
    {
        Height, Width, Size
    }
    /// <summary>
    /// 
    /// </summary>
    public enum ProjectType
    {
        Prizm3, Prizm4, Invalid
    }
    /// <summary>
    /// 
    /// </summary>
    public enum ScreenObjects
    {
        PrizmRectangle, PrizmCircle, PrizmRoundRectangle, PrizmEllips, Invalid
    }
    /// <summary>
    /// 
    /// </summary>
    public enum DownloadType
    {
        Serial, Ethernet, Invalid, Usb
    }
    /// <summary>
    /// 
    /// </summary>
    public enum DownloadData
    {
        Application = 1,
        Firmware = 2,
        Font = 8,
        Ladder = 4,
        LoggedData = 16,
        Invalid = 32,
        EtherSettings = 64,
        FHWT = 128,
        HistAlarmData = 256,  //manik
        BootBlock = 512
    }

    /// <summary>
    /// 
    /// </summary>
    public enum BrushType
    {
        Solid, Hatch, Texture
    }
    /// <summary>
    /// 
    /// </summary>
    ///
    #region SD_gradients_Pattern
    public enum PatternBrushQT
    {
        NOFILL = 0,
        // ONE_BLACK_ONE_WHITE = 5,
        THREE_BLACK_ONE_WHITE = 10,
        // ONE_BLACK_THREE_WHITE = 15,
        ONE_WHITE_ONE_BLACK = 20,
        HORIZONTAL = 25,
        VERTICAL = 30,
        CROSS = 35,
        BACKWORD_DIAGONAL = 40,
        DIAGONAL_CROSS = 45,
        FORWORD_DIAGONAL = 50,

        //PERCENT40 = 55,
        PERCENT20 = 55,
        PERCENT30 = 60,
        // LARGECHECKER_BOARD = 70

    }
    public enum PatternBrush
    {
        NOFILL = 0,
        ONE_BLACK_ONE_WHITE = 5,
        THREE_BLACK_ONE_WHITE = 10,
        ONE_BLACK_THREE_WHITE = 15,
        ONE_WHITE_ONE_BLACK = 20,
        HORIZONTAL = 25,
        VERTICAL = 30,
        CROSS = 35

    }
    #endregion
    /// <summary>
    /// 
    /// </summary>
    public enum AlignTo
    {
        Left, Right, Top, Bottom
    }
    /// <summary>
    /// 
    /// </summary>
    public enum ShapeDirection
    {
        TopLeft = 1, RightBottom, TopRight, LeftBottom, LeftCenter, RightCenter, TopCenter, BottomCenter, StartPoint = 100, EndPoint, ControlPoint = 11
    }
    /// <summary>
    /// 
    /// </summary>
    public enum LineWidth
    {
        SingleLine, DoubleLine, TripleLine, ThickLine
    }
    /// <summary>
    /// 
    /// </summary>
    public enum ProductID
    {
        PRODUCT_PRIZM10 = 501,
        PRODUCT_PRIZM12 = 502,
        PRODUCT_PRIZM18 = 503,
        PRODUCT_PRIZM22 = 504,
        PRODUCT_PRIZM50 = 505,
        PRODUCT_PRIZM120 = 507,

        PRODUCT_PRIZM15_EV2 = 502,
        PRODUCT_PRIZM20_EV2 = 503,
        PRODUCT_PRIZM40_EV2 = 504,
        PRODUCT_PRIZM50_EV2 = 505,
        PRODUCT_PRIZM80_EV2 = 506,

        PRODUCT_HIO_05 = 508,
        PRODUCT_PRIZM140_EV3 = 509,
        PRODUCT_PRIZM200,
        PRODUCT_PRIZM210 = 511,
        PRODUCT_PRIZM230 = 512,
        PRODUCT_PLC_CARD = 514,
        PRODUCT_PRIZM300,
        PRODUCT_PRIZM285 = 513,
        PRODUCT_PRIZM290N = 646,
        PRODUCT_PRIZM290E = 647,
        PRODUCT_PRIZM720 = 721,
        PRODUCT_PRIZM720N = 688,
        PRODUCT_PRIZM545 = 521,
        PRODUCT_PRIZM550N = 686,
        PRODUCT_PRIZM550E = 687,
        PRODUCT_PRIZM760n = 522,
        PRODUCT_PRIZM760 = 523,
        PRODUCT_PRIZM760E = 525,
        PRODUCT_PRIZM760nk = 526,
        PRODUCT_PRIZMCE545 = 1001,
        PRODUCT_PRIZMCE760 = 1002,

        PRODUCT_HIO_05_1 = 802,
        PRODUCT_HIO_05_2 = 803,
        PRODUCT_HIO_05_3 = 804,
        PRODUCT_HIO_05_4 = 805,
        PRODUCT_HIO_05_5 = 806,
        PRODUCT_HIO_10_1 = 821,
        PRODUCT_HIO_10_2 = 822,
        PRODUCT_HIO_10_3 = 823,
        PRODUCT_HIO_10_4 = 824,
        PRODUCT_HIO_10_5 = 825,
        PRODUCT_HIO_12_1 = 841,
        PRODUCT_HIO_12_2 = 842,
        PRODUCT_HIO_12_3 = 843,
        PRODUCT_HIO_12_4 = 844,
        PRODUCT_HIO_18_1 = 861,
        PRODUCT_HIO_18_2 = 862,
        PRODUCT_HIO_18_3 = 863,
        PRODUCT_HIO_18_4 = 864,
        PRODUCT_HIO_18_5 = 845,
        PRODUCT_HIO_50_1 = 881,
        PRODUCT_HIO_50_2 = 882,
        PRODUCT_HIO_50_3 = 883,
        PRODUCT_HIO_50_4 = 884,
        PRODUCT_HIO_50_5 = 885,
        PRODUCT_HIO_50_6 = 886,
        PRODUCT_HIO_50_7 = 887,
        PRODUCT_HIO_50_8 = 888,
        PRODUCT_HIO_140_1 = 901,
        PRODUCT_HIO_140_2 = 902,
        PRODUCT_HIO_140_3 = 903,
        PRODUCT_HIO_140_4 = 904,
        PRODUCT_HIO_140_5 = 905,
        PRODUCT_HIO_140_6 = 906,
        PRODUCT_HIO_140_7 = 907,
        PRODUCT_HIO_140_8 = 908,
        PRODUCT_HIO_230_1 = 601,
        PRODUCT_HIO_230_2 = 603,
        PRODUCT_HIO_230_3 = 604,
        PRODUCT_HIO_230_4 = 605,
        PRODUCT_HIO_230_5 = 602,
        PRODUCT_HIO_285_1 = 641,
        PRODUCT_HIO_285_2 = 642,
        PRODUCT_HIO_285_3 = 643,
        PRODUCT_HIO_285_4 = 644,
        PRODUCT_HIO_545_1 = 681,
        PRODUCT_HIO_545_2 = 682,
        PRODUCT_HIO_545_3 = 683,
        PRODUCT_HIO_545_4 = 684,
        PRODUCT_PRIZM_760_2 = 524,
        PRODUCT_RDIO_1612_A = 921,
        PRODUCT_RDIO_1612_B = 922,
        PRODUCT_RDIO_1612_C = 923,
        PRODUCT_RDIO_1612_D = 924,
        PRODUCT_RDIO_0808_A = 931,
        PRODUCT_RDIO_0808_B = 932,
        PRODUCT_RDIO_0808_C = 933,
        PRODUCT_FIOA_0402_A = 701,

        PRODUCT_NQ3_TQ000_B = 3503,
        PRODUCT_NQ3_TQ010_B = 3504,
        PRODUCT_NQ3_MQ000_B = 3801,
        PRODUCT_NQ5_MQ000_B = 5706,
        PRODUCT_NQ5_MQ010_B = 5707,
        PRODUCT_NQ5_SQ000_B = 5708,
        PRODUCT_NQ5_SQ010_B = 5709,

        PRODUCT_NQ5_MQ001_B = 5710,
        PRODUCT_NQ5_MQ011_B = 5711,
        PRODUCT_NQ5_SQ001_B = 5712,
        PRODUCT_NQ5_SQ011_B = 5713,

        //FlexiPanel_Change_R1
        //HMI only Products


        PRODUCT_PZ4030M_E = 1102,
        PRODUCT_PZ4030MN_E = 1103,

        PRODUCT_PZ4035TN_E = 1105,
        PRODUCT_PZ4057M_E = 1106,

        PRODUCT_PZ4057TN_E = 1108,
        PRODUCT_PZ4084TN_E = 1109,
        PRODUCT_PZ4121TN_E = 1110,

        PRODUCT_GSM900 = 2001,//GSM_Sanjay
        PRODUCT_GSM901 = 2002,//GWY-901 SP
        PRODUCT_GSM910 = 2003,//GWY_910_Suyash
        //Release Models
        //// PLC models
        PRODUCT_FL010 = 913,
        PRODUCT_FL050 = 914,
        PRODUCT_FL050_V2 = 920, //New Product FL050 V2 SammedB
        #region SD_GWY_NYX_Prod_For_QT
        PRODUCT_GWY_NYX_E = 5000,
        PRODUCT_GWY_NYX_W = 5001,
        PRODUCT_GWY_NYX_EW = 5002,
        #endregion
        //PRODUCT_FL051 = 911, //Remove_Product Vijay(06.02.14)
        PRODUCT_FL011_S1 = 912,
        PRODUCT_FL011_S4 = 969, //New_ProductAdd_Vijay
        PRODUCT_FL004_0403R_N0200L = 989,//SD_UPL_PLC_ProdAddtion				   
        PRODUCT_FL011 = 915,
        #region New PLC Models AMIT
        PRODUCT_FL011_S3 = 917,
        #endregion
        #region ToshibaUS PLC Models
        PRODUCT_GPU288_3S = 941,
        PRODUCT_GPU200_3S = 942,
        PRODUCT_GPU232_3S = 943,
        PRODUCT_GPU230_3S = 944, //New_Product_Addition Vijay(01.03.2013)
        PRODUCT_GPU110_3S = 945, //New_Product_Addition Vijay(15.05.2014)
        PRODUCT_GPU105_3S = 946, //New_Product_Addition Parag(9.12.2014)
        PRODUCT_GPU120_3S = 947, //New_Product_Addition Parag(9.12.2014)
        PRODUCT_GPU122_3S = 948, //New_Product_Addition Vijay(07.04.2015)
        #endregion
        ///////////////
        #region New FL100 Models SAMMED
        PRODUCT_FL100 = 918,
        PRODUCT_FL100_S1 = 934,//FL100_Product_Addition_Ajay

        #endregion
        PRODUCT_FL100_S0 = 919,//SS_FL100S0
        #region FL005-MicroPLC Base Module Series Vijay
        //Remove_Product Vijay
        //PRODUCT_FL005_0604RP = 925,
        //PRPDUCT_FL005_0604RP0201L = 926,
        //
        PRODUCT_FL005_0808RP = 927,
        PRODUCT_FL005_0808RP0201L = 928,
        //FL005-MicroPLC Base Module Series Vijay1
        PRODUCT_FL005_0604P = 951,
        PRODUCT_FL005_0808P = 952,
        PRODUCT_FL005_0808P0201L = 953,
        PRODUCT_FL005_0604N = 954,
        PRODUCT_FL005_0808N = 955,
        PRODUCT_FL005_0808R = 968, //AN_FL0050808R
        PRODUCT_FL005_0808N_S1 = 979, //AN_FL0050808N_S1

        PRODUCT_FL005_0808N0201L = 956,
        PRODUCT_FL005_1616P0201L_S1 = 963,//New FL005 Product Addition Suyash
        //End
        #endregion
        #region FL004_Series_PLC_Vijay
        PRODUCT_FL004_0806P = 1310,
        PRODUCT_FL004_0806R = 1311,
        PRODUCT_FL004_0806N = 1312,
        #endregion
        PRODUCT_FL055 = 970,//FL055_Product_Addition_Suyash
        PRODUCT_FL055_0808N = 964,//SS_FL0550808N
        PRODUCT_FL055_0808N_S1 = 991, //FL055_0808N_S1_Vijay
        PRODUCT_FL055_0808R = 965,//AN_FL0550808R

        #region FL005 Expandable PLC Series Vijay
        PRODUCT_FL005_0808RP0402U = 957,
        PRODUCT_FL005_1616RP0201L = 958,
        PRODUCT_FL005_1616P0201L = 959,
        PRODUCT_FL005_1616N0201L = 960,
        PRODUCT_FL005_1616RP = 961,
        PRODUCT_FL005_1616P = 962,
        PRODUCT_FL005_1616N = 966, //AN_FL005_1616R,AN_FL005_1616N
        PRODUCT_FL005_1616R = 967,
        #endregion
        PRODUCT_FP2020_L0808RP_A0401L = 1171, //2020_Series_Vijay
        PRODUCT_FP2020_L0808P_A0401L = 1172,
        PRODUCT_FP2020_L0604P_A0401L = 1173,
        PRODUCT_FP2020_L0808N_A0401L = 1174,
        //4020 models////////////////////////
        PRODUCT_FP4020MR = 1150,
        PRODUCT_FP4020MR_L0808P = 1151,
        PRODUCT_FP4020MR_L0808N = 1152,
        PRODUCT_FP4020MR_L0808R = 1153,
        #region New_Product_Addition Vijay
        PRODUCT_FP4020MR_L0808R_S3 = 1154,
        #endregion
        PRODUCT_FP3020MR_L1608RP = 1155,//Suyash_FP3020MR_L1608RP_Prod_Addition
        // 4030 models ////////////////////
        PRODUCT_FP4030MR = 1200,
        PRODUCT_FP4030MR_E = 1209,
        PRODUCT_FP4030MR_L1208R = 1210,
        PRODUCT_FP4030MR_0808R_A0400_S0 = 1228,//PRODUCT_FP4030MR_0808R_A0400_S0_addition_sammed
        PRODUCT_FP4030MR_1008R_A0202L_S0 = 1235, //Special Product Addition FP4030MR-1008R-A0202L-S0 ShitalG																			 
        PRODUCT_FP4030MR_L1210RP_A0402U = 1229, //PRODUCT_FP4030MR_L1210RP_A0402U Vijay 
        PRODUCT_FP4030MR_L1210P_A0402U = 1261, //PRODUCT_FP4030MR_L1210P_A0402U Vijay
        PRODUCT_FP4030MR_L1210RP = 1262,//PRODUCT_FP4030MR_L1210RP Suyash
        PRODUCT_FP4030MR_L1210P = 1263,//PRODUCT_FP4030MR_L1210P Suyash
        PRODUCT_FP4030MR_L0808R_A0400U = 1264, //PRODUCT_FP4030MR_L0808R_A0400U Vijay
        #region New_Product_Addition M&R AMIT
        PRODUCT_FP4030MT_HORIZONTAL = 1211,//FP4030MT_addition_AMIT
        PRODUCT_FP4030MT_VERTICAL = 1212,
        PRODUCT_FP4030MT_S1_HORIZONTAL = 1213,
        PRODUCT_FP4030MT_S1_VERTICAL = 1214,
        #endregion
        PRODUCT_FP4030MT_L0808RN_A0201 = 1215, //FP4030MT_L0808RN_A0201_addition_Vijay
        PRODUCT_FP4030MT_L0808RP_A0201 = 1216, //FP4030MT_L0808RP_A0201_addition_Vijay
        PRODUCT_FP4030MT_REV1 = 1218,//New Product addition FP4030MT- Rev 1
        PRODUCT_FP4030MT_S0 = 1236,//PRODUCT_FP4030MT-S0_Ajay

        PRODUCT_FP4030MT_L0808RN = 1219, //New Product addition FP4030MT-L0808RN/RP Vijay
        PRODUCT_FP4030MT_L0808RP = 1220, //New Product addition FP4030MT-L0808RN/RP Vijay
        PRODUCT_FP4030MT_L0808RP_A0201L = 1226, //FP4030MT_L0808RN_A0201L_addition_sammed
        PRODUCT_FP4030MT_L0808RP_A0201L_VERTICAL = 1227, //FP4030MT_L0808RP_A0201L(Vertical)_addition_sammed
        PRODUCT_FP4030MT_L0808RP_A0201_S0 = 1217, //New Product Addition FP4030MT-L0808RP-A0201-S0 Vijay
        #region New Product Addtion FP4030MT_L0808P/FP4030MT_L0808P_A0201U Vijay
        PRODUCT_FP4030MT_L0808P = 1301,
        PRODUCT_FP4030MT_L0808P_A0201U = 1302,
        #endregion
        PRODUCT_FP4030MT_L0808P_A0402L = 1303,//Suyash_Product_Addition_FP4030MT_L0808P_A0402L
        #region New FP4030MT Vertical Series Addition Vijay
        PRODUCT_FP4030MT_REV1_VERTICAL = 1221,
        PRODUCT_FP4030MT_L0808RN_A0201_VERTICAL = 1222,
        PRODUCT_FP4030MT_L0808RP_A0201_VERTICAL = 1223,
        PRODUCT_FP4030MT_L0808RN_VERTICAL = 1224,
        PRODUCT_FP4030MT_L0808RP_VERTICAL = 1225,
        #endregion
        ////////////////////////////////////
        ///4035//////////////////////////////////
        PRODUCT_FP4035T = 1231,
        PRODUCT_FP4035T_E = 1230,
        #region New_Ethernet_Products_AMIT
        PRODUCT_FP4035TN = 1232,
        PRODUCT_FP4035TN_E = 1233,
        PRODUCT_PRIZM_710_S0 = 1234,//SD_Product_Addition_Prizm710_so
        #endregion
        //4057//////////////
        PRODUCT_FP4057T = 1251,
        PRODUCT_FP4057T_E = 1250,
        #region New_Product_Addition_Herizomat AMIT
        PRODUCT_FP4057T_S2 = 1252,
        #endregion
        #region New_Ethernet_Products_AMIT
        PRODUCT_FP4057TN = 1253,
        PRODUCT_FP4057TN_E = 1254,
        #endregion
        #region New_Product_Addition_AllBodySoltn AMIT
        PRODUCT_FP4057T_E_S1 = 1255,
        #endregion
        #region New_Product_Addition_Vertical Vijay
        PRODUCT_FP4057T_E_VERTICAL = 1256,
        #endregion
        ///////////////////////
        //Toshiba Models///////
        PRODUCT_MICRO_PLC = 909, //TRSPUX10A
        PRODUCT_MICRO_PLC_ETHERNET = 910, //TRSPUX10E
        PRODUCT_TRPMIU0300L = 1330,
        PRODUCT_TRPMIU0300A = 1331,
        PRODUCT_TRPMIU0500L = 1350,
        PRODUCT_TRPMIU0500A = 1351,
        //New Ethernet Models - SnehaK
        PRODUCT_TRPMIU0300E = 1333,
        PRODUCT_TRPMIU0500E = 1354,
        //End

        //Toshiba-Japan_Product
        PRODUCT_TRPMIU0400E = 1343,
        PRODUCT_TRPMIU0700E = 1373,
        //End

        ///End/// ////////////


        PRODUCT_FP4020M_L0808P_A = 1203,
        PRODUCT_FP4020M_L0808P_A0400R = 1204,
        PRODUCT_FP4020M_L0808N_A = 1205,
        PRODUCT_FP4020M_L0808N_AR = 1206,

        PRODUCT_FP4020M_L0808R_A = 1207,
        #region New_Product_Addition M&R AMIT
        //PRODUCT_FP4020MR_L0808R_A0400 = 1211,
        //PRODUCT_FP4030M_L1208R_A0400 = 1212,        
        //PRODUCT_FP4030MN_E = 1213,               
        #endregion
        //PRODUCT_FP4057M_E = 1215,

        //PRODUCT_FP4084TN_E = 1217, //New Product Addition FP4030MT-L0808RP-A0201-S0 Vijay


        //Kaspro product ID
        PRODUCT_FH9020MR = 1400,
        PRODUCT_FH9020MR_L0808P = 1401,
        PRODUCT_FH9020MR_L0808N = 1402,
        PRODUCT_FH9020MR_L0808R = 1403,
        PRODUCT_FH9030MR = 1411,
        PRODUCT_FH9030MR_E = 1412,
        PRODUCT_FH9030MR_L1208R = 1413,
        PRODUCT_FH9035T_E = 1421,
        PRODUCT_FH9035T = 1422,
        PRODUCT_FH9057T_E = 1431,
        PRODUCT_FH9057T = 1432,
        //END         

        #region New FP Models-43&70 SnehalM

        // 4030 models ////////////////////
        // PRODUCT_FPW4030M = 1221, //New FP4030MT Vertical Series Addition Vijay
        /////
        #region New FP3series product Addition Suyash
        PRODUCT_FP3043T = 1701,//New FP3043T product Addition Suyash
        PRODUCT_FP3043TN = 1703,//New FP3043TN product Addition Suyash
        PRODUCT_FP3102T = 1721,//New FP3102T product Addition Suyash
        PRODUCT_FP3102TN = 1723,//New FP3102TN product Addition Suyash
        PRODUCT_FP3070T = 1711,//New FP3070T product Addition Suyash
        PRODUCT_FP3070TN = 1713,//New FP3070TN product Addition Suyash
        #region SY-FP3_PlugableIO_Product_addition
        PRODUCT_FP3070T_E = 1712,
        PRODUCT_FP3070TN_E = 1715,
        PRODUCT_FP3102T_E = 1722,
        PRODUCT_FP3102TN_E = 1725,
        #endregion
        #region OIS3Series_Vijay
        PRODUCT_OIS43E_Plus = 1803,
        PRODUCT_OIS72E_Plus = 1813,
        PRODUCT_OIS100E_Plus = 1823,
        #endregion
        #region FP3043_ExpansionSeries Vijay
        PRODUCT_FP3043T_E = 1702,
        PRODUCT_FP3043TN_E = 1704,
        #endregion
        #endregion

        //5043////  New Models added on date 30jully10- SnehalM
        PRODUCT_FP5043T = 1241,
        PRODUCT_FP5043TN = 1242,
        PRODUCT_FP5043T_E = 1240,
        PRODUCT_FP5043TN_E = 1243,
        /////////////////
        //5070////New Models added on date 30jully10- SnehalM
        PRODUCT_FP5070T = 1271,
        PRODUCT_FP5070TN = 1272,
        PRODUCT_FP5070T_E = 1270,
        PRODUCT_FP5070TN_E = 1273,
        PRODUCT_FP5070T_E_S2 = 1274,//New FP5070T-E-S2 product Addition Suyash
        /////////////////
        //4121/////New Model added on date 13Sept10- SnehalM
        PRODUCT_FP5121T = 1280,
        PRODUCT_FP5121TN = 1281,
        PRODUCT_FP5121TN_S0 = 1282,//Haresh_5121TN-SO
        #endregion

        #region Toshiba US products SnehalM
        // OIS10 models ////////////////////
        PRODUCT_OIS12 = 1600,
        PRODUCT_OIS10_Plus = 1603,
        // OIS20 models ////////////////////
        PRODUCT_OIS22_Plus = 1612,
        PRODUCT_OIS20_Plus = 1613,
        ///OIS55 models/////////////////////
        PRODUCT_OIS55_Plus = 1630,
        //OIS60 models//////////////////////
        PRODUCT_OIS60_Plus = 1650,

        //Toshiba_US New product Addition
        //OIS40_models//////////////////////
        PRODUCT_OIS40_Plus_HORIZONTAL = 1621,
        PRODUCT_OIS40_Plus_VERTICAL = 1622,
        PRODUCT_OIS42_Plus = 1623, //New_Product_Addition Vijay(01.03.2013)
        PRODUCT_OIS42L_Plus = 1624, //New_Product_Addition Vijay(12.09.2013)
        //OIS45_models////////////////////
        PRODUCT_OIS45_Plus = 1642,
        PRODUCT_OIS45E_Plus = 1643,
        //OIS70_models////////////////////
        PRODUCT_OIS70_Plus = 1672,
        PRODUCT_OIS70E_Plus = 1673,
        //OIS120_models////////////////////
        PRODUCT_OIS120A = 1681,
        #endregion

        #region PLC_Direct Vijay
        PRODUCT_CPU_300 = 980,
        PRODUCT_CPU_111_RP = 981,
        PRODUCT_CPU_120_ARP = 982,
        PRODUCT_CPU_100_P = 983,
        PRODUCT_CPU_110_P = 984,
        PRODUCT_CPU_120_AP = 985,
        PRODUCT_CPU_100_N = 986,
        PRODUCT_CPU_110_N = 987,
        PRODUCT_CPU_120_N = 988,
        #endregion
        #region Hitachi Hi-Rel Vijay
        PRODUCT_HH5L_B0604D_P = 971,
        PRODUCT_HH5L_B0808D_P = 972,
        PRODUCT_HH5L_B1616D_P = 973,
        PRODUCT_HH5L_B1616D_RP = 974,
        PRODUCT_HH5L_B0201A0808D_P = 975,
        PRODUCT_HH5L_B0201A1616D_RP = 976,
        PRODUCT_HH5L_B0402AU0808D_RP = 977,
        PRODUCT_HH1L_000 = 978,

        PRODUCT_HH5P_H43_NS = 1901,
        PRODUCT_HH5P_H43_S = 1902,
        PRODUCT_HH5P_H70_NS = 1903,
        PRODUCT_HH5P_H70_S = 1904,
        PRODUCT_HH5P_H100_NS = 1905,
        PRODUCT_HH5P_H100_S = 1906,
        PRODUCT_HH5P_HP200808D_P = 1907,
        PRODUCT_HH5P_HP301208D_R = 1908,
        PRODUCT_HH5P_HP300201U0808_RP = 1909,
        PRODUCT_HH5P_HP300201L0808_RP = 1910,
        PRODUCT_HH5P_HP43_NS = 1911,
        PRODUCT_HH5P_HP70_NS = 1912,
        #endregion
        //Maple PLC Product ID
        PRODUCT_PLC7008A_ML = 931,
        PRODUCT_PLC7008A_ME = 932,
        //End

        //Maple HMI Product ID
        PRODUCT_HMC7030A_M = 1531,
        PRODUCT_HMC7030A_L = 1532,
        PRODUCT_HMC7035A_M = 1551,
        PRODUCT_HMC7057A_M = 1571,
        #region//Mapple Customization 2.0_Sanjay
        PRODUCT_HMC7043A_M = 1543,
        PRODUCT_HMC7070A_M = 1573,
        #endregion
        //End

        #region New FP3035 Product Series
        //New FP3035 Product Series 3035T-24/3035T-5 SP
        PRODUCT_FP3035T_24 = 1130,
        PRODUCT_FP3035T_5 = 1132,
        //New_Product_Addition_OIS24/OIS_25 Vijay
        PRODUCT_OIS24 = 1634,
        PRODUCT_OIS25 = 1635,
        //End
        #endregion
        #region Panasonic sammed 2.0
        PRODUCT_GTXL07N = 1714,
        PRODUCT_GTXL10N = 1724,
        #endregion
        PRODUCT_GWY00 = 2021 //GWY00_Change (2021-2040 reserved for GWY00 series models)
    }
    /// <summary>
    /// 
    /// </summary>
    public enum ActionID
    {
        Add, Select, UnSelect, Delete, Change, Cut, Paste, SelectMulti,
        Layout, MakeGroup, BreakGroup, MakeComponent, BreakComponent, FontChange, MultiChange, MultiAdd, PropertyChange, RungLayout, LadderObjectLayout, SendToBack, BringToFront, None  //Ladder_Change New Added RungLayout, LadderObjectLayout
    }

    //Punit apr '09
    /// <summary>
    /// enum for update tag
    /// </summary>
    public enum UpdateTag
    {
        UPDATE_TAG = 0,
        ADD_NEW_TAG,
        NONE
    }

    /// <summary>
    /// 
    /// </summary>
    public enum AnimationID
    {
        ShowHide = 0x0001,
        Blink = 0x0002,
        Color = 0x0004,
        MoveHorizontal = 0x0008,
        MoveVertical = 0x0010,
        StretchHorizontal = 0x0020,
        StretchVertical = 0x0040,
        Rotate = 0x0080,
        Slider = 0x0100,
        ShowValue = 0x0200,
        EnterData = 0x0400,
        Action = 0x0800

    }

    /// <summary>
    /// 
    /// </summary>
    public enum TaskCode
    {
        GoToScreen = 0x0100,
        GoToNextScreen = 0x0101,
        GoToPreviousScreen = 0x0102,
        WriteValueToTag = 0x0200,
        AddaConstValueToTag = 0x0300,
        SubaConstValueFromTag = 0x0400,
        AddTagBToTagA = 0x0301,
        SubTagBFromTagA = 0x0401,
        TurnBitOn = 0x0500,
        TurnBitOff = 0x0501,
        ToggleBit = 0x0504,
        CopyTagBToTagA = 0x0600,
        SwapTagAandTagBBoth = 0x0700,
        PrintData = 0x0800,
        SetRTC = 0x0900,
        CopyTagToSTR = 0x0A00,
        CopyTagToLED = 0x0A01,
        Delay = 0x0C00,
        Wait = 0x0D00,
        KeySpecificTask = 0x0E00,
        ExecutePLCLogicBlock = 0x0F00,
        CopyPLCBlockToRecipe = 0x1000,
        CopyRecipeToPLCBlock = 0x1100,
        CopyRTCToPLCBlock = 0x1200,
        GoToPopUpScreen = 0x1400,
        HidePopUpScreen = 0x0E2F,
        USBDataLogUpload = 0x1500, //FP_CODE Shweta USBDataUpload 07.10.09
        USBHostUpload = 0x1600, //USB_Host_Upload Vijay
        SDCardUpload = 0x1700 //SS_SDCardUpload
    }
    /// <summary>
    /// 
    /// </summary>
    public enum KeyTaskCode
    {
        ClearDataEntry = 0x0000,
        CancelDataEntry = 0x0001,
        AcceptDataEntry = 0x0002,
        SwitchToNextDataEntry = 0x0003,
        IncreaseValueByOne = 0x0004,
        DecreaseValueByOne = 0x0005,
        IncreaseDigitByOne = 0x0006,
        DecreaseDigitByOne = 0x0007,
        ShiftValueToLeft = 0x0008,
        MoveCursorToLeft = 0x0009,
        MoveCursorToRight = 0x000A,
        SignKey = 0x000B,
        SignKeyAndZero = 0x000C,
        NumericKeyZero = 0x000D,
        NumericKeyOne = 0x000E,
        NumericKeyTwo = 0x000F,
        NumericKeyThree = 0x0010,
        NumericKeyFour = 0x0011,
        NumericKeyFive = 0x0012,
        NumericKeySix = 0x0013,
        NumericKeySeven = 0x0014,
        NumericKeyEight = 0x0015,
        NumericKeyNine = 0x0016,
        NumericKeyA = 0x0017,
        NumericKeyB = 0x0018,
        NumericKeyC = 0x0019,
        NumericKeyD = 0x001A,
        NumericKeyE = 0x001B,
        NumericKeyF = 0x001C,
        TurnBitOn = 0x001D,
        TurnBitOff = 0x001E,
        SelectAlarm = 0x001F,
        AcknowledgeAlarm = 0x0020,
        PreviousAlarm = 0x0021,
        NextAlarm = 0x0022,
        StartLogger = 0x0023,
        StopLogger = 0x0024,
        ClearLogMemory = 0x0025,
        PreviousHISAlarm = 0x0026,
        NextHISAlarm = 0x0027,
        ClearPassword = 0x0028,
        AcceptPassword = 0x0029,
        Abort = 0x002A,
        StartLoggerOfGroupNo = 0x002B,
        StopLoggerOfGroupNo = 0x002C,
        ClearHISLogMemory = 0x002D,
        HidePopUpScreen = 0x002F,
        RefreshTrendWindow = 0x0030,
        ScrollHistoricalTrendLeft = 0x0031,
        ScrollHistoricalTrendRight = 0x0032,
        AcknowledgeAllAlarms = 0x0033,
        MoveToOldestAlarms = 0x0036,//0x0054, //AdvancedAlarm_Change commented for alarm punam 813
        MoveToLatestAlarms = 0x0037,//0x0055, //commented for alarm punam 814
        //31-12-08 
        MoveToOldestHisAlarms = 0x0038,//0x0056,
        MoveToLatestHisAlarms = 0x0039,//0x0057,
        //31-12-08
        StartPrintingOfGroupNo = 0x0034,
        StopPrintingOfGroupNo = 0x0035,
        SwitchToPrevDataEntry = 0x3A,

        #region AdvancedAlarm Punam            20/10/08

        //Real Time Horizontal
        MoveToFirstColAlm = 0x3B,
        MoveToPreviousColAlm = 0x3C,
        MoveToNextColAlm = 0x3D,
        MoveToLastColAlm = 0x3E,

        //Historical Time Horizontal
        MoveToFirstColHisAlm = 0x3F,
        MoveToPreviousColHisAlm = 0x40,
        MoveToNextColHisAlm = 0x41,
        MoveToLastColHisAlm = 0x42,
        #region Configuring_Ethernet_Setting_At_RunTime_Vijay
        ShowEthernetConfigurationScreen = 0x43,
        ConfirmEthernetConfigurationScreenSetting = 0x44,
        CancelEthernetConfigurationScreenSetting = 0x45,
        #endregion
        #region AccessLevel Vijay
        ShowLoginScreen = 0x46,
        Logout = 0x47,
        AcceptLoginScreenPassword = 0x48,
        CopyScreenToUSB = 0x49,  //Haresh Copy screen to USB task
        ChangeLoginScreenPassword = 0x50, //AccessLevel_Phase2 Vijay
        CopyScreenToSDCard = 0x51,  //SD_Card_Functionality Vijay
        BackSpaceKey = 151,
        KeyF1 = 201,
        KeyF2 = 202,
        KeyF3 = 203,
        KeyF4 = 204,
        KeyF5 = 205,
        KeyF6 = 206,
        KeyF7 = 207,
        KeyF8 = 208,
        KeyF9 = 209,
        KeyF10 = 210,
        KeyF11 = 211,
        KeyF12 = 212,
        KeyF13 = 213,
        KeyF14 = 214,
        KeyF15 = 215,
        KeyF16 = 216,
        KeyF17 = 217,
        KeyF18 = 218,
        KeyF19 = 219,
        KeyF20 = 220,
        KeySet = 200,
        #endregion
        #endregion
        #region Data_Logging_Modification_1 Vijay
        StartExternalLogger = 0x00DD,
        StopExternalLogger = 0x00DE,
        StartExternalLoggerOfGroupNo = 0x00DF,
        StopExternalLoggerOfGroupNo = 0x00E0
        #endregion
    }

    #region AdvancedAlarm
    public enum ScrollType //manik
    {
        NONE,
        VERTICAL,
        HORIZENTAL,
        BOTH
    }
    public enum Order //Poonam
    {
        Ascending,
        Descending
    }

    #endregion

    /// <summary>
    /// 
    /// </summary>
    public enum AsciiKeyTaskCode
    {
        TildaKey = 100,
        NumericKeyOne = 101,
        NumericKeyTwo = 102,
        NumericKeyThree = 103,
        NumericKeyFour = 104,
        NumericKeyFive = 105,
        NumericKeySix = 106,
        NumericKeySeven = 107,
        NumericKeyEight = 108,
        NumericKeyNine = 109,
        NumericKeyZero = 110,
        MinusKey = 111,
        EqualToKey = 112,
        CommaKey = 113,
        FullStopKey = 114,
        SemiColonKey = 115,
        NumericKeyA = 116,
        NumericKeyB = 117,
        NumericKeyC = 118,
        NumericKeyD = 119,
        NumericKeyE = 120,
        NumericKeyF = 121,
        NumericKeyG = 122,
        NumericKeyH = 123,
        NumericKeyI = 124,
        NumericKeyJ = 125,
        NumericKeyK = 126,
        NumericKeyL = 127,
        NumericKeyM = 128,
        NumericKeyN = 129,
        NumericKeyO = 130,
        NumericKeyP = 131,
        NumericKeyQ = 132,
        NumericKeyR = 133,
        NumericKeyS = 134,
        NumericKeyT = 135,
        NumericKeyU = 136,
        NumericKeyV = 137,
        NumericKeyW = 138,
        NumericKeyX = 139,
        NumericKeyY = 140,
        NumericKeyZ = 141,
        OpeningBrace = 142,
        ClosingBrace = 143,
        BackSlashKey = 144,
        SlashKey = 145,
        SingleQuote = 146,
        ClearKey = 147,
        HomeKey = 148,
        EndKey = 149,
        SpaceKey = 150,
        BackSpaceKey = 151,
        LeftShift = 152,
        RightShift = 153,
        ShiftKey = 154,
        EnterKey = 155
    }
    public enum AsciiNumericKeyTaskCode
    {
        NumericKeyOne = 101,
        NumericKeyTwo = 102,
        NumericKeyThree = 103,
        NumericKeyFour = 104,
        NumericKeyFive = 105,
        NumericKeySix = 106,
        NumericKeySeven = 107,
        NumericKeyEight = 108,
        NumericKeyNine = 109,
        NumericKeyZero = 110,
        FullStopKey = 114,
        EnterKey = 155
    }
    /// <summary>
    /// 
    /// </summary>
    public enum LabelPosition
    {
        TOP,
        BOTTOM
    }

    /// <summary>
    /// It is used to create Size code required for
    /// direct and indirect address of tag.//umesh 05-April-06
    /// </summary>
    public enum TagType
    {
        BitOrCoil,
        Byte,
        Word,
        DoubleWord,
        SystemWordBit,
        BitAdderessRegister,
        Invalid,
        LrealDoubleWord//Support_LREAL_SY _for 8 byte
    }
    /// <summary>
    /// 
    /// </summary>
    public enum RegTextRangeColumnName
    {
        LOWLIMIT = 0,
        HIGHLIMIT,
        TEXT
    }
    /// <summary>
    /// 
    /// </summary>
    public enum OperationType
    {
        NOP = 0,
        ADDITION,
        SUBSTRACTION,
        MULTIPLICATION,
        DIVISION
    }
    /// <summary>
    /// umesh 10-july-06.
    /// The classes in the enum are used to show the
    /// usage of a selected tag.
    /// </summary>

    public enum ClassIdentification
    {
        PROJECT_CLASS,
        TASK_CLASS,
        SCREEN_CLASS,
        SHAPE_CLASS,
        ALARM_CLASS,
        LOGGER_CLASS,
        LADDER_CLASS,  //Ladder_change_R11
        LADDER_SHAPE_CLASS,
        #region PR 1210
        KEYTASK_CLASS,
        KEYGLOBALTASK_CLASS,
        #endregion
        LOGGER_CLASS_EXTERNAL, //Data_Logging_Modification Vijay
        FTP_CLASS,       //SS_FTP_Usage
        NODE_CLASS      //SS_ReconnectCntrl
    }

    /// <summary>
    /// umesh 10-july-06.
    /// The enum provides Task identification which is used to 
    /// show TaskID in usage of selected tag.
    /// </summary>
    public enum TaskIdentification
    {
        PowerOnTask,
        GlobalTask,
        BeforeShowingTask,
        WhileShowingTask,
        AfterHidingTask,
        #region PR 1210
        PressTask,
        PressedTask,
        ReleasedTask
        #endregion
    }
    /// <summary>
    /// 
    /// </summary>
    public enum MeterStyle
    {
        CUSTOM_METER = 0,
        D_METER,
        Optimize, //OptimizeMeter_SY
        //SPMeter_KV
        New1,
        New2
        //End
    }
    #region SPMeter_KV
    public enum SpeedoMeterStyle
    {
        Left_Meter = 0,
        Right_Meter,
        Center_Meter,
        Top_Meter

    }
    #endregion
    /// <summary>
    /// 
    /// </summary>
    public enum KeypadStyles
    {
        KEYPAD_16_KEYS_STYLE = 1,
        KEYPAD_12_KEYS_STYLE,
        KEYPAD_20_KEYS_STYLE,
        KEYPAD_25_KEYS_STYLE,
        KEYPAD_15_KEYS_STYLE,
        KEYPAD_8_KEYS_STYLE,
        KEYPAD_5_KEYS_STYLE,
        KEYPAD_3_KEYS_STYLE,
        KEYPAD_14_KEYS_STYLE
    }

    #region //MeterImprvGraphicalGUI_SY
    /// <summary>
    /// Meter style
    /// </summary>
    public enum MeterStyles
    {
        Meter_0_180_STYLE = 1,
        Meter_90_270_STYLE,
        Meter_180_360_STYLE,
        Meter_270_90_STYLE,
        Meter_0_90_STYLE,
        Meter_90_180_STYLE,
        Meter_180_2700_STYLE,
        Meter_270_360_STYLE,
        Meter_0_360_STYLE,
        Meter_45_135_STYLE,
        Meter_315_225_STYLE,
        Meter_225_315_STYLE
    }
    #endregion

    public enum NumberOfAsciiKeysInRow
    {
        AsciiKeypad_Style = 7,
        AsciiNumericKeyPad_Style = 2
    }

    public enum NumberOfAsciiKeysInColumn
    {

        AsciiKeypad_Style = 8,
        AsciiNumericKeyPad_Style = 6
    }

    public enum NumberOfDefaultDisplayAsciiKeys
    {
        AsciiKeyPad_Keys = 56,
        AsciiNumericKeyPadKeys = 12
    }


    /// <summary>
    /// /
    /// </summary>
    public enum NumberOfAsciiKeypadKeys
    {
        AsciiKeyPad_Keys = 56,
        AsciiNumericKeyPadKeys = 12
    }
    /// <summary>
    /// 
    /// </summary>
    public enum AsciiKeypadStyles
    {
        AsciiKeypad_Style = 1,
        AsciiNumericKeyPad_Style
    }
    /// <summary>
    /// 
    /// </summary>
    public enum NumberOfKeypadKeys
    {
        KEYPAD_16_KEYS = 16,
        KEYPAD_12_KEYS = 12,
        KEYPAD_20_KEYS = 20,
        KEYPAD_25_KEYS = 25,
        KEYPAD_15_KEYS = 15,
        KEYPAD_8_KEYS = 8,
        KEYPAD_5_KEYS = 5,
        KEYPAD_3_KEYS = 3,
        KEYPAD_14_KEYS = 14
    }
    /// <summary>
    /// 
    /// </summary>
    public enum NumberOfDefaultDisplayKeys
    {
        KEYPAD_16_KEYS = 13,
        KEYPAD_12_KEYS = 12,
        KEYPAD_20_KEYS = 20,
        KEYPAD_25_KEYS = 24,
        KEYPAD_15_KEYS = 11,
        KEYPAD_8_KEYS = 6,
        KEYPAD_5_KEYS = 5,
        KEYPAD_3_KEYS = 3,
        KEYPAD_14_KEYS = 13
    }

    public enum KeyStyle
    {
        ONE = 1,
        FOUR_IN_ONE,
        THREE_IN_ONE,
        TWO_IN_ONE
    }

    public enum NumberOfKeysInRow
    {
        KEYPAD_16_KEYS_STYLE = 4,
        KEYPAD_12_KEYS_STYLE = 4,
        KEYPAD_20_KEYS_STYLE = 4,
        KEYPAD_25_KEYS_STYLE = 5,
        KEYPAD_15_KEYS_STYLE = 3,
        KEYPAD_8_KEYS_STYLE = 2,
        KEYPAD_5_KEYS_STYLE = 1,
        KEYPAD_3_KEYS_STYLE = 1,
        KEYPAD_14_KEYS_STYLE = 4
    }

    public enum NumberOfKeysInColumn
    {
        KEYPAD_16_KEYS_STYLE = 4,
        KEYPAD_12_KEYS_STYLE = 3,
        KEYPAD_20_KEYS_STYLE = 5,
        KEYPAD_25_KEYS_STYLE = 5,
        KEYPAD_15_KEYS_STYLE = 5,
        KEYPAD_8_KEYS_STYLE = 4,
        KEYPAD_5_KEYS_STYLE = 5,
        KEYPAD_3_KEYS_STYLE = 3,
        KEYPAD_14_KEYS_STYLE = 4
    }

    public enum ColorPanelState
    {
        NEUTRAL = 0,
        MOUSE_OVER,
        CLICKED,
    }


    public enum DataType
    {
        UNSIGNED = 0,
        SIGNED,
        HEXADECIMAL,
        BCD,
        FLOAT,
        ASCII
    }

    public enum ProductType
    {
        EV4IO = 0,
        EV4WIO = 0,
        EV3IO = 2,
        EV3WIO = 2,
        GATEWAY,
        IOMODUlE,
        PLC
    }
    /// <summary>
    /// The enum is used to set import node errors. It contains all
    /// validation values such as invalid protocol, invalid model, node name present etc
    /// </summary>
    public enum ImportNodeErrorWarning
    {
        NODE_NAME_PRESENT,
        NODE_ADDRESS_AUTOGENERATED,
        INVALID_PROTOCOL,
        INVALID_MODEL,
        INVALID_PORT,
        PROTOCOL_DEFINED_ON_PORT,
        PRIZM_UNIT_DEFAULT_NODE,
        WRONG_NODE_INFORMATION,
        NODE_NOT_SUPPORTED_FOR_PRODUCT,
        INVALID_TOSHIBA_PROTOCOL,//SS_NewToshibaInverterPLC
        NO_ERROR
    }

    /// <summary>
    /// Errors while importing tags from CSV file
    /// </summary>
    public enum ImportTagErrors
    {
        WRONG_TAG_HEADER = 0,
        INVALID_TAG_COLUMN_COUNT,
        INVALID_TAG_INFORMATION,
        DUPLICATE_TAG_ADDRESS,
        DUPLICATE_TAG_NAME,
        WRONG_TAG_ADDRESS,
        WRONG_TAG_NAME,
        WRONG_TAG_TYPE,
        WRONG_NO_OF_BYTES,
        WRONG_PREFIX,
        WRONG_NODE_NAME,
        WRONG_PORT_NAME,
        TAG_LIMIT,
        TAG_ADDED_WITH_AUTOGENERATED_TAG_NAME,
        TAG_CANNOT_REPLACE,
        TAG_REPLACED,
        TAG_ADDED,
        WRONG_TAG_INFORMATION,
        NO_ERROR,
        DUPLICATE_NATIVE_ADDRESS,//ss_Issue426
        STRING_NOT_SUPPORT,//Issue_232 Vijay
        TAG_MAPPING_ERROR //Import/Export_ModbusTags_Issue809_Vijay
    }

    public enum ExportTagErrors
    {
        WRONG_FILE_HEADER,
        WRONG_NODE_HEADER,
        WRONG_TAG_HEADER,
        NOERROR
    }

    /// <summary>
    /// It provides various alrm types such as 16-Consicutive words: Each bit of each word is an alarm.
    /// 16-Words: Each bit of each word is an alarm.
    /// 256-Alarms: Each alarm is either a bit( on/off) or a word alarm.
    /// </summary>
    public enum AlarmType
    {
        Consicutive_Words_16,
        Words_16,
        Alarms_256
    }
    /// <summary>
    /// It provides register coil types such as ReadOnly, WriteOnly, ReadWrite
    /// It is used to show registercoil type in property grid as per the object selection.
    /// Ex. for data entry objects only readwrite and writeonly registercoil types can be provided.
    /// </summary>
    public enum RegisterCoilType
    {
        ReadOnly = 1,
        WriteOnly = 2,
        ReadWrite = 4
    }

    /// <summary>
    /// The enum is used to provide tag error for add tag data.
    /// </summary>
    public enum AddDefaultTagError
    {
        TagAddressAlareadyPresent,
        TagAlreadyPresent,
        InvalidePrefix,
        AddressOutOfRange,
        None
    }

    /// <summary>
    /// This enum is used to provide errors and warnings generated while import objects
    /// </summary>
    public enum ImportObjectErrorsAndWarnings
    {
        Wrong_FileHeader,
        ProjectTitle_NotMatch,
        ScreenName_NotPresent,
        ObjectIdDontMatch,
        LanguageNotPresent,
        LanguageNotPresentInCSV,
        ObjectsNotPresentInCSV,
        None
    }

    /// <summary>
    /// Picture type bitmap or picture library
    /// </summary>
    public enum PictureType
    {
        BITMAP,
        PICTURELIBRARY
    }

    /// <summary>
    /// 
    /// </summary>
    /// 
    //FP_Product_Conversion
    public enum Port
    {
        COM1,
        COM2,
        Ethernet,
        USB,
        Expansion
    }
    //End
    //punit jun '08
    /// <summary>
    /// 
    /// </summary>
    public enum NewInformationDialog
    {
        TAG
    }
    /// <summary>
    /// Manisha
    /// </summary>
    public enum OpenWindow
    {
        BaseScreens = 0, TemplateScreens, AllWindows
    }

    /// <summary>
    /// Enum for logging event
    /// </summary>
    public enum LoggingEvent
    {
        POSITIVE_EDGE = 0,
        NEGATIVE_EDGE,
        BOTH_EDGES
    }

    /// <summary>
    /// Logging modes of data logger
    /// </summary>
    public enum LoggingMode
    {
        POWER_UP = 0,
        START_STOP_TIME,
        KEY_TASK,
        LOGGING_WITH_RUNTIME_FREQUENCY,
        BIT_TASK,
        EVENT_BASED
    }

    public enum ExpansionType
    {
        Serial = 1,
        MPI
    }

    /// <summary>
    /// Data type used for printing tags
    /// </summary>
    public enum DataTypePrintingTags
    {
        UNSIGNED_INT = 0,
        SIGNED_INT,
        HEX,
        BCD,
        FLOAT
    }

    /// <summary>
    /// Plc code of the driver
    /// </summary>
    public enum PLCCode
    {
        PRIZM_UNIT = 0,
        MODBUS_UNIT_AS_MASTER = 9,
        MODBUS_UNIT_AS_SLAVE = 39,
        ALLENBRADLEYDF1 = 27,
        SEIMENS_STEP7_MAICRO = 29,
        TWIDO_PLC = 78,
        MITSUBISHI_FRS500 = 145,
        OMRON_HOST_LINK = 6,
        OMRON_NT_LINK = 85,
        UNIVERSAL_SERIAL_DRIVER = 116,
        ALLENBRADLEYDF1_COMPACTLOGIX = 178,
        MITSUBISHI_FX = 8,
        SEIMENS_S7_300_SERIES = 77,
        OMRON_OMYC = 67,
        SCHNIEDER_MODICON = 179,
        SCHNIEDER_NANO = 92,
        //FP_CODE  R12  Haresh
        TOSHIBA_INVERTERS = 108,
        Baldor = 47,
        ABB_PLC = 36,
        ALLENBRADLEY_DH485 = 7,
        Siemens_Micromaster_Drive = 158,
        Yokogawa_PLCs = 97,
        Koyo_DL205 = 23,
        //FP Code Pravin Serial Monitor
        SERIAL_MONITOR = 184,
        //End
        TRSPUX = 200,//SP
        G9SP_SAFETY_CONTROLLER = 188, // G9SP_SAFETY_CONTROLLER Ethernet Support SP
        FLEXILOGICS = 187,   //SS_RENU_PLC_Change
        FLEXILOGICS_SLAVE_DRIVER = 193, //SS_RENU_PLC_Change
        UNIVERSAL_ETHERNET_DRIVER = 191, //SS_UniversalDriverIECEnable
        TOSHIBA_INVERTERS_Rev1 = 194, //SS_NewToshibaInverterPLC
        PASSTHRUPORT = 197, //SS_FL100S0
        MODBUS_TCP_CLIENT = 132, //SS_ModbusSameNodeAddr
        SIEMENS_PROFINET_ETHERNET_DRIVER = 201//SD_SiemensProfinetDriver
    }

    //FP Code Pravin Serial Monitor
    public enum CommunicationType
    {
        USB = 0,
        Serial,
        Ethernet
    }
    //End
    //FP_Product_Conversion
    public enum PortActions
    {
        CopyCOM1TagtoCOM1Tag,
        CopyCOM1TagtoCOM2Tag,
        CopyCOM1TagtoEthernetTag,
        CopyCOM2TagtoCOM1Tag,
        CopyCOM2TagtoCOM2Tag,
        CopyCOM2TagtoEthernetTag,
        CopyEthernetTagtoCOM1Tag,
        CopyEthernetTagtoCOM2Tag,
        CopyEthernetTagtoEthernetTag
    }
    //End

    #region FP_Ethernet_Implementation-AMIT
    /// <summary>
    /// operation of type download or upload
    /// </summary>
    public enum CommunicationOperationType
    {
        DOWNLOAD = 0,
        UPLOAD = 1,
        NONE
    }
    #endregion

    #region SS_TagGroup
    public enum TagGroupMessage
    {
        NONE = 0,
        GROUP_ALREADY_PRESENT = 1
    }
    public struct stTagGroup
    {
        public int GroupID;
        public string GroupName;
    }
    #endregion

    #endregion

    public class CommonConstants
    {

        public static bool isDeviceInfo = false;
        public static bool IslogEnabled = true;

        public static int BB = 0;

        // Keeran (KA)
        #region set comm settings
        public static string setBaudRate = string.Empty;
        public static string setParity = string.Empty;
        public static string setBitsLength = string.Empty;
        public static string setStopbits = string.Empty;
        #endregion

        #region RoundedRect change_sy
        public static int ScrollPosLeft = 0;
        public static int ScrollPosTop = 0;
        #region Removing_Unused_Images
        //This variable is used for deleting all pzp files and unused bitmap files from ProjectName folder & Picture Folder so do not use it for any other purpose.
        public static string projectFolderPathWithoutExtension = "";
        #endregion
        //Parag_Change_574_Issue
        public static string _bitmapFileFolderPathOldProj = "";
        public static string _bitmapFileFolderPathNewProj = "";
        //Parag_Change_574_Issue
        #endregion
        #region Parag_ethernetdisablesettings
        public static bool _IsEthernetSelected = false;
        #endregion
        public static int SetFileType = 0;
        public static int NodeAddress = 0;
        public static string SetPortName = " ";
        public static string ProductNameforBootblock = " ";
        public static bool _IsImageEdited = false;//Parag_Change_Color
        public static bool _IsXYPlotText = false;//XYPlot
        public static bool _XYSTYLE2 = false;//New_type_XYPlot_SY//
        public static int _XYPlotStyle2NumberofBytes = 0;//New_type_XYPlot_SY//
        public static int _AccLvlHomScrNum = 1;//AccessLevel_HomScr_SY 
        public static int _AccLvlGoToPwrONScrNum = 1;//AccessLevel_HomScr_SY 
        public static bool _AccLvlGoToPwrONTsk = false;//AccessLevel_HomScr_SY 
        public static bool _AccLvlAutoLogOff = false;//AccessLevel_AutoLoggOff_SY
        public static Int16 _AccLvlAutoLogOffTime = 600;//AccessLevel_AutoLoggOff_SY
        public const int AccesslevelMaxUser = 255; //AccessLevelRev_1_SY
        public static bool _isProductVertical = false;//VerticalOri_SY
        #region Public Static/Constant Member Variables

        public static char InvertedComma = '"'; //Punit mar '09
        public static string TABstring = "\t";

        ///-1=NoReading, 0=ReadingFromPrizm3.x, 1=ReadingFromPrizm4.x
        public static int ReadingPrizm4File = -1;  //Kapil 1-Apr-08
        public static int communicationType = 0;
        #region RC1_Issue1703
        public static int MaxNoOfObjectOnScreen = 256;
        #endregion

        public static bool _isCalledForTagUsage = false;//PR1339 Sheetal
        public static bool _isScreenTaskUpdatedFromTagUsage = false;//PR1488 Sheetal
        public static bool _isScreenTaskIDsTOUpdateOnTagUsage = false;//PR1488 Sheetal
        public static bool _DefaultTagMemory = false;//Tagmemory_Check_Sanjay
        public static bool _ExpansionTagExceed = false;//Tagmemory_Check_Sanjay
        //Manisha 23Feb2007
        public static string strtext = "";
        public static string strstring = "";
        public static string strError = "";
        public static string imagechar = "";
        public static bool isMoveOutSide = false;
        public static bool isGroupCreated = false;
        public static bool isProjectSaveAs = false; //Nilam 3Sept09 PR 666 
        public static bool isDownloading = false;//KV added under Issue/2016-17/1696

        public const Int32 LOGPIXELSY = 90;

        public const int SUCCESS = 0;
        public const int FAILURE = -1;
        public const int ONLYBOOTBLOCK = 2;

        public const Byte FourGrayColorIndex_White = 3;  //for white
        public const Byte FourGrayColorIndex_Black = 0;  //for black
        public static String TagSelDefaultTagName = "";//tag_imprvmnts

        #region SS_DefaultTagEdit
        public static bool DownloadTagNames = true;
        public static string DefaultRegTagAddr = "SW0000";
        public static string DefaultBitTagAddr = "S00011";
        public static string LanguageTagAddr = "SW0001";
        #endregion
        #region ss_Object_Defaults
        public static int DefaultRegTagId = -1;
        public static int DefaultBitTagId = -1;
        public static bool blIsFactoryScreen = false;
        public static string DefaultRegTagName = "DefaultReg";
        public static string DefaultBitTagName = "DefaultCoil";
        #endregion
        public static string PassThruXMLFilename = "PassThroughPort.xml";//SS_FL100S0
        public static bool IsHobvisionClientFL100S0 = false;//SS_FL100S0
        #region Import_Screen_AMIT
        public static int ImportTempDefaultRegTagId = -1;
        public static int ImportTempDefaultBitTagId = -1;
        public static string ImportTempDefaultRegTagName = "DefaultReg";
        public static string ImportTempDefaultBitTagName = "DefaultCoil";
        #endregion

        //Ladder_change_R11
        #region Ladder Variables
        public const string Ladder = "Ladder";
        public static String BitInstructionName;
        //public static InstructionType INST_TYPE = InstructionType.NO;
        public static System.Drawing.Rectangle LadderAreaRect;
        //public static RungManager objRungManager;
        public static bool bLadderScreenRightClick = false;
        public static String CounterName;
        public static String CounterInputName;
        public static String CounterOutputName;
        public static String CounterResetName;
        public static String UpDownCounterSelectionInput;

        //5 For data Monitor info added
        //6 Write Format for Binary conversion instruction corrected
        //public static int LadderSaveFileDataVersion = 6;
        public static int LadderSaveFileDataVersion = 7; //Function_Generator_DataType Vijay
        public static string BlockStartHeader = "Start of Block";
        public static string InstructionStartHeader = "Start of Instruction";
        public static string DataMonitorStartHeader = "Start of Data Monitor";
        public static LadderEditorMode ActiveLadderMode = LadderEditorMode.MODE_OFFLINE;
        public static bool bPlcCommunicationStatus = false;
        public const int START_LADDER_SCREEN = 50000;
        public const int END_LADDER_SCREENS = 60000;
        public const ushort MAX_LADDER_SCREENS = 10000;
        public static byte enableCalibration = 0;

        //WebServer change
        #region WebServer Change
        //WebScreens 64000 to 64900 Total 900
        public const int START_WEB_SCREEN = 64000;
        public const int END_WEB_SCREENS = 64900;
        #endregion
        //End

        /* User defined screen ranges
          Base sccreens 1 to 49000         // Total=49000

              Template     64991 to 65000  //Total=10

              Popup        65001 to 65535   //Total=534
         */

        //FHWT 64901-64980 //Total=80
        //Ladder Screen  50000-60000 //Total=10000

        public static string LadderSaveFileStartHeader = "$$#*#Start of Ladder4 Data#*#$$";
        public static string UnicodeTagNamesStartHeader = "$$#*#Start of Tag Names Data#*#$$";
        public static bool bObjectMoved = false;
        public static bool bNewObjectAdded = false;
        public static bool bLadderEditing = true;
        public static bool bImportBlock = false;
        public static bool bUploadFromGUI = false;
        public static bool bIsShiftKeyPressed = false;
        public static LadderOperandInfo objLadderOperandInfo = new LadderOperandInfo();
        public static int ProductIdentifier = 0;
        public static byte UnicodeTagNameRevision = 1;
        public static string strDefaultTagAddress = "XXXX";
        //User defined Colors
        //On Line
        public static Color ColorContactOnState = Color.LightGreen;
        public static Color ColorContactOffState = Color.Red;
        public static Color ColorFunctionBlock = Color.Black;
        public static Color ColorOperandVale = Color.Black;
        public static Color ColorForceVar = Color.Red;
        //Editor
        public static Color ColorLadderBackGroundArea = Color.White;
        public static Color ColorActiveRung = Color.FromArgb(0, 255, 255);
        public static Color ColorLeftMarginRung1 = Color.Turquoise;
        public static Color ColorLeftMarginRung2 = Color.MistyRose;
        //////////
        public static bool ShowRegisterEntryMessage = true;
        public static bool AutoAddTagForExpansion = true;
        public static bool g_ShowNewInst_DefaultTagSel = false;//Default_TagSelUI_Change

        #region FP_CODE        Punam
        public static bool ShowOverlappingErrorMessage = true;
        #endregion FP_CODE        Punam

        //FP code Pravin Serial Monitor
        public static string FileNameLadderSettings = "LadderSettingsV6.dat";  //Default_TagSelUI_Change
        //End

        public static string SystemTag_MainLoopScanTime = "SW0017";
        public static string SystemTag_PLCMode = "MW0000";
        public static string SystemTag_LadderScanTime = "SW0046";
        public static string SystemTag_ErrorHandle1 = "MW0001";
        public static string SystemTag_ErrorHandle2 = "MW0002";
        public static int EventHistoryClearAddr = 0x3D01;
        public static int IOExpInfoAddr = 0x3F00;

        public static char Retentive_Prefix = 'R';
        //  public static string Retentive_MemoryLifeCycle = "Retentive memory write operation is limited to maximum of 10,00,000 write cycles \nExceeding this limit will cause damage to Retentive memory [R00000 - R01399].";
        public static string Retentive_MemoryLifeCycle = "Retentive memory write operation is limited to maximum of 10,00,000 write cycles \nExceeding this limit will cause damage to Retentive memory"; //Haresh Retentive change for FP3 series
        public static string Retentive_MemoryLifeCycle_2 = "Retentive memory write operation is limited to maximum of 30,000 write cycles \nExceeding this limit will cause damage to Retentive memory";
        public static string Retentive_MemoryLifeCycle_Caption = "Warning";

        // public static int SleepCount = 10;
        public static int SleepCount = 100;
        public static int SleepMultiplier = 50;

        public static byte[] FontDataBuff;

        public static float ZoomFactorLadder = 100.0f;
        public static float ZoomFactorScreen = 200.0f;

        public static int OriginalWidth = 40;
        public static int OriginalHeight = 40;

        //Haresh Debug_change
        public static string SystemTag_DebugMode = "SW0150"; //1 start, 0 stop
        public static string SystemTag_BkPoint = "SW0151"; //Lobyte value decideds 8 breakpoints
        public static string SystemTag_StepAddress = "SW0152"; //Stores addr for 1st Bkp
        public static string SystemTag_ActiveStep = "SW0170"; //Stores Active step Address
        public static long g_CurrentStepAddress = 0;
        public static int g_debugMode = 0;
        public static int g_BkPointRegValue = 0;

        //End

        //Expansion
        public static string strNode = "Node ";
        public static string strNode0 = "Node 0";
        public static string strCom = "Com";
        public static string strRenuDrv = "Renu Electronics";
        public static string strDeviceNodeName = "Operator Panel";

        public static string strExpansionIPTagAddress = "XW0";
        public static string strSerialIOIPTagAddress = "XW";
        public static string strExpansionIPTagName = "InputReg";
        public static string strExpansionIPRegType = "Input Registers";

        public static string strExpansionOPTagAddress = "YW0";
        public static string strSerialIOOPTagAddress = "YW";
        public static string strExpansionOPTagName = "OutputReg";
        public static string strExpansionOPRegType = "Output Registers";

        public static string strExpansionIPTagBitAddress = "X0";
        public static string strSerialIOIPTagBitAddress = "X";
        public static string strExpansionIPTagBitName = "InputCoil";
        public static string strExpansionIPBitRegType = "Input Coils";

        public static string strExpansionOPTagBitAddress = "Y0";
        public static string strSerialIOOPTagBitAddress = "Y";
        public static string strExpansionOPTagBitName = "OutputCoil";
        public static string strExpansionOPBitRegType = "Output Coils";

        public static string strExpansionIOConfigTagAddress = "MW0";
        public static string strSerialIOIOConfigTagAddress = "MW";
        public static string strExpansionIOConfigTagName = "IOConfigReg";
        public static string strExpansionIOConfigRegType = "IO Configuration Registers";
        public static string strExpansionIOConfigCoilType = "IO Configuration Coils";


        public static int TagNameLen_Display = 6;
        public static int Comm_Mode = 2; //Default USB

        public static bool b_chkhaltmode_dnld = true;
        public static bool b_chkrunmode_dnld = true;
        public static bool b_chkcleanmemory_dnld = false;
        //Changes AMIT M-05 10-05-2010
        //public static bool b_chkPLCMemory_dnld = false;
        public static bool b_chkPLCMemory_dnld = true;
        //End
        public static bool b_chkApplication_dnld = true;
        public static bool b_chkLadder_dnld = true;
        public static bool b_chkData_dnld = false;
        public static bool StatusErrorDlg = false;
        public static int PortIndex = 0;

        public static bool SimulationFlag_Native = false;//simulation_sammed
        public static bool _flagClose = false;//simulation_sammed
        public static bool _simulationErrorFlag = false;//Simulation_window_SammedB

        public static int FixedGridWidth = 12; //For Text based prduct FP4020
        public static int FixedGridHeight = 16;
        //End
        #region Structure_SY
        public static ArrayList StructureInfo = new ArrayList();
        #endregion
        //Logger.bin_multiple_excelsheet_Kapil_sammed
        public static ArrayList loggeddata_Filelist = new ArrayList();
        public static ArrayList loggeddata_StartDatelist = new ArrayList();
        public static ArrayList loggeddata_Enddatelist = new ArrayList();
        public static ArrayList loggeddata_StarTimelist = new ArrayList();
        public static ArrayList loggeddata_EndTimelist = new ArrayList();
        public const string LoggedDatapath = "";
        public static string Path = string.Empty;
        public static int projectID;
        public string _singlefile = "";//Displyloggdata_with_single_file_change_sammed_2.3
        //end

        public static ArrayList objListDataMonitorData = new ArrayList();
        public static PlcModuleHeaderInfo commonHeaderInfo = new PlcModuleHeaderInfo();
        public static ArrayList commonListModuleInfo = new ArrayList();

        #region Delete Update VMDB on Save/Close - Amit
        //IEC_Backup_Change-AMIT
        //public static ArrayList objDeleteVMDBTagData = new ArrayList();
        //public static ArrayList objDeleteVMDBScreenData = new ArrayList();
        //public static ArrayList objUpdateVMDBTagData = new ArrayList();
        //public static ArrayList objEditedVMDBTagData = new ArrayList();//ss_Issue460
        //End
        #endregion

        public static int ProjectReadVersion = 0;
        //public static byte ProjectCurrentVersion = 44;
        #region Import_Screen_AMIT
        public static int ImportProjectReadVersion = 0;
        public static bool ImportScreenFlag = false;
        public static bool ImportScreenXmlRoutine = false;
        public static bool ImportScreenIsProductVertical = false;
        #endregion

        #region _LineTagChange
        //public static byte ProjectCurrentVersion = 45; // Version is changed for run time line drawing feature
        #endregion
        #region FP_Ethernet_Implementation-AMIT
        // public static byte ProjectCurrentVersion = 46; // Version is changed for Ethernet Settings Save
        // public static byte ProjectCurrentVersion = 47; // Version changed for Add tag Task file format
        //FP_AnimationChange_AMIT
        //public static byte ProjectCurrentVersion = 48; // Version changed for Show/Hide Property for Data entry/Button
        //Haresh_back_Task_Change
        //public static byte ProjectCurrentVersion = 49; // Version changed for Back task support for remaining tasks
        //#region GSM_Sanjay
        //public static byte ProjectCurrentVersion = 50; // Version changed for GSM Settings
        //#endregion GSM_Sanjay
        #endregion
        //public static byte ProjectCurrentVersion = 51; // Version changed for Back task for Toggle Bit
        //public static byte ProjectCurrentVersion = 52; // Changed for Toshiba Japan Open appln issue which were saved by 52 version no.
        //public static byte ProjectCurrentVersion = 53; // Read No. of Pressed Task read for Coil Data Entry only and skip write Keypad (2 byte)//Issue_501_SurajP
        //public static byte ProjectCurrentVersion = 54; // For straton tag info// It was coomented before
        //public static byte ProjectCurrentVersion = 55; // For straton tag info
        //public static byte ProjectCurrentVersion = 56; // For Data monitor tag info & moniotor port Info
        //public static byte ProjectCurrentVersion = 57; // Modbus Mapping byte Addition
        //public static byte ProjectCurrentVersion = 58; // Initial value for Straton Tags //Inital Value Change Straton- Amit
        //public static byte ProjectCurrentVersion = 59; // Addition of One byte for Modbus mapping i.e datatype byte- Amit
        //public static byte ProjectCurrentVersion = 60;//Sanjay_ProjectTitleChange write Project folder name in Nondownlodable data for IEC Project. 
        //public static byte ProjectCurrentVersion = 61; // alarm_Add FontSize property-SnehaK
        //public static byte ProjectCurrentVersion = 62;//WindowsFontSupport_Kapil for Reg Data entry and Data Display
        //public static byte ProjectCurrentVersion = 63;//WindowsFontSupport_Kapil for Coil Data Entry and Coil Display Data
        //public static byte ProjectCurrentVersion = 64;// G9SP_SAFETY_CONTROLLER Ethernet Support SP
        //public static byte ProjectCurrentVersion = 65;
        //public static byte ProjectCurrentVersion = 66;//ss_NewlyAddedDefaultTagsIssue
        //public static byte ProjectCurrentVersion = 67; //Use As Default Functinality Issue_950 Vijay
        //public static byte ProjectCurrentVersion = 68; //ASCII register data entry and register display data Kapil
        //public static byte ProjectCurrentVersion = 69; //WordWizard write change Issue_871 Vijay

        //WebServer Change
        #region WebServer Change
        //public static byte ProjectCurrentVersion = 70;//WebServer Change
        #endregion
        //End
        //public static byte ProjectCurrentVersion = 71;//Siemens Micromaster Driver(USS) ShitalG
        //public static byte ProjectCurrentVersion = 72;//XYPlot
        //public static byte ProjectCurrentVersion = 73;//Save_Optimization_SS
        //public static byte ProjectCurrentVersion = 74;//Configuring_Ethernet_Setting_At_RunTime_Vijay
        //public static byte ProjectCurrentVersion = 75; //String_DataType_Vijay //Haresh Sir.
        //public static byte ProjectCurrentVersion = 76;//FL100_change_Sammed
        //public static byte ProjectCurrentVersion = 77;//FL100_change_Sammed
        //public static byte ProjectCurrentVersion = 78;//FL100_change_Sammed
        //public static byte ProjectCurrentVersion = 79;//Power-On_Communication_Timer_sammed
        //public static byte ProjectCurrentVersion = 80;//ToshibaUS_ProtocolChanges Vijay //Monitoring Port added to Native & IEC and removed monitoring port for IEC appln //SS_DefaultTagEdit same version
        //Monitoring Port- AD
        //public static byte ProjectCurrentVersion = 82;//Monitoring Port added to Native & IEC and removed monitoring port for IEC appln //SS_DefaultTagEdit same version
        //public static byte ProjectCurrentVersion = 83;//Webscreen Hide border,navigation & Header //Hide_Header_Navigation_SY
        // public static byte ProjectCurrentVersion = 84;//AccessLevel_Login_SY
        //public static byte ProjectCurrentVersion = 85;//Array_change Added dimension Info
        //public static byte ProjectCurrentVersion = 86;//SS_NodenameWrite
        //public static byte ProjectCurrentVersion = 87;//SS_ModbusSameNodeAddr
        //public static byte ProjectCurrentVersion = 88;//New_type_XYPlot_SY//
        //public static byte ProjectCurrentVersion = 89;//ASCII capital bitmap & Reg.DE-Reg.DD operand Float type //
        //public static byte ProjectCurrentVersion = 90;//Structure_SY
        //public static byte ProjectCurrentVersion = 91;//SS_SerialParam
        //public static byte ProjectCurrentVersion = 92;//SS_PopupScreenIssue
        //public static byte ProjectCurrentVersion = 93;//SD_AlarmSorting
        //public static byte ProjectCurrentVersion = 94;//SS_DeleteGatewayTag
        //public static byte ProjectCurrentVersion = 101;//FastKaps//Data_Logging_Modification Vijay
        // public static byte ProjectCurrentVersion = 102;//SS_FTP_cmntd
        //public static byte ProjectCurrentVersion = 103;//SS_ReconnectCntrl
        public static byte ProjectCurrentVersion = 107;//GWY00_Change //GWy00 download info //5 version numbers reserved for 2.32 update//SS_TagGroup////LREAL_New_SY_Plcspecificbyte_8byte

        //End
        //End

        public static bool IsDownloadMessageChecked = false;
        public static bool bScreenSnapToGrid = false;
        public static bool LADDER_PRESENT = false;
        public static bool EndorRetInstError = false;
        public static String ProjectName = "";

        public static bool IsHeizomatClient = false;
        public static bool IsAllBodySoltnClient = false;
        public static bool HidePowerOnMsgForFP3557 = false;//special Update
        #region SnehaK_29.5.2012
        public static bool FPSCDriver = false;
        #endregion
        #region DGHomeDriver_SY
        public static bool DigiHomeDriver = false;
        #endregion
        public static bool Tox_Changes = false;//Tox_Changes_SP_Update_SY
        #region New_Product_Special_Upadate Vijay
        public static bool FP4020MR_L0808R_S3 = false;
        #endregion
        #region New Product Addition FP4030MT-L0808RP-A0201-S0 Vijay
        public static bool FP4030MT_L0808RP_A0201_S0 = false;
        #endregion
        #region New_Product_Special_Upadate Vijay_29.11.13
        public static bool FP4030MR_0808R_A0400_S0 = false;
        #endregion
        public static bool ShowAllSpecialProducts = false;

        public static bool Show_5121N_S0 = false;//Haresh_5121TN-SO
        public static bool Show_5070T_E_S2 = false;//New FP5070T-E-S2 product Addition Suyash
        public static bool Show_PRIZM_710_S0 = false;//SD_Product_Addition_Prizm710_so
        //FP_Product_Conversion
        public static ProductData _commconstantDestProductData = new ProductData();
        public static ProductData _commconstantSourceProductData = new ProductData();
        public static ModelDataInfo _commconstantDestModelData = new ModelDataInfo();
        public static ResolutionValues _commonConstantsResValues = new ResolutionValues();
        public static PortValues _commonConstantsPortValues = new PortValues();
        public static KeyValues _commonConstantsKeyValues = new KeyValues();
        public static ColorValues _commonConstantsColorValues = new ColorValues();
        public static ArrayList _commonConstantsCom1DestinationModels = new ArrayList();//Issue_1105
        public static ArrayList _commonConstantsCom2DestinationModels = new ArrayList();//Issue_1105

        public static string _commonConstantsSrcProjName = "";
        public static string _commonConstantsDstProjName = "";
        public static bool _commonConstantblIsColorConvert = false;
        public static bool _commonConstantblIsProductConvert = false;
        public static bool _commonConstantblIsFHWTConvert = false;
        public static string _commonConstantsApplicationDirPath = "";
        public static string _commonConstantstrSaveAsFileName = "";
        public static bool ProjectConversion = false;
        public static String ProjectConversionName = "";
        public static ProductData OldProductDataInfo;

        public static bool g_Build_IEC_Ladder = false;
        public static bool g_Support_IEC_Ladder = false;
        public static bool g_IEC_Simulation = false;
        public static bool g_IEC_OnLine = false;
        public static bool g_SelectVar = false;
        public static UInt32 g_hDBClient = 0;
        public static UInt32 g_hDBProject = 0;
        public static UInt32 g_hMWClient = 0;
        public static UInt32 g_hMWProject = 0;
        public static string LadderProjectFolder = "LDProject";
        public static ArrayList objListSlotAddressXW = new ArrayList();
        public static ArrayList objListSlotAddressYW = new ArrayList();

        public static String SerialPortName = "Com1";

        public static bool g_AfteSelectFinished = false;

        public static bool ModelConversion = false;

        public static bool g_InsertMode = true;

        public static int MonitoringPort = 1100; //For Download
        //Suraj Ethernet Monitoring Change 20 June  2012
        public static string strIPAddress = "192.168.0.254";
        public static int _ethernetMonitoringPort = 1100;

        //SaveDownloadEthernetSettings_SD
        public static string ComNoOrIpAddressDownload = "192.168.0.254";
        public static int ethernetPortNumber = 5000;
        public static int responseTimeOutDownload = 40;
        //end

        public static int template1Series = 0;
        public static int template2Product = 0;
        public static int template3Mode = 0;
        public static int template4Language = 0;
        public static int template5Orientation = 0;



        public static uint g_hobjData = 0;
        public static uint g_hobjData2 = 0;
        public static uint g_hobjData3 = 0;
        public static uint g_hobjMode = 0;
        public static uint g_hobjModeW = 0;
        public static bool g_Status1 = false;
        public static bool g_Status2 = false;

        public static bool g_DM_Online = false;
        public static bool g_LadderModified = false;

        public static bool g_UploadForOnLine = false;
        public static bool g_DownloadForOnLine = false;
        public static UInt32 g_hMWClientDW = 0;
        public static UInt32 g_hMWProjectDW = 0;

        public static bool g_Logix = false;
        public static String g_StrValue = "";
        public static String g_StrName = "";
        public static String g_MWStatus = "";
        public static bool g_Save_Project = false;
        public static bool g_MDIClose = false;

        public static int g_Color_BOOL = Color.Magenta.ToArgb();
        public static int g_Color_BYTE = Color.Red.ToArgb();
        public static int g_Color_WORD = Color.Blue.ToArgb();
        public static int g_Color_DWORD = Color.Violet.ToArgb();
        public static int g_Color_INT = Color.LawnGreen.ToArgb();
        public static int g_Color_SINT = Color.Orange.ToArgb();
        public static int g_Color_DINT = Color.Red.ToArgb();
        public static int g_Color_USINT = Color.DodgerBlue.ToArgb();
        public static int g_Color_UDINT = Color.Black.ToArgb();
        public static int g_Color_UINT = Color.BlueViolet.ToArgb();
        public static int g_Color_Time = Color.DarkGreen.ToArgb();
        public static int g_Color_REAL = Color.Black.ToArgb();


        public static bool g_OffDM_Simulation = false;//Offline Data monitoring-AMIT
        public static bool g_ForceIO = false;
        public static ArrayList objListForceIO = new ArrayList();
        public static int g_Print_CellW_LD = 50;
        public static int g_Print_CellW_FBD = 50;
        public static int g_Print_CellW_SFC = 150;
        public static string g_FindString = "";//Find_change_native
        public static double g_ScanTime = 0;  //Large_ScanTime_change

        //IEC_ChangeKD
        public static string g_ProjectPath = "";
        //End
        #region Maple Demo Version Changes - AMIT
        public static bool DemoVersion = false;
        public static string RegistryEntryPath;
        #endregion

        public static bool FirmChkCheck = true;//Sanjay_Maple2.25.22

        public static String ETH_settingFileName = "ETH_SETTING.BIN";//ETH_SETTING.bin_SY

        #region Save_optimization_AD
        public static string XMLTemplateFolder = "Template";
        #region NewProject_Optimization_SS
        public static string ProjectTemplateFolder = "ProjectTemplates";
        public static string ProjectTemplateIECFolder = "IECApps";
        public static string ProjectTemplateNativeFolder = "NativeApps";
        public static string ProjectBackupFolder = "AppBkp";
        public static bool ProjectTemplateFlag = false;
        public static bool ProjectTemplateCreateNewFlag = false;
        public static string ProjectTemplateTempFolder = "TempProjectTemplates";
        public static string WriteExcepFile = "WExcp.fpe";
        public static string ReadExcepFile = "RExcp.fpe";
        public static string DwnlExcepFile = "DExcp.fpe";
        public static string UpldExcepFile = "UExcp.fpe";
        public static string OperExcepFile = "OperExcp.fpe";
        #endregion
        public static bool IsXMLFileSaveRoutine = false;
        public static float DpiX = 0;
        public static float DpiY = 0;
        public static string HeaderXMLFile = "PRJHDRIN.fpx";
        public static string NonDownloadbleXMLFile = "NDWIN.fpx";
        public static string TaskXMLFile = "TSKDB.fpx";
        public static string KeysXMLFile = "KYDB.fpx";
        public static string screenHeader = "SCRHDRIN.fpx";
        public static string objectHeader = "OBHIN.fpx";
        public static string XProjectData = "XProjectData";
        public static string DataLoggerXMLFile = "DLDB.fpx";
        public static string ObjectAnimationXMLFile = "OBAnimIN.fpx";
        public static string NodeDBXMLFile = "NDDB.fpx";
        public static string TagDBXMLFile = "NTDB.fpx";
        public static string objectTaskFile = "OBTSKIN.fpx";
        public static string objectXMLFileExtension = ".obx";
        public static string AlarmInformationXML = "ALDB.fpx";
        public static string LangDBXMLFile = "LGDB.fpx";
        public static string USDBXMLFile = "UNSDIN.fpx";
        public static string ModbusMapXML = "MSMIN.fpx";
        public static string ExpansionXML = "EXDB.fpx";
        public static string UseAsDefaultBIN = "UADef.bin";
        public static string WebScreenXML = "WSIN.fpx";
        public static string AccessLvluserXML = "ACCLU.fpx";//AccessLevelRev_1_SY
        public static string DMonitoringXML = "DMNTR.fpx";
        public static string ConversionLogXML = "CNLG.FPX";
        public static string EmailInformationXML = "EMDB.fpx";//EmailKD
        public static string EmailContactGroupInformationXML = "EMCG.fpx";//EmailKD
        public static string TagGroupXML = "GTIN.fpx";//SS_TagGroup
        public static string DefaultTagGroup = "None";//SS_TagGroup
        public static string FTPXMLFile = "TFIN.fpx";//SS_FTP
        public static string GWYBlockXML = "GWYBLK.FPX";//GWY00_Change
        public static bool IsProjectClosing = false;
        public static bool TagDBDirtyFlag = false;
        //public static SortedList _backupScreens = new SortedList();//Save_optimization_cmntd
        public static int SelectedProjectID = 0;
        #endregion
        //Haresh Project Converion
        public static int g_Conversion_Def_RegTag_Id = 0;
        public static String g_Conversion_Def_RegTag_Addr = "";
        public static String g_Conversion_Def_RegTag_Name = "";
        public static int g_Conversion_Def_CoilTag_Id = 0;
        public static String g_Conversion_Def_CoilTag_Addr = "";
        public static String g_Conversion_Def_CoilTag_Name = "";
        public static ArrayList List_DelTagInfo = new ArrayList();
        public static bool g_Project_Conversion = false;
        //
        public static List<int> lstCopyTaskIDs = new List<int>();//SS_CopyTasks

        //IEC_Backup_Change-AMIT
        public static string IECBackUpFolder = "BkpPrg";
        //HJ Default_Block_Change
        public static ArrayList List_DefBlockNames = new ArrayList();
        //End
        public static int g_Grid_Max_Rows = 256;//GWY00_Change
        #endregion

        #endregion

        // AMIT J-07 Extension change
        public static string ProjectExtension;
        public static string ProjectExtensionFilter;
        public static string ProjectConversionPath = "";
        public static string _stDatatype = string.Empty; //Tag DataType Sanjay
        #region Maple Customization Changes
        public static string ProjectIconFile;
        public static string IOExpansionFile;
        public static string ProjectFontBinFile;
        public static string ProjectUnitXmlFile;
        public static string ProjectUnitLPCFile;
        public static string ProjectSaveFolder;
        #endregion

        // Files needed for the Prizm 4 application
        public static string DEFAULT_NODETAG_FILE = "DefaultNodeTag.xml";

        //Constants for the ProjectList Class
        public const int PRIZM_MIN_BYTES_EV3 = 80;
        public const int PRIZM_HW_BYTES = 64;
        public const int VERSION_BYTE = 49;
        public const int PRIZM3_MIN_BYTES = 50;
        public const int PRIZM_EV3_READ_BYTES = 30;
        //Product Constants.
        //Product Constants.
        public const int PRODUCT_PRIZM10 = 501;
        public const int PRODUCT_PRIZM12 = 502;
        public const int PRODUCT_PRIZM15 = 15;
        public const int PRODUCT_PRIZM18 = 503;
        public const int PRODUCT_PRIZM22 = 504;
        public const int PRODUCT_PRIZM50 = 505;
        public const int PRODUCT_PRIZM120 = 507;

        public const int PRODUCT_PRIZM20 = 20;
        public const int PRODUCCT_PRIZM40 = 30;

        public const int PRODUCT_PRIZM80 = 41;

        public const int PRODUCT_PRIZM140 = 500;

        public const int PRODUCT_PRIZM10_EV2 = 501;
        public const int PRODUCT_PRIZM15_EV2 = 502;
        public const int PRODUCT_PRIZM20_EV2 = 503;
        public const int PRODUCT_PRIZM40_EV2 = 504;
        public const int PRODUCT_PRIZM50_EV2 = 505;
        public const int PRODUCT_PRIZM80_EV2 = 506;
        public const int PRODUCT_PRIZM90_EV2 = 507;
        public const int PRODUCT_HIO_05 = 508;
        public const int PRODUCT_PRIZM140_EV3 = 509;
        public const int PRODUCT_PRIZM280 = 510;
        public const int PRODUCT_PRIZM210 = 511;
        public const int PRODUCT_PRIZM230 = 512;
        public const int PRODUCT_PLC_CARD = 514;
        public const int PRODUCT_PRIZM540 = 520;
        public const int PRODUCT_PRIZM285 = 513;
        public const int PRODUCT_PRIZM290N = 646;
        public const int PRODUCT_PRIZM290E = 647;
        public const int PRODUCT_PRIZM720 = 721;
        public const int PRODUCT_PRIZM720N = 688;
        public const int PRODUCT_PRIZM545 = 521;
        public const int PRODUCT_PRIZM550N = 686;
        public const int PRODUCT_PRIZM550E = 687;
        public const int PRODUCT_PRIZM760n = 522;
        public const int PRODUCT_PRIZM760 = 523;
        public const int PRODUCT_PRIZM760E = 525;
        public const int PRODUCT_PRIZM760nk = 526;
        public const int PRODUCT_PRIZMCE545 = 1001;
        public const int PRODUCT_PRIZMCE760 = 1002;
        public const int PRODUCT_PZM4_0216 = 02161;
        public const int PRODUCT_PZM4_1300 = 13001;
        public const int PRODUCT_PZM4_1600 = 5701;
        public const int PRODUCT_PZM4_1615 = 5702;
        public const int PRODUCT_PZM4_2600 = 5703;
        public const int PRODUCT_PZM4_2615 = 5704;
        //New NQ3 and NQ5 products.
        public const int PRODUCT_NQ3_TQ000_B = 3503;
        public const int PRODUCT_NQ3_TQ010_B = 3504;
        public const int PRODUCT_NQ3_MQ000_B = 3801;
        public const int PRODUCT_NQ5_MQ000_B = 5706;
        public const int PRODUCT_NQ5_MQ010_B = 5707;
        public const int PRODUCT_NQ5_SQ000_B = 5708;
        public const int PRODUCT_NQ5_SQ010_B = 5709;
        //Vertical NQ Models
        public const int PRODUCT_NQ5_MQ001_B = 5710;
        public const int PRODUCT_NQ5_MQ011_B = 5711;
        public const int PRODUCT_NQ5_SQ001_B = 5712;
        public const int PRODUCT_NQ5_SQ011_B = 5713;


        public const int ianalogInputVal = 0;
        public const int ianalogOutputVal = 0;

        //Products used in ProductInfo.c File.
        public const int PRODUCT_HIO_05_1 = 802;
        public const int PRODUCT_HIO_05_2 = 803;
        public const int PRODUCT_HIO_05_3 = 804;
        public const int PRODUCT_HIO_05_4 = 805;
        public const int PRODUCT_HIO_05_5 = 806;

        public const int PRODUCT_HIO_10_1 = 821;
        public const int PRODUCT_HIO_10_2 = 822;
        public const int PRODUCT_HIO_10_3 = 823;
        public const int PRODUCT_HIO_10_4 = 824;
        public const int PRODUCT_HIO_10_5 = 825;

        public const int PRODUCT_HIO_12_1 = 841;
        public const int PRODUCT_HIO_12_2 = 842;
        public const int PRODUCT_HIO_12_3 = 843;
        public const int PRODUCT_HIO_12_4 = 844;

        public const int PRODUCT_HIO_18_1 = 861;
        public const int PRODUCT_HIO_18_2 = 862;
        public const int PRODUCT_HIO_18_3 = 863;
        public const int PRODUCT_HIO_18_4 = 864;
        public const int PRODUCT_HIO_18_5 = 845;       //Exceptional HIO 12 ID for CORN BURNER as requirement of Firmware

        public const int PRODUCT_HIO_50_1 = 881;
        public const int PRODUCT_HIO_50_2 = 882;
        public const int PRODUCT_HIO_50_3 = 883;
        public const int PRODUCT_HIO_50_4 = 884;
        public const int PRODUCT_HIO_50_5 = 885;
        public const int PRODUCT_HIO_50_6 = 886;
        public const int PRODUCT_HIO_50_7 = 887;
        public const int PRODUCT_HIO_50_8 = 888;

        public const int PRODUCT_HIO_140_1 = 901;
        public const int PRODUCT_HIO_140_2 = 902;
        public const int PRODUCT_HIO_140_3 = 903;
        public const int PRODUCT_HIO_140_4 = 904;
        public const int PRODUCT_HIO_140_5 = 905;
        public const int PRODUCT_HIO_140_6 = 906;
        public const int PRODUCT_HIO_140_7 = 907;
        public const int PRODUCT_HIO_140_8 = 908;

        public const int PRODUCT_HIO_230_1 = 601;
        public const int PRODUCT_HIO_230_2 = 603;
        public const int PRODUCT_HIO_230_3 = 604;
        public const int PRODUCT_HIO_230_4 = 605;
        public const int PRODUCT_HIO_230_5 = 602;

        public const int PRODUCT_HIO_285_1 = 641;
        public const int PRODUCT_HIO_285_2 = 642;
        public const int PRODUCT_HIO_285_3 = 643;
        public const int PRODUCT_HIO_285_4 = 644;

        public const int PRODUCT_HIO_545_1 = 681;
        public const int PRODUCT_HIO_545_2 = 682;
        public const int PRODUCT_HIO_545_3 = 683;
        public const int PRODUCT_HIO_545_4 = 684;

        public const int PRODUCT_PRIZM_760_2 = 524;     //760 Keypad based

        public const int PRODUCT_RDIO_1612_A = 921;
        public const int PRODUCT_RDIO_1612_B = 922;
        public const int PRODUCT_RDIO_1612_C = 923;
        public const int PRODUCT_RDIO_1612_D = 924;

        public const int PRODUCT_RDIO_0808_A = 931;
        public const int PRODUCT_RDIO_0808_B = 932;
        public const int PRODUCT_RDIO_0808_C = 933;

        public const int PRODUCT_FIOA_0402_A = 701;


        //FP_CODE  R12  Haresh
        #region Ladder FP ProductID

        //FlexiPanel_Change_R1
        //HMI only Products


        public const int PRODUCT_PZ4030M_E = 1102;
        public const int PRODUCT_PZ4030MN_E = 1103;

        public const int PRODUCT_PZ4035TN_E = 1105;
        public const int PRODUCT_PZ4057M_E = 1106;

        public const int PRODUCT_PZ4057TN_E = 1108;
        public const int PRODUCT_PZ4084TN_E = 1109;
        public const int PRODUCT_PZ4121TN_E = 1110;

        //Release Models
        //// PLC models

        #region GSM_Sanjay
        public const int PRODUCT_GSM900 = 2001;
        #endregion GSM_Sanjay
        public const int PRODUCT_GSM901 = 2002;//GWY-901 SP
        public const int PRODUCT_GSM910 = 2003;//GWY_910_Suyash
        public const int PRODUCT_GWY00 = 2021;//GWY00_Change
        public const int PRODUCT_FL010 = 913;
        public const int PRODUCT_FL050 = 914;
        public const int PRODUCT_FL050_V2 = 920;//New Product FL050 V2 SammedB
        //public const int PRODUCT_FL051 = 911; //Remove_Product Vijay(06.02.14)
        public const int PRODUCT_FL011_S1 = 912;
        public const int PRODUCT_FL011_S4 = 969; //New_ProductAdd_Vijay
        public const int PRODUCT_FL011 = 915;
        #region New PLC Models AMIT
        public const int PRODUCT_FL011_S3 = 917;
        #endregion

        #region ToshibaUS PLC Models
        public const int PRODUCT_GPU288_3S = 941;
        public const int PRODUCT_GPU200_3S = 942;
        public const int PRODUCT_GPU232_3S = 943;
        public const int PRODUCT_GPU230_3S = 944; //New_Product_Addition Vijay(01.03.2013)
        public const int PRODUCT_GPU110_3S = 945; //New_Product_Addition Vijay(15.05.2014)
        public const int PRODUCT_GPU105_3S = 946;//New_Product_Addition Parag(9.12.2014)
        public const int PRODUCT_GPU120_3S = 947;//New_Product_Addition Parag(9.12.2014)
        public const int PRODUCT_GPU122_3S = 948; //New_Product_Addition Vijay(07.04.2015)
        #endregion
        ///////////////
        #region New FL100 Model SAMMED
        public const int PRODUCT_FL100 = 918;
        #endregion
        public const int PRODUCT_FL100_S0 = 919;//SS_FL100S0
        #region FL005-MicroPLC Base Module Series Vijay
        //Remove_Product Vijay
        //public const int PRODUCT_FL005_0604RP = 925;
        //public const int PRODUCT_FL005_0604RP0201L = 926;
        //
        public const int PRODUCT_FL005_0808RP = 927;
        public const int PRODUCT_FL005_0808RP0201L = 928;
        //FL005-MicroPLC Base Module Series Vijay1
        public const int PRODUCT_FL005_0604P = 951;
        public const int PRODUCT_FL005_0808P = 952;
        public const int PRODUCT_FL005_0808P0201L = 953;
        public const int PRODUCT_FL005_0604N = 954;
        public const int PRODUCT_FL005_0808N = 955;
        public const int PRODUCT_FL005_0808N0201L = 956;
        public const int PRODUCT_FL005_1616P0201L_S1 = 963;//New FL005 Product Addition Suyash
        //End
        #endregion
        public const int PRODUCT_FL055 = 970;//FL055_Product_Addition_Suyash
        #region FL005 Expandable PLC Series Vijay
        public const int PRODUCT_FL005_0808RP0402U = 957;
        public const int PRODUCT_FL005_1616RP0201L = 958;
        public const int PRODUCT_FL005_1616P0201L = 959;
        public const int PRODUCT_FL005_1616N0201L = 960;
        public const int PRODUCT_FL005_1616RP = 961;
        public const int PRODUCT_FL005_1616P = 962;
        #endregion
        public const int PRODUCT_FP2020_L0808RP_A0401L = 1171; //2020_Series_Vijay
        public const int PRODUCT_FP2020_L0808P_A0401L = 1172;
        public const int PRODUCT_FP2020_L0604P_A0401L = 1173;
        //4020 models////////////////////////
        public const int PRODUCT_FP4020MR = 1150;
        public const int PRODUCT_FP4020MR_L0808P = 1151;
        public const int PRODUCT_FP4020MR_L0808N = 1152;
        public const int PRODUCT_FP4020MR_L0808R = 1153;
        #region New_Product_Addition Vijay
        public const int PRODUCT_FP4020MR_L0808R_S3 = 1154;
        #endregion
        public const int PRODUCT_FP3020MR_L1608RP = 1155;//Suyash_FP3020MR_L1608RP_Prod_Addition
        // 4030 models ////////////////////
        public const int PRODUCT_FP4030MR = 1200;
        public const int PRODUCT_FP4030MR_E = 1209;
        public const int PRODUCT_FP4030MR_L1208R = 1210;
        public const int PRODUCT_FP4030MR_0808R_A0400_S0 = 1228;//PRODUCT_FP4030MR_0808R_A0400_S0_addition_sammed
        public const int PRODUCT_FP4030MR_L1210RP_A0402U = 1229; //PRODUCT_FP4030MR_L1210RP_A0402U Vijay
        public const int PRODUCT_FP4030MR_L1210P_A0402U = 1261; //PRODUCT_FP4030MR_L1210P_A0402U Vijay
        public const int PRODUCT_FP4030MR_L1210RP = 1262;//PRODUCT_FP4030MR_L1210RP Suyash
        public const int PRODUCT_FP4030MR_L1210P = 1263;//PRODUCT_FP4030MR_L1210P Suyash
        public const int PRODUCT_FP4030MR_L0808R_A0400U = 1264; //PRODUCT_FP4030MR_L0808R_A0400U Vijay
        #region New_Product_Addition M&R AMIT
        public const int PRODUCT_FP4030MT_HORIZONTAL = 1211;//FP4030MT_addition_AMIT
        public const int PRODUCT_FP4030MT_VERTICAL = 1212;
        public const int PRODUCT_FP4030MT_S1_HORIZONTAL = 1213;
        public const int PRODUCT_FP4030MT_S1_VERTICAL = 1214;
        #endregion
        public const int PRODUCT_FP4030MT_L0808RN_A0201 = 1215; // FP4030MT_L0808RN_A0201_addition_Vijay
        public const int PRODUCT_FP4030MT_L0808RP_A0201 = 1216; // FP4030MT_L0808RP_A0201_addition_Vijay
        public const int PRODUCT_FP4030MT_REV1 = 1218;//New Product addition FP4030MT- Rev 1
        public const int PRODUCT_FP4030MT_L0808RN = 1219; //New Product addition FP4030MT-L0808RN/RP Vijay
        public const int PRODUCT_FP4030MT_L0808RP = 1220; //New Product addition FP4030MT-L0808RN/RP Vijay
        public const int PRODUCT_FP4030MT_L0808RP_A0201L = 1226; //FP4030MT_L0808RN_A0201L_addition_sammed
        public const int PRODUCT_FP4030MT_L0808RP_A0201L_VERTICAL = 1227; //FP4030MT_L0808RP_A0201L(Vertical)_addition_sammed
        public const int PRODUCT_FP4030MT_L0808RP_A0201_S0 = 1217; //New Product Addition FP4030MT-L0808RP-A0201-S0 Vijay
        #region New Product Addtion FP4030MT_L0808P/FP4030MT_L0808P_A0201U Vijay
        public const int PRODUCT_FP4030MT_L0808P = 1301;
        public const int PRODUCT_FP4030MT_L0808P_A0201U = 1302;
        #endregion
        #region New FP4030MT Vertical Series Addition Vijay
        public const int PRODUCT_FP4030MT_REV1_VERTICAL = 1221;
        public const int PRODUCT_FP4030MT_L0808RN_A0201_VERTICAL = 1222;
        public const int PRODUCT_FP4030MT_L0808RP_A0201_VERTICAL = 1223;
        public const int PRODUCT_FP4030MT_L0808RN_VERTICAL = 1224;
        public const int PRODUCT_FP4030MT_L0808RP_VERTICAL = 1225;
        #endregion
        public const int PRODUCT_FP4030MT_L0808P_A0402L = 1303;//Suyash_Product_Addition_FP4030MT_L0808P_A0402L
        ///4035//////////////////////////////////
        public const int PRODUCT_FP4035T = 1231;
        public const int PRODUCT_FP4035T_E = 1230;
        #region New_Ethernet_Products_AMIT
        public const int PRODUCT_FP4035TN = 1232;
        public const int PRODUCT_FP4035TN_E = 1233;
        public const int PRODUCT_PRIZM_710_S0 = 1234;//SD_Product_Addition_Prizm710_so
        #endregion
        //4057//////////////
        public const int PRODUCT_FP4057T = 1251;
        public const int PRODUCT_FP4057T_E = 1250;

        #region New_Product_Addition_Herizomat AMIT
        public const int PRODUCT_FP4057T_S2 = 1252;
        #endregion

        #region New_Ethernet_Products_AMIT
        public const int PRODUCT_FP4057TN = 1253;
        public const int PRODUCT_FP4057TN_E = 1254;
        #endregion
        #region New_Product_Addition_AllBodySoltn AMIT
        public const int PRODUCT_FP4057T_E_S1 = 1255;
        #endregion
        #region New_Product_Addition_Vertical Vijay
        public const int PRODUCT_FP4057T_E_VERTICAL = 1256;
        #endregion
        ///////////////////////
        //Toshiba Models///////
        public const int PRODUCT_MICRO_PLC = 909; //TRSPUX10A
        public const int PRODUCT_MICRO_PLC_ETHERNET = 910; //TRSPUX10E
        public const int PRODUCT_TRPMIU0300L = 1330;
        public const int PRODUCT_TRPMIU0300A = 1331;
        public const int PRODUCT_TRPMIU0500L = 1350;
        public const int PRODUCT_TRPMIU0500A = 1351;
        //New Ethernet Models - SnehaK
        public const int PRODUCT_TRPMIU0300E = 1333;
        public const int PRODUCT_TRPMIU0500E = 1354;
        //End
        /// ////////////

        //Toshiba-Japan_Product
        public const int PRODUCT_TRPMIU0400E = 1343;
        public const int PRODUCT_TRPMIU0700E = 1373;
        //End

        public const int PRODUCT_FP4020M_L0808P_A = 1203;
        public const int PRODUCT_FP4020M_L0808P_A0400R = 1204;
        public const int PRODUCT_FP4020M_L0808N_A = 1205;
        public const int PRODUCT_FP4020M_L0808N_AR = 1206;

        public const int PRODUCT_FP4020M_L0808R_A = 1207;
        #region New_Product_Addition M&R AMIT
        //public const int  PRODUCT_FP4020MR_L0808R_A0400 = 1211;
        //public const int  PRODUCT_FP4030M_L1208R_A0400 = 1212;        
        //public const int  PRODUCT_FP4030MN_E = 1213;              
        #endregion
        //public const int PRODUCT_FP4057M_E = 1215;

        //public const int PRODUCT_FP4084TN_E = 1217; //New Product Addition FP4030MT-L0808RP-A0201-S0 Vijay


        public const int PRODUCT_FH9020MR = 1400;
        public const int PRODUCT_FH9020MR_L0808P = 1401;
        public const int PRODUCT_FH9020MR_L0808N = 1402;
        public const int PRODUCT_FH9020MR_L0808R = 1403;
        public const int PRODUCT_FH9030MR = 1411;
        public const int PRODUCT_FH9030MR_E = 1412;
        public const int PRODUCT_FH9030MR_L1208R = 1413;
        public const int PRODUCT_FH9035T_E = 1421;
        public const int PRODUCT_FH9035T = 1422;
        public const int PRODUCT_FH9057T_E = 1431;
        public const int PRODUCT_FH9057T = 1432;

        //Maple PLC Product ID
        public const int PRODUCT_PLC7008A_ML = 931;
        public const int PRODUCT_PLC7008A_ME = 932;
        //End

        //Maple HMI Product ID
        public const int PRODUCT_HMC7030A_M = 1531;
        public const int PRODUCT_HMC7030A_L = 1532;

        public const int PRODUCT_HMC7035A_M = 1551;

        public const int PRODUCT_HMC7057A_M = 1571;
        #region //Mapple Customization 2.0_Sanjay
        public const int PRODUCT_HMC7043A_M = 1543;
        public const int PRODUCT_HMC7070A_M = 1573;
        #endregion
        //End

        //End
        //END

        #region New FP Models-43&70 SnehalM
        //4030

        //public const int PRODUCT_FPW4030M = 1221; //New FP4030MT Vertical Series Addition Vijay
        //
        #region New FP3series product Addition Suyash
        public const int PRODUCT_FP3043T = 1701;//New FP3043T product Addition Suyash
        public const int PRODUCT_FP3043TN = 1703;//New FP3043TN product Addition Suyash
        public const int PRODUCT_FP3070T = 1711;//New FP3070T product Addition Suyash
        public const int PRODUCT_FP3070TN = 1713;//New FP3070TN product Addition Suyash
        public const int PRODUCT_FP3102T = 1721;//New FP3102T product Addition Suyash
        public const int PRODUCT_FP3102TN = 1723;//New FP3102TN product Addition Suyash
        #region SY-FP3_PlugableIO_Product_addition
        public const int PRODUCT_FP3070T_E = 1712;
        public const int PRODUCT_FP3070TN_E = 1715;
        public const int PRODUCT_FP3102T_E = 1722;
        public const int PRODUCT_FP3102TN_E = 1725;
        #endregion
        #region OIS3Series_Vijay
        public const int PRODUCT_OIS43E_Plus = 1803;
        public const int PRODUCT_OIS72E_Plus = 1813;
        public const int PRODUCT_OIS100E_Plus = 1823;
        #endregion
        #region FP3043_ExpansionSeries Vijay
        public const int PRODUCT_FP3043T_E = 1702;
        public const int PRODUCT_FP3043TN_E = 1704;
        #endregion
        #endregion
        #region Panasonic sammed 2.0
        public const int PRODUCT_GTXL07N = 1714;
        public const int PRODUCT_GTXL10N = 1724;
        #endregion
        ///4043//////////New Models added on date 30july10- SnehalM
        public const int PRODUCT_FP5043T = 1241;
        public const int PRODUCT_FP5043TN = 1242;
        public const int PRODUCT_FP5043T_E = 1240;
        public const int PRODUCT_FP5043TN_E = 1243;

        //4070////////New Models added on date 30july10- SnehalM
        public const int PRODUCT_FP5070T = 1271;
        public const int PRODUCT_FP5070TN = 1272;
        public const int PRODUCT_FP5070T_E = 1270;
        public const int PRODUCT_FP5070TN_E = 1273;
        public const int PRODUCT_FP5070T_E_S2 = 1274;//New FP5070T-E-S2 product Addition Suyash
        ///////////////////////
        //4121////////New Models added on date 13Sept10- SnehalM
        public const int PRODUCT_FP5121T = 1280;
        public const int PRODUCT_FP5121TN = 1281;
        public const int PRODUCT_FP5121TN_S0 = 1282;//Haresh_5121TN-SO
        ///////////////////
        #endregion

        #region Toshiba US products SnehalM
        //4020 models////////////////////////
        public const int PRODUCT_OIS12 = 1600;
        public const int PRODUCT_OIS10_Plus = 1603;
        // 4030 models ////////////////////
        public const int PRODUCT_OIS22_Plus = 1612;
        public const int PRODUCT_OIS20_Plus = 1613;

        ///4035//////////////////////////////////
        public const int PRODUCT_OIS55_Plus = 1630;
        //4057//////////////       
        public const int PRODUCT_OIS60_Plus = 1650;
        ///////////////////////
        //Toshiba_US New product Addition
        //4030MT//////////////                
        public const int PRODUCT_OIS40_Plus_HORIZONTAL = 1621;
        public const int PRODUCT_OIS40_Plus_VERTICAL = 1622;
        public const int PRODUCT_OIS42_Plus = 1623; //New_Product_Addition Vijay(01.03.2013)
        public const int PRODUCT_OIS42L_Plus = 1624; //New_Product_Addition Vijay(12.09.2013)
        //5043///////////////
        public const int PRODUCT_OIS45_Plus = 1642;
        public const int PRODUCT_OIS45E_Plus = 1643;
        //5070//////////////
        public const int PRODUCT_OIS70_Plus = 1672;
        public const int PRODUCT_OIS70E_Plus = 1673;
        //5121/////////////
        public const int PRODUCT_OIS120A = 1681;
        #endregion

        #region New FP3035 Product Series
        //New FP3035 Product Series 3035T-24/3035T-5 SP
        public const int PRODUCT_FP3035T_24 = 1130;
        public const int PRODUCT_FP3035T_5 = 1132;
        //New_Product_Addition_OIS24/OIS_25 Vijay
        public const int PRODUCT_OIS24 = 1634;
        public const int PRODUCT_OIS25 = 1635;
        //End
        #endregion
        #region PLC_Direct Vijay
        public const int PRODUCT_CPU_300 = 980;
        public const int PRODUCT_CPU_111_RP = 981;
        public const int PRODUCT_CPU_120_ARP = 982;
        public const int PRODUCT_CPU_100_P = 983;
        public const int PRODUCT_CPU_110_P = 984;
        public const int PRODUCT_CPU_120_AP = 985;
        public const int PRODUCT_CPU_100_N = 986;
        public const int PRODUCT_CPU_110_N = 987;
        public const int PRODUCT_CPU_120_AN = 988;
        #endregion
        #region Hitachi Hi-Rel Vijay
        public const int PRODUCT_HH5L_B0604D_P = 971;
        public const int PRODUCT_HH5L_B0808D_P = 972;
        public const int PRODUCT_HH5L_B1616D_P = 973;
        public const int PRODUCT_HH5L_B1616D_RP = 974;
        public const int PRODUCT_HH5L_B0201A0808D_P = 975;
        public const int PRODUCT_HH5L_B0201A1616D_RP = 976;
        public const int PRODUCT_HH5L_B0402AU0808D_RP = 977;
        public const int PRODUCT_HH1L_000 = 978;

        public const int PRODUCT_HH5P_H43_NS = 1901;
        public const int PRODUCT_HH5P_H43_S = 1902;
        public const int PRODUCT_HH5P_H70_NS = 1903;
        public const int PRODUCT_HH5P_H70_S = 1904;
        public const int PRODUCT_HH5P_H100_NS = 1905;
        public const int PRODUCT_HH5P_H100_S = 1906;
        public const int PRODUCT_HH5P_HP200808D_P = 1907;
        public const int PRODUCT_HH5P_HP301208D_R = 1908;
        public const int PRODUCT_HH5P_HP300201U0808_RP = 1909;
        public const int PRODUCT_HH5P_HP300201L0808_RP = 1910;
        public const int PRODUCT_HH5P_HP43_NS = 1911;
        public const int PRODUCT_HH5P_HP70_NS = 1912;
        #endregion
        #region Maple_ProductAddition_Vijay
        public const int PRODUCT_HMC2020A_F0604P0401 = 1581;
        public const int PRODUCT_HMC2020A_F0808P0401 = 1582;
        public const int PRODUCT_HMC2020A_F0808Y0401 = 1583;
        public const int PRODUCT_HMC3043A_M = 1561;
        public const int PRODUCT_HMC3070A_M = 1562;
        public const int PRODUCT_HMC3102A_M = 1563;

        public const int PRODUCT_MLC1_F0604P = 1001;
        public const int PRODUCT_MLC1_F0604N = 1002;
        public const int PRODUCT_MLC1_F0808P = 1003;
        public const int PRODUCT_MLC1_F0808N = 1004;
        public const int PRODUCT_MLC1_F0808Y = 1005;
        public const int PRODUCT_MLC1_F0808P0201 = 1006;
        public const int PRODUCT_MLC1_F0808N0201 = 1007;
        public const int PRODUCT_MLC1_F0808Y0201 = 1008;
        public const int PRODUCT_MLC1_F1616P0201 = 1009;
        public const int PRODUCT_MLC1_E1616P = 1010;
        public const int PRODUCT_MLC1_E1616Y = 1011;
        public const int PRODUCT_MLC1_E0808Y0402T = 1012;
        public const int PRODUCT_MLC1_E1616P0201 = 1013;
        public const int PRODUCT_MLC1_E1616N0201 = 1014;
        public const int PRODUCT_MLC1_E1616Y0201 = 1015;
        public const int PRODUCT_MLC2_E0404P0802T = 1016;
        public const int PRODUCT_MLC3_E = 1017;
        #endregion
        #endregion


        //constants for the object
        public const int RECTANGLE = 0;
        public const int CIRCLE = 1;
        public const int ROUNDRECTANGLE = 2;
        public const int ELLIPSE = 3;

        //File IDs Required for Download.
        public static byte SERIAL_LADDER_DNLD_FILEID = 0x77;
        public static byte SERIAL_FONT_DNLD_FILEID = 0x88;
        public static byte SERIAL_FIRMWARE_DNLD_FILEID = 0x99;
        public static byte SERIAL_APPLICATION_DNLD_FILEID = 0xEE;
        public static byte SERIAL_EXP_DNLD_FILEID = 0xE1;
        public static byte SERIAL_ANALOGEXP_DNLD_FILEID = 0xD1;

        public static byte ETHER_APP_LADD_DNLD_FILEID = 6;
        public static byte ETHER_LADD_FIRM_DNLD_FILEID = 5;
        public static byte ETHER_LADDER_DNLD_FILEID = 4;
        public static byte ETHER_FONT_DNLD_FILEID = 3;
        public static byte ETHER_APPLICATION_DNLD_FILEID = 2;
        public static byte ETHER_FIRMWARE_LADD_DNLD_FILEID = 1;
        public static byte ETHER_LOGG_UPLD_FILEID = 7;
        #region FP_Ethernet_Implementation-AMIT
        public static byte ETHER_ETHERNET_SETTINGS_DNLD_FILEID = 11;
        public static byte ETHER_APP_UPLD_FILEID = 6;
        public static byte PLC_STATUS_FILEID = 0x70;
        public static byte ETHER_LOGG_UPLD_FLASH_FILEID = 8;
        public static byte ETHER_HISTORICAL_ALARM_UPLD_FILEID = 13;
        #endregion
        //Ladder_Change_R10
        public static byte LADDER_UPLD_FILEID = 0x40;
        //End

        public static int ETHERNET_PORT_NUMBER = 5000;

        public static int SHAPE_TRACKER_SIZE = 4;
        //Kapil
        public static byte SERIAL_APPLICATION_UPLD_FILEID = 0xBB;
        public static byte SERIAL_LOGGED_UPLD_FILEID = 0xAA;
        public static byte SERIAL_HISTALARM_UPLD_FILEID = 0x22;	//Manik

        //Temporary down loadable file name.
        public static string TEMP_DOWNLOAD_FILENAME;
        // AMIT J-07 Extension change
        //public static string TEMP_UPLOAD_FILENAME = "c:\\upLoad.pzm";
        public static string TEMP_UPLOAD_FILENAME = "c:\\upLoad";
        public static string UPLOAD_LADDER_FILENAME = "UpldLadder.bin";

        // Serial Download Settings.
        public static int BAUDRATE = 115200;
        public static byte PARITY = 0;
        public static byte BITESIZE = 8;
        public static byte STOPBIT = 1;

        //FP Code Pravin Serial Monitor
        public static int ON_LINE_COMMUNICATION = 0;
        public static int SERIAL_PORT = 0;
        //End

        //Object Type refere file format for prizm ev3.
        public const int RECTANGLE_OBJECTTYPE = 10;
        public const int ELLIPSE_OBJECTTYPE = 11;
        public const int BITBUTTON_OBJECTTYPE = 61;
        public const int WORDBUTTON_OBJECTTYE = 63;
        public const int WORDLAMP_OBJECTTYPE = 64;
        public const int TEXTWIZARD_OBJECTTYPE = 41;
        public const int TEXTOBJECT_OBJECTTYPE = 1;
        public const int BITLAMP_OBJECTTYPE = 62;
        public const int BARGRAPH_OBJECTTYPE = 66;
        public const int LINE_OBJECTTYPE = 13;
        public const int ROUNDRECT_OBJECTTYPE = 12;
        public const int BITMAP_OBJECTTYPE = 0;
        public const int SINGLEBARGRAPH_OBJECTTYPE = 21;
        public const int TIME_OBJECTTYPE = 7;
        public const int DATE_OBJECTTYPE = 8;
        public const int ANALOGMETER_OBJECTTYPE = 65;
        public const int DATAENTRYREGISTER_OBJECTTYPE = 3;
        public const int DATAENTRYCOIL_OBJECTTYPE = 2;
        public const int DISPLAYDATACOIL_OBJECTTYPE = 4;
        public const int DISPLAYDATAREGISTER_OBJECTTYPE = 5;
        public const int DISPLAYDATAREGISTERTEXT_OBJECTTYPE = 6;
        public const int KEYPAD_OBJECTTYPE = 67;
        public const int KEYPADPASSWORD_OBJECTTYPE = 42;
        public const int ASCIIKEYPAD_OBJECTTYPE = 46;      //Added by Kapil 13th April 2007
        public const int EDITPASSWORD_OBJECTTYPE = 45;
        public const int TREND_OBJECTTYPE = 68;
        public const int ALARM_OBJECTTYPE = 16;
        public const int HISTORICALTREND_OBJECTTYPE = 69;
        public const int CUSTOMKEYPAD_OBJECTTYPE = 95;
        public const int KEYPADWITHTAG_OBJECTTYPE = 98; //Haresh Keypadwith tag change
        public const int SPEEDOMETER_OBJECTTYPE = 99; //SPMeter_KV
        public static ushort DEFAULT_NUMKEYPAD_SCREENHEIGHT_PRODUCT230 = 62;
        public static ushort DEFAULT_NUMKEYPAD_SCREENWIDTH_PRODUCT230 = 127;//128 //Issue_795 & 797 Vijay
        public static ushort DEFAULT_HEXKEYPAD_SCREENHEIGHT_PRODUCT230 = 62;
        public static ushort DEFAULT_HEXKEYPAD_SCREENWIDTH_PRODUCT230 = 127;//132 //Issue_795 & 797 Vijay
        public static ushort DEFAULT_BITKEYPAD_SCREENHEIGHT_PRODUCT230 = 44;
        public static ushort DEFAULT_BITKEYPAD_SCREENWIDTH_PRODUCT230 = 100;

        //KeyPad_Style_Change_Amit
        public static ushort DEFAULT_NUMKEYPAD_SCREENHEIGHT_PRODUCT_4030MT = 126; //127 //Issue_795 & 797 Vijay
        public static ushort DEFAULT_NUMKEYPAD_SCREENWIDTH_PRODUCT_4030MT = 62;  //63 //Issue_795 & 797 Vijay
        public static ushort DEFAULT_BITKEYPAD_SCREENHEIGHT_PRODUCT_4030MT = 126; //127 //Issue_795 & 797 Vijay
        public static ushort DEFAULT_BITKEYPAD_SCREENWIDTH_PRODUCT_4030MT = 62;  //63 //Issue_795 & 797 Vijay
        //

        public const int POLYLINE_OBJECTTYPE = 90;
        public const int POLYGON_OBJECTTYPE = 91;


        public static DataSet dsRecentProjectList = new DataSet(); //Configure List Data Set.
        public static DataSet dsRecentProjectsData = new DataSet(); //Recent Project List Data Set.
        public static string _lastCloseProjectPath = "";//SY_OpenFileDLG
        public static TagSelectionFilters stTagSelFilters;//tag_imprvmnts

        //Current culture string
        public static string CURRENTCULTURE = "";

        //power on task list bytes for default entries
        public static byte[] DEFAULTPOWERONTASKBYTES = new byte[6] { 4, 0, 1, 0, 1, 0 };

        //Static Draw Operation for object selection through Toolbar Buttons.
        //public static DrawingOperations DRAWOPERATION = DrawingOperations.NONE;
        //Static Draw Object 
        //public static DrawingObjects DRAWOBJECT = DrawingObjects.NOOBJECT;
        //draw x1
        public static int DRAWx1 = 0;
        //draw x2
        public static int DRAWx2 = 0;
        //draw y1
        public static int DRAWy1 = 0;
        //draw y2
        public static int DRAWy2 = 0;
        public static int _chBoxCheck = 0; //Vijay_Sub
        public static bool _ethernetCheck = false; //Issue_596 Vijay
        public static bool _isSoftwareOILDS = false; //ToshibaUS Vijay
        public static bool _checkPass = false; //OIL-DS_Password_Vijay
        public static bool _pictureShowHide = false; //Issue_813 & 815 Vijay
        public static bool stGroupType_editPara = false; //Issue_988 Vijay
        public static ArrayList varList1 = new ArrayList(); //Issue_1005 Vijay
        public static bool _asciiDT = false; //String_DataType_Vijay
        public static bool _isSoftwareFlexiSoft = false; //Vijay_21.11.13
        public static bool _isSoftwareMaple = false;//Sanjay_Maple2.25.22
        public static bool _checkProtocol = false; //ToshibaUS_ProtocolChanges Vijay
        public static ArrayList tagHistroy = new ArrayList(); //TagUsageHistory Issue2.2_677 Vijay
        public static string _softwareName = ""; //PLC_Direct Vijay
        public static bool _isSoftwareGTXLSoft = false; //Panasonic sammed 2.0
        public static bool _isSoftwareHitachi = false; //Hitachi Hi-Rel Vijay
        public static ArrayList _isTagsSelected = new ArrayList(); //Issue_1170 Vijay
        #region Import/Export_Modification Vijay
        public static bool _totalNoNodes = false;
        public static bool _importInternelTagsCom1Com2 = false;
        public static bool _importModbusSlaveTagsCom1Com2 = false;
        public static int _totalNoNodesInCSV = 0;
        public static int _noOfLoopCount = 0;
        public static bool _isNextClick = false;
        public static bool _isOKClick = false;
        public static bool _scrCom1 = false;
        public static bool _scrCom2 = false;
        public static bool _isMasterNodeAdded = false;
        #endregion
        public static bool _isModbusSlave_Ev3defined = false; //ExportTagGUI_Improvement Vijay
        public static bool _isCancelClick = false; //Import_Export_Improvement Vijay
        public static bool _isSlaveSelected = false; //CheckBoxAddedForTagExport Vijay
        public static bool _TagSelectionGUIFromDataLogger = false; //TagSearch_DataLoggerWindow Vijay
        public static bool _isNodeModbusMasterEdited = false; //Requirement_382_Appln_Conversion_Form_16word_to_1word Vijay
        public static bool _tagUsage = false; //TagUsage_Vijay
        #region Improvement_TagImport_Funct Vijay
        public static bool _ShowImportTags = false;
        public static bool _ShowImportTagsOK = false;
        public static int _totalNoTagsInCSV = 0;
        public static int _totalNoTagsCount = 0;
        public static ArrayList _totalTagList = new ArrayList();
        public static ArrayList _importTagList = new ArrayList();
        #endregion
        //Application Class Constants.
        public static string CONFIGFILENAME = "Prizm4conf.xml";

        //Minimum bytes for a screen.
        public static int MINIMUMSCREENBYTES = 68;

        //Protocol xml file path
        public static string strProtocolFileName = "ModelInformation.xml";

        //Port Information file
        public static string strPortInfoFileName = "PortInformation.xml";

        //Undo Action Count
        public static int UndoActionCount = 20;

        // Selected object count
        public static volatile int SelectedObjectCount = 0;

        private static ProductData _commconstantProductData = new ProductData();

        // Grid size
        public static int HorizontalGrid = 5;
        public static int VerticalGrid = 5;
        public static int GridStyle = 0;

        //Active Screen Number
        public static int iActiveScreenNumber = -1;
        public static int iActiveDragDropScreenNumber = -1;//Issue_189 SP

        //----Zooming Factor--------(9th jan 2007)
        private static float _commconstiZoomFactor = 100.00f;


        //Show Hide Animation Variables 
        public static bool ShowHideShowValueOn = false;
        public static bool ShowHideWithinRange = false;
        public static int ShowHideFromRange = 0;
        public static int ShowHideToRange = 0;
        //=====================
        //The following variables are used for new project with one default screen and one rectangle object
        //umesh 13 jan 2006.
        public static byte TotalNoOfObject = 1;
        public static byte DefaultObjectBackColor = 26;
        public static byte DefaultObjectThickness = 1;
        public static byte btPrizm4Version = 40;
        public static System.Drawing.Point DefaultObjectTopLeft = new System.Drawing.Point(10, 10);
        public static System.Drawing.Point DefaultObjectBottomRight = new System.Drawing.Point(100, 100);
        public static byte DefaultObjectNumber = 1;
        public static byte DefaultObjectType = 10;//for rectangle.
        public static byte DefaultObjectZLevel = 0;
        public static byte DefaultObjectBorder = 1;
        public static ushort DefaultEv3ProjectHSCounter = 1766;
        public static ushort DefaultEv3ProjectHSTimmer = 80;
        public static ushort DefaultEv3ProjectPID = 0;
        public static ushort DefaultEv3ProjectChannel = 0;
        public static ushort DefaultEv3ProjectASCIIComm = 0;
        //public static ushort DefaultEv3ProjectLanguageID = 0;
        public static short DefaultEv3ProjectPOnTaskListSize = 6;
        public const string Rectangular = "Generic Square";
        public const string Circular = "Circle";
        public const string RoundRectangle = "Rounded Rectangle";
        public const string Invisible = "Invisible";
        public const string ChangeColor = "Change_Color";
        public const string Bitmap = "Bitmap";
        public static byte ColorIndex = 0;
        public static byte PatternIndex = 0;
        public const string Task = "Task";
        public const string ButtonStyle = "ButtonStyle";
        public const string LampStyle = "LampStyle";
        public const string Style = "Style";

        public const string ScreenColor = "ScreenColor";
        public const string ScreenNumber = "ScreenNumber";
        public const string Number = "Number";
        public const string ScreenName = "ScreenName";
        public const string PopUpScreenNumber = "PopUpScreenNumber";
        public const string PopUpScreenName = "PopUpScreenName";
        public const string Text = "Text";
        public const string SampleDefaultText = "Sample Text";//Issue344
        public const string Pattern = "Pattern";
        public const string PatternColor = "PatternColor";
        public const string BackgroundColor = "BackgroundColor";
        public const string TextColor = "TextColor";
        public const string Font = "Font";
        public const string Description = "Description";
        public const string Category = "Category";
        public const string On = "On";
        public const string Off = "Off";
        public const string Simulation = "Simulation";
        public const string Label = "Label";
        public const string LabelX = "X-Label";//XYPlot
        public const string LabelY = "Y-Label";//XYPlot
        public const string RLabel = "RLabel";
        public const string Top = "Top";
        public const string Bottom = "Bottom";
        public const string OnText = "OnText";
        public const string OnTextPattern = "OnTextPattern";
        public const string OnTextPatternColor = "OnTextPatternColor";
        public const string OnTextBackgroundColor = "OnTextBackgroundColor";
        public const string OnTextColor = "OnTextColor";
        public const string OnTextFont = "OnTextFont";
        public const string OffText = "OffText";
        public const string OffTextPattern = "OffTextPattern";
        public const string OffTextPatternColor = "OffTextPatternColor";
        public const string OffTextBackgroundColor = "OffTextBackgroundColor";
        public const string OffTextColor = "OffTextColor";
        public const string OffTextFont = "OffTextFont";
        public const string LabelText = "LabelText";
        public const string LabelPattern = "LabelPattern";
        public const string LabelPatternColor = "LabelPatternColor";
        public const string LabelBackgroundColor = "LabelBackgroundColor";
        public const string LabelTextColor = "LabelTextColor";
        public const string LabelPosition = "LabelPosition";
        public const string LabelTextFont = "LabelTextFont";
        public const string FeedbackTag = "FeedbackTag";
        public const string Border = "Border";
        public const string Previous = "Previous";
        public const string Next = "Next";
        public const string GoTo = "GoTo";
        public const string GoToScreen = "GoTo Screen";
        public const string GoToNextScreen = "Goto Next Screen";
        public const string GoToPreviousScreen = "Goto Previous Screen";
        public const string GoToPopUpScreen = "Popup";
        public const string HidePopUpScreen = "X";
        public const string Set = "Set";
        public const string Reset = "Reset";
        public const string Momentary = "Momentary";//ShitalG_PER466
        public const string Toggle = "Toggle";
        public const string HoldOn = "Hold On";
        public const string HoldOff = "Hold Off";
        public const string TurnBiton = "Turn Bit On";
        public const string TurnBitoff = "Turn Bit Off";
        public const string ToggleBit = "Toggle Bit";
        public const string MomentaryBit = "Momentary Bit";//ShitalG_PER466
        public const string FileName = "FileName"; //punit 17th apr '07
        public const string FileNameOff = "FileNameOff";//punit 20th apr '07
        public const string FromPictureLibraryON = "FromPictureLibraryON";//punit
        public const string FromPictureLibraryOFF = "FromPictureLibraryOFF";//punit
        public const string CannotOpenBitmap = "Cannot open Bitmap"; //punit 20th apr '07
        public const string BinaryFile = "Logger.BIN";    //punit
        public const string CSVFile = "Logg.csv";   //punit
        public const string CSVFile_New = "Logger.csv";   //Displyloggdata_with_single_file_change_sammed_2.3
        public const string CustomKeypad = "Custom Keypad";//CR839 Sheetal
        public const string HistAlarmBinaryFile = "HistAlarmData.BIN";    //manik
        public const string HistAlarmCSVFile = "HistAlarm.csv";   //manik
        public const string Error = "Error";
        public static bool IsOverlappingChecked = false;
        public static string FeedBackTagValue = "";
        #region PR890 1472 Sheetal
        public static string strImportAlarmLogErrFile = "";
        public static string strImportAlarmSeverityErr = "";
        public static string strImportAlarmIDErr = "";
        public static string strImportAlarmErrorsFound = "";
        public static string strImportAlarmTextErr = "";
        #endregion
        public static bool blFileErrMsgFlag = false; //PR1037 Sheetal
        public static bool blwaitdlgFlag = false; //datalogger_change_sammed

        #region WindowsFontSupport_Kapil
        public static ArrayList BitMapAddressDataTT = new ArrayList();
        public static ArrayList BitMapObjectAddressTT = new ArrayList();

        public static ArrayList BitMapAddressDataCoil = new ArrayList();
        public static ArrayList BitMapObjectAddressCoil = new ArrayList();

        //FastKaps
        public static int[] WindowsUnsignedFontsUsedInApplication = new int[10];
        public static int[] WindowsHexFontsUsedInApplication = new int[10];
        public static int[] WindowsASCIIFontsUsedInApplication = new int[10];
        public static int CurrenmtScreenStartPosition = 0;//Issue/2016-17/1555_KV

        //public static string strFontName = "Times New Roman";
        public static string strFontName = "Arial";//ShitalG_Default FontName Change
        public static int fontIndex = 0;
        #endregion

        #region True type font application size reduction change SP
        public static Hashtable rdeHtBitMapAddressDataTT = new Hashtable();
        public static Hashtable rdeASCIIHtBitMapAddressDataTT = new Hashtable();
        public static Hashtable rdeHEXHtBitMapAddressDataTT = new Hashtable();
        #endregion

        //End

        #region SnehaK_Alarm
        public static bool blFiveBySeven = false;
        public static bool blSevenByFourteen = false;
        public static bool blTenByFourteen = false;
        #endregion

        //punit
        public const string iNumber = "iNumber";
        public const string uiNumber = "uiNumber";
        public const string fNumber = "fNumber";
        public const string DfNumber = "DfNumber";//LREAL_New_SY
        public const string hNumber = "hNumber";
        public const string bNumber = "bNumber";
        public const string BCDNumber = "BCDNumber";
        public const string FbTagAddress = "FBTagAddress";
        public const string FbTagName = "FBTagName";
        //
        public const string Delay = "Delay";
        public const string Wait = "Wait";
        public static string NextAlarm = "Next Alarm";
        public static string PrevAlarm = "Previous Alarm";
        public static string AckAlarm = "Ack Alarm";
        public static string AckAllAlarms = "Ack All Alarms";
        public static string AcknowledgeAlarm = "Acknowledge Alarm";
        public static string AcknowledgeAllAlarms = "Acknowledge All Alarms";


        ///////
        //Nilam
        // public static string CopyPLCToPrizm = "Copy Prizm/PLC Block To Prizm Block";
        //public static string CopyPrizmToPLC = "Copy Prizm Block To Prizm/PLC Block";
        //
        public static string WriteValueToTag = "";//Umesh 15-Feb. Write Value To TagInitialize on prizmLoad.
        public static string AddAConstantValueToATag = "";//Add Constant Value To Tag
        public static string SubtractAConstantValueFromATag = "";//"Subtract Constant Value From Tag";
        public static string AddTagBToTagA = "";//Add TagB To TagA
        public static string SubtractTagBFromTagA = "";// "Sub TagB From TagA";
        public static string CopyTagBToTagA = "";//"Copy TagB To TagA";
        public static string SwapTagAAndTagB = "";// "Swap TagA And TagB";
        public static string CopyTagToSTR = ""; //"Switch Screen From Tag";
        public static string CopyTagToLED = "";//"Copy Tag To LED";
        public static string CopyPrizmToPLC = "";//Copy Prizm Block To Prizm Or PLC Block
        public static string CopyPLCToPrizm = "";//Copy PLC To Prizm
        public static string CopyRTCToPLC = "";//Copy RTC To PLC
        public static string ExecutePLCLogicBlock = "";//Execute PLC Logic Block
        //FP_CODE Shweta USBDataUpload 07.10.09
        public static string USBDataLogUpload = ""; //USBDataLogUpload 
        public static string USBHostUpload = ""; //USB_Host_Upload Vijay
        public static string SDCardUpload = ""; //SS_SDCardUpload

        /////////////
        //punit (Variables used in compilation error)
        public static string StrAlarm;
        public static string StrArc;
        public static string StrBitbutton;
        public static string StrBitlamp;
        public static string StrBitmap;
        public static string StrDataEntryCoil;
        public static string StrDataEnteryRegister;
        public static string StrDate;
        public static string StrDisplayDataCoil;
        public static string StrDisplayDataRegister;
        public static string StrDisplayDataText;
        public static string StrEllipse;
        public static string StrGoto;
        public static string StrGroup;
        public static string StrHistoricalTrends;
        public static string StrHoldon;
        public static string StrHoldoff;
        public static string StrLine;
        public static string StrMultibargraph;
        public static string StrNext;
        public static string StrNumericalKeypad;
        public static string StrPie;
        public static string StrPolygon;
        public static string StrPolyLine;
        public static string StrPrev;
        public static string StrPopup;
        public static string StrRectangle;
        public static string StrRoundRectangle;
        public static string StrReset;
        public static string StrSet;
        public static string StrMomentary;//ShitalG_PER466
        public static string StrSingleBargraph;
        public static string StrTextobject;
        public static string StrTime;
        public static string StrTextwizard;
        public static string StrToggle;
        public static string StrTrend;
        public static string StrWordbutton;
        public static string StrWordlamp;
        public static string StrAnalogmeter;
        public static string StrWriteValueToTag;
        public static string StrAddValueToTag;
        public static string StrSubTractValueToTag;
        public static string StrAddTags;
        public static string StrSubTags;
        public static string StrPrintData;
        public static string StrNumkeypad;
        public static string StrAsciikeypad;
        public static string StrCustomkeypad;
        public static string StrShape;
        public static string StrXYPlot;//XYPlot
        //
        public const string ScreenType = "ScreenType";
        public const string TopLeft = "TopLeft";
        public const string BottomRight = "BottomRight";
        public const string Size = "Size";
        public const string Password = "Password";
        public const string ScreenProperties = "ScreenProperties";
        public const string TemplateProperties = "TemplateProperties"; //manisha
        public const string ScreenPrintColumns = "ScreenPrintColumns";
        public const string CharactersToPrint = "CharactersToPrint";
        public const string AssociatedScreen = "AssociatedScreen";
        public const string NoofTemplates = "NoofTemplates";
        public const string UseTemplate = "UseTemplate";
        public const string Template1 = "Template1";
        public const string Template2 = "Template2";
        public const string Template3 = "Template3";
        public const string Template4 = "Template4";
        public const string Template5 = "Template5";
        public const string Template6 = "Template6";
        public const string Template7 = "Template7";
        public const string Template8 = "Template8";
        public const string Template9 = "Template9";
        public const string Template10 = "Template10";
        public const string Base = "Base";
        public const string GSM = "GSM";//GWY_900_SanjayY
        public const string PopUp = "Popup";
        public const string Template = "Template";
        public const string Bookmark = "Bookmark";
        public const string ScreenStatus = "ScreenMemoryStatus";
        public const string NumericKeypad = "Numeric Keypad";
        public const string HexKeypad = "Hex Keypad";
        public const string BitKeypad = "Bit Keypad";
        public const string AsciiKeypad = "Ascii Keypad";
        //public const string AsciiKeypad = "ASCII Keypad";

        public const string Name = "Name";
        public const string ShowHideSelect = "ShowHideSelect";
        public const string Direction = "Direction";
        public const string FillPattern = "FillPattern";
        #region FP_AnimationChange_AMIT
        public const string EnableTaskBit = "EnableTaskBit";
        public const string EBTagAddress = "EBTagAddress";
        public const string EBTagName = "EBTagName";
        #endregion
        public const string FlashSelect = "FlashSelect";
        public const string ColorSelect = "ColorSelect";
        public const string IECColorSelect = "IECColorSelect";//SD_IECColour_Animation        
        public const string ShowHide = "ShowHide";
        public const string Flash = "Flash";
        public const string ColorAnimation = "ColorAnimation";
        public const string LineThickness = "LineThickness";//LineThickness Width Support_ShitalG
        public const string TagList = "TagList";
        public const string LowRange = "LowRange";
        public const string HighRange = "HighRange";
        public const string BitShowWhen = "BitShowWhen";
        public const string RegShowWhen = "RegShowWhen";
        public const string KeypadLabel = "Key Pad";
        public const string MeterLabel = "Not enough size to Draw";
        public const string Bar = "Bar";
        public const string Axis = "Axis";
        public const string AxisColor = "AxisColor";
        public const string AxisLabel = "AxisLabel";
        public const string AxisLabelText = "AxisLabelText";
        public const string AxisLabelBackgroundColor = "AxisLabelBackgroundColor";
        public const string AxisLabelTextColor = "AxisLabelTextColor";
        //FP_CODE Shweta24.07.09
        public const string FillColor = "FillColor";
        public const string LineColor = "LineColor";
        public const string FillPatternColor = "FillPatternColor";
        public const string FontColor = "FontColor";
        public const string BackColor = "BackColor";
        public const string ActiveAndAcknowledgeAlarmColor = "ActiveAndAcknowledgeAlarmColor";
        public const string ActiveAndUnacknowledgeAlarmColor = "ActiveAndUnacknowledgeAlarmColor";
        public const string InActiveAndUnacknowledgeAlarmColor = "InActiveAndUnacknowledgeAlarmColor";
        public const string ScrollbarStyle = "ScrollbarStyle";
        public const string AlarmWindowInterColoumnDistance = "AlarmWindowInterColoumnDistance";
        public const string TextBorder = "TextBorder";
        //FP_CODE Shweta24.07.09
        public const string DisplayRange = "DisplayRange";
        public const string DisplayRangeProperties = "DisplayRangeProperties";
        public const string DisplayDivisions = "DisplayDivisions";
        public const string DivisionsProperties = "DivisionsProperties";
        public const string ShowLabel = "ShowLabel";
        public const string BargraphLabelFont = "BargraphLabelFont";
        public const string LabelAtBottom = "LabelAtBottom";
        public const string LabelColor = "LabelColor";
        public const string LabelFontColor = "LabelFontColor";
        public const string ColorPatchPropertiesBrowser = "ColorPatchPropertiesBrowser";
        public const string BorderColor = "BorderColor";
        public const string Language = "Language";
        public const string StateText = "StateText";

        public const string AlarmOrder = "AlarmOrder";//SY 28-6-2013

        //New FP3035 Product Series_V2.3_Issue_522/523/499 object boundry SP
        public const string NewSize = "NewSize";
        //End
        public const string Accesslevelpropscr = "AccessLevelToShow";//AccessLevel_ScreenProp_SY
        public const int NoFlash = 0;
        public const int SlowFlash = 128;
        public const int MediumFlash = 129;
        public const int FastFlash = 130;

        public static short DEFAULT_POPUP_SCREEN_TOPLEFT_X = 0;
        public static short DEFAULT_POPUP_SCREEN_TOPLEFT_Y = 0;
        public static ushort DEFAULT_POPUP_SCREEN_HEIGHT = 180;
        public static ushort DEFAULT_POPUP_SCREEN_WIDTH = 237;
        public static ushort DEFAULT_SCREEN_SCRATCHPAD_AREA = 768;//150;
        public static short MaximumFormSize = 1088;//PR_1410 Nilam

        /////////////////////
        public static ushort DEFAULT_NUMKEYPAD_SCREENHEIGHT_PRODUCT290 = 135;
        public static ushort DEFAULT_NUMKEYPAD_SCREENWIDTH_PRODUCT290 = 130;
        public static ushort DEFAULT_HEXKEYPAD_SCREENHEIGHT_PRODUCT290 = 155;
        public static ushort DEFAULT_HEXKEYPAD_SCREENWIDTH_PRODUCT290 = 160;
        public static ushort DEFAULT_BITKEYPAD_SCREENHEIGHT_PRODUCT290 = 75;
        public static ushort DEFAULT_BITKEYPAD_SCREENWIDTH_PRODUCT290 = 120;
        public static ushort DEFAULT_ASCIIKEYPAD_SCREENHEIGHT_PRODUCT290 = 200;
        public static ushort DEFAULT_ASCIIKEYPAD_SCREENWIDTH_PRODUCT290 = 212;

        public static ushort DEFAULT_NUMKEYPAD_SCREENHEIGHT_ALLPRODUCTS = 162;
        public static ushort DEFAULT_NUMKEYPAD_SCREENWIDTH_ALLPRODUCTS = 157;
        public static ushort DEFAULT_HEXKEYPAD_SCREENHEIGHT_ALLPRODUCTS = 189;
        public static ushort DEFAULT_HEXKEYPAD_SCREENWIDTH_ALLPRODUCTS = 194;
        public static ushort DEFAULT_BITKEYPAD_SCREENHEIGHT_ALLPRODUCTS = 81;
        public static ushort DEFAULT_BITKEYPAD_SCREENWIDTH_ALLPRODUCTS = 120;
        public static ushort DEFAULT_ASCIIKEYPAD_SCREENHEIGHT_ALLPRODUCTS = 218;
        public static ushort DEFAULT_ASCIIKEYPAD_SCREENWIDTH_ALLPRODUCTS = 292;


        //Default Change For FP5070 & FP5121 Series Product Vijay(17.9.12)       
        public static ushort DEFAULT_NUMKEYPAD_SCREENHEIGHT_PRODUCT5XXX = 375;
        public static ushort DEFAULT_NUMKEYPAD_SCREENWIDTH_PRODUCT5XXX = 375;
        public static ushort DEFAULT_HEXKEYPAD_SCREENHEIGHT_PRODUCT5XXX = 375;
        public static ushort DEFAULT_HEXKEYPAD_SCREENWIDTH_PRODUCT5XXX = 375;
        public static ushort DEFAULT_BITKEYPAD_SCREENHEIGHT_PRODUCT5XXX = 150;
        public static ushort DEFAULT_BITKEYPAD_SCREENWIDTH_PRODUCT5XXX = 300;
        public static ushort DEFAULT_ASCIIKEYPAD_SCREENHEIGHT_PRODUCT5XXX = 360;
        public static ushort DEFAULT_ASCIIKEYPAD_SCREENWIDTH_PRODUCT5XXX = 400;
        public static ushort DEFAULT_POPUP_SCREEN_HEIGHT_PRODUCT5XXX = 375;
        public static ushort DEFAULT_POPUP_SCREEN_WIDTH_PRODUCT5XXX = 375;

        //Default Change For FP5043 Series Product Vijay(17.9.12) 
        public static ushort DEFAULT_NUMKEYPAD_SCREENHEIGHT_PRODUCT5X43 = 225;
        public static ushort DEFAULT_NUMKEYPAD_SCREENWIDTH_PRODUCT5X43 = 225;
        public static ushort DEFAULT_HEXKEYPAD_SCREENHEIGHT_PRODUCT5X43 = 225;
        public static ushort DEFAULT_HEXKEYPAD_SCREENWIDTH_PRODUCT5X43 = 225;
        public static ushort DEFAULT_BITKEYPAD_SCREENHEIGHT_PRODUCT5X43 = 100;
        public static ushort DEFAULT_BITKEYPAD_SCREENWIDTH_PRODUCT5X43 = 200;
        public static ushort DEFAULT_ASCIIKEYPAD_SCREENHEIGHT_PRODUCT5X43 = 210;//250; //Issue_410 Vijay
        public static ushort DEFAULT_ASCIIKEYPAD_SCREENWIDTH_PRODUCT5X43 = 305;//350;  //Issue_410 Vijay
        public static ushort DEFAULT_POPUP_SCREEN_HEIGHT_PRODUCT5X43 = 225;
        public static ushort DEFAULT_POPUP_SCREEN_WIDTH_PRODUCT5X43 = 225;
        /////////////////////


        ///////////////////
        public const ushort MAX_TOUCH_SCREENS = 64990;
        public const ushort MAX_KEYPAD_SCREENS = 65534;
        public const ushort TOTAL_POPUP_SCREENS = 534;
        public const ushort START_POPUP_SCREEN = 65001;

        public static int m_gBlockType = 0;//sammed(check logic button)

        public static int selIECBlockType = 0; //Add_IECBlockType_From_ProjectProperty_GUI Vijay

        //Manisha added this for Template  Screens.
        public const ushort END_TEMPLATE_SCREENS = 65000;
        public const ushort START_TEMPLATE_SCREEN = 64991;
        public const ushort MAX_TEMPLATE_SCREENS = 10;

        public static string DOWNLOAD_FONT_FILENAME = "prizmFont.bin";
        public static string DOWNLOAD_LADDER_FILENAME = "ladder.bin";
        public static string DOWNLOAD_FIRMWARE_FILENAME = "firmware.abs";
        public static string DOWNLOAD_FHWT_FILENAME = "fhwt.bin";

        /// ////////////////////////////
        public static string DefaultBlockName = "Block"; //it is used in WriteBlockTagName method of Block Class.
        ///
        public static ArrayList BitMapAddressData = new ArrayList();
        public static ArrayList BitMapObjectAddress = new ArrayList();

        public static int MaximumIntensityOfRed = 240;
        public static int MaximumIntensityOfGreen = 240;
        public static int MaximumIntensityOfBlue = 240;
        public static int DEFAULT_COLOR_SUPPORT = 262144;

        //Kapil
        public const int ADVANCEDPICTURE_OBJECTTYPE = 96;
        public const int XYPlot_OBJECTTYPE = 97;//XYPlot
        public static int communicationStatus = 0;

        public static bool downloadSucess = false;

        //Tulika 12th June
        public const int ERROR_FILE_NOT_FOUND = 2;
        public const int ERROR_ACCESS_DENIED = 5;

        public const string XML_NAME_TAG = "Name"; //_resouremanager.GetString("XML_NAME_TAG", System.Reflection.Assembly.GetExecutingAssembly ());
        public const string XML_PATH_TAG = "Path";
        public const string XML_MODEL_TAG = "model";
        public const string XML_BMP_NAME_TAG = "BMPFile";
        public const string XML_PROJCET_TAG = "Project";
        public const string XML_INITDATA_TAG = "initdata";
        public const string XML_PROJCET_DATA_TAG = "ProjectData";
        public const string XML_SPLASHSCREEN_TAG = "SplashScreen";
        public const string XML_PLC_MODEL_DATA_TAG = "ModelData";
        public const string XML_PRODUCT_TAG = "Product";
        public const int MAX_NO_RECENT_PROJ = 4;
        public const string FirstOperation = "FirstOperation";
        public const string SecondOperation = "SecondOperation";
        public const string DataType = "DataType";
        public const string FirstOperand = "FirstOperand";
        public const string SecondOperand = "SecondOperand";
        public const string Format = "Format";
        public const string Length = "Length";
        public const string LeadingZerosBlank = "LeadingZerosBlank";
        public const string FlashAnimation = "FlashAnimation";
        public const string MeterBackground = "MeterBackground";
        public const string MeterColor = "MeterColor";
        public const string MeterBGColor = "MeterBGColor";
        public const string ColorRange = "ColorRange";
        public const string ColorPatches = "ColorPatches";
        public const string FirstColorPatchProperties = "FirstColorPatchProperties";
        public const string SecondColorPatchProperties = "SecondColorPatchProperties";
        public const string ThirdColorPatchProperties = "ThirdColorPatchProperties";
        public const string FourthColorPatchProperties = "FourthColorPatchProperties";
        public const string FifthColorPatchProperties = "FifthColorPatchProperties";
        public const string StartAngle = "StartAngle";
        public const string EndAngle = "EndAngle";
        public const string StartValue = "StartValue";
        public const string EndValue = "EndValue";
        public const string iStartValue = "iStartValue";
        public const string iEndValue = "iEndValue";
        public const string hStartValue = "hStartValue";
        public const string hEndValue = "hEndValue";
        public const string uiStartValue = "uiStartValue";
        public const string uiEndValue = "uiEndValue";
        public const string bStartValue = "bStartValue";
        public const string bEndValue = "bEndValue";
        public const string fMaximumDisplayRange = "fMaximumDisplayRange";
        public const string fMinimumDisplayRange = "fMinimumDisplayRange";
        public const string iMaximumDisplayRange = "iMaximumDisplayRange";
        public const string iMinimumDisplayRange = "iMinimumDisplayRange";
        public const string uiMaximumDisplayRange = "uiMaximumDisplayRange";
        public const string uiMinimumDisplayRange = "uiMinimumDisplayRange";
        public const string hMaximumDisplayRange = "hMaximumDisplayRange";
        public const string hMinimumDisplayRange = "hMinimumDisplayRange";
        public const string bMaximumDisplayRange = "bMaximumDisplayRange";
        public const string bMinimumDisplayRange = "bMinimumDisplayRange";
        public const string MeterStyle = "MeterStyle";
        public const string PatchHighLimit = "PatchHighLimit";
        public const string PatchLowLimit = "PatchLowLimit";
        public const string NumericKey0 = "0";
        public const string NumericKey1 = "1";
        public const string NumericKey2 = "2";
        public const string NumericKey3 = "3";
        public const string NumericKey4 = "4";
        public const string NumericKey5 = "5";
        public const string NumericKey6 = "6";
        public const string NumericKey7 = "7";
        public const string NumericKey8 = "8";
        public const string NumericKey9 = "9";
        public const string NumericKeyA = "A";
        public const string NumericKeyB = "B";
        public const string NumericKeyC = "C";
        public const string NumericKeyD = "D";
        public const string NumericKeyE = "E";
        public const string NumericKeyF = "F";
        public const string SignKey = "+/-";
        public const string ClearDataEntry = "CLR";
        public const string AcceptDataEntry = "ENT";
        public const string CancelDataEntry = "ESC";
        public const string IncreaseDigitBy1 = "^";
        public const string DecreaseDigitBy1 = "v";
        public const string MoveCursorLeft = "<-";
        public const string MoveCursorRight = "->";
        public const string IncreaseValueBy1 = "INC";
        public const string DecreaseValueBy1 = "DCR";
        public const string TurnBitOn = "ON";
        public const string TurnBitOff = "OFF";
        public const string SetRTC = "Set RTC";
        public const string PrintData = "Print Data";
        public const string KeysSpecificTask = "Key's Specific Task";
        public const string GotoPopUpScreen = "Goto Popup Screen";
        public const string TagAddress = "TagAddress";
        public const string TagName = "TagName";
        public const string TagA = "TagA";//8th feb
        public const string TagB = "TagB";
        public const string TagAadderess = "TagAadderess";
        public const string TagBadderess = "TagBadderess";
        public const string OnTextBorderStyle = "OnTextBorderStyle";
        public const string OffTextBorderStyle = "OffTextBorderStyle";
        public const string LabelBorderStyle = "LabelBorderStyle";
        public const string BorderStyle = "BorderStyle";
        public const string Keypad = "Keypad";

        public const string FrameAlignment = "FrameAlignment";
        public const string TopLeftColor = "TopLeftColor";
        public const string BottomRightColor = "BottomRightColor";
        public const string TopRightColor = "TopRightColor";
        public const string BottomLeftColor = "BottomLeftColor";
        public const string FrameWidth = "FrameWidth";

        public const string OnTextTopLeftColor = "OnTextTopLeftColor";
        public const string OnTextBottomRightColor = "OnTextBottomRightColor";
        public const string OnTextTopRightColor = "OnTextTopRightColor";
        public const string OnTextBottomLeftColor = "OnTextBottomLeftColor";
        public const string OnTextFrameWidth = "OnTextFrameWidth";
        public const string OnTextFrameAlignment = "OnTextFrameAlignment";

        public const string OffTextTopLeftColor = "OffTextTopLeftColor";
        public const string OffTextBottomRightColor = "OffTextBottomRightColor";
        public const string OffTextTopRightColor = "OffTextTopRightColor";
        public const string OffTextBottomLeftColor = "OffTextBottomLeftColor";
        public const string OffTextFrameWidth = "OffTextFrameWidth";
        public const string OffTextFrameAlignment = "OffTextFrameAlignment";
        public const string strAddValueToTag = "Add Value To Tag";//punit 6th feb 2007
        public const string strSubtractValueFromTag = "Sub Value From Tag"; //punit 6th feb 2007
        public const string strAddTagBToTagA = "Add TagB To TagA"; //punit 8th feb 2007
        public const string strSubTagBFromTagA = "Subtract TagB From TagA"; //punit 8th feb 2007
        public static ushort DefaultEv3ProjectLanguageID = 50;    //manisha  27th apr '07        
        public const string Id = "Id";//Manisha 21-May
        public const string Ethernet_UploadEthernetSettingBinaryFile = "EthUpld.bin";
        public const string strSubtractContsValueFromTag = "Subtract Constant Value From Tag";
        #region Configuring_Ethernet_Setting_At_RunTime_Vijay
        public const string ShowEthernetConfigurationScreen = "Show Ethernet Configuration Screen";
        public const string ConfirmEthernetConfigurationScreenSetting = "Confirm Ethernet Setting";
        public const string CancelEthernetConfigurationScreenSetting = "Cancel Ethernet Setting";
        #endregion
        #region AccessLevel Vijay
        public const string ShowLoginScreen = "Show Login Screen";
        public const string Logout = "Log Out";
        public const string ChangeLoginScreenPassword = "Change Password"; //AccessLevel_Phase2 Vijay
        public const string CopyScreenToSDCard = "Copy Screen data to SD Card";  //SD_Card_Functionality Vijay
        #endregion
        public static int[,] NumberOfKeysInRowAndColumn =
		{
			{4,4},  //1
			{3,4},  //2
			{5,4},  //3
			{5,5},  //4
			{5,3},  //5
			{4,2},  //6
			{5,1},  //7
			{3,1},  //8
			{4,4},  //9
		};

        //Replace kapil
        public static string[,] KeysTitle = {
						{ "1", "2", "3", "+/-", "4", "5", "6", "CLR", "7", "8", "9", "", "0", "0", "", "ENT","","","","","","","","","" },
						{ "1", "2", "3", "4", "5", "6", "7", "8", "9", "CLR", "0", "ENT","","","","","","","","","","","","","" },
						{ "1", "2", "3", "A", "B","4", "5", "6", "C","D", "7", "8", "9", "E","F", "+/-", "0", "ESC", "CLR","ENT","","","","","" },
						{ "1", "2", "3", "A", "B","4", "5", "6", "C","D", "7", "8", "9", "E","F", "+/-", "0", "^","CLR","ESC","<-","->","v", "ENT","ENT" },
						{ "<-", "->", "INC", "CLR", "CLR", "^", "v", "DCR", "", "", "0", "1", "ESC", "0", "ENT" ,"","","","","","","","","",""},
						{ "<-", "->", "CLR", "CLR", "^", "v", "ENT", "ENT" ,"","","","","","","","","","","","","","","","",""},
						{ "<-", "^", "v", "->", "ENT", "", "", "" ,"","","","","","","","","","","","","","","","",""},
						{ "ON", "OFF", "ENT", "", "", "", "", "" ,"","","","","","","","","","","","","","","","",""},
						{ "0", "1", "2", "3", "4", "5", "6", "7" ,"8","9","CLR","ENT","ABORT","","","","","","","","","","","",""},
						{ "", "", "", "", "", "", "", "" ,"","","","","","","","","","","","","","","","",""}
				};


        //kapil
        public static string[,] AsciiKeysTitle = {
						{ "~", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "_", "+", "<", ">", ":","A","B","C","D","E","F","G","H","I" ,"J","K","L" ,"M","N","O" ,"P","Q","R" ,"S","T","U" ,"V","W","X" ,"Y","Z","{" ,"}","|","?" ,"\"","","" ,"","","" ,"","","" ,""},
						{ "`","1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "-", "=",",",".",";","a","b","c","d","e","f" ,"g","h","i","j","k" ,"l","m","n","o","p" ,"q","r","s","t","u" ,"v","w","x","y","z" , "[","]","\\","/","'","CLR","Home","End","SP","BS" ,"<<",">>","Shift","ENT" },
						{ "0", "1", "2", "3", "4", "5", "6", "7" ,"8","9",".","ENT", "","","","","","","","","","" ,"","","","","" ,"","","","","" ,"","","","","" ,"","","","","" , "","","","","","","","","","" ,"","","",""}
				};


        public static KeyStyle[,] KeysDefaultStyles = {
//                      {KeyStyle.1,   KeyStyle.2,   KeyStyle.3,            KeyStyle.4,          KeyStyle.5,          KeyStyle.6,   KeyStyle.7,             KeyStyle.8,            KeyStyle.9,             KeyStyle.10,            KeyStyle.11,            KeyStyle.12,            KeyStyle.13,            KeyStyle.14,            KeyStyle.15,            KeyStyle.16,            KeyStyle.17,  KeyStyle.18,  KeyStyle.19,  KeyStyle.20,  KeyStyle.21,   KeyStyle.22,  KeyStyle.23,  KeyStyle.24,          KeyStyle.25}
						{KeyStyle.ONE, KeyStyle.ONE, KeyStyle.ONE,          KeyStyle.ONE,        KeyStyle.ONE,        KeyStyle.ONE, KeyStyle.ONE,           KeyStyle.ONE,          KeyStyle.ONE,           KeyStyle.ONE,           KeyStyle.ONE ,          KeyStyle.THREE_IN_ONE,  KeyStyle.TWO_IN_ONE,    KeyStyle.TWO_IN_ONE,    KeyStyle.THREE_IN_ONE,  KeyStyle.THREE_IN_ONE , KeyStyle.ONE, KeyStyle.ONE, KeyStyle.ONE, KeyStyle.ONE, KeyStyle.ONE , KeyStyle.ONE, KeyStyle.ONE, KeyStyle.ONE,         KeyStyle.ONE},
						{KeyStyle.ONE, KeyStyle.ONE, KeyStyle.ONE,          KeyStyle.ONE,        KeyStyle.ONE,        KeyStyle.ONE, KeyStyle.ONE,           KeyStyle.ONE,          KeyStyle.ONE,           KeyStyle.ONE,           KeyStyle.ONE,           KeyStyle.ONE,           KeyStyle.ONE,           KeyStyle.ONE,           KeyStyle.ONE,           KeyStyle.ONE ,          KeyStyle.ONE, KeyStyle.ONE, KeyStyle.ONE, KeyStyle.ONE, KeyStyle.ONE , KeyStyle.ONE, KeyStyle.ONE, KeyStyle.ONE,         KeyStyle.ONE},
						{KeyStyle.ONE, KeyStyle.ONE, KeyStyle.ONE,          KeyStyle.ONE,        KeyStyle.ONE,        KeyStyle.ONE, KeyStyle.ONE,           KeyStyle.ONE,          KeyStyle.ONE,           KeyStyle.ONE,           KeyStyle.ONE,           KeyStyle.ONE,           KeyStyle.ONE,           KeyStyle.ONE,           KeyStyle.ONE,           KeyStyle.ONE ,          KeyStyle.ONE, KeyStyle.ONE, KeyStyle.ONE, KeyStyle.ONE, KeyStyle.ONE , KeyStyle.ONE, KeyStyle.ONE, KeyStyle.ONE,         KeyStyle.ONE},
						{KeyStyle.ONE, KeyStyle.ONE, KeyStyle.ONE,          KeyStyle.ONE,        KeyStyle.ONE,        KeyStyle.ONE, KeyStyle.ONE,           KeyStyle.ONE,          KeyStyle.ONE,           KeyStyle.ONE,           KeyStyle.ONE,           KeyStyle.ONE,           KeyStyle.ONE,           KeyStyle.ONE,           KeyStyle.ONE,           KeyStyle.ONE ,          KeyStyle.ONE, KeyStyle.ONE, KeyStyle.ONE, KeyStyle.ONE, KeyStyle.ONE , KeyStyle.ONE, KeyStyle.ONE, KeyStyle.TWO_IN_ONE , KeyStyle.TWO_IN_ONE},
						{KeyStyle.ONE, KeyStyle.ONE, KeyStyle.ONE,          KeyStyle.TWO_IN_ONE, KeyStyle.TWO_IN_ONE, KeyStyle.ONE, KeyStyle.ONE,           KeyStyle.ONE,          KeyStyle.FOUR_IN_ONE,   KeyStyle.FOUR_IN_ONE,   KeyStyle.ONE,           KeyStyle.ONE,           KeyStyle.ONE,           KeyStyle.FOUR_IN_ONE,   KeyStyle.FOUR_IN_ONE,   KeyStyle.ONE ,          KeyStyle.ONE, KeyStyle.ONE, KeyStyle.ONE, KeyStyle.ONE, KeyStyle.ONE , KeyStyle.ONE, KeyStyle.ONE, KeyStyle.ONE,         KeyStyle.ONE},
						{KeyStyle.ONE, KeyStyle.ONE, KeyStyle.TWO_IN_ONE,   KeyStyle.TWO_IN_ONE, KeyStyle.ONE,        KeyStyle.ONE, KeyStyle.TWO_IN_ONE,    KeyStyle.TWO_IN_ONE,   KeyStyle.ONE,           KeyStyle.ONE,           KeyStyle.ONE,           KeyStyle.ONE,           KeyStyle.ONE,           KeyStyle.ONE,           KeyStyle.FOUR_IN_ONE,   KeyStyle.ONE ,          KeyStyle.ONE, KeyStyle.ONE, KeyStyle.ONE, KeyStyle.ONE, KeyStyle.ONE , KeyStyle.ONE, KeyStyle.ONE, KeyStyle.ONE,         KeyStyle.ONE},
						{KeyStyle.ONE, KeyStyle.ONE, KeyStyle.ONE,          KeyStyle.ONE,        KeyStyle.ONE,        KeyStyle.ONE, KeyStyle.ONE,           KeyStyle.ONE,          KeyStyle.ONE,           KeyStyle.ONE,           KeyStyle.ONE,           KeyStyle.ONE,           KeyStyle.ONE,           KeyStyle.ONE,           KeyStyle.ONE,           KeyStyle.ONE ,          KeyStyle.ONE, KeyStyle.ONE, KeyStyle.ONE, KeyStyle.ONE, KeyStyle.ONE , KeyStyle.ONE, KeyStyle.ONE, KeyStyle.ONE,         KeyStyle.ONE},
						{KeyStyle.ONE, KeyStyle.ONE, KeyStyle.ONE,          KeyStyle.ONE,        KeyStyle.ONE,        KeyStyle.ONE, KeyStyle.ONE,           KeyStyle.ONE,          KeyStyle.ONE,           KeyStyle.ONE,           KeyStyle.ONE,           KeyStyle.ONE,           KeyStyle.ONE,           KeyStyle.ONE,           KeyStyle.ONE,           KeyStyle.ONE ,          KeyStyle.ONE, KeyStyle.ONE, KeyStyle.ONE, KeyStyle.ONE, KeyStyle.ONE , KeyStyle.ONE, KeyStyle.ONE, KeyStyle.ONE,         KeyStyle.ONE},
						{KeyStyle.ONE, KeyStyle.ONE, KeyStyle.ONE,          KeyStyle.ONE,        KeyStyle.ONE,        KeyStyle.ONE, KeyStyle.ONE,           KeyStyle.ONE,          KeyStyle.ONE,           KeyStyle.ONE,           KeyStyle.ONE,           KeyStyle.ONE,           KeyStyle.TWO_IN_ONE,    KeyStyle.TWO_IN_ONE,    KeyStyle.ONE,           KeyStyle.ONE ,          KeyStyle.ONE, KeyStyle.ONE, KeyStyle.ONE, KeyStyle.ONE, KeyStyle.ONE , KeyStyle.ONE, KeyStyle.ONE, KeyStyle.ONE,         KeyStyle.ONE}
				};

        //FL100_LoggerMode
        public static string[] ListofLogMod = { "Power up", "Start/Stop Time", "Key Task", "Logging with run time Frequency", "Bit task", "Event based" };
        public static string[] ListofLogModFL100 = { "Power up", "Start/Stop Time", "Bit task", "Event based" };
        //End

        //Datalogger_different_datatype_sammed
        public static string[] ListofLogModDataType = { "2 Byte (Int)", "4 Byte (Int)", "4 Byte (Float)", "2 Byte (SInt)", "4 Byte (SInt)" };
        public static string[] ListofLogModDataType_New = { "2 Byte (Int)", "4 Byte (Int)", "2 Byte (SInt)", "4 Byte (SInt)", "4 Byte (Float)" };//Datalogger_different_datatype_sammed_new
        //public static string[] ListofLogModDataType_New = { "2 Byte (Int)", "2 Byte (SInt)", "4 Byte (Int)", "4 Byte (SInt)", "4 Byte (Float)" };
        //end

        //umesh 28-Aug-06.
        private static DataSet dsPLCInformation = new DataSet();
        #region PLCSupport_FromXML_Vijay
        private static DataSet dsReadPLCSupportedModelList_Native = new DataSet();
        private static DataSet dsReadPLCSupportedModelList_IEC = new DataSet();
        #endregion
        public static byte WORDWIZARD_MAX_STATES = 32;
        public static byte WORDWIZARD_MIN_STATES = 1;

        public const string TextVal = "TextVal";
        public const string TextBackgroundColor = "TextBackgroundColor";
        public const string TasksList = "TasksList";
        public const string Picture = "User defined Images";
        public const string FromPictureLibrary = "FromPictureLibrary";//punit
        public const string FromPictLibrary = "From Picture Library"; //punit
        //punit 19th july
        public const string DummyOnTextBackGroundColor = "DummyOnTextBackGroundColor";
        public const string DummyOnTextTextColor = "DummyOnTextTextColor";
        public const string DummyOnTextPattern = "DummyOnTextPattern";
        public const string DummyOnTextPatternColor = "DummyOnTextPatternColor";
        public const string DummyOnTextBorderStyle = "DummyOnTextBorderStyle";
        public const string DummyOnTextTopLeftcolor = "DummyOnTextTopLeftcolor";
        public const string DummyOnTextBottomRightcolor = "DummyOnTextBottomRightcolor";
        public const string DummyOnTextTopRightcolor = "DummyOnTextTopRightcolor";
        public const string DummyOnTextBottomLeftcolor = "DummyOnTextBottomLeftcolor";

        public const string DummyOffTextBackGroundColor = "DummyOffTextBackGroundColor";
        public const string DummyOffTextTextColor = "DummyOffTextTextColor";
        public const string DummyOffTextPattern = "DummyOffTextPattern";
        public const string DummyOffTextPatternColor = "DummyOffTextPatternColor";
        public const string DummyOffTextBorderStyle = "DummyOffTextBorderStyle";
        public const string DummyOffTextTopLeftcolor = "DummyOffTextTopLeftcolor";
        public const string DummyOffTextBottomRightcolor = "DummyOffTextBottomRightcolor";
        public const string DummyOffTextTopRightcolor = "DummyOffTextTopRightcolor";
        public const string DummyOffTextBottomLeftcolor = "DummyOffTextBottomLeftcolor";

        //
        public const string Collection = "( Collection )";
        public const string WordLampText = "Word Lamp";
        public const string WordButtonText = "Word Button";
        public const string LowLimit = "LowLimit";
        public const string HighLimit = "HighLimit";
        public const string WordButtonStatePropertiesBrowser = "WordButtonStatePropertiesBrowser";
        public const string WordLampStatePropertiesBrowser = "WordLampStatePropertiesBrowser";
        public static int HorizontalScreenScrollBarValue = 0;
        public static int VerticalScreenScrollBarValue = 0;
        //umesh 25-Sep-06.
        public static ushort usColorAnimationMinValue;
        public static ushort usColorAnimationMaxValue;

        public static string[] AlarmTimeFormats;
        public static string[] AlarmYNFormat;
        public static string AlarmDateFormat = "";

        public static string AlarmTextStringDisplay = "";
        public static string AlarmAlarmNumberDisplay = "";
        public static string AlarmOtherDisplay = "";

        // Kapil 29-March
        //View Password screen change  //Search other changes by this text
        public static bool PasswordScreenDisplay = false; // False 

        //Manisha 30-April-07
        public static List<LanguageInformation> LanguageIdList = new List<LanguageInformation>();


        //Kapil 28th May 2007
        public const string TitleText = "TitleText";
        public const string DisplayAreaCheck = "DisplayAreaCheck";
        public const string KeypadDispAreaBackColor = "KeypadDispAreaBackColor";
        public const string KeypadDispAreaTextColor = "KeypadDispAreaTextColor";
        public const string KeySelect = "KeySelect";
        public const string KeyBackColor = "KeyBackColor";
        public const string KeyTextColor = "KeyTextColor";
        public const string KeysGapHeight = "KeysGapHeight";
        public const string KeysGapWidth = "KeysGapWidth";
        public const string LabelBackColor = "LabelBackColor";
        public const string LabelCheck = "LabelCheck";
        //Manisha 23May-07
        public const int MaxNoofLanguages = 9;
        public static ushort MaxLimitOfColorAnimation = 999;
        public const float FontSize5X7 = 7.2F;
        public const float FontSize7x14 = 9.7F;
        public const float FontSize10x14 = 14.3F;
        public const float FontSize20x24 = 27;
        /////////////Node Info
        public static string IBMCommunication = "";//samir 27th july



        public static int iKeyPadTouchGridWidth = 12;
        public static int iKeyPadTouchGridHeight = 16;
        public static bool blSimulation = false;
        public static bool blSaveForSimulation = false;
        public static bool blLanguageChanged = false; // if screen mdi is activeted after change in project language from prizm mdi
        public static string TTFontNameUsedForPrizmFont = "Courier New";
        public static string strImportTagStartCharacter = "$";
        public static string strImportNodeStartCharacter = "@";
        public static string strImportTagsFileStartCharacter = "#";
        public static string strImportTagsCSV = ",";
        public static string strImportTagsCSVSeperator = ",\"";//PR1554 Sheetal
        public static string strImportTagsVersion = "Version";
        public static string strImportTagsDate = "Date";
        public static string strImportTagsTotalTags = "TotalTags";
        public static string strNewLineCharacter = "\n";
        public static string strImportNodeNamePresent = "";
        public static string strImportNodeAddAutoGenerated = "";
        public static string strImportNodeInvalidProtocol = "";
        public static string strImportNodeInvalidModel = "";
        public static string strImportNodeProtocolDefinedOnPort = "";
        public static string IBMComm = ""; //punit 10th oct
        public static string G9SP_ProtocolName = "G9SP-N20S";// G9SP_SAFETY_CONTROLLER Ethernet Support SP
        public static string PrizmUnit = ""; //punit 11th oct
        public static string Com1Com2 = ""; //punit 11th oct
        public static string strImportNodePrizmUnitDefaultNode = "";
        public static string strImportTagErrWrongTagHeader = "";
        public static string strImportTagErrInvalidTagColumnCount = "";
        public static string strImportTagErrInvalidTagInformation = "";
        public static string strImportTagErrDuplicateTagAddress = "";
        public static string strImportTagErrDuplicateTagName = "";
        public static string strImportTagErrWrongTagAddress = "";
        public static string strImportTagErrWrongTagName = "";
        public static string strImportTagErrWrongTagType = "";
        public static string strImportTagErrWrongNoofBytes = "";
        public static string strImportTagErrWrongPrefix = "";
        public static string strImportTagErrWrongNodeName = "";
        public static string strImportTagErrWrongPortName = "";
        public static string strImportTagErrTagLimitReached = "";
        public static string strImportTagErrTagAddedWithAutoGeneratedTagName = "";
        public static string strImportTagErrTagCannotReplace = "";
        public static string strImportTagErrTagReplaced = "";
        public static string strExportLogFileName = "";
        public static string strStringNotSupport = ""; //Issue_232 Vijay
        public static string strTagMappingError = ""; //Import/Export_ModbusTags_Issue809_Vijay
        public static string strProjectType = "ProjectType";//Import-Export tag change SP
        public static List<string> lstNodeColInformation = new List<string>();
        public static List<string> lstTagColInformation = new List<string>();
        #region ss_Issue426
        public static List<string> lstTagColInformation_Native = new List<string>();
        public static String strGroupName_Global = "(Global)";
        public static String strGroupName_Retain = "(Retain)";
        public static string strImportTagErrDupNativeTagAddress = "";
        public static string strImportTagErrDuplicateNativeAddress = "";
        public static string strStatustagname = "Status Tag : Com";
        #endregion

        //WebServer change
        #region WebServer Change
        public static string ApplicationPath = "";
        public const string strHTTPStatuscode = "HTTP/1.1 200 OK\r\n";
        public const string strHTTPStatuscodeBadRequest = "HTTP/1.1 400 OK\r\n";
        public const string strHTTPResponseHeader = "Cache-Control: no-cache, must-revalidate\r\n";
        public const string strHTTPExpiresHeader = "Expires: Sat, 26 Jul 1997 05:00:00 GMT\r\n";
        public const string strHTTPStatuscodeUnauthorizedUser = "HTTP/1.1 401 OK\r\n";
        public const string strHTTPStatuscodePageNotFound = "HTTP/1.1 404 OK\r\n";
        public const string strHTTPStatuscodeForbidden = "HTTP/1.1 403 OK\r\n";
        public const string strHTTPStatuscodeNoContent = "HTTP/1.1 204 OK\r\n";
        public const string strHTMLContentType = "Content-type: text/html\r\n\r\n";
        public const string strJSContentType = "Content-type: text/javascript\r\n\r\n";
        public const string strXMLContentType = "Content-type: text/xml\r\n\r\n";
        public const string strBMPContentType = "Content-type: image/bmp\r\n\r\n";
        public const string strJPGContentType = "Content-type: image/gpeg\r\n\r\n";
        public const string strPNGContentType = "Content-type: image/png\r\n\r\n";
        public const string strGIFContentType = "Content-type: image/gif\r\n\r\n";

        public static string strUserName = "";
        public static string strPassword = "";
        public static string strConfirmPW = "";
        public static string strHeaderText = "Web server v1.00";
        public static bool bEnableWebserver = false;
        #region //Hide_Header_Navigation_SY
        public static bool bEnableWebserverHeader = false;
        public static bool bEnableWebserverNavigation = false;
        public static bool bEnableWebserverBorder = false;
        #endregion
        public static int WEB_SCREEN_WIDTH = 800;
        public static int WEB_SCREEN_HEIGHT = 600;
        public static ushort DefaultWebscreenNumber = 64000;
        public static Hashtable _sequencialScreenMap = new Hashtable();
        public static Hashtable _noOfTagsPerScreen = new Hashtable();
        public static Hashtable _noOfTagsPerXML = new Hashtable();
        public static int _totalImageCnt = 2;
        public static int _totalXMLCnt = 3;
        public const string strHeaderPageName = "h9.html";
        public const string strLinksPageName = "h10.html";
        public static int _htmlWebscreenCnt = 11;
        public static int _selectedTab = 0;
        #endregion

        //End

        /// <summary>
        /// The strings required for byte selection as per the register coil type of
        /// operator panel.
        /// </summary>
        public static string strDataRegister = "Data Register";
        public static string strRetentiveRegister = "Retentive Register";
        public static string strSystemRegister = "System Register";
        public static string strInternalRegister = "Internal Register";
        public static string strInputRegister = "Input Register";
        public static string strOutputRegister = "Output Register";
        public static string strTimmerRegister = "Timmer Register";
        public static string strCounterRegister = "Counter Register";
        //public static Debug debugObject = new Debug();
        public static String strLangSequenceErrMsg = "strLangSequenceErrMsg";
        //Suraj IEC Task Tag Validation
        public static string strIECTaskName = "";
        //Alarm and Data Logger Tag Validation		
        public static string strIECAlarmDataLogger = "";
        public static string[] strRenuUDFB = { "AnalogTotalizer" };//Analog Totalizer Change Suraj

        #region SnehaK_Alarm
        public static string[] arrDigits = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "?" };//, " " };
        public static string[] arrSpecialCharacters = { "/", ".", ",", "-", ":" };//, " " }; 
        public static string[] arrStrings = { "Y", "N", "YES", "NO" };
        //public static string strSpace = " ";
        public static string strAlarmParamText = "";
        public static int iAlarmRectHeight = 0;
        public static Font fAlarmParam;
        public static StringFormat objAlarmStringFormat;
        public static byte bSelShapeFont = 0; //Issue_1458
        #endregion

        //Manisha
        #region
        /// <summary>
        /// The Messages getting repeated for multiple objects so aadded the following flags.
        /// </summary>
        public static bool ScreenNumberMsg = false;
        public static bool FlashAnimLowRangeMsg = false;
        public static bool FlashAnimHighRangeMsg = false;
        public static bool ColorAnimLinColorMsg = false;
        public static bool ColorAnimFillColorMsg = false;
        public static bool ShowHideAnimLowRangeMsg = false;
        public static bool ShowHideAnimHighRangeMsg = false;
        public static bool SingleBarGraphMaximumRangeMsg = false;
        public static bool SingleBarGraphMinimumRangeMsg = false;
        public static bool MultiBarGraphMsg = false;
        public static bool MultiBarGraphMinimumRangeMsg = false;
        public static bool RepeatMsg = false;

        #endregion

        #region Bitmap Nilam

        public static string NoImage = "NoImage";
        public static string NoImageDotBmp = "NoImage.bmp";
        public static string OnlyDotBmp = ".bmp";
        public static string OnlyDotBMP = ".BMP";
        public static string OnlyDotbmp = ".Bmp";
        public static string OnlyDotBmP = ".BmP";
        public static string OnlyDotBMp = ".BMp";
        public static string OnlyDotbMP = ".bMP";
        public static string OnlyDotbmP = ".bmP";
        public static string OnlyDotbMp = ".bMp";

        public static string UnderscoreTBmp = "_T.bmp";
        public static string UnderscoreT = "_T";
        public static string UnderscoreTPzp = "_T.pzp";
        public static string OnlyDotPzp = ".pzp";
        public static string UnderscoreTNoImage = "NoImage_T";
        public static string PictureFolder = "Picture";
        public static string Slash = "\\";

        #endregion


        #region AdvancedAlarm       Punam
        //Punam 10/10/08 
        public static string strAbbrevations = "Abbrevations:";
        public static string strAlarmType = "Alarm Type:";
        public static string strAlmType1 = "i) 0- 16 Consecutive Words: Each bit of each";
        public static string strAlmType2 = "word is";
        public static string strAlmType3 = "an alarm";
        public const string AlarmType = "AlarmType";
        public static string strAlmType4 = "ii)1- 16 Random Words: Each bit of each";
        public static string strAlmType5 = "word is";
        public static string strAlmType6 = "an alarm";

        public static string strAlmType7 = "iii)2- 256 Discrete Alarms: Each alarm is";
        public static string strAlmType8 = "either a bit";
        public static string strAlmType9 = "alarm [on/off]";
        public static string strAlmType10 = "or a word alarm";

        public static string strAlmMsg = "Alarm Action:";
        public static string strAlmMsg1 = "i) 0- Erase previous Alarms and starts logging from beginning";
        public static string strAlmMsg2 = "ii)1- Stop Logging";
        public static string strAlmMsg3 = "iii)2- Stop Logging and Display Error Message";

        public static string strHist = "History:";
        public static string strHist1 = "i)No- No History";
        public static string strHist2 = "ii)Yes_1- History With Acknowledge";
        public static string strHist3 = "iii)Yes_2- History Without Acknowledge";

        public static string strIsAlmAssign = "Alarm Assign";
        public static string strAlmType = "Alarm Type:";
        public static string strAlm = " for Alarm";
        public static string strErr = "Error";
        public static string strWarning = "Warning";
        public static string strFileExtErr = "File does not exist";
        public static string strFileOpenErr = "The file is used by another process,please close it.";
        public static string strAlmTxtLen = "Alarm Text is too long for Alarm No";
        public static string strTagBitPresent = "tag is not present in Tag Database";//PR1472 Sheetal

        public static string strBitNum = "BitNumber should not be repeated";
        public static string strTagGrp = "GroupNumber is already present";
        public static string strIsAlmAssignMsg = "Alarm Assign Text should be in Yes/No formats";
        public static string strLogMsg = "Log Text should be in No, Yes_1 and Yes_2 formats";
        public static string strAlmSeverityMsg1 = "Severity should be 0 to 9 only";//PR794 Sheetal
        public static string strAlmSeverityMsg2 = "Severity should be a number";
        //public static string strAlmPrintMsg = "Print Text should be in Yes/No Formats";
        public static string strAlmPrintMsg = "Print Text should be either 0 or 1";//PR1472
        public static string strAlmColBlankHeadingMsg = "Heading text should not be blank.";//PR1472
        public static string strAlmCondOperatorMsg = "Conditional operator should be valid";
        public static string strAlmIDPresent = "Alarm ID should be Positive Integer value";
        //public static string strAlmTypeMsg = "Alarm Type can not be change";
        public static string strAlmTypeMsg = "Current project Alarm Type, Alarm Action and Acknowledge type must be same as in import alarm database";
        public static string strAlmTypeMsg1 = "Current project Alarm Type is not same as in import alarm database";
        public static string strAlmAckMsg = "Current project Alarm Acknowledge Type is not same as in import alarm database";
        public static string strAlmActionMsg = "Current project Alarm Action Type is not same as in import alarm database";
        //public static string strColHeadingErrMsg = "You can not change any column heading text"
        public static string strAlmColHeadingMsg = "Heading text should not change for";
        public static string strLangErrMsg = "Please make sure languages in current project are same as in import alarm database";
        public static string strAlmTypeTxt = "Text Alarm Type is not found";
        public static string strTagPresent = "Tag is not present in Tag Database";
        public static string strTagMsg = "Acknowledge tag can not be null";
        public static string strExpFileMsg = "No such record is found in";
        public static string strFileErrFormat = "Invalid file format...!";
        public static string strFileErr = "No Such File Exists";
        public static string strNull = "NULL";

        public static string strTitle = "Title:";
        public static string strGlInfo = "Global Information";
        public static string strAlmScanTime = "Alarm Scan Time[0-5000ms]:";
        public static string strAlmActionTxt = "Alarm Action if Memory is Full:";
        public static string strAlmErrMsg = "Alarm Error Message:";
        public static string strAutoAck = "Alarm Auto Ack:";
        public static string strAlmProp = "Alarm Properties";
        public static string SequenceIDs = "SequenceIDs";
        //Alarm Error Message
        #endregion

        #region _LineTagChange
        public static bool RunTime_LineProperty = false;
        public static PropertySort SortType = PropertySort.CategorizedAlphabetical;
        #endregion

        #region New FP Models-43&70 SnehalM
        public static char dblCote = '"';
        #endregion

        #region SnehaK_Alarm
        public static int AlarmFontIndex = 0;
        #endregion


        #region FactoryAppl   Snehal
        //snehal added this for Factory Application
        public const ushort START_COMM_FACTORY_SCREEN = 64901;
        public const ushort END_COMM_FACTORY_SCREEN = 64910;
        public const ushort MAX_COMM_FACTORY_SCREEN = 10;

        public const ushort START_SYSTEM_FACTORY_SCREEN = 64911;
        public const ushort END_SYSTEM_FACTORY_SCREEN = 64950;
        public const ushort MAX_SYSTEM_FACTORY_SCREEN = 40;

        public const ushort START_FHWT_FACTORY_SCREEN = 64951;
        public const ushort END_FHWT_FACTORY_SCREEN = 64980;
        public const ushort MAX_FHWT_FACTORY_SCREEN = 30;

        // Snehal added string for names default factory  screen
        public const string ModeSelectionMenu = "Mode Selection Menu ";
        public const string SystemSetupMenu1 = "SystemSetupMenu-1";
        public const string SystemSetupMenu2 = "SystemSetupMenu-2";
        public const string ScreenSaverTime = "Screen Saver Time";
        public const string BrightnessControl = "Brightness Control";
        public const string ContrastControl = "Contrast Control";
        public const string Serial1CommnPara = "Serial Port 1";
        public const string Serial2Commnpara = "Serial Port 2";
        public const string DateTimeSet = "Set RTC";
        public const string SystemInfo = "System Information";
        public const string ApplnErase = "Appllication Erase";
        public const string FirmwareErase = "Firmware Erase";
        public const string RetentiveMemoryErase = "Retentive Erase";
        public const string Beeper = "Beeper Settings";
        public const string Battery = "Battery Status";
        public const string FHWT232Info = "FHWT_232_Info";
        public const string FHWT485Info = "FHWT_485_Info";
        public const string FHWT232Com1Info = "FHWT_232_Com1_Info";
        public const string FHWT485Com1Info = "FHWT_485_Com1_Info";
        public const string FHWT232Com2Info = "FHWT_232_Com2_Info";
        public const string FHWT485Com2Info = "FHWT_485_Com2_Info";
        public const string FHWT1 = "FHWT-1";
        public const string FHWT2 = "FHWT-2";
        public const string USB = "USB_Test";
        public const string Result1 = "Display Result1";
        public const string Result2 = "Display Result2";
        public const string Result = "Display Result";
        public const string NQ3T1 = "NQ3-T_FHWT_1";
        public const string NQ3T2 = "NQ3-T_FHWT_2";
        public const string NQ3M1 = "NQ3-M_FHWT_1";
        public const string NQ3M2 = "NQ3-M_FHWT_2";
        public const string NQ5S1 = "NQ5-S_FHWT_1";
        public const string NQ5S2 = "NQ5-S_FHWT_2";
        public const string NQ5M1 = "NQ5-M_FHWT_1";
        public const string NQ5M2 = "NQ5-M_FHWT_2";

        #region FP_CODE FHWT-4020 21-01-10 SnehalM

        public const string LCD_Keypad = "LCD-Keypad Test";
        public const string RTC_EEPROM = "RTC-EEPROM Test";
        public const string Key_Power_LED = "Key-Power LED Test";
        public const string PowerDown = "PowerDown_Test";   //FP_CODE FHWT-4030 06-03-10 SnehalM
        #endregion

        #region FP_Ethernet_FHWT_Screen_AMIT
        public const string EthernetSetting = "Ethernet Settings";
        public const string Ethernet = "Ethernet_Test";
        #endregion

        #region FP_FHWT_SnehaK
        public const string SystemInfo2 = "System Information 2";
        #endregion
        #region FP_FHWT FP4020MR_S3 Vijay
        public const string Temperature = "Temp_Test";
        #endregion

        #region FHWT_Vijay
        public const string DataLogErase = "Data Log Erase";
        public const string HistAlarmErase = "Hist Alarm Erase";
        #endregion
        #endregion
        #region Issue_1084 Vijay
        public static string ScrNumber = "Screen Number";
        public static string Obj_ImgText = "Object Text/Image Text";
        public static string Co_ordinate = "Co-ordinate";
        public static string Task_Name = "Task Name";
        public static int actualDeletedScrNo;
        #endregion

        #region ShitalG Utility
        public static bool IsCalibrationTestChecked = false;
        public static bool IsErrorResetChecked = false;
        public static bool blUSBHostDwnld = false;
        public static bool IsProductionChecked = false;
        public static string BasePLCName = "";
        public static string ExpansionName = "";
        public static double _bootblockversion;
        #endregion

        public CommonConstants()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region Private Declaration
        private static int _commConstantPrizmVersion = 0;
        private static ArrayList _commconstantarrFormObject = new ArrayList();
        private static ArrayList _constarrPrizmPatternValues = new ArrayList();
        public static ArrayList _constarrBaudRates = new ArrayList();

        private static bool _commConstantblRecalBlockSize = false;
        //umesh
        private static byte _commConstantModbusSlavePlcCode = 39;
        private static byte _commConstantPrizmPlcCode = 0;
        //
        public static string _CommConstantsProjHMILadderType = "";

        public const string Information = "Information";
        public static string strImportLogFileName = "";
        public const char chrImportSepCharacter = ',';
        public const int ARC_OBJECTTYPE = 92;
        public const int PIE_OBJECTTYPE = 93;
        public const int CHORD_OBJECTTYPE = 94;

        #endregion

        #region Public Methods
        #region Suraj IEC Task Tag Validation
        public static ArrayList IECTasksTagValidation(string taskName, ArrayList registerTagInfo)
        {

            ArrayList _temp = new ArrayList();
            switch (taskName)
            {
                case "Write Value to Tag":
                    {
                        _temp.Clear();
                        for (int i = 0; i < registerTagInfo.Count; i++)
                        {
                            if (((ClassList.CommonConstants.Prizm3TagStructure)registerTagInfo[i])._PLCCode == 0)
                            {
                                switch (((ClassList.CommonConstants.Prizm3TagStructure)registerTagInfo[i])._StratonDataType)
                                {
                                    case "SINT":
                                    case "USINT":
                                    case "BYTE":
                                    case "INT":
                                    case "UINT":
                                    case "WORD":
                                    case "UDINT":
                                    case "DWORD":
                                    case "REAL":
                                    case "LREAL"://LREAL_New_SY
                                    case "DINT":
                                    case "TIME":
                                        _temp.Add(registerTagInfo[i]);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            if (((ClassList.CommonConstants.Prizm3TagStructure)registerTagInfo[i])._PLCCode != 0)
                                _temp.Add(registerTagInfo[i]);
                        }
                    }
                    break;
                case "Add a Constant Value to a Tag":
                    {
                        _temp.Clear();
                        for (int i = 0; i < registerTagInfo.Count; i++)
                        {
                            if (((ClassList.CommonConstants.Prizm3TagStructure)registerTagInfo[i])._PLCCode == 0)
                            {
                                switch (((ClassList.CommonConstants.Prizm3TagStructure)registerTagInfo[i])._StratonDataType)
                                {
                                    case "SINT":
                                    case "USINT":
                                    case "BYTE":
                                    case "INT":
                                    case "UINT":
                                    case "WORD":
                                    case "UDINT":
                                    case "DWORD":
                                    case "REAL":
                                    case "LREAL"://LREAL_New_SY
                                    case "DINT":
                                    case "TIME":
                                        _temp.Add(registerTagInfo[i]);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            if (((ClassList.CommonConstants.Prizm3TagStructure)registerTagInfo[i])._PLCCode != 0)
                                _temp.Add(registerTagInfo[i]);

                        }
                    }
                    break;
                case "Subtract a Constant Value from a Tag":
                    {
                        _temp.Clear();
                        for (int i = 0; i < registerTagInfo.Count; i++)
                        {
                            if (((ClassList.CommonConstants.Prizm3TagStructure)registerTagInfo[i])._PLCCode == 0)
                            {
                                switch (((ClassList.CommonConstants.Prizm3TagStructure)registerTagInfo[i])._StratonDataType)
                                {
                                    case "SINT":
                                    case "USINT":
                                    case "BYTE":
                                    case "INT":
                                    case "UINT":
                                    case "WORD":
                                    case "UDINT":
                                    case "DWORD":
                                    case "REAL":
                                    case "LREAL"://LREAL_New_SY
                                    case "DINT":
                                    case "TIME":
                                        _temp.Add(registerTagInfo[i]);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            if (((ClassList.CommonConstants.Prizm3TagStructure)registerTagInfo[i])._PLCCode != 0)
                                _temp.Add(registerTagInfo[i]);

                        }

                    }
                    break;
                case "Add Tag B to Tag A":
                    {
                        _temp.Clear();
                        for (int i = 0; i < registerTagInfo.Count; i++)
                        {
                            if (((ClassList.CommonConstants.Prizm3TagStructure)registerTagInfo[i])._PLCCode == 0)
                            {
                                switch (((ClassList.CommonConstants.Prizm3TagStructure)registerTagInfo[i])._StratonDataType)
                                {
                                    case "SINT":
                                    case "USINT":
                                    case "BYTE":
                                    case "INT":
                                    case "UINT":
                                    case "WORD":
                                    case "UDINT":
                                    case "DWORD":
                                    case "REAL":
                                    case "LREAL"://LREAL_New_SY
                                    case "DINT":
                                    case "TIME":
                                        _temp.Add(registerTagInfo[i]);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            if (((ClassList.CommonConstants.Prizm3TagStructure)registerTagInfo[i])._PLCCode != 0)
                                _temp.Add(registerTagInfo[i]);

                        }
                    }
                    break;
                case "Subtract Tag B from Tag A":
                    {
                        _temp.Clear();
                        for (int i = 0; i < registerTagInfo.Count; i++)
                        {
                            if (((ClassList.CommonConstants.Prizm3TagStructure)registerTagInfo[i])._PLCCode == 0)
                            {
                                switch (((ClassList.CommonConstants.Prizm3TagStructure)registerTagInfo[i])._StratonDataType)
                                {
                                    case "SINT":
                                    case "USINT":
                                    case "BYTE":
                                    case "INT":
                                    case "UINT":
                                    case "WORD":
                                    case "UDINT":
                                    case "DWORD":
                                    case "REAL":
                                    case "LREAL"://LREAL_New_SY
                                    case "DINT":
                                    case "TIME":
                                        _temp.Add(registerTagInfo[i]);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            if (((ClassList.CommonConstants.Prizm3TagStructure)registerTagInfo[i])._PLCCode != 0)
                                _temp.Add(registerTagInfo[i]);

                        }
                    }
                    break;
                case "Copy Tag B to Tag A":
                    {
                        _temp.Clear();
                        for (int i = 0; i < registerTagInfo.Count; i++)
                        {
                            if (((ClassList.CommonConstants.Prizm3TagStructure)registerTagInfo[i])._PLCCode == 0)
                            {
                                switch (((ClassList.CommonConstants.Prizm3TagStructure)registerTagInfo[i])._StratonDataType)
                                {
                                    case "BOOL":
                                    case "SINT":
                                    case "USINT":
                                    case "BYTE":
                                    case "INT":
                                    case "UINT":
                                    case "WORD":
                                    case "UDINT":
                                    case "DWORD":
                                    case "REAL":
                                    case "LREAL"://LREAL_New_SY
                                    case "DINT":
                                    case "TIME":
                                        _temp.Add(registerTagInfo[i]);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            if (((ClassList.CommonConstants.Prizm3TagStructure)registerTagInfo[i])._PLCCode != 0)
                                _temp.Add(registerTagInfo[i]);

                        }
                    }
                    break;
                case "Swap Tag A and Tag B":
                    {
                        _temp.Clear();
                        for (int i = 0; i < registerTagInfo.Count; i++)
                        {
                            if (((ClassList.CommonConstants.Prizm3TagStructure)registerTagInfo[i])._PLCCode == 0)
                            {
                                switch (((ClassList.CommonConstants.Prizm3TagStructure)registerTagInfo[i])._StratonDataType)
                                {
                                    case "BOOL":
                                    case "SINT":
                                    case "USINT":
                                    case "BYTE":
                                    case "INT":
                                    case "UINT":
                                    case "WORD":
                                    case "UDINT":
                                    case "DWORD":
                                    case "REAL":
                                    case "LREAL"://LREAL_New_SY
                                    case "DINT":
                                    case "TIME":
                                        _temp.Add(registerTagInfo[i]);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            if (((ClassList.CommonConstants.Prizm3TagStructure)registerTagInfo[i])._PLCCode != 0)
                                _temp.Add(registerTagInfo[i]);

                        }
                    }
                    break;
                case "Switch Screen From Tag":
                    {
                        _temp.Clear();
                        for (int i = 0; i < registerTagInfo.Count; i++)
                        {
                            if (((ClassList.CommonConstants.Prizm3TagStructure)registerTagInfo[i])._PLCCode == 0)
                            {
                                switch (((ClassList.CommonConstants.Prizm3TagStructure)registerTagInfo[i])._StratonDataType)
                                {
                                    case "SINT":
                                    case "USINT":
                                    case "BYTE":
                                    case "INT":
                                    case "UINT":
                                    case "WORD":
                                    case "UDINT":
                                    case "DWORD":
                                    case "REAL":
                                    case "DINT":
                                    case "TIME":
                                        _temp.Add(registerTagInfo[i]);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            if (((ClassList.CommonConstants.Prizm3TagStructure)registerTagInfo[i])._PLCCode != 0)
                                _temp.Add(registerTagInfo[i]);

                        }
                    }
                    break;
                case "Copy HMI Block to HMI/PLC Block":
                    {
                        _temp.Clear();
                        for (int i = 0; i < registerTagInfo.Count; i++)
                        {
                            if (((ClassList.CommonConstants.Prizm3TagStructure)registerTagInfo[i])._PLCCode == 0)
                            {
                                switch (((ClassList.CommonConstants.Prizm3TagStructure)registerTagInfo[i])._StratonDataType)
                                {
                                    case "SINT":
                                    case "USINT":
                                    case "BYTE":
                                    case "INT":
                                    case "UINT":
                                    case "WORD":
                                    case "UDINT":
                                    case "DWORD":
                                    case "REAL":
                                    case "LREAL"://LREAL_New_SY
                                    case "DINT":
                                    case "TIME":
                                        _temp.Add(registerTagInfo[i]);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            if (((ClassList.CommonConstants.Prizm3TagStructure)registerTagInfo[i])._PLCCode != 0)
                                _temp.Add(registerTagInfo[i]);

                        }
                    }
                    break;
                case "Copy HMI/PLC Block to HMI Block":
                    {
                        _temp.Clear();
                        for (int i = 0; i < registerTagInfo.Count; i++)
                        {
                            if (((ClassList.CommonConstants.Prizm3TagStructure)registerTagInfo[i])._PLCCode == 0)
                            {
                                switch (((ClassList.CommonConstants.Prizm3TagStructure)registerTagInfo[i])._StratonDataType)
                                {
                                    case "SINT":
                                    case "USINT":
                                    case "BYTE":
                                    case "INT":
                                    case "UINT":
                                    case "WORD":
                                    case "UDINT":
                                    case "DWORD":
                                    case "REAL":
                                    case "LREAL"://LREAL_New_SY
                                    case "DINT":
                                    case "TIME":
                                        _temp.Add(registerTagInfo[i]);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            if (((ClassList.CommonConstants.Prizm3TagStructure)registerTagInfo[i])._PLCCode != 0)
                                _temp.Add(registerTagInfo[i]);

                        }
                    }
                    break;
                case "USB Data Log Upload":
                    {
                        _temp.Clear();
                        for (int i = 0; i < registerTagInfo.Count; i++)
                        {
                            if (((ClassList.CommonConstants.Prizm3TagStructure)registerTagInfo[i])._PLCCode == 0)
                            {
                                switch (((ClassList.CommonConstants.Prizm3TagStructure)registerTagInfo[i])._StratonDataType)
                                {
                                    case "SINT":
                                    case "USINT":
                                    case "BYTE":
                                    case "INT":
                                    case "UINT":
                                    case "WORD":
                                    case "DINT":
                                        _temp.Add(registerTagInfo[i]);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            if (((ClassList.CommonConstants.Prizm3TagStructure)registerTagInfo[i])._PLCCode != 0)
                                _temp.Add(registerTagInfo[i]);

                        }
                    }
                    break;
                #region SD_Card_Functionality Vijay
                case "Data Log Upload":
                    {
                        _temp.Clear();
                        for (int i = 0; i < registerTagInfo.Count; i++)
                        {
                            if (((ClassList.CommonConstants.Prizm3TagStructure)registerTagInfo[i])._PLCCode == 0)
                            {
                                switch (((ClassList.CommonConstants.Prizm3TagStructure)registerTagInfo[i])._StratonDataType)
                                {
                                    case "SINT":
                                    case "USINT":
                                    case "BYTE":
                                    case "INT":
                                    case "UINT":
                                    case "WORD":
                                    case "DINT":
                                        _temp.Add(registerTagInfo[i]);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            if (((ClassList.CommonConstants.Prizm3TagStructure)registerTagInfo[i])._PLCCode != 0)
                                _temp.Add(registerTagInfo[i]);

                        }
                    }
                    break;
                #endregion
                case "Copy Tag to LED":
                    {
                        _temp.Clear();
                        for (int i = 0; i < registerTagInfo.Count; i++)
                        {
                            if (((ClassList.CommonConstants.Prizm3TagStructure)registerTagInfo[i])._PLCCode == 0)
                            {
                                switch (((ClassList.CommonConstants.Prizm3TagStructure)registerTagInfo[i])._StratonDataType)
                                {
                                    case "SINT":
                                    case "USINT":
                                    case "BYTE":
                                    case "INT":
                                    case "UINT":
                                    case "WORD":
                                    case "UDINT":
                                    case "DWORD":
                                    case "REAL":
                                    case "DINT":
                                    case "TIME":
                                        _temp.Add(registerTagInfo[i]);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            if (((ClassList.CommonConstants.Prizm3TagStructure)registerTagInfo[i])._PLCCode != 0)
                                _temp.Add(registerTagInfo[i]);

                        }
                    }
                    break;
                //case "Delay":
                //    break;
                case "Wait While":
                    {
                        _temp.Clear();
                        for (int i = 0; i < registerTagInfo.Count; i++)
                        {
                            if (((ClassList.CommonConstants.Prizm3TagStructure)registerTagInfo[i])._PLCCode == 0)
                            {
                                switch (((ClassList.CommonConstants.Prizm3TagStructure)registerTagInfo[i])._StratonDataType)
                                {
                                    case "BOOL":
                                    case "SINT":
                                    case "USINT":
                                    case "BYTE":
                                    case "INT":
                                    case "UINT":
                                    case "WORD":
                                    case "UDINT":
                                    case "DWORD":
                                    case "REAL":
                                    case "DINT":
                                    case "TIME":
                                        _temp.Add(registerTagInfo[i]);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            if (((ClassList.CommonConstants.Prizm3TagStructure)registerTagInfo[i])._PLCCode != 0)
                                _temp.Add(registerTagInfo[i]);

                        }
                    }
                    break;
                case "Key's Specific Task":
                    {
                        _temp.Clear();
                        for (int i = 0; i < registerTagInfo.Count; i++)
                        {
                            if (((ClassList.CommonConstants.Prizm3TagStructure)registerTagInfo[i])._PLCCode == 0)
                            {
                                switch (((ClassList.CommonConstants.Prizm3TagStructure)registerTagInfo[i])._StratonDataType)
                                {
                                    case "BOOL":
                                    case "SINT":
                                    case "USINT":
                                    case "BYTE":
                                    case "INT":
                                    case "UINT":
                                    case "WORD":
                                    case "UDINT":
                                    case "DWORD":
                                    case "REAL":
                                    case "DINT":
                                    case "TIME":
                                        _temp.Add(registerTagInfo[i]);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            if (((ClassList.CommonConstants.Prizm3TagStructure)registerTagInfo[i])._PLCCode != 0)
                                _temp.Add(registerTagInfo[i]);

                        }
                    }
                    break;
                case "Alarms":
                    {
                        //Alarm and Data Logger Tag Validation
                        _temp.Clear();
                        for (int i = 0; i < registerTagInfo.Count; i++)
                        {
                            if (((ClassList.CommonConstants.Prizm3TagStructure)registerTagInfo[i])._PLCCode == 0)
                            {
                                switch (((ClassList.CommonConstants.Prizm3TagStructure)registerTagInfo[i])._StratonDataType)
                                {
                                    case "UINT":
                                    case "WORD":
                                        _temp.Add(registerTagInfo[i]);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            if (((ClassList.CommonConstants.Prizm3TagStructure)registerTagInfo[i])._PLCCode != 0)
                                _temp.Add(registerTagInfo[i]);
                        }
                    }
                    break;
                case "Data Logger":
                    {
                        //Alarm and Data Logger Tag Validation
                        _temp.Clear();
                        for (int i = 0; i < registerTagInfo.Count; i++)
                        {
                            if (((ClassList.CommonConstants.Prizm3TagStructure)registerTagInfo[i])._PLCCode == 0)
                            {
                                switch (((ClassList.CommonConstants.Prizm3TagStructure)registerTagInfo[i])._StratonDataType)
                                {
                                    case "UINT":
                                    case "WORD":
                                    case "UDINT":
                                    case "DWORD":
                                    case "REAL":
                                    case "BOOL":
                                    case "TIME":
                                    case "INT"://SS_Issue870
                                    case "DINT"://SS_Issue870
                                        _temp.Add(registerTagInfo[i]);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            if (((ClassList.CommonConstants.Prizm3TagStructure)registerTagInfo[i])._PLCCode != 0)
                                _temp.Add(registerTagInfo[i]);
                        }
                    }
                    break;
                #region Issue2.3_22 Vijay
                case "USB Host Upload":
                case "SD Card Upload"://SS_SDCardUpload
                    {
                        _temp.Clear();
                        for (int i = 0; i < registerTagInfo.Count; i++)
                        {
                            if (((ClassList.CommonConstants.Prizm3TagStructure)registerTagInfo[i])._PLCCode == 0)
                            {
                                if ((!((CommonConstants.Prizm3TagStructure)registerTagInfo[i])._IsTagSystem))
                                {
                                    switch (((ClassList.CommonConstants.Prizm3TagStructure)registerTagInfo[i])._StratonDataType)
                                    {
                                        case "USINT":
                                        case "BYTE":
                                        case "UINT":
                                        case "WORD":
                                        case "UDINT":
                                        case "DWORD":
                                            _temp.Add(registerTagInfo[i]);
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }
                        }
                    }
                    break;
                #endregion
                default:
                    _temp = registerTagInfo;
                    break;
            }
            return _temp;
        }
        #endregion
        #region Suraj IEC VisibilityAnimation Tag Validation
        public static ArrayList IECFlashAnimationTagValidation(ArrayList TagList)
        {
            ArrayList _tempList = new ArrayList();
            for (int i = 0; i < TagList.Count; i++)
            {
                if (((ClassList.CommonConstants.Prizm3TagStructure)TagList[i])._PLCCode == 0)
                {
                    switch (((ClassList.CommonConstants.Prizm3TagStructure)TagList[i])._StratonDataType)
                    {
                        case "BOOL":
                        case "USINT":
                        case "BYTE":
                        case "UINT":
                        case "WORD":
                            //case "INT"://Issue_282_IEC_sammed
                            //case "SINT":
                            //case "UDINT":
                            //case "DWORD":
                            //case "TIME"://End Issue_282_IEC_sammed
                            _tempList.Add(TagList[i]);
                            break;
                        default:
                            break;
                    }
                }
                if (((ClassList.CommonConstants.Prizm3TagStructure)TagList[i])._PLCCode != 0)
                    _tempList.Add(TagList[i]);
            }
            return _tempList;
        }
        #endregion

        #region OIL-DS_Password_Vijay
        public static string Decrypt(string encrypData)
        {
            string passPhrase = "Pas5pr@se";            // can be any string
            string saltValue = "s@1tValue";             // can be any string
            string hashAlgorithm = "SHA1";              // can be "MD5"
            int passwordIterations = 2;                 // can be any number
            string initVector = "Renu Electronics";     // must be 16 bytes
            int keySize = 256;                          // can be 192 or 128
            string decrypData = "";
            string decrypted = "";
            string encrypted = "";
            string plainText = "";
            try
            {
                string cipherText = encrypData;

                byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
                byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
                byte[] cipherTextBytes = Convert.FromBase64String(cipherText);

                PasswordDeriveBytes password = new PasswordDeriveBytes(
                                                                passPhrase,
                                                                saltValueBytes,
                                                                hashAlgorithm,
                                                                passwordIterations);

                byte[] keyBytes = password.GetBytes(keySize / 8);

                RijndaelManaged symmetricKey = new RijndaelManaged();

                symmetricKey.Mode = CipherMode.CBC;

                ICryptoTransform decryptor = symmetricKey.CreateDecryptor(
                                                                 keyBytes,
                                                                 initVectorBytes);

                MemoryStream memoryStream = new MemoryStream(cipherTextBytes);

                CryptoStream cryptoStream = new CryptoStream(memoryStream,
                                                              decryptor,
                                                              CryptoStreamMode.Read);

                byte[] plainTextBytes = new byte[cipherTextBytes.Length];

                int decryptedByteCount = cryptoStream.Read(plainTextBytes,
                                                           0,
                                                           plainTextBytes.Length);

                memoryStream.Close();
                cryptoStream.Close();

                plainText = Encoding.UTF8.GetString(plainTextBytes,
                                                          0,
                                                          decryptedByteCount);

            }
            catch (Exception e)
            {
                // MessageBox.Show("Configuration file has been changed.Please enter correct password to restore this file.");
            }
            return plainText;
        }
        public static string Encrypt(string decrypData)
        {
            string plainText = "";                      // original plaintext
            string passPhrase = "Pas5pr@se";            // can be any string
            string saltValue = "s@1tValue";             // can be any string
            string hashAlgorithm = "SHA1";              // can be "MD5"
            int passwordIterations = 2;                 // can be any number
            string initVector = "Renu Electronics";    // must be 16 bytes
            int keySize = 256;                          // can be 192 or 128
            string encrypData = "";
            string decrypted = "";
            string encrypted = "";
            plainText = decrypData;

            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            PasswordDeriveBytes password = new PasswordDeriveBytes(
                                                            passPhrase,
                                                            saltValueBytes,
                                                            hashAlgorithm,
                                                            passwordIterations);

            byte[] keyBytes = password.GetBytes(keySize / 8);

            RijndaelManaged symmetricKey = new RijndaelManaged();

            symmetricKey.Mode = CipherMode.CBC;

            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(
                                                             keyBytes,
                                                             initVectorBytes);

            MemoryStream memoryStream = new MemoryStream();

            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                                                         encryptor,
                                                         CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);

            cryptoStream.FlushFinalBlock();

            byte[] cipherTextBytes = memoryStream.ToArray();

            memoryStream.Close();
            cryptoStream.Close();

            string cipherText = Convert.ToBase64String(cipherTextBytes);

            return cipherText;
        }
        #endregion

        #region SS_CopyTasks
        /// <summary>
        /// Method returns true if key task code is valid for pressed tasks
        /// SS_CopyTasks
        /// </summary>
        /// <param name="pkeyCode"></param>
        /// <returns></returns>
        public static bool IsValidPressedKeyTask(ClassList.KeyTaskCode pkeyCode)
        {
            switch (pkeyCode)
            {
                case KeyTaskCode.IncreaseValueByOne:
                case KeyTaskCode.DecreaseValueByOne:
                case KeyTaskCode.IncreaseDigitByOne:
                case KeyTaskCode.DecreaseDigitByOne:

                case KeyTaskCode.PreviousAlarm:
                case KeyTaskCode.NextAlarm:
                case KeyTaskCode.PreviousHISAlarm:
                case KeyTaskCode.NextHISAlarm:
                case KeyTaskCode.RefreshTrendWindow:
                    return true;
            }
            return false;
        }
        #endregion

        //Alarm and Data Logger Tag Validation
        public static List<T> ToList<T>(ArrayList arrayList)
        {
            List<T> list = new List<T>(arrayList.Count);
            foreach (T instance in arrayList)
            {
                list.Add(instance);
            }
            return list;
        }
        public static int GetModelSeriesProductId(int iProductId)
        {
            //Added by Samir Karve on 4/4/2007
            //As per Prizm3.12Beta changes are not made in DefaultNodeTag.xml. So first ModelSries is found out and then 
            // from Modelseries productId is found.
            string strTemp = "";
            int iNewProductId = 0;
            foreach (DataRow drow in dsRecentProjectList.Tables["UnitInformation"].Rows)
            {
                if (iProductId == Convert.ToInt32(drow.ItemArray[13].ToString()))
                {
                    strTemp = drow.ItemArray[2].ToString();
                    break;
                }
            }

            foreach (DataRow drow in dsRecentProjectList.Tables["ModelData"].Rows)
            {
                if (strTemp.Equals(drow.ItemArray[1].ToString()))
                {
                    iNewProductId = Convert.ToInt32(drow.ItemArray[6].ToString());
                    break;
                }
            }

            return iNewProductId;
        }

        /// <summary>
        /// The function returns pattern index required for c# coding as per the provided pattern index of 
        /// prizm file formate.Check the Read Method of Rectangular class to get the reference.
        /// </summary>
        /// <param name="pPattern">Reference Pattern Object parameter</param>
        /// <param name="pPatternIndex">Pattern index</param>
        public static void GetPatternIndex(ref  object pPattern, byte pPatternIndex)
        {
            if (pPatternIndex == Convert.ToByte(ClassList.PatternBrush.NOFILL))
                pPattern = 0;
            else if (pPatternIndex == Convert.ToByte(ClassList.PatternBrush.ONE_BLACK_ONE_WHITE))
                pPattern = 14;
            else if (pPatternIndex == Convert.ToByte(ClassList.PatternBrush.THREE_BLACK_ONE_WHITE))
                pPattern = 16;
            else if (pPatternIndex == Convert.ToByte(ClassList.PatternBrush.ONE_BLACK_THREE_WHITE))
                pPattern = 7;
            else if (pPatternIndex == Convert.ToByte(ClassList.PatternBrush.ONE_WHITE_ONE_BLACK))
                pPattern = 12;
            else if (pPatternIndex == Convert.ToByte(ClassList.PatternBrush.HORIZONTAL))
                pPattern = 25;
            else if (pPatternIndex == Convert.ToByte(ClassList.PatternBrush.VERTICAL))
                pPattern = 24;
            else if (pPatternIndex == Convert.ToByte(ClassList.PatternBrush.CROSS))
                pPattern = 48;
        }

        #region Import_Screen_AMIT
        public static string GetModelSeriesName(int iProductId)
        {
            string strTemp = "";
            foreach (DataRow drow in dsRecentProjectList.Tables["UnitInformation"].Rows)
            {
                if (iProductId == Convert.ToInt32(drow.ItemArray[13].ToString()))
                {
                    strTemp = drow.ItemArray[2].ToString();
                    break;
                }
            }

            return strTemp;
        }
        #endregion

        public static short MAKEWORD(byte a, byte b)
        {
            return (short)(a | (b << 8));
        }

        /// <summary>
        /// Joins 2 bytes to make a word
        /// </summary>
        /// <param name="pTemparr">temporary array containing 2 bytes to be joined</param>
        /// <returns>ushort</returns>
        //public static short MAKEWORD(byte[] pTemparr)
        //{
        //    int iHiByte = pTemparr[1];
        //    iHiByte = iHiByte << 8;
        //    iHiByte = iHiByte | (int)pTemparr[0];
        //    return (short)iHiByte;
        //}
        #region IEC_Issue_70_SanjayY
        public static void checkVPSerialPort(ref string V_PortName1, ref string V_PortName2)
        {
            string path = string.Empty;
            //if (InternalCheckIsWow64())
            //{
            //    path = @System.IO.Directory.GetCurrentDirectory() + "\\" + "x64_VP" + "\\" + "setupc1.txt";
            //}
            //else
            //{
            //    path = @System.IO.Directory.GetCurrentDirectory() + "\\" + "x32_VP" + "\\" + "setupc1.txt";
            //}
            path = @System.IO.Directory.GetCurrentDirectory() + "\\" + "setupc1.txt";//ComPortListChange_SY
            if (File.Exists(path))
            {


                using (StreamReader sr = File.OpenText(path))
                    if (sr.ReadLine().ToString() == "1")
                    {
                        if (File.Exists("VPCOMPORT.txt"))
                        {
                            StreamReader SR_VP = new StreamReader("VPCOMPORT.txt");
                            V_PortName1 = SR_VP.ReadLine();
                            V_PortName2 = SR_VP.ReadLine();
                            SR_VP.Close();
                        }
                        sr.Close();
                    }
            }
        }
        #endregion
        #region IEC_Issue_70_SanjayY
        bool is64BitProcess = (IntPtr.Size == 8);
        //bool is64BitOperatingSystem = is64BitProcess || InternalCheckIsWow64();
        [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsWow64Process
        (
            [In] IntPtr hProcess,
            [Out] out bool wow64Process
        );
        public static bool InternalCheckIsWow64()
        {
            if ((Environment.OSVersion.Version.Major == 5 && Environment.OSVersion.Version.Minor >= 1) ||
                Environment.OSVersion.Version.Major >= 6)
            {
                using (Process p = Process.GetCurrentProcess())
                {
                    bool retVal;
                    if (!IsWow64Process(p.Handle, out retVal))
                    {
                        return false;
                    }
                    return retVal;
                }
            }
            else
            {
                return false;
            }
        }
        #endregion Detect_32bit or 64 bit Pc_SanjayY
        public static ushort MAKEWORD(byte[] pTemparr)
        {
            uint uiHiByte = Convert.ToUInt16(pTemparr[1]);
            uiHiByte = uiHiByte << 8;
            uiHiByte = uiHiByte | (uint)pTemparr[0];
            return Convert.ToUInt16(uiHiByte);
        }

        //Ladder_Change_R11
        public static ushort MAKEUWORD(byte a, byte b)
        {
            uint uiHiByte = Convert.ToUInt16(b);
            uiHiByte = uiHiByte << 8;
            uiHiByte = uiHiByte | (uint)a;
            return Convert.ToUInt16(uiHiByte);
        }

        /// <summary>
        /// Joins 4 bytes to make a double word
        /// </summary>
        /// <param name="pTemparr">temporary array containing 4 bytes to be joined</param>
        /// <returns>uint</returns>
        public static int MAKEINT(byte[] pTemparr)
        {
            int iValue = ((pTemparr[3] & 0xFF) << 24) | ((pTemparr[2] & 0xFF) << 16) | ((pTemparr[1] & 0xFF) << 8) | (pTemparr[0] & 0xFF);
            return iValue;
        }

        /// <summary>
        ///Joins 4bytes to make a unsigned double word.
        /// </summary>
        /// <param name="pTemparr"></param>
        /// <returns></returns>
        public static uint MAKEUINT(byte[] pTemparr)
        {
            uint iValue = (uint)(((pTemparr[3] & 0xFF) << 24) | ((pTemparr[2] & 0xFF) << 16) | ((pTemparr[1] & 0xFF) << 8) | (pTemparr[0] & 0xFF));
            return iValue;
        }


        public static void BREAKWORD(byte[] pTemparr, short pProperty)
        {
            int iTemp;
            iTemp = ((int)pProperty) & 255;
            pTemparr[0] = Convert.ToByte(iTemp);
            iTemp = pProperty;
            iTemp = iTemp >> 8;
            pTemparr[1] = Convert.ToByte((iTemp & 255));
        }

        public static void BREAKWORD(byte[] pTemparr, ushort pProperty)
        {
            uint uiTemp;
            uiTemp = ((uint)pProperty) & 255;
            pTemparr[0] = Convert.ToByte(uiTemp);
            uiTemp = pProperty;
            uiTemp = uiTemp >> 8;
            pTemparr[1] = Convert.ToByte((uiTemp & 255));
        }
        //Following changes by Samir Karve
        public static void BREAKWORD(byte[] pTemparr, uint pProperty)
        {
            int iTemp;
            iTemp = ((int)pProperty) & 255;
            pTemparr[0] = Convert.ToByte(iTemp);
            iTemp = (int)pProperty;
            iTemp = iTemp >> 8;
            pTemparr[1] = Convert.ToByte((iTemp & 255));
        }
        //End of changes by Samir Karve
        public static void BREAKINT(byte[] pTemparr, int pProperty)
        {
            pTemparr[3] = (byte)((pProperty & 0xff000000) >> 24);
            pTemparr[2] = (byte)((pProperty & 0x00ff0000) >> 16);
            pTemparr[1] = (byte)((pProperty & 0x0000ff00) >> 8);
            pTemparr[0] = (byte)((pProperty & 0x000000ff));

        }

        //Ladder_Change_R10
        public static void BREAKUINT(byte[] pTemparr, uint pProperty)
        {
            pTemparr[3] = (byte)((pProperty & 0xff000000) >> 24);
            pTemparr[2] = (byte)((pProperty & 0x00ff0000) >> 16);
            pTemparr[1] = (byte)((pProperty & 0x0000ff00) >> 8);
            pTemparr[0] = (byte)((pProperty & 0x000000ff));

        }





        public static byte[] GetWord(long temp_variable)
        {
            byte[] temparr = new byte[4];

            temparr[0] = (byte)(temp_variable & 0x000000ff);
            temparr[1] = (byte)((temp_variable & 0x0000ff00) >> 8);
            temparr[2] = (byte)((temp_variable & 0x00ff0000) >> 16);
            temparr[3] = (byte)((temp_variable & 0xff000000) >> 24);

            return temparr;
        }

        //Issue_1504 Nilam
        public static void GetTagDataTypeRanges(TagType pTagType, byte pDataType, ref string pMinVal, ref string pMaxVal)
        {
            string strMaxSideGap = "";
            string MinVal = "";
            string MaxVal = "";

            switch (pTagType)
            {
                case TagType.Byte:
                    {
                        switch (pDataType)
                        {
                            case 0: //Unsigned
                                {
                                    MinVal = "0";
                                    MaxVal = "255";
                                }
                                break;

                            case 1: //Signed
                                {
                                    MinVal = "-127";
                                    MaxVal = "127";
                                }
                                break;

                            case 2: //Hex
                                {
                                    MinVal = "0";
                                    MaxVal = "FF";
                                }
                                break;
                            case 3: //BCD
                                {
                                    MinVal = "0";
                                    MaxVal = "99";
                                }
                                break;

                            case 4: //Float
                                {
                                    MinVal = "0";
                                    MaxVal = "255";
                                }
                                break;
                        }
                    }
                    break;

                case TagType.Word:
                    {
                        switch (pDataType)
                        {
                            case 0: //Unsigned
                                {
                                    MinVal = "65535000";
                                    MaxVal = "65535000";
                                }
                                break;

                            case 1: //Signed
                                {
                                    MinVal = "-32768000";
                                    MaxVal = "32767000";
                                }
                                break;

                            case 2: //Hex
                                {
                                    MinVal = "0000000";
                                    MaxVal = "FFFFFFF";
                                }
                                break;
                            case 3: //BCD
                                {
                                    MinVal = "9999000";
                                    MaxVal = "9999000";
                                }
                                break;

                            case 4: //Float
                                {
                                    MinVal = "655355";
                                    MaxVal = "655355";
                                }
                                break;
                        }
                    }
                    break;

                case TagType.DoubleWord:
                    {
                        switch (pDataType)
                        {
                            case 0: //Unsigned
                                {
                                    MinVal = "4294967295000";
                                    MaxVal = "4294967295000";
                                }
                                break;

                            case 1: //Signed
                                {
                                    MinVal = "-2147483648000";
                                    MaxVal = "2147483647000";
                                }
                                break;

                            case 2: //Hex
                                {
                                    MinVal = "FFFFFFFFFFF";
                                    MaxVal = "FFFFFFFFFFF";
                                }
                                break;

                            case 3: //BCD
                                {
                                    MinVal = "99999999999";
                                    MaxVal = "99999999999";
                                }
                                break;

                            case 4: //Float
                                {
                                    MinVal = "-999999999.0000";
                                    MaxVal = "-999999999.0000";
                                }
                                break;
                        }
                    }
                    break;
            }

            pMinVal = MinVal;
            pMaxVal = MaxVal;
        }
        ///////////////////////
        //FP_CODE  R12  Haresh
        public static byte[] GetHalfWord(int temp_variable)
        {
            byte[] temparr = new byte[2];

            int raw_variable = 0;
            raw_variable = (temp_variable) & 255;
            temparr[0] = Convert.ToByte(raw_variable);
            raw_variable = temp_variable;
            raw_variable = raw_variable >> 8;
            temparr[1] = Convert.ToByte((raw_variable & 255));

            return temparr;

        }
        //End
        public static void SetActiveFormObject(Form pFormObject)
        {
            _commconstantarrFormObject.Clear();
            _commconstantarrFormObject.Add(pFormObject);
        }

        public static ArrayList GetActiveFormObject()
        {
            return _commconstantarrFormObject;
        }

        public static string IntArrayToString(int[] pIntVal)
        {

            char[] _cVal = new char[pIntVal.Length];
            for (int i = 0; i < pIntVal.Length; i++)
                _cVal[i] = System.Convert.ToChar(pIntVal[i]);
            string _strVal = new string(_cVal);
            return _strVal;

        }

        public static void StringToIntArray(string pStrVal, int[] pIntVal)
        {
            char[] _cVal = new char[pStrVal.Length];
            pStrVal.CopyTo(0, _cVal, 0, pStrVal.Length);
            for (int i = 0; i < pStrVal.Length; i++)
                pIntVal[i] = System.Convert.ToUInt16(_cVal[i]);

        }

        #region Save_Optimization_AD
        public static void StringToByteArray(string pStrVal, byte[] pByteVal)
        {
            char[] _cVal = new char[pStrVal.Length];
            pStrVal.CopyTo(0, _cVal, 0, pStrVal.Length);
            for (int i = 0; i < pStrVal.Length; i++)
                pByteVal[i] = System.Convert.ToByte(_cVal[i]);
        }
        #endregion

        public static string ShortArrayToString(short[] pShortVal)
        {

            char[] _cVal = new char[pShortVal.Length];
            for (int i = 0; i < pShortVal.Length; i++)
                _cVal[i] = System.Convert.ToChar(pShortVal[i]);
            string _strVal = new string(_cVal);
            return _strVal;

        }

        public static void StringToShortArray(string pStrVal, short[] pShortVal)
        {
            char[] _cVal = new char[pStrVal.Length];
            pStrVal.CopyTo(0, _cVal, 0, pStrVal.Length);
            for (int i = 0; i < pStrVal.Length; i++)
                pShortVal[i] = System.Convert.ToInt16(_cVal[i]);
        }

        public static string UShortArrayToString(ushort[] pShortVal)
        {

            char[] _cVal = new char[pShortVal.Length];
            for (int i = 0; i < pShortVal.Length; i++)
                _cVal[i] = System.Convert.ToChar(pShortVal[i]);
            string _strVal = new string(_cVal);
            return _strVal;

        }



        public static void StringToUShortArray(string pStrVal, ushort[] pShortVal)
        {
            char[] _cVal = new char[pStrVal.Length];
            pStrVal.CopyTo(0, _cVal, 0, pStrVal.Length);
            for (int i = 0; i < pStrVal.Length; i++)
                pShortVal[i] = System.Convert.ToUInt16(_cVal[i]);
        }

        /// <summary>
        /// This method is called when the MFC LOGFONT structure ( which is used for storing text objects of
        /// wizards generated in Prizm 3.12 ) needs to be converted to C#.net's Font object. It should be called
        /// while reading Prizm 3.12 projects.
        /// </summary>
        /// <param name="pLOGFONT"></param>
        /// <param name="pFontInfo"></param>
        /// <param name="pCharOfFaceName"></param>
        /// <returns></returns>
        public static Font ConvertLogFontToFont(LOGFONT pLOGFONT, ref FontInfo pFontInfo, short[] pCharOfFaceName)
        {

            pLOGFONT.lfHeight = pFontInfo._fFontHeight;
            pLOGFONT.lfWidth = pFontInfo._fFontWidth;
            pLOGFONT.lfEscapement = pFontInfo._fEscapement;
            pLOGFONT.lfOrientation = pFontInfo._fOrientation;
            pLOGFONT.lfWeight = pFontInfo._fWeight;
            pLOGFONT.lfItalic = pFontInfo._fItalic;
            pLOGFONT.lfUnderline = pFontInfo._fUnderline;
            pLOGFONT.lfStrikeOut = pFontInfo._fStrikeOut;
            pLOGFONT.lfCharSet = Convert.ToByte(pFontInfo._fCharSet);
            pLOGFONT.lfOutPrecision = pFontInfo._fOutPrecision;
            pLOGFONT.lfClipPrecision = pFontInfo._fClipPrecision;
            pLOGFONT.lfQuality = pFontInfo._fQuality;
            pLOGFONT.lfPitchAndFamily = pFontInfo._fPitchFamily;
            pLOGFONT.lfFaceName = ShortArrayToString(pCharOfFaceName);
            Font objFont;

            if (ProductDataInfo.btPrizmVersion == 10)
            {
                if (pLOGFONT.lfFaceName.Contains("prizm"))
                    pLOGFONT.lfFaceName = "Arial";
                IntPtr fontHandle = CreateFontIndirect(pLOGFONT);
                objFont = System.Drawing.Font.FromHfont(fontHandle);
                if (objFont.Size - objFont.Size / 4 <= 50)
                    return objFont = new Font(objFont.FontFamily, objFont.Size - objFont.Size / 4, objFont.Style);
                else
                    return objFont = new Font(objFont.FontFamily, objFont.Size / 10 - (objFont.Size / 10) / 4, objFont.Style);
            }
            else
            {
                try
                {
                    objFont = System.Drawing.Font.FromLogFont(pLOGFONT);
                }
                catch (Exception e)
                {
                    //MessageBox.Show(e.Message);
                    pLOGFONT.lfFaceName = CommonConstants.TTFontNameUsedForPrizmFont;
                    objFont = System.Drawing.Font.FromLogFont(pLOGFONT);
                }
            }
            //objFont = new Font(objFont.FontFamily , objFont.Size, GraphicsUnit.Millimeter );    
            if (pFontInfo._fFontWidth <= 0)
                pFontInfo._fFontWidth = Convert.ToInt32(objFont.Size);
            return objFont = new Font(objFont.FontFamily, pFontInfo._fFontWidth, objFont.Style);
        }
        //Prizm710_Conversion
        public static Font ConvertPrizmLogFontToFPFont(LOGFONT pLOGFONT, ref FontInfo pFontInfo, short[] pCharOfFaceName)
        {

            pLOGFONT.lfHeight = pFontInfo._fFontHeight;
            pLOGFONT.lfWidth = pFontInfo._fFontWidth;
            pLOGFONT.lfEscapement = pFontInfo._fEscapement;
            pLOGFONT.lfOrientation = pFontInfo._fOrientation;
            pLOGFONT.lfWeight = pFontInfo._fWeight;
            pLOGFONT.lfItalic = pFontInfo._fItalic;
            pLOGFONT.lfUnderline = pFontInfo._fUnderline;
            pLOGFONT.lfStrikeOut = pFontInfo._fStrikeOut;
            pLOGFONT.lfCharSet = Convert.ToByte(pFontInfo._fCharSet);
            pLOGFONT.lfOutPrecision = pFontInfo._fOutPrecision;
            pLOGFONT.lfClipPrecision = pFontInfo._fClipPrecision;
            pLOGFONT.lfQuality = pFontInfo._fQuality;
            pLOGFONT.lfPitchAndFamily = pFontInfo._fPitchFamily;
            pLOGFONT.lfFaceName = ShortArrayToString(pCharOfFaceName);
            Font objFont;

            //if (ProductDataInfo.btPrizmVersion == 10)
            {
                if (pLOGFONT.lfFaceName.Contains("prizm"))
                    pLOGFONT.lfFaceName = "Arial";
                IntPtr fontHandle = CreateFontIndirect(pLOGFONT);
                objFont = System.Drawing.Font.FromHfont(fontHandle);
                /*if (objFont.Size - objFont.Size / 4 <= 50)
                     objFont = new Font(objFont.FontFamily, objFont.Size - objFont.Size / 4, objFont.Style);
                else
                     objFont = new Font(objFont.FontFamily, objFont.Size / 10 - (objFont.Size / 10) / 4, objFont.Style);
                 * */

                objFont = new Font(objFont.FontFamily, objFont.SizeInPoints, objFont.Style);




                if (pFontInfo._fFontWidth <= 0)
                    pFontInfo._fFontWidth = Convert.ToInt32(objFont.Size);


            }

            objFont.ToLogFont(pLOGFONT);

            pFontInfo._fFontHeight = pLOGFONT.lfHeight;
            //pFontInfo._fFontWidth = pLogFont.lfWidth;
            pFontInfo._fFontWidth = Convert.ToInt32(objFont.Size);
            pFontInfo._fEscapement = pLOGFONT.lfEscapement;
            pFontInfo._fOrientation = pLOGFONT.lfOrientation;
            pFontInfo._fWeight = pLOGFONT.lfWeight;
            pFontInfo._fItalic = pLOGFONT.lfItalic;
            pFontInfo._fUnderline = pLOGFONT.lfUnderline;
            pFontInfo._fStrikeOut = pLOGFONT.lfStrikeOut;
            pFontInfo._fCharSet = pLOGFONT.lfCharSet;
            pFontInfo._fOutPrecision = pLOGFONT.lfOutPrecision;
            pFontInfo._fClipPrecision = pLOGFONT.lfClipPrecision;
            pFontInfo._fQuality = pLOGFONT.lfQuality;
            pFontInfo._fPitchFamily = pLOGFONT.lfPitchAndFamily;
            pFontInfo._fLenOfFaceName = Convert.ToByte(pLOGFONT.lfFaceName.Length);

            return objFont;
            // return objFont = new Font(objFont.FontFamily, pFontInfo._fFontWidth, objFont.Style);
        }
        //


        /// <summary>
        /// In prizm 3.12 file format ( .pzm ), the font information of a text object in a wizard
        /// is stored as MFC LOGFONT data structure. While writing this strcuture from C#.net,
        /// ( prizm 4.00 ), the same structure is re-used, only width of the font is not available in C#.net
        /// so the size parameter is stored in LOGFONT's width parameter.
        /// This structure is interpreted according to software version
        /// When reading Prizm 3.12 projects, it is interpreted as LOGFONT, while for Prizm 4.00
        /// projects, it is interpreted and used to create C#.net's Font object.
        /// 
        /// </summary>
        /// <param name="pFont"></param>
        /// <param name="pLogFont"></param>
        /// <param name="pFontInfo"></param>
        public static void ConvertFontToLogFont(Font pFont, LOGFONT pLogFont, ref FontInfo pFontInfo)
        {
            pFont.ToLogFont(pLogFont);

            pFontInfo._fFontHeight = pLogFont.lfHeight;
            //pFontInfo._fFontWidth = pLogFont.lfWidth;
            pFontInfo._fFontWidth = Convert.ToInt32(pFont.Size);
            pFontInfo._fEscapement = pLogFont.lfEscapement;
            pFontInfo._fOrientation = pLogFont.lfOrientation;
            pFontInfo._fWeight = pLogFont.lfWeight;
            pFontInfo._fItalic = pLogFont.lfItalic;
            pFontInfo._fUnderline = pLogFont.lfUnderline;
            pFontInfo._fStrikeOut = pLogFont.lfStrikeOut;
            pFontInfo._fCharSet = pLogFont.lfCharSet;
            pFontInfo._fOutPrecision = pLogFont.lfOutPrecision;
            pFontInfo._fClipPrecision = pLogFont.lfClipPrecision;
            pFontInfo._fQuality = pLogFont.lfQuality;
            pFontInfo._fPitchFamily = pLogFont.lfPitchAndFamily;
            pFontInfo._fLenOfFaceName = Convert.ToByte(pLogFont.lfFaceName.Length);


        }

        public static void SetTTFFontInfo(ref FontInfo pFont)
        {
            pFont._fPtSzForFont = 0;
            pFont._fFontHeight = 12;
            pFont._fFontWidth = 0;
            pFont._fEscapement = 0;
            pFont._fOrientation = 0;
            pFont._fWeight = 400;
            pFont._fItalic = 0;
            pFont._fUnderline = 0;
            pFont._fStrikeOut = 0;
            pFont._fCharSet = 129;
            pFont._fOutPrecision = 0;
            pFont._fClipPrecision = 0;
            pFont._fQuality = 0;
            pFont._fPitchFamily = 0;
            pFont._fLenOfFaceName = 5;
        }

        /// <summary>
        /// This function converts the pattern index in c sharp to its equivalent value used in prizm file format.
        /// </summary>
        /// <param name="pPattern">pattern index in c sharp</param>
        /// <param name="pPatternIndex">pattern index used in prizm file format</param>
        public static void SetPatternIndex(object pPattern, ref byte pPatternIndex)
        {

            #region Issue_2 Vijay
            #region New FP3035 Product Series_V2.3_Issue_469 SP
            //if (Convert.ToByte(pPattern) == 1)
            //    pPattern = 14;
            //else if (Convert.ToByte(pPattern) == 2)
            //    pPattern = 16;
            //else if (Convert.ToByte(pPattern) == 3)
            //    pPattern = 7;
            //else if (Convert.ToByte(pPattern) == 4)
            //    pPattern = 12;
            //else if (Convert.ToByte(pPattern) == 5)
            //    pPattern = 25;
            //else if (Convert.ToByte(pPattern) == 6)
            //    pPattern = 24;
            //else if (Convert.ToByte(pPattern) == 7)
            //    pPattern = 48;
            #endregion
            #endregion

            if (Convert.ToInt32(pPattern) == 0)
                pPatternIndex = Convert.ToByte(ClassList.PatternBrush.NOFILL);
            else if (Convert.ToInt32(pPattern) == 14)
                pPatternIndex = Convert.ToByte(ClassList.PatternBrush.ONE_BLACK_ONE_WHITE);
            else if (Convert.ToInt32(pPattern) == 16)
                pPatternIndex = Convert.ToByte(ClassList.PatternBrush.THREE_BLACK_ONE_WHITE);
            else if (Convert.ToInt32(pPattern) == 7)
                pPatternIndex = Convert.ToByte(ClassList.PatternBrush.ONE_BLACK_THREE_WHITE);
            else if (Convert.ToInt32(pPattern) == 12)
                pPatternIndex = Convert.ToByte(ClassList.PatternBrush.ONE_WHITE_ONE_BLACK);
            else if (Convert.ToInt32(pPattern) == 25)
                pPatternIndex = Convert.ToByte(ClassList.PatternBrush.HORIZONTAL);
            else if (Convert.ToInt32(pPattern) == 24)
                pPatternIndex = Convert.ToByte(ClassList.PatternBrush.VERTICAL);
            else if (Convert.ToInt32(pPattern) == 48)
                pPatternIndex = Convert.ToByte(ClassList.PatternBrush.CROSS);

        }

        public static byte GetNumberOfKeysForAStyle(KeypadStyles pKeypadStyle)
        {
            byte btNumberOfKeys = Convert.ToByte(NumberOfKeypadKeys.KEYPAD_16_KEYS);

            switch (pKeypadStyle)
            {
                case KeypadStyles.KEYPAD_16_KEYS_STYLE:
                    btNumberOfKeys = Convert.ToByte(NumberOfKeypadKeys.KEYPAD_16_KEYS);
                    break;

                case KeypadStyles.KEYPAD_12_KEYS_STYLE:
                    btNumberOfKeys = Convert.ToByte(NumberOfKeypadKeys.KEYPAD_12_KEYS);
                    break;

                case KeypadStyles.KEYPAD_20_KEYS_STYLE:
                    btNumberOfKeys = Convert.ToByte(NumberOfKeypadKeys.KEYPAD_20_KEYS);
                    break;

                case KeypadStyles.KEYPAD_25_KEYS_STYLE:
                    btNumberOfKeys = Convert.ToByte(NumberOfKeypadKeys.KEYPAD_25_KEYS);
                    break;

                case KeypadStyles.KEYPAD_15_KEYS_STYLE:
                    btNumberOfKeys = Convert.ToByte(NumberOfKeypadKeys.KEYPAD_15_KEYS);
                    break;

                case KeypadStyles.KEYPAD_8_KEYS_STYLE:
                    btNumberOfKeys = Convert.ToByte(NumberOfKeypadKeys.KEYPAD_8_KEYS);
                    break;

                case KeypadStyles.KEYPAD_5_KEYS_STYLE:
                    btNumberOfKeys = Convert.ToByte(NumberOfKeypadKeys.KEYPAD_5_KEYS);
                    break;

                case KeypadStyles.KEYPAD_3_KEYS_STYLE:
                    btNumberOfKeys = Convert.ToByte(NumberOfKeypadKeys.KEYPAD_3_KEYS);
                    break;

                case KeypadStyles.KEYPAD_14_KEYS_STYLE:
                    btNumberOfKeys = Convert.ToByte(NumberOfKeypadKeys.KEYPAD_14_KEYS);
                    break;

            }

            return btNumberOfKeys;
        }

        public static byte GetNumberOfKeysForAsciiStyle(AsciiKeypadStyles pKeypadStyle)
        {
            byte btNumberOfKeys = Convert.ToByte((NumberOfAsciiKeypadKeys.AsciiKeyPad_Keys));

            switch (pKeypadStyle)
            {
                case AsciiKeypadStyles.AsciiKeypad_Style:
                    btNumberOfKeys = Convert.ToByte(NumberOfAsciiKeypadKeys.AsciiKeyPad_Keys);
                    break;

                case AsciiKeypadStyles.AsciiNumericKeyPad_Style:
                    btNumberOfKeys = Convert.ToByte(NumberOfAsciiKeypadKeys.AsciiNumericKeyPadKeys);
                    break;

            }

            return btNumberOfKeys;
        }

        public static int GetCurrentPictureAddress()
        {
            return 0;
        }

        /// <summary>
        /// The method shifts bytes first 4 bits towards right and last 4 bits towards left.
        /// It is required for 285 product for color index assignment.
        /// </summary>
        /// <param name="pbtValue">byte value</param>
        /// <returns>Reversed byte value</returns>
        public static byte ReverseByte(byte pbtValue)
        {
            int ibtValue = Convert.ToInt32(pbtValue);
            int temp = ibtValue & 15;
            ibtValue = ibtValue >> 4;
            ibtValue = ibtValue + (temp << 4);
            return Convert.ToByte(ibtValue);
        }

        public static int GetPrizmPixels(Color pColor)
        {
            int iColor;
            int temp = 0;
            int colorFlag = 0;
            int colorFound = 0;
            int bitsOfTwoBytes = 16;
            int tempRed = pColor.R;
            int tempGreen = pColor.G;
            int tempBlue = pColor.B;
            int maxSupportedColors = CommonConstants.ProductDataInfo.ColorArray.GetLength(0);
            int redColor = 0, blueColor = 0, greenColor = 0;
            int redFromPalette, greenFromPalette, blueFromPalette;

            //Tulika 18th Dec 2006.....Prizm 140 has 255,255,255 instead of 240,240,240.
            if (maxSupportedColors != 2)
            {
                if (tempRed > MaximumIntensityOfRed)
                    tempRed = MaximumIntensityOfRed;
                if (tempGreen > MaximumIntensityOfGreen)
                    tempGreen = MaximumIntensityOfGreen;
                if (tempBlue > MaximumIntensityOfBlue)
                    tempBlue = MaximumIntensityOfBlue;
            }
            if ((tempRed & --bitsOfTwoBytes) != 0)
                colorFlag = 1;
            if ((tempGreen & bitsOfTwoBytes) != 0)
                colorFlag = 1;
            if ((tempBlue & bitsOfTwoBytes++) != 0)
                colorFlag = 1;
            iColor = Color.FromArgb(tempRed, tempGreen, tempBlue).ToArgb();
            if (colorFlag == 0)
                colorFlag = ReturnColorIndex(iColor);
            else
                colorFlag = -1;
            if (colorFlag == -1)
            {
                //Tulika 18th Dec 2006.....Prizm 140 has 255,255,255 instead of 240,240,240.
                if (maxSupportedColors != 2)
                {
                    redColor = (tempRed / bitsOfTwoBytes) * bitsOfTwoBytes;
                    if (tempRed - redColor >= 8)
                        redColor = redColor + bitsOfTwoBytes;
                    greenColor = (tempGreen / bitsOfTwoBytes) * bitsOfTwoBytes;
                    if (tempGreen - greenColor >= 8)
                        greenColor = greenColor + bitsOfTwoBytes;
                    blueColor = (tempBlue / bitsOfTwoBytes) * bitsOfTwoBytes;
                    if (tempBlue - blueColor >= 8)
                        blueColor = blueColor + bitsOfTwoBytes;

                    iColor = Color.FromArgb(redColor, greenColor, blueColor).ToArgb();
                    colorFlag = ReturnColorIndex(iColor);
                }
                else
                {
                    iColor = Color.FromArgb(tempRed, tempGreen, tempBlue).ToArgb();
                    colorFlag = ReturnColorIndex(iColor);
                }

                if (colorFlag == -1)
                {
                    for (int iCount = 1; iCount < 16; iCount++)
                    {
                        colorFound = 0;
                        maxSupportedColors = CommonConstants.ProductDataInfo.ColorArray.GetLength(0);
                        for (temp = 0; temp < maxSupportedColors; temp++)
                        {
                            //redFromPalette = CommonConstants.argb[temp, 0];
                            redFromPalette = CommonConstants.ProductDataInfo.ColorArray[temp, 0];
                            redFromPalette = redColor - redFromPalette;

                            if (redFromPalette == 0)
                                redFromPalette = bitsOfTwoBytes * iCount;
                            if (redFromPalette == -bitsOfTwoBytes * iCount || redFromPalette == bitsOfTwoBytes * iCount)
                            {
                                //greenFromPalette = CommonConstants.argb[temp, 1];
                                greenFromPalette = CommonConstants.ProductDataInfo.ColorArray[temp, 1];
                                greenFromPalette = greenColor - greenFromPalette;
                                if (greenFromPalette == 0)
                                    greenFromPalette = bitsOfTwoBytes * iCount;
                                if (greenFromPalette == -bitsOfTwoBytes * iCount || greenFromPalette == bitsOfTwoBytes * iCount)
                                {
                                    //blueFromPalette = CommonConstants.argb[temp, 2];
                                    blueFromPalette = CommonConstants.ProductDataInfo.ColorArray[temp, 2];
                                    blueFromPalette = blueColor - blueFromPalette;

                                    if (blueFromPalette == 0)
                                        blueFromPalette = bitsOfTwoBytes * iCount;
                                    if (blueFromPalette == -bitsOfTwoBytes * iCount || blueFromPalette == bitsOfTwoBytes * iCount)
                                        colorFound = 1;
                                }
                            }
                            if (colorFound == 1)
                                break;
                        }
                        if (colorFound == 1)
                            break;
                    }
                    colorFlag = temp;
                }
            }
            return colorFlag;
        }

        private static int ReturnColorIndex(int pColor)
        {
            int temp = 0;
            int index = -1;
            int tempFlag = 0;
            int maxColorsIntensity = 255;
            int maxPrizmColorsIntensity = 240;
            int tempRed, tempGreen, tempBlue;

            tempRed = Color.FromArgb(pColor).R;
            tempGreen = Color.FromArgb(pColor).G;
            tempBlue = Color.FromArgb(pColor).B;

            if (tempRed == maxColorsIntensity)
                tempRed = maxPrizmColorsIntensity;
            if (tempGreen == maxColorsIntensity)
                tempGreen = maxPrizmColorsIntensity;
            if (tempBlue == maxColorsIntensity)
                tempBlue = maxPrizmColorsIntensity;
            temp = maxColorsIntensity;
            for (index = 0; index <= temp && index < CommonConstants.ProductDataInfo.ColorArray.Length / 3; index++)
            {
                //if (tempRed == CommonConstants.argb[index, 0])
                //    if (tempGreen == CommonConstants.argb[index, 1])
                //        if (tempBlue == CommonConstants.argb[index, 2])
                if (tempRed == CommonConstants.ProductDataInfo.ColorArray[index, 0])
                    if (tempGreen == CommonConstants.ProductDataInfo.ColorArray[index, 1])
                        if (tempBlue == CommonConstants.ProductDataInfo.ColorArray[index, 2])
                            tempFlag = 1;
                if (tempFlag == 1)
                    break;
            }
            //            if (index == maxColorsIntensity+1)
            //                index = -1;
            if (tempFlag == 0)
                return -1;
            if (index == CommonConstants.ProductDataInfo.ColorArray.Length / 3)
                return index - 1;
            return index;
        }

        public static string DecimalToBinary(ushort pNumber)
        {
            ushort usBinaryHolder;
            char[] cBinaryArray;
            string strBinaryResult = "";
            while (pNumber > 0)
            {
                usBinaryHolder = Convert.ToUInt16(pNumber % 2);
                strBinaryResult += Convert.ToUInt16(usBinaryHolder);
                pNumber = Convert.ToUInt16(pNumber / 2);
            }

            cBinaryArray = strBinaryResult.ToCharArray();
            Array.Reverse(cBinaryArray);
            strBinaryResult = new string(cBinaryArray);
            return strBinaryResult;
        }

        public static string GetProductName(int pProjectID)
        {
            string strProductName = "";

            //Gets name from Configure.Xml
            strProductName = GetProductName_FromProductID(pProjectID);
            return strProductName;
        }

        public static string GetProductName_FromProductID(int ProductId)
        {
            string ProductName = "";
            string FileName = "";
            //DataRow[] dsProductInfo = dsRecentProjectList.Tables["UnitInformation"].Select("ModelNo = '" + ProductId + "'");

            DataSet ds1 = new DataSet();
            if (ProductId.ToString() == "1600" || ProductId.ToString() == "1603" ||
               ProductId.ToString() == "1612" || ProductId.ToString() == "1613")
            {
                FileName = @"USConfigure.xml";
            }
            else if (ProductId.ToString() == "1531" || ProductId.ToString() == "1532")
            {
                FileName = @"MapleConfigure.xml";
            }
            else if (ProductId.ToString() == "1907" || ProductId.ToString() == "1908")
            {
                FileName = @"HitachiConfigure.xml";
            }
            else
                FileName = @"Configure.xml";
            ds1.ReadXml(FileName);
            DataRow[] dsProductInfo = ds1.Tables["UnitInformation"].Select("ModelNo = '" + ProductId + "'");

            foreach (DataRow dr in dsProductInfo)
            {
                ProductName = dr["FolderName"].ToString();
            }

            return ProductName;
        }
        #region FlexiLogic/FlexiLogic_Slave_Driver_Changes Vijay
        public static int GetProductID_FromModelName(string ModelName)
        {
            int ProductId = 0;

            DataRow[] dsProductInfo = dsRecentProjectList.Tables["UnitInformation"].Select("Model = '" + ModelName + "'");

            foreach (DataRow dr in dsProductInfo)
            {
                ProductId = Convert.ToInt32(dr.ItemArray[13].ToString());
            }

            return ProductId;
        }
        #endregion
        //FP_CODE  R12  Haresh
        public static void GetCountIOValuesBase(int ProductID, ref int IP, ref int OP)
        {
            switch (ProductID)
            {
                case CommonConstants.PRODUCT_FP4020MR_L0808R:
                case CommonConstants.PRODUCT_OIS10_Plus: //06.04.15_Vijay
                #region New_Product_Addition Vijay
                case CommonConstants.PRODUCT_FP4020MR_L0808R_S3:
                #endregion
                case CommonConstants.PRODUCT_FP4020MR_L0808P:
                case CommonConstants.PRODUCT_FP4020MR_L0808N:
                case CommonConstants.PRODUCT_FP4030MR_0808R_A0400_S0://PRODUCT_FP4030MR_0808R_A0400_S0_addition_sammed
                case CommonConstants.PRODUCT_FP4030MR_L0808R_A0400U: //PRODUCT_FP4030MR_L0808R_A0400U Vijay
                case CommonConstants.PRODUCT_HH5P_HP200808D_P: //Hitachi Hi-Rel Vijay
                    IP = 8;
                    OP = 8;
                    break;

                case CommonConstants.PRODUCT_FP4030MR_L1208R:
                case CommonConstants.PRODUCT_HMC7030A_L:
                case CommonConstants.PRODUCT_OIS20_Plus: //06.04.15_Vijay
                case CommonConstants.PRODUCT_HH5P_HP301208D_R: //Hitachi Hi-Rel Vijay
                    IP = 12;
                    OP = 8;
                    break;

                case CommonConstants.PRODUCT_FP4030MR_L1210RP_A0402U: //PRODUCT_FP4030MR_L1210RP_A0402U Vijay
                case CommonConstants.PRODUCT_FP4030MR_L1210P_A0402U:  //PRODUCT_FP4030MR_L1210P_A0402U Vijay
                case CommonConstants.PRODUCT_FP4030MR_L1210RP://PRODUCT_FP4030MR_L1210RP Suyash
                case CommonConstants.PRODUCT_FP4030MR_L1210P://PRODUCT_FP4030MR_L1210P Suyash
                    IP = 12;
                    OP = 10;
                    break;
                #region Suyash_FP3020MR_L1608RP_Prod_Addition
                case CommonConstants.PRODUCT_FP3020MR_L1608RP:
                    IP = 16;
                    OP = 8;
                    break;
                #endregion
            }
        }
        #region delay for enable online mode SammedB
        public static string SetMonitoringDealy()
        {

            StreamReader srMonitoring = new StreamReader("MonitoringDealyUSB.txt");
            string IECstrdealy = "";
            string Nativestrdealy = "";
            string[] strtemp = new string[2];

            IECstrdealy = srMonitoring.ReadLine();
            Nativestrdealy = srMonitoring.ReadLine();

            if (ClassList.CommonConstants.g_Support_IEC_Ladder)
            {
                strtemp = IECstrdealy.Split('=');
            }
            else
            {
                strtemp = Nativestrdealy.Split('=');
            }

            string Dealy = strtemp[1];

            return Dealy;
        }
        #endregion
        public static int SetExpansion_ProductID(int ModuleType, int ProductID)
        {
            int exp_ProductID = 0;
            string str_productID = string.Empty;
            DataSet BaseModuleInfoSet = new DataSet();
            DataRow[] drModelInfo;
            if (ClassList.CommonConstants.IsProductPLC(ProductID))
                BaseModuleInfoSet.ReadXml("LdrConfigPLC.xml");
            else
            {
                //BaseModuleInfoSet.ReadXml("LdrIOFlexi.xml");
                #region FP3043_ExpansionSeries Vijay
                if (ProductID == ClassList.CommonConstants.PRODUCT_FP3043T_E || ProductID == ClassList.CommonConstants.PRODUCT_FP3043TN_E
                    || ProductID == ClassList.CommonConstants.PRODUCT_FP3070T_E || ProductID == ClassList.CommonConstants.PRODUCT_FP3070TN_E //SY-FP3_PlugableIO_Product_addition
                    || ProductID == ClassList.CommonConstants.PRODUCT_FP3102T_E || ProductID == ClassList.CommonConstants.PRODUCT_FP3102TN_E)//SY-FP3_PlugableIO_Product_addition

                    BaseModuleInfoSet.ReadXml("LdrIOFlexi3XX.xml");
                else
                    BaseModuleInfoSet.ReadXml(ClassList.CommonConstants.IOExpansionFile);//Maple Customization Changes
                #endregion
            }
            //drModelInfo = BaseModuleInfoSet.Tables["Slot_One"].Select("ExpProduct_ID='" + ProductID + "'");
            DataTable objDataTable = BaseModuleInfoSet.Tables["Slot_One"];

            for (int rowCount = 1; rowCount < objDataTable.Rows.Count; rowCount++)
            {
                if (rowCount == ModuleType)
                {
                    str_productID = objDataTable.Rows[rowCount]["ExpProduct_ID"].ToString();
                    exp_ProductID = Convert.ToInt32(str_productID);
                    break;
                }
            }

            return exp_ProductID;
        }

        public static int GetExpansion_ProductID(int ModuleType, int ProductID)
        {
            if (ModuleType == 0)
                return 0;

            int exp_ProductID = 0;
            string str_productID = string.Empty;
            DataSet BaseModuleInfoSet = new DataSet();
            DataRow[] drModelInfo;
            if (ClassList.CommonConstants.IsProductPLC(ProductID))
                BaseModuleInfoSet.ReadXml("LdrConfigPLC.xml");
            else
            {
                //BaseModuleInfoSet.ReadXml("LdrIOFlexi.xml");
                #region FP3043_ExpansionSeries Vijay
                if (ProductID == ClassList.CommonConstants.PRODUCT_FP3043T_E || ProductID == ClassList.CommonConstants.PRODUCT_FP3043TN_E
                     || ProductID == ClassList.CommonConstants.PRODUCT_FP3070T_E || ProductID == ClassList.CommonConstants.PRODUCT_FP3070TN_E //SY-FP3_PlugableIO_Product_addition
                     || ProductID == ClassList.CommonConstants.PRODUCT_FP3102T_E || ProductID == ClassList.CommonConstants.PRODUCT_FP3102TN_E)//SY-FP3_PlugableIO_Product_addition
                    BaseModuleInfoSet.ReadXml("LdrIOFlexi3XX.xml");
                else
                    BaseModuleInfoSet.ReadXml(ClassList.CommonConstants.IOExpansionFile);//Maple Customization Changes
                #endregion
            }

            //drModelInfo = BaseModuleInfoSet.Tables["Slot_One"].Select("ExpProduct_ID='" + ProductID + "'");
            DataTable objDataTable = BaseModuleInfoSet.Tables["Slot_One"];

            for (int rowCount = 1; rowCount < objDataTable.Rows.Count; rowCount++)
            {
                str_productID = objDataTable.Rows[rowCount]["ExpProduct_ID"].ToString();
                exp_ProductID = Convert.ToInt32(str_productID);
                if (exp_ProductID == ModuleType)
                {
                    //str_productID = objDataTable.Rows[rowCount]["Module_No"].ToString();                    
                    //exp_ProductID = Convert.ToInt32(str_productID);
                    exp_ProductID = rowCount;
                    return exp_ProductID;
                    //break;
                }
            }

            //return exp_ProductID;
            return 0;
        }

        public static int GetExpansion_Count(int ProductID)
        {
            DataSet BaseModuleInfoSet = new DataSet();
            DataRow[] drModelInfo;
            if (ClassList.CommonConstants.IsProductPLC(ProductID))
                #region FL100_Change_Sammed
                if (ClassList.CommonConstants.g_Support_IEC_Ladder)
                {
                    BaseModuleInfoSet.ReadXml("LdrConfigPLC_IEC.xml");
                }
                else
                    BaseModuleInfoSet.ReadXml("LdrConfigPLC.xml");
                #endregion
            else
            {
                #region FP3043_ExpansionSeries Vijay
                if (ProductID == ClassList.CommonConstants.PRODUCT_FP3043T_E || ProductID == ClassList.CommonConstants.PRODUCT_FP3043TN_E
                     || ProductID == ClassList.CommonConstants.PRODUCT_FP3070T_E || ProductID == ClassList.CommonConstants.PRODUCT_FP3070TN_E //SY-FP3_PlugableIO_Product_addition
                    || ProductID == ClassList.CommonConstants.PRODUCT_FP3102T_E || ProductID == ClassList.CommonConstants.PRODUCT_FP3102TN_E)//SY-FP3_PlugableIO_Product_addition

                    BaseModuleInfoSet.ReadXml("LdrIOFlexi3XX.xml");
                else
                    BaseModuleInfoSet.ReadXml(ClassList.CommonConstants.IOExpansionFile);//Maple Customization Changes
                #endregion
            }

            DataTable objDataTable = BaseModuleInfoSet.Tables["Slot_One"];

            return (objDataTable.Rows.Count - 1);
        }


        //new function
        public static string GetFolderName(int pProjectID)
        {
            //Proudct Name and folder name is same.
            return GetProductName(pProjectID);




        }

        //Punit mar '09
        /// <summary>
        /// Gets the product name for USB host
        /// </summary>
        /// <param name="pProjectID"></param>
        /// <returns></returns>
        public static string GetProductNameForUSBHost(int pProjectID)
        {
            string strProductName = "";
            switch ((ProductID)pProjectID)
            {
                #region New_Product_Addition Vijay
                case ProductID.PRODUCT_FP4020MR_L0808R_S3:
                    strProductName = "FP4020S3";
                    break;
                #endregion

                case ProductID.PRODUCT_TRPMIU0300A:
                    strProductName = "TRP0300A";
                    break;
                case ProductID.PRODUCT_TRPMIU0500A:
                    strProductName = "TRP0500A";
                    break;

                case ProductID.PRODUCT_FP4035T:
                    strProductName = "FP4035T";
                    break;
                case ProductID.PRODUCT_FP4035T_E:
                    strProductName = "FP4035TE";
                    break;
                #region New_Ethernet_Products_AMIT
                case ProductID.PRODUCT_FP4035TN:
                    strProductName = "FP4035TN";
                    break;
                case ProductID.PRODUCT_FP4035TN_E:
                    strProductName = "FP4035TNE";
                    break;
                case ProductID.PRODUCT_FP4057TN:
                    strProductName = "FP4057TN";
                    break;
                case ProductID.PRODUCT_FP4057TN_E:
                    strProductName = "FP4057TNE";
                    break;
                #endregion
                case ProductID.PRODUCT_FP4057T:
                    strProductName = "FP4057T";
                    break;
                #region New_Product_Addition_Herizomat AMIT
                case ProductID.PRODUCT_FP4057T_S2:
                    strProductName = "FP4057TS2";
                    break;
                #endregion
                case ProductID.PRODUCT_FP4057T_E:
                    strProductName = "FP4057TE";
                    break;
                #region New_Product_Addition_AllBodySoltn AMIT
                case ProductID.PRODUCT_FP4057T_E_S1:
                    strProductName = "FP4057TES1";
                    break;
                #endregion
                #region New_Product_Addition_Vertical Vijay
                case ProductID.PRODUCT_FP4057T_E_VERTICAL:
                    strProductName = "FP4057TE";
                    break;
                #endregion
                case ProductID.PRODUCT_FH9035T:
                    strProductName = "FH9035T";
                    break;
                case ProductID.PRODUCT_FH9035T_E:
                    strProductName = "FH9035TE";
                    break;
                case ProductID.PRODUCT_FH9057T:
                    strProductName = "FH9057T";
                    break;
                case ProductID.PRODUCT_FH9057T_E:
                    strProductName = "FH9057TE";
                    break;
                case ProductID.PRODUCT_HMC7035A_M:
                    strProductName = "HMC7035M";
                    break;

                case ProductID.PRODUCT_HMC7057A_M:
                    strProductName = "HMC7057M";
                    break;

                #region //Mapple Customization 2.0_Sanjay
                case ProductID.PRODUCT_HMC7043A_M:
                    strProductName = "HMC7043M";
                    break;

                case ProductID.PRODUCT_HMC7070A_M:
                    strProductName = "HMC7070M";
                    break;
                #endregion

                #region New FP3series product Addition Suyash
                case ProductID.PRODUCT_FP3043T://New FP3043T product Addition Suyash
                    strProductName = "FP3043T";
                    break;
                case ProductID.PRODUCT_FP3043TN://New FP3043TN product Addition Suyash
                    strProductName = "FP3043TN";
                    break;
                case ProductID.PRODUCT_FP3070T://New FP3070T product Addition Suyash
                    strProductName = "FP3070T";
                    break;
                case ProductID.PRODUCT_FP3102T://New FP3102T product Addition Suyash
                    strProductName = "FP3102T";
                    break;
                case ProductID.PRODUCT_FP3070TN://New FP3070TN product Addition Suyash
                    strProductName = "FP3070TN";
                    break;
                case ProductID.PRODUCT_FP3102TN://New FP3102TN product Addition Suyash
                    strProductName = "FP3102TN";
                    break;
                #region SY-FP3_PlugableIO_Product_addition
                case ProductID.PRODUCT_FP3070T_E://New FP3070T product Addition Suyash
                    strProductName = "FP3070TE";
                    break;
                case ProductID.PRODUCT_FP3102T_E://New FP3102T product Addition Suyash
                    strProductName = "FP3102TE";
                    break;
                case ProductID.PRODUCT_FP3070TN_E://New FP3070TN product Addition Suyash
                    strProductName = "FP3070TNE";
                    break;
                case ProductID.PRODUCT_FP3102TN_E://New FP3102TN product Addition Suyash
                    strProductName = "FP3102TNE";
                    break;
                #endregion
                #region OIS3Series_Vijay
                case ProductID.PRODUCT_OIS43E_Plus:
                    strProductName = "OIS43EP";
                    break;
                case ProductID.PRODUCT_OIS72E_Plus:
                    strProductName = "OIS72EP";
                    break;
                case ProductID.PRODUCT_OIS100E_Plus:
                    strProductName = "OIS100EP";
                    break;
                #endregion
                #region Hitachi Hi-Rel Vijay
                case ProductID.PRODUCT_HH5P_H43_NS:
                    strProductName = "HH5P-H43-NS";
                    break;
                case ProductID.PRODUCT_HH5P_H43_S:
                    strProductName = "HH5P-H43-S";
                    break;
                case ProductID.PRODUCT_HH5P_H70_NS:
                    strProductName = "HH5P-H70-NS";
                    break;
                case ProductID.PRODUCT_HH5P_H70_S:
                    strProductName = "HH5P-H70-S";
                    break;
                case ProductID.PRODUCT_HH5P_H100_NS:
                    strProductName = "HH5P-H100-NS";
                    break;
                case ProductID.PRODUCT_HH5P_H100_S:
                    strProductName = "HH5P-H100-S";
                    break;
                case ProductID.PRODUCT_HH5P_HP43_NS:
                    strProductName = "HH5P-HP43-NS";
                    break;
                case ProductID.PRODUCT_HH5P_HP70_NS:
                    strProductName = "HH5P-HP70-NS";
                    break;
                #endregion
                #region FP3043_ExpansionSeries Vijay
                case ProductID.PRODUCT_FP3043T_E:
                    strProductName = "FP3043TE";
                    break;
                case ProductID.PRODUCT_FP3043TN_E:
                    strProductName = "FP3043TNE";
                    break;
                #endregion
                #endregion
                #region New FP Models-43&70 SnehalM
                case ProductID.PRODUCT_FP5043T:
                    strProductName = "FP5043T";
                    break;
                case ProductID.PRODUCT_FP5043TN:
                    strProductName = "FP5043TN";
                    break;
                case ProductID.PRODUCT_FP5043T_E:
                    strProductName = "FP5043TE";
                    break;
                case ProductID.PRODUCT_FP5070T:
                    strProductName = "FP5070T";
                    break;
                case ProductID.PRODUCT_FP5070T_E:
                    strProductName = "FP5070TE";
                    break;
                case ProductID.PRODUCT_FP5121T:
                    strProductName = "FP5121T";
                    break;
                #endregion
                #region Toshiba US products SnehalM
                case ProductID.PRODUCT_OIS55_Plus:
                    strProductName = "OIS55P";
                    break;
                case ProductID.PRODUCT_OIS60_Plus:
                    strProductName = "OIS60P";
                    break;
                case ProductID.PRODUCT_OIS45_Plus:
                    strProductName = "OIS45P";
                    break;
                case ProductID.PRODUCT_OIS45E_Plus:
                    strProductName = "OIS45EP";
                    break;
                case ProductID.PRODUCT_OIS70_Plus:
                    strProductName = "OIS70P";
                    break;
                case ProductID.PRODUCT_OIS70E_Plus:
                    strProductName = "OIS70EP";
                    break;
                case ProductID.PRODUCT_OIS120A:
                    strProductName = "OIS120A";
                    break;
                #endregion
                //FP Issue no. 60 QA2010-11 Amit
                case ProductID.PRODUCT_FP5043TN_E:
                    strProductName = "FP5043TNE";
                    break;
                case ProductID.PRODUCT_FP5070TN:
                    strProductName = "FP5070TN";
                    break;
                case ProductID.PRODUCT_FP5070TN_E:
                    strProductName = "FP5070TNE";
                    break;
                case ProductID.PRODUCT_FP5121TN:
                    strProductName = "FP5121TN";
                    break;
                case ProductID.PRODUCT_FP5070T_E_S2://New FP5070T-E-S2 product Addition Suyash
                    strProductName = "FP5070TES2";
                    break;
                #region //Haresh_5121TN-SO
                case ProductID.PRODUCT_FP5121TN_S0:
                    strProductName = "FP5121TN-S0";
                    break;
                #endregion
                case ProductID.PRODUCT_FL055://FL055_Product_Addition_Suyash
                    strProductName = "FL0550404P0802U"; //FL055_RenameTo_FL550404P0802U Vijay
                    break;
                //
                //New Ethernet Models - SnehaK
                case ProductID.PRODUCT_TRPMIU0300E:
                    strProductName = "TRP0300E";
                    break;

                case ProductID.PRODUCT_TRPMIU0500E:
                    strProductName = "TRP0500E";
                    break;
                //End

                //Toshiba-Japan_Product
                case ProductID.PRODUCT_TRPMIU0400E:
                    strProductName = "TRP0400E";
                    break;

                case ProductID.PRODUCT_TRPMIU0700E:
                    strProductName = "TRP0700E";
                    break;
                //End
                #region Panasonic sammed 2.0
                case ProductID.PRODUCT_GTXL07N:
                    strProductName = "GTXL07N";
                    break;
                case ProductID.PRODUCT_GTXL10N:
                    strProductName = "GTXL10N";
                    break;
                #endregion
                #region Issue_1295 Vijay
                case ProductID.PRODUCT_FL050_V2:
                    strProductName = "FL050V2"; //Issue_1299 Vijay
                    break;
                #endregion

                //Create appln in USB folder for all Products-Haresh
                default: strProductName = GetFolderName(pProjectID);
                    break;
                //End
            }




            return strProductName;
        }

        //Punit mar '09
        /// <summary>
        /// Gets the product name for USB host file name
        /// </summary>
        /// <param name="pProjectID"></param>
        /// <returns></returns>
        public static string GetProductNameForUSBHostFileName(int pProjectID)
        {
            string strProductName = "";
            switch ((ProductID)pProjectID)
            {
                #region New_Product_Addition Vijay
                case ProductID.PRODUCT_FP4020MR_L0808R_S3:
                    strProductName = "FP4020S3";
                    break;
                #endregion
                case ProductID.PRODUCT_TRPMIU0300A:
                    strProductName = "TRP0300A";
                    break;
                case ProductID.PRODUCT_TRPMIU0500A:
                    strProductName = "TRP0500A";
                    break;
                case ProductID.PRODUCT_FP4035T:
                    strProductName = "FP4035T";
                    break;
                case ProductID.PRODUCT_FP4035T_E:
                    strProductName = "FP4035TE";
                    break;
                #region New_Ethernet_Products_AMIT
                case ProductID.PRODUCT_FP4035TN:
                    strProductName = "FP4035TN";
                    break;
                case ProductID.PRODUCT_FP4035TN_E:
                    strProductName = "FP4035TNE";
                    break;
                case ProductID.PRODUCT_FP4057TN:
                    strProductName = "FP4057TN";
                    break;
                case ProductID.PRODUCT_FP4057TN_E:
                    strProductName = "FP4057TNE";
                    break;
                #endregion
                case ProductID.PRODUCT_FP4057T:
                    strProductName = "FP4057T";
                    break;
                #region New_Product_Addition_Herizomat AMIT
                case ProductID.PRODUCT_FP4057T_S2:
                    strProductName = "FP4057TS2";
                    break;
                #endregion
                case ProductID.PRODUCT_FP4057T_E:
                    strProductName = "FP4057TE";
                    break;
                #region New_Product_Addition_AllBodySoltn AMIT
                case ProductID.PRODUCT_FP4057T_E_S1:
                    strProductName = "FP4057TES1";
                    break;
                #endregion
                #region New_Product_Addition_Vertical Vijay
                case ProductID.PRODUCT_FP4057T_E_VERTICAL:
                    strProductName = "FP4057TE";
                    break;
                #endregion
                case ProductID.PRODUCT_FH9035T:
                    strProductName = "FH9035T";
                    break;
                case ProductID.PRODUCT_FH9035T_E:
                    strProductName = "FH9035TE";
                    break;
                case ProductID.PRODUCT_FH9057T:
                    strProductName = "FH9057T";
                    break;
                case ProductID.PRODUCT_FH9057T_E:
                    strProductName = "FH9057TE";
                    break;

                case ProductID.PRODUCT_HMC7035A_M:
                    strProductName = "HMC7035M";
                    break;

                case ProductID.PRODUCT_HMC7057A_M:
                    strProductName = "HMC7057M";
                    break;

                #region //Mapple Customization 2.0_Sanjay
                case ProductID.PRODUCT_HMC7043A_M:
                    strProductName = "HMC7043M";
                    break;

                case ProductID.PRODUCT_HMC7070A_M:
                    strProductName = "HMC7070M";
                    break;
                #endregion

                case ProductID.PRODUCT_FL055://FL055_Product_Addition_Suyash
                    strProductName = "FL0550404P0802U"; //FL055_RenameTo_FL550404P0802U Vijay
                    break;

                #region New FP3series product Addition Suyash
                case ProductID.PRODUCT_FP3043T://New FP3043T product Addition Suyash
                    strProductName = "FP3043T";
                    break;
                case ProductID.PRODUCT_FP3043TN://New FP3043TN product Addition Suyash
                    strProductName = "FP3043TN";
                    break;
                case ProductID.PRODUCT_FP3070T://New FP3070T product Addition Suyash
                    strProductName = "FP3070T";
                    break;
                case ProductID.PRODUCT_FP3070TN://New FP3070TN product Addition Suyash
                    strProductName = "FP3070TN";
                    break;
                case ProductID.PRODUCT_FP3102T://New FP3102T product Addition Suyash
                    strProductName = "FP3102T";
                    break;
                case ProductID.PRODUCT_FP3102TN://New FP3102TN product Addition Suyash
                    strProductName = "FP3102TN";
                    break;
                #region SY-FP3_PlugableIO_Product_addition
                case ProductID.PRODUCT_FP3070T_E://New FP3070T product Addition Suyash
                    strProductName = "FP3070TE";
                    break;
                case ProductID.PRODUCT_FP3070TN_E://New FP3070TN product Addition Suyash
                    strProductName = "FP3070TNE";
                    break;
                case ProductID.PRODUCT_FP3102T_E://New FP3102T product Addition Suyash
                    strProductName = "FP3102TE";
                    break;
                case ProductID.PRODUCT_FP3102TN_E://New FP3102TN product Addition Suyash
                    strProductName = "FP3102TNE";
                    break;
                #endregion
                #region OIS3Series_Vijay
                case ProductID.PRODUCT_OIS43E_Plus:
                    strProductName = "OIS43EP";
                    break;
                case ProductID.PRODUCT_OIS72E_Plus:
                    strProductName = "OIS72EP";
                    break;
                case ProductID.PRODUCT_OIS100E_Plus:
                    strProductName = "OIS100EP";
                    break;
                #endregion
                #region Hitachi Hi-Rel Vijay
                case ProductID.PRODUCT_HH5P_H43_NS:
                    strProductName = "HH5P-H43-NS";
                    break;
                case ProductID.PRODUCT_HH5P_H43_S:
                    strProductName = "HH5P-H43-S";
                    break;
                case ProductID.PRODUCT_HH5P_H70_NS:
                    strProductName = "HH5P-H70-NS";
                    break;
                case ProductID.PRODUCT_HH5P_H70_S:
                    strProductName = "HH5P-H70-S";
                    break;
                case ProductID.PRODUCT_HH5P_H100_NS:
                    strProductName = "HH5P-H100-NS";
                    break;
                case ProductID.PRODUCT_HH5P_H100_S:
                    strProductName = "HH5P-H100-S";
                    break;
                case ProductID.PRODUCT_HH5P_HP43_NS:
                    strProductName = "HH5P-HP43-NS";
                    break;
                case ProductID.PRODUCT_HH5P_HP70_NS:
                    strProductName = "HH5P-HP70-NS";
                    break;
                #endregion
                #region FP3043_ExpansionSeries Vijay
                case ProductID.PRODUCT_FP3043T_E:
                    strProductName = "FP3043TE";
                    break;
                case ProductID.PRODUCT_FP3043TN_E:
                    strProductName = "FP3043TNE";
                    break;
                #endregion
                #endregion
                #region New FP Models-43&70 SnehalM
                case ProductID.PRODUCT_FP5043T:
                    strProductName = "FP5043T";
                    break;
                case ProductID.PRODUCT_FP5043TN:
                    strProductName = "FP5043TN";
                    break;
                case ProductID.PRODUCT_FP5043T_E:
                    strProductName = "FP5043TE";
                    break;
                case ProductID.PRODUCT_FP5043TN_E:
                    strProductName = "FP5043TNE";
                    break;
                case ProductID.PRODUCT_FP5070T:
                    strProductName = "FP5070T";
                    break;
                case ProductID.PRODUCT_FP5070TN:
                    strProductName = "FP5070TN";
                    break;
                case ProductID.PRODUCT_FP5070T_E:
                    strProductName = "FP5070TE";
                    break;
                case ProductID.PRODUCT_FP5070TN_E:
                    strProductName = "FP5070TNE";
                    break;
                case ProductID.PRODUCT_FP5070T_E_S2://New FP5070T-E-S2 product Addition Suyash
                    strProductName = "FP5070TES2";
                    break;
                case ProductID.PRODUCT_FP5121T:
                    strProductName = "FP5121T";
                    break;
                case ProductID.PRODUCT_FP5121TN:
                    strProductName = "FP5121TN";
                    break;
                #region //Haresh_5121TN-SO
                case ProductID.PRODUCT_FP5121TN_S0:
                    strProductName = "FP5121TN-S0";
                    break;
                #endregion
                #endregion
                #region Toshiba US products SnehalM
                case ProductID.PRODUCT_OIS55_Plus:
                    strProductName = "OIS55P";
                    break;
                case ProductID.PRODUCT_OIS60_Plus:
                    strProductName = "OIS60P";
                    break;
                case ProductID.PRODUCT_OIS45_Plus:
                    strProductName = "OIS45P";
                    break;
                case ProductID.PRODUCT_OIS45E_Plus:
                    strProductName = "OIS45EP";
                    break;
                case ProductID.PRODUCT_OIS70_Plus:
                    strProductName = "OIS70P";
                    break;
                case ProductID.PRODUCT_OIS70E_Plus:
                    strProductName = "OIS70EP";
                    break;
                case ProductID.PRODUCT_OIS120A:
                    strProductName = "OIS120A";
                    break;
                #endregion

                //New Ethernet Models - SnehaK
                case ProductID.PRODUCT_TRPMIU0300E:
                    strProductName = "TRP0300E";
                    break;

                case ProductID.PRODUCT_TRPMIU0500E:
                    strProductName = "TRP0500E";
                    break;
                //End

                //Toshiba-Japan_Product
                case ProductID.PRODUCT_TRPMIU0400E:
                    strProductName = "TRP0400E";
                    break;
                case ProductID.PRODUCT_TRPMIU0700E:
                    strProductName = "TRP0700E";
                    break;
                //End
                #region Panasonic sammed 2.0
                case ProductID.PRODUCT_GTXL07N:
                    strProductName = "GTXL07N";
                    break;
                case ProductID.PRODUCT_GTXL10N:
                    strProductName = "GTXL10N";
                    break;
                #endregion

                #region Issue_1295 Vijay
                case ProductID.PRODUCT_FL050_V2:
                    strProductName = "FL050V2"; //Issue_1299 Vijay
                    break;
                #endregion

                //Create appln in USB folder for all Products-Haresh
                default: strProductName = GetFolderName(pProjectID);
                    break;
                //End
            }


            return strProductName;
        }

        #region FP_Vertical_Product_Change_AMIT
        /// <summary>
        /// Gets Row Number from Table
        /// </summary>
        /// <param name="Model"></param>
        /// <param name="SubModel"></param>
        public static int GetRowNumber(string Model, string SubModel, string TableName)
        {
            DataTable objDataTable;
            int rowNo = 0;

            objDataTable = dsRecentProjectList.Tables[TableName];

            for (int row = 0; row < objDataTable.Rows.Count; row++)
            {
                if (Model == objDataTable.Rows[row]["ModelSeries"].ToString() && SubModel == objDataTable.Rows[row]["Model"].ToString())
                {
                    rowNo = row;
                    break;
                }
            }
            return rowNo;
        }

        public static bool IsVerticalProduct(int ProductId)
        {
            bool IsVertical = false;
            switch (ProductId)
            {
                case ClassList.CommonConstants.PRODUCT_FP4030MT_S1_VERTICAL:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_VERTICAL: //FP4030MT_addition_AMIT
                #region New FP4030MT Vertical Series Addition Vijay
                case ClassList.CommonConstants.PRODUCT_FP4030MT_REV1_VERTICAL:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RN_A0201_VERTICAL:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201_VERTICAL:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RN_VERTICAL:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RP_VERTICAL:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201L_VERTICAL://FP4030MT_L0808RP_A0201L(Vertical)_addition_sammed
                #endregion
                case ClassList.CommonConstants.PRODUCT_OIS40_Plus_VERTICAL://Toshiba_US New product Addition
                case ClassList.CommonConstants.PRODUCT_FP4057T_E_VERTICAL: //New_Product_Addition_Vertical Vijay
                    IsVertical = true;
                    break;
                #region VerticalOri_SY
                default:
                    if (ClassList.CommonConstants._isProductVertical == true)
                    {
                        IsVertical = true;
                    }
                    break;
                #endregion
            }

            return IsVertical;
        }

        #region New_Product_Addition_Vertical Vijay-AMIT
        //Amit 22 Feb' 13
        /// <summary>
        /// This function will be called in case of Vertical product only, 
        /// if product is rotated vertically AntiClock wise then it will return true
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        public static bool IsProductRotatedAntiClockWise(int productID)
        {
            bool flag = false;
            switch (productID)
            {
                case ClassList.CommonConstants.PRODUCT_FP4030MT_S1_VERTICAL:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_VERTICAL: //FP4030MT_addition_AMIT
                #region New FP4030MT Vertical Series Addition Vijay
                case ClassList.CommonConstants.PRODUCT_FP4030MT_REV1_VERTICAL:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RN_A0201_VERTICAL:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201_VERTICAL:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RN_VERTICAL:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RP_VERTICAL:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201L_VERTICAL://FP4030MT_L0808RP_A0201L(Vertical)_addition_sammed
                #endregion
                case ClassList.CommonConstants.PRODUCT_OIS40_Plus_VERTICAL://Toshiba_US New product Addition
                case ClassList.CommonConstants.PRODUCT_FP4057T_E_VERTICAL: //New_Product_Addition_Vertical Vijay
                    flag = true;
                    break;
                #region VerticalOri_SY
                default:
                    if (ClassList.CommonConstants._isProductVertical == true)
                    {
                        flag = true;
                    }
                    break;
                #endregion
            }

            return flag;
        }


        //Amit 22 Feb' 13
        /// <summary>
        /// This function will be called in case of Vertical product only, 
        /// if product is rotated vertically Clock wise then it will return true
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        public static bool IsProductRotatedClockWise(int productID)
        {
            bool flag = false;
            switch (productID)
            {
                case ClassList.CommonConstants.PRODUCT_FP4057T_E_VERTICAL:
                    flag = true;
                    break;
                #region VerticalOri_SY
                default:
                    if (ClassList.CommonConstants._isProductVertical == true)
                    {
                        if (ClassList.CommonConstants.Is4030MTVerticalProduct(ClassList.CommonConstants.ProductDataInfo.iProductID)
                            || ClassList.CommonConstants.ProductDataInfo.iProductID == ClassList.CommonConstants.PRODUCT_FP4030MT_L0808P //VerticalOri_SY_Keypad-4030MT
                            || ClassList.CommonConstants.ProductDataInfo.iProductID == ClassList.CommonConstants.PRODUCT_FP4030MT_L0808P_A0201U
                            || ClassList.CommonConstants.ProductDataInfo.iProductID == ClassList.CommonConstants.PRODUCT_FP4030MT_L0808P_A0402L)//Suyash_Product_Addition_FP4030MT_L0808P_A0402L//VerticalOri_SY_Keypad-4030MT_Temp
                        {
                            flag = false;
                        }
                        else
                        {
                            flag = true;
                        }
                    }
                    break;
                #endregion
            }

            return flag;
        }
        #endregion

        #region VerticalOri_SY_Keypad-4030MT_Temp
        public static bool IsFP4030MTVerticalProduct(int ProductId)
        {
            //   return true;

            String FileName = @"VerticalproductList.xml";

            String TableName = "Product";

            DataSet objDataSet = new DataSet();


            int ProdId = 0;

            System.IO.FileStream fsReadXml = null;

            try
            {
                if (File.Exists(FileName) == true)
                {
                    fsReadXml = new System.IO.FileStream(FileName, FileMode.Open);

                    objDataSet.ReadXml(fsReadXml);

                    DataTable objDataTable = objDataSet.Tables[TableName];

                    for (int i = 0; i < objDataTable.Rows.Count; i++)
                    {
                        ProdId = Convert.ToInt32(objDataTable.Rows[i][1].ToString().Trim());

                        if (ProdId == ProductId)
                        {
                            fsReadXml.Close();
                            return true;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                // MessageBox.Show("Error in opening file ProductID.xml");
                if (fsReadXml != null)
                    fsReadXml.Close();
                return true;
            }
            if (fsReadXml != null)
                fsReadXml.Close();
            return false;
        }
        #endregion

        #region VerticalOri_SY_Keypad-4030MT_Temp
        public static bool VerticalProductRemoveList(int ProductId)
        {
            String FileName = @"VerticalproductList.xml";
            String TableName = "ListToRemove";
            DataSet objDataSet = new DataSet();
            int ProdId = 0;
            System.IO.FileStream fsReadXml = null;
            try
            {
                if (File.Exists(FileName) == true)
                {
                    fsReadXml = new System.IO.FileStream(FileName, FileMode.Open);
                    objDataSet.ReadXml(fsReadXml);
                    DataTable objDataTable = objDataSet.Tables[TableName];

                    for (int i = 0; i < objDataTable.Rows.Count; i++)
                    {
                        ProdId = Convert.ToInt32(objDataTable.Rows[i][0].ToString().Trim());
                        if (ProdId == ProductId)
                        {
                            fsReadXml.Close();
                            return true;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                if (fsReadXml != null)
                    fsReadXml.Close();
                return true;
            }
            if (fsReadXml != null)
                fsReadXml.Close();
            return false;
        }
        #endregion

        #region VerticalOri_SY_Keypad-4030MT_Temp
        public static bool IsProductSupported(int ProductId, ref int EquivVertiProductID)
        {
            //   return true;

            String FileName = @"VerticalproductList.xml";

            String TableName = "Product";

            DataSet objDataSet = new DataSet();


            int ProdId = 0;

            System.IO.FileStream fsReadXml = null;

            try
            {
                if (File.Exists(FileName) == true)
                {
                    fsReadXml = new System.IO.FileStream(FileName, FileMode.Open);

                    objDataSet.ReadXml(fsReadXml);

                    DataTable objDataTable = objDataSet.Tables[TableName];

                    for (int i = 0; i < objDataTable.Rows.Count; i++)
                    {
                        ProdId = Convert.ToInt32(objDataTable.Rows[i][0].ToString().Trim());

                        if (ProdId == ProductId)
                        {
                            EquivVertiProductID = Convert.ToInt32(objDataTable.Rows[i][1].ToString().Trim());
                            fsReadXml.Close();
                            return true;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                if (fsReadXml != null)
                    fsReadXml.Close();
                return true;
            }
            if (fsReadXml != null)
                fsReadXml.Close();
            return false;
        }
        #endregion

        #endregion

        //Punit mar '09
        /// <summary>
        /// Gets the instruction file name which is used for USB
        /// </summary>
        /// <param name="pProjectID"></param>
        /// <returns></returns>


        //Following Function Written By Samir Karve
        /// <summary>
        /// This Function returns Ushort value. It combines two bytes of data and combine it to ushort.
        /// 
        /// </summary>
        /// <param name="a">First Byte</param>
        /// <param name="b">Second Byte</param>
        /// <returns>Ushort</returns>
        public static ushort MAKEUSHORT(byte a, byte b)
        {
            return (ushort)(a | (b << 8));
        }

        public static byte GetGroupNumber(byte btbitAlarmNo)
        {
            byte btgroupno = 17;
            if ((btbitAlarmNo >= 0) && (btbitAlarmNo <= 15))
                return btgroupno = 0;
            if ((btbitAlarmNo >= 16) && (btbitAlarmNo <= 31))
                return btgroupno = 1;
            if ((btbitAlarmNo >= 32) && (btbitAlarmNo <= 47))
                return btgroupno = 2;
            if ((btbitAlarmNo >= 48) && (btbitAlarmNo <= 63))
                return btgroupno = 3;
            if ((btbitAlarmNo >= 64) && (btbitAlarmNo <= 79))
                return btgroupno = 4;
            if ((btbitAlarmNo >= 80) && (btbitAlarmNo <= 95))
                return btgroupno = 5;
            if ((btbitAlarmNo >= 96) && (btbitAlarmNo <= 111))
                return btgroupno = 6;
            if ((btbitAlarmNo >= 112) && (btbitAlarmNo <= 127))
                return btgroupno = 7;
            if ((btbitAlarmNo >= 128) && (btbitAlarmNo <= 143))
                return btgroupno = 8;
            if ((btbitAlarmNo >= 144) && (btbitAlarmNo <= 159))
                return btgroupno = 9;
            if ((btbitAlarmNo >= 160) && (btbitAlarmNo <= 175))
                return btgroupno = 10;
            if ((btbitAlarmNo >= 176) && (btbitAlarmNo <= 191))
                return btgroupno = 11;
            if ((btbitAlarmNo >= 192) && (btbitAlarmNo <= 207))
                return btgroupno = 12;
            if ((btbitAlarmNo >= 208) && (btbitAlarmNo <= 223))
                return btgroupno = 13;
            if ((btbitAlarmNo >= 224) && (btbitAlarmNo <= 239))
                return btgroupno = 14;
            if ((btbitAlarmNo >= 240) && (btbitAlarmNo <= 255))
                return btgroupno = 15;
            return btgroupno;
        }

        public static Graphics CreateMemoryDC(int pTLX, int pTLY, int pBRX, int pBRY)
        {
            Graphics graphicsMemDC;
            IntPtr intptrHDC;
            Bitmap bitmapMemBmp;

            bitmapMemBmp = new Bitmap((pBRX - pTLX + 2), (pBRY - pTLY + 1));
            intptrHDC = CreateCompatibleDC((IntPtr)null);
            SelectObject(intptrHDC, bitmapMemBmp.GetHbitmap());
            graphicsMemDC = Graphics.FromHdc(intptrHDC);

            return graphicsMemDC;
        }

        public static bool IsTouchScreenObject(int pProductId)
        {
            if (pProductId > 509)
                return true;
            else
                return false;
        }

        public static bool IsTemplateScreen(int pActiveScreenNumber)
        {
            if (pActiveScreenNumber >= ClassList.CommonConstants.START_TEMPLATE_SCREEN && pActiveScreenNumber <= ClassList.CommonConstants.END_TEMPLATE_SCREENS)
            {
                return true;
            }
            else
                return false;
        }

        public static bool IsPopUpScreen(int pActiveScreenNumber)
        {
            if (pActiveScreenNumber >= ClassList.CommonConstants.START_POPUP_SCREEN && pActiveScreenNumber <= ClassList.CommonConstants.MAX_KEYPAD_SCREENS)
            {
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// The overloaded method used for 3.12 file formate to suppost 32-bit data for task.
        /// </summary>
        /// <param name="pNumber">Unsigned Integer Number</param>
        /// <returns>Binary String Value</returns>
        public static string DecimalToBinary(uint pNumber)
        {
            uint uiBinaryHolder;
            char[] cBinaryArray;
            string strBinaryResult = "";
            while (pNumber > 0)
            {
                uiBinaryHolder = Convert.ToUInt32(pNumber % 2);
                strBinaryResult += Convert.ToUInt32(uiBinaryHolder);
                pNumber = Convert.ToUInt32(pNumber / 2);
            }

            cBinaryArray = strBinaryResult.ToCharArray();
            Array.Reverse(cBinaryArray);
            strBinaryResult = new string(cBinaryArray);
            return strBinaryResult;
        }


        //Added by Samir 8th May 2007
        /// <summary>
        /// This Function Returns Selected Shape Default Width
        /// </summary>
        /// <param name="pShapeID">Shape ID</param>
        /// <returns>Returns byte(Default Width)</returns>
        public static int GetShapeDefaultWidthSize(byte pShapeID)
        {
            int btShapeDefaultSizeX = 10;
            //switch ((ClassList.DrawingObjects)pShapeID)
            //{

            //    case ClassList.DrawingObjects.ALARM:
            //        if (IsProductCompatibleWith4030(CommonConstants.ProductDataInfo.iProductID) == true)
            //            btShapeDefaultSizeX = 70;
            //        else
            //            btShapeDefaultSizeX = 100;
            //        break;
            //    case ClassList.DrawingObjects.ARC:
            //        btShapeDefaultSizeX = 10;
            //        break;
            //    case ClassList.DrawingObjects.BITBUTTON:
            //        btShapeDefaultSizeX = 45;
            //        break;
            //    case ClassList.DrawingObjects.BITMAP:
            //        if (IsProductCompatibleWith4030(CommonConstants.ProductDataInfo.iProductID) == true)
            //            btShapeDefaultSizeX = 20;
            //        else
            //            btShapeDefaultSizeX = 100;
            //        break;

            //    case ClassList.DrawingObjects.ADVANCEDPICTURE:
            //        btShapeDefaultSizeX = 100;
            //        break;

            //    case ClassList.DrawingObjects.BITLAMP:
            //        if (IsProductCompatibleWith4030(CommonConstants.ProductDataInfo.iProductID) == true)
            //            btShapeDefaultSizeX = 30;
            //        else
            //            btShapeDefaultSizeX = 45;

            //        break;
            //    case ClassList.DrawingObjects.DATAENTRYCOIL:
            //        btShapeDefaultSizeX = 45;
            //        break;
            //    case ClassList.DrawingObjects.DATAENTRYREGISTER:
            //        btShapeDefaultSizeX = 45;
            //        break;
            //    case ClassList.DrawingObjects.DATE:
            //        btShapeDefaultSizeX = 10;
            //        break;
            //    case ClassList.DrawingObjects.DISPLAYDATACOIL:
            //        btShapeDefaultSizeX = 30;
            //        break;
            //    case ClassList.DrawingObjects.DISPLAYDATAREGISTER:
            //        btShapeDefaultSizeX = 45;
            //        break;
            //    case ClassList.DrawingObjects.DISPLAYDATAREGISTERTEXT:
            //        btShapeDefaultSizeX = 30;
            //        break;
            //    case ClassList.DrawingObjects.ELLIPSE:
            //        if (IsProductCompatibleWith4030(CommonConstants.ProductDataInfo.iProductID) == true)
            //            btShapeDefaultSizeX = 20;
            //        else
            //            btShapeDefaultSizeX = 40;
            //        break;
            //    case ClassList.DrawingObjects.GOTO:
            //        btShapeDefaultSizeX = 55;
            //        break;
            //    case ClassList.DrawingObjects.GROUP:
            //        btShapeDefaultSizeX = 10;
            //        break;
            //    case ClassList.DrawingObjects.HISTORICALTRENDS:
            //        btShapeDefaultSizeX = 200;
            //        break;
            //    case ClassList.DrawingObjects.HOLDOFF:
            //        btShapeDefaultSizeX = 10;
            //        break;
            //    case ClassList.DrawingObjects.HOLDON:
            //        btShapeDefaultSizeX = 10;
            //        break;
            //    case ClassList.DrawingObjects.LINE:
            //        btShapeDefaultSizeX = 20;
            //        break;
            //    case ClassList.DrawingObjects.MULTIPLEBARGRAPH:
            //        if (IsProductCompatibleWith4030(CommonConstants.ProductDataInfo.iProductID) == true)
            //            // btShapeDefaultSizeX = 100;
            //            btShapeDefaultSizeX = 118; //Issue_777 Vijay
            //        else
            //            btShapeDefaultSizeX = 150;
            //        break;
            //    case ClassList.DrawingObjects.NEXT:
            //        btShapeDefaultSizeX = 55;
            //        break;
            //    case ClassList.DrawingObjects.NUMERICKEYPAD:
            //        btShapeDefaultSizeX = 150;
            //        break;
            //    case ClassList.DrawingObjects.PIE:
            //        btShapeDefaultSizeX = 10;
            //        break;
            //    case ClassList.DrawingObjects.POLYGON:
            //        btShapeDefaultSizeX = 10;
            //        break;
            //    case ClassList.DrawingObjects.POLYLINE:
            //        btShapeDefaultSizeX = 10;
            //        break;
            //    case ClassList.DrawingObjects.GOTOPOPUPSCREEN:
            //        btShapeDefaultSizeX = 60;
            //        break;
            //    case ClassList.DrawingObjects.PREV:
            //        btShapeDefaultSizeX = 75;
            //        break;
            //    case ClassList.DrawingObjects.RECTANGLE:
            //        if (IsProductCompatibleWith4030(CommonConstants.ProductDataInfo.iProductID) == true)
            //            btShapeDefaultSizeX = 20;
            //        else
            //            btShapeDefaultSizeX = 70;
            //        break;
            //    case ClassList.DrawingObjects.RESET:
            //        btShapeDefaultSizeX = 60;
            //        break;
            //    //ShitalG_PER466
            //    case ClassList.DrawingObjects.MOMENTARY:
            //        btShapeDefaultSizeX = 90;
            //        break;
            //    //
            //    case ClassList.DrawingObjects.ROUNDRECT:
            //        if (IsProductCompatibleWith4030(CommonConstants.ProductDataInfo.iProductID) == true)
            //            btShapeDefaultSizeX = 30;
            //        else
            //            btShapeDefaultSizeX = 50;
            //        break;
            //    case ClassList.DrawingObjects.SET:
            //        btShapeDefaultSizeX = 50;
            //        break;
            //    case ClassList.DrawingObjects.SINGLEBARGRAPH:
            //        {
            //            if (IsProductIsTextBased(CommonConstants.ProductDataInfo.iProductID) == true)
            //            {
            //                btShapeDefaultSizeX = 48;
            //            }
            //            else if (IsProductIsTextAndGraphicsBased(CommonConstants.ProductDataInfo.iProductID) == true)
            //            {
            //                btShapeDefaultSizeX = 20;
            //            }
            //            else
            //            {
            //                btShapeDefaultSizeX = 40;
            //            }
            //            break;
            //        }
            //    case ClassList.DrawingObjects.TEXTOBJECT:
            //        if (IsFixedGridSizeProduct(CommonConstants.ProductDataInfo.iProductID) == true)
            //            btShapeDefaultSizeX = 48;
            //        else
            //            // btShapeDefaultSizeX = 32;
            //            btShapeDefaultSizeX = 24; //Text 6x4=24
            //        break;
            //    case ClassList.DrawingObjects.TEXTWIZARD:
            //        btShapeDefaultSizeX = 82;
            //        break;
            //    case ClassList.DrawingObjects.TIME:
            //        btShapeDefaultSizeX = 10;
            //        break;
            //    case ClassList.DrawingObjects.TOGGLE:
            //        btShapeDefaultSizeX = 65;
            //        break;
            //    case ClassList.DrawingObjects.TREND:
            //        btShapeDefaultSizeX = 185;
            //        break;
            //    case ClassList.DrawingObjects.WORDBUTTON:
            //        btShapeDefaultSizeX = 140;
            //        break;
            //    case ClassList.DrawingObjects.WORDLAMP:
            //        if (IsProductCompatibleWith4030(CommonConstants.ProductDataInfo.iProductID) == true)
            //            btShapeDefaultSizeX = 46;
            //        else
            //            btShapeDefaultSizeX = 130;
            //        break;
            //    case ClassList.DrawingObjects.ANALOGMETER:
            //        if (IsProductCompatibleWith4030(CommonConstants.ProductDataInfo.iProductID) == true)
            //        {
            //            #region //MeterImprvRemoveExtraSapce_SY
            //            if (IsProductSupports16GrayScale(CommonConstants.ProductDataInfo.iProductID) == true ||
            //            IsProductSupports2Color(CommonConstants.ProductDataInfo.iProductID) == true)
            //            {
            //                btShapeDefaultSizeX = 80;//80 
            //            }
            //            else
            //                btShapeDefaultSizeX = 85;//80 
            //        }
            //        else
            //            btShapeDefaultSizeX = 125;//122 
            //            #endregion
            //        break;
            //    //if (IsProductCompatibleWith4030(CommonConstants.ProductDataInfo.iProductID) == true)
            //    //    btShapeDefaultSizeX = 80;
            //    //else
            //    //    btShapeDefaultSizeX = 122;

            //    //break;
            //    case ClassList.DrawingObjects.WRITEVALUETOTAG:
            //        btShapeDefaultSizeX = 155;
            //        break;
            //    case ClassList.DrawingObjects.ADDVALUETOTAG:
            //        btShapeDefaultSizeX = 155;
            //        break;
            //    case ClassList.DrawingObjects.SUBTRACTVALUEFROMTAG:
            //        btShapeDefaultSizeX = 165;
            //        break;
            //    case ClassList.DrawingObjects.ADDTAGS:
            //        btShapeDefaultSizeX = 160;
            //        break;
            //    case ClassList.DrawingObjects.SUBTRACTTAGS:
            //        btShapeDefaultSizeX = 170;
            //        break;
            //    case ClassList.DrawingObjects.PRINT:
            //        btShapeDefaultSizeX = 71;
            //        break;
            //    case ClassList.DrawingObjects.KEYPAD:
            //        btShapeDefaultSizeX = 150;
            //        break;
            //    case ClassList.DrawingObjects.ASCIIKEYPAD:
            //        btShapeDefaultSizeX = 255;
            //        break;
            //    case ClassList.DrawingObjects.ACKNOWLEDGE_ALARM:
            //        btShapeDefaultSizeX = 90;
            //        break;
            //    case ClassList.DrawingObjects.ACKNOWLEDGE_ALL_ALARMS:
            //        btShapeDefaultSizeX = 110;
            //        break;
            //    case ClassList.DrawingObjects.NEXT_ALARM:
            //        btShapeDefaultSizeX = 90;
            //        break;
            //    case ClassList.DrawingObjects.PREV_ALARM:
            //        btShapeDefaultSizeX = 120;
            //        break;
            //    case ClassList.DrawingObjects.COPY_PLCBLOCKTOPRIZMBLOCK:
            //        btShapeDefaultSizeX = 125;
            //        break;
            //    case ClassList.DrawingObjects.COPY_PRIZMBLOCKTOPLCBLOCK:
            //        btShapeDefaultSizeX = 130;
            //        break;
            //    case ClassList.DrawingObjects.CUSTOMKEYPAD:
            //    case ClassList.DrawingObjects.KEYPADWITHTAG:
            //        btShapeDefaultSizeX = 150;
            //        break;
            //    case ClassList.DrawingObjects.XYTREND://XYPlot
            //        btShapeDefaultSizeX = 200;
            //        break;
            //    #region SPMeter_KV
            //    case ClassList.DrawingObjects.SPEEDOMETER:
            //        btShapeDefaultSizeX = 450;
            //        break;
            //    #endregion
            //    default:
            //        btShapeDefaultSizeX = 10;
            //        break;
            //}
            return btShapeDefaultSizeX;
        }
        //Added by Samir 8th May 2007
        /// <summary>
        /// This Function Returns Selected Shape Default Height
        /// </summary>
        /// <param name="pShapeID">Shape ID</param>
        /// <returns>Returns byte(Default Height)</returns>
        public static byte GetShapeDefaultHeightSize(byte pShapeID)
        {
            byte btShapeDefaultSizeY = 10;

            //switch ((ClassList.DrawingObjects)pShapeID)
            //{

            //    case ClassList.DrawingObjects.ALARM:
            //        //FP_CODE  R12  Haresh
            //        if (CommonConstants.IsProductIsTextBased(CommonConstants.ProductDataInfo.iProductID) == true)
            //            btShapeDefaultSizeY = 16;
            //        else if (CommonConstants.IsProductIsTextAndGraphicsBased(CommonConstants.ProductDataInfo.iProductID) == true)
            //            btShapeDefaultSizeY = 28;
            //        else
            //            btShapeDefaultSizeY = 100;
            //        break;
            //    case ClassList.DrawingObjects.ARC:
            //        btShapeDefaultSizeY = 10;
            //        break;
            //    case ClassList.DrawingObjects.BITBUTTON:
            //        btShapeDefaultSizeY = 40;
            //        break;
            //    case ClassList.DrawingObjects.BITLAMP:
            //        if (IsProductCompatibleWith4030(CommonConstants.ProductDataInfo.iProductID) == true)
            //            btShapeDefaultSizeY = 16;
            //        else
            //            btShapeDefaultSizeY = 40;
            //        break;
            //    case ClassList.DrawingObjects.BITMAP:
            //        if (IsProductCompatibleWith4030(CommonConstants.ProductDataInfo.iProductID) == true)
            //            btShapeDefaultSizeY = 20;
            //        else
            //            btShapeDefaultSizeY = 100;
            //        break;
            //    case ClassList.DrawingObjects.ADVANCEDPICTURE:
            //        btShapeDefaultSizeY = 100;
            //        break;
            //    case ClassList.DrawingObjects.DATAENTRYCOIL:
            //        btShapeDefaultSizeY = 10;
            //        break;
            //    case ClassList.DrawingObjects.DATAENTRYREGISTER:
            //        btShapeDefaultSizeY = 10;
            //        break;
            //    case ClassList.DrawingObjects.DATE:
            //        btShapeDefaultSizeY = 10;
            //        break;
            //    case ClassList.DrawingObjects.DISPLAYDATACOIL:
            //        btShapeDefaultSizeY = 17;
            //        break;
            //    case ClassList.DrawingObjects.DISPLAYDATAREGISTER:
            //        btShapeDefaultSizeY = 13;
            //        break;
            //    case ClassList.DrawingObjects.DISPLAYDATAREGISTERTEXT:
            //        btShapeDefaultSizeY = 17;
            //        break;
            //    case ClassList.DrawingObjects.ELLIPSE:
            //        if (IsProductCompatibleWith4030(CommonConstants.ProductDataInfo.iProductID) == true)
            //            btShapeDefaultSizeY = 20;
            //        else
            //            btShapeDefaultSizeY = 40;
            //        break;
            //    case ClassList.DrawingObjects.GOTO:
            //        btShapeDefaultSizeY = 40;
            //        break;
            //    case ClassList.DrawingObjects.GROUP:
            //        btShapeDefaultSizeY = 10;
            //        break;
            //    case ClassList.DrawingObjects.HISTORICALTRENDS:
            //        btShapeDefaultSizeY = 125;
            //        break;
            //    case ClassList.DrawingObjects.HOLDOFF:
            //        btShapeDefaultSizeY = 10;
            //        break;
            //    case ClassList.DrawingObjects.HOLDON:
            //        btShapeDefaultSizeY = 10;
            //        break;
            //    case ClassList.DrawingObjects.LINE:
            //        btShapeDefaultSizeY = 20;
            //        break;
            //    case ClassList.DrawingObjects.MULTIPLEBARGRAPH:
            //        if (IsProductCompatibleWith4030(CommonConstants.ProductDataInfo.iProductID) == true)
            //            btShapeDefaultSizeY = 55;
            //        else
            //            btShapeDefaultSizeY = 115;
            //        break;
            //    case ClassList.DrawingObjects.NEXT:
            //        btShapeDefaultSizeY = 40;
            //        break;
            //    case ClassList.DrawingObjects.NUMERICKEYPAD:
            //        btShapeDefaultSizeY = 130;
            //        break;
            //    case ClassList.DrawingObjects.PIE:
            //        btShapeDefaultSizeY = 10;
            //        break;
            //    case ClassList.DrawingObjects.POLYGON:
            //        btShapeDefaultSizeY = 10;
            //        break;
            //    case ClassList.DrawingObjects.POLYLINE:
            //        btShapeDefaultSizeY = 10;
            //        break;
            //    case ClassList.DrawingObjects.GOTOPOPUPSCREEN:
            //        btShapeDefaultSizeY = 40;
            //        break;
            //    case ClassList.DrawingObjects.PREV:
            //        btShapeDefaultSizeY = 40;
            //        break;
            //    case ClassList.DrawingObjects.RECTANGLE:
            //        if (IsProductCompatibleWith4030(CommonConstants.ProductDataInfo.iProductID) == true)
            //            btShapeDefaultSizeY = 20;
            //        else
            //            btShapeDefaultSizeY = 40;
            //        break;
            //    case ClassList.DrawingObjects.RESET:
            //        btShapeDefaultSizeY = 40;
            //        break;
            //    //ShitalG_PER466
            //    case ClassList.DrawingObjects.MOMENTARY:
            //        btShapeDefaultSizeY = 40;
            //        break;
            //    //
            //    case ClassList.DrawingObjects.ROUNDRECT:
            //        if (IsProductCompatibleWith4030(CommonConstants.ProductDataInfo.iProductID) == true)
            //            btShapeDefaultSizeY = 30;
            //        else
            //            btShapeDefaultSizeY = 40;
            //        break;
            //    case ClassList.DrawingObjects.SET:
            //        btShapeDefaultSizeY = 40;
            //        break;
            //    case ClassList.DrawingObjects.SINGLEBARGRAPH:
            //        {
            //            if (IsProductIsTextBased(CommonConstants.ProductDataInfo.iProductID) == true)
            //            {
            //                btShapeDefaultSizeY = 16;
            //            }
            //            else if (IsProductIsTextAndGraphicsBased(CommonConstants.ProductDataInfo.iProductID) == true)
            //            {
            //                btShapeDefaultSizeY = 40;
            //            }
            //            else
            //            {
            //                btShapeDefaultSizeY = 100;
            //            }
            //            break;
            //        }
            //    case ClassList.DrawingObjects.TEXTOBJECT:
            //        //FP_CODE  R12  Haresh
            //        if (CommonConstants.IsProductIsTextBased(CommonConstants.ProductDataInfo.iProductID) == true)
            //            //btShapeDefaultSizeY = 14;
            //            btShapeDefaultSizeY = 16;
            //        else
            //            // btShapeDefaultSizeY = 17;
            //            btShapeDefaultSizeY = 8;


            //        break;
            //    case ClassList.DrawingObjects.TEXTWIZARD:
            //        btShapeDefaultSizeY = 17;
            //        break;
            //    case ClassList.DrawingObjects.TIME:
            //        btShapeDefaultSizeY = 10;
            //        break;
            //    case ClassList.DrawingObjects.TOGGLE:
            //        btShapeDefaultSizeY = 40;
            //        break;
            //    case ClassList.DrawingObjects.TREND:
            //        btShapeDefaultSizeY = 122;
            //        break;
            //    case ClassList.DrawingObjects.WORDBUTTON:
            //        btShapeDefaultSizeY = 40;
            //        break;
            //    case ClassList.DrawingObjects.WORDLAMP:
            //        if (IsProductCompatibleWith4030(CommonConstants.ProductDataInfo.iProductID) == true)
            //            btShapeDefaultSizeY = 16;
            //        else
            //            btShapeDefaultSizeY = 40;
            //        break;
            //    case ClassList.DrawingObjects.ANALOGMETER:
            //        //if (IsProductCompatibleWith4030(CommonConstants.ProductDataInfo.iProductID) == true)
            //        //{
            //        //    //Changes AMIT M-05 11-05-2010
            //        //    //As vertical gap was increased in order to that Default Height was also increased
            //        //    //btShapeDefaultSizeY = 45;
            //        //    btShapeDefaultSizeY = 50;
            //        //    //End
            //        //}
            //        //else
            //        //    btShapeDefaultSizeY = 81;//Kapil_Issue_integration_#MeterImprovement
            //        //break;
            //        #region MeterImprvRemoveExtraSapce_SY
            //        if (IsProductCompatibleWith4030(CommonConstants.ProductDataInfo.iProductID) == true)
            //        {
            //            //Changes AMIT M-05 11-05-2010
            //            //As vertical gap was increased in order to that Default Height was also increased                        
            //            if (IsProductSupports16GrayScale(CommonConstants.ProductDataInfo.iProductID) == true ||
            //             IsProductSupports2Color(CommonConstants.ProductDataInfo.iProductID) == true)
            //            {
            //                btShapeDefaultSizeY = 45;//45
            //            }
            //            else
            //                btShapeDefaultSizeY = 35;//45
            //            //End
            //        }
            //        else
            //        {
            //            //btShapeDefaultSizeY = 81;//Kapil_Issue_integration_#MeterImprovement
            //            //btShapeDefaultSizeY = 65;

            //            btShapeDefaultSizeY = 78;
            //        }
            //        break;
            //        #endregion

            //    case ClassList.DrawingObjects.WRITEVALUETOTAG:
            //        btShapeDefaultSizeY = 40;
            //        break;
            //    case ClassList.DrawingObjects.ADDVALUETOTAG:
            //        btShapeDefaultSizeY = 40;
            //        break;
            //    case ClassList.DrawingObjects.SUBTRACTVALUEFROMTAG:
            //        btShapeDefaultSizeY = 40;
            //        break;
            //    case ClassList.DrawingObjects.ADDTAGS:
            //        btShapeDefaultSizeY = 40;
            //        break;
            //    case ClassList.DrawingObjects.SUBTRACTTAGS:
            //        btShapeDefaultSizeY = 40;
            //        break;
            //    case ClassList.DrawingObjects.PRINT:
            //        btShapeDefaultSizeY = 40;
            //        break;
            //    case ClassList.DrawingObjects.KEYPAD:
            //        btShapeDefaultSizeY = 130;
            //        break;
            //    case ClassList.DrawingObjects.ASCIIKEYPAD:
            //        btShapeDefaultSizeY = 196;
            //        break;
            //    case ClassList.DrawingObjects.ACKNOWLEDGE_ALARM:
            //        btShapeDefaultSizeY = 40;
            //        break;
            //    case ClassList.DrawingObjects.ACKNOWLEDGE_ALL_ALARMS:
            //        btShapeDefaultSizeY = 40;
            //        break;
            //    case ClassList.DrawingObjects.NEXT_ALARM:
            //        btShapeDefaultSizeY = 40;
            //        break;
            //    case ClassList.DrawingObjects.PREV_ALARM:
            //        btShapeDefaultSizeY = 40;
            //        break;
            //    case ClassList.DrawingObjects.COPY_PLCBLOCKTOPRIZMBLOCK:
            //        btShapeDefaultSizeY = 40;
            //        break;
            //    case ClassList.DrawingObjects.COPY_PRIZMBLOCKTOPLCBLOCK:
            //        btShapeDefaultSizeY = 40;
            //        break;
            //    case ClassList.DrawingObjects.CUSTOMKEYPAD:
            //    case ClassList.DrawingObjects.KEYPADWITHTAG:
            //        btShapeDefaultSizeY = 130;
            //        break;
            //    #region SPMeter_KV
            //    case ClassList.DrawingObjects.SPEEDOMETER:
            //        btShapeDefaultSizeY = 200;
            //        break;
            //    #endregion
            //    default:
            //        btShapeDefaultSizeY = 10;
            //        break;
            //    case ClassList.DrawingObjects.XYTREND://XYPlot
            //        btShapeDefaultSizeY = 125;
            //        break;
            //}
            return btShapeDefaultSizeY;
        }

        //EmailKD
        public static bool IsEmailScreen1(int pScreenNumber)
        {
            //if (pScreenNumber >= ClassList.CommonConstants.START_EMAIL_SCREEN && pScreenNumber <= ClassList.CommonConstants.END_EMAIL_SCREENS)
            //    return true;
            //else
            return false;
        }

        //WebServer change
        #region WebServer Change
        public static bool IsWebScreen(int pScreenNumber)
        {
            if (pScreenNumber >= ClassList.CommonConstants.START_WEB_SCREEN && pScreenNumber <= ClassList.CommonConstants.END_WEB_SCREENS)
                return true;
            else
                return false;
        }
        public static bool IsProductSupportsWebScreens(int pProductID)
        {
            bool bFlag = false;
            switch (pProductID)
            {
                //case PRODUCT_FL055: //FL055_Product_Addition_Suyash //As per Dicusion with UP and Rishi Remove For This Product_20.07.2016
                case PRODUCT_FL100:
                case PRODUCT_FL100_S0://SS_FL100S0
                case PRODUCT_FP5043TN_E:
                case PRODUCT_FP5043TN:
                case PRODUCT_FP5070TN:
                case PRODUCT_FP5070TN_E:
                case PRODUCT_FP5121TN:
                case PRODUCT_FP5121TN_S0://Haresh_5121TN-SO
                #region WebServer Change Vijay
                case PRODUCT_OIS45_Plus:
                case PRODUCT_OIS45E_Plus:
                case PRODUCT_OIS70_Plus:
                case PRODUCT_OIS70E_Plus:
                case PRODUCT_OIS120A:
                case PRODUCT_GPU230_3S:
                #endregion
                #region WebServer change for TRPGMS01 SP
                case PRODUCT_TRPMIU0400E:
                case PRODUCT_TRPMIU0700E:
                #endregion
                case PRODUCT_HMC7043A_M:
                case PRODUCT_HMC7070A_M:
                #region PLC_Direct Vijay
                case PRODUCT_CPU_300:
                #endregion
                #region
                case PRODUCT_FP3043TN://New FP3043TN product Addition Suyash
                case PRODUCT_FP3070TN://New FP3070TN product Addition Suyash
                case PRODUCT_FP3102TN://New FP3102TN product Addition Suyash
                case PRODUCT_FP3043TN_E: //FP3043_ExpansionSeries Vijay
                #endregion
                #region SY-FP3_PlugableIO_Product_addition
                case PRODUCT_FP3070TN_E:
                case PRODUCT_FP3102TN_E:
                #endregion
                #region OIS3Series_Vijay
                case PRODUCT_OIS43E_Plus:
                case PRODUCT_OIS72E_Plus:
                case PRODUCT_OIS100E_Plus:
                #endregion
                #region Panasonic sammed 2.0
                case PRODUCT_GTXL07N:
                case PRODUCT_GTXL10N:
                #endregion
                #region Hitachi Hi-Rel Vijay
                case PRODUCT_HH5P_H43_S:
                case PRODUCT_HH5P_H70_S:
                case PRODUCT_HH5P_H100_S:
                case PRODUCT_HH1L_000:
                #endregion
                    //case PRODUCT_FL050_V2: //24.10.2016_Vijay
                    bFlag = true;
                    break;
                default:
                    bFlag = false;
                    break;
            }
            return bFlag;
        }
        #endregion
        //End

        public static bool IsProductSupportsEmail(int pProductID)
        {
            bool bFlag = false;
            return bFlag;
            switch (pProductID)
            {
                //case PRODUCT_FL055: //FL055_Product_Addition_Suyash //As per Dicusion with UP and Rishi Remove For This Product_20.07.2016
                case PRODUCT_FL100:
                case PRODUCT_FL100_S0://SS_FL100S0
                case PRODUCT_FP5043TN_E:
                case PRODUCT_FP5043TN:
                case PRODUCT_FP5070TN:
                case PRODUCT_FP5070TN_E:
                case PRODUCT_FP5121TN:
                case PRODUCT_FP5121TN_S0://Haresh_5121TN-SO
                #region WebServer Change Vijay
                case PRODUCT_OIS45_Plus:
                case PRODUCT_OIS45E_Plus:
                case PRODUCT_OIS70_Plus:
                case PRODUCT_OIS70E_Plus:
                case PRODUCT_OIS120A:
                case PRODUCT_GPU230_3S:
                #endregion
                #region WebServer change for TRPGMS01 SP
                case PRODUCT_TRPMIU0400E:
                case PRODUCT_TRPMIU0700E:
                #endregion
                case PRODUCT_HMC7043A_M:
                case PRODUCT_HMC7070A_M:
                #region PLC_Direct Vijay
                case PRODUCT_CPU_300:
                #endregion
                #region
                case PRODUCT_FP3043TN://New FP3043TN product Addition Suyash
                case PRODUCT_FP3070TN://New FP3070TN product Addition Suyash
                case PRODUCT_FP3102TN://New FP3102TN product Addition Suyash
                case PRODUCT_FP3043TN_E: //FP3043_ExpansionSeries Vijay
                #endregion
                #region SY-FP3_PlugableIO_Product_addition
                case PRODUCT_FP3070TN_E:
                case PRODUCT_FP3102TN_E:
                #endregion
                #region OIS3Series_Vijay
                case PRODUCT_OIS43E_Plus:
                case PRODUCT_OIS72E_Plus:
                case PRODUCT_OIS100E_Plus:
                #endregion
                #region Panasonic sammed 2.0
                case PRODUCT_GTXL07N:
                case PRODUCT_GTXL10N:
                #endregion
                #region Hitachi Hi-Rel Vijay
                case PRODUCT_HH5P_H43_S:
                case PRODUCT_HH5P_H70_S:
                case PRODUCT_HH5P_H100_S:
                case PRODUCT_HH1L_000:
                #endregion
                    //case PRODUCT_FL050_V2: //24.10.2016_Vijay
                    bFlag = true;
                    break;
                default:
                    bFlag = false;
                    break;
            }
            return bFlag;
        }

        /// <summary>
        /// The method checks for fixed grid size.
        /// 501 = for model 10.
        /// 505 = for model 50.
        /// 881 to 888 = for model HIO50.
        /// </summary>
        /// <param name="piModelNo">Model No</param>
        /// <returns>True or False</returns>
        public static bool IsFixedGridSizeProduct(int piModelNo)
        {
            if (piModelNo == 505 || piModelNo == 881 || piModelNo == 882 || piModelNo == 883 || piModelNo == 884 || piModelNo == 885 || piModelNo == 886 || piModelNo == 887 || piModelNo == 888 || piModelNo == 501 || piModelNo == 502 || piModelNo == 503 || piModelNo == 504 || piModelNo == 821)
                return true;
            //FP_CODE  R12  Haresh
            else if (IsProductIsTextBased(piModelNo))
                return true;
            //End
            return false;
        }


        #region Ladder Public Methods
        //FlexiPanel_Change_R1        
        public static bool IsProductFlexiPanels(int ProdutID)
        {
            bool retValue = false;

            if ((ProdutID >= 1100) &&
                //  (ProdutID <= 2000))
                 (ProdutID <= 2040))//GWY00_Change 
            {
                retValue = true;
            }
            #region GSM_Sanjay
            else if (ProdutID == 2001)
            {
                retValue = true;
            }
            #endregion GSM_Sanjay
            //GWY-901 SP PRODUCT_GSM901
            else if (ProdutID == 2002)
            {
                retValue = true;
            }
            //End
            #region GWY_910_Suyash
            else if (ProdutID == 2003)
            {
                retValue = true;
            }
            #endregion
            return retValue;
        }
        public static bool IsProductHMIOnly(int ProdutID)
        {
            #region FP_GSM_Sanjay
            bool retValue = false;
            #region New FP3035 Product Series
            if (IsProductSupportedFP3035(ProdutID))
            {
                retValue = true;
            }
            else
                retValue = false;
            #endregion
            return retValue;
            #endregion
        }

        public static bool IsProductSupportsKeypadOnly(int ProdutID)
        {
            bool retValue = false;
            switch (ProdutID)
            {
                case CommonConstants.PRODUCT_FP2020_L0808RP_A0401L: //2020_Series_Vijay
                case CommonConstants.PRODUCT_FP2020_L0808P_A0401L:
                case CommonConstants.PRODUCT_FP2020_L0604P_A0401L:
                case CommonConstants.PRODUCT_FP3020MR_L1608RP://Suyash_FP3020MR_L1608RP_Prod_Addition
                case CommonConstants.PRODUCT_FP4020MR:
                case CommonConstants.PRODUCT_FP4030MR:
                case CommonConstants.PRODUCT_PZ4030M_E:
                case CommonConstants.PRODUCT_PZ4030MN_E:

                case CommonConstants.PRODUCT_FP4020MR_L0808P:
                case CommonConstants.PRODUCT_FP4020M_L0808P_A:
                case CommonConstants.PRODUCT_FP4020M_L0808P_A0400R:
                case CommonConstants.PRODUCT_FP4020MR_L0808N:
                case CommonConstants.PRODUCT_FP4020M_L0808N_A:
                case CommonConstants.PRODUCT_FP4020M_L0808N_AR:
                case CommonConstants.PRODUCT_FP4020MR_L0808R:
                #region New_Product_Addition Vijay
                case CommonConstants.PRODUCT_FP4020MR_L0808R_S3:
                #endregion
                case CommonConstants.PRODUCT_FP4020M_L0808R_A:
                //case CommonConstants.PRODUCT_FP4020MR_L0808R_A0400://New_Product_Addition M&R AMIT
                //case CommonConstants.PRODUCT_FP4030M_L1208R_A0400:
                case CommonConstants.PRODUCT_FP4030MR_E:
                case CommonConstants.PRODUCT_FP4030MR_L1208R:
                case CommonConstants.PRODUCT_FP4030MR_0808R_A0400_S0://PRODUCT_FP4030MR_0808R_A0400_S0_addition_sammed
                case CommonConstants.PRODUCT_FP4030MR_L1210RP_A0402U: //PRODUCT_FP4030MR_L1210RP_A0402U Vijay
                case CommonConstants.PRODUCT_FP4030MR_L1210P_A0402U:  //PRODUCT_FP4030MR_L1210P_A0402U Vijay
                case CommonConstants.PRODUCT_FP4030MR_L1210RP://PRODUCT_FP4030MR_L1210RP Suyash
                case CommonConstants.PRODUCT_FP4030MR_L1210P://PRODUCT_FP4030MR_L1210P Suyash
                case CommonConstants.PRODUCT_FP4030MR_L0808R_A0400U: //PRODUCT_FP4030MR_L0808R_A0400U Vijay
                //case CommonConstants.PRODUCT_FP4030MN_E://New_Product_Addition M&R AMIT

                case CommonConstants.PRODUCT_FH9020MR:
                case CommonConstants.PRODUCT_FH9020MR_L0808P:
                case CommonConstants.PRODUCT_FH9020MR_L0808N:
                case CommonConstants.PRODUCT_FH9020MR_L0808R:

                case CommonConstants.PRODUCT_FH9030MR:
                case CommonConstants.PRODUCT_FH9030MR_E:
                case CommonConstants.PRODUCT_FH9030MR_L1208R:

                case CommonConstants.PRODUCT_HMC7030A_M:
                case CommonConstants.PRODUCT_HMC7030A_L:
                case CommonConstants.PRODUCT_PRIZM_710_S0://SD_Product_Addition_Prizm710_so

                #region Toshiba US products SnehalM
                case CommonConstants.PRODUCT_OIS12:
                case CommonConstants.PRODUCT_OIS22_Plus:
                case CommonConstants.PRODUCT_OIS20_Plus:
                case CommonConstants.PRODUCT_OIS10_Plus:
                #endregion
                case CommonConstants.PRODUCT_FP5121TN_S0://Haresh_5121TN-SO
                #region Hitachi Hi-Rel Vijay
                case CommonConstants.PRODUCT_HH5P_HP200808D_P:
                case CommonConstants.PRODUCT_HH5P_HP301208D_R:
                #endregion
                    retValue = true;
                    break;
            }

            return retValue;

        }


        public static bool IsProductSupportsKeypadAndTouchscreen(int ProdutID)
        {
            bool retValue = false;
            switch (ProdutID)
            {
                case CommonConstants.PRODUCT_FP4035T:
                case CommonConstants.PRODUCT_PZ4035TN_E:
                case CommonConstants.PRODUCT_PZ4057M_E:
                case CommonConstants.PRODUCT_FP4057T:
                #region New_Product_Addition_Herizomat AMIT
                case CommonConstants.PRODUCT_FP4057T_S2:
                #endregion
                case CommonConstants.PRODUCT_PZ4057TN_E:
                case CommonConstants.PRODUCT_PZ4084TN_E:
                case CommonConstants.PRODUCT_PZ4121TN_E:

                case CommonConstants.PRODUCT_FP4035T_E:
                #region New_Ethernet_Products_AMIT
                case CommonConstants.PRODUCT_FP4035TN:
                case CommonConstants.PRODUCT_FP4035TN_E:
                case CommonConstants.PRODUCT_FP4057TN:
                case CommonConstants.PRODUCT_FP4057TN_E:
                #endregion
                //case CommonConstants.PRODUCT_FP4057M_E:
                case CommonConstants.PRODUCT_FP4057T_E:
                #region New_Product_Addition_AllBodySoltn AMIT
                case CommonConstants.PRODUCT_FP4057T_E_S1:
                #endregion
                #region New_Product_Addition_Vertical Vijay
                case CommonConstants.PRODUCT_FP4057T_E_VERTICAL:
                #endregion
                case CommonConstants.PRODUCT_FP5070T_E_S2://New FP5070T-E-S2 product Addition Suyash
                case CommonConstants.PRODUCT_TRPMIU0300L:
                case CommonConstants.PRODUCT_TRPMIU0300A:
                case CommonConstants.PRODUCT_TRPMIU0500L:
                case CommonConstants.PRODUCT_TRPMIU0500A:

                case CommonConstants.PRODUCT_FH9035T:
                case CommonConstants.PRODUCT_FH9035T_E:
                case CommonConstants.PRODUCT_FH9057T:
                case CommonConstants.PRODUCT_FH9057T_E:

                case CommonConstants.PRODUCT_HMC7035A_M:
                case CommonConstants.PRODUCT_HMC7057A_M:

                #region Toshiba US products SnehalM
                case CommonConstants.PRODUCT_OIS55_Plus:
                case CommonConstants.PRODUCT_OIS60_Plus:
                #endregion
                //New Ethernet Models - SnehaK
                case CommonConstants.PRODUCT_TRPMIU0300E:
                case CommonConstants.PRODUCT_TRPMIU0500E:
                    //End

                    retValue = true;
                    break;
            }

            return retValue;
        }

        public static bool IsProductSupportsTouchscreenOnly(int ProdutID)
        {
            bool retValue = false;
            switch (ProdutID)
            {

                case CommonConstants.PRODUCT_FP5043T:
                case CommonConstants.PRODUCT_FP5043TN:
                case CommonConstants.PRODUCT_FP5043T_E:
                case CommonConstants.PRODUCT_FP5043TN_E:
                case CommonConstants.PRODUCT_FP5070T:
                case CommonConstants.PRODUCT_FP5070TN:
                case CommonConstants.PRODUCT_FP5070T_E:
                case CommonConstants.PRODUCT_FP5070TN_E:
                case CommonConstants.PRODUCT_FP5121T:
                case CommonConstants.PRODUCT_FP5121TN:
                //case CommonConstants.PRODUCT_FPW4030M: //New FP4030MT Vertical Series Addition Vijay
                #region New_Product_Addition M&R AMIT
                case CommonConstants.PRODUCT_FP4030MT_S1_HORIZONTAL:
                case CommonConstants.PRODUCT_FP4030MT_S1_VERTICAL:
                case CommonConstants.PRODUCT_FP4030MT_HORIZONTAL://FP4030MT_addition_AMIT
                case CommonConstants.PRODUCT_FP4030MT_VERTICAL:
                #endregion
                case CommonConstants.PRODUCT_FP4030MT_L0808RN_A0201: // FP4030MT_L0808RN_A0201_addition_Vijay
                case CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201:  // FP4030MT_L0808RP_A0201_addition_Vijay
                case CommonConstants.PRODUCT_FP4030MT_REV1://New Product addition FP4030MT- Rev 1
                case CommonConstants.PRODUCT_FP4030MT_L0808RN: //New Product addition FP4030MT-L0808RN/RP Vijay
                case CommonConstants.PRODUCT_FP4030MT_L0808RP: //New Product addition FP4030MT-L0808RN/RP Vijay
                #region New FP4030MT Vertical Series Addition Vijay
                case CommonConstants.PRODUCT_FP4030MT_REV1_VERTICAL:
                case CommonConstants.PRODUCT_FP4030MT_L0808RN_A0201_VERTICAL:
                case CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201_VERTICAL:
                case CommonConstants.PRODUCT_FP4030MT_L0808RN_VERTICAL:
                case CommonConstants.PRODUCT_FP4030MT_L0808RP_VERTICAL:
                #endregion
                case CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201L://FP4030MT_L0808RP_A0201L_addition_sammed
                case CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201L_VERTICAL://FP4030MT_L0808RP_A0201L(Vertical)_addition_sammed
                case CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201_S0: //New Product Addition FP4030MT-L0808RP-A0201-S0 Vijay
                #region New Product Addtion FP4030MT_L0808P/FP4030MT_L0808P_A0201U Vijay
                case CommonConstants.PRODUCT_FP4030MT_L0808P:
                case CommonConstants.PRODUCT_FP4030MT_L0808P_A0201U:
                #endregion
                case CommonConstants.PRODUCT_FP4030MT_L0808P_A0402L://Suyash_Product_Addition_FP4030MT_L0808P_A0402L
                //Toshiba_US New product Addition
                case CommonConstants.PRODUCT_OIS40_Plus_HORIZONTAL:
                case CommonConstants.PRODUCT_OIS40_Plus_VERTICAL:
                case CommonConstants.PRODUCT_OIS42_Plus: //New_Product_Addition Vijay(01.03.2013)
                case CommonConstants.PRODUCT_OIS42L_Plus: //New_Product_Addition Vijay(12.09.2013)
                case CommonConstants.PRODUCT_OIS45_Plus:
                case CommonConstants.PRODUCT_OIS45E_Plus:
                case CommonConstants.PRODUCT_OIS70_Plus:
                case CommonConstants.PRODUCT_OIS70E_Plus:
                case CommonConstants.PRODUCT_OIS120A:
                //Toshiba-Japan_Product
                case CommonConstants.PRODUCT_TRPMIU0400E:
                case CommonConstants.PRODUCT_TRPMIU0700E:
                //End
                #region //Mapple Customization 2.0_Sanjay_13
                case CommonConstants.PRODUCT_HMC7043A_M:
                case CommonConstants.PRODUCT_HMC7070A_M:
                #endregion
                #region New FP3035 Product Series
                //New FP3035 Product Series 3035T-24/3035T-5 SP
                case CommonConstants.PRODUCT_FP3035T_24:
                case CommonConstants.PRODUCT_FP3035T_5:
                //New_Product_Addition_OIS24/OIS_25 Vijay
                case CommonConstants.PRODUCT_OIS24:
                case CommonConstants.PRODUCT_OIS25:
                //End
                #endregion

                #region New FP3series product Addition Suyash
                case CommonConstants.PRODUCT_FP3043T://New FP3043T product Addition Suyash
                case CommonConstants.PRODUCT_FP3043TN://New FP3043TN product Addition Suyash
                case CommonConstants.PRODUCT_FP3070T://New FP3070T product Addition Suyash
                case CommonConstants.PRODUCT_FP3070TN://New FP3070TN product Addition Suyash
                case CommonConstants.PRODUCT_FP3102T://New FP3102T product Addition Suyash
                case CommonConstants.PRODUCT_FP3102TN://New FP3102TN product Addition Suyash
                #region Hitachi Hi-Rel Vijay
                case CommonConstants.PRODUCT_HH5P_H43_NS:
                case CommonConstants.PRODUCT_HH5P_H43_S:
                case CommonConstants.PRODUCT_HH5P_H70_NS:
                case CommonConstants.PRODUCT_HH5P_H70_S:
                case CommonConstants.PRODUCT_HH5P_H100_NS:
                case CommonConstants.PRODUCT_HH5P_H100_S:
                case CommonConstants.PRODUCT_HH5P_HP300201U0808_RP:
                case CommonConstants.PRODUCT_HH5P_HP300201L0808_RP:
                case CommonConstants.PRODUCT_HH5P_HP43_NS:
                case CommonConstants.PRODUCT_HH5P_HP70_NS:
                #endregion
                #region SY-FP3_PlugableIO_Product_addition
                case CommonConstants.PRODUCT_FP3070T_E:
                case CommonConstants.PRODUCT_FP3070TN_E:
                case CommonConstants.PRODUCT_FP3102T_E:
                case CommonConstants.PRODUCT_FP3102TN_E:
                #endregion
                #region FP3043_ExpansionSeries Vijay
                case CommonConstants.PRODUCT_FP3043T_E:
                case CommonConstants.PRODUCT_FP3043TN_E:
                #endregion
                #endregion
                #region Panasonic sammed 2.0
                case CommonConstants.PRODUCT_GTXL07N:
                case CommonConstants.PRODUCT_GTXL10N:
                #endregion
                    retValue = true;
                    break;
            }

            return retValue;
        }

        public static bool IsProductSupportsFunctionKeys(int ProdutID)
        {
            if (IsProductSupportsKeypadOnly(ProdutID))
                return true;
            else if (IsProductSupportsKeypadAndTouchscreen(ProdutID))
                return true;

            return false;
        }


        public static bool IsProductIsTextBased(int ProdutID)
        {
            bool retValue = false;
            switch (ProdutID)
            {
                case CommonConstants.PRODUCT_FP2020_L0808RP_A0401L: //2020_Series_Vijay
                case CommonConstants.PRODUCT_FP2020_L0808P_A0401L:
                case CommonConstants.PRODUCT_FP2020_L0604P_A0401L:
                case CommonConstants.PRODUCT_FP3020MR_L1608RP://Suyash_FP3020MR_L1608RP_Prod_Addition
                case CommonConstants.PRODUCT_FP4020MR:

                case CommonConstants.PRODUCT_FP4020MR_L0808P:
                case CommonConstants.PRODUCT_FP4020M_L0808P_A:
                case CommonConstants.PRODUCT_FP4020M_L0808P_A0400R:
                case CommonConstants.PRODUCT_FP4020MR_L0808N:
                case CommonConstants.PRODUCT_FP4020M_L0808N_A:
                case CommonConstants.PRODUCT_FP4020M_L0808N_AR:
                case CommonConstants.PRODUCT_FP4020MR_L0808R:
                #region New_Product_Addition Vijay
                case CommonConstants.PRODUCT_FP4020MR_L0808R_S3:
                #endregion
                case CommonConstants.PRODUCT_FP4020M_L0808R_A:
                //case CommonConstants.PRODUCT_FP4020MR_L0808R_A0400://New_Product_Addition M&R AMIT

                case CommonConstants.PRODUCT_FH9020MR:
                case CommonConstants.PRODUCT_FH9020MR_L0808N:
                case CommonConstants.PRODUCT_FH9020MR_L0808P:
                case CommonConstants.PRODUCT_FH9020MR_L0808R:
                case CommonConstants.PRODUCT_HH5P_HP200808D_P: //Hitachi Hi-Rel Vijay
                #region Toshiba US products SnehalM
                case CommonConstants.PRODUCT_OIS12:
                case CommonConstants.PRODUCT_OIS10_Plus:
                #endregion

                    retValue = true;
                    break;
            }



            return retValue;

            return false;

        }
        public static bool IsProductIsTextAndGraphicsBased(int ProdutID)
        {
            bool retValue = false;
            switch (ProdutID)
            {

                case CommonConstants.PRODUCT_FP4030MR:
                case CommonConstants.PRODUCT_PZ4030M_E:
                case CommonConstants.PRODUCT_PZ4030MN_E:

                //case CommonConstants.PRODUCT_FP4030M_L1208R_A0400:
                case CommonConstants.PRODUCT_FP4030MR_E:
                case CommonConstants.PRODUCT_FP4030MR_L1208R:
                case CommonConstants.PRODUCT_FP4030MR_0808R_A0400_S0://PRODUCT_FP4030MR_0808R_A0400_S0_addition_sammed
                case CommonConstants.PRODUCT_FP4030MR_L1210RP_A0402U: //PRODUCT_FP4030MR_L1210RP_A0402U Vijay
                case CommonConstants.PRODUCT_FP4030MR_L1210P_A0402U:  //PRODUCT_FP4030MR_L1210P_A0402U Vijay
                case CommonConstants.PRODUCT_FP4030MR_L1210RP://PRODUCT_FP4030MR_L1210RP Suyash
                case CommonConstants.PRODUCT_FP4030MR_L1210P://PRODUCT_FP4030MR_L1210P Suyash
                case CommonConstants.PRODUCT_FP4030MR_L0808R_A0400U: //PRODUCT_FP4030MR_L0808R_A0400U Vijay
                //case CommonConstants.PRODUCT_FP4030MN_E://New_Product_Addition M&R AMIT

                case CommonConstants.PRODUCT_FH9030MR:
                case CommonConstants.PRODUCT_FH9030MR_E:
                case CommonConstants.PRODUCT_FH9030MR_L1208R:

                case CommonConstants.PRODUCT_HMC7030A_M:
                case CommonConstants.PRODUCT_HMC7030A_L:

                #region Toshiba US products SnehalM
                case CommonConstants.PRODUCT_OIS22_Plus:
                case CommonConstants.PRODUCT_OIS20_Plus:
                #endregion

                //case CommonConstants.PRODUCT_FPW4030M: //New FP4030MT Vertical Series Addition Vijay
                #region New_Product_Addition M&R AMIT
                case CommonConstants.PRODUCT_FP4030MT_S1_HORIZONTAL:
                case CommonConstants.PRODUCT_FP4030MT_S1_VERTICAL:
                case CommonConstants.PRODUCT_FP4030MT_HORIZONTAL://FP4030MT_addition_AMIT
                case CommonConstants.PRODUCT_FP4030MT_VERTICAL:
                #endregion
                case CommonConstants.PRODUCT_FP4030MT_L0808RN_A0201: //FP4030MT_L0808RN_A0201_addition_Vijay
                case CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201: //FP4030MT_L0808RP_A0201_addition_Vijay
                case CommonConstants.PRODUCT_FP4030MT_REV1://New Product addition FP4030MT- Rev 1
                case CommonConstants.PRODUCT_FP4030MT_L0808RN: //New Product addition FP4030MT-L0808RN/RP Vijay
                case CommonConstants.PRODUCT_FP4030MT_L0808RP: //New Product addition FP4030MT-L0808RN/RP Vijay
                #region New FP4030MT Vertical Series Addition Vijay
                case CommonConstants.PRODUCT_FP4030MT_REV1_VERTICAL:
                case CommonConstants.PRODUCT_FP4030MT_L0808RN_A0201_VERTICAL:
                case CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201_VERTICAL:
                case CommonConstants.PRODUCT_FP4030MT_L0808RN_VERTICAL:
                case CommonConstants.PRODUCT_FP4030MT_L0808RP_VERTICAL:
                #endregion
                case CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201L://FP4030MT_L0808RP_A0201L_addition_sammed
                case CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201L_VERTICAL://FP4030MT_L0808RP_A0201L(Vertical)_addition_sammed
                case CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201_S0: //New Product Addition FP4030MT-L0808RP-A0201-S0 Vijay
                #region New Product Addtion FP4030MT_L0808P/FP4030MT_L0808P_A0201U Vijay
                case CommonConstants.PRODUCT_FP4030MT_L0808P:
                case CommonConstants.PRODUCT_FP4030MT_L0808P_A0201U:
                #endregion
                case CommonConstants.PRODUCT_FP4030MT_L0808P_A0402L://Suyash_Product_Addition_FP4030MT_L0808P_A0402L
                //Toshiba_US New product Addition
                case CommonConstants.PRODUCT_OIS40_Plus_HORIZONTAL:
                case CommonConstants.PRODUCT_OIS40_Plus_VERTICAL:
                case CommonConstants.PRODUCT_OIS42_Plus: //New_Product_Addition Vijay(01.03.2013)
                case CommonConstants.PRODUCT_OIS42L_Plus: //New_Product_Addition Vijay(12.09.2013)
                #region Hitachi Hi-Rel Vijay
                case CommonConstants.PRODUCT_HH5P_HP301208D_R:
                case CommonConstants.PRODUCT_HH5P_HP300201U0808_RP:
                case CommonConstants.PRODUCT_HH5P_HP300201L0808_RP:
                #endregion
                    retValue = true;
                    break;
            }



            return retValue;



        }
        public static bool IsProductSupports16GrayScale(int ProdutID)
        {
            bool retValue = false;
            switch (ProdutID)
            {

                case CommonConstants.PRODUCT_PZ4057M_E:
                    //case CommonConstants.PRODUCT_FP4057M_E:
                    retValue = true;
                    break;
            }



            return retValue;
        }

        public static bool IsProductSupportsColor(int ProdutID)
        {
            bool retValue = false;

            switch (ProdutID)
            {
                case CommonConstants.PRODUCT_FP4035T:
                case CommonConstants.PRODUCT_PZ4035TN_E:

                case CommonConstants.PRODUCT_FP4035T_E:
                #region New_Ethernet_Products_AMIT
                case CommonConstants.PRODUCT_FP4035TN:
                case CommonConstants.PRODUCT_FP4035TN_E:
                case CommonConstants.PRODUCT_FP4057TN:
                case CommonConstants.PRODUCT_FP4057TN_E:
                #endregion

                case CommonConstants.PRODUCT_FP4057T:
                #region New_Product_Addition_Herizomat AMIT
                case CommonConstants.PRODUCT_FP4057T_S2:
                #endregion
                case CommonConstants.PRODUCT_FP4057T_E:
                #region New_Product_Addition_AllBodySoltn AMIT
                case CommonConstants.PRODUCT_FP4057T_E_S1:
                #endregion
                #region New_Product_Addition_Vertical Vijay
                case CommonConstants.PRODUCT_FP4057T_E_VERTICAL:
                #endregion
                case CommonConstants.PRODUCT_TRPMIU0300L:
                case CommonConstants.PRODUCT_TRPMIU0300A:
                case CommonConstants.PRODUCT_TRPMIU0500L:
                case CommonConstants.PRODUCT_TRPMIU0500A:

                case CommonConstants.PRODUCT_FH9035T:
                case CommonConstants.PRODUCT_FH9035T_E:
                case CommonConstants.PRODUCT_FH9057T:
                case CommonConstants.PRODUCT_FH9057T_E:
                #region New FP Models-43&70 SnehalM
                case CommonConstants.PRODUCT_FP5043T:
                case CommonConstants.PRODUCT_FP5043TN:
                case CommonConstants.PRODUCT_FP5043T_E:
                case CommonConstants.PRODUCT_FP5043TN_E:
                case CommonConstants.PRODUCT_FP5070T:
                case CommonConstants.PRODUCT_FP5070TN:
                case CommonConstants.PRODUCT_FP5070T_E:
                case CommonConstants.PRODUCT_FP5070TN_E:
                case CommonConstants.PRODUCT_FP5121T:
                case CommonConstants.PRODUCT_FP5121TN:
                case CommonConstants.PRODUCT_FP5121TN_S0://Haresh_5121TN-SO
                #endregion
                case CommonConstants.PRODUCT_FP5070T_E_S2://New FP5070T-E-S2 product Addition Suyash
                //WebServer change
                #region WebServer change
                case CommonConstants.PRODUCT_FL100:
                case CommonConstants.PRODUCT_FL100_S0://SS_FL100S0
                case CommonConstants.PRODUCT_GPU230_3S: //WebServer Change Vijay
                #endregion
                //End

                #region Toshiba US products SnehalM
                case CommonConstants.PRODUCT_OIS55_Plus:
                case CommonConstants.PRODUCT_OIS60_Plus:
                //Toshiba_US New product Addition
                case CommonConstants.PRODUCT_OIS45_Plus:
                case CommonConstants.PRODUCT_OIS45E_Plus:
                case CommonConstants.PRODUCT_OIS70_Plus:
                case CommonConstants.PRODUCT_OIS70E_Plus:
                case CommonConstants.PRODUCT_OIS120A:
                #endregion
                case CommonConstants.PRODUCT_HMC7035A_M:
                case CommonConstants.PRODUCT_HMC7057A_M:
                #region //Mapple Customization 2.0_Sanjay
                case CommonConstants.PRODUCT_HMC7043A_M:
                case CommonConstants.PRODUCT_HMC7070A_M:
                #endregion

                //New Ethernet Models - SnehaK
                case CommonConstants.PRODUCT_TRPMIU0300E:
                case CommonConstants.PRODUCT_TRPMIU0500E:
                //End
                //Toshiba-Japan_Product
                case CommonConstants.PRODUCT_TRPMIU0400E:
                case CommonConstants.PRODUCT_TRPMIU0700E:
                //End
                #region New FP3035 Product Series
                //New FP3035 Product Series 3035T-24/3035T-5 SP
                case CommonConstants.PRODUCT_FP3035T_24:
                case CommonConstants.PRODUCT_FP3035T_5:
                //New_Product_Addition_OIS24/OIS_25 Vijay
                case CommonConstants.PRODUCT_OIS24:
                case CommonConstants.PRODUCT_OIS25:
                //End
                //End
                #endregion
                #region PLC_Direct Vijay
                case CommonConstants.PRODUCT_CPU_300:
                #endregion

                case CommonConstants.PRODUCT_PRIZM_710_S0://SD_Product_Addition_Prizm710_so

                #region New FP3series product Addition Suyash
                case CommonConstants.PRODUCT_FP3043T://New FP3043T product Addition Suyash
                case CommonConstants.PRODUCT_FP3043TN://New FP3043TN product Addition Suyash
                case CommonConstants.PRODUCT_FP3070T://New FP3070T product Addition Suyash
                case CommonConstants.PRODUCT_FP3070TN://New FP3070TN product Addition Suyash
                case CommonConstants.PRODUCT_FP3102T://New FP3102T product Addition Suyash
                case CommonConstants.PRODUCT_FP3102TN://New FP3102TN product Addition Suyash
                #region SY-FP3_PlugableIO_Product_addition
                case CommonConstants.PRODUCT_FP3070T_E:
                case CommonConstants.PRODUCT_FP3070TN_E:
                case CommonConstants.PRODUCT_FP3102T_E:
                case CommonConstants.PRODUCT_FP3102TN_E:
                #endregion
                #region FP3043_ExpansionSeries Vijay
                case CommonConstants.PRODUCT_FP3043T_E:
                case CommonConstants.PRODUCT_FP3043TN_E:
                #endregion
                #region Hitachi Hi-Rel Vijay
                case CommonConstants.PRODUCT_HH5P_H43_NS:
                case CommonConstants.PRODUCT_HH5P_H43_S:
                case CommonConstants.PRODUCT_HH5P_H70_NS:
                case CommonConstants.PRODUCT_HH5P_H70_S:
                case CommonConstants.PRODUCT_HH5P_H100_NS:
                case CommonConstants.PRODUCT_HH5P_H100_S:
                case CommonConstants.PRODUCT_HH1L_000:
                case CommonConstants.PRODUCT_HH5P_HP43_NS:
                case CommonConstants.PRODUCT_HH5P_HP70_NS:
                #endregion
                #endregion
                #region OIS3Series_Vijay
                case CommonConstants.PRODUCT_OIS43E_Plus:
                case CommonConstants.PRODUCT_OIS72E_Plus:
                case CommonConstants.PRODUCT_OIS100E_Plus:
                #endregion
                #region Panasonic sammed 2.0
                case CommonConstants.PRODUCT_GTXL07N:
                case CommonConstants.PRODUCT_GTXL10N:
                #endregion
                case CommonConstants.PRODUCT_FL050_V2: //Vijay_22.12.2015
                case CommonConstants.PRODUCT_FL055://FL055_Product_Addition_Suyash
                    retValue = true;
                    break;
            }



            return retValue;
        }

        public static bool IsProductSupports2Color(int ProdutID)
        {
            bool retValue = false;
            switch (ProdutID)
            {

                case CommonConstants.PRODUCT_FP4030MR:
                case CommonConstants.PRODUCT_PZ4030M_E:
                case CommonConstants.PRODUCT_PZ4030MN_E:

                //case CommonConstants.PRODUCT_FP4030M_L1208R_A0400:
                case CommonConstants.PRODUCT_FP4030MR_E:
                //case CommonConstants.PRODUCT_FP4030MN_E://New_Product_Addition M&R AMIT
                case CommonConstants.PRODUCT_FP4030MR_L1208R:

                case CommonConstants.PRODUCT_FH9030MR:
                case CommonConstants.PRODUCT_FH9030MR_E:
                case CommonConstants.PRODUCT_FH9030MR_L1208R:
                case CommonConstants.PRODUCT_FP4030MR_0808R_A0400_S0://PRODUCT_FP4030MR_0808R_A0400_S0_addition_sammed
                case CommonConstants.PRODUCT_FP4030MR_L1210RP_A0402U: //PRODUCT_FP4030MR_L1210RP_A0402U Vijay
                case CommonConstants.PRODUCT_FP4030MR_L1210P_A0402U:  //PRODUCT_FP4030MR_L1210P_A0402U Vijay
                case CommonConstants.PRODUCT_FP4030MR_L1210RP://PRODUCT_FP4030MR_L1210RP Suyash
                case CommonConstants.PRODUCT_FP4030MR_L1210P://PRODUCT_FP4030MR_L1210P Suyash
                case CommonConstants.PRODUCT_FP4030MR_L0808R_A0400U: //PRODUCT_FP4030MR_L0808R_A0400U Vijay
                case CommonConstants.PRODUCT_HMC7030A_M:
                case CommonConstants.PRODUCT_HMC7030A_L:
                #region Toshiba US products SnehalM
                case CommonConstants.PRODUCT_OIS22_Plus:
                case CommonConstants.PRODUCT_OIS20_Plus:
                #endregion

                //case CommonConstants.PRODUCT_FPW4030M: //New FP4030MT Vertical Series Addition Vijay
                #region New_Product_Addition M&R AMIT
                case CommonConstants.PRODUCT_FP4030MT_S1_HORIZONTAL:
                case CommonConstants.PRODUCT_FP4030MT_S1_VERTICAL:
                case CommonConstants.PRODUCT_FP4030MT_HORIZONTAL://FP4030MT_addition_AMIT
                case CommonConstants.PRODUCT_FP4030MT_VERTICAL:
                #endregion
                case CommonConstants.PRODUCT_FP4030MT_L0808RN_A0201: //FP4030MT_L0808RN_A0201_addition_Vijay
                case CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201: //FP4030MT_L0808RP_A0201_addition_Vijay
                case CommonConstants.PRODUCT_FP4030MT_REV1://New Product addition FP4030MT- Rev 1
                case CommonConstants.PRODUCT_FP4030MT_L0808RN: //New Product addition FP4030MT-L0808RN/RP Vijay
                case CommonConstants.PRODUCT_FP4030MT_L0808RP: //New Product addition FP4030MT-L0808RN/RP Vijay
                #region New FP4030MT Vertical Series Addition Vijay
                case CommonConstants.PRODUCT_FP4030MT_REV1_VERTICAL:
                case CommonConstants.PRODUCT_FP4030MT_L0808RN_A0201_VERTICAL:
                case CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201_VERTICAL:
                case CommonConstants.PRODUCT_FP4030MT_L0808RN_VERTICAL:
                case CommonConstants.PRODUCT_FP4030MT_L0808RP_VERTICAL:
                #endregion
                case CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201L://FP4030MT_L0808RP_A0201L_addition_sammed
                case CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201L_VERTICAL://FP4030MT_L0808RP_A0201L(Vertical)_addition_sammed
                case CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201_S0: //New Product Addition FP4030MT-L0808RP-A0201-S0 Vijay
                #region New Product Addtion FP4030MT_L0808P/FP4030MT_L0808P_A0201U Vijay
                case CommonConstants.PRODUCT_FP4030MT_L0808P:
                case CommonConstants.PRODUCT_FP4030MT_L0808P_A0201U:
                #endregion
                case CommonConstants.PRODUCT_FP4030MT_L0808P_A0402L://Suyash_Product_Addition_FP4030MT_L0808P_A0402L
                //Toshiba_US New product Addition
                case CommonConstants.PRODUCT_OIS40_Plus_HORIZONTAL:
                case CommonConstants.PRODUCT_OIS40_Plus_VERTICAL:
                case CommonConstants.PRODUCT_OIS42_Plus: //New_Product_Addition Vijay(01.03.2013)
                case CommonConstants.PRODUCT_OIS42L_Plus: //New_Product_Addition Vijay(12.09.2013)
                #region Hitachi Hi-Rel Vijay
                case CommonConstants.PRODUCT_HH5P_HP301208D_R:
                case CommonConstants.PRODUCT_HH5P_HP300201U0808_RP:
                case CommonConstants.PRODUCT_HH5P_HP300201L0808_RP:
                #endregion
                    retValue = true;
                    break;
            }


            return retValue;
        }

        //FP_CODE Pravin Disable RTC and USB host feature for 300L and 500L
        public static bool IsProductSupportsDataLogger(int ProdutID)
        {
            bool retValue = false;
            switch (ProdutID)
            {
                case CommonConstants.PRODUCT_FP4035T:
                case CommonConstants.PRODUCT_PZ4035TN_E:
                case CommonConstants.PRODUCT_PZ4057M_E:
                case CommonConstants.PRODUCT_FP4057T:
                #region New_Product_Addition_Herizomat AMIT
                case CommonConstants.PRODUCT_FP4057T_S2:
                #endregion
                case CommonConstants.PRODUCT_PZ4057TN_E:

                case CommonConstants.PRODUCT_PZ4084TN_E:
                case CommonConstants.PRODUCT_PZ4121TN_E:

                case CommonConstants.PRODUCT_FP4035T_E:
                #region New_Ethernet_Products_AMIT
                case CommonConstants.PRODUCT_FP4035TN:
                case CommonConstants.PRODUCT_FP4035TN_E:
                case CommonConstants.PRODUCT_FP4057TN:
                case CommonConstants.PRODUCT_FP4057TN_E:
                #endregion
                //case CommonConstants.PRODUCT_FP4057M_E:
                case CommonConstants.PRODUCT_FP4057T_E:
                #region New_Product_Addition_AllBodySoltn AMIT
                case CommonConstants.PRODUCT_FP4057T_E_S1:
                #endregion
                #region New_Product_Addition_Vertical Vijay
                case CommonConstants.PRODUCT_FP4057T_E_VERTICAL:
                #endregion
                //case CommonConstants.PRODUCT_FP4084TN_E: //New Product Addition FP4030MT-L0808RP-A0201-S0 Vijay


                //case CommonConstants.PRODUCT_TRPMIU0300L:
                case CommonConstants.PRODUCT_TRPMIU0300A:
                //case CommonConstants.PRODUCT_TRPMIU0500L:
                case CommonConstants.PRODUCT_TRPMIU0500A:

                case CommonConstants.PRODUCT_FH9035T:
                case CommonConstants.PRODUCT_FH9035T_E:
                case CommonConstants.PRODUCT_FH9057T:
                case CommonConstants.PRODUCT_FH9057T_E:
                #region New FP Models-43&70 SnehalM
                case CommonConstants.PRODUCT_FP5043T:
                case CommonConstants.PRODUCT_FP5043TN:
                case CommonConstants.PRODUCT_FP5043T_E:
                case CommonConstants.PRODUCT_FP5043TN_E:
                case CommonConstants.PRODUCT_FP5070T:
                case CommonConstants.PRODUCT_FP5070TN:
                case CommonConstants.PRODUCT_FP5070T_E:
                case CommonConstants.PRODUCT_FP5070TN_E:
                case CommonConstants.PRODUCT_FP5121T:
                case CommonConstants.PRODUCT_FP5121TN:
                case CommonConstants.PRODUCT_FP5121TN_S0://Haresh_5121TN-SO
                #endregion
                case CommonConstants.PRODUCT_FP5070T_E_S2://New FP5070T-E-S2 product Addition Suyash

                #region Toshiba US products SnehalM
                case CommonConstants.PRODUCT_OIS55_Plus:
                case CommonConstants.PRODUCT_OIS60_Plus:
                //Toshiba_US New product Addition
                case CommonConstants.PRODUCT_OIS45_Plus:
                case CommonConstants.PRODUCT_OIS45E_Plus:
                case CommonConstants.PRODUCT_OIS70_Plus:
                case CommonConstants.PRODUCT_OIS70E_Plus:
                case CommonConstants.PRODUCT_OIS120A:
                #endregion

                case CommonConstants.PRODUCT_HMC7035A_M:
                case CommonConstants.PRODUCT_HMC7057A_M:
                #region //Mapple Customization 2.0_Sanjay
                case CommonConstants.PRODUCT_HMC7043A_M:
                case CommonConstants.PRODUCT_HMC7070A_M:
                #endregion

                //New Ethernet Models - SnehaK
                case CommonConstants.PRODUCT_TRPMIU0300E:
                case CommonConstants.PRODUCT_TRPMIU0500E:
                //End
                //Toshiba-Japan_Product
                case CommonConstants.PRODUCT_TRPMIU0400E:
                case CommonConstants.PRODUCT_TRPMIU0700E:
                //End
                //sammed_FL100_datalogger
                #region New FL100 Model SAMMED
                case CommonConstants.PRODUCT_FL100:
                case CommonConstants.PRODUCT_GPU230_3S: //Vijay_08.01.14
                #endregion
                //End
                #region PLC_Direct Vijay
                case CommonConstants.PRODUCT_CPU_300:
                #endregion
                case CommonConstants.PRODUCT_PRIZM_710_S0://SD_Product_Addition_Prizm710_so

                #region New FP3series product Addition Suyash
                case CommonConstants.PRODUCT_FP3043T://New FP3043T product Addition Suyash
                case CommonConstants.PRODUCT_FP3043TN://New FP3043TN product Addition Suyash
                case CommonConstants.PRODUCT_FP3070T://New FP3070T product Addition Suyash
                case CommonConstants.PRODUCT_FP3070TN://New FP3070TN product Addition Suyash
                case CommonConstants.PRODUCT_FP3102T://New FP3102T product Addition Suyash
                case CommonConstants.PRODUCT_FP3102TN://New FP3102TN product Addition Suyash
                #region SY-FP3_PlugableIO_Product_addition
                case CommonConstants.PRODUCT_FP3070T_E:
                case CommonConstants.PRODUCT_FP3070TN_E:
                case CommonConstants.PRODUCT_FP3102T_E:
                case CommonConstants.PRODUCT_FP3102TN_E:
                #endregion
                #region FP3043_ExpansionSeries Vijay
                case CommonConstants.PRODUCT_FP3043T_E:
                case CommonConstants.PRODUCT_FP3043TN_E:
                #endregion
                #region Hitachi Hi-Rel Vijay
                case CommonConstants.PRODUCT_HH5P_H43_NS:
                case CommonConstants.PRODUCT_HH5P_H43_S:
                case CommonConstants.PRODUCT_HH5P_H70_NS:
                case CommonConstants.PRODUCT_HH5P_H70_S:
                case CommonConstants.PRODUCT_HH5P_H100_NS:
                case CommonConstants.PRODUCT_HH5P_H100_S:
                case CommonConstants.PRODUCT_HH1L_000:
                case CommonConstants.PRODUCT_HH5P_HP43_NS:
                case CommonConstants.PRODUCT_HH5P_HP70_NS:
                #endregion
                #endregion
                #region OIS3Series_Vijay
                case CommonConstants.PRODUCT_OIS43E_Plus:
                case CommonConstants.PRODUCT_OIS72E_Plus:
                case CommonConstants.PRODUCT_OIS100E_Plus:
                #endregion
                #region Panasonic sammed 2.0
                case CommonConstants.PRODUCT_GTXL07N:
                case CommonConstants.PRODUCT_GTXL10N:
                #endregion
                case CommonConstants.PRODUCT_FL055://FL055_Product_Addition_Suyash
                case CommonConstants.PRODUCT_FL050_V2: //24.10.2016_Vijay
                    retValue = true;
                    break;
            }



            return retValue;

        }
        //End

        #region Data_Logging_Modification Vijay
        public static bool IsProductSupportsDataLoggerExternal(int ProdutID)
        {
            bool retValue = false;
            switch (ProdutID)
            {
                //case CommonConstants.PRODUCT_FP3043T:
                case CommonConstants.PRODUCT_FP3043TN:
                case CommonConstants.PRODUCT_FP3043TN_E://SY-FP3_PlugableIO_Product_addition
                //case CommonConstants.PRODUCT_FP3070T:
                case CommonConstants.PRODUCT_FP3070TN:
                case CommonConstants.PRODUCT_FP3070TN_E://SY-FP3_PlugableIO_Product_addition
                //case CommonConstants.PRODUCT_FP3102T:
                case CommonConstants.PRODUCT_FP3102TN:
                case CommonConstants.PRODUCT_FP3102TN_E://SY-FP3_PlugableIO_Product_addition
                //case CommonConstants.PRODUCT_FP3043T_E:
                //case CommonConstants.PRODUCT_FP3043TN_E:
                case CommonConstants.PRODUCT_OIS43E_Plus:
                case CommonConstants.PRODUCT_OIS72E_Plus:
                case CommonConstants.PRODUCT_OIS100E_Plus:
                #region Hitachi Hi-Rel Vijay
                case CommonConstants.PRODUCT_HH5P_H43_S:
                case CommonConstants.PRODUCT_HH5P_H70_S:
                case CommonConstants.PRODUCT_HH5P_H100_S:
                #endregion
                //case CommonConstants.PRODUCT_FP5043T:
                //case CommonConstants.PRODUCT_FP5043TN:
                //case CommonConstants.PRODUCT_FP5043T_E:
                //case CommonConstants.PRODUCT_FP5043TN_E:
                //case CommonConstants.PRODUCT_FP5070T:
                //case CommonConstants.PRODUCT_FP5070TN:
                //case CommonConstants.PRODUCT_FP5070T_E:
                //case CommonConstants.PRODUCT_FP5070TN_E:
                //case CommonConstants.PRODUCT_FP5121T:
                //case CommonConstants.PRODUCT_FP5121TN:
                //case CommonConstants.PRODUCT_FP5121TN_S0:
                //case CommonConstants.PRODUCT_FP5070T_E_S2:
                //case CommonConstants.PRODUCT_OIS45_Plus:
                //case CommonConstants.PRODUCT_OIS45E_Plus:
                //case CommonConstants.PRODUCT_OIS70_Plus:
                //case CommonConstants.PRODUCT_OIS70E_Plus:
                //case CommonConstants.PRODUCT_OIS120A:
                //case CommonConstants.PRODUCT_TRPMIU0400E:
                //case CommonConstants.PRODUCT_TRPMIU0700E:
                //case CommonConstants.PRODUCT_HMC7043A_M:
                //case CommonConstants.PRODUCT_HMC7070A_M:

                //case CommonConstants.PRODUCT_GTXL07N:
                //case CommonConstants.PRODUCT_GTXL10N:

                case CommonConstants.PRODUCT_FL055:
                case CommonConstants.PRODUCT_FL050_V2: //24.10.2016_Vijay
                    retValue = true;
                    break;
            }
            return retValue;
        }

        public static bool IsProductSupportsOnlyUSB(int ProdutID)
        {
            bool retValue = false;
            switch (ProdutID)
            {
                case CommonConstants.PRODUCT_FP5043T:
                case CommonConstants.PRODUCT_FP5043TN:
                case CommonConstants.PRODUCT_FP5043T_E:
                case CommonConstants.PRODUCT_FP5043TN_E:
                case CommonConstants.PRODUCT_FP5070T:
                case CommonConstants.PRODUCT_FP5070TN:
                case CommonConstants.PRODUCT_FP5070T_E:
                case CommonConstants.PRODUCT_FP5070TN_E:
                case CommonConstants.PRODUCT_FP5121T:
                case CommonConstants.PRODUCT_FP5121TN:
                case CommonConstants.PRODUCT_FP5121TN_S0:
                case CommonConstants.PRODUCT_FP5070T_E_S2:
                case CommonConstants.PRODUCT_OIS45_Plus:
                case CommonConstants.PRODUCT_OIS45E_Plus:
                case CommonConstants.PRODUCT_OIS70_Plus:
                case CommonConstants.PRODUCT_OIS70E_Plus:
                case CommonConstants.PRODUCT_OIS120A:
                case CommonConstants.PRODUCT_TRPMIU0400E:
                case CommonConstants.PRODUCT_TRPMIU0700E:
                case CommonConstants.PRODUCT_HMC7043A_M:
                case CommonConstants.PRODUCT_HMC7070A_M:
                    #region SY-FP3_PlugableIO_Product_addition
                    //case CommonConstants.PRODUCT_FP3070T_E:
                    //case CommonConstants.PRODUCT_FP3070TN_E:
                    //case CommonConstants.PRODUCT_FP3102T_E:
                    //case CommonConstants.PRODUCT_FP3102TN_E:
                    #endregion
                    retValue = true;
                    break;
            }
            return retValue;
        }
        #endregion

        //FP_CODE Pravin Disable RTC and USB host feature for 300L and 500L
        public static bool IsProductWithoutRTC(int ProdutID)
        {
            bool retValue = false;
            switch (ProdutID)
            {
                case CommonConstants.PRODUCT_TRPMIU0300L:
                case CommonConstants.PRODUCT_TRPMIU0500L:
                case CommonConstants.PRODUCT_GSM900:
                case CommonConstants.PRODUCT_GSM901://GWY-901 SP
                case CommonConstants.PRODUCT_GSM910://GWY_910_Suyash
                    retValue = true;
                    break;
            }

            return retValue;
        }
        //End
        //USB_PORT_RESET
        public static bool IsProductUSBPortReset(int ProdutID)
        {
            bool retValue = true;

            if (IsProductSupportedFP4035(ProdutID) || IsProductSupportedFP4057(ProdutID) || IsProductGateway(ProdutID)
                || ProdutID == ClassList.CommonConstants.PRODUCT_FL010 ||
                ProdutID == ClassList.CommonConstants.PRODUCT_FL011_S1 ||
                ProdutID == ClassList.CommonConstants.PRODUCT_FL011_S4 || //New_ProductAdd_Vijay
                ProdutID == ClassList.CommonConstants.PRODUCT_FL011 ||
                ProdutID == ClassList.CommonConstants.PRODUCT_FL050 || ProdutID == ClassList.CommonConstants.PRODUCT_FL011_S3 ||
                ProdutID == ClassList.CommonConstants.PRODUCT_GPU288_3S ||
                ProdutID == ClassList.CommonConstants.PRODUCT_GPU200_3S ||
                ProdutID == ClassList.CommonConstants.PRODUCT_GPU232_3S)//SD_Toshiba_US_18Nov16
            {

                if (ProdutID == ClassList.CommonConstants.PRODUCT_GSM910)//Sammed_07-10-2015
                {
                }
                else
                    retValue = false;
            }
            return retValue;
        }
        //End
        //FP_CODE Pravin Disable RTC and USB host feature for 300L and 500L
        public static bool IsProductSupportsHisAlarm(int ProdutID)
        {
            bool retValue = true;

            if (IsProductPLC(ProdutID) || IsProductWithoutRTC(ProdutID))
                retValue = false;



            return retValue;

        }
        //End
        public static bool IsProductSupportsEthernet(int ProdutID)
        {
            bool retValue = false;
            switch (ProdutID)
            {

                case CommonConstants.PRODUCT_MICRO_PLC_ETHERNET:
                case CommonConstants.PRODUCT_FL050:
                case CommonConstants.PRODUCT_FL050_V2://New Product FL050 V2 SammedB
                #region ToshibaUS PLC Models
                case ClassList.CommonConstants.PRODUCT_GPU200_3S:
                case ClassList.CommonConstants.PRODUCT_GPU230_3S: //New_Product_Addition Vijay(01.03.2013)
                #endregion
                #region New FL100 Model SAMMED
                case CommonConstants.PRODUCT_FL100:
                case CommonConstants.PRODUCT_FL100_S0://SS_FL100S0
                #endregion
                //case CommonConstants.PRODUCT_FL051: //Remove_Product Vijay(06.02.14)
                case CommonConstants.PRODUCT_PLC7008A_ME:

                case CommonConstants.PRODUCT_FP5043TN:
                case CommonConstants.PRODUCT_FP5043TN_E:
                case CommonConstants.PRODUCT_FP5070TN:
                case CommonConstants.PRODUCT_FP5070TN_E:
                case CommonConstants.PRODUCT_FP5121TN:
                case CommonConstants.PRODUCT_FP5121TN_S0://Haresh_5121TN-SO
                #region New_Ethernet_Products_AMIT
                case CommonConstants.PRODUCT_FP4035TN:
                case CommonConstants.PRODUCT_FP4035TN_E:
                case CommonConstants.PRODUCT_FP4057TN:
                case CommonConstants.PRODUCT_FP4057TN_E:
                #endregion
                //New Ethernet Models - SnehaK
                case CommonConstants.PRODUCT_TRPMIU0300E:
                case CommonConstants.PRODUCT_TRPMIU0500E:
                case CommonConstants.PRODUCT_TRPMIU0400E:
                case CommonConstants.PRODUCT_TRPMIU0700E:
                //End
                //Toshiba_US New product Addition
                case CommonConstants.PRODUCT_OIS45_Plus:
                case CommonConstants.PRODUCT_OIS45E_Plus:
                case CommonConstants.PRODUCT_OIS70_Plus:
                case CommonConstants.PRODUCT_OIS70E_Plus:
                case CommonConstants.PRODUCT_OIS120A:
                //MapleChange_Ethernet_SY
                case CommonConstants.PRODUCT_HMC7043A_M:
                case CommonConstants.PRODUCT_HMC7070A_M:
                #region PLC_Direct Vijay
                case CommonConstants.PRODUCT_CPU_300:
                #endregion

                #region New FP3series product Addition Suyash
                case CommonConstants.PRODUCT_FP3043TN://New FP3043TN product Addition Suyash
                case CommonConstants.PRODUCT_FP3070TN://New FP3070TN product Addition Suyash
                case CommonConstants.PRODUCT_FP3102TN://New FP3102TN product Addition Suyash
                case CommonConstants.PRODUCT_FP3043TN_E: //FP3043_ExpansionSeries Vijay
                #endregion
                #region SY-FP3_PlugableIO_Product_addition
                case CommonConstants.PRODUCT_FP3070TN_E:
                case CommonConstants.PRODUCT_FP3102TN_E:
                #endregion
                #region OIS3Series_Vijay
                case CommonConstants.PRODUCT_OIS43E_Plus:
                case CommonConstants.PRODUCT_OIS72E_Plus:
                case CommonConstants.PRODUCT_OIS100E_Plus:
                #endregion
                #region Hitachi Hi-Rel Vijay
                case CommonConstants.PRODUCT_HH5P_H43_S:
                case CommonConstants.PRODUCT_HH5P_H70_S:
                case CommonConstants.PRODUCT_HH5P_H100_S:
                case CommonConstants.PRODUCT_HH1L_000:
                #endregion
                #region Panasonic sammed 2.0
                case CommonConstants.PRODUCT_GTXL07N:
                case CommonConstants.PRODUCT_GTXL10N:
                #endregion
                case CommonConstants.PRODUCT_FL055://FL055_Product_Addition_Suyash                
                    retValue = true;
                    break;
            }

            return retValue;

        }

        public static bool IsProduct_Compatible_FL50(int ProdutID)
        {

            if (ProdutID == CommonConstants.PRODUCT_FL050 ||
                ProdutID == CommonConstants.PRODUCT_GPU200_3S ||
                ProdutID == CommonConstants.PRODUCT_MICRO_PLC_ETHERNET)// ||
            //ProdutID == CommonConstants.PRODUCT_FL050_V2) //New Product FL050 V2 SammedB //24.10.2016_Vijay
            {
                return true;
            }
            return false;
        }
        public static bool IsCom2Supported(int ProductID)
        {
            DataRow[] drProductID = ClassList.CommonConstants.dsRecentProjectList.Tables["Unitinformation"].Select("ModelNo='" + ProductID + "' and COM2='True'");
            if (drProductID.Length > 0)
                return true;

            return false;
        }
        public static bool IsProductEv4(int ProdutID)
        {
            if (IsProductFlexiPanels(ProdutID))
                return true;
            else if (IsProductHMIOnly(ProdutID))
                return true;
            return false;
        }

        public static bool IsProductCompatibleWith4020(int ProdutID)
        {
            bool retValue = false;
            switch (ProdutID)
            {
                case CommonConstants.PRODUCT_FP2020_L0808RP_A0401L: //2020_Series_Vijay
                case CommonConstants.PRODUCT_FP2020_L0808P_A0401L:
                case CommonConstants.PRODUCT_FP2020_L0604P_A0401L:
                case CommonConstants.PRODUCT_FP3020MR_L1608RP://Suyash_FP3020MR_L1608RP_Prod_Addition
                case CommonConstants.PRODUCT_FP4020MR:

                case CommonConstants.PRODUCT_FP4020MR_L0808P:
                case CommonConstants.PRODUCT_FP4020M_L0808P_A:
                case CommonConstants.PRODUCT_FP4020M_L0808P_A0400R:
                case CommonConstants.PRODUCT_FP4020MR_L0808N:
                case CommonConstants.PRODUCT_FP4020M_L0808N_A:
                case CommonConstants.PRODUCT_FP4020M_L0808N_AR:
                case CommonConstants.PRODUCT_FP4020MR_L0808R:
                #region New_Product_Addition Vijay
                case CommonConstants.PRODUCT_FP4020MR_L0808R_S3:
                #endregion
                case CommonConstants.PRODUCT_FP4020M_L0808R_A:
                //case CommonConstants.PRODUCT_FP4020MR_L0808R_A0400://New_Product_Addition M&R AMIT

                case CommonConstants.PRODUCT_FH9020MR:
                case CommonConstants.PRODUCT_FH9020MR_L0808P:
                case CommonConstants.PRODUCT_FH9020MR_L0808N:
                case CommonConstants.PRODUCT_FH9020MR_L0808R:
                case CommonConstants.PRODUCT_HH5P_HP200808D_P: //Hitachi Hi-Rel Vijay
                #region Toshiba US products SnehalM
                case CommonConstants.PRODUCT_OIS12:
                case CommonConstants.PRODUCT_OIS10_Plus:
                #endregion
                    retValue = true;
                    break;
            }


            return retValue;
        }
        public static bool IsProductCompatibleWith4030(int ProdutID)
        {
            bool retValue = false;
            switch (ProdutID)
            {

                case CommonConstants.PRODUCT_FP4030MR:
                case CommonConstants.PRODUCT_PZ4030M_E:
                case CommonConstants.PRODUCT_PZ4030MN_E:

                //case CommonConstants.PRODUCT_FP4030M_L1208R_A0400:
                case CommonConstants.PRODUCT_FP4030MR_E:
                //case CommonConstants.PRODUCT_FP4030MN_E://New_Product_Addition M&R AMIT
                case CommonConstants.PRODUCT_FP4030MR_L1208R:
                case CommonConstants.PRODUCT_FP4030MR_0808R_A0400_S0://PRODUCT_FP4030MR_0808R_A0400_S0_addition_sammed
                case CommonConstants.PRODUCT_FP4030MR_L1210RP_A0402U: //PRODUCT_FP4030MR_L1210RP_A0402U Vijay
                case CommonConstants.PRODUCT_FP4030MR_L1210P_A0402U:  //PRODUCT_FP4030MR_L1210P_A0402U Vijay
                case CommonConstants.PRODUCT_FP4030MR_L1210RP://PRODUCT_FP4030MR_L1210RP Suyash
                case CommonConstants.PRODUCT_FP4030MR_L1210P://PRODUCT_FP4030MR_L1210P Suyash
                case CommonConstants.PRODUCT_FP4030MR_L0808R_A0400U: //PRODUCT_FP4030MR_L0808R_A0400U Vijay
                case CommonConstants.PRODUCT_FH9030MR:
                case CommonConstants.PRODUCT_FH9030MR_E:
                case CommonConstants.PRODUCT_FH9030MR_L1208R:

                case CommonConstants.PRODUCT_HMC7030A_M:
                case CommonConstants.PRODUCT_HMC7030A_L:
                #region Toshiba US products SnehalM
                case CommonConstants.PRODUCT_OIS22_Plus:
                case CommonConstants.PRODUCT_OIS20_Plus:
                #endregion

                //case CommonConstants.PRODUCT_FPW4030M: //New FP4030MT Vertical Series Addition Vijay
                #region New_Product_Addition M&R AMIT
                case CommonConstants.PRODUCT_FP4030MT_S1_HORIZONTAL:
                case CommonConstants.PRODUCT_FP4030MT_S1_VERTICAL:
                case CommonConstants.PRODUCT_FP4030MT_HORIZONTAL://FP4030MT_addition_AMIT
                case CommonConstants.PRODUCT_FP4030MT_VERTICAL:
                #endregion
                case CommonConstants.PRODUCT_FP4030MT_L0808RN_A0201: //FP4030MT_L0808RN_A0201_addition_Vijay
                case CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201: //FP4030MT_L0808RP_A0201_addition_Vijay
                case CommonConstants.PRODUCT_FP4030MT_REV1://New Product addition FP4030MT- Rev 1
                case CommonConstants.PRODUCT_FP4030MT_L0808RN: //New Product addition FP4030MT-L0808RN/RP Vijay
                case CommonConstants.PRODUCT_FP4030MT_L0808RP: //New Product addition FP4030MT-L0808RN/RP Vijay
                #region New FP4030MT Vertical Series Addition Vijay
                case CommonConstants.PRODUCT_FP4030MT_REV1_VERTICAL:
                case CommonConstants.PRODUCT_FP4030MT_L0808RN_A0201_VERTICAL:
                case CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201_VERTICAL:
                case CommonConstants.PRODUCT_FP4030MT_L0808RN_VERTICAL:
                case CommonConstants.PRODUCT_FP4030MT_L0808RP_VERTICAL:
                #endregion
                case CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201L://FP4030MT_L0808RP_A0201L_addition_sammed
                case CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201L_VERTICAL://FP4030MT_L0808RP_A0201L(Vertical)_addition_sammed
                case CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201_S0: //New Product Addition FP4030MT-L0808RP-A0201-S0 Vijay
                #region New Product Addtion FP4030MT_L0808P/FP4030MT_L0808P_A0201U Vijay
                case CommonConstants.PRODUCT_FP4030MT_L0808P:
                case CommonConstants.PRODUCT_FP4030MT_L0808P_A0201U:
                #endregion
                case CommonConstants.PRODUCT_FP4030MT_L0808P_A0402L://Suyash_Product_Addition_FP4030MT_L0808P_A0402L
                //Toshiba_US New product Addition
                case CommonConstants.PRODUCT_OIS40_Plus_HORIZONTAL:
                case CommonConstants.PRODUCT_OIS40_Plus_VERTICAL:
                case CommonConstants.PRODUCT_OIS42_Plus: //New_Product_Addition Vijay(01.03.2013)
                case CommonConstants.PRODUCT_OIS42L_Plus: //New_Product_Addition Vijay(12.09.2013)
                #region Hitachi Hi-Rel Vijay
                case CommonConstants.PRODUCT_HH5P_HP301208D_R:
                case CommonConstants.PRODUCT_HH5P_HP300201U0808_RP:
                case CommonConstants.PRODUCT_HH5P_HP300201L0808_RP:
                #endregion
                    retValue = true;
                    break;
            }


            return retValue;
        }

        #region ShitalG
        public static bool IsProductCompatibleWith4030MR(int ProdutID)
        {
            bool retValue = false;

            switch (ProdutID)
            {
                case CommonConstants.PRODUCT_FP4030MR:
                case CommonConstants.PRODUCT_FP4030MR_E:
                case CommonConstants.PRODUCT_FP4030MR_L1208R:
                case CommonConstants.PRODUCT_FP4030MR_0808R_A0400_S0://PRODUCT_FP4030MR_0808R_A0400_S0_addition_sammed
                case CommonConstants.PRODUCT_FP4030MR_L1210RP_A0402U: //PRODUCT_FP4030MR_L1210RP_A0402U Vijay
                case CommonConstants.PRODUCT_FP4030MR_L1210P_A0402U:  //PRODUCT_FP4030MR_L1210P_A0402U Vijay
                case CommonConstants.PRODUCT_FP4030MR_L1210RP://PRODUCT_FP4030MR_L1210RP Suyash
                case CommonConstants.PRODUCT_FP4030MR_L1210P://PRODUCT_FP4030MR_L1210P Suyash
                case CommonConstants.PRODUCT_FP4030MR_L0808R_A0400U: //PRODUCT_FP4030MR_L0808R_A0400U Vijay
                #region 06.04.15_Vijay
                case CommonConstants.PRODUCT_OIS20_Plus:
                case CommonConstants.PRODUCT_OIS22_Plus:
                case CommonConstants.PRODUCT_HMC7030A_L:
                case CommonConstants.PRODUCT_HMC7030A_M:
                #endregion
                case CommonConstants.PRODUCT_HH5P_HP301208D_R: //Hitachi Hi-Rel Vijay
                    retValue = true;
                    break;
            }
            return retValue;
        }
        #endregion

        public static bool IsProductCompatibleWith4030MT(int ProdutID)
        {
            bool retValue = false;

            switch (ProdutID)
            {
                case CommonConstants.PRODUCT_FP4030MT_S1_HORIZONTAL:
                case CommonConstants.PRODUCT_FP4030MT_S1_VERTICAL:
                case CommonConstants.PRODUCT_FP4030MT_HORIZONTAL://FP4030MT_addition_AMIT
                case CommonConstants.PRODUCT_FP4030MT_VERTICAL:
                case CommonConstants.PRODUCT_FP4030MT_L0808RN_A0201: //FP4030MT_L0808RN_A0201_addition_Vijay
                case CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201: //FP4030MT_L0808RP_A0201_addition_Vijay
                case CommonConstants.PRODUCT_FP4030MT_REV1://New Product addition FP4030MT- Rev 1
                case CommonConstants.PRODUCT_FP4030MT_L0808RN: //New Product addition FP4030MT-L0808RN/RP Vijay
                case CommonConstants.PRODUCT_FP4030MT_L0808RP: //New Product addition FP4030MT-L0808RN/RP Vijay
                #region New FP4030MT Vertical Series Addition Vijay
                case CommonConstants.PRODUCT_FP4030MT_REV1_VERTICAL:
                case CommonConstants.PRODUCT_FP4030MT_L0808RN_A0201_VERTICAL:
                case CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201_VERTICAL:
                case CommonConstants.PRODUCT_FP4030MT_L0808RN_VERTICAL:
                case CommonConstants.PRODUCT_FP4030MT_L0808RP_VERTICAL:
                #endregion
                case CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201L://FP4030MT_L0808RP_A0201L_addition_sammed
                case CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201L_VERTICAL://FP4030MT_L0808RP_A0201L(Vertical)_addition_sammed
                case CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201_S0: //New Product Addition FP4030MT-L0808RP-A0201-S0 Vijay
                #region New Product Addtion FP4030MT_L0808P/FP4030MT_L0808P_A0201U Vijay
                case CommonConstants.PRODUCT_FP4030MT_L0808P:
                case CommonConstants.PRODUCT_FP4030MT_L0808P_A0201U:
                #endregion
                case CommonConstants.PRODUCT_FP4030MT_L0808P_A0402L://Suyash_Product_Addition_FP4030MT_L0808P_A0402L
                //Toshiba_US New product Addition
                case CommonConstants.PRODUCT_OIS40_Plus_HORIZONTAL:
                case CommonConstants.PRODUCT_OIS40_Plus_VERTICAL:
                case CommonConstants.PRODUCT_OIS42_Plus: //New_Product_Addition Vijay(01.03.2013)
                case CommonConstants.PRODUCT_OIS42L_Plus: //New_Product_Addition Vijay(12.09.2013)
                #region Hitachi Hi-Rel Vijay
                case CommonConstants.PRODUCT_HH5P_HP300201U0808_RP:
                case CommonConstants.PRODUCT_HH5P_HP300201L0808_RP:
                #endregion
                    retValue = true;
                    break;
            }
            return retValue;
        }

        public static bool IsProductLPCBased(int ProdutID)
        {
            if (IsProductCompatibleWith4020(ProdutID) || IsProductCompatibleWith4030(ProdutID) || IsProductPLC(ProdutID) || ProdutID == CommonConstants.PRODUCT_GSM900
                || ProdutID == CommonConstants.PRODUCT_GSM901 || IsProductCompatibleWithFP3035(ProdutID)
                || IsProductGWY_K22(ProdutID))//GSM_Sanjay //GWY-901 SP //New FP3035 Product Series //GWY00_Change
                return true;
            return false;
        }

        public static bool IsProductCompatibleWith4084(int ProdutID)
        {
            bool retValue = false;
            switch (ProdutID)
            {


                case CommonConstants.PRODUCT_PZ4084TN_E:
                case CommonConstants.PRODUCT_PZ4121TN_E:
                    //case CommonConstants.PRODUCT_FP4084TN_E: //New Product Addition FP4030MT-L0808RP-A0201-S0 Vijay

                    retValue = true;
                    break;
            }

            return retValue;

        }
        public static bool IsProductSupportsLadder(int ProdutID)
        {
            //GWY00_Change
            if (IsProductGWY_K22(ProdutID))
                return false;
            //
            if ((ClassList.CommonConstants.IsProductPLC(ProdutID) || ClassList.CommonConstants.IsProductFlexiPanels(ProdutID))
                && !CommonConstants.IsProductSupportedFP3035(ProdutID) && !CommonConstants.IsProductFL100Special(ProdutID))//New FP3035 Product Series //SS_FL100S0
                return true;

            return false;
        }
        public static bool IsProductPLC(int ProdutID)
        {
            if (ProdutID == ClassList.CommonConstants.PRODUCT_MICRO_PLC ||
                ProdutID == ClassList.CommonConstants.PRODUCT_MICRO_PLC_ETHERNET ||
                ProdutID == ClassList.CommonConstants.PRODUCT_FL010 ||
                ProdutID == ClassList.CommonConstants.PRODUCT_FL011_S1 ||
                ProdutID == ClassList.CommonConstants.PRODUCT_FL011_S4 || //New_ProductAdd_Vijay
                ProdutID == ClassList.CommonConstants.PRODUCT_FL011 ||
                ProdutID == ClassList.CommonConstants.PRODUCT_FL050 ||
                 ProdutID == ClassList.CommonConstants.PRODUCT_FL050_V2 ||//New Product FL050 V2 SammedB
                 ProdutID == ClassList.CommonConstants.PRODUCT_FL055 ||//FL055_Product_Addition_Suyash
            #region New FL100 Model SAMMED
 ProdutID == ClassList.CommonConstants.PRODUCT_FL100 ||
            #endregion
 ProdutID == ClassList.CommonConstants.PRODUCT_FL100_S0 ||//SS_FL100S0
            #region FL005-MicroPLC Base Module Series Vijay
                //Remove_Product Vijay
                //ProdutID == ClassList.CommonConstants.PRODUCT_FL005_0604RP ||
                //ProdutID == ClassList.CommonConstants.PRODUCT_FL005_0604RP0201L ||
                //
                ProdutID == ClassList.CommonConstants.PRODUCT_FL005_0808RP ||
                ProdutID == ClassList.CommonConstants.PRODUCT_FL005_0808RP0201L ||
                //FL005-MicroPLC Base Module Series Vijay1
                ProdutID == ClassList.CommonConstants.PRODUCT_FL005_0604P ||
                ProdutID == ClassList.CommonConstants.PRODUCT_FL005_0808P ||
                ProdutID == ClassList.CommonConstants.PRODUCT_FL005_0808P0201L ||
                ProdutID == ClassList.CommonConstants.PRODUCT_FL005_0604N ||
                ProdutID == ClassList.CommonConstants.PRODUCT_FL005_0808N ||
                ProdutID == ClassList.CommonConstants.PRODUCT_FL005_0808N0201L ||
                ProdutID == ClassList.CommonConstants.PRODUCT_FL005_1616P0201L_S1 ||//New FL005 Product Addition Suyash
                //End
            #endregion
            #region FL005 Expandable PLC Series Vijay
                ProdutID == ClassList.CommonConstants.PRODUCT_FL005_0808RP0402U ||
                ProdutID == ClassList.CommonConstants.PRODUCT_FL005_1616RP0201L ||
                ProdutID == ClassList.CommonConstants.PRODUCT_FL005_1616P0201L ||
                ProdutID == ClassList.CommonConstants.PRODUCT_FL005_1616N0201L ||
                ProdutID == ClassList.CommonConstants.PRODUCT_FL005_1616RP ||
                ProdutID == ClassList.CommonConstants.PRODUCT_FL005_1616P ||
            #endregion
            #region PLC_Direct Vijay
 ProdutID == ClassList.CommonConstants.PRODUCT_CPU_300 ||
                ProdutID == ClassList.CommonConstants.PRODUCT_CPU_111_RP ||
                ProdutID == ClassList.CommonConstants.PRODUCT_CPU_120_ARP ||
                ProdutID == ClassList.CommonConstants.PRODUCT_CPU_100_P ||
                ProdutID == ClassList.CommonConstants.PRODUCT_CPU_110_P ||
                ProdutID == ClassList.CommonConstants.PRODUCT_CPU_120_AP ||
                ProdutID == ClassList.CommonConstants.PRODUCT_CPU_100_N ||
                ProdutID == ClassList.CommonConstants.PRODUCT_CPU_110_N ||
                ProdutID == ClassList.CommonConstants.PRODUCT_CPU_120_AN ||
            #endregion
            #region Hitachi Hi-Rel Vijay
 ProdutID == ClassList.CommonConstants.PRODUCT_HH5L_B0604D_P ||
                ProdutID == ClassList.CommonConstants.PRODUCT_HH5L_B0808D_P ||
                ProdutID == ClassList.CommonConstants.PRODUCT_HH5L_B1616D_P ||
                ProdutID == ClassList.CommonConstants.PRODUCT_HH5L_B1616D_RP ||
                ProdutID == ClassList.CommonConstants.PRODUCT_HH5L_B0201A0808D_P ||
                ProdutID == ClassList.CommonConstants.PRODUCT_HH5L_B0201A1616D_RP ||
                ProdutID == ClassList.CommonConstants.PRODUCT_HH5L_B0402AU0808D_RP ||
                ProdutID == ClassList.CommonConstants.PRODUCT_HH1L_000 ||
            #endregion
                //ProdutID == ClassList.CommonConstants.PRODUCT_FL051 || //Remove_Product Vijay(06.02.14)
                ProdutID == ClassList.CommonConstants.PRODUCT_PLC7008A_ML ||
                ProdutID == ClassList.CommonConstants.PRODUCT_PLC7008A_ME ||
                ProdutID == ClassList.CommonConstants.PRODUCT_FL011_S3 ||//New PLC Models AMIT
                ProdutID == ClassList.CommonConstants.PRODUCT_GPU288_3S ||
                ProdutID == ClassList.CommonConstants.PRODUCT_GPU200_3S ||
                ProdutID == ClassList.CommonConstants.PRODUCT_GPU232_3S || //ToshibaUS PLC Models
                ProdutID == ClassList.CommonConstants.PRODUCT_GPU230_3S || //New_Product_Addition Vijay(01.03.2013)
                ProdutID == ClassList.CommonConstants.PRODUCT_GPU110_3S ||  //New_Product_Addition Vijay(15.05.2014)
                ProdutID == ClassList.CommonConstants.PRODUCT_GPU105_3S ||//New_Product_Addition Parag(9.12.2014)
                ProdutID == ClassList.CommonConstants.PRODUCT_GPU120_3S || //New_Product_Addition Parag(9.12.2014)
                ProdutID == ClassList.CommonConstants.PRODUCT_GPU122_3S || //New_Product_Addition Vijay(07.04.2015)
            #region Maple_ProductAddition_Vijay
                ProdutID == ClassList.CommonConstants.PRODUCT_MLC1_F0604P ||
                ProdutID == ClassList.CommonConstants.PRODUCT_MLC1_F0604N ||
                ProdutID == ClassList.CommonConstants.PRODUCT_MLC1_F0808P ||
                ProdutID == ClassList.CommonConstants.PRODUCT_MLC1_F0808N ||
                ProdutID == ClassList.CommonConstants.PRODUCT_MLC1_F0808Y ||
                ProdutID == ClassList.CommonConstants.PRODUCT_MLC1_F0808P0201 ||
                ProdutID == ClassList.CommonConstants.PRODUCT_MLC1_F0808N0201 ||
                ProdutID == ClassList.CommonConstants.PRODUCT_MLC1_F0808Y0201 ||
                ProdutID == ClassList.CommonConstants.PRODUCT_MLC1_F1616P0201 ||
                ProdutID == ClassList.CommonConstants.PRODUCT_MLC1_E1616P ||
                ProdutID == ClassList.CommonConstants.PRODUCT_MLC1_E1616Y ||
                ProdutID == ClassList.CommonConstants.PRODUCT_MLC1_E0808Y0402T ||
                ProdutID == ClassList.CommonConstants.PRODUCT_MLC1_E1616P0201 ||
                ProdutID == ClassList.CommonConstants.PRODUCT_MLC1_E1616N0201 ||
                ProdutID == ClassList.CommonConstants.PRODUCT_MLC1_E1616Y0201 ||
                ProdutID == ClassList.CommonConstants.PRODUCT_MLC2_E0404P0802T ||
                ProdutID == ClassList.CommonConstants.PRODUCT_MLC3_E)
            #endregion
                return true;

            return false;
        }
        #region AccessLevel_ScreenProp_SY //AccessLevelSupport_FP3/5_Vijay
        public static bool IsAccessLvlsupported(int ProductID)
        {
            if (ProductID == ClassList.CommonConstants.PRODUCT_FP5121TN_S0 ||
                ClassList.CommonConstants.IsProductSupportedFP5043(ProductID) ||
                ClassList.CommonConstants.IsProductSupportedFP5070(ProductID) ||
                ClassList.CommonConstants.IsProductSupportedFP5121(ProductID) ||
                ClassList.CommonConstants.IsProductSupportedFP3series(ProductID))
                return true;

            return false;
        }
        #endregion
        public static bool IsProductGateway(int ProductId)
        {
            if (ProductId == ClassList.CommonConstants.PRODUCT_GSM900 ||
                ProductId == ClassList.CommonConstants.PRODUCT_GSM901 ||
                ProductId == ClassList.CommonConstants.PRODUCT_GSM910)//GWY_910_Suyash
                return true;

            return false;
        }
        //GWY00_Change
        public static bool IsProductGWY_K22(int ProdutID)
        {
            if (ProdutID == ClassList.CommonConstants.PRODUCT_GWY00)
                return true;

            return false;
        }

        #region New FP Models-43&70 SnehalM
        public static bool IsProductMX257_Based(int ProductID)
        {
            bool retValue = false;
            switch (ProductID)
            {
                case CommonConstants.PRODUCT_FP5043T:
                case CommonConstants.PRODUCT_FP5043TN:
                case CommonConstants.PRODUCT_FP5043T_E:
                case CommonConstants.PRODUCT_FP5043TN_E:
                case CommonConstants.PRODUCT_FP5070T:
                case CommonConstants.PRODUCT_FP5070TN:
                case CommonConstants.PRODUCT_FP5070T_E:
                case CommonConstants.PRODUCT_FP5070TN_E:
                case CommonConstants.PRODUCT_FP5121T:
                case CommonConstants.PRODUCT_FP5121TN:
                case CommonConstants.PRODUCT_FP5121TN_S0://Haresh_5121TN-SO
                case CommonConstants.PRODUCT_FP5070T_E_S2://New FP5070T-E-S2 product Addition Suyash
                //Toshiba_US New product Addition
                case CommonConstants.PRODUCT_OIS45_Plus:
                case CommonConstants.PRODUCT_OIS45E_Plus:
                case CommonConstants.PRODUCT_OIS70_Plus:
                case CommonConstants.PRODUCT_OIS70E_Plus:
                case CommonConstants.PRODUCT_OIS120A:
                //Toshiba-Japan_Product
                case CommonConstants.PRODUCT_TRPMIU0400E:
                case CommonConstants.PRODUCT_TRPMIU0700E:
                //End
                #region //Mapple Customization 2.0_Sanjay
                case CommonConstants.PRODUCT_HMC7043A_M:
                case CommonConstants.PRODUCT_HMC7070A_M:
                #endregion

                #region New FP3series product Addition Suyash
                case CommonConstants.PRODUCT_FP3043T://New FP3043T product Addition Suyash
                case CommonConstants.PRODUCT_FP3043TN://New FP3043TN product Addition Suyash
                case CommonConstants.PRODUCT_FP3070T://New FP3070T product Addition Suyash
                case CommonConstants.PRODUCT_FP3070TN://New FP3070TN product Addition Suyash
                case CommonConstants.PRODUCT_FP3102T://New FP3102T product Addition Suyash
                case CommonConstants.PRODUCT_FP3102TN://New FP3102TN product Addition Suyash
                #region SY-FP3_PlugableIO_Product_addition
                case CommonConstants.PRODUCT_FP3070T_E:
                case CommonConstants.PRODUCT_FP3070TN_E:
                case CommonConstants.PRODUCT_FP3102T_E:
                case CommonConstants.PRODUCT_FP3102TN_E:
                #endregion
                #region FP3043_ExpansionSeries Vijay
                case CommonConstants.PRODUCT_FP3043T_E:
                case CommonConstants.PRODUCT_FP3043TN_E:
                #endregion
                #region Hitachi Hi-Rel Vijay
                case CommonConstants.PRODUCT_HH5P_H43_NS:
                case CommonConstants.PRODUCT_HH5P_H43_S:
                case CommonConstants.PRODUCT_HH5P_H70_NS:
                case CommonConstants.PRODUCT_HH5P_H70_S:
                case CommonConstants.PRODUCT_HH5P_H100_NS:
                case CommonConstants.PRODUCT_HH5P_H100_S:
                case CommonConstants.PRODUCT_HH5P_HP43_NS:
                case CommonConstants.PRODUCT_HH5P_HP70_NS:
                #endregion
                #endregion
                #region OIS3Series_Vijay
                case CommonConstants.PRODUCT_OIS43E_Plus:
                case CommonConstants.PRODUCT_OIS72E_Plus:
                case CommonConstants.PRODUCT_OIS100E_Plus:
                #endregion
                #region Panasonic sammed 2.0
                case CommonConstants.PRODUCT_GTXL07N:
                case CommonConstants.PRODUCT_GTXL10N:
                #endregion
                case CommonConstants.PRODUCT_PRIZM_710_S0://SD_Product_Addition_Prizm710_so

                    retValue = true;
                    break;
            }
            return retValue;
        }



        #region New FL100 Model SAMMED
        /// <summary>
        /// Includes FL100-S0 model
        /// </summary>
        /// <param name="ProductID"></param>
        /// <returns></returns>
        public static bool IsProductMXSpecialCase_Based(int ProductID)
        {
            bool retValue = false;
            switch (ProductID)
            {
                case CommonConstants.PRODUCT_FL100:
                case CommonConstants.PRODUCT_FL100_S0://SS_FL100S0
                case CommonConstants.PRODUCT_HH1L_000: //Hitachi Hi-Rel Vijay
                case CommonConstants.PRODUCT_MLC3_E: //Maple_ProductAddition_Vijay
                    retValue = true;
                    break;
                //case CommonConstants.PRODUCT_FL005:
                //    retValue = true;
                //    break;
                #region New_Product_Addition Vijay(01.03.2013)
                case CommonConstants.PRODUCT_GPU230_3S:
                case CommonConstants.PRODUCT_CPU_300: //PLC_Direct Vijay
                    retValue = true;
                    break;
                #endregion
            }
            return retValue;
        }
        #endregion
        #region SS_FL100S0
        /// <summary>
        /// Excludes FL100-S0 model
        /// </summary>
        /// <param name="ProductID"></param>
        /// <returns></returns>
        public static bool IsProductMXSpecialCase_OldModel(int ProductID)
        {
            bool retValue = false;
            switch (ProductID)
            {
                case CommonConstants.PRODUCT_FL100:
                case CommonConstants.PRODUCT_HH1L_000: //Hitachi Hi-Rel Vijay
                    retValue = true;
                    break;
                #region New_Product_Addition Vijay(01.03.2013)
                case CommonConstants.PRODUCT_GPU230_3S:
                case CommonConstants.PRODUCT_CPU_300: //PLC_Direct Vijay
                    retValue = true;
                    break;
                #endregion
            }
            return retValue;
        }
        public static bool IsProductFL100Special(int ProductID)
        {
            bool retValue = false;
            switch (ProductID)
            {
                case CommonConstants.PRODUCT_FL100_S0:
                    retValue = true;
                    break;
            }
            return retValue;
        }
        #endregion

        //PID5 is supported for FL010 product 07-05-2014 - Pravin 
        public static bool IsProductCompatible_FL010(int ProductID)
        {
            bool retValue = false;
            switch (ProductID)
            {
                case CommonConstants.PRODUCT_FL010:
                case CommonConstants.PRODUCT_GPU288_3S:
                case CommonConstants.PRODUCT_PLC7008A_ML:
                case CommonConstants.PRODUCT_MICRO_PLC: //TRSPUX10A
                    retValue = true;
                    break;
            }
            return retValue;
        }
        //End

        // New Functions added on date 14th Oct 2010  SnehalM
        #region FP_CODE FHWT Screen Addition for 4043 and 4070   SnehalM
        public static bool IsProductCompatibleWith4043(int ProdutID)
        {
            bool retValue = false;
            switch (ProdutID)
            {
                case CommonConstants.PRODUCT_FP5043T:
                case CommonConstants.PRODUCT_FP5043TN:
                case CommonConstants.PRODUCT_FP5043T_E:
                #region FHWT_Vijay
                case CommonConstants.PRODUCT_FP5043TN_E:
                #endregion
                //Toshiba_US New product Addition
                case CommonConstants.PRODUCT_OIS45_Plus:
                #region //Mapple Customization 2.0_Sanjay_13
                case CommonConstants.PRODUCT_HMC7043A_M:
                case CommonConstants.PRODUCT_HMC7070A_M:
                #endregion
                case CommonConstants.PRODUCT_TRPMIU0400E:

                #region New FP3series product Addition Suyash
                case CommonConstants.PRODUCT_FP3043T://New FP3043T product Addition Suyash
                case CommonConstants.PRODUCT_FP3043TN://New FP3043TN product Addition Suyash
                case CommonConstants.PRODUCT_OIS43E_Plus: //OIS3Series_Vijay
                #region FP3043_ExpansionSeries Vijay
                case CommonConstants.PRODUCT_FP3043T_E:
                case CommonConstants.PRODUCT_FP3043TN_E:
                #endregion
                #region Hitachi Hi-Rel Vijay
                case CommonConstants.PRODUCT_HH5P_H43_NS:
                case CommonConstants.PRODUCT_HH5P_H43_S:
                case CommonConstants.PRODUCT_HH5P_HP43_NS:
                #endregion
                #endregion
                    retValue = true;
                    break;
            }
            return retValue;
        }

        public static bool IsProductCompatibleWith4070(int ProdutID)
        {
            bool retValue = false;
            switch (ProdutID)
            {
                case CommonConstants.PRODUCT_FP5070T:
                case CommonConstants.PRODUCT_FP5070TN:
                case CommonConstants.PRODUCT_FP5070T_E:
                case CommonConstants.PRODUCT_FP5070T_E_S2://New FP5070T-E-S2 product Addition Suyash
                #region FHWT_Vijay
                case CommonConstants.PRODUCT_FP5070TN_E:
                #endregion
                //Toshiba_US New product Addition
                case CommonConstants.PRODUCT_OIS70_Plus:
                case CommonConstants.PRODUCT_TRPMIU0700E:
                #region New FP3series product Addition Suyash
                case CommonConstants.PRODUCT_FP3070T://New FP3070T product Addition Suyash
                case CommonConstants.PRODUCT_FP3070TN://New FP3070TN product Addition Suyash
                case CommonConstants.PRODUCT_FP3102T://New FP3102T product Addition Suyash
                case CommonConstants.PRODUCT_FP3102TN://New FP3102TN product Addition Suyash
                #endregion
                #region SY-FP3_PlugableIO_Product_addition
                case CommonConstants.PRODUCT_FP3070T_E:
                case CommonConstants.PRODUCT_FP3070TN_E:
                case CommonConstants.PRODUCT_FP3102T_E:
                case CommonConstants.PRODUCT_FP3102TN_E:
                #endregion
                #region Hitachi Hi-Rel Vijay
                case CommonConstants.PRODUCT_HH5P_H70_NS:
                case CommonConstants.PRODUCT_HH5P_H70_S:
                case CommonConstants.PRODUCT_HH5P_H100_NS:
                case CommonConstants.PRODUCT_HH5P_H100_S:
                case CommonConstants.PRODUCT_HH5P_HP70_NS:
                #endregion
                #region OIS3Series_Vijay
                case CommonConstants.PRODUCT_OIS72E_Plus:
                case CommonConstants.PRODUCT_OIS100E_Plus:
                #endregion
                #region Panasonic sammed 2.0
                case CommonConstants.PRODUCT_GTXL07N:
                case CommonConstants.PRODUCT_GTXL10N:
                #endregion
                    retValue = true;
                    break;
            }
            return retValue;
        }

        public static bool IsProductCompatibleWith4121(int ProdutID)
        {
            bool retValue = false;
            switch (ProdutID)
            {
                case CommonConstants.PRODUCT_FP5121T:
                case CommonConstants.PRODUCT_FP5121TN:
                case CommonConstants.PRODUCT_FP5121TN_S0://Haresh_5121TN-SO
                //Toshiba_US New product Addition
                case CommonConstants.PRODUCT_OIS120A:
                    retValue = true;
                    break;
            }
            return retValue;
        }

        public static bool IsProductFreeScale(int ProdutID)
        {
            if (IsProductCompatibleWith4043(ProdutID) || IsProductCompatibleWith4070(ProdutID)
                || IsProductCompatibleWith4121(ProdutID))
                return true;

            return false;
        }
        //
        #endregion
        #endregion

        # region For toshiba   Snehalm
        public static bool IsProductLowerType(int ProdutID)
        {
            bool retValue = false;
            switch (ProdutID)
            {
                case CommonConstants.PRODUCT_TRPMIU0500L:
                case CommonConstants.PRODUCT_TRPMIU0300L:

                    retValue = true;
                    break;
            }
            return retValue;
        }

        public static bool IsProductAdvancedType(int ProdutID)
        {
            bool retValue = false;
            switch (ProdutID)
            {
                case CommonConstants.PRODUCT_TRPMIU0500A:
                case CommonConstants.PRODUCT_TRPMIU0300A:

                    retValue = true;
                    break;
            }
            return retValue;
        }

        #endregion For toshiba   Snehalm

        public static bool IsUSBHostSupported(int ProdutID)
        {
            bool retValue = false;
            switch (ProdutID)
            {
                #region New_Product_Addition Vijay
                case CommonConstants.PRODUCT_FP4020MR_L0808R_S3:
                #endregion
                case CommonConstants.PRODUCT_TRPMIU0300A:
                case CommonConstants.PRODUCT_TRPMIU0500A:
                case CommonConstants.PRODUCT_FP4035T:
                case CommonConstants.PRODUCT_FP4057T:
                #region New_Product_Addition_Herizomat AMIT
                case CommonConstants.PRODUCT_FP4057T_S2:
                #endregion
                case CommonConstants.PRODUCT_FP4035T_E:
                case CommonConstants.PRODUCT_FP4057T_E:
                #region New_Ethernet_Products_AMIT
                case CommonConstants.PRODUCT_FP4035TN:
                case CommonConstants.PRODUCT_FP4035TN_E:
                case CommonConstants.PRODUCT_FP4057TN:
                case CommonConstants.PRODUCT_FP4057TN_E:
                #endregion
                #region New_Product_Addition_AllBodySoltn AMIT
                case CommonConstants.PRODUCT_FP4057T_E_S1:
                #endregion
                #region New_Product_Addition_Vertical Vijay
                case CommonConstants.PRODUCT_FP4057T_E_VERTICAL:
                #endregion
                case CommonConstants.PRODUCT_FH9035T:
                case CommonConstants.PRODUCT_FH9035T_E:
                case CommonConstants.PRODUCT_FH9057T:
                case CommonConstants.PRODUCT_FH9057T_E:

                #region New FP Models-43&70 SnehalM
                case CommonConstants.PRODUCT_FP5043T:
                case CommonConstants.PRODUCT_FP5043TN:
                case CommonConstants.PRODUCT_FP5043T_E:
                case CommonConstants.PRODUCT_FP5043TN_E:
                case CommonConstants.PRODUCT_FP5070T:
                case CommonConstants.PRODUCT_FP5070TN:
                case CommonConstants.PRODUCT_FP5070T_E:
                case CommonConstants.PRODUCT_FP5070TN_E:
                case CommonConstants.PRODUCT_FP5121T:
                case CommonConstants.PRODUCT_FP5121TN:
                case CommonConstants.PRODUCT_FP5121TN_S0://Haresh_5121TN-SO
                #endregion
                case CommonConstants.PRODUCT_FP5070T_E_S2://New FP5070T-E-S2 product Addition Suyash
                #region Toshiba US products SnehalM
                case CommonConstants.PRODUCT_OIS55_Plus:
                case CommonConstants.PRODUCT_OIS60_Plus:

                #endregion
                case CommonConstants.PRODUCT_HMC7035A_M:
                case CommonConstants.PRODUCT_HMC7057A_M:
                #region //Mapple Customization 2.0_Sanjay
                case CommonConstants.PRODUCT_HMC7043A_M:
                case CommonConstants.PRODUCT_HMC7070A_M:
                #endregion

                //New Ethernet Models - SnehaK
                case CommonConstants.PRODUCT_TRPMIU0300E:
                case CommonConstants.PRODUCT_TRPMIU0500E:
                //End
                //Toshiba_US New product Addition
                case CommonConstants.PRODUCT_OIS45_Plus:
                case CommonConstants.PRODUCT_OIS45E_Plus:
                case CommonConstants.PRODUCT_OIS70_Plus:
                case CommonConstants.PRODUCT_OIS70E_Plus:
                case CommonConstants.PRODUCT_OIS120A:
                //Toshiba-Japan_Product
                case CommonConstants.PRODUCT_TRPMIU0400E:
                case CommonConstants.PRODUCT_TRPMIU0700E:
                //End
                case CommonConstants.PRODUCT_FL100:
                case CommonConstants.PRODUCT_FL100_S0://SS_FL100S0
                case CommonConstants.PRODUCT_GPU230_3S: //New_Product_Addition Vijay(15.05.2014)
                #region PLC_Direct Vijay
                case CommonConstants.PRODUCT_CPU_300:
                #endregion

                #region New FP3series product Addition Suyash
                case CommonConstants.PRODUCT_FP3043T://New FP3043T product Addition Suyash
                case CommonConstants.PRODUCT_FP3043TN://New FP3043TN product Addition Suyash
                case CommonConstants.PRODUCT_FP3070T://New FP3070T product Addition Suyash
                case CommonConstants.PRODUCT_FP3070TN://New FP3070TN product Addition Suyash
                case CommonConstants.PRODUCT_FP3102T://New FP3102T product Addition Suyash
                case CommonConstants.PRODUCT_FP3102TN://New FP3102TN product Addition Suyash
                #region SY-FP3_PlugableIO_Product_addition
                case CommonConstants.PRODUCT_FP3070T_E:
                case CommonConstants.PRODUCT_FP3070TN_E:
                case CommonConstants.PRODUCT_FP3102T_E:
                case CommonConstants.PRODUCT_FP3102TN_E:
                #endregion
                #region FP3043_ExpansionSeries Vijay
                case CommonConstants.PRODUCT_FP3043T_E:
                case CommonConstants.PRODUCT_FP3043TN_E:
                #endregion
                #endregion
                #region Hitachi Hi-Rel Vijay
                case CommonConstants.PRODUCT_HH5P_H43_NS:
                case CommonConstants.PRODUCT_HH5P_H43_S:
                case CommonConstants.PRODUCT_HH5P_H70_NS:
                case CommonConstants.PRODUCT_HH5P_H70_S:
                case CommonConstants.PRODUCT_HH5P_H100_NS:
                case CommonConstants.PRODUCT_HH5P_H100_S:
                case CommonConstants.PRODUCT_HH1L_000:
                case CommonConstants.PRODUCT_HH5P_HP43_NS:
                case CommonConstants.PRODUCT_HH5P_HP70_NS:
                #endregion
                #region OIS3Series_Vijay
                case CommonConstants.PRODUCT_OIS43E_Plus:
                case CommonConstants.PRODUCT_OIS72E_Plus:
                case CommonConstants.PRODUCT_OIS100E_Plus:
                #endregion
                #region Panasonic sammed 2.0
                case CommonConstants.PRODUCT_GTXL07N:
                case CommonConstants.PRODUCT_GTXL10N:
                #endregion
                case CommonConstants.PRODUCT_PRIZM_710_S0: //Lohia_710_change  //USB_Host_change
                case CommonConstants.PRODUCT_FL055://FL055_Product_Addition_Suyash
                case CommonConstants.PRODUCT_FL050_V2: //Issue_1295 Vijay
                    retValue = true;
                    break;

            }
            return retValue;
        }

        public static string GetBMPFileName(int pProductId)
        {
            string BMPFileName = "";
            DataRow[] drMemory;

            drMemory = dsRecentProjectList.Tables["UnitInformation"].Select("ModelNo= '" + pProductId + "'");

            foreach (DataRow dr in drMemory)
            {
                BMPFileName = dr["BMPFile"].ToString();
            }

            return BMPFileName;
        }

        #region Straton_Amit
        public static bool IsProductSupportsIEC(int ProductID)
        {
            bool supported = false;

            switch (ProductID)
            {
                case ClassList.CommonConstants.PRODUCT_FP2020_L0808RP_A0401L: //2020_Series_Vijay
                case ClassList.CommonConstants.PRODUCT_FP2020_L0808P_A0401L:
                case ClassList.CommonConstants.PRODUCT_FP2020_L0604P_A0401L:
                case ClassList.CommonConstants.PRODUCT_GSM910://GWY_910_Suyash//Asper_discussion_UPSir_GWY910IEC_Add_SY()07-10-2015
                case ClassList.CommonConstants.PRODUCT_FP3020MR_L1608RP://Suyash_FP3020MR_L1608RP_Prod_Addition
                case ClassList.CommonConstants.PRODUCT_FP4035T:
                case ClassList.CommonConstants.PRODUCT_FP4035T_E:
                case ClassList.CommonConstants.PRODUCT_FP4035TN:
                case ClassList.CommonConstants.PRODUCT_FP4035TN_E:
                case ClassList.CommonConstants.PRODUCT_FP4057T:
                case ClassList.CommonConstants.PRODUCT_FP4057T_E:
                case ClassList.CommonConstants.PRODUCT_FP4057T_E_VERTICAL: //New_Product_Addition_Vertical Vijay
                case ClassList.CommonConstants.PRODUCT_FP4057TN:
                case ClassList.CommonConstants.PRODUCT_FP4057TN_E:
                case ClassList.CommonConstants.PRODUCT_FP5043T:
                case ClassList.CommonConstants.PRODUCT_FP5043T_E:
                case ClassList.CommonConstants.PRODUCT_FP5043TN:
                case ClassList.CommonConstants.PRODUCT_FP5043TN_E:
                case ClassList.CommonConstants.PRODUCT_FP5070T:
                case ClassList.CommonConstants.PRODUCT_FP5070T_E:
                case ClassList.CommonConstants.PRODUCT_FP5070TN:
                case ClassList.CommonConstants.PRODUCT_FP5070TN_E:
                case ClassList.CommonConstants.PRODUCT_FP5070T_E_S2://New FP5070T-E-S2 product Addition Suyash
                case ClassList.CommonConstants.PRODUCT_FP5121T:
                case ClassList.CommonConstants.PRODUCT_FP5121TN:
                //case ClassList.CommonConstants.PRODUCT_FL010:
                #region Sanjayy(18-6-2012)
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RN_A0201:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RN: //New Product addition FP4030MT-L0808RN/RP Vijay
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RP: //New Product addition FP4030MT-L0808RN/RP Vijay
                //case ClassList.CommonConstants.PRODUCT_FP4030MT_HORIZONTAL:
                //case ClassList.CommonConstants.PRODUCT_FP4030MT_S1_HORIZONTAL:
                //case ClassList.CommonConstants.PRODUCT_FP4030MT_S1_VERTICAL:
                //case ClassList.CommonConstants.PRODUCT_FP4030MT_VERTICAL:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_REV1://New Product addition FP4030MT- Rev 1
                #region New FP4030MT Vertical Series Addition Vijay
                case ClassList.CommonConstants.PRODUCT_FP4030MT_REV1_VERTICAL:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RN_A0201_VERTICAL:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201_VERTICAL:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RN_VERTICAL:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RP_VERTICAL:
                #endregion
                #endregion
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201L://FP4030MT_L0808RP_A0201L_addition_sammed
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201L_VERTICAL://FP4030MT_L0808RP_A0201L(Vertical)_addition_sammed
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201_S0: //New Product Addition FP4030MT-L0808RP-A0201-S0 Vijay
                #region New Product Addtion FP4030MT_L0808P/FP4030MT_L0808P_A0201U Vijay
                case CommonConstants.PRODUCT_FP4030MT_L0808P:
                case CommonConstants.PRODUCT_FP4030MT_L0808P_A0201U:
                #endregion
                case CommonConstants.PRODUCT_FP4030MT_L0808P_A0402L://Suyash_Product_Addition_FP4030MT_L0808P_A0402L
                #region FL005-MicroPLC Base Module Series Vijay
                //Remove_Product Vijay
                //case ClassList.CommonConstants.PRODUCT_FL005_0604RP:
                //case ClassList.CommonConstants.PRODUCT_FL005_0604RP0201L:
                //
                case ClassList.CommonConstants.PRODUCT_FL005_0808RP:
                case ClassList.CommonConstants.PRODUCT_FL005_0808RP0201L:
                //FL005-MicroPLC Base Module Series Vijay1
                case ClassList.CommonConstants.PRODUCT_FL005_0604P:
                case ClassList.CommonConstants.PRODUCT_FL005_0808P:
                case ClassList.CommonConstants.PRODUCT_FL005_0808P0201L:
                case ClassList.CommonConstants.PRODUCT_FL005_0604N:
                case ClassList.CommonConstants.PRODUCT_FL005_0808N:
                case ClassList.CommonConstants.PRODUCT_FL005_0808N0201L:
                case ClassList.CommonConstants.PRODUCT_FL005_1616P0201L_S1://New FL005 Product Addition Suyash
                //End
                #endregion
                #region FL005 Expandable PLC Series Vijay
                case ClassList.CommonConstants.PRODUCT_FL005_0808RP0402U:
                case ClassList.CommonConstants.PRODUCT_FL005_1616RP0201L:
                case ClassList.CommonConstants.PRODUCT_FL005_1616P0201L:
                case ClassList.CommonConstants.PRODUCT_FL005_1616N0201L:
                case ClassList.CommonConstants.PRODUCT_FL005_1616RP:
                case ClassList.CommonConstants.PRODUCT_FL005_1616P:
                #endregion
                #region Toshiba IEC support SP
                //case ClassList.CommonConstants.PRODUCT_MICRO_PLC:
                //case ClassList.CommonConstants.PRODUCT_MICRO_PLC_ETHERNET:
                case ClassList.CommonConstants.PRODUCT_TRPMIU0300L:
                case ClassList.CommonConstants.PRODUCT_TRPMIU0300A:
                case ClassList.CommonConstants.PRODUCT_TRPMIU0500L:
                case ClassList.CommonConstants.PRODUCT_TRPMIU0500A:
                //case ClassList.CommonConstants.PRODUCT_TRPMIU0300E:
                //case ClassList.CommonConstants.PRODUCT_TRPMIU0500E:
                case ClassList.CommonConstants.PRODUCT_TRPMIU0400E:
                case ClassList.CommonConstants.PRODUCT_TRPMIU0700E:
                #endregion
                #region PLC_Direct Vijay
                case CommonConstants.PRODUCT_CPU_300:
                case CommonConstants.PRODUCT_CPU_111_RP:
                case CommonConstants.PRODUCT_CPU_120_ARP:
                case CommonConstants.PRODUCT_CPU_100_P:
                case CommonConstants.PRODUCT_CPU_110_P:
                case CommonConstants.PRODUCT_CPU_120_AP:
                case CommonConstants.PRODUCT_CPU_100_N:
                case CommonConstants.PRODUCT_CPU_110_N:
                case CommonConstants.PRODUCT_CPU_120_AN:
                #endregion

                #region ToshibaUS IEC supported Vijay
                case ClassList.CommonConstants.PRODUCT_OIS42_Plus: //New_Product_Addition Vijay(01.03.2013)
                case ClassList.CommonConstants.PRODUCT_OIS42L_Plus: //New_Product_Addition Vijay(12.09.2013)
                case ClassList.CommonConstants.PRODUCT_OIS55_Plus:
                case ClassList.CommonConstants.PRODUCT_OIS60_Plus:
                case ClassList.CommonConstants.PRODUCT_OIS45_Plus:
                case ClassList.CommonConstants.PRODUCT_OIS45E_Plus:
                case ClassList.CommonConstants.PRODUCT_OIS70_Plus:
                case ClassList.CommonConstants.PRODUCT_OIS70E_Plus:
                case ClassList.CommonConstants.PRODUCT_OIS120A:
                case ClassList.CommonConstants.PRODUCT_GPU230_3S: //New_Product_Addition Vijay(01.03.2013)
                case ClassList.CommonConstants.PRODUCT_GPU110_3S: //New_Product_Addition Vijay(15.05.2014)
                case ClassList.CommonConstants.PRODUCT_GPU105_3S://New_Product_Addition Parag(9.12.2014)
                case ClassList.CommonConstants.PRODUCT_GPU120_3S://New_Product_Addition Parag(9.12.2014)
                case ClassList.CommonConstants.PRODUCT_GPU122_3S: //New_Product_Addition Vijay(07.04.2015)
                #endregion

                #region New FL100 Model SAMMED
                case CommonConstants.PRODUCT_FL100:
                #endregion

                #region //Mapple Customization 2.0_Sanjay
                case ClassList.CommonConstants.PRODUCT_HMC7035A_M:
                case ClassList.CommonConstants.PRODUCT_HMC7057A_M:
                case ClassList.CommonConstants.PRODUCT_HMC7043A_M:
                case ClassList.CommonConstants.PRODUCT_HMC7070A_M:
                #endregion
                case CommonConstants.PRODUCT_FP4030MR_0808R_A0400_S0://PRODUCT_FP4030MR_0808R_A0400_S0_addition_sammed
                case CommonConstants.PRODUCT_FP4030MR_L1210RP_A0402U: //PRODUCT_FP4030MR_L1210RP_A0402U Vijay
                case CommonConstants.PRODUCT_FP4030MR_L1210P_A0402U:  //PRODUCT_FP4030MR_L1210P_A0402U Vijay
                case CommonConstants.PRODUCT_FP4030MR_L1210RP://PRODUCT_FP4030MR_L1210RP Suyash
                case CommonConstants.PRODUCT_FP4030MR_L1210P://PRODUCT_FP4030MR_L1210P Suyash
                case CommonConstants.PRODUCT_FP4030MR_L0808R_A0400U: //PRODUCT_FP4030MR_L0808R_A0400U Vijay
                #region New FP3035 Product Series
                //case ClassList.CommonConstants.PRODUCT_FP3035T:
                #endregion

                #region
                case ClassList.CommonConstants.PRODUCT_FP3043T://New FP3043T product Addition Suyash
                case ClassList.CommonConstants.PRODUCT_FP3043TN://New FP3043TN product Addition Suyash
                case ClassList.CommonConstants.PRODUCT_FP3070T://New FP3070T product Addition Suyash
                case ClassList.CommonConstants.PRODUCT_FP3102T://New FP3102T product Addition Suyash
                case ClassList.CommonConstants.PRODUCT_FP3070TN://New FP3070TN product Addition Suyash
                case ClassList.CommonConstants.PRODUCT_FP3102TN://New FP3102TN product Addition Suyash
                #region SY-FP3_PlugableIO_Product_addition
                case ClassList.CommonConstants.PRODUCT_FP3070T_E:
                case ClassList.CommonConstants.PRODUCT_FP3102T_E:
                case ClassList.CommonConstants.PRODUCT_FP3070TN_E:
                case ClassList.CommonConstants.PRODUCT_FP3102TN_E:
                #endregion
                #region FP3043_ExpansionSeries Vijay
                case CommonConstants.PRODUCT_FP3043T_E:
                case CommonConstants.PRODUCT_FP3043TN_E:
                #endregion
                #endregion
                #region Hitachi Hi-Rel Vijay
                case CommonConstants.PRODUCT_HH5P_H43_NS:
                case CommonConstants.PRODUCT_HH5P_H43_S:
                case CommonConstants.PRODUCT_HH5P_H70_NS:
                case CommonConstants.PRODUCT_HH5P_H70_S:
                case CommonConstants.PRODUCT_HH5P_H100_NS:
                case CommonConstants.PRODUCT_HH5P_H100_S:
                case CommonConstants.PRODUCT_HH5L_B0604D_P:
                case CommonConstants.PRODUCT_HH5L_B0808D_P:
                case CommonConstants.PRODUCT_HH5L_B1616D_P:
                case CommonConstants.PRODUCT_HH5L_B1616D_RP:
                case CommonConstants.PRODUCT_HH5L_B0201A0808D_P:
                case CommonConstants.PRODUCT_HH5L_B0201A1616D_RP:
                case CommonConstants.PRODUCT_HH5L_B0402AU0808D_RP:
                case CommonConstants.PRODUCT_HH1L_000:
                case CommonConstants.PRODUCT_HH5P_HP300201U0808_RP:
                case CommonConstants.PRODUCT_HH5P_HP300201L0808_RP:
                case CommonConstants.PRODUCT_HH5P_HP43_NS:
                case CommonConstants.PRODUCT_HH5P_HP70_NS:
                #endregion
                #region OIS3Series_Vijay
                case CommonConstants.PRODUCT_OIS43E_Plus:
                case CommonConstants.PRODUCT_OIS72E_Plus:
                case CommonConstants.PRODUCT_OIS100E_Plus:
                #endregion
                #region Panasonic sammed 2.0
                case CommonConstants.PRODUCT_GTXL07N:
                case CommonConstants.PRODUCT_GTXL10N:
                #endregion
                case CommonConstants.PRODUCT_PRIZM_710_S0: //Lohia_710_change
                case CommonConstants.PRODUCT_FL050_V2://New Product FL050 V2 SammedB
                case ClassList.CommonConstants.PRODUCT_FL055://FL055_Product_Addition_Suyash
                    supported = true;
                    break;
            }
            return supported;
        }

        #region Vijay_08.07.013
        public static bool FP4030MT_Rev1ApplicationConversion(int ProductID)
        {
            bool supported = false;
            switch (ProductID)
            {
                case ClassList.CommonConstants.PRODUCT_FP4030MT_REV1:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RN_A0201:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RN:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RP:
                case CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201L://FP4030MT_L0808RP_A0201L_addition_sammed //Vijay_23.10.13
                #region New Product Addtion FP4030MT_L0808P/FP4030MT_L0808P_A0201U Vijay
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808P:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808P_A0201U:
                #endregion
                case CommonConstants.PRODUCT_FP4030MT_L0808P_A0402L://Suyash_Product_Addition_FP4030MT_L0808P_A0402L
                #region Hitachi Hi-Rel Vijay
                case ClassList.CommonConstants.PRODUCT_HH5P_HP300201U0808_RP:
                case ClassList.CommonConstants.PRODUCT_HH5P_HP300201L0808_RP:
                #endregion
                    supported = true;
                    break;
            }
            return supported;
        }
        public static bool FP4030MT_L0808RPApplicationConversion(int ProductID)
        {
            bool supported = false;
            switch (ProductID)
            {
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RN_A0201:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RN:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RP:
                case CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201L://FP4030MT_L0808RP_A0201L_addition_sammed //Vijay_23.10.13
                #region New Product Addtion FP4030MT_L0808P/FP4030MT_L0808P_A0201U Vijay
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808P:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808P_A0201U:
                #endregion
                case CommonConstants.PRODUCT_FP4030MT_L0808P_A0402L://Suyash_Product_Addition_FP4030MT_L0808P_A0402L
                #region Hitachi Hi-Rel Vijay
                case ClassList.CommonConstants.PRODUCT_HH5P_HP300201U0808_RP:
                case ClassList.CommonConstants.PRODUCT_HH5P_HP300201L0808_RP:
                #endregion
                    supported = true;
                    break;
            }
            return supported;
        }
        public static bool FP4030MT_L0808RNApplicationConversion(int ProductID)
        {
            bool supported = false;
            switch (ProductID)
            {
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RN_A0201:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RN:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RP:
                case CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201L://FP4030MT_L0808RP_A0201L_addition_sammed //Vijay_23.10.13
                #region New Product Addtion FP4030MT_L0808P/FP4030MT_L0808P_A0201U Vijay
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808P:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808P_A0201U:
                #endregion
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808P_A0402L://Suyash_Product_Addition_FP4030MT_L0808P_A0402L
                #region Hitachi Hi-Rel Vijay
                case ClassList.CommonConstants.PRODUCT_HH5P_HP300201U0808_RP:
                case ClassList.CommonConstants.PRODUCT_HH5P_HP300201L0808_RP:
                #endregion
                    supported = true;
                    break;
            }
            return supported;
        }
        public static bool FP4030MT_L0808RP_A0201UApplicationConversion(int ProductID)
        {
            bool supported = false;
            switch (ProductID)
            {
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RN_A0201:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201:
                case CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201L://FP4030MT_L0808RP_A0201L_addition_sammed //Vijay_23.10.13
                #region New Product Addtion FP4030MT_L0808P/FP4030MT_L0808P_A0201U Vijay
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808P:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808P_A0201U:
                #endregion
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808P_A0402L://Suyash_Product_Addition_FP4030MT_L0808P_A0402L
                #region Hitachi Hi-Rel Vijay
                case ClassList.CommonConstants.PRODUCT_HH5P_HP300201U0808_RP:
                case ClassList.CommonConstants.PRODUCT_HH5P_HP300201L0808_RP:
                #endregion
                    supported = true;
                    break;
            }
            return supported;
        }
        public static bool FP4030MT_L0808RN_A0201UApplicationConversion(int ProductID)
        {
            bool supported = false;
            switch (ProductID)
            {
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RN_A0201:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201:
                case CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201L://FP4030MT_L0808RP_A0201L_addition_sammed //Vijay_23.10.13
                #region New Product Addtion FP4030MT_L0808P/FP4030MT_L0808P_A0201U Vijay
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808P:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808P_A0201U:
                #endregion
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808P_A0402L://Suyash_Product_Addition_FP4030MT_L0808P_A0402L
                #region Hitachi Hi-Rel Vijay
                case ClassList.CommonConstants.PRODUCT_HH5P_HP300201U0808_RP:
                case ClassList.CommonConstants.PRODUCT_HH5P_HP300201L0808_RP:
                #endregion
                    supported = true;
                    break;
            }
            return supported;
        }
        #region New Product Addtion FP4030MT_L0808P/FP4030MT_L0808P_A0201U Vijay
        public static bool FP4030MT_L0808PApplicationConversion(int ProductID)
        {
            bool supported = false;
            switch (ProductID)
            {
                case ClassList.CommonConstants.PRODUCT_FP4030MT_REV1:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RN_A0201:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RN:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RP:
                case CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201L://FP4030MT_L0808RP_A0201L_addition_sammed //Vijay_23.10.13
                #region New Product Addtion FP4030MT_L0808P/FP4030MT_L0808P_A0201U Vijay
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808P:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808P_A0201U:
                #endregion
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808P_A0402L://Suyash_Product_Addition_FP4030MT_L0808P_A0402L
                #region Hitachi Hi-Rel Vijay
                case ClassList.CommonConstants.PRODUCT_HH5P_HP300201U0808_RP:
                case ClassList.CommonConstants.PRODUCT_HH5P_HP300201L0808_RP:
                #endregion
                    supported = true;
                    break;
            }
            return supported;
        }
        public static bool FP4030MT_L0808P_A0201UApplicationConversion(int ProductID)
        {
            bool supported = false;
            switch (ProductID)
            {
                case ClassList.CommonConstants.PRODUCT_FP4030MT_REV1:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RN_A0201:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RN:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RP:
                case CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201L://FP4030MT_L0808RP_A0201L_addition_sammed //Vijay_23.10.13
                #region New Product Addtion FP4030MT_L0808P/FP4030MT_L0808P_A0201U Vijay
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808P:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808P_A0201U:
                #endregion
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808P_A0402L://Suyash_Product_Addition_FP4030MT_L0808P_A0402L
                #region Hitachi Hi-Rel Vijay
                case ClassList.CommonConstants.PRODUCT_HH5P_HP300201U0808_RP:
                case ClassList.CommonConstants.PRODUCT_HH5P_HP300201L0808_RP:
                #endregion
                    supported = true;
                    break;
            }
            return supported;
        }
        #endregion
        #region Suyash_Product_Addition_FP4030MT_L0808P_A0402L
        public static bool FP4030MT_L0808P_A0402LApplicationConversion(int ProductID)
        {
            bool supported = false;
            switch (ProductID)
            {
                case ClassList.CommonConstants.PRODUCT_FP4030MT_REV1:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RN_A0201:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RN:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RP:
                case CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201L://FP4030MT_L0808RP_A0201L_addition_sammed //Vijay_23.10.13
                #region New Product Addtion FP4030MT_L0808P/FP4030MT_L0808P_A0201U Vijay
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808P:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808P_A0201U:
                #endregion
                //case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808P_A0402L://Suyash_Product_Addition_FP4030MT_L0808P_A0402L
                #region Hitachi Hi-Rel Vijay
                case ClassList.CommonConstants.PRODUCT_HH5P_HP300201U0808_RP:
                case ClassList.CommonConstants.PRODUCT_HH5P_HP300201L0808_RP:
                #endregion
                    supported = true;
                    break;
            }
            return supported;
        }
        #endregion
        #region coversion_FP4030MT_L0808RP_A0201L_to_FP4030MT_L0808P Sammedb
        public static bool FP4030MT_L0808RP_A0201LApplicationConversion(int ProductID)
        {
            bool supported = false;
            switch (ProductID)
            {
                // case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201L:       
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808P:
                    supported = true;
                    break;
            }
            return supported;
        }
        #endregion
        #region New FP4030MT Vertical Series Addition Vijay
        public static bool FP4030MT_Rev1VerticalApplicationConversion(int ProductID)
        {
            bool supported = false;
            switch (ProductID)
            {
                case ClassList.CommonConstants.PRODUCT_FP4030MT_REV1_VERTICAL:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RN_A0201_VERTICAL:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201_VERTICAL:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RN_VERTICAL:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RP_VERTICAL:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201L_VERTICAL://FP4030MT_L0808RP_A0201L(Vertical)_addition_sammed
                    supported = true;
                    break;
            }
            return supported;
        }
        public static bool FP4030MT_L0808RPVerticalApplicationConversion(int ProductID)
        {
            bool supported = false;
            switch (ProductID)
            {
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RN_A0201_VERTICAL:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201_VERTICAL:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RN_VERTICAL:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RP_VERTICAL:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201L_VERTICAL://FP4030MT_L0808RP_A0201L(Vertical)_addition_sammed
                    supported = true;
                    break;
            }
            return supported;
        }
        public static bool FP4030MT_L0808RNVerticalApplicationConversion(int ProductID)
        {
            bool supported = false;
            switch (ProductID)
            {
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RN_A0201_VERTICAL:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201_VERTICAL:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RN_VERTICAL:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RP_VERTICAL:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201L_VERTICAL://FP4030MT_L0808RP_A0201L(Vertical)_addition_sammed
                    supported = true;
                    break;
            }
            return supported;
        }
        public static bool FP4030MT_L0808RP_A0201UVerticalApplicationConversion(int ProductID)
        {
            bool supported = false;
            switch (ProductID)
            {
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RN_A0201_VERTICAL:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201_VERTICAL:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201L_VERTICAL://FP4030MT_L0808RP_A0201L(Vertical)_addition_sammed
                    supported = true;
                    break;
            }
            return supported;
        }
        public static bool FP4030MT_L0808RN_A0201UVerticalApplicationConversion(int ProductID)
        {
            bool supported = false;
            switch (ProductID)
            {
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RN_A0201_VERTICAL:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201_VERTICAL:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201L_VERTICAL://FP4030MT_L0808RP_A0201L(Vertical)_addition_sammed
                    supported = true;
                    break;
            }
            return supported;
        }
        #endregion

        #region Vijay_25.07.13
        public static bool OIS42PlusApplicationConversion(int ProductID)
        {
            bool supported = false;
            switch (ProductID)
            {
                case ClassList.CommonConstants.PRODUCT_OIS42_Plus:
                    supported = true;
                    break;
                #region New_Product_Addition Vijay(12.09.2013)
                case ClassList.CommonConstants.PRODUCT_OIS42L_Plus:
                    supported = true;
                    break;
                #endregion
            }
            return supported;
        }
        #endregion

        #endregion


        #region Vijay_10.01.13
        public static bool IsProductSupportedFP4020MR(int ProductID)
        {
            bool supported = false;
            switch (ProductID)
            {
                case ClassList.CommonConstants.PRODUCT_FP2020_L0808RP_A0401L: //2020_Series_Vijay
                case ClassList.CommonConstants.PRODUCT_FP2020_L0808P_A0401L:
                case ClassList.CommonConstants.PRODUCT_FP2020_L0604P_A0401L:
                case ClassList.CommonConstants.PRODUCT_FP3020MR_L1608RP://Suyash_FP3020MR_L1608RP_Prod_Addition
                case ClassList.CommonConstants.PRODUCT_FP4020MR:
                case ClassList.CommonConstants.PRODUCT_FP4020MR_L0808P:
                case ClassList.CommonConstants.PRODUCT_FP4020MR_L0808N:
                case ClassList.CommonConstants.PRODUCT_FP4020MR_L0808R:
                case ClassList.CommonConstants.PRODUCT_FP4020MR_L0808R_S3:
                case ClassList.CommonConstants.PRODUCT_OIS10_Plus:
                case ClassList.CommonConstants.PRODUCT_OIS12:
                case ClassList.CommonConstants.PRODUCT_HH5P_HP200808D_P: //Hitachi Hi-Rel Vijay
                    supported = true;
                    break;
            }
            return supported;
        }
        public static bool IsProductSupportedFP4030MR(int ProductID)
        {
            bool supported = false;
            switch (ProductID)
            {
                case ClassList.CommonConstants.PRODUCT_FP4030MR:
                case ClassList.CommonConstants.PRODUCT_FP4030MR_E:
                case ClassList.CommonConstants.PRODUCT_FP4030MR_L1208R:
                case ClassList.CommonConstants.PRODUCT_OIS20_Plus:
                case ClassList.CommonConstants.PRODUCT_OIS22_Plus:
                case ClassList.CommonConstants.PRODUCT_HMC7030A_L:
                case ClassList.CommonConstants.PRODUCT_HMC7030A_M:
                case ClassList.CommonConstants.PRODUCT_FP4030MR_0808R_A0400_S0://PRODUCT_FP4030MR_0808R_A0400_S0_addition_sammed
                case ClassList.CommonConstants.PRODUCT_FP4030MR_L1210RP_A0402U: //PRODUCT_FP4030MR_L1210RP_A0402U Vijay
                case ClassList.CommonConstants.PRODUCT_FP4030MR_L1210P_A0402U: //PRODUCT_FP4030MR_L1210P_A0402U Vijay
                case ClassList.CommonConstants.PRODUCT_FP4030MR_L1210RP://PRODUCT_FP4030MR_L1210RP Suyash
                case ClassList.CommonConstants.PRODUCT_FP4030MR_L1210P://PRODUCT_FP4030MR_L1210P Suyash
                case ClassList.CommonConstants.PRODUCT_FP4030MR_L0808R_A0400U: //PRODUCT_FP4030MR_L0808R_A0400U Vijay
                case ClassList.CommonConstants.PRODUCT_HH5P_HP301208D_R: //Hitachi Hi-Rel Vijay
                    supported = true;
                    break;
            }
            return supported;
        }
        public static bool IsProductSupportedFP4030MT(int ProductID)
        {
            bool supported = false;
            switch (ProductID)
            {
                case ClassList.CommonConstants.PRODUCT_FP4030MT_HORIZONTAL:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_VERTICAL:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_S1_HORIZONTAL:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_S1_VERTICAL:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RN_A0201:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_REV1://New Product addition FP4030MT- Rev 1
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RN: //New Product addition FP4030MT-L0808RN/RP Vijay
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RP: //New Product addition FP4030MT-L0808RN/RP Vijay
                #region New FP4030MT Vertical Series Addition Vijay
                case ClassList.CommonConstants.PRODUCT_FP4030MT_REV1_VERTICAL:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RN_A0201_VERTICAL:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201_VERTICAL:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RN_VERTICAL:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RP_VERTICAL:
                #endregion
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201L://FP4030MT_L0808RP_A0201L_addition_sammed
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201L_VERTICAL://FP4030MT_L0808RP_A0201L(Vertical)_addition_sammed
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201_S0: //New Product Addition FP4030MT-L0808RP-A0201-S0 Vijay
                #region New Product Addtion FP4030MT_L0808P/FP4030MT_L0808P_A0201U Vijay
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808P:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808P_A0201U:
                #endregion
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808P_A0402L://Suyash_Product_Addition_FP4030MT_L0808P_A0402L
                case ClassList.CommonConstants.PRODUCT_OIS40_Plus_HORIZONTAL:
                case ClassList.CommonConstants.PRODUCT_OIS40_Plus_VERTICAL:
                case ClassList.CommonConstants.PRODUCT_OIS42_Plus: //New_Product_Addition Vijay(01.03.2013)
                case ClassList.CommonConstants.PRODUCT_OIS42L_Plus: //New_Product_Addition Vijay(12.09.2013)
                #region Hitachi Hi-Rel Vijay
                case ClassList.CommonConstants.PRODUCT_HH5P_HP300201U0808_RP:
                case ClassList.CommonConstants.PRODUCT_HH5P_HP300201L0808_RP:
                #endregion
                    supported = true;
                    break;
            }
            return supported;
        }
        public static bool IsProductSupportedFP4035(int ProductID)
        {
            bool supported = false;
            switch (ProductID)
            {
                case ClassList.CommonConstants.PRODUCT_FP4035T:
                case ClassList.CommonConstants.PRODUCT_FP4035T_E:
                case ClassList.CommonConstants.PRODUCT_FP4035TN:
                case ClassList.CommonConstants.PRODUCT_FP4035TN_E:
                case ClassList.CommonConstants.PRODUCT_OIS55_Plus:
                case ClassList.CommonConstants.PRODUCT_TRPMIU0300A:
                case ClassList.CommonConstants.PRODUCT_TRPMIU0300L:
                case ClassList.CommonConstants.PRODUCT_TRPMIU0300E:
                case ClassList.CommonConstants.PRODUCT_HMC7035A_M:
                    supported = true;
                    break;
            }
            return supported;
        }
        public static bool IsProductSupportedFP4057(int ProductID)
        {
            bool supported = false;
            switch (ProductID)
            {
                case ClassList.CommonConstants.PRODUCT_FP4057T:
                case ClassList.CommonConstants.PRODUCT_FP4057T_E:
                case ClassList.CommonConstants.PRODUCT_FP4057T_E_VERTICAL: //New_Product_Addition_Vertical Vijay
                case ClassList.CommonConstants.PRODUCT_FP4057TN:
                case ClassList.CommonConstants.PRODUCT_FP4057TN_E:
                case ClassList.CommonConstants.PRODUCT_FP4057T_S2:
                case ClassList.CommonConstants.PRODUCT_FP4057T_E_S1:
                case ClassList.CommonConstants.PRODUCT_OIS60_Plus:
                case ClassList.CommonConstants.PRODUCT_TRPMIU0500A:
                case ClassList.CommonConstants.PRODUCT_TRPMIU0500L:
                case ClassList.CommonConstants.PRODUCT_TRPMIU0500E:
                case ClassList.CommonConstants.PRODUCT_HMC7057A_M:
                    supported = true;
                    break;
            }
            return supported;
        }
        public static bool IsProductSupportedFP5043(int ProductID)
        {
            bool supported = false;
            switch (ProductID)
            {
                case ClassList.CommonConstants.PRODUCT_FP5043T:
                case ClassList.CommonConstants.PRODUCT_FP5043T_E:
                case ClassList.CommonConstants.PRODUCT_FP5043TN:
                case ClassList.CommonConstants.PRODUCT_FP5043TN_E:
                case ClassList.CommonConstants.PRODUCT_OIS45_Plus:
                case ClassList.CommonConstants.PRODUCT_OIS45E_Plus:
                case ClassList.CommonConstants.PRODUCT_TRPMIU0400E:
                case ClassList.CommonConstants.PRODUCT_HMC7043A_M: //New_Product_Addition Vijay-Sanjay
                #region New FP3series product Addition Suyash
                case ClassList.CommonConstants.PRODUCT_FP3043T://New FP3043T product Addition Suyash
                case ClassList.CommonConstants.PRODUCT_FP3043TN://New FP3043TN product Addition Suyash
                #region FP3043_ExpansionSeries Vijay
                case CommonConstants.PRODUCT_FP3043T_E:
                case CommonConstants.PRODUCT_FP3043TN_E:
                #endregion
                #region SY-FP3_PlugableIO_Product_addition
                case CommonConstants.PRODUCT_FP3070T_E:
                case CommonConstants.PRODUCT_FP3070TN_E:
                case CommonConstants.PRODUCT_FP3102T_E:
                case CommonConstants.PRODUCT_FP3102TN_E:
                #endregion
                #region Hitachi Hi-Rel Vijay
                case CommonConstants.PRODUCT_HH5P_H43_NS:
                case CommonConstants.PRODUCT_HH5P_H43_S:
                case CommonConstants.PRODUCT_HH5P_HP43_NS:
                #endregion
                #endregion
                case CommonConstants.PRODUCT_OIS43E_Plus: //OIS3Series_Vijay                
                    supported = true;
                    break;
            }
            return supported;
        }
        public static bool IsProductSupportedFP5070(int ProductID)
        {
            bool supported = false;
            switch (ProductID)
            {
                case ClassList.CommonConstants.PRODUCT_FP5070T:
                case ClassList.CommonConstants.PRODUCT_FP5070T_E:
                case ClassList.CommonConstants.PRODUCT_FP5070TN:
                case ClassList.CommonConstants.PRODUCT_FP5070TN_E:
                case ClassList.CommonConstants.PRODUCT_FP5070T_E_S2://New FP5070T-E-S2 product Addition Suyash
                case ClassList.CommonConstants.PRODUCT_OIS70_Plus:
                case ClassList.CommonConstants.PRODUCT_OIS70E_Plus:
                case ClassList.CommonConstants.PRODUCT_TRPMIU0700E:
                case ClassList.CommonConstants.PRODUCT_HMC7070A_M: //New_Product_Addition Vijay-Sanjay
                #region New FP3series product Addition Suyash
                case ClassList.CommonConstants.PRODUCT_FP3070T://New FP3070T product Addition Suyash
                case ClassList.CommonConstants.PRODUCT_FP3070TN://New FP3070TN product Addition Suyash
                case ClassList.CommonConstants.PRODUCT_FP3102T://New FP3102T product Addition Suyash
                case ClassList.CommonConstants.PRODUCT_FP3102TN://New FP3102TN product Addition Suyash
                #endregion

                #region SY-FP3_PlugableIO_Product_addition
                case ClassList.CommonConstants.PRODUCT_FP3070T_E:
                case ClassList.CommonConstants.PRODUCT_FP3070TN_E:
                case ClassList.CommonConstants.PRODUCT_FP3102T_E:
                case ClassList.CommonConstants.PRODUCT_FP3102TN_E:
                #endregion
                #region Hitachi Hi-Rel Vijay
                case CommonConstants.PRODUCT_HH5P_H70_NS:
                case CommonConstants.PRODUCT_HH5P_H70_S:
                case CommonConstants.PRODUCT_HH5P_H100_NS:
                case CommonConstants.PRODUCT_HH5P_H100_S:
                case CommonConstants.PRODUCT_HH5P_HP70_NS:
                #endregion
                #region OIS3Series_Vijay
                case CommonConstants.PRODUCT_OIS72E_Plus:
                case CommonConstants.PRODUCT_OIS100E_Plus:
                #endregion
                #region Panasonic sammed 2.0
                case CommonConstants.PRODUCT_GTXL07N:
                case CommonConstants.PRODUCT_GTXL10N:
                #endregion
                    supported = true;
                    break;
            }
            return supported;
        }
        public static bool IsProductSupportedFP5121(int ProductID)
        {
            bool supported = false;
            switch (ProductID)
            {
                case ClassList.CommonConstants.PRODUCT_FP5121T:
                case ClassList.CommonConstants.PRODUCT_FP5121TN:
                case CommonConstants.PRODUCT_FP5121TN_S0://Haresh_5121TN-SO
                case ClassList.CommonConstants.PRODUCT_OIS120A:
                    supported = true;
                    break;
            }
            return supported;
        }
        #endregion

        #region Configuring_Ethernet_Setting_At_RunTime_Vijay
        public static bool IsProductSupportedFP5043ConfigureEthernetScreen(int ProductID)
        {
            bool supported = false;
            switch (ProductID)
            {
                case ClassList.CommonConstants.PRODUCT_FP5043TN:
                case ClassList.CommonConstants.PRODUCT_FP5043TN_E:
                case ClassList.CommonConstants.PRODUCT_OIS45_Plus:
                case ClassList.CommonConstants.PRODUCT_OIS45E_Plus:
                case ClassList.CommonConstants.PRODUCT_TRPMIU0400E:
                case ClassList.CommonConstants.PRODUCT_HMC7043A_M:
                case ClassList.CommonConstants.PRODUCT_FP3043TN://New FP3043TN product Addition Suyash
                case ClassList.CommonConstants.PRODUCT_HH5P_H43_S: //Hitachi Hi-Rel Vijay
                case ClassList.CommonConstants.PRODUCT_OIS43E_Plus: //OIS3Series_Vijay
                case CommonConstants.PRODUCT_FP3043TN_E: //FP3043_ExpansionSeries Vijay
                #region SY-FP3_PlugableIO_Product_addition
                case CommonConstants.PRODUCT_FP3070TN_E:
                case CommonConstants.PRODUCT_FP3102TN_E:
                #endregion
                    supported = true;
                    break;
            }
            return supported;
        }
        public static bool IsProductSupportedFP5070ConfigureEthernetScreen(int ProductID)
        {
            bool supported = false;
            switch (ProductID)
            {
                case ClassList.CommonConstants.PRODUCT_FP5070TN:
                case ClassList.CommonConstants.PRODUCT_FP5070TN_E:
                case ClassList.CommonConstants.PRODUCT_OIS70_Plus:
                case ClassList.CommonConstants.PRODUCT_OIS70E_Plus:
                case ClassList.CommonConstants.PRODUCT_TRPMIU0700E:
                case ClassList.CommonConstants.PRODUCT_HMC7070A_M:
                #region New FP3series product Addition Suyash
                case ClassList.CommonConstants.PRODUCT_FP3070TN://New FP3070TN product Addition Suyash
                case ClassList.CommonConstants.PRODUCT_FP3102TN://New FP3102TN product Addition Suyash
                #endregion
                #region SY-FP3_PlugableIO_Product_addition
                case ClassList.CommonConstants.PRODUCT_FP3070TN_E:
                case ClassList.CommonConstants.PRODUCT_FP3102TN_E:
                #endregion
                #region Hitachi Hi-Rel Vijay
                case CommonConstants.PRODUCT_HH5P_H70_S:
                case CommonConstants.PRODUCT_HH5P_H100_S:
                #endregion
                #region OIS3Series_Vijay
                case ClassList.CommonConstants.PRODUCT_OIS72E_Plus:
                case ClassList.CommonConstants.PRODUCT_OIS100E_Plus:
                #endregion
                #region Panasonic sammed 2.0
                case ClassList.CommonConstants.PRODUCT_GTXL07N:
                case ClassList.CommonConstants.PRODUCT_GTXL10N:
                #endregion
                    supported = true;
                    break;
            }
            return supported;
        }
        public static bool IsProductSupportedFP5121ConfigureEthernetScreen(int ProductID)
        {
            bool supported = false;
            switch (ProductID)
            {
                case ClassList.CommonConstants.PRODUCT_FP5121TN:
                case ClassList.CommonConstants.PRODUCT_OIS120A:
                    supported = true;
                    break;
            }
            return supported;
        }
        #endregion

        #region New FP3035 Product Series
        public static bool IsProductSupportedFP3035(int ProductID)
        {
            bool supported = false;
            switch (ProductID)
            {
                //New FP3035 Product Series 3035T-24/3035T-5 SP
                case ClassList.CommonConstants.PRODUCT_FP3035T_24:
                case ClassList.CommonConstants.PRODUCT_FP3035T_5:
                //New_Product_Addition_OIS24/OIS_25 Vijay
                case ClassList.CommonConstants.PRODUCT_OIS24:
                case ClassList.CommonConstants.PRODUCT_OIS25:
                    //End
                    //End
                    supported = true;
                    break;
            }
            return supported;
        }
        public static bool IsProductCompatibleWithFP3035(int ProductID)
        {
            bool supported = false;
            switch (ProductID)
            {
                //New FP3035 Product Series 3035T-24/3035T-5 SP
                case ClassList.CommonConstants.PRODUCT_FP3035T_24:
                case ClassList.CommonConstants.PRODUCT_FP3035T_5:
                //New_Product_Addition_OIS24/OIS_25 Vijay
                case ClassList.CommonConstants.PRODUCT_OIS24:
                case ClassList.CommonConstants.PRODUCT_OIS25:
                    //End
                    //End
                    supported = true;
                    break;
            }
            return supported;
        }
        #endregion

        #region FL005-MicroPLC Base Module Series Vijay
        public static bool IsProductFL005MicroPLCBase(int ProductID)
        {
            bool supported = false;
            switch (ProductID)
            {
                //Remove_Product Vijay
                //case ClassList.CommonConstants.PRODUCT_FL005_0604RP:
                //case ClassList.CommonConstants.PRODUCT_FL005_0604RP0201L:
                //
                case ClassList.CommonConstants.PRODUCT_FL005_0808RP:
                case ClassList.CommonConstants.PRODUCT_FL005_0808RP0201L:
                //FL005-MicroPLC Base Module Series Vijay1
                case ClassList.CommonConstants.PRODUCT_FL005_0604P:
                case ClassList.CommonConstants.PRODUCT_FL005_0808P:
                case ClassList.CommonConstants.PRODUCT_FL005_0808P0201L:
                case ClassList.CommonConstants.PRODUCT_FL005_0604N:
                case ClassList.CommonConstants.PRODUCT_FL005_0808N:
                case ClassList.CommonConstants.PRODUCT_FL005_0808N0201L:
                case ClassList.CommonConstants.PRODUCT_GPU110_3S: //New_Product_Addition Vijay(15.05.2014)
                case ClassList.CommonConstants.PRODUCT_GPU105_3S://New_Product_Addition Parag(9.12.2014)
                case ClassList.CommonConstants.PRODUCT_GPU120_3S://New_Product_Addition Parag(9.12.2014)
                case ClassList.CommonConstants.PRODUCT_GPU122_3S: //New_Product_Addition Vijay(07.04.2015)
                case ClassList.CommonConstants.PRODUCT_FL005_1616P0201L_S1://New FL005 Product Addition Suyash
                #region PLC_Direct Vijay
                case CommonConstants.PRODUCT_CPU_111_RP:
                case CommonConstants.PRODUCT_CPU_120_ARP:
                case CommonConstants.PRODUCT_CPU_100_P:
                case CommonConstants.PRODUCT_CPU_110_P:
                case CommonConstants.PRODUCT_CPU_120_AP:
                case CommonConstants.PRODUCT_CPU_100_N:
                case CommonConstants.PRODUCT_CPU_110_N:
                case CommonConstants.PRODUCT_CPU_120_AN:
                #endregion
                #region FL005 Expandable PLC Series Vijay
                case ClassList.CommonConstants.PRODUCT_FL005_0808RP0402U:
                case ClassList.CommonConstants.PRODUCT_FL005_1616RP0201L:
                case ClassList.CommonConstants.PRODUCT_FL005_1616P0201L:
                case ClassList.CommonConstants.PRODUCT_FL005_1616N0201L:
                case ClassList.CommonConstants.PRODUCT_FL005_1616RP:
                case ClassList.CommonConstants.PRODUCT_FL005_1616P:
                #endregion
                case ClassList.CommonConstants.PRODUCT_FL055://FL055_Product_Addition_Suyash
                case ClassList.CommonConstants.PRODUCT_FL050_V2: //24.10.2016_Vijay
                #region Hitachi Hi-Rel Vijay
                case CommonConstants.PRODUCT_HH5L_B0604D_P:
                case CommonConstants.PRODUCT_HH5L_B0808D_P:
                case CommonConstants.PRODUCT_HH5L_B1616D_P:
                case CommonConstants.PRODUCT_HH5L_B1616D_RP:
                case CommonConstants.PRODUCT_HH5L_B0201A0808D_P:
                case CommonConstants.PRODUCT_HH5L_B0201A1616D_RP:
                case CommonConstants.PRODUCT_HH5L_B0402AU0808D_RP:
                #endregion
                    //End
                    supported = true;
                    break;
            }
            return supported;
        }
        public static bool IsProductFL005_Series(int ProductID)
        {
            bool supported = false;
            switch (ProductID)
            {

                case ClassList.CommonConstants.PRODUCT_FL005_0808RP:
                case ClassList.CommonConstants.PRODUCT_FL005_0808RP0201L:
                //FL005-MicroPLC Base Module Series Vijay1
                case ClassList.CommonConstants.PRODUCT_FL005_0604P:
                case ClassList.CommonConstants.PRODUCT_FL005_0808P:
                case ClassList.CommonConstants.PRODUCT_FL005_0808P0201L:
                case ClassList.CommonConstants.PRODUCT_FL005_0604N:
                case ClassList.CommonConstants.PRODUCT_FL005_0808N:
                case ClassList.CommonConstants.PRODUCT_FL005_0808N0201L:
                case ClassList.CommonConstants.PRODUCT_GPU110_3S: //New_Product_Addition Vijay(15.05.2014)
                case ClassList.CommonConstants.PRODUCT_GPU105_3S://New_Product_Addition Parag(9.12.2014)
                case ClassList.CommonConstants.PRODUCT_GPU120_3S://New_Product_Addition Parag(9.12.2014)
                case ClassList.CommonConstants.PRODUCT_GPU122_3S: //New_Product_Addition Vijay(07.04.2015)
                case ClassList.CommonConstants.PRODUCT_FL005_1616P0201L_S1://New FL005 Product Addition Suyash
                #region PLC_Direct Vijay
                case CommonConstants.PRODUCT_CPU_111_RP:
                case CommonConstants.PRODUCT_CPU_120_ARP:
                case CommonConstants.PRODUCT_CPU_100_P:
                case CommonConstants.PRODUCT_CPU_110_P:
                case CommonConstants.PRODUCT_CPU_120_AP:
                case CommonConstants.PRODUCT_CPU_100_N:
                case CommonConstants.PRODUCT_CPU_110_N:
                case CommonConstants.PRODUCT_CPU_120_AN:
                #endregion
                #region FL005 Expandable PLC Series Vijay
                case ClassList.CommonConstants.PRODUCT_FL005_0808RP0402U:
                case ClassList.CommonConstants.PRODUCT_FL005_1616RP0201L:
                case ClassList.CommonConstants.PRODUCT_FL005_1616P0201L:
                case ClassList.CommonConstants.PRODUCT_FL005_1616N0201L:
                case ClassList.CommonConstants.PRODUCT_FL005_1616RP:
                case ClassList.CommonConstants.PRODUCT_FL005_1616P:
                #endregion

                #region Hitachi Hi-Rel Vijay
                case CommonConstants.PRODUCT_HH5L_B0604D_P:
                case CommonConstants.PRODUCT_HH5L_B0808D_P:
                case CommonConstants.PRODUCT_HH5L_B1616D_P:
                case CommonConstants.PRODUCT_HH5L_B1616D_RP:
                case CommonConstants.PRODUCT_HH5L_B0201A0808D_P:
                case CommonConstants.PRODUCT_HH5L_B0201A1616D_RP:
                case CommonConstants.PRODUCT_HH5L_B0402AU0808D_RP:
                #endregion
                    //End
                    supported = true;
                    break;
            }
            return supported;
        }
        #endregion

        #region FL005-MicroPLC Base Module Series Vijay1
        public static bool IsProductSupportStringDataType(int ProductID)
        {
            if (ClassList.CommonConstants.g_Support_IEC_Ladder)
            {
                if (ClassList.CommonConstants.IsProductMX257_Based(ProductID))
                {
                    return true;
                }
                else if (ClassList.CommonConstants.IsProductMXSpecialCase_OldModel(ProductID)) //SS_FL100S0
                {
                    return true;
                }
                else if (ClassList.CommonConstants.IsProductFL005MicroPLCBase(ProductID))
                {
                    return true;
                }
                //New Product FL050 V2 SammedB
                else if (ProductID == ClassList.CommonConstants.PRODUCT_FL050_V2)
                {
                    return true;
                }
                #region GWY_910_Suyash1
                else if (ClassList.CommonConstants.ProductDataInfo.iProductID == CommonConstants.PRODUCT_GSM910)
                {
                    return true;
                }
                #endregion
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region //Support_LREAL_SY
        public static bool ProductsupportLREL(int ProductID)
        {
            //return false;
            bool retValue = false;
            switch (ProductID)
            {
                case ClassList.CommonConstants.PRODUCT_FP3043T:
                case ClassList.CommonConstants.PRODUCT_FP3043TN://OIS43E Plus
                case ClassList.CommonConstants.PRODUCT_FP3043T_E:
                case ClassList.CommonConstants.PRODUCT_FP3043TN_E:
                case ClassList.CommonConstants.PRODUCT_OIS43E_Plus:
                case ClassList.CommonConstants.PRODUCT_FP3070T:
                case ClassList.CommonConstants.PRODUCT_FP3070TN://OIS72E Plus
                case ClassList.CommonConstants.PRODUCT_FP3070T_E:
                case ClassList.CommonConstants.PRODUCT_FP3070TN_E:
                case ClassList.CommonConstants.PRODUCT_OIS72E_Plus:
                case ClassList.CommonConstants.PRODUCT_FP3102T:
                case ClassList.CommonConstants.PRODUCT_FP3102TN://OIS100E Plus
                case ClassList.CommonConstants.PRODUCT_FP3102T_E:
                case ClassList.CommonConstants.PRODUCT_FP3102TN_E:


                #region Hitachi Hi-Rel Vijay
                case ClassList.CommonConstants.PRODUCT_HH5P_H43_NS:
                case ClassList.CommonConstants.PRODUCT_HH5P_H43_S:
                case ClassList.CommonConstants.PRODUCT_HH5P_H70_NS:
                case ClassList.CommonConstants.PRODUCT_HH5P_H70_S:
                case ClassList.CommonConstants.PRODUCT_HH5P_H100_NS:
                case ClassList.CommonConstants.PRODUCT_HH5P_H100_S:
                case ClassList.CommonConstants.PRODUCT_HH5P_HP43_NS:
                case ClassList.CommonConstants.PRODUCT_HH5P_HP70_NS:
                case ClassList.CommonConstants.PRODUCT_HH1L_000:
                #endregion

                case ClassList.CommonConstants.PRODUCT_FP5043T:
                case ClassList.CommonConstants.PRODUCT_FP5043TN://OIS45 Plus 
                case ClassList.CommonConstants.PRODUCT_OIS45_Plus:
                case ClassList.CommonConstants.PRODUCT_FP5070T:
                case ClassList.CommonConstants.PRODUCT_FP5070TN://OIS70 Plus
                case ClassList.CommonConstants.PRODUCT_OIS70_Plus:
                case ClassList.CommonConstants.PRODUCT_FP5121T:
                case ClassList.CommonConstants.PRODUCT_FP5121TN://OIS120A   
                case ClassList.CommonConstants.PRODUCT_OIS120A:
                case ClassList.CommonConstants.PRODUCT_FL100:
                case ClassList.CommonConstants.PRODUCT_FP5043TN_E:
                case ClassList.CommonConstants.PRODUCT_OIS45E_Plus:
                case ClassList.CommonConstants.PRODUCT_TRPMIU0400E:
                case ClassList.CommonConstants.PRODUCT_HMC7043A_M:
                case ClassList.CommonConstants.PRODUCT_FP5043T_E:
                case ClassList.CommonConstants.PRODUCT_FP5070TN_E:
                case ClassList.CommonConstants.PRODUCT_OIS70E_Plus:
                case ClassList.CommonConstants.PRODUCT_TRPMIU0700E:
                case ClassList.CommonConstants.PRODUCT_HMC7070A_M:
                case ClassList.CommonConstants.PRODUCT_FP5070T_E:

                    //case ClassList.CommonConstants.PRODUCT_GSM910://As perdiscussion with PrashantK,Rishi&UP sir to  support



                    retValue = true;
                    break;
            }
            return retValue;
        }
        #endregion

        #region FL005 Expandable PLC Series Vijay
        public static bool IsProductFL005ExpandablePLCSeries(int ProductID)
        {
            bool supported = false;
            switch (ProductID)
            {
                case ClassList.CommonConstants.PRODUCT_FL005_0808RP0402U:
                case ClassList.CommonConstants.PRODUCT_FL005_1616RP0201L:
                case ClassList.CommonConstants.PRODUCT_FL005_1616P0201L:
                case ClassList.CommonConstants.PRODUCT_FL005_1616N0201L:
                case ClassList.CommonConstants.PRODUCT_FL005_1616RP:
                case ClassList.CommonConstants.PRODUCT_FL005_1616P:
                case ClassList.CommonConstants.PRODUCT_FL005_1616P0201L_S1:
                case ClassList.CommonConstants.PRODUCT_GPU120_3S://New_Product_Addition Parag(9.12.2014)
                case ClassList.CommonConstants.PRODUCT_GPU122_3S: //New_Product_Addition Vijay(07.04.2015)
                case ClassList.CommonConstants.PRODUCT_FL055://FL055_Product_Addition_Suyash
                case ClassList.CommonConstants.PRODUCT_FL050_V2: //24.10.2016_Vijay
                #region Hitachi Hi-Rel Vijay
                case ClassList.CommonConstants.PRODUCT_HH5L_B1616D_P:
                case ClassList.CommonConstants.PRODUCT_HH5L_B1616D_RP:
                case ClassList.CommonConstants.PRODUCT_HH5L_B0201A1616D_RP:
                case ClassList.CommonConstants.PRODUCT_HH5L_B0402AU0808D_RP:
                #endregion
                #region Maple_ProductAddition_Vijay
                case ClassList.CommonConstants.PRODUCT_MLC2_E0404P0802T:
                case ClassList.CommonConstants.PRODUCT_MLC1_F1616P0201:
                case ClassList.CommonConstants.PRODUCT_MLC1_E1616P:
                case ClassList.CommonConstants.PRODUCT_MLC1_E1616Y:
                case ClassList.CommonConstants.PRODUCT_MLC1_E0808Y0402T:
                case ClassList.CommonConstants.PRODUCT_MLC1_E1616P0201:
                case ClassList.CommonConstants.PRODUCT_MLC1_E1616N0201:
                case ClassList.CommonConstants.PRODUCT_MLC1_E1616Y0201:
                #endregion
                    supported = true;
                    break;
            }
            return supported;
        }
        #endregion
        #region HardwareVersion_RemoveForPLC Vijay
        public static bool HardwareVersion_AvailableForPLC(int ProductID)
        {
            bool supported = false;
            switch (ProductID)
            {
                case ClassList.CommonConstants.PRODUCT_FL010:
                case ClassList.CommonConstants.PRODUCT_FL050:
                case ClassList.CommonConstants.PRODUCT_GPU288_3S:
                case ClassList.CommonConstants.PRODUCT_GPU200_3S:
                case ClassList.CommonConstants.PRODUCT_MICRO_PLC:
                case ClassList.CommonConstants.PRODUCT_MICRO_PLC_ETHERNET:
                case ClassList.CommonConstants.PRODUCT_PLC7008A_ML:
                case ClassList.CommonConstants.PRODUCT_PLC7008A_ME:
                    supported = true;
                    break;
            }
            return supported;
        }
        #endregion
        #region Hitachi Hi-Rel Vijay
        public static bool IsProductSupportHHInvertersProtocol(int ProductID)
        {
            bool supported = false;
            switch (ProductID)
            {
                case ClassList.CommonConstants.PRODUCT_HH1L_000:
                case ClassList.CommonConstants.PRODUCT_HH5L_B0201A0808D_P:
                case ClassList.CommonConstants.PRODUCT_HH5L_B0201A1616D_RP:
                case ClassList.CommonConstants.PRODUCT_HH5L_B0402AU0808D_RP:
                case ClassList.CommonConstants.PRODUCT_HH5L_B0604D_P:
                case ClassList.CommonConstants.PRODUCT_HH5L_B0808D_P:
                case ClassList.CommonConstants.PRODUCT_HH5L_B1616D_P:
                case ClassList.CommonConstants.PRODUCT_HH5L_B1616D_RP:
                case ClassList.CommonConstants.PRODUCT_HH5P_H100_NS:
                case ClassList.CommonConstants.PRODUCT_HH5P_H100_S:
                case ClassList.CommonConstants.PRODUCT_HH5P_H43_NS:
                case ClassList.CommonConstants.PRODUCT_HH5P_H43_S:
                case ClassList.CommonConstants.PRODUCT_HH5P_H70_NS:
                case ClassList.CommonConstants.PRODUCT_HH5P_H70_S:
                case ClassList.CommonConstants.PRODUCT_HH5P_HP200808D_P:
                case ClassList.CommonConstants.PRODUCT_HH5P_HP301208D_R:
                case ClassList.CommonConstants.PRODUCT_HH5P_HP300201U0808_RP:
                case ClassList.CommonConstants.PRODUCT_HH5P_HP300201L0808_RP:
                case ClassList.CommonConstants.PRODUCT_HH5P_HP43_NS:
                case ClassList.CommonConstants.PRODUCT_HH5P_HP70_NS:
                    supported = true;
                    break;
            }
            return supported;
        }
        #endregion
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct StratonTagStructure
        {
            public byte _blockType;// 0-Global, 1-Retentive, 2-Local
            public string _initalValue;
            public byte _dataType;
            public byte _stringLength;
            public byte _IsExpansionTag;
            public byte _IsRetentiveRegister;
            public byte _reserved5;
            #region ss_StratonSysExpTagFormat
            public byte _IsSystemTag;
            public byte _slotNo;//For expansion tags
            public string _nativePrefix;//only applicable to Expansion and System tags (e.g. X,Y,XW,YW,MW,S,SW)
            public string _nativeAddrVal;//Exp:Register Address value e.g. 007, Sys:Tag value
            public string _nativeAddress;//complete native tag address
            #endregion
            public string _Dimension; //Array_change
            public string _ArrTagInfo;
            #region Structure_SY
            public string _StructureName;
            public string _StructureObjName;
            #endregion
        }
        #region Tag DataType Sanjay
        public static int GetstratonDataTypeByte(string _StratonDataType, ref int dataTypebyte)
        {


            if (Convert.ToString(_StratonDataType) == "BOOL" || Convert.ToString(_StratonDataType) == "BYTE" || Convert.ToString(_StratonDataType) == "SINT" || Convert.ToString(_StratonDataType) == "USINT")
            {
                dataTypebyte = 1;
            }
            else if (Convert.ToString(_StratonDataType) == "INT" || Convert.ToString(_StratonDataType) == "UINT" || Convert.ToString(_StratonDataType) == "WORD")
            {
                dataTypebyte = 2;
            }
            else if (Convert.ToString(_StratonDataType) == "LREAL")
            {
                dataTypebyte = 8;
            }
            else if (Convert.ToString(_StratonDataType) == "DINT" || Convert.ToString(_StratonDataType) == "DWORD" || Convert.ToString(_StratonDataType) == "UDINT" || Convert.ToString(_StratonDataType) == "REAL" || Convert.ToString(_StratonDataType) == "TIME")//Issue no.56
            {
                dataTypebyte = 4;
            }
            else if (Convert.ToString(_StratonDataType) == "STRING")
            {

            }
            //_stDatatype = dataTypebyte;
            return dataTypebyte;
        }
        #endregion
        #endregion

        #region Suyash_FP3020MR_L1608RP_Prod_Addition
        public static bool IsProductSupportedFP3020series(int ProductID)
        {
            bool supported = false;
            switch (ProductID)
            {

                case CommonConstants.PRODUCT_FP3020MR_L1608RP:

                    supported = true;
                    break;
            }
            return supported;
        }
        #endregion
        #region New FP3series product Addition Suyash
        public static bool IsProductSupportedFP3series(int ProductID)
        {
            bool supported = false;
            switch (ProductID)
            {
                case ClassList.CommonConstants.PRODUCT_FP3043T://New FP3043T product Addition Suyash
                case ClassList.CommonConstants.PRODUCT_FP3043TN://New FP3043TN product Addition Suyash
                case ClassList.CommonConstants.PRODUCT_FP3070T://New FP3070T product Addition Suyash
                case ClassList.CommonConstants.PRODUCT_FP3070TN://New FP3070TN product Addition Suyash
                case ClassList.CommonConstants.PRODUCT_FP3102T://New FP3102T product Addition Suyash
                case ClassList.CommonConstants.PRODUCT_FP3102TN://New FP3102TN product Addition Suyash

                #region SY-FP3_PlugableIO_Product_addition
                case ClassList.CommonConstants.PRODUCT_FP3070T_E:
                case ClassList.CommonConstants.PRODUCT_FP3070TN_E:
                case ClassList.CommonConstants.PRODUCT_FP3102T_E:
                case ClassList.CommonConstants.PRODUCT_FP3102TN_E:
                #endregion
                #region FP3043_ExpansionSeries Vijay
                case ClassList.CommonConstants.PRODUCT_FP3043T_E:
                case ClassList.CommonConstants.PRODUCT_FP3043TN_E:
                #endregion
                #region Hitachi Hi-Rel Vijay
                case CommonConstants.PRODUCT_HH5P_H43_NS:
                case CommonConstants.PRODUCT_HH5P_H43_S:
                case CommonConstants.PRODUCT_HH5P_H70_NS:
                case CommonConstants.PRODUCT_HH5P_H70_S:
                case CommonConstants.PRODUCT_HH5P_H100_NS:
                case CommonConstants.PRODUCT_HH5P_H100_S:
                #endregion
                #region OIS3Series_Vijay
                case ClassList.CommonConstants.PRODUCT_OIS43E_Plus:
                case ClassList.CommonConstants.PRODUCT_OIS72E_Plus:
                case ClassList.CommonConstants.PRODUCT_OIS100E_Plus:
                #endregion
                #region Panasonic sammed 2.0
                case ClassList.CommonConstants.PRODUCT_GTXL07N:
                case ClassList.CommonConstants.PRODUCT_GTXL10N:
                #endregion
                    supported = true;
                    break;
            }
            return supported;
        }
        #endregion

        public static bool IsProductSupports_ExpansionPort(int ProductID)
        {
            bool supported = false;
            switch (ProductID)
            {
                case ClassList.CommonConstants.PRODUCT_MICRO_PLC:
                case ClassList.CommonConstants.PRODUCT_MICRO_PLC_ETHERNET:
                #region New PLC Models AMIT
                case ClassList.CommonConstants.PRODUCT_FL010:
                #endregion
                case ClassList.CommonConstants.PRODUCT_FL011_S3:
                case ClassList.CommonConstants.PRODUCT_PLC7008A_ML:
                //  case ClassList.CommonConstants.PRODUCT_FL011_S1:
                //  case ClassList.CommonConstants.PRODUCT_FL011:
                case ClassList.CommonConstants.PRODUCT_FL050:
                case ClassList.CommonConstants.PRODUCT_FL050_V2://New Product FL050 V2 SammedB
                case ClassList.CommonConstants.PRODUCT_FL055://FL055_Product_Addition_Suyash
                //case ClassList.CommonConstants.PRODUCT_FL051: //Remove_Product Vijay(06.02.14)
                #region New FL100 Model SAMMED
                case ClassList.CommonConstants.PRODUCT_FL100:
                #endregion
                #region FL005 Expandable PLC Series Vijay
                case ClassList.CommonConstants.PRODUCT_FL005_0808RP0402U:
                case ClassList.CommonConstants.PRODUCT_FL005_1616RP0201L:
                case ClassList.CommonConstants.PRODUCT_FL005_1616P0201L:
                case ClassList.CommonConstants.PRODUCT_FL005_1616N0201L:
                case ClassList.CommonConstants.PRODUCT_FL005_1616RP:
                case ClassList.CommonConstants.PRODUCT_FL005_1616P:
                case ClassList.CommonConstants.PRODUCT_FL005_1616P0201L_S1:
                #endregion
                #region Hitachi Hi-Rel Vijay
                case ClassList.CommonConstants.PRODUCT_HH5L_B1616D_P:
                case ClassList.CommonConstants.PRODUCT_HH5L_B1616D_RP:
                case ClassList.CommonConstants.PRODUCT_HH5L_B0201A1616D_RP:
                case ClassList.CommonConstants.PRODUCT_HH5L_B0402AU0808D_RP:
                case ClassList.CommonConstants.PRODUCT_HH1L_000:
                case ClassList.CommonConstants.PRODUCT_HH5P_HP43_NS:
                case ClassList.CommonConstants.PRODUCT_HH5P_HP70_NS:
                #endregion
                #region ToshibaUS PLC Models
                case ClassList.CommonConstants.PRODUCT_GPU288_3S:
                case ClassList.CommonConstants.PRODUCT_GPU200_3S:
                case ClassList.CommonConstants.PRODUCT_GPU230_3S: //New_Product_Addition Vijay(01.03.2013)
                #endregion
                //case ClassList.CommonConstants.PRODUCT_FP4084TN_E: //New Product Addition FP4030MT-L0808RP-A0201-S0 Vijay
                case ClassList.CommonConstants.PRODUCT_FP4030MR_E:
                //case ClassList.CommonConstants.PRODUCT_FP4030MN_E://New_Product_Addition M&R AMIT
                case ClassList.CommonConstants.PRODUCT_FP4035T_E:
                #region New_Ethernet_Products_AMIT
                case ClassList.CommonConstants.PRODUCT_FP4035TN_E:
                case ClassList.CommonConstants.PRODUCT_FP4057TN_E:
                #endregion
                //case ClassList.CommonConstants.PRODUCT_FP4057M_E:
                case ClassList.CommonConstants.PRODUCT_FP4057T_E:
                #region New_Product_Addition_AllBodySoltn AMIT
                case ClassList.CommonConstants.PRODUCT_FP4057T_E_S1:
                #endregion
                #region New_Product_Addition_Vertical Vijay
                case ClassList.CommonConstants.PRODUCT_FP4057T_E_VERTICAL:
                #endregion
                case ClassList.CommonConstants.PRODUCT_TRPMIU0300A:
                case ClassList.CommonConstants.PRODUCT_TRPMIU0500A:
                case ClassList.CommonConstants.PRODUCT_FH9030MR_E:
                case ClassList.CommonConstants.PRODUCT_FH9035T_E:
                case ClassList.CommonConstants.PRODUCT_FH9057T_E:
                #region New FP Models-43&70 SnehalM
                case ClassList.CommonConstants.PRODUCT_FP5043T_E:
                case ClassList.CommonConstants.PRODUCT_FP5043TN_E:
                case ClassList.CommonConstants.PRODUCT_FP5070T_E:
                case ClassList.CommonConstants.PRODUCT_FP5070TN_E:
                #endregion
                case ClassList.CommonConstants.PRODUCT_FP5070T_E_S2://New FP5070T-E-S2 product Addition Suyash
                #region Toshiba US products SnehalM
                case ClassList.CommonConstants.PRODUCT_OIS22_Plus:
                case ClassList.CommonConstants.PRODUCT_OIS55_Plus:
                case ClassList.CommonConstants.PRODUCT_OIS60_Plus:
                case ClassList.CommonConstants.PRODUCT_OIS45E_Plus:
                case ClassList.CommonConstants.PRODUCT_OIS70E_Plus:
                case ClassList.CommonConstants.PRODUCT_GPU120_3S: //New_Product_Addition Parag(9.12.2014)
                case ClassList.CommonConstants.PRODUCT_GPU122_3S: //New_Product_Addition Vijay(07.04.2015)
                #endregion
                case ClassList.CommonConstants.PRODUCT_HMC7030A_M:
                case ClassList.CommonConstants.PRODUCT_HMC7035A_M:
                case ClassList.CommonConstants.PRODUCT_HMC7057A_M:
                case ClassList.CommonConstants.PRODUCT_PLC7008A_ME:
                #region //Mapple Customization 2.0_Sanjay
                case ClassList.CommonConstants.PRODUCT_HMC7043A_M:
                case ClassList.CommonConstants.PRODUCT_HMC7070A_M:
                #endregion

                //New Ethernet Models - SnehaK
                case CommonConstants.PRODUCT_TRPMIU0300E:
                case CommonConstants.PRODUCT_TRPMIU0500E:
                //End
                //Toshiba-Japan_Product
                case CommonConstants.PRODUCT_TRPMIU0400E:
                case CommonConstants.PRODUCT_TRPMIU0700E:
                #region PLC_Direct Vijay
                case ClassList.CommonConstants.PRODUCT_CPU_300:
                #endregion
                //End
                #region FP3043_ExpansionSeries Vijay
                case CommonConstants.PRODUCT_FP3043T_E:
                case CommonConstants.PRODUCT_FP3043TN_E:
                #endregion
                #region SY-FP3_PlugableIO_Product_addition
                case CommonConstants.PRODUCT_FP3070T_E:
                case CommonConstants.PRODUCT_FP3070TN_E:
                case CommonConstants.PRODUCT_FP3102T_E:
                case CommonConstants.PRODUCT_FP3102TN_E:
                #endregion
                    supported = true;
                    break;
            }

            return supported;
        }

        public static bool IsProductSupports_LocalIO(int ProductID)
        {

            bool retValue = false;
            switch (ProductID)
            {
                case CommonConstants.PRODUCT_FP3020MR_L1608RP://Suyash_FP3020MR_L1608RP_Prod_Addition
                case CommonConstants.PRODUCT_FP4020MR_L0808P:
                case CommonConstants.PRODUCT_FP4020MR_L0808N:
                case CommonConstants.PRODUCT_FP4020MR_L0808R:
                #region New_Product_Addition Vijay
                case CommonConstants.PRODUCT_FP4020MR_L0808R_S3:
                #endregion
                case CommonConstants.PRODUCT_FP4030MR_L1208R:
                case CommonConstants.PRODUCT_HMC7030A_L:
                case CommonConstants.PRODUCT_FP4030MR_0808R_A0400_S0://PRODUCT_FP4030MR_0808R_A0400_S0_addition_sammed
                case CommonConstants.PRODUCT_FP4030MR_L1210RP_A0402U: //PRODUCT_FP4030MR_L1210RP_A0402U Vijay
                case CommonConstants.PRODUCT_FP4030MR_L1210P_A0402U:  //PRODUCT_FP4030MR_L1210P_A0402U Vijay
                case CommonConstants.PRODUCT_FP4030MR_L1210RP://PRODUCT_FP4030MR_L1210RP Suyash
                case CommonConstants.PRODUCT_FP4030MR_L1210P://PRODUCT_FP4030MR_L1210P Suyash
                case CommonConstants.PRODUCT_FP4030MR_L0808R_A0400U: //PRODUCT_FP4030MR_L0808R_A0400U Vijay
                #region Toshiba US products SnehalM
                case CommonConstants.PRODUCT_OIS10_Plus:
                case CommonConstants.PRODUCT_OIS20_Plus:
                //IO Allocation to Base
                case CommonConstants.PRODUCT_OIS42_Plus:
                case CommonConstants.PRODUCT_OIS42L_Plus:
                case CommonConstants.PRODUCT_FP4030MT_L0808P:
                case CommonConstants.PRODUCT_FP4030MT_L0808P_A0201U:
                case CommonConstants.PRODUCT_FP4030MT_L0808P_A0402L://Suyash_Product_Addition_FP4030MT_L0808P_A0402L
                case CommonConstants.PRODUCT_FP4030MT_L0808RN:
                case CommonConstants.PRODUCT_FP4030MT_L0808RN_A0201:
                case CommonConstants.PRODUCT_FP4030MT_L0808RN_A0201_VERTICAL:
                case CommonConstants.PRODUCT_FP4030MT_L0808RN_VERTICAL:
                case CommonConstants.PRODUCT_FP4030MT_L0808RP:
                case CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201:
                case CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201_S0:
                case CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201_VERTICAL:
                case CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201L:
                case CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201L_VERTICAL:
                case CommonConstants.PRODUCT_FP4030MT_L0808RP_VERTICAL:
                case CommonConstants.PRODUCT_FP2020_L0808RP_A0401L: //2020_Series_Vijay
                case CommonConstants.PRODUCT_FP2020_L0808P_A0401L:
                case CommonConstants.PRODUCT_FP2020_L0604P_A0401L:
                //
                #endregion
                #region Hitachi Hi-Rel Vijay
                case CommonConstants.PRODUCT_HH5P_HP200808D_P:
                case CommonConstants.PRODUCT_HH5P_HP301208D_R:
                case CommonConstants.PRODUCT_HH5P_HP300201U0808_RP:
                case CommonConstants.PRODUCT_HH5P_HP300201L0808_RP:
                #endregion
                    retValue = true;
                    break;
            }


            return retValue;



        }
        public static bool IsProductSupports_RetainHSCounter(int ProductID)
        {

            bool retValue = false;
            if (IsProductSupports_LocalIO(ProductID))
                retValue = true;
            else
            {
                switch (ProductID)
                {

                    case CommonConstants.PRODUCT_FL010:
                    case CommonConstants.PRODUCT_PLC7008A_ML:
                    case CommonConstants.PRODUCT_FL011_S1:
                    case CommonConstants.PRODUCT_FL011_S4: //New_ProductAdd_Vijay
                    case CommonConstants.PRODUCT_FL011:
                    //case CommonConstants.PRODUCT_FL051: //Remove_Product Vijay(06.02.14)
                    #region ToshibaUS PLC Models
                    case ClassList.CommonConstants.PRODUCT_GPU288_3S:
                    case ClassList.CommonConstants.PRODUCT_GPU232_3S:
                    #endregion
                    #region New PLC Models AMIT
                    case CommonConstants.PRODUCT_FL011_S3:
                    #endregion
                        #region FL005_Changes(28.02.14) Vijay
                        //#region FL005-MicroPLC Base Module Series Vijay
                        //Remove_Product Vijay
                        //case ClassList.CommonConstants.PRODUCT_FL005_0604RP:
                        //case ClassList.CommonConstants.PRODUCT_FL005_0604RP0201L:
                        //
                        //case ClassList.CommonConstants.PRODUCT_FL005_0808RP:
                        //case ClassList.CommonConstants.PRODUCT_FL005_0808RP0201L:
                        //FL005-MicroPLC Base Module Series Vijay1
                        //case ClassList.CommonConstants.PRODUCT_FL005_0604P:
                        //case ClassList.CommonConstants.PRODUCT_FL005_0808P:
                        //case ClassList.CommonConstants.PRODUCT_FL005_0808P0201L:
                        //case ClassList.CommonConstants.PRODUCT_FL005_0604N:
                        //case ClassList.CommonConstants.PRODUCT_FL005_0808N:
                        //case ClassList.CommonConstants.PRODUCT_FL005_0808N0201L:
                        //End
                        //#endregion
                        #endregion
                        retValue = true;
                        break;
                }
            }



            return retValue;



        }
        public static string GetDeviceRangesXMLFileName(int ProductID)
        {
            //String strFileName= "PrizmUnit.xml";
            String strFileName = ClassList.CommonConstants.ProjectUnitXmlFile;//Maple Customization Changes
            if (IsProductPLC(ProductID) && ClassList.CommonConstants.g_Support_IEC_Ladder == false)//FL100_Change_Sammed
                strFileName = "MicropLC.xml";
            else if (IsProductIsTextBased(ProductID) || IsProductIsTextAndGraphicsBased(ProductID))
            {
                //strFileName = "PrizmUnitLPC.xml";
                //  strFileName = ClassList.CommonConstants.ProjectUnitLPCFile;//Maple Customization Changes
                #region KPCL_Change Vijay
                if (ProductID == ClassList.CommonConstants.PRODUCT_FP4030MR_0808R_A0400_S0 || ProductID == ClassList.CommonConstants.PRODUCT_FP4030MR_L0808R_A0400U) //PRODUCT_FP4030MR_L0808R_A0400U Vijay
                {
                    //strFileName = "PrizmUnit.xml";
                    strFileName = ClassList.CommonConstants.ProjectUnitXmlFile;
                }
                #region Suyash_FP3020MR_L1608RP_Prod_Addition
                else if (ProductID == ClassList.CommonConstants.PRODUCT_FP3020MR_L1608RP)
                {
                    strFileName = ClassList.CommonConstants.ProjectUnitXmlFile;
                }
                #endregion
                else
                {
                    //strFileName = "PrizmUnitLPC.xml";
                    #region 2020_Series_Vijay
                    if (ProductID == ClassList.CommonConstants.PRODUCT_FP2020_L0808RP_A0401L ||
                        ProductID == ClassList.CommonConstants.PRODUCT_FP2020_L0808P_A0401L ||
                        ProductID == ClassList.CommonConstants.PRODUCT_FP2020_L0604P_A0401L)
                        strFileName = "PrizmUnitLPC20XX.xml";
                    else
                        strFileName = ClassList.CommonConstants.ProjectUnitLPCFile;//Maple Customization Changes
                    #endregion
                }
                #endregion
            }
            else
            {
                //Sammed new XML added for 32k Retentive tag range
                if (IsProductSupportedFP3series(ProductID))//Haresh Sir As discuss with Alankar need to modify for 3043,3070,3102
                {
                    strFileName = "PrizmUnit3XX.xml";
                }
                else ///end
                {
                    strFileName = ClassList.CommonConstants.ProjectUnitXmlFile;//Maple Customization Changes
                }
            }
            return strFileName;
        }
        public static bool IsToshiba_FlexiProduct(int ProdutID)
        {
            bool retValue = false;
            switch (ProdutID)
            {

                case CommonConstants.PRODUCT_TRPMIU0300L:
                case CommonConstants.PRODUCT_TRPMIU0300A:
                case CommonConstants.PRODUCT_TRPMIU0500L:
                case CommonConstants.PRODUCT_TRPMIU0500A:

                case CommonConstants.PRODUCT_HMC7035A_M:
                case CommonConstants.PRODUCT_HMC7057A_M:
                #region //Mapple Customization 2.0_Sanjay
                case CommonConstants.PRODUCT_HMC7043A_M:
                case CommonConstants.PRODUCT_HMC7070A_M:
                #endregion

                    retValue = true;
                    break;
            }
            return retValue;
        }
        public static bool IsKaspro_FlexiProduct(int ProdutID)
        {
            bool retValue = false;
            switch (ProdutID)
            {

                case CommonConstants.PRODUCT_FH9035T:
                case CommonConstants.PRODUCT_FH9035T_E:
                case CommonConstants.PRODUCT_FH9057T:
                case CommonConstants.PRODUCT_FH9057T_E:

                    retValue = true;
                    break;
            }
            return retValue;
        }

        public static bool IsProductWithLocalIO()//ss_Slot0Expansion
        {
            if (CommonConstants.ProductIdentifier == CommonConstants.PRODUCT_FP4030MT_L0808RN_A0201 || CommonConstants.ProductIdentifier == CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201
              || CommonConstants.ProductIdentifier == CommonConstants.PRODUCT_FP4030MT_L0808RN || CommonConstants.ProductIdentifier == CommonConstants.PRODUCT_FP4030MT_L0808RP
              || CommonConstants.ProductIdentifier == CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201_S0 //New Product Addition FP4030MT-L0808RP-A0201-S0 Vijay
            #region Hitachi Hi-Rel Vijay
              || CommonConstants.ProductIdentifier == CommonConstants.PRODUCT_HH5P_HP300201U0808_RP
              || CommonConstants.ProductIdentifier == CommonConstants.PRODUCT_HH5P_HP300201L0808_RP
            #endregion
            #region New FP4030MT Vertical Series Addition Vijay
 || CommonConstants.ProductIdentifier == CommonConstants.PRODUCT_FP4030MT_L0808RN_A0201_VERTICAL || CommonConstants.ProductIdentifier == CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201_VERTICAL
              || CommonConstants.ProductIdentifier == CommonConstants.PRODUCT_FP4030MT_L0808RN_VERTICAL || CommonConstants.ProductIdentifier == CommonConstants.PRODUCT_FP4030MT_L0808RP_VERTICAL
            #endregion
 || CommonConstants.ProductIdentifier == CommonConstants.PRODUCT_FP4030MR_0808R_A0400_S0 //PRODUCT_FP4030MR_0808R_A0400_S0_addition_sammed 
              || CommonConstants.ProductIdentifier == CommonConstants.PRODUCT_FP4030MR_L1210RP_A0402U //PRODUCT_FP4030MR_L1210RP_A0402U Vijay
              || CommonConstants.ProductIdentifier == CommonConstants.PRODUCT_FP4030MR_L1210P_A0402U  //PRODUCT_FP4030MR_L1210P_A0402U Vijay
              || CommonConstants.ProductIdentifier == CommonConstants.PRODUCT_FP4030MR_L1210RP //PRODUCT_FP4030MR_L1210RP Suyash
              || CommonConstants.ProductIdentifier == CommonConstants.PRODUCT_FP4030MR_L1210P //PRODUCT_FP4030MR_L1210P Suyash
              || CommonConstants.ProductIdentifier == CommonConstants.PRODUCT_FP4030MR_L0808R_A0400U //PRODUCT_FP4030MR_L0808R_A0400U Vijay
                //FP4030MT_L0808RN_A0201L_addition_sammed
              || CommonConstants.ProductIdentifier == CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201L
              || CommonConstants.ProductIdentifier == CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201L_VERTICAL
                //End
              || CommonConstants.ProductIdentifier == CommonConstants.PRODUCT_OIS42_Plus //New Product addition FP4030MT-L0808RN/RP Vijay
              || CommonConstants.ProductIdentifier == CommonConstants.PRODUCT_OIS42L_Plus//New_Product_Addition Vijay(12.09.2013)
            #region New Product Addtion FP4030MT_L0808P/FP4030MT_L0808P_A0201U Vijay
              || CommonConstants.ProductIdentifier == ClassList.CommonConstants.PRODUCT_FP4030MT_L0808P
              || CommonConstants.ProductIdentifier == ClassList.CommonConstants.PRODUCT_FP4030MT_L0808P_A0201U
            #endregion
 || ClassList.CommonConstants.ProductIdentifier == ClassList.CommonConstants.PRODUCT_FP2020_L0808RP_A0401L //2020_Series_Vijay
              || ClassList.CommonConstants.ProductIdentifier == ClassList.CommonConstants.PRODUCT_FP2020_L0808P_A0401L
              || ClassList.CommonConstants.ProductIdentifier == ClassList.CommonConstants.PRODUCT_FP2020_L0604P_A0401L
              || CommonConstants.ProductIdentifier == ClassList.CommonConstants.PRODUCT_FP4030MT_L0808P_A0402L//Suyash_Product_Addition_FP4030MT_L0808P_A0402L
              || ClassList.CommonConstants.IsProductFL005MicroPLCBase(CommonConstants.ProductIdentifier) //FL005-MicroPLC Base Module Series Vijay
                || ClassList.CommonConstants.IsProductSupportedFP3020series(CommonConstants.ProductIdentifier))//Suyash_FP3020MR_L1608RP_Prod_Addition
                return true;
            return false;
        }

        public static bool IsProductCompatibleWith4035(int ProdutID)
        {
            bool retValue = false;
            switch (ProdutID)
            {
                case CommonConstants.PRODUCT_FP4035T:
                case CommonConstants.PRODUCT_PZ4035TN_E:

                case CommonConstants.PRODUCT_FP4035T_E:
                #region New_Ethernet_Products_AMIT
                case CommonConstants.PRODUCT_FP4035TN:
                case CommonConstants.PRODUCT_FP4035TN_E:
                #endregion

                case CommonConstants.PRODUCT_TRPMIU0300L:
                case CommonConstants.PRODUCT_TRPMIU0300A:

                case CommonConstants.PRODUCT_FH9035T:
                case CommonConstants.PRODUCT_FH9035T_E:

                #region New FP Models-43&70 SnehalM
                case CommonConstants.PRODUCT_FP5043T:
                case CommonConstants.PRODUCT_FP5043TN:
                case CommonConstants.PRODUCT_FP5043T_E:
                case CommonConstants.PRODUCT_FP5043TN_E:
                case CommonConstants.PRODUCT_FP5070T:
                case CommonConstants.PRODUCT_FP5070TN:
                case CommonConstants.PRODUCT_FP5070T_E:
                case CommonConstants.PRODUCT_FP5070TN_E:
                case CommonConstants.PRODUCT_FP5121T:
                case CommonConstants.PRODUCT_FP5121TN:
                #endregion
                case CommonConstants.PRODUCT_FP5070T_E_S2://New FP5070T-E-S2 product Addition Suyash
                #region Toshiba US products SnehalM
                case CommonConstants.PRODUCT_OIS55_Plus:
                #endregion

                case CommonConstants.PRODUCT_HMC7035A_M:
                //New Ethernet Models - SnehaK
                case CommonConstants.PRODUCT_TRPMIU0300E:
                //End
                //Toshiba_US New product Addition
                case CommonConstants.PRODUCT_OIS45_Plus:
                case CommonConstants.PRODUCT_OIS45E_Plus:
                case CommonConstants.PRODUCT_OIS70_Plus:
                case CommonConstants.PRODUCT_OIS70E_Plus:
                case CommonConstants.PRODUCT_OIS120A:
                //Toshiba-Japan_Product
                case CommonConstants.PRODUCT_TRPMIU0400E:
                case CommonConstants.PRODUCT_TRPMIU0700E:
                //End
                #region //Mapple Customization 2.0_Sanjay_13
                case CommonConstants.PRODUCT_HMC7043A_M:
                case CommonConstants.PRODUCT_HMC7070A_M:
                #endregion
                case CommonConstants.PRODUCT_PRIZM_710_S0://SD_Product_Addition_Prizm710_so

                #region New FP3series product Addition Suyash
                case CommonConstants.PRODUCT_FP3043T://New FP3043T product Addition Suyash
                case CommonConstants.PRODUCT_FP3043TN://New FP3043TN product Addition Suyash
                case CommonConstants.PRODUCT_FP3070T://New FP3070T product Addition Suyash
                case CommonConstants.PRODUCT_FP3070TN://New FP3070TN product Addition Suyash
                case CommonConstants.PRODUCT_FP3102T://New FP3102T product Addition Suyash
                case CommonConstants.PRODUCT_FP3102TN://New FP3102TN product Addition Suyash

                #region SY-FP3_PlugableIO_Product_addition
                case CommonConstants.PRODUCT_FP3070T_E:
                case CommonConstants.PRODUCT_FP3070TN_E:
                case CommonConstants.PRODUCT_FP3102T_E:
                case CommonConstants.PRODUCT_FP3102TN_E:
                #endregion
                #region Hitachi Hi-Rel Vijay
                case CommonConstants.PRODUCT_HH5P_H43_NS:
                case CommonConstants.PRODUCT_HH5P_H43_S:
                case CommonConstants.PRODUCT_HH5P_H70_NS:
                case CommonConstants.PRODUCT_HH5P_H70_S:
                case CommonConstants.PRODUCT_HH5P_H100_NS:
                case CommonConstants.PRODUCT_HH5P_H100_S:
                case CommonConstants.PRODUCT_HH5P_HP43_NS:
                case CommonConstants.PRODUCT_HH5P_HP70_NS:
                #endregion

                #region FP3043_ExpansionSeries Vijay
                case CommonConstants.PRODUCT_FP3043T_E:
                case CommonConstants.PRODUCT_FP3043TN_E:
                #endregion
                #endregion
                #region OIS3Series_Vijay
                case ClassList.CommonConstants.PRODUCT_OIS43E_Plus:
                case ClassList.CommonConstants.PRODUCT_OIS72E_Plus:
                case ClassList.CommonConstants.PRODUCT_OIS100E_Plus:
                #endregion
                #region Panasonic sammed 2.0
                case CommonConstants.PRODUCT_GTXL07N:
                case CommonConstants.PRODUCT_GTXL10N:
                #endregion
                    retValue = true;
                    break;
            }



            return retValue;

        }

        #region New_Ethernet_Products_AMIT
        public static bool IsProduct4035_EthernetProducts(int ProdutID)
        {
            bool retValue = false;
            switch (ProdutID)
            {
                case CommonConstants.PRODUCT_FP4035TN:
                case CommonConstants.PRODUCT_FP4035TN_E:
                //New Ethernet Models - SnehaK
                case CommonConstants.PRODUCT_TRPMIU0300E:
                    //End
                    //case CommonConstants.PRODUCT_TRPMIU0400E:
                    //case CommonConstants.PRODUCT_TRPMIU0700E:
                    retValue = true;
                    break;
            }
            return retValue;

        }
        #endregion

        public static bool IsProductCompatibleWith4057(int ProdutID)
        {
            bool retValue = false;
            switch (ProdutID)
            {

                case CommonConstants.PRODUCT_PZ4057M_E:
                case CommonConstants.PRODUCT_FP4057T:
                #region New_Product_Addition_Herizomat AMIT
                case CommonConstants.PRODUCT_FP4057T_S2:
                #endregion
                case CommonConstants.PRODUCT_PZ4057TN_E:

                //case CommonConstants.PRODUCT_FP4057M_E:
                case CommonConstants.PRODUCT_FP4057T_E:
                #region New_Ethernet_Products_AMIT
                case CommonConstants.PRODUCT_FP4057TN:
                case CommonConstants.PRODUCT_FP4057TN_E:
                #endregion
                #region New_Product_Addition_AllBodySoltn AMIT
                case CommonConstants.PRODUCT_FP4057T_E_S1:
                #endregion
                #region New_Product_Addition_Vertical Vijay
                case CommonConstants.PRODUCT_FP4057T_E_VERTICAL:
                #endregion

                case CommonConstants.PRODUCT_TRPMIU0500L:
                case CommonConstants.PRODUCT_TRPMIU0500A:

                case CommonConstants.PRODUCT_FH9057T:
                case CommonConstants.PRODUCT_FH9057T_E:

                #region New FP Models-43&70 SnehalM
                case CommonConstants.PRODUCT_FP5070T:
                case CommonConstants.PRODUCT_FP5070T_E:
                case CommonConstants.PRODUCT_FP5121T:
                #endregion
                case CommonConstants.PRODUCT_FP5070T_E_S2://New FP5070T-E-S2 product Addition Suyash
                #region Toshiba US products SnehalM
                case CommonConstants.PRODUCT_OIS60_Plus:
                #endregion


                case CommonConstants.PRODUCT_HMC7057A_M:

                //New Ethernet Models - SnehaK                
                case CommonConstants.PRODUCT_TRPMIU0500E:
                //End

                #region New FP3series product Addition Suyash
                case CommonConstants.PRODUCT_FP3070T://New FP3070T product Addition Suyash
                case CommonConstants.PRODUCT_FP3102T://New FP3102T product Addition Suyash
                #endregion
                #region SY-FP3_PlugableIO_Product_addition
                case CommonConstants.PRODUCT_FP3070T_E:
                case CommonConstants.PRODUCT_FP3102T_E:
                #endregion
                #region Hitachi Hi-Rel Vijay
                case CommonConstants.PRODUCT_HH5P_H70_NS:
                case CommonConstants.PRODUCT_HH5P_H100_NS:
                case CommonConstants.PRODUCT_HH5P_HP70_NS:
                #endregion
                    retValue = true;
                    break;
            }



            return retValue;

        }

        public static string FormatedDecimalToBinary(ushort pNumber)
        {
            ushort usBinaryHolder;
            char[] cBinaryArray;
            string strBinaryResult = "";
            int noOfZeros = 0;
            while (pNumber > 0)
            {
                usBinaryHolder = Convert.ToUInt16(pNumber % 2);
                strBinaryResult += Convert.ToUInt16(usBinaryHolder);
                pNumber = Convert.ToUInt16(pNumber / 2);
            }

            cBinaryArray = strBinaryResult.ToCharArray();
            Array.Reverse(cBinaryArray);
            strBinaryResult = new string(cBinaryArray);

            noOfZeros = 8 - strBinaryResult.Length;
            String tempString = "";
            for (int i = 0; i < noOfZeros; i++)
                tempString += '0';

            strBinaryResult = tempString + strBinaryResult;

            return strBinaryResult;
        }
        public static int BinaryToDecimal(string binary)
        {
            long l = Convert.ToInt64(binary, 2);
            int i = (int)l;
            return i;
        }
        public static bool IsFileNameContains_T(String strFileName)
        {
            String tempStr = "";

            if (strFileName.Length > 1)
            {
                tempStr = strFileName.Substring(strFileName.Length - 2, 2);

                if (tempStr == "_T")
                    return true;
            }

            return false;
        }


        public static double GetTagValueFromDataMonitorData(String strAddress)
        {
            //ClassList.DmBlockInfo objBlockInfo;
            //ClassList.DmTagInfo objTagInfo;
            //int TagCount = 0;

            //for (int i = 0; i < ClassList.CommonConstants.objListDataMonitorData.Count; i++)
            //{
            //    objBlockInfo = (ClassList.DmBlockInfo)ClassList.CommonConstants.objListDataMonitorData[i];
            //    TagCount = objBlockInfo.TagList.Count;

            //    for (int j = 0; j < TagCount; j++)
            //    {
            //        objTagInfo = (ClassList.DmTagInfo)objBlockInfo.TagList[j];
            //        if (objTagInfo.strTagAddress == strAddress)
            //        {
            //            return objTagInfo.doubleTagValue;
            //        }

            //    }

            //}

            return 0;
        }
        public static bool IsLadderScreen(int pScreenNumber)
        {
            if (pScreenNumber >= ClassList.CommonConstants.START_LADDER_SCREEN && pScreenNumber <= ClassList.CommonConstants.END_LADDER_SCREENS)
                return true;
            else
                return false;
        }

        public static void Validation_RetentiveMemory(string currentAddr, string prevAddr)
        {
            if (currentAddr[0] == CommonConstants.Retentive_Prefix)
            {
                if (prevAddr != string.Empty)
                {
                    if (currentAddr != prevAddr)
                    {
                        if (ClassList.CommonConstants.IsProductFL005MicroPLCBase(ClassList.CommonConstants.ProductDataInfo.iProductID) ||
                            ClassList.CommonConstants.IsProductFL005ExpandablePLCSeries(ClassList.CommonConstants.ProductDataInfo.iProductID) ||
                            IsProductGateway(ClassList.CommonConstants.ProductDataInfo.iProductID) ||
                            (ClassList.CommonConstants.ProductDataInfo.iProductID == PRODUCT_FP2020_L0808RP_A0401L) || //2020_Series_Vijay
                            (ClassList.CommonConstants.ProductDataInfo.iProductID == PRODUCT_FP2020_L0808P_A0401L) ||
                            (ClassList.CommonConstants.ProductDataInfo.iProductID == PRODUCT_FP2020_L0604P_A0401L))
                        {
                            MessageBox.Show(CommonConstants.Retentive_MemoryLifeCycle_2, CommonConstants.Retentive_MemoryLifeCycle_Caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                            MessageBox.Show(CommonConstants.Retentive_MemoryLifeCycle, CommonConstants.Retentive_MemoryLifeCycle_Caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }
        }

        public static bool IsAddressContainsDecimalPoint(string pStr)
        {
            for (int i = 0; i < pStr.Length; i++)
            {
                if (pStr[i] == '.' || pStr[i] == 'E' || pStr[i] == 'f')
                    return true;
            }
            return false;
        }

        #region Project conversion - AD
        #region Parag_Alarm
        public static bool IsAlarmSupportedByDestinationModel(int pModelID)
        {
            if (!ClassList.CommonConstants.IsProductFlexiPanels(pModelID))
            {
                return false;
            }
            return true;
        }
        #endregion

        #region ShitalG_Product Conversion GUI Change
        public static bool IsSpecialProduct(int ProductId)
        {
            bool supported = false;
            switch (ProductId)
            {
                case ClassList.CommonConstants.PRODUCT_FP4057T_S2:
                case ClassList.CommonConstants.PRODUCT_FP4057T_E_S1:
                case ClassList.CommonConstants.PRODUCT_FL011_S3:
                case ClassList.CommonConstants.PRODUCT_FP4020MR_L0808R_S3:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201_S0:
                case ClassList.CommonConstants.PRODUCT_FP4030MR_0808R_A0400_S0:
                case ClassList.CommonConstants.PRODUCT_FP5121TN_S0:
                case ClassList.CommonConstants.PRODUCT_FP5070T_E_S2://New FP5070T-E-S2 product Addition Suyash
                case ClassList.CommonConstants.PRODUCT_PRIZM_710_S0://SD_Product_Addition_Prizm710_so
                    supported = true;
                    break;
            }
            return supported;
        }
        #endregion

        public static void ConversionLog(string msgs)
        {
            System.IO.StreamWriter writer = null;

            try
            {
                writer = new System.IO.StreamWriter(ClassList.CommonConstants.ProjectConversionPath, true);
                writer.WriteLine(msgs);
            }
            catch (Exception e)
            {
                ExceptionLogger.DisplayError("Error occured in logging product conversion", "Error");
            }
            finally
            {
                writer.Close();
                writer.Dispose();
            }
        }

        //TrendObject_ProductConversion_sammedb
        public static bool IsProductSupportsTrend(int productId)
        {
            if (productId == ClassList.CommonConstants.PRODUCT_FP4030MT_REV1
            || ClassList.CommonConstants.IsProductSupportedFP3035(productId)
            || ClassList.CommonConstants.IsProductSupportedFP4020MR(productId)
            || ClassList.CommonConstants.IsProductSupportedFP4030MT(productId)
            || ClassList.CommonConstants.IsProductSupportedFP4030MR(productId))
            {
                return false;
            }

            return true;
        }
        //End

        public static string GetTaskName(TaskCode pTaskCode)
        {
            string strTaskName = CoreConstStrings.strGotoScreen;
            switch (pTaskCode)
            {
                case ClassList.TaskCode.GoToScreen:
                    strTaskName = CoreConstStrings.strGotoScreen;
                    break;

                case ClassList.TaskCode.GoToNextScreen:
                    strTaskName = CoreConstStrings.strNextScreen;
                    break;

                case ClassList.TaskCode.GoToPreviousScreen:
                    strTaskName = CoreConstStrings.strPreviousScreen;
                    break;

                case ClassList.TaskCode.WriteValueToTag:
                    strTaskName = CoreConstStrings.strWriteValueToTag;
                    break;

                case ClassList.TaskCode.AddaConstValueToTag:
                    strTaskName = CoreConstStrings.strAddAConstantValueToATag;
                    break;

                case ClassList.TaskCode.SubaConstValueFromTag:
                    strTaskName = CoreConstStrings.strSubtractAConstantValueFromATag;
                    break;

                case ClassList.TaskCode.AddTagBToTagA:
                    strTaskName = CoreConstStrings.strAddTagBToTagA;
                    break;

                case ClassList.TaskCode.SubTagBFromTagA:
                    strTaskName = CoreConstStrings.strSubtractTagBFromTagA;
                    break;

                case ClassList.TaskCode.TurnBitOn:
                    strTaskName = CoreConstStrings.strTurnBitON;
                    break;

                case ClassList.TaskCode.TurnBitOff:
                    strTaskName = CoreConstStrings.strTurnBitOFF;
                    break;

                case ClassList.TaskCode.ToggleBit:
                    strTaskName = CoreConstStrings.strToggleBit;
                    break;

                case ClassList.TaskCode.CopyTagBToTagA:
                    strTaskName = CoreConstStrings.strCopyTagBToTagA;
                    break;

                case ClassList.TaskCode.SwapTagAandTagBBoth:
                    strTaskName = CoreConstStrings.strSwapTagAAndTagB;
                    break;

                case ClassList.TaskCode.CopyTagToSTR:
                    strTaskName = CoreConstStrings.strCopyTagToSTR;
                    break;

                case ClassList.TaskCode.CopyTagToLED:
                    strTaskName = CoreConstStrings.strCopyTagToLED;
                    break;

                case ClassList.TaskCode.CopyRecipeToPLCBlock:
                    strTaskName = CoreConstStrings.strCopyPrizmBlockToPrizmOrPLCBlock;
                    break;

                case ClassList.TaskCode.CopyPLCBlockToRecipe:
                    strTaskName = CoreConstStrings.strCopyPLCToPrizm;
                    break;

                case ClassList.TaskCode.CopyRTCToPLCBlock:
                    strTaskName = CoreConstStrings.strCopyRTCToPLC;
                    break;

                case ClassList.TaskCode.KeySpecificTask:
                    strTaskName = CoreConstStrings.strKeysSpecificTask;
                    break;

                case ClassList.TaskCode.PrintData:
                    strTaskName = CoreConstStrings.strPrintData;
                    break;

                case ClassList.TaskCode.SetRTC:
                    strTaskName = CoreConstStrings.strSetRTC;
                    break;
                case ClassList.TaskCode.USBDataLogUpload:
                    strTaskName = CoreConstStrings.strUSBDataLogUpload;
                    break;

                #region SS_CopyTasks
                case TaskCode.Delay:
                    strTaskName = CoreConstStrings.strDelay;
                    break;
                case TaskCode.Wait:
                    strTaskName = CoreConstStrings.strWait;
                    break;

                case TaskCode.ExecutePLCLogicBlock:
                    strTaskName = CoreConstStrings.strExecutePLCLogicBlock;
                    break;

                case TaskCode.GoToPopUpScreen:
                    strTaskName = CoreConstStrings.strGoToPopUpScreen;
                    break;

                case TaskCode.USBHostUpload:
                    strTaskName = CoreConstStrings.strUSBHostUpload;
                    break;
                case TaskCode.SDCardUpload://SS_SDCardUpload
                    strTaskName = CoreConstStrings.strSDCardUpload;
                    break;
                #endregion
            }
            return strTaskName;
        }

        public static string GetKeySpecificTaskName(KeyTaskCode objTaskCode)
        {
            string strTaskName = "";

            switch (objTaskCode)
            {
                case KeyTaskCode.RefreshTrendWindow:
                    strTaskName = CoreConstStrings.strRefreshTrendWindow;
                    break;

                case KeyTaskCode.ClearLogMemory:
                    strTaskName = CoreConstStrings.strClearLogMemory;
                    break;

                case KeyTaskCode.ShowEthernetConfigurationScreen:
                    strTaskName = CoreConstStrings.strShowEthernetConfigurationScreen;
                    break;

                case KeyTaskCode.StartLogger:
                    strTaskName = CoreConstStrings.strStartLogger;
                    break;

                case KeyTaskCode.StartLoggerOfGroupNo:
                    strTaskName = CoreConstStrings.strStartLoggerOfGroupNo;
                    break;

                case KeyTaskCode.StopLogger:
                    strTaskName = CoreConstStrings.strStopLogger;
                    break;

                case KeyTaskCode.StopPrintingOfGroupNo:
                    strTaskName = CoreConstStrings.strStopLoggerOfGroupNo;
                    break;

                #region Data_Logging_Modification_1 Vijay
                case KeyTaskCode.StartExternalLogger:
                    strTaskName = CoreConstStrings.strStartExternalLogger;
                    break;
                case KeyTaskCode.StartExternalLoggerOfGroupNo:
                    strTaskName = CoreConstStrings.strStartExternalLoggerOfGroupNo;
                    break;
                case KeyTaskCode.StopExternalLogger:
                    strTaskName = CoreConstStrings.strStopExternalLogger;
                    break;
                case KeyTaskCode.StopExternalLoggerOfGroupNo:
                    strTaskName = CoreConstStrings.strStopExternalLoggerOfGroupNo;
                    break;
                #endregion

                default:
                    break;
            }
            return strTaskName;
        }

        public static string GetShapeName(int ShapeId)
        {
            string strShapeName = "";

            switch (ShapeId)
            {
                case ClassList.CommonConstants.RECTANGLE_OBJECTTYPE:
                    strShapeName = "Rectangle";
                    break;
                case ClassList.CommonConstants.ELLIPSE_OBJECTTYPE:
                    strShapeName = "Ellipse";
                    break;
                case ClassList.CommonConstants.ROUNDRECT_OBJECTTYPE:
                    strShapeName = "Round Rectangle";
                    break;
                case ClassList.CommonConstants.LINE_OBJECTTYPE:
                    strShapeName = "Line";
                    break;
                case ClassList.CommonConstants.BITBUTTON_OBJECTTYPE:
                    strShapeName = "Bit Button";
                    break;
                case ClassList.CommonConstants.WORDBUTTON_OBJECTTYE:
                    strShapeName = "Word Button";
                    break;
                case ClassList.CommonConstants.WORDLAMP_OBJECTTYPE:
                    strShapeName = "Word Lamp";
                    break;
                case ClassList.CommonConstants.SINGLEBARGRAPH_OBJECTTYPE:
                    strShapeName = "Single Bargraph";
                    break;
                case ClassList.CommonConstants.DATE_OBJECTTYPE:
                    strShapeName = "Date";
                    break;
                case ClassList.CommonConstants.TIME_OBJECTTYPE:
                    strShapeName = "Time";
                    break;
                case ClassList.CommonConstants.TEXTWIZARD_OBJECTTYPE:
                    strShapeName = "Mutilingual Text";
                    break;
                case ClassList.CommonConstants.TEXTOBJECT_OBJECTTYPE:
                    strShapeName = "Text";
                    break;
                case ClassList.CommonConstants.BARGRAPH_OBJECTTYPE:
                    strShapeName = "Multiple Bargraph";
                    break;
                case ClassList.CommonConstants.BITMAP_OBJECTTYPE:
                    strShapeName = "Bitmap";
                    break;
                case ClassList.CommonConstants.ADVANCEDPICTURE_OBJECTTYPE:
                    strShapeName = "Picture";
                    break;
                case ClassList.CommonConstants.ANALOGMETER_OBJECTTYPE:
                    strShapeName = "Analogmeter";
                    break;
                case ClassList.CommonConstants.KEYPAD_OBJECTTYPE:
                    strShapeName = "Keypad";
                    break;
                case ClassList.CommonConstants.TREND_OBJECTTYPE:
                    strShapeName = "Trend";
                    break;
                case ClassList.CommonConstants.XYPlot_OBJECTTYPE:
                    strShapeName = "XY Plot";
                    break;
                case ClassList.CommonConstants.HISTORICALTREND_OBJECTTYPE:
                    strShapeName = "Historical Trend";
                    break;
                case ClassList.CommonConstants.ALARM_OBJECTTYPE:
                    strShapeName = "Alarm";
                    break;
                case ClassList.CommonConstants.KEYPADPASSWORD_OBJECTTYPE:
                    strShapeName = "Keypad Password";
                    break;
                case ClassList.CommonConstants.EDITPASSWORD_OBJECTTYPE:
                    strShapeName = "Edit Password";
                    break;
                case ClassList.CommonConstants.ASCIIKEYPAD_OBJECTTYPE:
                    strShapeName = "Ascii Keypad";
                    break;
                case ClassList.CommonConstants.CUSTOMKEYPAD_OBJECTTYPE:
                    strShapeName = "Custom Keypad";
                    break;
                case ClassList.CommonConstants.KEYPADWITHTAG_OBJECTTYPE:
                    strShapeName = "Advanced Custom keypad";
                    break;
                case ClassList.CommonConstants.POLYLINE_OBJECTTYPE:
                    strShapeName = "Polyline";
                    break;
                case ClassList.CommonConstants.POLYGON_OBJECTTYPE:
                    strShapeName = "Polygon";
                    break;
                case ClassList.CommonConstants.ARC_OBJECTTYPE:
                    strShapeName = "Arc";
                    break;
                case ClassList.CommonConstants.PIE_OBJECTTYPE:
                    strShapeName = "Pie";
                    break;
                case ClassList.CommonConstants.DATAENTRYCOIL_OBJECTTYPE:
                    strShapeName = "Coil Data Entry";
                    break;
                case ClassList.CommonConstants.DATAENTRYREGISTER_OBJECTTYPE:
                    strShapeName = "Register Data Entry";
                    break;
                case ClassList.CommonConstants.DISPLAYDATACOIL_OBJECTTYPE:
                    strShapeName = "Display Data Coil";
                    break;
                case ClassList.CommonConstants.DISPLAYDATAREGISTER_OBJECTTYPE:
                    strShapeName = "Display Data Register";
                    break;
                case ClassList.CommonConstants.DISPLAYDATAREGISTERTEXT_OBJECTTYPE:
                    strShapeName = "Message Display Data";
                    break;
                default:
                    strShapeName = "Default";
                    break;
            }
            return strShapeName;
        }

        #endregion

        public static bool IsPLCSupported(int ProductId, int PLCCode, string strPort) //PLCSupport_FromXML_Vijay
        {
            #region PLCSupport_FromXML_Vijay
            DataRow[] drProtocolInfo;
            bool Flag = false;
            string strProductModel = "Model" + ProductId.ToString();

            string strPlcCode = PLCCode.ToString();
            if (strPlcCode.Length == 1)
                strPlcCode = "0" + strPlcCode;

            if (ClassList.CommonConstants.g_Support_IEC_Ladder == false)
            {
                drProtocolInfo = CommonConstants.dsReadPLCSupportedModelList_Native.Tables[strProductModel].Select("PLCCode='" + strPlcCode + "' and " + strPort + "='True'");
                if (drProtocolInfo.Length > 0)
                    Flag = true;
            }
            else
            {
                drProtocolInfo = CommonConstants.dsReadPLCSupportedModelList_IEC.Tables[strProductModel].Select("PLCCode='" + strPlcCode + "' and " + strPort + "='True'");
                if (drProtocolInfo.Length > 0)
                    Flag = true;
            }
            return Flag;
            #region OLD_CODE
            //   #region 24.10.2016_Vijay
            //   ////New Product FL050 V2 SammedB
            //   //if (ProductId == ClassList.CommonConstants.PRODUCT_FL050_V2)
            //   //{
            //   //    if (PLCCode == 181 || PLCCode == 133 || PLCCode == 188 || (!(ClassList.CommonConstants.g_Support_IEC_Ladder) && PLCCode == 187) || PLCCode == 193 || PLCCode == 134 || PLCCode == 191) //Remove_FlexiLogicsDriverFromIEC Vijay
            //   //    {
            //   //        return true;
            //   //    }
            //   //    else if (PLCCode == 29)
            //   //    {
            //   //        return false;
            //   //    }
            //   //}
            //   ////End
            //   #endregion
            //   #region Req195_AddKeyenceProtocol Vijay
            //   if (PLCCode == 18)
            //   {
            //       if (!IsProductSupportsKeyenceProtocol(ProductId))
            //       {
            //           return false;
            //       }
            //   }
            //   #endregion
            //   if (IsProductSupportsEthernetMultiNode(ProductId))//SS_ModbusServerClient
            //   {
            //       if (PLCCode == 131)//remove modbus TCP Server (Slave)
            //           return false;
            //   }

            //   //GWY00_Change
            //   if (IsProductGWY_K22(ProductId) == true)
            //   {
            //       if (PLCCode == 187 || PLCCode == 193 || PLCCode == 184 || PLCCode == 116)
            //       {
            //           return false;
            //       }
            //   }
            //   //
            //   if (ClassList.CommonConstants.IsProductCompatibleWith4030(ProductId) ||
            //       ClassList.CommonConstants.IsProductCompatibleWith4030MT(ProductId) ||
            //       IsProductGWY_K22(ProductId) ||//GWY00_Change
            //       ClassList.CommonConstants.IsProductFL005MicroPLCBase(ProductId)) //Issue_391 & 393 Vijay
            //   {
            //       #region Issue_493 Vijay
            //       if (ClassList.CommonConstants.IsProductFL005MicroPLCBase(ProductId)||
            //            IsProductGWY_K22(ProductId))//GWY00_Change)
            //       {
            //           //FL055_Product_Addition_Suyash
            //           if (ProductId == ClassList.CommonConstants.PRODUCT_FL055 || ProductId == ClassList.CommonConstants.PRODUCT_FL050_V2) //24.10.2016_Vijay
            //           {
            //               if (PLCCode == 138 || PLCCode == 180 || PLCCode == 77 || PLCCode == 197 || PLCCode == 29 || (ClassList.CommonConstants.g_Support_IEC_Ladder && PLCCode == 184) || (ClassList.CommonConstants.g_Support_IEC_Ladder && PLCCode == 187)) //Remove_FlexiLogicsDriverFromIEC Vijay
            //                   return false;
            //           }
            //           //end
            //           else if (PLCCode == 77 || PLCCode == 197 || PLCCode == 29 || /*PLCCode == 06 || PLCCode == 67 ||*/ PLCCode == 188 || (ClassList.CommonConstants.g_Support_IEC_Ladder && PLCCode == 184) || (ClassList.CommonConstants.g_Support_IEC_Ladder && PLCCode == 187) || (ClassList.CommonConstants.g_Support_IEC_Ladder && PLCCode == 193)) ////FlexiLogic/FlexiLogic_Slave_Driver_Changes Vijay //SS_FL100S0
            //               return false;
            //           //if (PLCCode == 77 || PLCCode == 197 || PLCCode == 29 || /*PLCCode == 06 || PLCCode == 67 ||*/ PLCCode == 188 || (ClassList.CommonConstants.g_Support_IEC_Ladder && PLCCode == 184) || (ClassList.CommonConstants.g_Support_IEC_Ladder && PLCCode == 187) || (ClassList.CommonConstants.g_Support_IEC_Ladder && PLCCode == 193)) ////FlexiLogic/FlexiLogic_Slave_Driver_Changes Vijay //SS_FL100S0
            //           //    return false;
            //           else if (ClassList.CommonConstants.g_Support_IEC_Ladder && PLCCode == 178)//SiemenseGasAnalyser_Driver_sammed
            //               return false;
            //       }
            //       else
            //       {
            //           //if (PLCCode == 77 || PLCCode == 29 || PLCCode == 06 || PLCCode == 67 || PLCCode == 188 || (ClassList.CommonConstants.g_Support_IEC_Ladder && PLCCode == 184) || (ClassList.CommonConstants.g_Support_IEC_Ladder && PLCCode == 187))//New Product addition FP4030MT- Rev 1 //G9SP removed as per kranti reported
            //           //if (PLCCode == 77 || PLCCode == 29 || /*PLCCode == 06 || PLCCode == 67 ||*/ PLCCode == 188 || (ClassList.CommonConstants.g_Support_IEC_Ladder && PLCCode == 184) || (ClassList.CommonConstants.g_Support_IEC_Ladder && PLCCode == 187))//Parag changes 
            //           if (PLCCode == 77 || PLCCode == 197 || PLCCode == 29 || /*PLCCode == 06 || PLCCode == 67 ||*/ PLCCode == 188 || (ClassList.CommonConstants.g_Support_IEC_Ladder && PLCCode == 184) || (ClassList.CommonConstants.g_Support_IEC_Ladder && PLCCode == 187) || (ClassList.CommonConstants.g_Support_IEC_Ladder && PLCCode == 178) || (ClassList.CommonConstants.g_Support_IEC_Ladder && PLCCode == 193))//Parag changes //sam_array //SS_FL100S0
            //               return false;
            //       }
            //       #endregion
            //   }

            //   else if (ClassList.CommonConstants.IsProductCompatibleWith4020(ProductId))
            //   {
            //       //if (PLCCode == 77 || PLCCode == 29 || PLCCode == 06 || PLCCode == 67 || PLCCode == 181 || PLCCode == 188)//G9SP removed as per kranti reported
            //       if (PLCCode == 77 || PLCCode == 197 || PLCCode == 29 || /*PLCCode == 06 || PLCCode == 67 ||*/ PLCCode == 181 || PLCCode == 188)//Parag changes //SS_FL100S0
            //           return false;

            //   }
            //   //New FP3035 Product Series_V2.3_Issue_453 SP
            //   else if (ClassList.CommonConstants.IsProductCompatibleWithFP3035(ProductId))
            //   {
            //       if (PLCCode == 77 || PLCCode == 197 || PLCCode == 29 || PLCCode == 188 || PLCCode == 184 /*|| PLCCode == 187*/)//*/)//New FP3035 Product Series_V2.3_Issue_723 SP //SS_FL100S0
            //           return false;
            //   }
            //   //End
            //   #region S7-300_Remove Vijay
            //   else if (ClassList.CommonConstants.IsProductSupportedFP3series(ProductId))
            //   {
            //       if (ClassList.CommonConstants.g_Support_IEC_Ladder)
            //       {
            //           if (PLCCode == 77 || PLCCode == 197 || PLCCode == 187 || PLCCode == 193 || PLCCode == 178)//SS_FL100S0
            //               return false;
            //       }
            //       else
            //       {
            //           if (PLCCode == 77 || PLCCode == 197)//SS_FL100S0
            //               return false;
            //       }
            //   }
            //   #endregion

            //   #region Logix5000PLCs_RemoveFP4XXXSeries Vijay
            //   else if (((ClassList.CommonConstants.IsProductSupportedFP4035(ProductId)) || (ClassList.CommonConstants.IsProductSupportedFP4057(ProductId)))
            //&& (ClassList.CommonConstants.IsProductSupportsEthernet(ProductId)) && (ClassList.CommonConstants.g_Support_IEC_Ladder == false))
            //   {
            //       if (PLCCode == 138 || PLCCode == 134 || PLCCode == 197)//SS_FL100S0
            //           return false;
            //   }
            //   #endregion

            //   //else if (ProductId == ClassList.CommonConstants.PRODUCT_FL100 || ProductId == ClassList.CommonConstants.PRODUCT_GPU230_3S) //FL100 As per sahil Mail Date 19-6-2013
            //   //{

            //   //    if (PLCCode == 02 || PLCCode == 78 || PLCCode == 106)
            //   //        return false;
            //   //}
            //   #region Vijay_FL100
            //   else if (ClassList.CommonConstants.g_Support_IEC_Ladder == true)
            //   {
            //       //sammed_123
            //       //ss_enableEthernet
            //       if (/*PLCCode == 116 || PLCCode == 131 ||*/ PLCCode == 184 || PLCCode == 187 || PLCCode == 188 || PLCCode == 193)//Issue 736 SP G9SP removed for IEC //SS_RENU_PLC_Change ////SS_UniversalDriverIECEnable 
            //       {
            //           if ((ClassList.CommonConstants.IsProductSupportedFP4035(ProductId) ||
            //           ClassList.CommonConstants.IsProductSupportedFP4057(ProductId) ||
            //           ClassList.CommonConstants.IsProductSupportedFP5043(ProductId) ||
            //           ClassList.CommonConstants.IsProductSupportedFP5070(ProductId) ||
            //           ClassList.CommonConstants.IsProductSupportedFP5121(ProductId)) && PLCCode == 188)//As per mail of Kranti P(21-May-2013)G9SP supported for 4057 4035 FP5X series for IEC.
            //           {
            //           }
            //           else
            //               return false;
            //       }
            //       else if (PLCCode == 02 || PLCCode == 78 || PLCCode == 106)
            //       {
            //           if (ProductId == ClassList.CommonConstants.PRODUCT_FL100 || ProductId == ClassList.CommonConstants.PRODUCT_FL100_S0 || ProductId == ClassList.CommonConstants.PRODUCT_GPU230_3S //SS_FL100S0
            //               || ProductId == ClassList.CommonConstants.PRODUCT_CPU_300 //PLC_Direct Vijay
            //                || ProductId == ClassList.CommonConstants.PRODUCT_HH1L_000) //Hitachi Hi-Rel Vijay
            //           {
            //               return false;
            //           }
            //       }
            //       else if (PLCCode == 178)//SiemenseGasAnalyser_Driver_sammed 
            //           return false;
            //       else
            //           if (PLCCode == 197) //SS_FL100S0
            //           {
            //               //if (IsProductMXSpecialCase_Based(ProductId) || IsProductMX257_Based(ProductId))//SS remove passthroughport for FP5 and FL100 basic model
            //               if (IsProductFL100Special(ProductId))
            //               { }
            //               else
            //                   return false;
            //           }
            //   }
            //   #endregion
            //   else if (ClassList.CommonConstants.IsProductPLC(ProductId))
            //   {
            //       if (ProductId == ClassList.CommonConstants.PRODUCT_FL100 || ProductId == ClassList.CommonConstants.PRODUCT_FL100_S0 || ProductId == ClassList.CommonConstants.PRODUCT_GPU230_3S || ProductId == ClassList.CommonConstants.PRODUCT_CPU_300 || ProductId == ClassList.CommonConstants.PRODUCT_HH1L_000) //FL100 //New_Product_Addition Vijay(01.03.2013)//PLC_Direct Vijay //SS_FL100S0 //Hitachi Hi-Rel Vijay
            //       {
            //           //if (PLCCode == 77 || PLCCode == 29 || PLCCode == 06 || PLCCode == 67 || PLCCode == 181 || PLCCode == 138 || PLCCode == 188 || PLCCode == 187 || PLCCode == 02 || PLCCode == 78 || PLCCode == 106)//G9SP removed as per kranti reported
            //           if (ProductId == ClassList.CommonConstants.PRODUCT_FL100 || ProductId == ClassList.CommonConstants.PRODUCT_CPU_300) //PLC_Direct Vijay //SS_FL100S0
            //           {
            //               if (PLCCode == 77 || PLCCode == 197 || PLCCode == 29 || PLCCode == 06 || PLCCode == 67 || PLCCode == 181 /*|| PLCCode == 187*/ || PLCCode == 02 || PLCCode == 78 || PLCCode == 106) //FlexiLogic/FlexiLogic_Slave_Driver_Changes Vijay
            //                   return false;
            //           }
            //           #region Hitachi Hi-Rel Vijay
            //           else if (ProductId == ClassList.CommonConstants.PRODUCT_HH1L_000)
            //           {
            //               if (PLCCode == 77 || PLCCode == 197 || PLCCode == 29 /*|| PLCCode == 187*/ || PLCCode == 02 || PLCCode == 106) //FlexiLogic/FlexiLogic_Slave_Driver_Changes Vijay
            //                   return false;
            //           }
            //           #endregion
            //           else if (ProductId == ClassList.CommonConstants.PRODUCT_GPU230_3S)
            //           {
            //               if (PLCCode == 77 || PLCCode == 197 || PLCCode == 29 || PLCCode == 06 || PLCCode == 67 || PLCCode == 181 /*|| PLCCode == 187*/ || PLCCode == 02 || PLCCode == 78 || PLCCode == 106 || PLCCode == 188) //FlexiLogic/FlexiLogic_Slave_Driver_Changes Vijay
            //                   return false;
            //           }
            //           else if (ProductId == ClassList.CommonConstants.PRODUCT_FL100_S0)//SS remove passthroughport for FP5 and FL100 basic model
            //           {
            //               if (PLCCode == 77 || PLCCode == 29 || PLCCode == 06 || PLCCode == 67 || PLCCode == 181 /*|| PLCCode == 187*/ || PLCCode == 02 || PLCCode == 78 || PLCCode == 106) //FlexiLogic/FlexiLogic_Slave_Driver_Changes Vijay
            //                   return false;
            //           }
            //       }
            //       else
            //       {
            //           //if (PLCCode == 77 || PLCCode == 29 || PLCCode == 06 || PLCCode == 67 || PLCCode == 181 || PLCCode == 180 || PLCCode == 138 || PLCCode == 188 || PLCCode == 187)//G9SP removed as per kranti reported
            //           if (PLCCode == 77 || PLCCode == 197 || PLCCode == 29 || /*PLCCode == 06 || PLCCode == 67 || */PLCCode == 181 || PLCCode == 180 || PLCCode == 138 || PLCCode == 188 /*|| PLCCode == 187*/)//G9SP removed as per kranti reported //FlexiLogic/FlexiLogic_Slave_Driver_Changes Vijay //SS_FL100S0
            //               return false;
            //       }
            //   }
            //   else if (ClassList.CommonConstants.ProductDataInfo.iProductID == ClassList.CommonConstants.PRODUCT_GSM900 || ClassList.CommonConstants.ProductDataInfo.iProductID == ClassList.CommonConstants.PRODUCT_GSM901 || ClassList.CommonConstants.ProductDataInfo.iProductID == ClassList.CommonConstants.PRODUCT_GSM910)//GWY_910_Suyash //GSM_Sanjay //GWY-901 SP
            //   {
            //       if (PLCCode == 06 || PLCCode == 67 || PLCCode == 77 || PLCCode == 29 || PLCCode == 181 || PLCCode == 188 || PLCCode == 187 || PLCCode == 193 || PLCCode == 197)//G9SP removed as per kranti reported //SS_RENU_PLC_Change //SS_FL100S0
            //           return false;
            //   }
            //   else if (PLCCode == 197)
            //   {
            //       //if (IsProductMXSpecialCase_Based(ProductId) || IsProductMX257_Based(ProductId))//SS remove passthroughport for FP5 and FL100 basic model
            //       if (IsProductFL100Special(ProductId))
            //       { }
            //       else
            //           return false;
            //   }
            //   #region FlexiLogic/FlexiLogic_Slave_Driver_Changes Vijay
            //   //if (PLCCode == 193 && (!ClassList.CommonConstants.IsProductPLC(ProductId) || ClassList.CommonConstants.g_Support_IEC_Ladder))//SS_RENU_PLC_Change
            //   //    return false;

            //   #endregion
            //   return true;
            #endregion
            #endregion
        }
        #region Req195_AddKeyenceProtocol Vijay
        public static bool IsProductSupportsKeyenceProtocol(int ProdutID)
        {
            bool retValue = false;
            switch (ProdutID)
            {

                case CommonConstants.PRODUCT_FP4030MR:
                case CommonConstants.PRODUCT_FP4030MR_E:
                case CommonConstants.PRODUCT_FP4030MR_L1208R:
                case CommonConstants.PRODUCT_FP4030MR_L1210P_A0402U:
                case CommonConstants.PRODUCT_FP4030MR_L1210RP_A0402U:
                case CommonConstants.PRODUCT_OIS20_Plus:
                case CommonConstants.PRODUCT_OIS22_Plus:
                case CommonConstants.PRODUCT_HMC7030A_L:
                case CommonConstants.PRODUCT_HMC7030A_M:
                case CommonConstants.PRODUCT_FP4030MT_L0808P_A0402L://Suyash_Product_Addition_FP4030MT_L0808P_A0402L
                case CommonConstants.PRODUCT_FP4030MT_HORIZONTAL:
                case CommonConstants.PRODUCT_FP4030MT_REV1:
                case CommonConstants.PRODUCT_FP4030MT_L0808P:
                case CommonConstants.PRODUCT_FP4030MT_L0808P_A0201U:
                case CommonConstants.PRODUCT_FP4030MT_L0808RP:
                case CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201L:
                case CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201:
                case CommonConstants.PRODUCT_OIS40_Plus_HORIZONTAL:
                case CommonConstants.PRODUCT_OIS42_Plus:
                case CommonConstants.PRODUCT_OIS42L_Plus:

                case CommonConstants.PRODUCT_FP3043T:
                case CommonConstants.PRODUCT_FP3043TN:
                case CommonConstants.PRODUCT_FP3070T:
                case CommonConstants.PRODUCT_FP3070TN:
                case CommonConstants.PRODUCT_FP3102T:
                case CommonConstants.PRODUCT_FP3102TN:

                #region SY-FP3_PlugableIO_Product_addition
                case CommonConstants.PRODUCT_FP3070T_E:
                case CommonConstants.PRODUCT_FP3070TN_E:
                case CommonConstants.PRODUCT_FP3102T_E:
                case CommonConstants.PRODUCT_FP3102TN_E:
                #endregion

                #region FP3043_ExpansionSeries Vijay
                case CommonConstants.PRODUCT_FP3043T_E:
                case CommonConstants.PRODUCT_FP3043TN_E:
                #endregion
                case CommonConstants.PRODUCT_OIS43E_Plus:
                case CommonConstants.PRODUCT_OIS72E_Plus:
                case CommonConstants.PRODUCT_OIS100E_Plus:

                #region Hitachi Hi-Rel Vijay
                case CommonConstants.PRODUCT_HH5P_H43_NS:
                case CommonConstants.PRODUCT_HH5P_H43_S:
                case CommonConstants.PRODUCT_HH5P_H70_NS:
                case CommonConstants.PRODUCT_HH5P_H70_S:
                case CommonConstants.PRODUCT_HH5P_H100_NS:
                case CommonConstants.PRODUCT_HH5P_H100_S:
                case CommonConstants.PRODUCT_HH5P_HP301208D_R:
                case CommonConstants.PRODUCT_HH5P_HP300201U0808_RP:
                case CommonConstants.PRODUCT_HH5P_HP300201L0808_RP:
                case CommonConstants.PRODUCT_HH5P_HP43_NS:
                case CommonConstants.PRODUCT_HH5P_HP70_NS:
                #endregion

                case CommonConstants.PRODUCT_FP5043T:
                case CommonConstants.PRODUCT_FP5043T_E:
                case CommonConstants.PRODUCT_FP5043TN:
                case CommonConstants.PRODUCT_FP5043TN_E:
                case CommonConstants.PRODUCT_OIS45_Plus:
                case CommonConstants.PRODUCT_OIS45E_Plus:
                case CommonConstants.PRODUCT_TRPMIU0400E:
                case CommonConstants.PRODUCT_HMC7043A_M:

                case CommonConstants.PRODUCT_FP5070T:
                case CommonConstants.PRODUCT_FP5070T_E:
                case CommonConstants.PRODUCT_FP5070TN:
                case CommonConstants.PRODUCT_FP5070TN_E:
                case CommonConstants.PRODUCT_OIS70_Plus:
                case CommonConstants.PRODUCT_OIS70E_Plus:
                case CommonConstants.PRODUCT_TRPMIU0700E:
                case CommonConstants.PRODUCT_HMC7070A_M:

                case CommonConstants.PRODUCT_FP5121T:
                case CommonConstants.PRODUCT_FP5121TN:
                case CommonConstants.PRODUCT_OIS120A:
                #region Panasonic sammed 2.0
                case CommonConstants.PRODUCT_GTXL07N:
                case CommonConstants.PRODUCT_GTXL10N:
                #endregion
                    retValue = true;
                    break;
            }
            return retValue;
        }
        #endregion


        public static bool IsProductSupportsEthernetMultiNode(int ProdutID)//SS_ModbusServerClient
        {
            bool retValue = false;
            switch (ProdutID)
            {
                case CommonConstants.PRODUCT_FL055://FL055_Product_Addition_Suyash
                case CommonConstants.PRODUCT_FL050_V2: //24.10.2016_Vijay
                case CommonConstants.PRODUCT_FL100:
                case CommonConstants.PRODUCT_FL100_S0:
                case CommonConstants.PRODUCT_GPU230_3S:
                case CommonConstants.PRODUCT_CPU_300:

                case CommonConstants.PRODUCT_FP5043TN:
                case CommonConstants.PRODUCT_FP5043TN_E:
                case CommonConstants.PRODUCT_OIS45_Plus:
                case CommonConstants.PRODUCT_OIS45E_Plus:
                case CommonConstants.PRODUCT_TRPMIU0400E:
                case CommonConstants.PRODUCT_HMC7043A_M:

                case CommonConstants.PRODUCT_FP5070TN:
                case CommonConstants.PRODUCT_FP5070TN_E:
                case CommonConstants.PRODUCT_OIS70_Plus:
                case CommonConstants.PRODUCT_OIS70E_Plus:
                case CommonConstants.PRODUCT_TRPMIU0700E:
                case CommonConstants.PRODUCT_HMC7070A_M:

                case CommonConstants.PRODUCT_FP5121TN:
                case CommonConstants.PRODUCT_FP5121TN_S0:
                case CommonConstants.PRODUCT_OIS120A:
                case CommonConstants.PRODUCT_FP3043TN:
                case CommonConstants.PRODUCT_FP3070TN:
                case CommonConstants.PRODUCT_FP3102TN:
                #region SY-FP3_PlugableIO_Product_addition
                case CommonConstants.PRODUCT_FP3043TN_E: //Vijay_15.12.2016
                case CommonConstants.PRODUCT_FP3070TN_E:
                case CommonConstants.PRODUCT_FP3102TN_E:
                #endregion
                case CommonConstants.PRODUCT_OIS43E_Plus:
                case CommonConstants.PRODUCT_OIS72E_Plus:
                case CommonConstants.PRODUCT_OIS100E_Plus:
                #region Hitachi Hi-Rel Vijay
                case CommonConstants.PRODUCT_HH5P_H43_S:
                case CommonConstants.PRODUCT_HH5P_H70_S:
                case CommonConstants.PRODUCT_HH5P_H100_S:
                case CommonConstants.PRODUCT_HH1L_000:
                #endregion
                #region Panasonic sammed 2.0
                case CommonConstants.PRODUCT_GTXL07N:
                case CommonConstants.PRODUCT_GTXL10N:
                #endregion
                    retValue = true;
                    break;
            }
            return retValue;
        }

        public static bool IsProductSupportsEthernetSameNodeAddr(int ProdutID)//SS_ModbusSameNodeAddr
        {
            bool retValue = false;
            switch (ProdutID)
            {
                case CommonConstants.PRODUCT_FL100:
                case CommonConstants.PRODUCT_FL100_S0:
                case CommonConstants.PRODUCT_GPU230_3S://SS_CustomizationChange
                case CommonConstants.PRODUCT_CPU_300: //SS_CustomizationChange

                case CommonConstants.PRODUCT_FP5043TN:
                case CommonConstants.PRODUCT_FP5043TN_E:
                #region SS_CustomizationChange
                case CommonConstants.PRODUCT_OIS45_Plus:
                case CommonConstants.PRODUCT_OIS45E_Plus:
                case CommonConstants.PRODUCT_TRPMIU0400E:
                case CommonConstants.PRODUCT_HMC7043A_M:
                #endregion
                case CommonConstants.PRODUCT_FP5070TN:
                case CommonConstants.PRODUCT_FP5070TN_E:
                #region SS_CustomizationChange
                case CommonConstants.PRODUCT_OIS70_Plus:
                case CommonConstants.PRODUCT_OIS70E_Plus:
                case CommonConstants.PRODUCT_TRPMIU0700E:
                case CommonConstants.PRODUCT_HMC7070A_M:
                #endregion

                case CommonConstants.PRODUCT_FP5121TN:
                case CommonConstants.PRODUCT_FP5121TN_S0:
                case CommonConstants.PRODUCT_OIS120A://SS_CustomizationChange

                case CommonConstants.PRODUCT_FP3043TN:
                case CommonConstants.PRODUCT_FP3070TN:
                case CommonConstants.PRODUCT_FP3102TN:
                #region SY-FP3_PlugableIO_Product_addition
                case CommonConstants.PRODUCT_FP3070TN_E:
                case CommonConstants.PRODUCT_FP3102TN_E:
                #endregion
                case CommonConstants.PRODUCT_FP3043TN_E: //FP3043_ExpansionSeries Vijay
                #region SS_CustomizationChange
                case CommonConstants.PRODUCT_OIS43E_Plus:
                case CommonConstants.PRODUCT_OIS72E_Plus:
                case CommonConstants.PRODUCT_OIS100E_Plus:
                #endregion
                case CommonConstants.PRODUCT_FL055://NewProdsAdded
                case CommonConstants.PRODUCT_FL050_V2://NewProdsAdded
                #region Hitachi Hi-Rel Vijay
                case CommonConstants.PRODUCT_HH5P_H43_S:
                case CommonConstants.PRODUCT_HH5P_H70_S:
                case CommonConstants.PRODUCT_HH5P_H100_S:
                case CommonConstants.PRODUCT_HH1L_000:
                #endregion
                    retValue = true;
                    break;
            }
            return retValue;
        }
        #region SS_SerialParam
        public static bool IsProductSupportsDwnldSerialParams(int ProdutID)
        {
            bool retValue = false;
            switch (ProdutID)
            {
                case CommonConstants.PRODUCT_FP3043T:
                case CommonConstants.PRODUCT_FP3043TN:
                #region FP3043_ExpansionSeries Vijay
                case CommonConstants.PRODUCT_FP3043T_E:
                case CommonConstants.PRODUCT_FP3043TN_E:
                #endregion
                case CommonConstants.PRODUCT_OIS43E_Plus:

                case CommonConstants.PRODUCT_FP3070T:
                case CommonConstants.PRODUCT_FP3070TN:
                case CommonConstants.PRODUCT_OIS72E_Plus:

                case CommonConstants.PRODUCT_FP3102T:
                case CommonConstants.PRODUCT_FP3102TN:
                case CommonConstants.PRODUCT_OIS100E_Plus:

                #region SY-FP3_PlugableIO_Product_addition
                case CommonConstants.PRODUCT_FP3070T_E:
                case CommonConstants.PRODUCT_FP3070TN_E:
                case CommonConstants.PRODUCT_FP3102T_E:
                case CommonConstants.PRODUCT_FP3102TN_E:
                #endregion
                case CommonConstants.PRODUCT_FP5043T:
                case CommonConstants.PRODUCT_FP5043T_E:
                case CommonConstants.PRODUCT_FP5043TN:
                case CommonConstants.PRODUCT_OIS45_Plus:
                case CommonConstants.PRODUCT_FP5043TN_E:
                case CommonConstants.PRODUCT_OIS45E_Plus:

                case CommonConstants.PRODUCT_FP5070T:
                case CommonConstants.PRODUCT_FP5070T_E:
                case CommonConstants.PRODUCT_FP5070TN:
                case CommonConstants.PRODUCT_OIS70_Plus:
                case CommonConstants.PRODUCT_FP5070TN_E:
                case CommonConstants.PRODUCT_OIS70E_Plus:

                case CommonConstants.PRODUCT_FP5121T:
                case CommonConstants.PRODUCT_FP5121TN:
                case CommonConstants.PRODUCT_OIS120A:

                case CommonConstants.PRODUCT_FP4030MT_L0808RP:
                case CommonConstants.PRODUCT_FP4030MT_REV1:
                case CommonConstants.PRODUCT_FP4030MT_L0808P:
                case CommonConstants.PRODUCT_FP4030MT_L0808P_A0201U:
                case CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201:
                case CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201L:
                case CommonConstants.PRODUCT_OIS42L_Plus:
                case CommonConstants.PRODUCT_FP4030MT_S1_HORIZONTAL:
                case CommonConstants.PRODUCT_FP4030MT_S1_VERTICAL:

                case CommonConstants.PRODUCT_FL100:
                case ClassList.CommonConstants.PRODUCT_GPU105_3S:
                case CommonConstants.PRODUCT_CPU_300:

                case CommonConstants.PRODUCT_FL055:
                case CommonConstants.PRODUCT_FL050_V2:

                case CommonConstants.PRODUCT_FL005_0808RP:
                case CommonConstants.PRODUCT_GPU230_3S:
                case CommonConstants.PRODUCT_CPU_111_RP:

                case CommonConstants.PRODUCT_FL005_0808RP0201L:
                case ClassList.CommonConstants.PRODUCT_GPU110_3S:
                case CommonConstants.PRODUCT_CPU_120_ARP:

                case CommonConstants.PRODUCT_FL005_0604P:
                case CommonConstants.PRODUCT_CPU_100_P:

                case CommonConstants.PRODUCT_FL005_0808P:
                case CommonConstants.PRODUCT_CPU_110_P:

                case CommonConstants.PRODUCT_FL005_0808P0201L:
                case CommonConstants.PRODUCT_CPU_120_AP:

                case CommonConstants.PRODUCT_FL005_0604N:
                case CommonConstants.PRODUCT_CPU_100_N:

                case CommonConstants.PRODUCT_FL005_0808N:
                case CommonConstants.PRODUCT_CPU_110_N:

                case CommonConstants.PRODUCT_FL005_0808N0201L:
                case CommonConstants.PRODUCT_CPU_120_AN:

                case CommonConstants.PRODUCT_FL005_0808RP0402U:
                case ClassList.CommonConstants.PRODUCT_GPU122_3S:

                case CommonConstants.PRODUCT_FL005_1616RP0201L:
                case ClassList.CommonConstants.PRODUCT_GPU120_3S:

                case CommonConstants.PRODUCT_FL005_1616P0201L:
                case CommonConstants.PRODUCT_FL005_1616N0201L:
                case CommonConstants.PRODUCT_FL005_1616RP:
                case CommonConstants.PRODUCT_FL005_1616P:
                case CommonConstants.PRODUCT_FL005_1616P0201L_S1:
                case CommonConstants.PRODUCT_GWY00: //GWY00_Change
                #region Hitachi Hi-Rel Vijay
                case CommonConstants.PRODUCT_HH5P_H43_NS:
                case CommonConstants.PRODUCT_HH5P_H43_S:
                case CommonConstants.PRODUCT_HH5P_H70_NS:
                case CommonConstants.PRODUCT_HH5P_H70_S:
                case CommonConstants.PRODUCT_HH5P_H100_NS:
                case CommonConstants.PRODUCT_HH5P_H100_S:
                case CommonConstants.PRODUCT_HH5P_HP300201U0808_RP:
                case CommonConstants.PRODUCT_HH5P_HP300201L0808_RP:
                case CommonConstants.PRODUCT_HH5P_HP43_NS:
                case CommonConstants.PRODUCT_HH5P_HP70_NS:
                #endregion
                    retValue = true;
                    break;
            }
            return retValue;
        }
        #endregion
        #region EnronModbus_support_SD
        public static bool IsProductSupportsEnronModbusProtocol(int ProdutID)
        {
            bool retValue = false;
            switch (ProdutID)
            {
                case CommonConstants.PRODUCT_FP3043T:
                case CommonConstants.PRODUCT_FP3043TN:
                #region FP3043_ExpansionSeries Vijay
                case CommonConstants.PRODUCT_FP3043T_E:
                case CommonConstants.PRODUCT_FP3043TN_E:
                #endregion
                case CommonConstants.PRODUCT_FP3070T:
                case CommonConstants.PRODUCT_FP3070TN:
                case CommonConstants.PRODUCT_FP3102T:
                case CommonConstants.PRODUCT_FP3102TN:

                #region SY-FP3_PlugableIO_Product_addition
                case CommonConstants.PRODUCT_FP3070T_E:
                case CommonConstants.PRODUCT_FP3070TN_E:
                case CommonConstants.PRODUCT_FP3102T_E:
                case CommonConstants.PRODUCT_FP3102TN_E:
                #endregion
                case CommonConstants.PRODUCT_FP5043T:
                case CommonConstants.PRODUCT_FP5043T_E:
                case CommonConstants.PRODUCT_FP5043TN:
                case CommonConstants.PRODUCT_FP5043TN_E:
                case CommonConstants.PRODUCT_FP5070T:
                case CommonConstants.PRODUCT_FP5070T_E:
                case CommonConstants.PRODUCT_FP5070TN:
                case CommonConstants.PRODUCT_FP5070TN_E:
                case CommonConstants.PRODUCT_FP5121T:
                case CommonConstants.PRODUCT_FP5121TN:

                case CommonConstants.PRODUCT_OIS45_Plus:
                case CommonConstants.PRODUCT_OIS45E_Plus:
                case CommonConstants.PRODUCT_TRPMIU0400E:
                case CommonConstants.PRODUCT_HMC7043A_M:

                case CommonConstants.PRODUCT_OIS70_Plus:
                case CommonConstants.PRODUCT_OIS70E_Plus:
                case CommonConstants.PRODUCT_TRPMIU0700E:
                case CommonConstants.PRODUCT_HMC7070A_M:

                case CommonConstants.PRODUCT_OIS120A:

                case CommonConstants.PRODUCT_OIS43E_Plus:
                case CommonConstants.PRODUCT_OIS72E_Plus:
                case CommonConstants.PRODUCT_OIS100E_Plus:
                #region Hitachi Hi-Rel Vijay
                case CommonConstants.PRODUCT_HH5P_H43_NS:
                case CommonConstants.PRODUCT_HH5P_H43_S:
                case CommonConstants.PRODUCT_HH5P_H70_NS:
                case CommonConstants.PRODUCT_HH5P_H70_S:
                case CommonConstants.PRODUCT_HH5P_H100_NS:
                case CommonConstants.PRODUCT_HH5P_H100_S:
                case CommonConstants.PRODUCT_HH5P_HP43_NS:
                case CommonConstants.PRODUCT_HH5P_HP70_NS:
                #endregion
                #region Panasonic sammed 2.0
                case CommonConstants.PRODUCT_GTXL07N:
                case CommonConstants.PRODUCT_GTXL10N:
                #endregion
                    retValue = true;
                    break;
            }
            return retValue;
        }
        #endregion
        #region SS_FTP
        public static bool isProductSupportsFTP(int ProdutID)
        {
            bool retValue = false;
            switch (ProdutID)
            {
                //case CommonConstants.PRODUCT_FP3043T:
                case CommonConstants.PRODUCT_FP3043TN:
                //#region FP3043_ExpansionSeries Vijay
                //case CommonConstants.PRODUCT_FP3043T_E:

                //#endregion
                case CommonConstants.PRODUCT_OIS43E_Plus:

                //case CommonConstants.PRODUCT_FP3070T:
                case CommonConstants.PRODUCT_FP3070TN:

                case CommonConstants.PRODUCT_OIS72E_Plus:

                //case CommonConstants.PRODUCT_FP3102T:
                case CommonConstants.PRODUCT_FP3102TN:
                case CommonConstants.PRODUCT_FP3043TN_E://SY-FP3_PlugableIO_Product_addition
                case CommonConstants.PRODUCT_FP3070TN_E://SY-FP3_PlugableIO_Product_addition
                case CommonConstants.PRODUCT_FP3102TN_E://SY-FP3_PlugableIO_Product_addition
                case CommonConstants.PRODUCT_OIS100E_Plus:
                #region Hitachi Hi-Rel Vijay
                case CommonConstants.PRODUCT_HH5P_H43_S:
                case CommonConstants.PRODUCT_HH5P_H70_S:
                case CommonConstants.PRODUCT_HH5P_H100_S:
                #endregion

                //case CommonConstants.PRODUCT_FP5043T:
                //case CommonConstants.PRODUCT_FP5043T_E:
                //case CommonConstants.PRODUCT_FP5043TN:
                //case CommonConstants.PRODUCT_OIS45_Plus:
                //case CommonConstants.PRODUCT_FP5043TN_E:
                //case CommonConstants.PRODUCT_OIS45E_Plus:

                //case CommonConstants.PRODUCT_FP5070T:
                //case CommonConstants.PRODUCT_FP5070T_E:
                //case CommonConstants.PRODUCT_FP5070TN:
                //case CommonConstants.PRODUCT_OIS70_Plus:
                //case CommonConstants.PRODUCT_FP5070TN_E:
                //case CommonConstants.PRODUCT_OIS70E_Plus:

                //case CommonConstants.PRODUCT_FP5121T:
                //case CommonConstants.PRODUCT_FP5121TN:
                //case CommonConstants.PRODUCT_OIS120A:
                //case CommonConstants.PRODUCT_FL100:

                case CommonConstants.PRODUCT_FL055:
                case CommonConstants.PRODUCT_FL050_V2://removed.confirmed from rishi and abhijit //24.10.2016_Vijay

                    retValue = true;
                    break;
            }
            return retValue;
        }
        public static bool isProductSupportsFTPSDCard(int ProdutID)
        {
            bool retValue = false;
            switch (ProdutID)
            {
                //case CommonConstants.PRODUCT_FP3043T:
                case CommonConstants.PRODUCT_FP3043TN:
                case CommonConstants.PRODUCT_OIS43E_Plus:
                #region FP3043_ExpansionSeries Vijay
                //case CommonConstants.PRODUCT_FP3043T_E:
                //case CommonConstants.PRODUCT_FP3043TN_E:
                #endregion
                //case CommonConstants.PRODUCT_FP3070T:
                case CommonConstants.PRODUCT_FP3070TN:
                case CommonConstants.PRODUCT_OIS72E_Plus:

                //case CommonConstants.PRODUCT_FP3102T:
                case CommonConstants.PRODUCT_FP3102TN:
                case CommonConstants.PRODUCT_OIS100E_Plus:

                case CommonConstants.PRODUCT_FL055:
                case CommonConstants.PRODUCT_FL050_V2: //24.10.2016_Vijay

                case CommonConstants.PRODUCT_FP3043TN_E://SY-FP3_PlugableIO_Product_addition
                case CommonConstants.PRODUCT_FP3070TN_E://SY-FP3_PlugableIO_Product_addition
                case CommonConstants.PRODUCT_FP3102TN_E://SY-FP3_PlugableIO_Product_addition
                #region Hitachi Hi-Rel Vijay
                case CommonConstants.PRODUCT_HH5P_H43_S:
                case CommonConstants.PRODUCT_HH5P_H70_S:
                case CommonConstants.PRODUCT_HH5P_H100_S:
                #endregion
                    retValue = true;
                    break;
            }
            return retValue;
        }
        public static bool isProductSupportsFTPUSB(int ProdutID)
        {
            bool retValue = false;
            switch (ProdutID)
            {
                case CommonConstants.PRODUCT_FP3043T:
                case CommonConstants.PRODUCT_FP3043TN:
                #region FP3043_ExpansionSeries Vijay
                case CommonConstants.PRODUCT_FP3043T_E:
                case CommonConstants.PRODUCT_FP3043TN_E:
                #endregion

                #region SY-FP3_PlugableIO_Product_addition
                case CommonConstants.PRODUCT_FP3070T_E:
                case CommonConstants.PRODUCT_FP3070TN_E:
                case CommonConstants.PRODUCT_FP3102T_E:
                case CommonConstants.PRODUCT_FP3102TN_E:
                #endregion
                case CommonConstants.PRODUCT_OIS43E_Plus:

                case CommonConstants.PRODUCT_FP3070T:
                case CommonConstants.PRODUCT_FP3070TN:
                case CommonConstants.PRODUCT_OIS72E_Plus:

                case CommonConstants.PRODUCT_FP3102T:
                case CommonConstants.PRODUCT_FP3102TN:
                case CommonConstants.PRODUCT_OIS100E_Plus:
                #region Hitachi Hi-Rel Vijay
                case CommonConstants.PRODUCT_HH5P_H43_NS:
                case CommonConstants.PRODUCT_HH5P_H43_S:
                case CommonConstants.PRODUCT_HH5P_H70_NS:
                case CommonConstants.PRODUCT_HH5P_H70_S:
                case CommonConstants.PRODUCT_HH5P_H100_NS:
                case CommonConstants.PRODUCT_HH5P_H100_S:
                #endregion
                //case CommonConstants.PRODUCT_FP5043T:
                //case CommonConstants.PRODUCT_FP5043T_E:
                //case CommonConstants.PRODUCT_FP5043TN:
                //case CommonConstants.PRODUCT_OIS45_Plus:
                //case CommonConstants.PRODUCT_FP5043TN_E:
                //case CommonConstants.PRODUCT_OIS45E_Plus:

                //case CommonConstants.PRODUCT_FP5070T:
                //case CommonConstants.PRODUCT_FP5070T_E:
                //case CommonConstants.PRODUCT_FP5070TN:
                //case CommonConstants.PRODUCT_OIS70_Plus:
                //case CommonConstants.PRODUCT_FP5070TN_E:
                //case CommonConstants.PRODUCT_OIS70E_Plus:

                //case CommonConstants.PRODUCT_FP5121T:
                //case CommonConstants.PRODUCT_FP5121TN:
                //case CommonConstants.PRODUCT_OIS120A:

                case CommonConstants.PRODUCT_FL100:
                case CommonConstants.PRODUCT_GPU230_3S://SD_Toshiba_US_18Nov16
                    retValue = true;
                    break;
            }
            return retValue;
        }
        public static bool isProductSupportsFTPCOM2(int ProdutID)
        {
            bool retValue = false;
            switch (ProdutID)
            {
                case CommonConstants.PRODUCT_FP3070TN:
                case CommonConstants.PRODUCT_OIS72E_Plus:

                case CommonConstants.PRODUCT_FP3102TN:
                case CommonConstants.PRODUCT_OIS100E_Plus:

                case CommonConstants.PRODUCT_FP3070TN_E://SY-FP3_PlugableIO_Product_addition
                case CommonConstants.PRODUCT_FP3102TN_E://SY-FP3_PlugableIO_Product_addition
                #region Hitachi Hi-Rel Vijay
                case CommonConstants.PRODUCT_HH5P_H70_S:
                case CommonConstants.PRODUCT_HH5P_H100_S:
                #endregion
                    retValue = true;
                    break;
            }
            return retValue;
        }
        #endregion
        #region ShitalG Serial Monitoring Changes 29 April 2013
        public static bool IsPLCSupportedFor5Series(int ProductId, int PLCCode)
        {

            if (ClassList.CommonConstants.IsProductMX257_Based(ProductId))
            {
                if (PLCCode == 184)
                    return false;
            }
            return true;
        #endregion
        }
        #region SS_ReconnectCntrl
        public static bool isProductSupportsReconnectControl(int pProductID)
        {
            #region cmntd
            //bool retValue = true;
            //switch (ProdutID)
            //{
            //    case CommonConstants.PRODUCT_FP4057T:
            //    case CommonConstants.PRODUCT_FP4057TN:
            //    case CommonConstants.PRODUCT_FP4057TN_E:

            //    case CommonConstants.PRODUCT_FP4035T:
            //    case CommonConstants.PRODUCT_FP4035TN:
            //    case CommonConstants.PRODUCT_FP4035TN_E:

            //    case CommonConstants.PRODUCT_FL010:
            //    case CommonConstants.PRODUCT_FL050:
            //    case CommonConstants.PRODUCT_FL010:
            //        retValue = false;
            //        break;
            //}
            //return retValue;
            #endregion
            switch (pProductID)
            {

                case CommonConstants.PRODUCT_FP3043T:
                case CommonConstants.PRODUCT_FP3043TN:
                case CommonConstants.PRODUCT_FP3070T:
                case CommonConstants.PRODUCT_FP3070TN:
                case CommonConstants.PRODUCT_FP3102T:
                case CommonConstants.PRODUCT_FP3102TN:
                #region SS Support added for new products
                case CommonConstants.PRODUCT_FP3043T_E:
                case CommonConstants.PRODUCT_FP3043TN_E:
                case CommonConstants.PRODUCT_FP3070T_E:
                case CommonConstants.PRODUCT_FP3070TN_E:
                case CommonConstants.PRODUCT_FP3102T_E:
                case CommonConstants.PRODUCT_FP3102TN_E:
                #endregion
                case CommonConstants.PRODUCT_FP5043T:
                case CommonConstants.PRODUCT_FP5043T_E:
                case CommonConstants.PRODUCT_FP5043TN:
                case CommonConstants.PRODUCT_FP5043TN_E:
                case CommonConstants.PRODUCT_FP5070T:
                case CommonConstants.PRODUCT_FP5070T_E:
                case CommonConstants.PRODUCT_FP5070TN:
                case CommonConstants.PRODUCT_FP5070TN_E:
                case CommonConstants.PRODUCT_FP5121T:
                case CommonConstants.PRODUCT_FP5121TN:

                case CommonConstants.PRODUCT_FL100:

                case CommonConstants.PRODUCT_FL005_0808RP:
                case CommonConstants.PRODUCT_FL005_0808RP0201L:
                case CommonConstants.PRODUCT_FL005_0604P:
                case CommonConstants.PRODUCT_FL005_0808P:
                case CommonConstants.PRODUCT_FL005_0808P0201L:
                case CommonConstants.PRODUCT_FL005_0604N:
                case CommonConstants.PRODUCT_FL005_0808N:
                case CommonConstants.PRODUCT_FL005_0808N0201L:
                case CommonConstants.PRODUCT_FL005_0808RP0402U:
                case CommonConstants.PRODUCT_FL005_1616RP0201L:
                case CommonConstants.PRODUCT_FL005_1616P0201L:
                case CommonConstants.PRODUCT_FL005_1616N0201L:
                case CommonConstants.PRODUCT_FL005_1616RP:
                case CommonConstants.PRODUCT_FL005_1616P:
                case CommonConstants.PRODUCT_FL005_1616P0201L_S1:
                    return true;
                    break;
                default:
                    break;
            }
            return false;
        }
        public static bool isPLCSupportsReconnectControl(int pProtocol)
        {
            bool retValue = true;
            switch (pProtocol)
            {
                case 191:
                    return false;
                default:
                    break;
            }
            return true;
        }
        public class StructReconnectNodeComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                if (!(x is CommonConstants.stReconnectNode) || !(y is CommonConstants.stReconnectNode)) return 0;
                CommonConstants.stReconnectNode a = (CommonConstants.stReconnectNode)x;
                CommonConstants.stReconnectNode b = (CommonConstants.stReconnectNode)y;

                return a._usAddr.CompareTo(b._usAddr);
            }
        }
        #endregion
        public static bool IsBothTagOf4Bytes(ArrayList pTagInfoList, String strTagNameA, String strTagNameB)
        {
            int index = 0;
            int BytesA = 0;
            int BytesB = 0;
            for (index = 0; index < pTagInfoList.Count; index++)
            {
                if (((CommonConstants.Prizm3TagStructure)pTagInfoList[index])._TagName == strTagNameA)
                {
                    BytesA = ((CommonConstants.Prizm3TagStructure)pTagInfoList[index])._NoOfBytes;
                    break;
                }
            }

            for (index = 0; index < pTagInfoList.Count; index++)
            {
                if (((CommonConstants.Prizm3TagStructure)pTagInfoList[index])._TagName == strTagNameB)
                {
                    BytesB = ((CommonConstants.Prizm3TagStructure)pTagInfoList[index])._NoOfBytes;
                    break;
                }
            }
            if ((BytesA == 4) && (BytesB == 4))
                return true;

            return false;
        }

        #region LREAL_New_SY
        public static bool IsBothTagOf8Bytes(ArrayList pTagInfoList, String strTagNameA, String strTagNameB)
        {
            int index = 0;
            int BytesA = 0;
            int BytesB = 0;
            for (index = 0; index < pTagInfoList.Count; index++)
            {
                if (((CommonConstants.Prizm3TagStructure)pTagInfoList[index])._TagName == strTagNameA)
                {
                    BytesA = ((CommonConstants.Prizm3TagStructure)pTagInfoList[index])._NoOfBytes;
                    break;
                }
            }

            for (index = 0; index < pTagInfoList.Count; index++)
            {
                if (((CommonConstants.Prizm3TagStructure)pTagInfoList[index])._TagName == strTagNameB)
                {
                    BytesB = ((CommonConstants.Prizm3TagStructure)pTagInfoList[index])._NoOfBytes;
                    break;
                }
            }
            if ((BytesA == 8) && (BytesB == 8))
                return true;

            return false;
        }
        #endregion

        #region TrueTypeFontChange SP
        public static bool IsProductSupportTrueTypeFont(int pProductID)
        {
            bool flag = false;
            if (IsProductSupportedFP4035(pProductID) || IsProductSupportedFP4057(pProductID)
             || IsProductSupportedFP5043(pProductID) || IsProductSupportedFP5070(pProductID)
             || IsProductSupportedFP5121(pProductID)
            #region New FP3035 Product Series
 || ClassList.CommonConstants.IsProductSupportedFP3035(pProductID)
            #endregion
)
            {
                flag = true;
            }
            //Lohia_710_change
            if (ClassList.CommonConstants.ProductDataInfo.iProductID == ClassList.CommonConstants.PRODUCT_PRIZM_710_S0)
                flag = true;

            return flag;
        }
        #endregion

        #region Shweta 21.12.09
        public static string GetSeparateTagNameFromTagList(string pstrTag)
        {
            //sammed_Hide_Tag Address
            string wholeWaitTag = pstrTag;
            if (ClassList.CommonConstants.g_Support_IEC_Ladder == true)
            {
                return wholeWaitTag;
            }
            int leftParenIndexWaitTag = wholeWaitTag.IndexOf("(") + 1;
            string strnewTagNameWaitTag = wholeWaitTag.Substring(leftParenIndexWaitTag, wholeWaitTag.LastIndexOf(")") - leftParenIndexWaitTag);
            return strnewTagNameWaitTag;
            //
        }
        public static int ReadWord(FileStream pFileStream)
        {
            int intValue = 0;

            byte[] byteBuff = new byte[2];
            pFileStream.Read(byteBuff, 0, 2);
            intValue = CommonConstants.MAKEWORD(byteBuff);

            return intValue;

        }
        public static bool IsProductSupported(int ProductId)
        {
            //   return true;

            String FileName = @"ProductId.xml";

            String TableName = "Product";

            DataSet objDataSet = new DataSet();


            int ProdId = 0;

            System.IO.FileStream fsReadXml = null;
            if (File.Exists(FileName) == false)
            {
                return true;
            }

            try
            {
                fsReadXml = new System.IO.FileStream(FileName, FileMode.Open);

                objDataSet.ReadXml(fsReadXml);

                DataTable objDataTable = objDataSet.Tables[TableName];

                for (int i = 0; i < objDataTable.Rows.Count; i++)
                {
                    ProdId = Convert.ToInt32(objDataTable.Rows[i][0].ToString().Trim());

                    if (ProdId == ProductId)
                    {
                        fsReadXml.Close();
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                // MessageBox.Show("Error in opening file ProductID.xml");
                if (fsReadXml != null)
                    fsReadXml.Close();
                return true;
            }
            if (fsReadXml != null)
                fsReadXml.Close();
            return false;
        }

        public static bool Is4030MTHorizontalProduct(int pProductID)
        {
            bool Flag = false;

            switch (pProductID)
            {
                case CommonConstants.PRODUCT_FP4030MT_HORIZONTAL:
                case CommonConstants.PRODUCT_FP4030MT_S1_HORIZONTAL:
                case CommonConstants.PRODUCT_FP4030MT_L0808RN_A0201: //FP4030MT_L0808RN_A0201_addition_Vijay
                case CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201: //FP4030MT_L0808RP_A0201_addition_Vijay
                case CommonConstants.PRODUCT_FP4030MT_REV1://New Product addition FP4030MT- Rev 1
                case CommonConstants.PRODUCT_FP4030MT_L0808RN: //New Product addition FP4030MT-L0808RN/RP Vijay
                case CommonConstants.PRODUCT_FP4030MT_L0808RP: //New Product addition FP4030MT-L0808RN/RP Vijay
                case CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201_S0: //New Product Addition FP4030MT-L0808RP-A0201-S0 Vijay
                case CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201L://FP4030MT_L0808RP_A0201L_addition_sammed //Vijay_23.10.13
                #region New Product Addtion FP4030MT_L0808P/FP4030MT_L0808P_A0201U Vijay
                case CommonConstants.PRODUCT_FP4030MT_L0808P:
                case CommonConstants.PRODUCT_FP4030MT_L0808P_A0201U:
                #endregion
                case CommonConstants.PRODUCT_FP4030MT_L0808P_A0402L://Suyash_Product_Addition_FP4030MT_L0808P_A0402L
                //Toshiba_US New product Addition
                case CommonConstants.PRODUCT_OIS40_Plus_HORIZONTAL:
                case CommonConstants.PRODUCT_OIS42_Plus: //New_Product_Addition Vijay(01.03.2013)
                case CommonConstants.PRODUCT_OIS42L_Plus: //New_Product_Addition Vijay(12.09.2013)
                #region Hitachi Hi-Rel Vijay
                case CommonConstants.PRODUCT_HH5P_HP300201U0808_RP:
                case CommonConstants.PRODUCT_HH5P_HP300201L0808_RP:
                #endregion
                    Flag = true;
                    break;
            }
            return Flag;
        }

        public static bool Is4030MTVerticalProduct(int pProductID)
        {
            bool Flag = false;

            switch (pProductID)
            {
                case CommonConstants.PRODUCT_FP4030MT_VERTICAL:
                case CommonConstants.PRODUCT_FP4030MT_S1_VERTICAL:
                #region New FP4030MT Vertical Series Addition Vijay
                case CommonConstants.PRODUCT_FP4030MT_REV1_VERTICAL:
                case CommonConstants.PRODUCT_FP4030MT_L0808RN_A0201_VERTICAL:
                case CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201_VERTICAL:
                case CommonConstants.PRODUCT_FP4030MT_L0808RN_VERTICAL:
                case CommonConstants.PRODUCT_FP4030MT_L0808RP_VERTICAL:
                #endregion
                case CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201L_VERTICAL://FP4030MT_L0808RP_A0201L(Vertical)_addition_sammed
                //Toshiba_US New product Addition
                case CommonConstants.PRODUCT_OIS40_Plus_VERTICAL:
                    Flag = true;
                    break;
            }
            return Flag;
        }

        public static bool IsScreenSaverSupported(int pProductID)
        {
            int value = 0;

            DataRow[] drMemory;
            drMemory = ClassList.CommonConstants.dsRecentProjectList.Tables["UnitInformation"].Select("ModelNo='" + pProductID + "'");


            foreach (DataRow dr in drMemory)
            {
                value = Convert.ToInt32(dr["ScreenSaver"]);

            }

            if (value == 1)
                return true;
            else
                return false;
        }

        //Import_Export change SP
        public static bool IsProductSupportsCOMPorts(int pProductID, string strCOMPort)
        {
            bool value = false;
            string _strCOMPort = strCOMPort.ToUpper();
            DataRow[] drMemory;
            drMemory = ClassList.CommonConstants.dsRecentProjectList.Tables["UnitInformation"].Select("ModelNo='" + pProductID + "'");
            foreach (DataRow dr in drMemory)
            {
                value = Convert.ToBoolean(dr[_strCOMPort].ToString().ToLower());
            }
            return value;
        }
        //END


        public static bool IsUSBLogUpload_TaskSupported(int ProdutID)
        {
            if (IsUSBHostSupported(ProdutID))
            {
                if (IsProductSupportsDataLogger(ProdutID))
                    return true;
            }
            return false;
        }
        #region SD_Card_Functionality Vijay
        public static bool IsSDCardLogUpload_TaskSupported(int ProductId)
        {
            bool flag = false;

            switch (ProductId)
            {
                case CommonConstants.PRODUCT_FP3043TN:
                case CommonConstants.PRODUCT_FP3070TN:
                case CommonConstants.PRODUCT_FP3102TN:
                #region OIS3Series_Vijay
                case CommonConstants.PRODUCT_OIS43E_Plus:
                case CommonConstants.PRODUCT_OIS72E_Plus:
                case CommonConstants.PRODUCT_OIS100E_Plus:
                #endregion
                #region Hitachi Hi-Rel Vijay
                case CommonConstants.PRODUCT_HH5P_H43_S:
                case CommonConstants.PRODUCT_HH5P_H70_S:
                case CommonConstants.PRODUCT_HH5P_H100_S:
                #endregion
                #region Panasonic sammed 2.0
                case CommonConstants.PRODUCT_GTXL07N:
                case CommonConstants.PRODUCT_GTXL10N:
                #endregion
                case CommonConstants.PRODUCT_FL055://FL055_Product_Addition_Suyash
                case CommonConstants.PRODUCT_FL050_V2: //24.10.2016_Vijay
                    flag = true;
                    break;
            }
            return flag;
        }
        #endregion
        public static bool IsSDCardUploadTaskSupported(int ProductId)//SS_SDCardUpload
        {
            bool flag = false;

            switch (ProductId)
            {
                case CommonConstants.PRODUCT_FL055:
                case CommonConstants.PRODUCT_FL050_V2: //24.10.2016_Vijay
                    flag = true;
                    break;
            }
            return flag;
        }
        public static bool IsProductSupport_IOInterrupt_Block1(int ProductId)
        {
            bool flag = false;

            switch (ProductId)
            {
                case CommonConstants.PRODUCT_FL010:
                //case CommonConstants.PRODUCT_FL051: //Remove_Product Vijay(06.02.14)
                case CommonConstants.PRODUCT_FL011_S1:
                case CommonConstants.PRODUCT_FL011_S4: //New_ProductAdd_Vijay
                case CommonConstants.PRODUCT_FL011:
                case CommonConstants.PRODUCT_FL011_S3:
                #region Vijay_02.06.14
                case CommonConstants.PRODUCT_GPU288_3S:
                case CommonConstants.PRODUCT_GPU232_3S:
                case CommonConstants.PRODUCT_MICRO_PLC: //TRSPUX10A
                case CommonConstants.PRODUCT_PLC7008A_ML:
                    flag = true;
                    break;
                #endregion
                    //case CommonConstants.PRODUCT_FL055://FL055_Product_Addition_Suyash1 //24.10.2016_Vijay
                    if (ClassList.CommonConstants.g_Support_IEC_Ladder == false)
                        flag = true;
                    else
                        flag = false;
                    break;
            }

            return flag;
        }

        public static bool IsProductSupport_IOInterrupt_Block2(int ProductId)
        {
            bool flag = false;

            switch (ProductId)
            {
                case CommonConstants.PRODUCT_FL010:
                //case CommonConstants.PRODUCT_FL051: //Remove_Product Vijay(06.02.14)
                case CommonConstants.PRODUCT_FL011_S1:
                case CommonConstants.PRODUCT_FL011_S4: //New_ProductAdd_Vijay
                case CommonConstants.PRODUCT_FL011:
                case CommonConstants.PRODUCT_FL011_S3:
                #region Vijay_02.06.14
                case CommonConstants.PRODUCT_GPU288_3S:
                case CommonConstants.PRODUCT_GPU232_3S:
                case CommonConstants.PRODUCT_MICRO_PLC: //TRSPUX10A
                case CommonConstants.PRODUCT_PLC7008A_ML:
                #endregion
                    flag = true;
                    break;
                    //case CommonConstants.PRODUCT_FL055://FL055_Product_Addition_Suyash1 //24.10.2016_Vijay
                    if (ClassList.CommonConstants.g_Support_IEC_Ladder == false)
                        flag = true;
                    else
                        flag = false;
                    break;
            }

            return flag;
        }

        public static int GetExpansionSlotCount(int pProductID)
        {
            int SlotCount = 0;
            switch (pProductID)
            {
                #region New PLC Models AMIT
                case CommonConstants.PRODUCT_FL011_S3:
                #region FP3043_ExpansionSeries Vijay
                case CommonConstants.PRODUCT_FP3043T_E:
                case CommonConstants.PRODUCT_FP3043TN_E:
                #endregion
                case CommonConstants.PRODUCT_HMC3043A_M: //Maple_ProductAddition_Vijay
                    SlotCount = 1;
                    break;
                #endregion

                case CommonConstants.PRODUCT_MICRO_PLC:
                case CommonConstants.PRODUCT_MICRO_PLC_ETHERNET:
                case ClassList.CommonConstants.PRODUCT_FL010:
                //case ClassList.CommonConstants.PRODUCT_FL011_S1:
                //case ClassList.CommonConstants.PRODUCT_FL011:
                case ClassList.CommonConstants.PRODUCT_FL050:
                //case ClassList.CommonConstants.PRODUCT_FL050_V2://New Product FL050 V2 SammedB //24.10.2016_Vijay
                //case ClassList.CommonConstants.PRODUCT_FL051: //Remove_Product Vijay(06.02.14)
                #region ToshibaUS PLC Models
                case ClassList.CommonConstants.PRODUCT_GPU288_3S:
                case ClassList.CommonConstants.PRODUCT_GPU200_3S:
                #endregion

                case ClassList.CommonConstants.PRODUCT_PLC7008A_ML:
                case ClassList.CommonConstants.PRODUCT_PLC7008A_ME:
                    SlotCount = 8;
                    break;
                case CommonConstants.PRODUCT_FP4030MR_E:
                //case CommonConstants.PRODUCT_FP4030MN_E://New_Product_Addition M&R AMIT
                case CommonConstants.PRODUCT_FP4035T_E:
                #region New_Ethernet_Products_AMIT
                case CommonConstants.PRODUCT_FP4035TN_E:
                #endregion
                case CommonConstants.PRODUCT_TRPMIU0300A:
                case CommonConstants.PRODUCT_FH9030MR_E:
                case CommonConstants.PRODUCT_FH9035T_E:
                #region New FP Models-43&70 SnehalM
                case CommonConstants.PRODUCT_FP5043T_E:
                case CommonConstants.PRODUCT_FP5043TN_E:

                #endregion
                case CommonConstants.PRODUCT_HH5P_HP43_NS: //Hitachi Hi-Rel Vijay
                //Toshiba-Japan_Product
                case CommonConstants.PRODUCT_TRPMIU0400E:
                //End

                #region Toshiba US products SnehalM
                case CommonConstants.PRODUCT_OIS22_Plus:
                case CommonConstants.PRODUCT_OIS55_Plus:
                //Toshiba_US New product Addition
                case CommonConstants.PRODUCT_OIS45E_Plus:
                #endregion

                case CommonConstants.PRODUCT_HMC7030A_M:
                case CommonConstants.PRODUCT_HMC7035A_M:

                //New Ethernet Models - SnehaK
                case CommonConstants.PRODUCT_TRPMIU0300E:
                //End
                #region SY-FP3_PlugableIO_Product_addition
                case CommonConstants.PRODUCT_FP3070T_E:
                case CommonConstants.PRODUCT_FP3070TN_E:
                #endregion
                case CommonConstants.PRODUCT_HMC3070A_M: //Maple_ProductAddition_Vijay
                    SlotCount = 3;
                    break;
                //case CommonConstants.PRODUCT_FP4057M_E:
                case CommonConstants.PRODUCT_FP4057T_E:
                #region New_Ethernet_Products_AMIT
                case CommonConstants.PRODUCT_FP4057TN_E:
                #endregion
                #region New_Product_Addition_AllBodySoltn AMIT
                case CommonConstants.PRODUCT_FP4057T_E_S1:
                #endregion
                #region New_Product_Addition_Vertical Vijay
                case CommonConstants.PRODUCT_FP4057T_E_VERTICAL:
                #endregion
                case CommonConstants.PRODUCT_TRPMIU0500A:
                case CommonConstants.PRODUCT_FH9057T_E:
                #region New FP Models-43&70 SnehalM
                case CommonConstants.PRODUCT_FP5070T_E:
                case CommonConstants.PRODUCT_FP5070TN_E:
                #endregion
                case CommonConstants.PRODUCT_HH5P_HP70_NS: //Hitachi Hi-Rel Vijay
                case CommonConstants.PRODUCT_FP5070T_E_S2://New FP5070T-E-S2 product Addition Suyash
                #region Toshiba US products SnehalM
                case CommonConstants.PRODUCT_OIS60_Plus:
                case CommonConstants.PRODUCT_OIS70E_Plus:
                #endregion
                case CommonConstants.PRODUCT_HMC7057A_M:
                //New Ethernet Models - SnehaK                
                case CommonConstants.PRODUCT_TRPMIU0500E:
                //End

                //Toshiba-Japan_Product
                case CommonConstants.PRODUCT_TRPMIU0700E:
                //End
                #region SY-FP3_PlugableIO_Product_addition
                case CommonConstants.PRODUCT_FP3102T_E:
                case CommonConstants.PRODUCT_FP3102TN_E:
                #endregion
                case CommonConstants.PRODUCT_HMC3102A_M: //Maple_ProductAddition_Vijay
                    SlotCount = 5;
                    break;

                #region New FL100 Model SAMMED
                case ClassList.CommonConstants.PRODUCT_FL100:
                case ClassList.CommonConstants.PRODUCT_CPU_300: //PLC_Direct Vijay
                case ClassList.CommonConstants.PRODUCT_MLC3_E: //Maple_ProductAddition_Vijay
                    SlotCount = 16;
                    break;
                #endregion

                #region New_Product_Addition Vijay(01.03.2013)
                case ClassList.CommonConstants.PRODUCT_GPU230_3S:
                    SlotCount = 16;
                    break;
                #endregion
                case ClassList.CommonConstants.PRODUCT_FL055://FL055_Product_Addition_Suyash
                case ClassList.CommonConstants.PRODUCT_FL050_V2: //24.10.2016_Vijay
                #region FL005 Expandable PLC Series Vijay
                case ClassList.CommonConstants.PRODUCT_FL005_0808RP0402U:
                case ClassList.CommonConstants.PRODUCT_FL005_1616RP0201L:
                case ClassList.CommonConstants.PRODUCT_FL005_1616P0201L:
                case ClassList.CommonConstants.PRODUCT_FL005_1616N0201L:
                case ClassList.CommonConstants.PRODUCT_FL005_1616RP:
                case ClassList.CommonConstants.PRODUCT_FL005_1616P:
                case ClassList.CommonConstants.PRODUCT_FL005_1616P0201L_S1:
                #region Hitachi Hi-Rel Vijay
                case ClassList.CommonConstants.PRODUCT_HH5L_B1616D_P:
                case ClassList.CommonConstants.PRODUCT_HH5L_B1616D_RP:
                case ClassList.CommonConstants.PRODUCT_HH5L_B0201A1616D_RP:
                case ClassList.CommonConstants.PRODUCT_HH5L_B0402AU0808D_RP:
                case ClassList.CommonConstants.PRODUCT_HH1L_000:
                #endregion
                #region Maple_ProductAddition_Vijay
                case CommonConstants.PRODUCT_MLC2_E0404P0802T:
                case CommonConstants.PRODUCT_MLC1_F1616P0201:
                case CommonConstants.PRODUCT_MLC1_E1616P:
                case CommonConstants.PRODUCT_MLC1_E1616Y:
                case CommonConstants.PRODUCT_MLC1_E0808Y0402T:
                case CommonConstants.PRODUCT_MLC1_E1616P0201:
                case CommonConstants.PRODUCT_MLC1_E1616N0201:
                case CommonConstants.PRODUCT_MLC1_E1616Y0201:
                #endregion
                    SlotCount = 16;
                    break;
                #endregion

                #region New_Product_Addition Parag(9.12.2014)
                case ClassList.CommonConstants.PRODUCT_GPU120_3S:
                case ClassList.CommonConstants.PRODUCT_GPU122_3S: //New_Product_Addition Vijay(07.04.2015)
                    SlotCount = 16;
                    break;
                #endregion
                #region //Mapple Customization 2.0_Sanjay
                case CommonConstants.PRODUCT_HMC7043A_M:
                    SlotCount = 3;
                    break;
                case CommonConstants.PRODUCT_HMC7070A_M:
                    SlotCount = 5;
                    break;
                #endregion

                    break;
            }
            return SlotCount;
        }

        public static String GetDeviceNodeNameFromXML()
        {

            string strFileName = @"DefaultNodeTag.xml";
            System.IO.FileStream fsReadXml = null;
            String strMesasge = "";
            String TableName = "";
            DataSet objDataSet = new DataSet();

            //Straton_change Haresh
            if (ClassList.CommonConstants.g_Support_IEC_Ladder == true)
                strFileName = @"DefaultNodeTag_IEC.xml";
            //
            String strNodeName = "";
            try
            {
                fsReadXml = new System.IO.FileStream(strFileName, System.IO.FileMode.Open);


            }
            catch (Exception ex)
            {

                strMesasge += "Failed to Open File " + strFileName;
                MessageBox.Show(strMesasge);
                return strNodeName;

            }
            objDataSet.ReadXml(fsReadXml);
            TableName = "NodeData";

            DataTable objDataTable = objDataSet.Tables[TableName];
            strNodeName = objDataTable.Rows[0][1].ToString().Trim();
            fsReadXml.Close();
            if (strNodeName.Length == 0)
            {
                MessageBox.Show("Failed to initialize device node name.");
            }
            return strNodeName;
        }


        #endregion
        //FP_Product_Conversion
        #region Version2.0Incr1_ProductConversion

        /// <summary>
        /// Is COM1 Supported By Destination Model. True if Yes, else False.
        /// </summary>
        /// <param name="pObjPortValues"></param>
        /// <returns></returns>
        public static bool IsCOM1SupportedByDestinationModel()
        {
            if (PortValuesObject._lstDestPorts.Contains(ClassList.Port.COM1))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Is COM2 Supported By Destination Model. True if Yes, else False.
        /// </summary>
        /// <param name="pObjPortValues"></param>
        /// <returns></returns>
        public static bool IsCOM2SupportedByDestinationModel()
        {
            if (PortValuesObject._lstDestPorts.Contains(ClassList.Port.COM2))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Is Ethernet Supported By Destination Model. True if Yes, else False.
        /// </summary>
        /// <param name="pObjPortValues"></param>
        /// <returns></returns>
        public static bool IsEthernetSupportedByDestinationModel()
        {
            if (PortValuesObject._lstDestPorts.Contains(ClassList.Port.Ethernet))
                return true;
            else
                return false;
        }

        public static bool IsCom1Supported(int ProductID)
        {
            DataRow[] drProductID = ClassList.CommonConstants.dsRecentProjectList.Tables["Unitinformation"].Select("ModelNo='" + ProductID + "' and COM1='True'");
            if (drProductID.Length > 0)
                return true;

            return false;
        }

        public static bool IsCom3Supported(int ProductID)
        {
            DataRow[] drProductID = ClassList.CommonConstants.dsRecentProjectList.Tables["Unitinformation"].Select("ModelNo='" + ProductID + "' and Ethernet='True'");
            if (drProductID.Length > 0)
                return true;

            return false;
        }

        /// <summary>
        /// Is COM1 Supported By Source Model. True if Yes, else False.
        /// </summary>
        /// <param name="pObjPortValues"></param>
        /// <returns></returns>
        public static bool IsCOM1SupportedBySourceModel()
        {
            if (PortValuesObject._lstSourcePorts.Contains(ClassList.Port.COM1))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Is COM2 Supported By Source Model. True if Yes, else False.
        /// </summary>
        /// <param name="pObjPortValues"></param>
        /// <returns></returns>
        public static bool IsCOM2SupportedBySourceModel()
        {
            if (PortValuesObject._lstSourcePorts.Contains(ClassList.Port.COM2))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Is Ethernet Supported By Source Model. True if Yes, else False.
        /// </summary>
        /// <param name="pObjPortValues"></param>
        /// <returns></returns>
        public static bool IsEthernetSupportedBySourceModel()
        {
            if (PortValuesObject._lstSourcePorts.Contains(ClassList.Port.Ethernet))
                return true;
            else
                return false;
        }


        public static byte[,] GetColorArray(int pNoOfColors)
        {
            byte[,] ColorArray;

            switch (pNoOfColors)
            {
                case 2: ColorArray = (byte[,])ClassList.CommonConstants.Col2Supported.Clone();
                    return ColorArray;
                    break;

                case 16: ColorArray = (byte[,])ClassList.CommonConstants.Col16Supported.Clone();
                    return ColorArray;
                    break;
                case 256: ColorArray = (byte[,])ClassList.CommonConstants.Col256Supported.Clone();
                    return ColorArray;
                    break;
                default: ColorArray = (byte[,])ClassList.CommonConstants.Col256Supported.Clone();
                    return ColorArray;
                    break;
            }
        }
        public static bool IsFactoryScreen(int pScreenNumber)
        {
            if (pScreenNumber >= ClassList.CommonConstants.START_COMM_FACTORY_SCREEN && pScreenNumber <= ClassList.CommonConstants.END_FHWT_FACTORY_SCREEN)
                return true;
            else
                return false;
        }
        public static byte GetConversionIndex(byte index, int Source, int Dest)
        {
            int R = 0;
            int G = 0;
            int B = 0;
            byte grayScale = 0;
            byte NewIndex = 0;
            Color objNewColor = new Color();
            Color objcolor = new Color();
            if ((Source == 256) && (Dest == 2))//Color to Mono
            {
                objcolor = Color.FromArgb(CommonConstants.OldProductDataInfo.ColorArray[index, 0], CommonConstants.OldProductDataInfo.ColorArray[index, 1], CommonConstants.OldProductDataInfo.ColorArray[index, 2]);

                grayScale = (byte)((byte)(objcolor.R * 0.3) + (byte)(objcolor.G * 0.59) + (byte)(objcolor.B * 0.11));

                if (grayScale > 128)
                    grayScale = 255;
                else
                    grayScale = 0;

                if (grayScale == 0)
                    NewIndex = 0; //Black
                else
                    NewIndex = 1;//White



            }
            else if ((Dest == 256) && (Source == 2))//Mono to Color
            {
                if (index == 1)
                    NewIndex = 26;
                else
                    NewIndex = 0;


            }

            return NewIndex;
        }

        public static Color GetConversionColor(Color objcolor, int Source, int Dest)
        {
            int R = 0;
            int G = 0;
            int B = 0;
            byte grayScale = 0;
            byte NewIndex = 0;
            Color objNewColor = new Color();

            if ((Source == 256) && (Dest == 2))//Color to Mono
            {
                grayScale = (byte)((byte)(objcolor.R * 0.3) + (byte)(objcolor.G * 0.59) + (byte)(objcolor.B * 0.11));

                if (grayScale > 128)
                    grayScale = 255;
                else
                    grayScale = 0;

                objNewColor = Color.FromArgb(grayScale, grayScale, grayScale);




            }
            else if ((Dest == 256) && (Source == 2))//Mono to Color
            {
                objNewColor = objcolor;


            }

            return objNewColor;
        }
        public static String Conversion_GetTagNameFromTagID(int TagID)
        {
            String strTagName = "";
            for (int i = 0; i < List_DelTagInfo.Count; i++)
            {
                if (((ClassList.CommonConstants.DelTagInfo)List_DelTagInfo[i]).TagID == TagID)
                {
                    strTagName = ((ClassList.CommonConstants.DelTagInfo)List_DelTagInfo[i]).TagName;
                    break;
                }
            }

            return strTagName;
        }
        #endregion Version2.0Incr1_ProductConversion
        public static float ConvertStringToFloat(String strFont)
        {
            float fontSize = 0;
            if (strFont != null)
            {
                if (strFont.Length > 0)
                {
                    if (strFont.Contains(","))
                        strFont = strFont.Replace(",", ".");

                }

            }
            fontSize = Convert.ToSingle(strFont, CultureInfo.InvariantCulture);
            if (fontSize == 825.0) //Added to correct old projects having font value disturbed
            {
                fontSize = 8.25F;
            }
            else if (fontSize == 975.0)
            {
                fontSize = 9.75F;
            }
            else if (fontSize == 1125.0)
            {
                fontSize = 11.25F;
            }
            else if (fontSize == 1425.0)
            {
                fontSize = 14.25F;
            }
            else if (fontSize == 1575.0)
            {
                fontSize = 15.75F;
            }
            else if (fontSize == 2025.0)
            {
                fontSize = 20.25F;
            }
            else if (fontSize == 2175.0)
            {
                fontSize = 21.75F;
            }
            else if (fontSize == 2625.0)
            {
                fontSize = 26.25F;
            }
            else if (fontSize == 2775.0)
            {
                fontSize = 27.75F;
            }


            return fontSize;
        }
        public static bool IsArraySupported(int ProductID)
        {
            if (IsProductMX257_Based(ProductID))
                return true;
            return false;
        }

        #endregion

        //Punit  mar '09
        /// <summary>
        /// Copies the logg data and historical alarm data from usb drive to local drive
        /// </summary>
        /// <param name="pProductID">Product id of the project</param>
        /// <param name="pProjectInfo"></param>
        public static void CopyLoggDataAndHistoricalAlarmFilesFromUSBDrive(int pProductID, ProjectInfo pProjectInfo)
        {
            //string _projectFileName = pProjectInfo.FilePath + "\\" + pProjectInfo.ProjectName;
            string _projectFolderName = pProjectInfo.FilePath;
            string _AlarmFileName = "HISTALARM.BIN";
            string _LoggerFileName = "LOGGER_DATA.BIN";
            if (File.Exists(_projectFolderName + "\\" + _AlarmFileName))
                File.Copy(_projectFolderName + "\\" + _AlarmFileName, "HistAlarmData.BIN", true);
            if (File.Exists(_projectFolderName + "\\" + _LoggerFileName))
                File.Copy(_projectFolderName + "\\" + _LoggerFileName, "Logger.BIN", true);

        }

        //sammed(check logic button)
        public static void SetBlockType(int m_lBlockType)
        {
            m_gBlockType = m_lBlockType;
        }
        //

        #region Add_IECBlockType_From_ProjectProperty_GUI Vijay
        public static void SelBlockType(int selIECBlockType1)
        {
            selIECBlockType = selIECBlockType1;
        }
        #endregion

        #region Sanjay_ProjectTitleChange
        public static string _NewProjectFolderName = "";
        public static int _NewProjectnumber;
        public static string _ProjectFolderName = "";
        public static string _PreviousFolderName = "";
        public static string _TEMPPreviousFolderName = "";
        public static string _IECFoldername = "IEC";//Yadav_Sanjay
        public static bool IsfolderPresent(string FolderPath, ref string _NewFolderPath, ref bool Ispresent)
        {
            int i = 0;
            string Foldername = FolderPath.Remove((FolderPath.Length - 3), 3);
            while (System.IO.Directory.Exists(FolderPath) == true)
            {
                i = ++i;
                _NewProjectnumber = i;
                _NewProjectFolderName = Foldername + i;
                FolderPath = _NewProjectFolderName;
                _NewFolderPath = FolderPath;
            }
            return Ispresent;
        }
        #endregion
        #endregion
        // G9SP_SAFETY_CONTROLLER Ethernet Support SP
        #region G9SP_SAFETY_CONTROLLER Ethernet Support SP
        /// <summary>
        /// This methode use to copy node structure into G9SP node structure.
        /// </summary>
        /// <param name="objNode"></param>
        /// <returns></returns>
        public static ClassList.CommonConstants.G9SPNodeInfo copyComNodeStructureToFins(ClassList.CommonConstants.NodeInfo objNode)
        {
            ClassList.CommonConstants.G9SPNodeInfo objNewNode = new CommonConstants.G9SPNodeInfo();

            objNewNode._iNodeId = objNode._iNodeId;
            objNewNode._strName = objNode._strName;
            objNewNode._usAddress = objNode._usAddress;
            objNewNode._btType = objNode._btType;
            objNewNode._btPort = 3;
            objNewNode._strProtocol = objNode._strProtocol;
            objNewNode._strModel = objNode._strModel;
            objNewNode._btHasTag = objNode._btHasTag;
            objNewNode._strPortName = ClassList.Port.Ethernet.ToString();

            objNewNode._btPLCCode = 0xB1;
            objNewNode._btPLCModel = 1; // Variable depend on user selection of model

            objNewNode._btRegLength = objNode._btRegLength;
            objNewNode._btSpecialData1 = objNode._btSpecialData1; // Applicable to modbus master only
            objNewNode._btSpecialData2 = objNode._btSpecialData2; // Applicable to modbus master only
            objNewNode._btSpecialData3 = objNode._btSpecialData3; // Applicable to modbus master only
            objNewNode._usTotalBlocks = objNode._usTotalBlocks;
            objNewNode._uiEthernetIpAddress = objNode._uiEthernetIpAddress;
            objNewNode._usEthernetPortNumber = 9600;
            objNewNode._usEthernetScanTime = objNode._usEthernetScanTime;
            objNewNode._usEthernetResponseTimeOut = objNode._usEthernetResponseTimeOut;
            objNewNode._btBaudRate = objNode._btBaudRate;
            objNewNode._btParity = objNode._btParity;
            objNewNode._btDataBits = objNode._btDataBits;
            objNewNode._btStopBits = objNode._btStopBits;
            objNewNode._btRetryCount = 3;
            objNewNode._usInterframeDelay = objNode._usInterframeDelay;
            objNewNode._usResponseTime = objNode._usResponseTime;
            objNewNode._btInterByteDelay = objNode._btInterByteDelay;
            objNewNode._btFloatFormat = objNode._btFloatFormat; // Applicable to modbus master only
            objNewNode._btIntFormat = objNode._btIntFormat;// Applicable to modbus master only
            objNewNode._btExpansionType = objNode._btExpansionType;

            objNewNode._usEthernetScanTime = objNode._usInterframeDelay;
            objNewNode._usEthernetResponseTimeOut = objNode._usResponseTime;


            objNewNode._btG9SPSrcNetwork = 0;
            objNewNode._btG9SPSrcNode = 100;
            objNewNode._btG9SPSrcID = 0;
            objNewNode._btG9SPDestNetwork = 0;
            objNewNode._btG9SPDestNode = 0;
            objNewNode._btG9SPDestID = 0;
            objNewNode._btReserved = 0;

            return objNewNode;
        }

        #endregion

        #region Serialization Methods
        public static object RawDeserialize(byte[] rawdatas, Type anytype)
        {
            int rawsize = Marshal.SizeOf(anytype);
            if (rawsize > rawdatas.Length)
                return null;
            IntPtr buffer = Marshal.AllocHGlobal(rawsize);
            Marshal.Copy(rawdatas, 0, buffer, rawsize);
            object retobj = Marshal.PtrToStructure(buffer, anytype);
            Marshal.FreeHGlobal(buffer);
            return retobj;
        }

        public static byte[] RawSerialize(object anything)
        {
            int rawsize = Marshal.SizeOf(anything);
            IntPtr buffer = Marshal.AllocHGlobal(rawsize);
            Marshal.StructureToPtr(anything, buffer, false);
            byte[] rawdatas = new byte[rawsize];
            Marshal.Copy(buffer, rawdatas, 0, rawsize);
            Marshal.FreeHGlobal(buffer);
            return rawdatas;
        }

        public static byte LOBYTE(int iValue)
        {
            return Convert.ToByte(iValue & 255);
        }

        public static byte HIBYTE(int iValue)
        {
            return Convert.ToByte((iValue >> 8) & 255);
        }

        public static int GetShapeIndex(ArrayList pShapeList, uint pObjectID)
        {
            for (int index = 0; index < pShapeList.Count; index++)
            {
                //if (((Shape)pShapeList[index]).ObjectID == pObjectID)
                //    return index;
            }
            return -1;
        }

        public static int GetScreenIndex(List<ScreenInfo> pScreenInfoList, ushort pScreenNumber)
        {
            for (int index = 0; index < pScreenInfoList.Count; index++)
            {
                if (pScreenInfoList[index].usScrNumber == pScreenNumber)
                    return index;
            }
            return -1;
        }


        #endregion

        #region Color Array

        //umesh 06-june-06
        public static System.Byte[,] Col16Supported = new byte[,]
		{
			{0,0,0},  //0
			{16,16,16},  //1
			{32,32,32},  //2
			{48,48,48},   //3
			{64,64,64},  //4
			{80,80,80},   //5
			{96,96,96},  //6
			{112,112,112},  //7
			{128,128,128},  //8
			{144,144,144},  //9
			{160,160,160},  //10
			{176,176,176},  //11
			{192,192,192},  //12
			{208,208,208},  //13
			{224,224,224},  //14
			{240,240,240},  //15
		};

        //umesh 06-june-06
        public static System.Byte[,] Col256Supported = new byte[,]
		{            
			{0x00,0x00,0x00},
			{0x30,0x00,0x00},
			{0x30,0x30,0x30},
			{0x00,0x10,0x10},
			{0x20,0x20,0x20},
			{0x10,0x10,0x10},
			{0x00,0x30,0x00},
			{0x30,0x30,0x00},
			{0x00,0x30,0x30},
			{0x40,0x40,0x40},
			{0x50,0x50,0x50},
			{0x60,0x60,0x60},
			{0x68,0x68,0x68},
			{0x70,0x70,0x70},
			{0x80,0x80,0x80},
			{0x90,0x90,0x90},
			{0xA0,0xA0,0xA0},
			{0xA8,0xA8,0xA8},
			{0xB0,0xB0,0xB0},
			{0xC0,0xC0,0xC0},
			{0xC8,0xC8,0xC8},
			{0xD0,0xD0,0xD0},
			{0xD8,0xD8,0xD8},
			{0xE0,0xE0,0xE0},
			{0xE8,0xE8,0xE8},
			{0xF0,0xF0,0xF0},
			{0xFF,0xFF,0xFF},
			{0x60,0x30,0x30},
			{0x60,0x30,0x00},
			{0x60,0x00,0x00},
			{0x60,0x00,0x60},
			{0x60,0x30,0x60},
			{0xA0,0x00,0x60},
			{0xA0,0x30,0x60},
			{0xA0,0x00,0x20},
			{0xA0,0x30,0x30},
			{0xA0,0x30,0x00},
			{0xA0,0x00,0x00},
			{0xA0,0x60,0x60},
			{0xA0,0x60,0x30},
			{0xA0,0x60,0x00},
			{0xD0,0x00,0x60},
			{0xD0,0x30,0x60},
			{0xD0,0x60,0x60},
			{0xD0,0x60,0x00},
			{0xD0,0x60,0x30},
			{0xD0,0x30,0x30},
			{0xD0,0x30,0x00},
			{0xD0,0x00,0x00},
			{0xF0,0x60,0x60},
			{0xF0,0x00,0x70},
			{0xF0,0x30,0x60},
			{0xF0,0x00,0x60},
			{0xF0,0x60,0x30},
			{0xF0,0x60,0x00},
			{0xF0,0x10,0x20},
			{0xF0,0x50,0x50},
			{0xF0,0x00,0x00},
			{0xF0,0x80,0x80},
			{0xF0,0xA0,0xA0},
			{0xF0,0xA0,0xA8},
			{0xF0,0xA0,0xD0},
			{0xF0,0x60,0xD0},
			{0xF0,0x60,0xF0},
			{0xE0,0x10,0xD0},
			{0xE8,0x10,0xD8},
			{0xF0,0x00,0xB0},
			{0xF0,0x00,0xA0},
			{0xF0,0x30,0xA0},
			{0xF0,0x60,0xA0},
			{0xD0,0x00,0x90},
			{0xD0,0x00,0xA0},
			{0xD0,0x30,0xA0},
			{0xD0,0x60,0xA0},
			{0xF0,0x00,0xD0},
			{0xD0,0x60,0xD0},
			{0xD0,0x00,0xD0},
			{0xD0,0x18,0xD0},
			{0xD0,0x30,0xD0},
			{0xF0,0x00,0xF0},
			{0xF0,0x30,0xF0},
			{0xF0,0xA0,0xF0},
			{0xF0,0xD0,0xF0},
			{0xD0,0xA0,0x60},
			{0xD0,0xA0,0x30},
			{0xD0,0xA0,0x00},
			{0xD0,0xA0,0x80},
			{0xD0,0xA0,0xA0},
			{0xF0,0xD0,0xA0},
			{0xF0,0xD0,0xB0},
			{0xF0,0xD0,0xC0},
			{0xF0,0xD0,0xD0},
			{0xD0,0xA0,0xD0},
			{0xB0,0xA0,0x90},
			{0xC0,0xB8,0x98},
			{0xD0,0xD0,0xA0},
			{0xE0,0xE0,0xB0},
			{0xE8,0xE8,0xC0},
			{0xF0,0xF0,0xD0},
			{0x60,0x60,0x00},
			{0x60,0x60,0x30},
			{0x00,0x60,0x00},
			{0x30,0x60,0x00},
			{0x00,0x60,0x30},
			{0x30,0x60,0x30},
			{0x00,0x80,0x00},
			{0x60,0xA0,0x30},
			{0x60,0xA0,0x60},
			{0x30,0xA0,0x60},
			{0x00,0xA0,0x60},
			{0x00,0xA0,0x30},
			{0x30,0xA0,0x30},
			{0x30,0xA0,0x00},
			{0x00,0xA0,0x00},
			{0x30,0xD0,0x00},
			{0x00,0xD0,0x00},
			{0x60,0xD0,0x00},
			{0x60,0xD0,0x60},
			{0x40,0xD0,0x40},
			{0x00,0xD0,0x30},
			{0x30,0xD0,0x30},
			{0x60,0xD0,0x30},
			{0x00,0xD0,0x60},
			{0x30,0xD0,0x60},
			{0x00,0xF0,0x00},
			{0x60,0xF0,0x60},
			{0x30,0xF0,0x30},
			{0x30,0xF0,0x60},
			{0x00,0xF0,0x60},
			{0x60,0xF0,0x30},
			{0x60,0xF0,0x00},
			{0xA0,0xF0,0x00},
			{0xA0,0xF0,0x30},
			{0xA0,0xF0,0x60},
			{0xC0,0xE0,0xC0},
			{0xB0,0xE0,0xC0},
			{0xB0,0xE8,0xC0},
			{0xD0,0xF0,0xD0},
			{0xD0,0xF0,0x00},
			{0xD0,0xF0,0x30},
			{0xD0,0xF0,0x60},
			{0xF0,0xD0,0x60},
			{0xF0,0xD0,0x30},
			{0xF0,0xD0,0x00},
			{0x80,0x80,0x00},
			{0xA0,0xA0,0x30},
			{0xA0,0xA0,0x40},
			{0xA0,0xA0,0x60},
			{0xB0,0xC0,0x00},
			{0xD0,0xD0,0x30},
			{0xD0,0xD0,0x60},
			{0xB0,0xD0,0x30},
			{0xA8,0xC0,0x60},
			{0xA0,0xD0,0x60},
			{0xA0,0xD0,0x00},
			{0xC0,0xB0,0x60},
			{0xF0,0xA0,0x60},
			{0xF0,0xA0,0x30},
			{0xF0,0xA0,0x00},
			{0xF0,0xC0,0x00},
			{0xF0,0xF0,0x00},
			{0xF0,0xF0,0x60},
			{0xF0,0xF0,0x30},
			{0xE0,0xE0,0x00},
			{0xA0,0xF0,0xA0},
			{0x00,0xF0,0xA0},
			{0x30,0xF0,0xA0},
			{0x60,0xF0,0xA0},
			{0x30,0xE0,0xA0},
			{0x30,0xC0,0xA0},
			{0x30,0xD0,0xA0},
			{0x00,0xD0,0xA0},
			{0x00,0xD8,0xA8},
			{0x30,0xD8,0xA8},
			{0x60,0xD0,0xA0},
			{0xB0,0xB0,0x90},
			{0x30,0x60,0x60},
			{0x00,0x60,0x60},
			{0x00,0x80,0x80},
			{0x00,0xA0,0xA0},
			{0x60,0xA0,0xA0},
			{0x30,0xF0,0xD0},
			{0x00,0xF0,0xD0},
			{0xA0,0xF0,0xD0},
			{0x00,0xD0,0xD0},
			{0x30,0xD0,0xD0},
			{0x60,0xD0,0xD0},
			{0x00,0xC0,0xD0},
			{0xA0,0xF0,0xF0},
			{0x60,0xF0,0xF0},
			{0x00,0xF0,0xF0},
			{0x30,0xF0,0xF0},
			{0xD0,0xF0,0xF0},
			{0xC0,0xF0,0xF0},
			{0xB0,0xF0,0xF0},
			{0xA0,0xD0,0xF0},
			{0xB8,0xD0,0xF0},
			{0xD0,0xD0,0xF0},
			{0xA0,0xA0,0xD0},
			{0xD0,0x00,0xF0},
			{0xD0,0xA0,0xF0},
			{0xA0,0x30,0xD0},
			{0xA0,0x00,0xD0},
			{0xA0,0x60,0xD0},
			{0xD0,0x60,0xF0},
			{0xD0,0x30,0xF0},
			{0xB0,0x50,0xC0},
			{0xA0,0x60,0xA0},
			{0xA0,0x00,0xA0},
			{0xA0,0x30,0xA0},
			{0x80,0x00,0x80},
			{0xA0,0x30,0xF0},
			{0xA0,0x00,0xF0},
			{0xA0,0x60,0xF0},
			{0x60,0x00,0xA0},
			{0x60,0x30,0xA0},
			{0x30,0x00,0x60},
			{0x00,0x00,0x60},
			{0x00,0x30,0x60},
			{0x30,0x30,0x60},
			{0x30,0x30,0x70},
			{0x00,0x00,0x70},
			{0x00,0x00,0x80},
			{0xA0,0xA0,0xF0},
			{0x30,0x30,0xA0},
			{0x00,0x00,0xA0},
			{0x00,0x30,0xA0},
			{0x30,0x00,0xA0},
			{0x30,0x60,0xA0},
			{0x60,0x60,0xA0},
			{0x00,0x60,0xD0},
			{0x30,0x60,0xD0},
			{0x00,0x00,0xD0},
			{0x60,0x30,0xD0},
			{0x30,0x30,0xD0},
			{0x00,0x30,0xD0},
			{0x00,0x00,0xF0},
			{0x60,0x00,0xF0},
			{0x60,0x60,0xF0},
			{0x00,0x60,0xF0},
			{0x60,0x30,0xF0},
			{0x30,0x30,0xF0},
			{0x30,0x60,0xF0},
			{0x60,0x60,0xD0},
			{0x60,0xA0,0xF0},
			{0x30,0xA0,0xF0},
			{0x00,0xA0,0xF0},
			{0x30,0xA0,0xE0},
			{0x60,0xA0,0xE0},
			{0x00,0xA0,0xD0},
			{0x60,0xA0,0xD0},
			{0x30,0xA0,0xD0},
			{0x00,0xC0,0xE0},
			{0x00,0xD0,0xF0},
			{0x30,0xD0,0xF0},
			{0x60,0xD0,0xF0}
		};

        public static System.Byte[,] Col2Supported = new byte[,]
		{
			{0,0,0},  //0
			{255,255,255} //1
		};

        /// <summary>
        /// This function returns the index of the color, which is passed as a parameter, in the color array.
        /// </summary>
        /// <param name="pColor">Color whose index is to be returned</param>
        /// <returns>The index of the passed color in the color array</returns>
        public static byte GetColorIndex(System.Drawing.Color pColor)
        {
            byte index;
            byte R, G, B;
            R = pColor.R;
            G = pColor.G;
            B = pColor.B;

            for (index = 0; index < _commconstantProductData.ColorArray.GetLength(0); index++)             //for (index = 0; index < 255; index++)
            {
                //if (R == argb[index, 0])
                //    if (G == argb[index, 1])
                //        if (B == argb[index, 2])
                if (R == _commconstantProductData.ColorArray[index, 0])
                    if (G == _commconstantProductData.ColorArray[index, 1])
                        if (B == _commconstantProductData.ColorArray[index, 2])
                            break;
            }
            return index;
        }

        /// <summary>
        /// This Function Returns the default Screen Color Index.
        /// For 2 color Product :  White Color Index = 1
        /// For 16 Color Product:  White Color Index = 15
        /// For 256 Color Product: White Color Index = 26
        /// The switch case statement checks selected Product and returns its DefaultScreen Color index.
        /// </summary>
        /// <param name="iProductSeriesID"></param>
        /// <returns></returns>
        public static int GetDefaultScreenColorIndex(int iProductSeriesID)
        {
            int iColorIndex = 1;
            switch (iProductSeriesID)
            {
                //Products Having 2 Colors
                case CommonConstants.PRODUCT_PRIZM10:
                case CommonConstants.PRODUCT_PRIZM12:
                case CommonConstants.PRODUCT_PRIZM15:
                case CommonConstants.PRODUCT_PRIZM18:
                case CommonConstants.PRODUCT_PRIZM22:
                case CommonConstants.PRODUCT_PRIZM50:
                case CommonConstants.PRODUCT_PRIZM120:
                case CommonConstants.PRODUCT_PRIZM140:
                case CommonConstants.PRODUCT_PRIZM140_EV3:
                case CommonConstants.PRODUCT_HIO_05:
                case CommonConstants.PRODUCT_PRIZM230:
                case CommonConstants.PRODUCT_PZM4_0216:
                case CommonConstants.PRODUCT_PZM4_1300:
                //FlexiPanel_Change_R1
                case CommonConstants.PRODUCT_FP2020_L0808RP_A0401L: //2020_Series_Vijay
                case CommonConstants.PRODUCT_FP2020_L0808P_A0401L:
                case CommonConstants.PRODUCT_FP2020_L0604P_A0401L:
                case CommonConstants.PRODUCT_FP4020MR:
                case CommonConstants.PRODUCT_FP4030MR:
                case CommonConstants.PRODUCT_PZ4030M_E:
                case CommonConstants.PRODUCT_PZ4030MN_E:
                case CommonConstants.PRODUCT_FP4020MR_L0808P:
                case CommonConstants.PRODUCT_FP4020M_L0808P_A:
                case CommonConstants.PRODUCT_FP4020M_L0808P_A0400R:
                case CommonConstants.PRODUCT_FP4020MR_L0808N:
                case CommonConstants.PRODUCT_FP4020M_L0808N_A:
                case CommonConstants.PRODUCT_FP4020M_L0808N_AR:
                case CommonConstants.PRODUCT_FP4020MR_L0808R:
                #region New_Product_Addition Vijay
                case CommonConstants.PRODUCT_FP4020MR_L0808R_S3:
                #endregion
                #region Hitachi Hi-Rel Vijay
                case CommonConstants.PRODUCT_HH5P_HP200808D_P:
                case CommonConstants.PRODUCT_HH5P_HP301208D_R:
                case CommonConstants.PRODUCT_HH5P_HP300201U0808_RP:
                case CommonConstants.PRODUCT_HH5P_HP300201L0808_RP:
                #endregion
                case CommonConstants.PRODUCT_FP4020M_L0808R_A:
                //case CommonConstants.PRODUCT_FP4020MR_L0808R_A0400://New_Product_Addition M&R AMIT
                //case CommonConstants.PRODUCT_FP4030M_L1208R_A0400:
                case CommonConstants.PRODUCT_FP4030MR_E:
                //case CommonConstants.PRODUCT_FP4030MN_E://New_Product_Addition M&R AMIT
                case CommonConstants.PRODUCT_FP4030MR_L1208R:
                case CommonConstants.PRODUCT_FP4030MR_0808R_A0400_S0://PRODUCT_FP4030MR_0808R_A0400_S0_addition_sammed
                case CommonConstants.PRODUCT_FP4030MR_L1210RP_A0402U: //PRODUCT_FP4030MR_L1210RP_A0402U Vijay
                case CommonConstants.PRODUCT_FP4030MR_L1210P_A0402U:  //PRODUCT_FP4030MR_L1210P_A0402U Vijay
                case CommonConstants.PRODUCT_FP4030MR_L1210RP: //PRODUCT_FP4030MR_L1210RP Suyash
                case CommonConstants.PRODUCT_FP4030MR_L1210P: //PRODUCT_FP4030MR_L1210P Suyash
                case CommonConstants.PRODUCT_FP4030MR_L0808R_A0400U: //PRODUCT_FP4030MR_L0808R_A0400U Vijay
                case CommonConstants.PRODUCT_FH9020MR:
                case CommonConstants.PRODUCT_FH9020MR_L0808P:
                case CommonConstants.PRODUCT_FH9020MR_L0808N:
                case CommonConstants.PRODUCT_FH9020MR_L0808R:
                case CommonConstants.PRODUCT_FH9030MR:
                case CommonConstants.PRODUCT_FH9030MR_E:
                case CommonConstants.PRODUCT_FH9030MR_L1208R:

                case CommonConstants.PRODUCT_HMC7030A_M:
                case CommonConstants.PRODUCT_HMC7030A_L:
                //END -- Amit
                #region Toshiba US products SnehalM
                case CommonConstants.PRODUCT_OIS12:
                case CommonConstants.PRODUCT_OIS22_Plus:
                case CommonConstants.PRODUCT_OIS20_Plus:
                case CommonConstants.PRODUCT_OIS10_Plus: //06.04.15_Vijay
                #endregion
                //case CommonConstants.PRODUCT_FPW4030M: //New FP4030MT Vertical Series Addition Vijay
                #region New_Product_Addition M&R AMIT
                case CommonConstants.PRODUCT_FP4030MT_S1_HORIZONTAL:
                case CommonConstants.PRODUCT_FP4030MT_S1_VERTICAL:
                case CommonConstants.PRODUCT_FP4030MT_HORIZONTAL://FP4030MT_addition_AMIT
                case CommonConstants.PRODUCT_FP4030MT_VERTICAL:
                #endregion
                case CommonConstants.PRODUCT_FP3020MR_L1608RP://Suyash_FP3020MR_L1608RP_Prod_Addition
                case CommonConstants.PRODUCT_FP4030MT_L0808RN_A0201: //FP4030MT_L0808RN_A0201_addition_Vijay
                case CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201: //FP4030MT_L0808RP_A0201_addition_Vijay
                case CommonConstants.PRODUCT_FP4030MT_REV1://New Product addition FP4030MT- Rev 1
                case CommonConstants.PRODUCT_FP4030MT_L0808RN: //New Product addition FP4030MT-L0808RN/RP Vijay
                case CommonConstants.PRODUCT_FP4030MT_L0808RP: //New Product addition FP4030MT-L0808RN/RP Vijay
                #region New FP4030MT Vertical Series Addition Vijay
                case CommonConstants.PRODUCT_FP4030MT_REV1_VERTICAL:
                case CommonConstants.PRODUCT_FP4030MT_L0808RN_A0201_VERTICAL:
                case CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201_VERTICAL:
                case CommonConstants.PRODUCT_FP4030MT_L0808RN_VERTICAL:
                case CommonConstants.PRODUCT_FP4030MT_L0808RP_VERTICAL:
                #endregion
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201L://FP4030MT_L0808RP_A0201L_addition_sammed
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201L_VERTICAL://FP4030MT_L0808RP_A0201L(Vertical)_addition_sammed
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808RP_A0201_S0: //New Product Addition FP4030MT-L0808RP-A0201-S0 Vijay
                #region New Product Addtion FP4030MT_L0808P/FP4030MT_L0808P_A0201U Vijay
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808P:
                case ClassList.CommonConstants.PRODUCT_FP4030MT_L0808P_A0201U:
                #endregion
                case CommonConstants.PRODUCT_FP4030MT_L0808P_A0402L://Suyash_Product_Addition_FP4030MT_L0808P_A0402L
                case CommonConstants.PRODUCT_GSM900://GSM_Screen_Sanjay_7-Nov-11 
                case CommonConstants.PRODUCT_GSM901://GWY-901 SP
                case CommonConstants.PRODUCT_GSM910://GWY_910_Suyash
                case CommonConstants.PRODUCT_GWY00://GWY00_Change
                //Toshiba_US New product Addition
                case CommonConstants.PRODUCT_OIS40_Plus_HORIZONTAL:
                case CommonConstants.PRODUCT_OIS40_Plus_VERTICAL:
                case CommonConstants.PRODUCT_OIS42_Plus: //New_Product_Addition Vijay(01.03.2013)
                case CommonConstants.PRODUCT_OIS42L_Plus: //New_Product_Addition Vijay(12.09.2013)
                    iColorIndex = 1;
                    break;

                //Products having 256 Colors
                case CommonConstants.PRODUCT_PRIZM540:
                case CommonConstants.PRODUCT_PRIZM545:
                case CommonConstants.PRODUCT_PRIZM550E:
                case CommonConstants.PRODUCT_PRIZM550N:
                case CommonConstants.PRODUCT_PRIZM720:
                case CommonConstants.PRODUCT_PRIZM760:
                case CommonConstants.PRODUCT_PRIZM760E:
                case CommonConstants.PRODUCT_PRIZM760n:
                case CommonConstants.PRODUCT_PRIZM760nk:
                case CommonConstants.PRODUCT_PRIZMCE545:
                case CommonConstants.PRODUCT_PRIZMCE760:
                case CommonConstants.PRODUCT_PZM4_2600:
                case CommonConstants.PRODUCT_PZM4_2615:
                case CommonConstants.PRODUCT_NQ3_TQ000_B:
                case CommonConstants.PRODUCT_NQ3_TQ010_B:
                case CommonConstants.PRODUCT_NQ5_SQ000_B:
                case CommonConstants.PRODUCT_NQ5_SQ010_B:
                case CommonConstants.PRODUCT_NQ5_SQ001_B:
                case CommonConstants.PRODUCT_NQ5_SQ011_B:
                //FlexiPanel_Change_R1
                case CommonConstants.PRODUCT_FP4035T:
                case CommonConstants.PRODUCT_PZ4035TN_E:
                case CommonConstants.PRODUCT_FP4057T:
                #region New_Product_Addition_Herizomat AMIT
                case CommonConstants.PRODUCT_FP4057T_S2:
                #endregion
                case CommonConstants.PRODUCT_PZ4057TN_E:
                case CommonConstants.PRODUCT_PZ4121TN_E:

                case CommonConstants.PRODUCT_FP4035T_E:
                #region New_Ethernet_Products_AMIT
                case CommonConstants.PRODUCT_FP4035TN:
                case CommonConstants.PRODUCT_FP4035TN_E:

                case CommonConstants.PRODUCT_FP4057TN:
                case CommonConstants.PRODUCT_FP4057TN_E:

                #endregion
                case CommonConstants.PRODUCT_FP4057T_E:
                #region New_Product_Addition_AllBodySoltn AMIT
                case CommonConstants.PRODUCT_FP4057T_E_S1:
                #endregion
                #region New_Product_Addition_Vertical Vijay
                case CommonConstants.PRODUCT_FP4057T_E_VERTICAL:
                #endregion
                //case CommonConstants.PRODUCT_FP4084TN_E: //New Product Addition FP4030MT-L0808RP-A0201-S0 Vijay

                //FP_CODE  R12  Haresh
                case CommonConstants.PRODUCT_TRPMIU0300L:
                case CommonConstants.PRODUCT_TRPMIU0300A:
                case CommonConstants.PRODUCT_TRPMIU0500L:
                case CommonConstants.PRODUCT_TRPMIU0500A:
                //New Ethernet Models - SnehaK
                case CommonConstants.PRODUCT_TRPMIU0300E:
                case CommonConstants.PRODUCT_TRPMIU0500E:
                //End

                case CommonConstants.PRODUCT_FH9035T:
                case CommonConstants.PRODUCT_FH9035T_E:
                case CommonConstants.PRODUCT_FH9057T:
                case CommonConstants.PRODUCT_FH9057T_E:
                //End
                #region New FP3series product Addition Suyash
                case CommonConstants.PRODUCT_FP3043T://New FP3043T product Addition Suyash
                case CommonConstants.PRODUCT_FP3043TN://New FP3043TN product Addition Suyash
                case CommonConstants.PRODUCT_FP3070T://New FP3070T product Addition Suyash
                case CommonConstants.PRODUCT_FP3070TN://New FP3070TN product Addition Suyash
                case CommonConstants.PRODUCT_FP3102T://New FP3102T product Addition Suyash
                case CommonConstants.PRODUCT_FP3102TN://New FP3102TN product Addition Suyash
                #region SY-FP3_PlugableIO_Product_addition
                case CommonConstants.PRODUCT_FP3070T_E:
                case CommonConstants.PRODUCT_FP3070TN_E:
                case CommonConstants.PRODUCT_FP3102T_E:
                case CommonConstants.PRODUCT_FP3102TN_E:
                #endregion
                #region FP3043_ExpansionSeries Vijay
                case CommonConstants.PRODUCT_FP3043T_E:
                case CommonConstants.PRODUCT_FP3043TN_E:
                #endregion
                #endregion
                #region Hitachi Hi-Rel Vijay
                case CommonConstants.PRODUCT_HH5P_H43_NS:
                case CommonConstants.PRODUCT_HH5P_H43_S:
                case CommonConstants.PRODUCT_HH5P_H70_NS:
                case CommonConstants.PRODUCT_HH5P_H70_S:
                case CommonConstants.PRODUCT_HH5P_H100_NS:
                case CommonConstants.PRODUCT_HH5P_H100_S:
                case CommonConstants.PRODUCT_HH1L_000:
                case CommonConstants.PRODUCT_HH5P_HP43_NS:
                case CommonConstants.PRODUCT_HH5P_HP70_NS:
                #endregion
                #region OIS3Series_Vijay
                case CommonConstants.PRODUCT_OIS43E_Plus:
                case CommonConstants.PRODUCT_OIS72E_Plus:
                case CommonConstants.PRODUCT_OIS100E_Plus:
                #endregion
                #region New FP Models-43&70 SnehalM
                // New Models added on date 30jully10- SnehalM
                case CommonConstants.PRODUCT_FP5043T:
                case CommonConstants.PRODUCT_FP5043TN:
                case CommonConstants.PRODUCT_FP5043T_E:
                case CommonConstants.PRODUCT_FP5043TN_E:
                case CommonConstants.PRODUCT_FP5070T:
                case CommonConstants.PRODUCT_FP5070TN:
                case CommonConstants.PRODUCT_FP5070T_E:
                case CommonConstants.PRODUCT_FP5070TN_E:
                case CommonConstants.PRODUCT_FP5121T:
                case CommonConstants.PRODUCT_FP5121TN:
                case CommonConstants.PRODUCT_FP5121TN_S0://Haresh_5121TN-SO
                case ClassList.CommonConstants.PRODUCT_PRIZM_710_S0://SD_Product_Addition_Prizm710_so
                //////
                #endregion
                #region Panasonic sammed 2.0
                case CommonConstants.PRODUCT_GTXL07N:
                case CommonConstants.PRODUCT_GTXL10N:
                #endregion
                case CommonConstants.PRODUCT_FP5070T_E_S2://New FP5070T-E-S2 product Addition Suyash
                //Toshiba-Japan_Product
                case CommonConstants.PRODUCT_TRPMIU0400E:
                case CommonConstants.PRODUCT_TRPMIU0700E:
                //End

                #region Toshiba US products SnehalM
                case CommonConstants.PRODUCT_OIS55_Plus:
                case CommonConstants.PRODUCT_OIS60_Plus:
                //Toshiba_US New product Addition
                case CommonConstants.PRODUCT_OIS45_Plus:
                case CommonConstants.PRODUCT_OIS45E_Plus:
                case CommonConstants.PRODUCT_OIS70_Plus:
                case CommonConstants.PRODUCT_OIS70E_Plus:
                case CommonConstants.PRODUCT_OIS120A:
                #endregion

                case CommonConstants.PRODUCT_HMC7035A_M:
                case CommonConstants.PRODUCT_HMC7057A_M:
                #region //Mapple Customization 2.0_Sanjay
                case CommonConstants.PRODUCT_HMC7043A_M:
                case CommonConstants.PRODUCT_HMC7070A_M:
                #endregion
                //END -- Amit

                //WebServer changes
                #region WebServer Change
                case CommonConstants.PRODUCT_FL100:
                case CommonConstants.PRODUCT_FL100_S0://SS_FL100S0
                case CommonConstants.PRODUCT_GPU230_3S: //WebServer Change Vijay
                #region New FP3035 Product Series
                //New FP3035 Product Series 3035T-24/3035T-5 SP
                case CommonConstants.PRODUCT_FP3035T_24:
                case CommonConstants.PRODUCT_FP3035T_5:
                //New_Product_Addition_OIS24/OIS_25 Vijay
                case ClassList.CommonConstants.PRODUCT_OIS24:
                case ClassList.CommonConstants.PRODUCT_OIS25:
                case CommonConstants.PRODUCT_CPU_300: //PLC_Direct Vijay
                //End
                //End
                #endregion
                case CommonConstants.PRODUCT_FL050_V2:
                case CommonConstants.PRODUCT_FL055://FL055_Product_Addition_Suyash
                    iColorIndex = 26;
                    break;
                #endregion
                //End


                //Products Having 16 Colors
                case CommonConstants.PRODUCT_PRIZM280:
                case CommonConstants.PRODUCT_PRIZM285:
                case CommonConstants.PRODUCT_PRIZM290E:
                case CommonConstants.PRODUCT_PRIZM290N:
                case CommonConstants.PRODUCT_PZM4_1600:
                case CommonConstants.PRODUCT_PZM4_1615:
                case CommonConstants.PRODUCT_NQ3_MQ000_B:
                case CommonConstants.PRODUCT_NQ5_MQ000_B:
                case CommonConstants.PRODUCT_NQ5_MQ010_B:
                case CommonConstants.PRODUCT_NQ5_MQ001_B:
                case CommonConstants.PRODUCT_NQ5_MQ011_B:
                //FlexiPanel_Change_R1
                case CommonConstants.PRODUCT_PZ4057M_E:
                    //case CommonConstants.PRODUCT_FP4057M_E:
                    //End
                    iColorIndex = 15;
                    break;

                //default:
                //    iColorIndex = 0;

            }

            return iColorIndex;
        }



        /// <summary>
        /// Grey = 26
        /// Dark Grey - Screen Background Color = 16
        /// Magenta - Rectangle Frame Color  = 70
        /// Cyan - Rectangle Frame Color = 255
        /// Blue = 236
        /// Black = 0
        /// Yellow = 160
        /// Red = 57
        /// Green = 124
        /// Grey - Keypad = 19 ( Keypad not supported in Prizm 140 )
        /// </summary>
        /// <param name="pNoOfColorsSupported"></param>
        /// <param name="pColorIndexOfPrizm545"></param>
        /// <returns></returns>
        /* public static int GetInitializationColorIndex( int pNoOfColorsSupported, int pColorIndexOfPrizm545 )
         {
             int index = 0;
             if ( pNoOfColorsSupported == 256 )
                 index = pColorIndexOfPrizm545;
             else if( pNoOfColorsSupported == 16 )
             {
                 if (pColorIndexOfPrizm545 == 26 || pColorIndexOfPrizm545 == 141) 
                     index = 15;             
                 else if (pColorIndexOfPrizm545 == 16)
                     index = 10;
                 else if (pColorIndexOfPrizm545 == 70 || pColorIndexOfPrizm545 == 236 || 
                          pColorIndexOfPrizm545 == 160 || pColorIndexOfPrizm545 == 0 || 
                          pColorIndexOfPrizm545 == 57 || pColorIndexOfPrizm545 == 124 ||
                          pColorIndexOfPrizm545 == 255 )  
                     index = 0; 
                 else if (pColorIndexOfPrizm545 == 19)
                     index = 12;
             }
             else if ( pNoOfColorsSupported == 2)
             {
                 if (pColorIndexOfPrizm545 == 26 || pColorIndexOfPrizm545 == 141 )
                     index = 1;               
                 else if (pColorIndexOfPrizm545 == 70 || pColorIndexOfPrizm545 == 236 ||
                          pColorIndexOfPrizm545 == 160 || pColorIndexOfPrizm545 == 0 ||
                          pColorIndexOfPrizm545 == 57 || pColorIndexOfPrizm545 == 124 ||
                          pColorIndexOfPrizm545 == 16 || pColorIndexOfPrizm545 == 255)
                     index = 0;                
             }
             return index;
         }
         */

        public static int GetInitializationColorIndex(int pNoOfColorsSupported, int pColorIndexOfPrizm545)
        {
            int index = 0;
            if (pNoOfColorsSupported == 256)
                index = pColorIndexOfPrizm545;
            else if (pNoOfColorsSupported == 16)
            {
                if (pColorIndexOfPrizm545 == 26 || pColorIndexOfPrizm545 == 141)
                    index = 15;
                else if (pColorIndexOfPrizm545 == 16)
                    index = 10;
                else if (pColorIndexOfPrizm545 == 70 || pColorIndexOfPrizm545 == 236 ||
                         pColorIndexOfPrizm545 == 160 || pColorIndexOfPrizm545 == 0 ||
                         pColorIndexOfPrizm545 == 57 || pColorIndexOfPrizm545 == 124 ||
                         pColorIndexOfPrizm545 == 255)
                    index = 0;
                else if (pColorIndexOfPrizm545 == 19)
                    index = 12;
            }
            else if (pNoOfColorsSupported == 2)
            {
                if (pColorIndexOfPrizm545 == 26 || pColorIndexOfPrizm545 == 141)
                    index = 1;
                else if (pColorIndexOfPrizm545 == 70 || pColorIndexOfPrizm545 == 236 ||
                         pColorIndexOfPrizm545 == 160 || pColorIndexOfPrizm545 == 0 ||
                         pColorIndexOfPrizm545 == 57 || pColorIndexOfPrizm545 == 124 ||
                         pColorIndexOfPrizm545 == 16 || pColorIndexOfPrizm545 == 255)
                    index = 0;
            }
            else if (pNoOfColorsSupported == 4)
            {
                if (pColorIndexOfPrizm545 == 26 || pColorIndexOfPrizm545 == 141)
                    index = 3;
                else if (pColorIndexOfPrizm545 == 16 || pColorIndexOfPrizm545 == 10)
                    index = 2;
                else if (pColorIndexOfPrizm545 == 70 || pColorIndexOfPrizm545 == 236 ||
                         pColorIndexOfPrizm545 == 160 || pColorIndexOfPrizm545 == 0 ||
                         pColorIndexOfPrizm545 == 57 || pColorIndexOfPrizm545 == 124 ||
                         pColorIndexOfPrizm545 == 255)
                    index = 0;
                else if (pColorIndexOfPrizm545 == 19)
                    index = 2;
            }
            return index;
        }

        //public static bool IsBitWizardObject(DrawingObjects pShapeID)
        //{
        //    if (pShapeID == DrawingObjects.NEXT ||
        //   pShapeID == DrawingObjects.GOTO ||
        //   pShapeID == DrawingObjects.GOTOPOPUPSCREEN ||
        //   pShapeID == DrawingObjects.HIDEPOPUPSCREEN ||
        //   pShapeID == DrawingObjects.PREV ||
        //   pShapeID == DrawingObjects.WRITEVALUETOTAG ||
        //   pShapeID == DrawingObjects.ADDVALUETOTAG ||
        //   pShapeID == DrawingObjects.SUBTRACTVALUEFROMTAG ||
        //   pShapeID == DrawingObjects.HIDEPOPUPSCREEN ||
        //   pShapeID == DrawingObjects.ADDTAGS ||
        //   pShapeID == DrawingObjects.SUBTRACTTAGS ||
        //   pShapeID == DrawingObjects.BITBUTTON ||
        //   pShapeID == DrawingObjects.SET ||
        //   pShapeID == DrawingObjects.RESET ||
        //   pShapeID == DrawingObjects.MOMENTARY ||//ShitalG_PER466
        //   pShapeID == DrawingObjects.TOGGLE ||
        //   pShapeID == DrawingObjects.HOLDON ||
        //   pShapeID == DrawingObjects.HOLDOFF ||
        //   pShapeID == DrawingObjects.BITLAMP ||
        //   pShapeID == DrawingObjects.NEXT_ALARM ||
        //   pShapeID == DrawingObjects.PREV_ALARM ||
        //   pShapeID == DrawingObjects.ACKNOWLEDGE_ALARM ||
        //   pShapeID == DrawingObjects.ACKNOWLEDGE_ALL_ALARMS ||//punit
        //   pShapeID == DrawingObjects.COPY_PLCBLOCKTOPRIZMBLOCK || //Nilam
        //   pShapeID == DrawingObjects.COPY_PRIZMBLOCKTOPLCBLOCK)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        /// <summary>
        /// Methode use Check For Bitmap Extension. //Nilam 16 Sept.
        /// </summary>
        /// <param name="pstrExtension"></param>
        /// <returns></returns>
        public static bool IsValidExtensionForBitmap(string pstrExtension)
        {
            if (pstrExtension == CommonConstants.OnlyDotBmP ||
                pstrExtension == CommonConstants.OnlyDotBMP ||
                pstrExtension == CommonConstants.OnlyDotbmp ||
                pstrExtension == CommonConstants.OnlyDotbMp ||
                pstrExtension == CommonConstants.OnlyDotBmp ||
                pstrExtension == CommonConstants.OnlyDotbmP ||
                pstrExtension == CommonConstants.OnlyDotBMp ||
                pstrExtension == CommonConstants.OnlyDotbMP)
            {
                return true;
            }
            return false;


        }
        //punit 30th jan 2007 --- added    
        /// <summary>
        /// convets decimal number into binary
        /// </summary>
        /// <param name="pDecimal"></param>
        /// <returns></returns>
        public static string Convert_To_BinFromDec(string pDecimal)
        {
            int tempNumber = Convert.ToInt32(pDecimal);
            string str = "";
            if (tempNumber == 0)
            {
                return ("0");
            }
            for (int i = 0; tempNumber > 0; i++)
            {
                if ((tempNumber | 1) == tempNumber)
                    str = 1.ToString() + str;
                else
                    str = 0.ToString() + str;
                tempNumber >>= 1;
            }
            return str;
        }

        /// <summary>
        /// converts binary number into decimal
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string convert_from_BinToDec(string str)
        {
            return (Convert.ToInt64(str, 2).ToString());
        }

        /// <summary>
        /// Converts Hexadecimal String to Decimal.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string convert_From_HexToDec(string str)
        {
            return (Convert.ToInt64(str, 16).ToString());
        }

        /// <summary>
        /// Convert's Ushort value to Hex.
        /// </summary>
        /// <param name="pushort"></param>
        /// <returns></returns>
        public static string convert_From_DecToHex(ushort pushort)
        {
            return Microsoft.VisualBasic.Conversion.Hex(pushort);
        }


        public static UInt32 ConvertToBCD(UInt32 Num, UInt32 Divider, UInt32 Factor)
        {
            UInt32 Remainder = 0, Quotient = 0, Result = 0;
            Remainder = Num % Divider;
            Quotient = Num / Divider;
            if (!(Quotient == 0 && Remainder == 0))
                Result += ConvertToBCD(Quotient, Divider, Factor) * Factor + Remainder;
            return Result;

        }

        #endregion

        #region Public Structures

        /// <summary>
        /// Used For Modbus Master Specific Broadcast Settings.
        /// </summary>
        public struct BroadcastSettings
        {
            public ushort _usBroadcastEnableBit;
            public byte _btTypeNoOfRegister;    // 0: Fixed  1: Tag
            public byte _btAdjustingbyte1;
            public ushort _usNoOfRegisterData; // 0: Count of No of Register , 1: Address of data register ;
            public byte _btModbusTagType;  //0: Coils, 1: Input coils, 2: Input Register, 3: Holding register ;
            public byte _btAdjustingbyte2;
            public ushort _usModbusTagStartAddr; //First Address of Modbus Tag.
            public ushort _usPrizmTagStartAddr;  //First Address of Prizm Tag.
        }


        /// <summary>
        /// Universal Serial Drivar Settings Structure.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct UniversalSerialDriver
        {
            //Transmit.
            public byte _btStartAddrType;
            public byte _btStartAddrAdjust;
            public ushort _usStartAddress;

            public byte _btNoOfBytesType;
            public byte _btNoOfBytesAdjust;
            public ushort _usNoOfBytesAddress;

            public byte _btTransSignature;

            public byte _btNoOfBytesSTXEnable;
            public byte _btNoOfBytesSTX;
            public ushort _usSTXFrame0;
            public ushort _usSTXFrame1;
            public ushort _usSTXFrame2;
            public ushort _usSTXFrame3;
            public ushort _usSTXFrame4;

            public byte _btNoOfBytesETXEnable;
            public byte _btNoOfBytesETX;
            public ushort _usETXFrame0;
            public ushort _usETXFrame1;
            public ushort _usETXFrame2;
            public ushort _usETXFrame3;
            public ushort _usETXFrame4;

            public byte _btChecksumTransEnable;
            public byte _btChecksumType1;
            public byte _btChecksumType2;
            public byte _btChecksumTransTimeout;

            public byte _btSilentIntervalSTXEnable;
            public byte _btSilentIntervalSTXAdjust;
            public byte _btSilentIntervalSTXType;
            public ushort _usSilentIntervalSTX;

            public byte _btStartTransEnable;
            public byte _btStartTransType;
            public byte _btStartTransAdjust;
            public ushort _usStartTransAddr;

            public byte _btTransComplEnable;
            public byte _btTransComplType;
            public byte _btTransComplAdjust;
            public ushort _usTransComplAddr;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
            public byte[] ReservedBytes;

            //Receive
            public byte _btRxEnableBit;     // LoByte/HiByte.

            public byte _btRecStartAddrType;
            public byte _btRecStartAddrAdjust;
            public ushort _usRecStartAddress;

            public byte _btRecAsByteRecEnable;

            public byte _btRecNoOfBytesSTXEnable;
            public byte _btRecNoOfBytesSTX;
            public ushort _usRecSTXFrame0;
            public ushort _usRecSTXFrame1;
            public ushort _usRecSTXFrame2;
            public ushort _usRecSTXFrame3;
            public ushort _usRecSTXFrame4;

            public byte _btRecOnBitEnable;
            public byte _btRecOnBitType;
            public byte _btRecOnBitAdjust;
            public ushort _usRecOnBitAddress;

            public byte _btRecAfterBreakOfEnable;
            public byte _btRecAfterBreakOfType;
            public byte _btRecAfterBreakOfAdjust;
            public ushort _usRecAfterBreakOfAddress;

            public byte _btRecNoOfByteEnable;
            public byte _btRecNoOfByteType;
            public byte _btRecNoOfByteAdjust;
            public ushort _usRecNoOfByteAddress;

            public byte _btRecNoOfBytesETXEnable;
            public byte _btRecNoOfBytesETX;
            public ushort _usRecETXFrame0;
            public ushort _usRecETXFrame1;
            public ushort _usRecETXFrame2;
            public ushort _usRecETXFrame3;
            public ushort _usRecETXFrame4;

            public byte _btRecComplEnable;
            public byte _btRecComplType;
            public byte _btRecComplAdjust;
            public ushort _usRecComplAddress;

            public byte _btRecChecksumEnable;
            public byte _btRecChecksumType1;
            public byte _btRecChecksumType2;

            public byte _btRecCheksumErrBitEnable;
            public byte _btRecCheksumErrBitType;
            public byte _btRecCheksumErrBitAdjust;
            public ushort _usRecCheksumErrBitAddress;

            //Settings.
            public byte _btSettRespToutMSecEnable;
            public byte _btSettRespToutMSecNoOfBytesType;
            public byte _btSettRespToutMSecAdjust;
            public ushort _usSettRespToutMSecAddress;

            public byte _btSettRespToutBitEnable;
            public byte _btSettRespToutBitNoOfBytesType;
            public byte _btSettRespToutBitAdjust;
            public ushort _usSettRespToutBitAddress;

            public byte _btSettIRDelayEnable;
            public byte _btSettIRDelayNoOfBytesType;
            public byte _btSettIRDelayAdjust;
            public ushort _usSettIRDelayAddress;

            public byte _btSettRetryCountEnable;
            public byte _btSettRetryCountNoOfBytesType;
            public byte _btSettRetryCountAdjust;
            public ushort _usSettRetryCountAddress;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
            public byte[] ReservedBytes2;
        }

        /// <summary>
        /// IEC Universal Serial Driver Settings Structure.
        /// SS_UniversalDriverIECEnable
        /// AddrType,AddrAdjust,StartAddress etc fields are not updated since Tagids are used.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct UniversalSerialDriverIEC
        {
            //Transmit.
            public byte _btStartAddrType;
            public byte _btStartAddrAdjust;
            public ushort _usStartAddress;
            public int _transStartTagID;//

            public byte _btNoOfBytesType;
            public byte _btNoOfBytesAdjust;
            public ushort _usNoOfBytesAddress;
            public byte _transNoOfBytesConstOrTag;//
            public int _transNoOfBytesTagID;//

            public byte _btTransSignature;

            public byte _btNoOfBytesSTXEnable;
            public byte _btNoOfBytesSTX;
            public ushort _usSTXFrame0;
            public ushort _usSTXFrame1;
            public ushort _usSTXFrame2;
            public ushort _usSTXFrame3;
            public ushort _usSTXFrame4;

            public byte _btNoOfBytesETXEnable;
            public byte _btNoOfBytesETX;
            public ushort _usETXFrame0;
            public ushort _usETXFrame1;
            public ushort _usETXFrame2;
            public ushort _usETXFrame3;
            public ushort _usETXFrame4;

            public byte _btChecksumTransEnable;
            public byte _btChecksumType1;
            public byte _btChecksumType2;
            public byte _btChecksumTransTimeout;

            public byte _btSilentIntervalSTXEnable;
            public byte _btSilentIntervalSTXAdjust;
            public byte _btSilentIntervalSTXType;
            public ushort _usSilentIntervalSTX;
            public byte _silentIntervalConstOrTag;//
            public int _silentIntervalTagID;//

            public byte _btStartTransEnable;
            public byte _btStartTransType;
            public byte _btStartTransAdjust;
            public ushort _usStartTransAddr;
            public int _transStartBitTagID;//

            public byte _btTransComplEnable;
            public byte _btTransComplType;
            public byte _btTransComplAdjust;
            public ushort _usTransComplAddr;
            public int _transCmpltBitTagID;//


            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
            public byte[] ReservedBytes;

            //Receive
            public byte _btRxEnableBit;     // LoByte/HiByte.

            public byte _btRecStartAddrType;
            public byte _btRecStartAddrAdjust;
            public ushort _usRecStartAddress;
            public int _RecStartTagID;//

            public byte _btRecAsByteRecEnable;

            public byte _btRecNoOfBytesSTXEnable;
            public byte _btRecNoOfBytesSTX;
            public ushort _usRecSTXFrame0;
            public ushort _usRecSTXFrame1;
            public ushort _usRecSTXFrame2;
            public ushort _usRecSTXFrame3;
            public ushort _usRecSTXFrame4;

            public byte _btRecOnBitEnable;
            public byte _btRecOnBitType;
            public byte _btRecOnBitAdjust;
            public ushort _usRecOnBitAddress;
            public int _RecOnBitTagID;//

            public byte _btRecAfterBreakOfEnable;
            public byte _btRecAfterBreakOfType;
            public byte _btRecAfterBreakOfAdjust;
            public ushort _usRecAfterBreakOfAddress;
            public byte _RecAfterBreakOfConstOrTag;//
            public int _RecAfterBreakOfTagID;//

            public byte _btRecNoOfByteEnable;
            public byte _btRecNoOfByteType;
            public byte _btRecNoOfByteAdjust;
            public ushort _usRecNoOfByteAddress;
            public byte _RecNoOfByteConstOrTag;//
            public int _RecNoOfByteTagID;//

            public byte _btRecNoOfBytesETXEnable;
            public byte _btRecNoOfBytesETX;
            public ushort _usRecETXFrame0;
            public ushort _usRecETXFrame1;
            public ushort _usRecETXFrame2;
            public ushort _usRecETXFrame3;
            public ushort _usRecETXFrame4;

            public byte _btRecComplEnable;
            public byte _btRecComplType;
            public byte _btRecComplAdjust;
            public ushort _usRecComplAddress;
            public int _RecComplTagID;//

            public byte _btRecChecksumEnable;
            public byte _btRecChecksumType1;
            public byte _btRecChecksumType2;

            public byte _btRecCheksumErrBitEnable;
            public byte _btRecCheksumErrBitType;
            public byte _btRecCheksumErrBitAdjust;
            public ushort _usRecCheksumErrBitAddress;
            public int _RecChcksumErrBitTagID;//

            //Settings.
            public byte _btSettRespToutMSecEnable;
            public byte _btSettRespToutMSecNoOfBytesType;
            public byte _btSettRespToutMSecAdjust;
            public ushort _usSettRespToutMSecAddress;
            public byte _SettRespToutMSecConstOrTag;//
            public int _SettRespToutMSecTagID;//

            public byte _btSettRespToutBitEnable;
            public byte _btSettRespToutBitNoOfBytesType;
            public byte _btSettRespToutBitAdjust;
            public ushort _usSettRespToutBitAddress;
            public int _SettRespToutBitTagID;//

            public byte _btSettIRDelayEnable;
            public byte _btSettIRDelayNoOfBytesType;
            public byte _btSettIRDelayAdjust;
            public ushort _usSettIRDelayAddress;
            public byte _SettIRDelayConstOrTag;//
            public int _SettIRDelayTagID;//

            public byte _btSettRetryCountEnable;
            public byte _btSettRetryCountNoOfBytesType;
            public byte _btSettRetryCountAdjust;
            public ushort _usSettRetryCountAddress;
            public byte _SettRetryCountConstOrTag;//
            public int _SettRetryCountTagID;//

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
            public byte[] ReservedBytes2;
        }

        /// <summary>
        /// Struct for MemmoryStatus.cs 
        /// Abhishek khurd.
        /// 22 Jun 07 
        /// </summary>
        [Serializable]
        public struct MemoryStatus
        {
            public int _totalNodes;
            public int _totalScreens;
            public int _totalKeys;
            public int _totalAlarms;
            public int _totalPowerOntasks;
            public int _totalGlobaltasks;
            public int _totalLogger;
            public int _totalBlockToBeRead;
            public int _totalTagName;
            public int _totalOther;

            public int _nodeBytes;
            public int _screenBytes;
            public int _keyBytes;
            public int _alarmBytes;
            public int _powerOntaskBytes;
            public int _globaltaskBytes;
            public int _loggerBytes;
            public int _blockToBeReadBytes;
            public int _tagNameBytes;
            public int _otherBytes;
            public int _historicalAlarmBytes;

            public float _availableMemory;
            public int _usedMemory;
            public int _allotedloggerDataMemory;

            //FP_CODE Pravin Ladder Memory Status
            public float _availableLadderMemory;
            public float _usedLadderMemory;
            #region FP_Ethernet_Implementation-AMIT
            public uint _ethernetsettings;
            #endregion
            //End

        }


        #region User Data
        [Serializable]
        public struct UserData
        {
            public int _userID;
            public string _userName;
            public string _userDescription;
            public string _userPassword;
            public string _userEmail;
            public string _userTelephone;
            public string _userSecretQuestion;
            public string _userAnswer;
            public byte _userAccessLevel;
            public byte _userType;
            public bool _userConfigure;
            public bool _userExecute;
            public bool _userPermToDownload;
            public bool _userPermToUpload;
            public bool _userPermToConfLadderLogic;
            public bool _userPermToCreateNewProject;

        }
        #endregion
        #region AccessLevel_Login_SY
        [Serializable]
        public struct AccessLevelUserData
        {
            public int _userID;
            public string _userName;
            public string _userPassword;
            public int _userAccessLevel;
            public string _userDsc;
        }
        #endregion

        #region Screen Information

        [Serializable]
        public struct ScreenInfo
        {
            public ushort usScrNumber;
            public string strScrName;
            public short sPassword;
            public byte btScrType;
            public byte btScrProperties;
            public string strDescription;
            public byte btBGColor;
            public short sTopLeftX;
            public short sTopLeftY;
            public ushort sHeight;
            public ushort sWidth;
            public byte btAssocitedScrNumber;
            public byte btNewlyCreatedScreen;
            public bool blTaskAssociate;
            public byte btBookmarks;
            public bool blDataEntryObjectPresent;
            public List<int> lstAssociatedScreenList;
            public ushort sScreenPrintColumns;
            public ushort sCharactersToPrint;
            public bool useTemplate;
            public ushort NoofTemplates;
            public ushort NoofLocalKeys;
            public byte btWaitForPLC;
            public string[] TemplatesList;
            public uint accessLevelScr;//AccessLevel_ScreenProp_SY
        }



        #endregion

        //FP_CODE  R12  Haresh
        #region Ladder Structures

        [Serializable]
        public struct LadderScreenInfo
        {
            //public RungManager RungManager;
            public string LadderBlockName;
            public int LadderBlockTypeIndex;
            public int LadderCommentTextColor;
            public int LadderCommentBackColor;
            public Font LadderCommentFont;
            public int BlockType;


        }

        public struct LadderOperandInfo
        {
            public int intFieldType;//Address/name
            public int intOperandType;//Reg/Constant
            public int intOperandNumber;
            public String strOperandText;
            public String strOperandName; //Haresh added to resolve find operan issue reported by Customer
            public System.Drawing.Rectangle objOperandTextRect;
            public int intTxtFontSize;

            public int intObjectID;
            //public ClassList.InstructionType InstType;
            public int intShapeID;
            public int intBytes;
            public int intDataType; //Float data change
        }


        public struct LadderTagInfo
        {
            public byte Type;
            public String Prefix;
            public byte ReadWrite;
            public byte Bytes;
            public int MinLimit;
            public int MaxLimit;
            public int DataType;//Used for math/compare instruction
        }

        public struct LadderCompilationRungInfo
        {
            public int InstructuonType;
            public int VLinkVariable;
            public string Operand;
            public int FW_Link;
            public int BK_Link;
            public int FW_End_Position;
            public int BK_End_Position;
            public int Leading_Trailing_Count;
            public int AddressTypeRegister;
            public int Constant;
            public int SourceTagIndex;
            public int DestinationTagIndex;
            public int ThirdOprandTagIndex;
            public int TableSize;
            public int Datatype;
            public int ByteFormat;
            public string Constant_String;
            public int ByteOrderValue;//Pack_Unpack_Instructions Vijay
        }



        public struct LadderMonitorTagInfo
        {
            public string TagAddress;
            public double value;
            public int OperandType;
            public int DataType;
            public int DataSize;
            //public ClassList.InstructionType InstType;

        }

        //FP_CODE Pravin UploadDataLog Instruction
        public struct LadderUploadInfo
        {
            public int InstrType;
            public int VerticalLink;
            public string strOprand1;
            public string strOprand2;
            public string strOprand3;
            public string strOprand4;
            public int AddressTypeOprand1;
            public int AddressTypeOprand2;
            public int AddressTypeOprand3;
            public long Constant1;
            public long Constant2;
            public long Constant3;
            public float floatConstant1;
            public float floatConstant2;
            public float floatConstant3;
            public string Constant_String;
            public int IndexType1;
            public int IndexType2;
            public int IndexType3;
            public int DataType;
            public int DataSize;
            public int TableSize;
            public int intRow;
            public int intColumn;
            public int ByteOrderValue;//Pack_Unpack_Instructions Vijay
        }
        //End



        public struct LadderBlockPrintInfo
        {
            public int ScreenNumber;
            public string BlockName;
            public int PrintWidth;
            public int PrintHeight;
            public int IECBlockType;
            public bool bQualifier;
            public String strQualifier;
            public String strCode;
            public int Lang;

        }

        [Serializable]
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Auto)]
        public struct LadderSaveFileHeaderInfo
        {
            public int Version;
            public int TotalLadderBlocks;
        }

        [Serializable]
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Auto)]
        public struct LadderSaveBlockInfo
        {
            public int BlockType;
            public int TotalRungs;
            public int TotalColumns;
            public int Commenttextcolor;
            public int CommentBackcolor;
            public int Rung1Backcolor;
            public int Rung2Backcolor;

        }

        [Serializable]
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Auto)]
        public struct LadderSaveRungInfo
        {
            public bool ShowCommentArea;
            public int NoRungCells;
            public int HeightCommentArea;
        }


        public struct PlcModuleHeaderInfo
        {
            public int intNoModules;
            public int BaseModuleType;
            public int intTotalBytesForModuleInfo;
            public int intRAM_OffsetXW;
            public int intRAM_OffsetYW;
            public int intRAM_OffsetMW;
            public int intNumRegisterXW;
            public int intNumRegisterYW;
            public int intNumRegisterMW;


        }
        public struct PlcModuleInfo
        {
            public int intModuleNO;
            public int intBytesForModule;
            public int intModuleAddress;
            public int intModuleFirmwareRevision;
            public int intModuleType;
            public int intRAM_OffsetXW;
            public int intRAM_OffsetYW;
            public int intRAM_OffsetMW;
            public int intNumberOfXCOils;
            public int intNumberOfYCOils;
            public int intNumRegisterXW;
            public int intNumRegisterYW;
            public int intNumRegisterMW;
            public int intNumberOfMCoils;



        }

        public struct DoubleData
        {
            public double dbValue;

        }
        //For Find Instruction
        public struct LadderInstructionListInfo
        {
            public int intBytes;
            public string Instruction_Name;
            //public ClassList.InstructionType InstType;
        }
        //For Find Instruction
        public struct LadderAddressListInfo
        {
            public int intOperandType;//Reg/Constant
            public int intOperandNumber;
            public String strOperandText;

            public int intObjectID;
            public string Instruction_Name;
            //public ClassList.InstructionType InstType;
            public System.Drawing.Rectangle objRect;
            public int intShapeID;
            public int intBytes;
        }
        [Serializable]
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Auto)]
        public struct LadderSettingsInfo
        {
            public bool ShowRegisterEntryMessage;
            public int ColorContactOnState;
            public int ColorContactOffState;
            public int ColorFunctionBlock;
            public int ColorOperandVale;
            public int ColorLadderBackGroundArea;
            public int ColorLeftMarginRung1;
            public int ColorLeftMarginRung2;
            public int ColorActiveRung;
            public int TagNameLen_Display;
            public bool b_chkhaltmode_dnld;
            public bool b_chkrunmode_dnld;
            public bool b_chkcleanmemory_dnld;
            public bool b_chkPLCMemory_dnld;
            public bool b_chkApplication_dnld;
            public bool b_chkLadder_dnld;
            public bool b_chkData_dnld;
            public int Comm_Mode;
            //FP Code Pravin Serial Monitor
            public int Comm_Type;
            public int Com_Port;
            //End
            public int Color_BOOL;
            public int Color_BYTE;
            public int Color_WORD;
            public int Color_DWORD;
            public int Color_INT;
            public int Color_SINT;
            public int Color_DINT;
            public int Color_USINT;
            public int Color_UDINT;
            public int Color_REAL;
            public int Color_UINT;
            public int Color_TIME;
            public bool b_ForceIO;
            public bool b_ShowNewInst_DefaultTagSel; //Default_TagSelUI_Change
        }
        public struct TimerAddressListInfo
        {
            public string TagAddress;
            public double value;
            public int OperandType;
            public int TagAddressCount;
            public uint intObjectId;
            public string Prefix;
        }

        //Issue_928 Vijay
        public struct CounterAddressListInfo
        {
            public string TagAddress;
            public double value;
            public int OperandType;
            public int TagAddressCount;
            public uint intObjectId;
            public string Prefix;
        }

        public struct LadderTagAddressInfo
        {
            public int intFieldType;//Address/name
            public int intOperandType;//Reg/Constant
            public int intOperandNumber;
            public String strOperandText;
            public System.Drawing.Rectangle objOperandTextRect;
            public int intTxtFontSize;
            public int intTableSize;

            public int intObjectID;
            //public ClassList.InstructionType InstType;
            public int intShapeID;
            public int intBytes;

        }

        public struct LadderBlockListInfo
        {
            public ushort ScreenNumber;
            public int BlockType;
            public string BlockName;
            public int NumberOfBlocks;
        }
        public struct ScreenList
        {
            public int _screenNumber;
            public string _screenName;
        }
        public struct ScreenTagIDList
        {
            public int screenNumber;
            public int TagID;
        }
        //For IEC data Monitor
        public struct DataMonitorTagInfo
        {
            public string Name;
            public string DataType;
            public string Value;
            public int ReadOnly; //Issue_186 Vijay
        }

        public struct DMVarInfo
        {
            public string Name;
            public UInt32 address;
        }
        public struct DMComInfo
        {
            public UInt32 address;
            public uint offset;

        }
        public struct TagObjInfo
        {
            public String Type;
            public String Name;

        }
        public struct BlockNameInfo
        {
            public String OriginalName;
            public String NewName;

        }
        //Vijay_Sub
        public struct SubParameters
        {
            public String VariableName;
            public String DataType;
            public bool IOType;
        }
        public struct ForNextInfo
        {

            public uint ObjectID;
            public int RungNo;
        }
        //SFC_change   
        public struct level2TypeInfo
        {
            public int Type;
            public System.Drawing.Rectangle rectInfo;
        }
        public struct SfcItemInfo
        {
            public int ItemType;
            public int StepNumber;
            public int TransNumber;
            public int CommentNumber;
            public int LangP1;
            public int LangP0;
            public int LangN;
            public int LangConition;
            public String CodeAction;
            public String CodeP1;
            public String CodeP0;
            public String CodeN;
            public String CodeNotes;
            public String CodeCondition;
            public String CodeComment;
        }
        public struct TreeNodeInfo
        {
            public String Name;
            public TreeNode Node;
        }
        public struct ChildInfo
        {
            public String Name;
            public int level;
        }
        //SFC_new_change  Haresh added to resolve issue 30
        public struct ChildNodeInfo
        {
            public String Name;
            public String ParentName;
            public int ScreenNumber;

        }
        //UDB_Change Haresh
        public struct InstanceInfo
        {
            public String strName;
            public String strGroup;
            public String strUDFBname;

        }

        //Find_change_native
        public struct FindInfo
        {
            public uint ObjectID;
            public int RungNo;
            public int LineNo;
            public String BlockName;
            public String InstName;

        }
        //Haresh Debug_change
        public struct BreakPointInfo
        {
            public uint ObjectID;
            public int ScreenNumber;
            public long StepAddress;

        }
        public struct DebugStepInfo
        {
            public int runNo;
            public int Row;
            public int Column;
            public String Operand;
            public int StepNo;
            public long startAddress;
            public uint ObjectID;

        }
        ///
        ///
        ///
        ///
        //FP_Product_Conversion
        #region Version2.0Incr1_ProductConversion

        public struct ModelDataInfo
        {
            public int iPrizmId;
            public int iHIOId;
            public string strModelSeries;
            public string strModel;
            public string strDigitalInputs;
            public string strAnalogInputs;
            public string strDigitalOutputs;
            public string strAnalogOutputs;
            public string strDigitalOutputType;
            public string strAnalogInputType;
            public string strAnalogOutputType;
            public string strAnalogIOConfiguration;
            public string strNote;
            public int iModelNo;
            public bool blCOM1;
            public bool blCOM2;
            public bool blEthernet;
            public bool blUSB;
            public bool blExpansionPort;
            public int iConversionID;
            public int iVersionID;
            public bool blTouchGrid;
            public bool blGridConfiguration;
            public bool blOverlappingAllowed;
            public int iMemory;
            public int iProductTypeID;
            //int Ports>1 Serial Port, USB</Ports>
            public int iNoOfCharactersToPrint;
            public int iScrColumns;
            public bool blScrColumnsReadOnlyFlag;
            public int iBootId;
            public int iApplicationmemory;
            public int iHistoricalAlarmsMemory;
        }

        /// <summary>
        /// Product Conversion - Resoution Preference Values.
        /// </summary>
        public struct ResolutionValues
        {
            public bool _blHeightKeepSameSize;
            public bool _blWidthKeepSameSize;

            public bool _blHeightDelOutsideObject;
            public bool _blWidthDelOutsideObject;

            public bool _blHeightScaleObjSize;
            public bool _blWidthScaleObjSize;

            public bool _blHeightScaleTextSize;
            public bool _blWidthScaleTextSize;
        }

        /// <summary>
        /// Product Conversion - Port Preference Values.
        /// </summary>
        public struct PortValues
        {
            public int _iNoOfSourcePorts;
            public int _iNoOfDestPorts;
            public bool _blSetDefaultParameters;
            public bool _blCopyFromSource;
            public List<Port> _lstSourcePorts;
            public List<Port> _lstDestPorts;
            public List<PortActions> _lstPortActions;
        }

        /// <summary>
        /// Product Conversion - Key Preference Values.        
        /// </summary>
        public struct KeyValues
        {
            public int _iNoOfSourceKeys;
            public int _iNoOfDestKeys;
            public int _iSelectedKeyNo;
        }

        /// <summary>
        /// Product Conversion - Color values structure.        
        /// </summary>        
        public struct ColorValues
        {
            public int _iNoOfSourceSupportedColor;
            public int _iNoOfDestSupportedColor;
        }
        public struct DelTagInfo
        {
            public int TagID;
            public String TagName;
        }
        public struct DefTagInfo
        {
            public int Type;
            public String Address;
            public int bytes;
            public int bitNumber;

        }
        public struct memStatusVarInfo
        {
            public String DataType;
            public int Count;
            public int memUsed;


        }
        #endregion Version2.0Incr1_ProductConversion
        #region Issue_1084 Vijay
        public struct ScreenTaskUsage
        {
            public ClassIdentification iClassIdentification;
            public int iEntityId;
            public string strEntityName;
            public string strInstructionName;
            public int screenTaskType;
            public int screenTaskID;
            public int ScreenNumber;
            public String ObjectText;
            public String Coordinate;
            public String TaskName;
        }
        #endregion
        //Import_Tasks HJ
        public struct ImportTaskInfo
        {
            public bool bImportPWOnTasks;
            public bool bImportGTasks;
            public bool bImportScrTasks;
            public int CountPowerOnTasks;
            public int CountGlobalTasks;
            public bool bImportScrBeforeSHTasks;
            public bool bImportScrWhileSHTasks;
            public bool bImportScrAfterHTasks;
            public String strProjectFilePath;
            public String strSourceScreen;
            public String strDestScreen;
            public int taskAddedPOn;
            public int taskAddedG;
            public int taskAddedScrBSh;
            public int taskAddedScrWSh;
            public int taskAddedScrAh;
            public int numberSourceScreen;
            public int CountScreenTasksBSH;
            public int CountScreenTasksWSH;
            public int CountScreenTasksAH;
            public bool errorPLCTasks;
        }
        //GWY00_Change
        public struct GwyPLCInfo
        {
            public String strName_PlcSource;
            public String strName_ModelSource;
            public int RegLen_Source;
            public int Plc_Code_Source;
            public int ModelNo_Source;

            public String strName_PlcDest;
            public String strName_ModelDest;
            public int RegLen_Dest;
            public int Plc_Code_Dest;
            public int ModelNo_Dest;
        }
        public struct GwyPLCPortInfo
        {
            public int iPort;
            public int iNodeAddress;
            public int iPlc_Code;
            public int iPlc_Model;
            public int iRegLen;
            public int strProtocolName;

        }
        public struct GwyRegCoilInfo
        {
            public String strName;
            public String strPrefix;
            public String strSuffix;
            public String strType;
            public String strRWType;
            public String strBlockSize;
            public int NoParts;
            public int Len_Part1;
            public String strDataType_Part1;
            public String strLoLimit_Part1;
            public String strHiLimit_Part1;
            public int Len_Part2;
            public String strDataType_Part2;
            public String strLoLimit_Part2;
            public String strHiLimit_Part2;

        }
        public struct GwyBlockInfo
        {
            public int iCountWords;
            public int iCountRepCycle;
            public int iComPort_Source;
            public int iPlc_Code_Source;
            public int iPlc_Model_Source;
            public int iNodeAddress_Source;
            public String strPrefix_Source;
            public String strSuffix_Source;
            public String strAddress_Source;

            public int iComPort_Dest;
            public int iPlc_Code_Dest;
            public int iPlc_Model_Dest;
            public int iNodeAddress_Dest;

            public String strPrefix_Dest;
            public String strSuffix_Dest;
            public String strAddress_Dest;
            public String strComment;

        }
        public struct GwyErrorBitInfo
        {
            public int iComPort_Source;
            public int iPlc_Code_Source;
            public int iNodeAddress_Source;
            public String strAddress_Source;
            public String strPrefix_Source;
            public String strSuffix_Source;

            public int iComPort_Dest;
            public int iPlc_Code_Dest;
            public int iNodeAddress_Dest;
            public String strAddress_Dest;
            public String strPrefix_Dest;
            public String strSuffix_Dest;
        }
        public struct GwyContolWordInfo
        {
            public int iComPort;
            public int iPlc_Code;
            public int iNodeAddress;
            public String strAddress;
            public String strPrefix;
            public String strSuffix;
        }
        public struct GwyDnld_MultiNodeInfo
        {
            public int iSrcCom1Bytes;
            public byte bSrcCom1BlkCount;
            public byte[] btArr1SrcCom1;
            public byte[] btArr2SrcCom1;
            public int iSrcCom2Bytes;
            public byte bSrcCom2BlkCount;
            public byte[] btArr1SrcCom2;
            public byte[] btArr2SrcCom2;


        }
        #endregion

        #region Node Data
        [Serializable]
        public struct NodeInfo
        {
            public int _iNodeId;
            public string _strName;
            public ushort _usAddress;
            public byte _btType;
            public byte _btPort;
            public string _strProtocol;
            public string _strModel;
            public byte _btHasTag;
            public string _strPortName;
            public byte _btPLCCode;
            public byte _btPLCModel;
            public byte _btRegLength;
            public byte _btSpecialData1;
            public byte _btSpecialData2;
            public byte _btSpecialData3;
            public ushort _usTotalBlocks;
            public uint _uiEthernetIpAddress;
            public ushort _usEthernetPortNumber;
            public ushort _usEthernetScanTime;
            public ushort _usEthernetResponseTimeOut;
            public byte _btBaudRate;
            public byte _btParity;
            public byte _btDataBits;
            public byte _btStopBits;
            public byte _btRetryCount;///Retry count _btReserved1
            public ushort _usInterframeDelay;
            public ushort _usResponseTime;
            public byte _btInterByteDelay;
            //public byte       _btReserved2;///Low byte of Interframe delay
            //public byte       _btReserved3;///High byte of Interframe delay
            //public byte       _btReserved4;///Low byte of Response time
            //public byte       _btReserved5;///High byte of Response time
            //public byte       _btReserved6;///Inter byte delay
            //                             ///
            public byte _btFloatFormat;
            public byte _btIntFormat;
            public byte _btExpansionType;
            public byte _btIntFourFormat; //Int Format
            public byte _btFormatPort3;  //Haresh Format for Port3
            //U12GSM  GSM_Sanjay
            public string _strGSMMobileNo;
            public byte _btGSMMobileNoLength;
            public byte _modbusSlaveID;//SS_ModbusSameNodeAddr
            public byte _dwnldSerialParams;//SS_SerialParam
            public byte _btReconnectCntrl;//SS_ReconnectCntrl
            public int _ReconnectTag;
            public byte _btFloatFormatfor8byte;//LREAL_New_SY
        }

        // G9SP_SAFETY_CONTROLLER Ethernet Support SP
        #region G9SP_SAFETY_CONTROLLER Ethernet Support SP
        [Serializable]
        public struct G9SPNodeInfo
        {
            public int _iNodeId;
            public string _strName;
            public ushort _usAddress;
            public byte _btType;
            public byte _btPort;
            public string _strProtocol;
            public string _strModel;
            public byte _btHasTag;
            public string _strPortName;
            public byte _btPLCCode;
            public byte _btPLCModel;
            public byte _btRegLength;
            public byte _btSpecialData1;
            public byte _btSpecialData2;
            public byte _btSpecialData3;
            public ushort _usTotalBlocks;
            public uint _uiEthernetIpAddress;
            public ushort _usEthernetPortNumber;
            public ushort _usEthernetScanTime;
            public ushort _usEthernetResponseTimeOut;
            public byte _btBaudRate;
            public byte _btParity;
            public byte _btDataBits;
            public byte _btStopBits;
            public byte _btRetryCount;
            public ushort _usInterframeDelay;
            public ushort _usResponseTime;
            public byte _btInterByteDelay;
            public byte _btFloatFormat;
            public byte _btIntFormat;
            public byte _btExpansionType;
            public byte _btIntFourFormat; //Int Format
            public byte _btFormatPort3;  //Haresh Format for Port3
            //U12GSM  GSM_Sanjay
            public string _strGSMMobileNo;
            public byte _btGSMMobileNoLength;


            public byte _btG9SPSrcNetwork;
            public byte _btG9SPSrcNode;
            public byte _btG9SPSrcID;
            public byte _btG9SPDestNetwork;
            public byte _btG9SPDestNode;
            public byte _btG9SPDestID;
            public byte _btReserved;
            public byte _dwnldSerialParams;//SS_SerialParam
            public byte _btReconnectCntrl;//SS_ReconnectCntrl
            public int _ReconnectTag;
        }
        #endregion
        public struct stReconnectNode//:IComparable   //SS_ReconnectCntrl
        {
            public ushort _usAddr;
            public byte[] _BitAddr;

            public stReconnectNode(int pSizeArr)
            {
                _usAddr = 0;
                _BitAddr = new byte[pSizeArr];
            }

            //public int CompareTo(Object pObj)
            //{
            //    stReconnectNode ThatNode = (stReconnectNode)pObj;

            //    if (this._usAddr > ThatNode._usAddr)
            //        return -1;
            //    if (this._usAddr < ThatNode._usAddr)
            //        return 1;

            //    return 0;
            //}
        }
        public struct MITQSettings
        {
            public byte Port;
            public byte NodeAddress;
            public byte NetworkNumber;
            public byte PCNumber;
            public ushort DestModuleIONo;
            public byte DestModuleStNo;
        }

        #region Siemens Micromaster Driver(USS) ShitalG
        public struct USSDriverInfo
        {
            public byte _btPort;
            public byte _btNodeAddress;
            public ushort _usControlWord1;
            public ushort _usControlWord2;
            public ushort _usControlWord3;
            public ushort _usStatusWord1;
            public ushort _usStatusWord2;
            public byte[] _btReserved;
        }
        #endregion

        public struct ScreenSaverSettings
        {
            public string strUserName;
            public string strPassword;
        }
        #endregion

        #region Tag Data
        //[StructLayout(LayoutKind.Sequential, Pack = 1)]
        //public struct Prizm3TagStructure
        //{
        //    public ushort _TagSize;
        //    public byte _TagBy;
        //    public byte _TagType;
        //    public byte _ReadWrite;
        //    public byte _BitNumber;
        //    public byte _NoOfBytes;
        //    public byte _LowHigh;
        //    public string _TagAddress;
        //    public string _TagName;
        //    public string _NodeName;
        //    public int _RegMinRange;
        //    public int _RegMaxRange;
        //    public int _TagValue;
        //    public bool _IsTagUsed;
        //    public bool _IsTagSystem;
        //    public int _NodeID;
        //    public int _ComID;
        //    public int _PLCCode;
        //    public int _TagTagID;
        //}
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Prizm3TagStructure
        {
            public ushort _TagSize;
            public byte _TagBy;
            public byte _TagType;
            public byte _ReadWrite;
            public byte _BitNumber;
            public byte _NoOfBytes;
            public byte _LowHigh;
            public string _TagAddress;
            public string _TagName;
            public string _NodeName;
            public int _RegMinRange;
            public int _RegMinRange2;//
            public int _RegMaxRange;
            public int _RegMaxRange2;//
            public int _TagValue;
            public int _TagValue2;//
            public bool _IsTagUsed;
            public bool _IsTagSystem;
            public bool _IsSpecialRangePLCTag; //
            public bool _IsSpecialCharPresentInTagAddr;
            public int _NodeID;
            public int _ComID;
            public int _PLCCode;
            public int _TagTagID;
            public string _strPrefix;
            public string _strSuffix;
            public string _blockStartAdderess;
            public int _blockNumber;
            public ushort _blockSize;
            public int _TagNumber;
            public int _RegNo; //Register no in xml
            public int _NoofParts;
            public string _DataTypePart1; //FP_CODE Haresh
            public string _DataTypePart2;
            public int _LengthPart1; //FP_CODE Haresh
            public int _LengthPart2;
            #region Straton_DatatypeChange
            public string _StratonDataType;
            public byte _StratonBlockType;//0-Global, 1- Retentive, 2-Local
            public string _StratonInitialValue;
            public int _StratonDataTypeStringLength;//String DataType Length Sanjay
            public byte _IsExpansionTag;
            public byte _IsRetentiveRegister;
            public string _StratonGroupName;
            #region ss_StratonSysExpTagFormat
            public byte _slotNo;//For expansion tags
            public string _nativePrefix;//only applicable to Expansion and System tags (e.g. X,Y,XW,YW,MW,S,SW)
            public string _nativeAddrVal;//Exp:Register Address value e.g. 007, Sys:Tag value
            public string _nativeAddress;//complete native tag address
            #endregion
            #endregion
            public byte IsLocalIOTag;//ss_Slot0Expansion
            #region Save_Optimization_SS
            public bool _IsNodeStatusTag;
            public byte _StatusNodePort;//SS_DefaultTagEdit
            public ushort _StatusNodeAddr;
            #endregion
            public string _Dimension; //Array_change
            public string _ArrTagInfo;
            public string _StructureName;//Structure_SY
            public string _StructureObjName;//Structure_SY
            public bool _ForExport; //CheckBoxAddedForTagExport Vijay
            public int _TagGroup;//SS_TagGroup
        }



        #endregion

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct TagInfo
        {
            public string _TagAddress;
            public string _strDriver;
            public string _strProtocol;
        }

        #region Block Data
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Prizm3BlockStructure
        {
            public byte _BlockByteSize;
            public int _BlockLengthOfStartingAddress;
            public string _BlockStartingAddress;
            public byte _BlockBlockSize;
            public int _BlockNoOfTags;
            public byte _BlockBlockTypes;
            public string _BlockPrefix;
            public string _BlockSuffix;
        }
        #endregion

        #region Font Structures
        [Serializable]
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Auto)]
        public struct FontInfo
        {
            public short _fPtSzForFont;
            public int _fFontHeight;
            public int _fFontWidth;
            public int _fEscapement;
            public int _fOrientation;
            public int _fWeight;
            public byte _fItalic;
            public byte _fUnderline;
            public byte _fStrikeOut;
            public byte _fCharSet;
            public byte _fOutPrecision;
            public byte _fClipPrecision;
            public byte _fQuality;
            public byte _fPitchFamily;
            public byte _fLenOfFaceName;
            public byte _fFontAdjByte;

        }

        [Serializable]
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class LOGFONT
        {
            public const int LF_FACESIZE = 32;
            public int lfHeight;
            public int lfWidth;
            public int lfEscapement;
            public int lfOrientation;
            public int lfWeight;
            public byte lfItalic;
            public byte lfUnderline;
            public byte lfStrikeOut;
            public byte lfCharSet;
            public byte lfOutPrecision;
            public byte lfClipPrecision;
            public byte lfQuality;
            public byte lfPitchAndFamily;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = LF_FACESIZE)]
            public string lfFaceName;
        }

        [Serializable]
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Auto)]
        public struct Range
        {
            public uint iLowLimit;
            public uint iHighLimit;
        }

        [Serializable]
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class TEXTMETRIC
        {
            public int tmHeight;
            public int tmAscent;
            public int tmDescent;
            public int tmInternalLeading;
            public int tmExternalLeading;
            public int tmAveCharWidth;
            public int tmMaxCharWidth;
            public int tmWeight;
            public byte tmItalic;
            public byte tmUnderlined;
            public byte tmStruckOut;
            public byte tmFirstChar;
            public byte tmLastChar;
            public byte tmDefaultChar;
            public byte tmBreakChar;
            public byte tmPitchAndFamily;
            public byte tmCharSet;
            public int tmOverhang;
            public int tmDigitizedAspectX;
            public int tmDigitizedAspectY;
        }

        [Serializable] //Manisha
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Auto)]
        public struct AssociatedScreenInfo
        {
            public uint BaseScreenNo;
            public List<int> AssoTemplateList;
            public List<string> AssoTemplateNames;
            public AssociatedScreenInfo(int i)
            {
                BaseScreenNo = 0;
                AssoTemplateList = new List<int>();
                AssoTemplateNames = new List<string>();
            }

        }
        #endregion

        #region Project Info Structure
        public struct ProductData
        {
            public int DataColorSupported;
            public bool PatternSupported;
            public bool IsColorReverse;
            public int ScreenWidth;
            public int ScreenHeight;
            public System.Byte[,] ColorArray;
            public string[] ScreenObjects;
            //Added By Samir 13th April 2007
            public byte UnitType;   //Used for Password Screen (Default keyboard) 0 - Keyboard, 1 - TouchScreen, 2 - Both.
            public bool BlSnapToGrid;
            public Size SzAlphanumericGridSize;
            public Size SzTouchGridSize;
            public bool ShowAlphanumericGrid;
            public bool ShowTouchGrid;
            public bool IsOverlapAllowed;  //punit 19th jun
            public int iProductID;         //Samir 17th July 
            public int iPopUpScreenWidth;
            public int iPopUpScreenHeight;
            public byte btPrizmVersion;//for prizm 3.12 = 10, for prizm 4.00 = 40
            public byte Orientation;    //1- vertical 0-horizontal
            public ushort NoOfCharactersToPrint;
            public ushort ScreenColumns;
            public bool ScrColumnsReadOnlyFlag;
            public uint _accesslevlscr;//AccessLevel_ScreenProp_SY
        }
        public struct LanguageInformation  //manisha 27th apr '07
        {
            public string LanguageName;
            public int LanguageId;
            public bool KeyboardLayout;
        }
        #endregion

        #region TagUsage Information Structure
        /// <summary>
        /// umesh 10-july-06.
        /// The structure is used to get tag information of class and objects 
        /// where the selected tag is used.
        /// </summary>
        [Serializable]
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Auto)]
        public struct TagUsageInformation
        {
            public ClassIdentification iClassIdentification;
            public int iEntityId;
            public string strEntityName;
            public string strInstructionName;//Ladder_change_R11
            public int intRungNumber;
            public int intLineNumber; //End
            public int screenTaskType;//PR1339 Sheetal
            public int screenTaskID;//PR1339 Sheetal

        }
        #endregion

        public struct ProductConversionSourceAppParameters
        {
            public float ResolutionX;
            public float ResolutionY;
            public int ModelNo;
            public string Name;
            public bool PortCom1;
            public bool PortCom2;
            public bool PortEth;
            public int ProjectID;
            public int SlotCount;
        }

        public struct ProductConversionDestinationAppParameters
        {
            public float ResolutionX;
            public float ResolutionY;
            public int ModelNo;
            public string Name;
            public bool PortCom1;
            public bool PortCom2;
            public bool PortEth;
            public int SlotCount;
            public CommonConstants.ProductData objDestProductData;
        }

        public struct ProductConversionPreferences
        {
            public bool scalingOfObjects;
        }

        public struct ProductConversionParameters
        {
            public ProductConversionDestinationAppParameters destination;
            public ProductConversionSourceAppParameters source;
            public ProductConversionPreferences preferences;
        }




        [Serializable]
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Auto)]
        public struct ErrorInfo
        {
            public ushort usScreenNumber;
            public string strScreenName;
            public uint uiErrorSourceID;
            public string strErrorSourceName;
            public byte btErrorType;
            public byte btWarningType;
            public string strScreenNotDefined;
        }

        #region SS_ScreenTagImport
        [Serializable]
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Auto)]
        public struct ImportWarningInfo
        {
            public string ScreenNumber;
            public string ScreenName;
            //public uint ErrorSourceID;//Object index/task id
            public ImportScreenErrSrcType ErrorSourceType;//obj/task/key task
            public string ShapeName;//Reg data entry/bargraph/wordbutton can be shape name
            public string ShapeObjID;//Object ID as seen in property grid
            public string ObjProperty;//Animation/FB tag/Min Max Tag etc
            public string TaskName;//"Write Value to Tag" etc 
            public string KeyNumber;//F1/F2/F1-F2
            public string KeyTaskType;//Press/Pressed/Released
            public string warningDescp;
        }
        public enum ImportScreenWarnings
        {
            NONE,
            OBJECT_REMOVED,
            DATALOGGER_ABSENT_TREND,
            TAG_NODE_NOT_SUPPORTED,
            TAG_NODE_NOT_ADDED,
            TAG_NODE_ADDRESS_PRESENT,
            TAG_NOT_SUPPORTED,
            TAG_NOT_IMPORTED
        }
        public enum ImportScreenErrSrcType
        {
            OBJECT,
            OBJECT_TASK,
            SCREEN_TASK,
            SCREEN_KEY_TASK
        }

        #endregion

        [Serializable]
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Auto)]
        public struct TaskListInfo4AS
        {
            public int iTouchKeyByte;
            public short sTopLeftX;
            public short sBottomRtY;
            public short sBottomRtX;
            public short sTopLeftY;
            public short sNoOfPressTasks;
            public short sNoOfPressedTasks;
            public short sNoOfReleaseTasks;
            public short sTotalPressTasks;
            public short sTotalPressedTasks;
            public short sTotalReleaseTasks;
        }

        [Serializable]
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Auto)]
        public struct CondTaskInfo
        {
            public short sBytes4CondTask;
            public byte btTaskCode;
            public byte btAdjByte;
            public short sNoOfState;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] btIndirectAddrOfTask;
            public byte btOpnVal;
            public short sOpdNo;
            public byte btReservedByte;

        }

        [Serializable]
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Auto)]
        public struct TaskListInfo4ES
        {
            public byte btStateNo;
            public byte btAdjByte;
            public ushort usLowLimit;
            public ushort usHighLimit;
            public short sTouchKeyByte;
            public short sNoOfPressTasks;
            public short sNoOfPressedTasks;
            public short sNoOfReleaseTasks;
            public short sTotalPressTasks;
            public short sTotalPressedTasks;
            public short sTotalReleaseTasks;
        }


        #region OldAlarmInfoStructCode
        //[Serializable]
        //[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Auto)]
        //public struct AlarmInfo
        //{
        //    public byte BitAlarmNumber;
        //    public byte GroupNumber;
        //    public string AlarmText;
        //    public bool AlarmActions;
        //    public int TagId;
        //    public uint AlarmId;
        //    public string AlarmName;
        //    public byte AlarmAttribute;
        //}


        ///// <summary>
        ///// Common structure to keep groupwise information of Alarm.
        ///// </summary>
        //[Serializable]
        //[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        //public struct AlarmGroup
        //{
        //    public byte GroupNumber;
        //    public byte adjbyte;
        //    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        //    public byte[] DirectAddressTag;
        //    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        //    public byte[] IndirectAddressTag;
        //}
        //[Serializable]
        #endregion

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Auto)]
        public struct LoggerGroupInfo
        {
            public byte LoggerMode;
            public byte LoggerFrequencyHour;
            public byte LoggerFrequencyMinute;
            public byte LoggerFrequencySecond;
            public byte Reserved1;
            public byte LoggerStartTimeHour;
            public byte LoggerStartTimeMinute;
            public byte LoggerStartTimeSecond;
            public byte LoggerStopTimeHour;
            public byte LoggerStopTimeMinute;
            public byte LoggerStopTimeSecond;
            public byte DataType;
            public byte LoggedTags;
            public byte Reserved3;//used for Data Logger Logger event
            public byte LoggingMode;//used for Logging mode (Normal/Fast)//Fast_Logging Vijay
            #region Internal_External_Type Vijay
            public byte FileSendAtEveryHour;
            public byte FileSendAtEveryMinute;
            public byte FileSendAtEverySecond;
            public string LoggingFileName;
            #endregion
        }
        #region Data_Logging_Modification Vijay
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Auto)]
        public struct LoggerGroupInfoExternal
        {
            public byte LoggerMode;
            public byte LoggerFrequencyHour;
            public byte LoggerFrequencyMinute;
            public byte LoggerFrequencySecond;
            public byte Reserved1;
            public byte LoggerStartTimeHour;
            public byte LoggerStartTimeMinute;
            public byte LoggerStartTimeSecond;
            public byte LoggerStopTimeHour;
            public byte LoggerStopTimeMinute;
            public byte LoggerStopTimeSecond;
            public byte DataType;
            public byte LoggedTags;
            public byte Reserved3;//used for Data Logger Logger event
            public byte LoggingMode;//used for Logging mode (Normal/Fast)//Fast_Logging Vijay           
            public string LoggingFileName;
        }
        #endregion
        [Serializable]
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Auto)]
        public struct PrintPropertiesInfo
        {
            public byte PrintingStatus; //(  0 : Not defined     1 : Defined)
            public ushort GroupBytes;
            public byte TagTypeForPageLines; //( 0: Direct       1 : Indirect)
            public int TagIdForPageLines;  //Tag id for page lines
            public byte PageLines;  //Max 60
            public byte PaperSize;
            public ushort LeftMargin;
            public ushort RightMargin;
            public ushort TopMargin;
            public ushort BottomMargin;
            public byte HeaderDateDisplay;
            public byte TimeColumnDisplay;
            public byte TimeColumnWidth;
            public byte FooterDateDisplay;
            public int NoofTagstobePrinted;
            public string HeaderLine1;
            public string HeaderLine2;
            public string HeaderLine3;
            public string HeaderLine4;
            public string FooterLine1;
            public string FooterLine2;
            public string FooterLine3;
            public string FooterLine4;
            public string PowerFailure;
            public string CommBreak;
            public string PowerUp;
        }
        [Serializable]
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Auto)]
        public struct PrintTagsInformation
        {
            public string HeaderName;
            public ushort ColumnWidth;
            public byte Format;
            public byte DecimalPointLocation;
            public byte DataType;   //( 0: Uint, 1: Sint, 2: Hex ,3: BCD , 4: Float)
            public byte GroupofTag;
            public byte TagIndex;
            public int TagId;
        }

        //samir 27th apr '07
        ////Add
        /// <summary>
        /// Structure to Store Analog Configuration Settings for Each Channel
        /// </summary>
        [Serializable]
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Auto)]
        public struct AnalogInputConfiguration
        {
            public byte InputChannelNo;                     //(0 to n)
            public byte InputChannelTypeIndex;
            public byte InputChannelDependentTypeIndex;
            public byte InputChannelIndex;
            public byte InputDataRegister1TypeIndex;        //(?D?=0, ?@?=1) 
            public byte InputCalibration;                   // (0-Disable 1-Enable)
            public short InputDataRegister1Value;
            public byte InputDataRegister2TypeIndex;        //(?D?=0, ?@?=1, ?S?=2)
            public byte InputChannelTypeChar;               //(Not Config=?N?, Thermocouple=?T?, RTD=?R?, mA=?A?, mV=?V?, Data Register (Data Reg=?D?, System Reg=?S?)
            public short InputDataRegister2Value;
            public byte InputDataRegister3TypeIndex;        //(?D?=0, ?@?=1)
            public byte AdjustingByte1;
            public short InputDataRegister3Value;
            public byte InputDataRegister4TypeIndex;        //(?D?=0, ?@?=1)
            public byte NormalizationFactor;                //(0-99)
            public short InputDataRegister4Value;
            public byte BaudRate;                           //(0-9600, 1-19.2K, 2-57.6K, 3-115.2K)
            public byte Parity;                             //(0-None, 1-Even, 2-Odd)
            public byte DataBit;                            // (0-8, 1-7)
            public byte StopBit;                            //(0-1, 1-2)
            public byte DeviceId;                           //(0-255)
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 45)]
            public byte[] ReservedBytes;
        }

        [Serializable]
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Auto)]
        public struct AnalogOutputConfiguration
        {
            public byte OutputChannelNo;                     //(0 to n)
            public byte OutputChannelTypeIndex;
            public byte OutputChannelDependentTypeIndex;
            public byte OutputChannelIndex;
            public byte OutputDataRegister1TypeIndex;        //(?D?=0, ?@?=1) 
            public byte OutputCalibration;                   // (0-Disable 1-Enable)
            public short OutputDataRegister1Value;
            public byte OutputDataRegister2TypeIndex;        //(?D?=0, ?@?=1, ?S?=2)
            public byte OutputChannelTypeChar;               //(Not Config=?N?, Thermocouple=?T?, RTD=?R?, mA=?A?, mV=?V?, Data Register (Data Reg=?D?, System Reg=?S?)
            public short OutputDataRegister2Value;
            public byte OutputDataRegister3TypeIndex;        //(?D?=0, ?@?=1)
            public byte AdjustingByte3;
            public short OutputDataRegister3Value;
            public byte OutputDataRegister4TypeIndex;        //(?D?=0, ?@?=1)
            public byte AdjustingByte4;
            public short OutputDataRegister4Value;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
            public byte[] ReservedBytes;
        }
        /// <summary>
        /// The global block list is used to create block list for application tasks,
        /// datalogger and alarm plc specific tags except modbus slave tag.The number of blocks variable is not 
        /// included, it can be calculated from block number byte counts.
        /// The same structure can also be used to create screen block list.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct BlockList
        {
            public byte _btPort;
            public ushort _usNodeAddress;
            public List<ushort> _usBlockNumber;
        }
        /// <summary>
        /// The structure is used to show screen task information. It displays screen name, block name and whether
        /// it is used in while showing tasks, after hiding tasks or before showing tasks
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct ScreenLadderTaskInfo
        {
            public int ScreenNo;
            public string ScreenName;
            public string BlockName;
            public bool IsUsedInBeforeShowingTasks;
            public bool IsUsedInWhileShowingTasks;
            public bool IsUsedInAfterHidingTasks;
        }
        /// <summary>
        /// The structure is used to pass import tag information to coreclasses importfilehandler class.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct ImportTagInfo
        {
            public bool _CreateDuplicates;
            public bool _AutogenerateTagName;
            public bool _ViewLogFile;
            public int _TagNameColumn;
            public int _NodeName1Column;//For node name in node import parameters
            public int _TagAddressColumn;
            public int _TagTypeColumn;
            public int _TagPrefixColumn;
            public int _BytesColumn;
            public int _NodeName2Column;//For node name in tag import parameters.
            public int _ProtocolColumn;
            public int _ModelColumn;
            public int _PortColumn; // for node
            public int _TagPortcolumn; // for tag
            public string _ImportFileName;
            public bool _IsAscii;    //If it is true then the data stored in file is in AScii format other wise in Uni-code format
            public int _SlotNumberColumn;
            #region ss_StratonSysExpTagFormat import/export tag changes
            public int _NativePrefixColumn;
            public int _NativeAddressColumn;
            public int _NativeAddrValColumn;
            #endregion
            #region ss_Issue426
            public int _StratonBlockTypeColumn;
            public int _StratonBlockNameColumn;
            public int _StratonInitialValueColumn;
            public int _IsRetentiveColumn;
            #endregion
            #region Import/Export_ModbusTags_Issue809_Vijay
            public int _Com1MappingAddressColumn;
            public int _Com2MappingAddressColumn;
            public int _Com3MappingAddressColumn;
            public int _StringLength; //StratonDataTypeStringLength Vijay
            #endregion
            public int _dimensionColumn; //Array_change
            public int _arrTagInfoColumn;
            public int _modbusSlaveIDColumn;//SS_ModbusSameNodeAddr
        }
        /// <summary>
        /// The structure is used to pass import node information from importfilehandler class to nodemanager
        /// class through projectprizm3.cs.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct ImportNodeData
        {
            public string _NodeName;
            public string _Protocol;
            public string _Model;
            public string _Port;
            public int _NodeError;
            public int _slaveID;//SS_ModbusSameNodeAddr
        }
        /// <summary>
        /// The structure is used to pass import tag information from importfilehandler class to tagmanager class
        /// through projectprizm3.cs.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct ImportTagData
        {
            public string _TagName;
            public string _TagType;
            public string _TagPrefix;
            public string _TagAddress;
            public string _TagPort;
            public string _TagNodeName;
            public int _TagBytes;
            public byte _LowHigh;
            public int _TagError;
            public string _stratonDataType;//Import-Export tag change SP
            #region ss_StratonSysExpTagFormat import/export tag changes
            public string _NativePrefix;
            public string _NativeAddr;
            public string _NativeAddrVal;
            public byte _SlotNo;
            #endregion
            #region ss_Issue426
            public byte _StratonBlockType;
            public string _StratonBlockName;
            public string _StratonInitialValue;
            public byte _IsRetentive;
            #endregion
            #region Import/Export_ModbusTags_Issue809_Vijay
            public string _Com1MappingAddress;
            public string _Com2MappingAddress;
            public string _Com3MappingAddress;
            public string _StringLength; //StratonDataTypeStringLength Vijay
            #endregion
            public string _Dimension;
            public string _ArrTagInfo;
        }
        /// <summary>
        /// This structure is used to pass export tag information from ExportTag.cs
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct ExportTagInfo
        {
            public bool _SelectAllNodeTags;
            public ArrayList _NodeName;
            public bool _SystemTags;
            public bool _UsedTags;
            public bool _Ascii;
            public bool _OverWrite;
            public string _FileName;
            public List<int> _TagId;
            public int _TagNameColumn;
            public int _NodeName1Column;//For node name in node import parameters
            public int _TagAddressColumn;
            public int _TagTypeColumn;
            public int _TagPrefixColumn;
            public int _BytesColumn;
            public int _NodeName2Column;//For node name in tag import parameters.
            public int _ProtocolColumn;
            public int _ModelColumn;
            public int _PortColumn; // for node
            public int _TagPortcolumn; // for tag
            public bool _ViewErrorLog;
            #region ss_StratonSysExpTagFormat import/export tag changes
            public int _SlotNumberColumn;//ss_StratonSysExpTagFormat import/export tag changes 
            public int _NativePrefixColumn;
            public int _NativeAddressColumn;
            public int _NativeAddrValColumn;
            #endregion
            #region ss_Issue426
            public int _StratonBlockTypeColumn;
            public int _StratonBlockNameColumn;
            public int _StratonInitialValueColumn;
            public int _IsRetentiveColumn;
            #endregion
            #region Import/Export_ModbusTags_Issue809_Vijay
            public int _Com1MappingAddressColumn;
            public int _Com2MappingAddressColumn;
            public int _Com3MappingAddressColumn;
            public int _StringLength; //StratonDataTypeStringLength Vijay
            #endregion
            public int _DimensionColumn; //Array_change
            public int _arrTagInfoColumn;
            public int _ModbusSlaveIDColumn;//SS_ModbusSameNodeAddr
            #region ExportTagGUI_Improvement Vijay
            public bool _AllTags;
            public bool _UnusedTags;
            public bool _UserdefinedTags;
            public bool _UserdefUsedTags;
            public bool _UserdefUnusedTags;
            public bool _CheckedExportListTags; //CheckBoxAddedForTagExport Vijay
            #endregion
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct ASCIITagInfo
        {
            public int TagID;
            public int AsciiLen;
        }
        /// <summary>
        /// This structure is used to pass export objects information from GUI to importExportObjects.cs
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct ExportObjectsInfo
        {
            public bool _ExportWholeProject;
            public bool _ViewErrorLog;
            public bool _IsAscii;
            public string _FileName;
            public string _ProjectName;
            public List<int> _ScreenNo;
            public List<string> _ScreenName;
        }

        /// <summary>
        /// This structure is used to pass import objects information
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct ImportObjectsInfo
        {
            public bool _IsAscii;
            public bool _ViewErrorLog;
            public string _FileName;
            public string _ProjectName;


        }

        /// <summary>
        /// Punit 
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct ImportObj
        {
            public string _ScreenName;
            public string ShapeType;
            public string[][] _LanguageText;
            public uint _ObjId;
        }

        /// <summary>
        /// This structure is used to pass node information to property grid.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct PropertyGridNodeInfo
        {
            public string _strNodeName;
            public int _iNodeId;
        }
        /// <summary>
        /// This structure is used to pass node information to property grid.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct PropertyGridRegCoilType
        {
            public int _iNodeId;
            public List<string> _lstStrRegCoilType;
            public List<string> _lstStrPrefix;
            public List<int> _lstIntMinRange;
            public List<int> _lstIntMaxRange;
            public List<string> _lstStrPrefixRange;//The prefix range value from xml file.
            public List<string> _lstStrBitRegType;//Register, Bit
        }
        /// <summary>
        /// The structure is used to add property grid data from screen mdi property grid.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct PropertyGridAddTagData
        {
            public string _strNodeName;
            public int _iNodeId;
            public string _strRegCoilType;
            public string _strTagAddress;
            public string _strTagName;
        }
        /// <summary>
        /// 
        /// </summary>
        public struct ButtonLocation
        {
            public int X;
            public int Y;
        }

        //Punit
        /// <summary>
        /// Logged data csv format
        /// </summary>
        [Serializable]
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct LoggedDataCSVFormat
        {
            public int _GroupNumber;
            public StringBuilder _LoggedData;

            public LoggedDataCSVFormat(int GroupNumber)
            {
                _GroupNumber = GroupNumber;
                _LoggedData = new StringBuilder();
            }
        }

        /// <summary>
        /// The structure will be used to display tag information in the list view at
        /// GUI level, as user can add any tag with different different data types and with different
        /// low high byte and same tag address e.g. D0000 can be added as D0000 with 2 byte,
        /// D0000 with 4 byte, D0000 with 1 byte Low byte and D0000 with 1 byte High byte etc.
        /// </summary>
        public struct TagByteLowHighbitData
        {
            /// <summary>
            /// Tag Byte e.g. 1 - One byte, 2-Two byte(1 word), 4-Four byte(2-Word).
            /// </summary>
            public byte TagByte;
            /// <summary>
            /// The low and high byte for tag data e.g. 0-Low byte/low word, 1-High byte/high word.
            /// </summary>
            public byte TagLowHighByte;
            /// <summary>
            /// The address of tag used to get tag byte and low high byte information.
            /// </summary>
            public string TagAddress;
        }

        //punit mar'08
        /// <summary>
        /// Size and Count of the objects on the screen like drawing objects, dataentry, 
        /// screen keys, Before showing task, while showing task, after hiding tasks 
        /// of the currently focused screen.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct ScreenMemoryStatus
        {
            public int _noOfObject;
            public byte _noofDataEntries;
            public int _Blocks_to_be_Read;
            public short _ScreenKeysCount;
            public byte _BeforeShowingTaskCount;
            public short _WhileShowingTaskCount;
            public short _AfterHidingTaskCount;

            public int _ObjectsSize;
            public short _BlockSize;
            public int _ScreenKeysSize;
            public short _BeforeShowingTaskSize;
            public short _WhileShowingTaskSize;
            public short _AfterHidingTaskSize;
            public int _ScreenBytes; //other

        }

        //Punit May '08
        /// <summary>
        /// Printer port settings
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct PrinterPortSettings
        {
            public byte _BoudRate;
            public byte _NoofDataBits;
            public byte _Parity;
            public byte _NoofColumns;
            public byte _TerminatingCharacter;

        }
        //Punit jul '08
        /// <summary>
        /// Printer Port Settings
        /// </summary>
        [Serializable]
        public struct UndefinedTagAttrib
        {
            public int _TagId;
            public string _TagAdderess;
            public string _TagName;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct PLCGeneralInfo
        {
            public string _Prefix;
            public string _Suffix;
        }

        public struct PLCRangeInfo//Save_Optimization_SS
        {
            public string _Prefix;
            public string _Suffix;
            public string _RegMinRange;
            public string _RegMaxRange;
            public string _RegMinRange2;
            public string _RegMaxRange2;
            public int _RegNo;//SS_CustSupportSamePrefixIssue
            public int NoOfParts;
            public string _DataTypePart1;
            public string _DataTypePart2;
            public int _LengthPart1;
            public int _LengthPart2;
            public ushort _BlockSize;
        }

        #region Printing Structures
        //punit apr '08
        /// <summary>
        /// 
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct ApplicationInformation
        {
            public string _Title;
            public string _Author;
            public string DateLastEdited;
            public string TimeLastEdited;
        }

        //punit apr '08
        /// <summary>
        /// 
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct PrizmUnitInformation
        {
            public string _BaudRate;
            public string _Parity;
            public string _NoOfBytes;
            public string _NoOfcolumns;
            public string _TerminatingCharacter;
        }

        //punit apr '08
        /// <summary>
        /// Gets the node information for printing data
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct NodeInformation
        {
            public string _NodeAddr;
            public string _NodeName;
            public string _Port;
            public string _Protocol;
        }

        //punit apr '08
        /// <summary>
        /// Gets the Taginformation for printing data
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct TagInformation
        {
            public string _TagAdderess;
            public string _NodeName;
            public string _Bytes;
            public string _TagName;
        }

        //punit apr '08
        /// <summary>
        /// Gets the screen name and number for printing
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct ScreenInformation
        {
            public string _ScreenNumber;
            public string _ScreenName;
        }

        //punit apr '08
        /// <summary>
        /// Gets the alarm info for printing
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct AlarmInformation
        {
            public string _AlarmAssign;
            public string _AlarmNumber;
            public string _AlarmTag;
            public string _Severity;
            public string _Print;
            public string _AlarmText;
        }

        #region SnehaK_Alarm
        public struct AlarmParameters
        {
            public int LanguageId;
            public string _strY;
            public string _strN;
            public string _strYes;
            public string _strNo;
        }
        #endregion

        //punit apr '08
        /// <summary>
        /// Contains the information for both application task list and screen task list for printing
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct TaskListInformation
        {
            public string _ScreenNumber;
            public List<string> _BwShowingTk;
            public List<string> _WhShowingTk;
            public List<string> _AfHidingTk;
        }

        //punit apr '08
        /// <summary>
        /// Contains the information of application takslist information
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct ApplicationTaskListInformation
        {
            public List<string> _PowerOnTasks;
            public List<string> _GlobalTasks;
        }

        //punit apr '08
        /// <summary>
        /// Contains the information of application takslist information
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct KeysInformation
        {
            public string _KeyName;
            public List<string> _PressTasks;
            public List<string> _PressedTasks;
            public List<string> _ReleaseTasks;
        }
        #endregion

        //FP Issue no. 137 QA2010-11 Amit
        public struct EthernetSettingsUploadFormat
        {
            public uint _IPAddress;
            public uint _SubnetMask;
            public uint _DefaultGateway;
            public int _DownloadPort;
            public byte _DHCP;
        }
        //End

        #region FP_Ethernet_Implementation-AMIT
        public struct EthernetSettingsSaveFormat
        {
            public byte _DHCP;
            public int _DownloadPort;
            public uint _IPAdderess;
            public uint _SubnetMask;
            public uint _DefaultGateway;
        }

        //Ethernet - FlexiSoft
        /// <summary>
        /// Structure for ethernet settings
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct EthernetSettings
        {
            public bool _DHCP;
            public decimal _DownloadPort;
            public string _IPAdderess;
            public string _SubnetMask;
            public string _DefaultGateway;
            public decimal _MonitoringPort;//Monitoring Port- AD
        }

        #region Monitoring Port- AD
        public struct EthernetSettingsDwndlble
        {
            public byte _DHCP;
            public int _DownloadPort;
            public uint _IPAdderess;
            public uint _SubnetMask;
            public uint _DefaultGateway;
            public int _MonitoringPort;
        }
        #endregion
        #endregion

        #region GSM_Sanjay
        [Serializable]
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Auto)]
        public struct GSMSettingsSaveFormat
        {
            public byte _btBaudRate;//1
            public byte _btParity;//2
            public byte _btDataBits;//3
            public byte _btStopBits;//4
            public byte _btRetryCount; //5           
            public ushort _usInterframeDelay;//6//7
            public ushort _usResponseTime;//8//9  
            public byte _btInterByteDelay;
            public byte _mobileNoLength;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 15)]
            public byte[] _mobileNumber;

        }
        #endregion GSM_Sanjay

        //Straton Modbus Mapping - Amit
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct StratonModbusMappingData
        {
            public byte _comPort;// Com1/Com2/Com3
            public byte _prefix;// 4- Holding Register/ 0-Coil Status
            public string _modbusTagAddress;
            public byte _stratonTag; //0-Default tag / 1-User Defined Tag
            public string _stratonTagName;
            public string _dataType;
            public byte _IsExpansionTag;
            public byte _noOfBytes;
            public byte _IsRetentiveRegTag;//Retentive Tag support for modbus mapping SP 26.09.12
            public int _OffsetString;


        }
        #region ss_StratonSysExpTagFormat
        public struct StratonTagData
        {
            public ushort _noOfBytes;
            public byte _hmiTagType;//1:Coil; 2:2 Byte Register; 3:4 Byte Register, 4:Bit addressable Coil
            public ushort _regNumber;
            public ushort _coilNumber;//If tagtype 1 or 4
            public uint _symAddr;
        }

        public struct StratonExpTagWrFormat
        {
            public ushort NoOfBytes;//single oper size
            public byte TagType;//1-2 byte,2-4 byte,3-2 byte coil addressable,4-4 byte coil addressable
            public ushort RegNo;
            public uint SymAddr;
            public ArrayList CoilTags;//If tagtype 3 or 4
        }
        public struct StratonExpSlotWrFormat
        {
            public ushort _NoOfBytes;//Single expansion size
            public byte _SlotNo;
            public byte _ExpId;
            public ushort _ExpXWInfoSize;
            public ushort _ExpYWInfoSize;
            public ushort _ExpMWInfoSize;
            public ArrayList _ExpXWInfo;//StratonExpTagWrFormat array
            public ArrayList _ExpYWInfo;//StratonExpTagWrFormat array
            public ArrayList _ExpMWInfo;//StratonExpTagWrFormat array
        }
        #endregion

        //WebServer Change        
        #region WebServer Change
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HTMLFileStructure
        {
            public short _lengthOfScreenNameWithExtension;
            public string _screenNameWithExtension;
            //public byte _isDefaultScreen;
            public string _httpStatusCode;
            public string _contentType;
            public string _contentLength;
            public string _responseHeader;
            public string _expiresHeader;
            public uint _screenFileOffSet;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct JSFileStructure
        {
            public short _lengthOfJSFileWithExtension;
            public string _jsFileNameWithExtension;
            public string _httpStatusCode;
            public string _contentType;
            public string _contentLength;
            public string _responseHeader;
            public string _expiresHeader;
            public uint _jsFileOffSet;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct XMLFileStructure
        {
            public short _lengthOfXMLFileNameWithExtension;
            public string _xmlFileNameWithExtension;
            public string _httpStatusCode;
            public string _contentType;
            public string _contentLength;
            public string _responseHeader;
            public string _expiresHeader;
            public uint _xmlFileOffSet;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct BitmapFileStructure
        {
            public short _lengthOfBitMapFileNameWithExtension;
            public string _bitmapFileNameWithExtension;
            public string _httpStatusCode;
            public string _contentType;
            public string _contentLength;
            public string _responseHeader;
            public string _expiresHeader;
            public uint _bitmapFileOffSet;
        }
        #endregion
        //End


        public struct EditedVMDBTag//ss_Issue460
        {
            public Prizm3TagStructure prizm3tag;
            public string _prevTagnm;
            public string _prevInitialval;
        }

        public struct ModbusComData
        {
            public int _noOfBytesCom;
            public byte _comPort;// Com1/Com2/Com3
            public bool _IsNodePresent;

            //HR Info
            public int _totalNoofHR;
            public int _totalNoofHRBlocks;

            //Coil Info
            public int _totalNoOfCoils;
            public int _totalNoOfCoilBlocks;
        }

        //Offline Data monitoring-AMIT
        public struct OffMonitorData
        {
            public string _tagName;
            public string _blockName;
            public uint _loopID;
            public int _blockType;
        }
        //End

        #region AdvancedAlarm           Punam 30/9/08
        [Serializable]
        public struct ReadImportAlarmData
        {
            public byte IsAlarmAssign;
            public uint AlarmID;
            public string AlarmName;
            public byte BitNumber;
            public byte NoOfLanguages;
            public byte[] LanguageIndex;
            public string[] AlarmText;
            public string TagName;
            public int TagId;
            public byte ConditionAlarmFlag;
            public byte GroupNumber;
            public byte AlarmAttribute;
            public string AlarmActions;
            public byte Severity;
            public byte AutoAck;
            public string AutoAckTag;
            public int AutoAckTagId;
            public byte History;
            public byte Print;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] DirectAddressAutoAckTag;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] IndirectAddressAutoAckTag;
            public int AutoAckTagValue;

            public byte ConditionalOperator;
            public byte CompareWith;
            public ushort CondConstantValue;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] DirectAddressTag;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] IndirectAddressTag;

        }

        [Serializable]
        public struct ReadHeader
        {
            public string IsAlarmAssign;
            public string AlarmNumber;
            public string AlarmName;
            public string BitNumber;
            public string[] AlarmText;
            public string TagName;
            public string AlarmCondition;
            public string TagAddress;
            public string AlarmAttribute;
            public string ConditionalOperator;
            public string Severity;
            public string History;
            public string AcknowledgeTag;
            public string Print;
            public string Language1;
            public string Language2;

        }

        public struct GlobalAlarmProperties
        {
            public byte AlmActIfBufferFull;
            public byte AutoAckAlm;
            public string AlmErrText;
            public int AlmHistBufferSize;
            public bool LogAlmText;
            public int AlmScanTime;
            public byte AlmType;
        }
        #endregion

        #region AdvancedAlarm

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct AlarmConfigInfo
        {
            public short almConfigInfoTotalBytes;
            public byte almType;
            public byte almAutoAck;
            public ushort almScanTime;
            public byte almActIfBufferFull;
            public string almErrText;
            public byte almErrTextLength;
        }

        [Serializable]
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Auto)]
        public struct AlarmInfo
        {
            public ushort AlarmNumber;
            public byte BitAlarmNumber;
            public byte GroupNumber;
            public byte NoOfLanguges;
            public byte[] LanguageIndex;
            public string[] AlarmText;
            public bool AlarmActions;
            public int TagId;
            public uint AlarmId;
            public string AlarmName;
            public byte AlarmAttribute;
            public byte IsAlarmAssign;
            public byte Print;
            public byte Severity;

            public byte AutoAck;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] DirectAddressAutoAckTag;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] IndirectAddressAutoAckTag;
            public int AutoAckTagValue;
            public int AutoAckTagId;
            public byte ConditionAlarmFlag;
            public byte ConditionalOpretor;
            public byte CompareWith;
            public ushort CondConstantValue;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] DirectAddressTag;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] IndirectAddressTag;

        }


        /// <summary>
        /// Common structure to keep groupwise information of Alarm.
        /// </summary>
        [Serializable]
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct AlarmGroup
        {
            public byte GroupNumber;
            public byte adjbyte;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] DirectAddressTag;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] IndirectAddressTag;
        }

        /// <summary>
        /// --Sheetal-- Tag_imprvmnts
        /// </summary>
        [Serializable]
        public struct TagSelectionFilters
        {
            public bool _blHideSystemTags;
            public bool _blHideUnusedTags;
            public ArrayList _arrPorts;
            public ArrayList _arrNodenames;
            public ArrayList _arrBlocks;
            public ArrayList _arrCategory;
            public ArrayList _arrDatatypes;
            public ArrayList _arrAttributes;
            public ArrayList _arrTagGroups;//SS_TagGroup
            public TagSelectionFilters(bool phidesystags)
            {
                _blHideSystemTags = phidesystags;
                _blHideUnusedTags = false;
                _arrPorts = null;
                _arrNodenames = null;
                _arrBlocks = null;
                _arrCategory = null;
                _arrDatatypes = null;
                _arrAttributes = null;
                _arrTagGroups = null;//SS_TagGroup
            }
        }

        #endregion

        #region //New_type_XYPlot_SY//
        [Serializable]
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct XYPlotInfoForFirmwareStructure
        {
            public int TotalobjectBytes;
            public int NoOfPoint;
            public byte ActionAftMemFull;
            public byte XAxisDataType;
            public byte YAxisDataType;
            public byte[] _xDirectTagAddr;
            public byte[] _xIndirectTagAddr;
            public byte[] _yDirectTagAddr;
            public byte[] _yIndirectTagAddr;
            public byte[] _DirectTagAddrStartCoil;
            public byte[] _IndirectTagAddrStartCoil;
            public byte[] _DirectTagAddrStopCoil;
            public byte[] _IndirectTagAddrStopCoil;
            public byte[] _DirectTagAddrArrayIndex;
            public byte[] _IndirectTagAddrArrayIndex;
            //public byte[] _DirectTagAddrArray_X;
            //public byte[] _IndirectTagAddrArray_X;
            //public byte[] _DirectTagAddrArray_Y;
            //public byte[] _IndirectTagAddrArray_Y;
            public List<byte[]> _DirectTagAddrArray_X;
            public List<byte[]> _IndirectTagAddrArray_X;
            public List<byte[]> _DirectTagAddrArray_Y;
            public List<byte[]> _IndirectTagAddrArray_Y;
        }
        #endregion
        public struct structFTPInfo //SS_FTP
        {
            public byte _btFTPConfig;
            public byte _btGroupNumber;
            public byte _btSourceMedia;
            public byte _btDestMedia;
            public byte _btAPN;
            public byte _btUsername;
            public byte _btPassword;
            public byte _btServerAddr;
            public byte _btdestPath;
            public byte _btSendFileAtEvery;

            public byte _SourceMedia;
            public byte _DestinationMedia;
            public byte _btFileSendHour;
            public byte _btFileSendMinute;
            public byte _btFileSendSeconds;
            public string _strGroupNumber;
            public string _strAPN;
            public string _strUsername;
            public string _strPassword;
            public string _strServerAddr;
            public string _strdestPath;

            public int _tagIDEnableBit;
            public int _tagIDResendBit;
            public int _tagIDGrpNumber;
            public int _tagIDSourceMedia;
            public int _tagIDDestMedia;
            public int _tagIDAPN;
            public int _tagIDUserName;
            public int _tagIDPassword;
            public int _tagIDServerAddr;
            public int _tagIDDestPath;
            public int _tagIDFileSendAtEvery;
            public int _tagIDMediaStatus;
            public int _tagIDNetConnStatus;
            public int _tagIDFTPStatus;
            public int _tagIDFileSendStatus;
            public int _tagIDFTPBlkStatus;
        }
        #endregion

        #region public properties
        public static int ProjectPrizmVersion
        {
            get
            {
                return _commConstantPrizmVersion;
            }
            set
            {
                _commConstantPrizmVersion = value;
            }
        }
        public static ProductData ProductDataInfo
        {
            set
            {
                _commconstantProductData = value;
            }
            get
            {
                return _commconstantProductData;
            }
        }

        /// <summary>
        /// bharat 22-july-08
        /// Gives the value For Projects HMILadder Type, as HMI, Ladder, HMILadder.
        /// </summary>        
        public static string ProjectHMILadderType
        {
            get
            {
                return _CommConstantsProjHMILadderType;
            }
            set
            {
                _CommConstantsProjHMILadderType = value;
            }
        }

        /// <summary>
        /// umesh 28-Aug-06. The dataset reads ModelInformation.xml and
        /// stores it at the application level.
        /// </summary>
        public static DataSet PLCInformation
        {
            set
            {
                dsPLCInformation = value;
            }
            get
            {
                return dsPLCInformation;
            }
        }

        #region PLCSupport_FromXML_Vijay
        /// <summary>
        /// vijay 29-Nov-2016. The dataset reads PLCSupportedModelList_Native.xml and
        /// stores it at the application level.
        /// </summary>
        public static DataSet PLCInformationFromXMLNative
        {
            set
            {
                dsReadPLCSupportedModelList_Native = value;
            }
            get
            {
                return dsReadPLCSupportedModelList_Native;
            }
        }

        /// <summary>
        /// vijay 29-Nov-2016. The dataset reads PLCSupportedModelList_IEC.xml and
        /// stores it at the application level.
        /// </summary>
        public static DataSet PLCInformationFromXMLIEC
        {
            set
            {
                dsReadPLCSupportedModelList_IEC = value;
            }
            get
            {
                return dsReadPLCSupportedModelList_IEC;
            }
        }
        #endregion
        public static float ZoomFactor
        {
            set
            {
                _commconstiZoomFactor = value;/// 100.00f;
            }
            get
            {
                return (_commconstiZoomFactor / 100.00f);
            }
        }

        /// <summary>
        /// The value will be true only when block size will be changed through
        /// variable block size dialog.
        /// </summary>
        public static bool RecalculateBlockSize
        {
            get
            {
                return _commConstantblRecalBlockSize;
            }
            set
            {
                _commConstantblRecalBlockSize = value;
            }
        }
        //umesh
        /// <summary>
        /// The method will return plc code for modbus slave plc.
        /// </summary>
        public static byte ModbusSlavePlcCode
        {
            get
            {
                return _commConstantModbusSlavePlcCode;
            }
        }
        /// <summary>
        /// The method will return plc code for prizm.
        /// </summary>
        public static byte PrizmPlcCode
        {
            get
            {
                return _commConstantPrizmPlcCode;
            }
        }
        //FP_Product_Conversion
        #region Version2.0Incr1_ProductConversion

        public static string SourceProjectName
        {
            get
            {
                return _commonConstantsSrcProjName;
            }
            set
            {
                _commonConstantsSrcProjName = value;
            }
        }

        public static string DestinationProjectName
        {
            get
            {
                return _commonConstantsDstProjName;
            }
            set
            {
                _commonConstantsDstProjName = value;
            }
        }

        /// <summary>
        /// Used for product convresion -
        /// stores conversion process status.
        /// </summary>
        public static bool IsApplicationConversion
        {
            get
            {
                return _commonConstantblIsProductConvert;
            }
            set
            {
                _commonConstantblIsProductConvert = value;
            }
        }

        /// <summary>
        /// This is used to notify conversion that this is FHWT processing,
        /// dont do any conversion. True for FHWT addition and False for Other.
        /// </summary>
        public static bool IsFHWTForConversion
        {
            get
            {
                return _commonConstantblIsFHWTConvert;
            }
            set
            {
                _commonConstantblIsFHWTConvert = value;
            }
        }


        /// <summary>
        /// Stores color conversion flag.
        /// </summary>
        public static bool IsColorConversion
        {
            get
            {
                return _commonConstantblIsColorConvert;
            }
            set
            {
                _commonConstantblIsColorConvert = value;
            }
        }

        /// <summary>
        /// This gets or sets Application Directory Path.
        /// </summary>
        public static string ApplicationDirectoryPath
        {
            set
            {
                _commonConstantsApplicationDirPath = value;
            }
            get
            {
                return _commonConstantsApplicationDirPath;
            }
        }

        /// <summary>
        /// Used in Model Conversion for destination ModelDataInfo
        /// </summary>
        public static ModelDataInfo DestModelDataInfo
        {
            set
            {
                _commconstantDestModelData = value;
            }
            get
            {
                return _commconstantDestModelData;
            }
        }

        /// <summary>
        ///  Used in Model Conversion for Source Model ProductDataInfo
        /// </summary>
        public static ProductData SourceProductDataInfo
        {
            set
            {
                _commconstantSourceProductData = value;
            }
            get
            {
                return _commconstantSourceProductData;
            }
        }

        /// <summary>
        /// Used in Model Conversion for destination ProductDataInfo
        /// </summary>
        public static ProductData DestProductDataInfo
        {
            set
            {
                _commconstantDestProductData = value;
            }
            get
            {
                return _commconstantDestProductData;
            }
        }

        /// <summary>
        /// SaveAs file name for Converted Model.
        /// </summary>
        public static string ModelSaveAsFileName
        {
            get
            {
                return _commonConstantstrSaveAsFileName;
            }
            set
            {
                _commonConstantstrSaveAsFileName = value;
            }
        }

        /// <summary>
        /// This Property stores user preferences for Resolution values in ProductConversion.
        /// </summary>
        public static ResolutionValues ResolutionValuesObject
        {
            get
            {
                return _commonConstantsResValues;
            }
            set
            {
                _commonConstantsResValues = value;
            }
        }

        /// <summary>
        /// This Property stores user preferences for Port values in ProductConversion.
        /// </summary>
        public static PortValues PortValuesObject
        {
            get
            {
                return _commonConstantsPortValues;
            }
            set
            {
                _commonConstantsPortValues = value;
            }
        }

        /// <summary>
        /// This Property stores user preferences for Keys values in ProductConversion.
        /// </summary>
        public static KeyValues KeyValuesObject
        {
            get
            {
                return _commonConstantsKeyValues;
            }
            set
            {
                _commonConstantsKeyValues = value;
            }
        }

        /// <summary>
        /// This Property stores user preferences for Color values in ProductConversion.
        /// </summary>
        public static ColorValues ColorValuesObject
        {
            get
            {
                return _commonConstantsColorValues;
            }
            set
            {
                _commonConstantsColorValues = value;
            }
        }

        #endregion Version2.0Incr1_ProductConversion
        //
        #endregion
        [DllImport("gdi32.dll")]
        static extern IntPtr CreateCompatibleDC(IntPtr hdc);

        [DllImport("gdi32.dll")]
        static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr CreateFontIndirect(
              [In, MarshalAs(UnmanagedType.LPStruct)]
			  LOGFONT lplf
              );
    }
    /// <summary>
    /// --sheetal--
    /// This class provides constants and delegates for Tag Selection functionality
    /// </summary>
    public class TagSelectionDelegateClass//ss_tag_imprvmnts
    {
        public delegate void callAddTagGUI();
        public static event callAddTagGUI _evntcallAddTagGUI;
        public delegate bool CheckUsageIECLadderDataMonitor(CommonConstants.Prizm3TagStructure ptagstruct);//SS_Issue1472
        public static event CheckUsageIECLadderDataMonitor _evntCheckUsageIECLadderDataMonitor;//SS_Issue1472
        public delegate void callUpdateTagInfoObjects();
        public static event callUpdateTagInfoObjects _evntcallUpdateTagInfoObjects;
        #region ss_addtag_taskchange
        public delegate void callUpdateTagInfoTasks();
        public static event callUpdateTagInfoTasks _evntcallUpdateTagInfoTasks;
        public delegate void callUpdateTagInfoKeys();
        public static event callUpdateTagInfoKeys _evntcallUpdateTagInfoKeys;
        public delegate void callUpdateTagInfoDatalogger();
        public static event callUpdateTagInfoDatalogger _evntcallUpdateTagInfoDatalogger;
        public delegate void callUpdateTagInfoAlarm();
        public static event callUpdateTagInfoAlarm _evntcallUpdateTagInfoAlarm;
        public delegate void callUpdateTagInfoScreenUCTasks();
        public static event callUpdateTagInfoScreenUCTasks _evntcallUpdateTagInfoScreenUCTasks;
        public delegate void callUpdateTagInfoScreenKeys();
        public static event callUpdateTagInfoScreenKeys _evntcallUpdateTagInfoScreenkeys;
        public delegate void callUpdateTagInfoScreenTasks();
        public static event callUpdateTagInfoScreenTasks _evntcallUpdateTagInfoScreenTasks;
        public delegate void callUpdateTagInfoTouchScreenTasks();
        public static event callUpdateTagInfoTouchScreenTasks _evntcallUpdateTagInfoTouchScreenTasks;
        #endregion
        public static bool TagSelectionIsTagAdded = false;
        public static bool IsCalledFromTagSelGUI = false;   //Issue271

        public static void CallAddTagGUI()
        {
            _evntcallAddTagGUI();
        }
        public static bool CheckTagUsageIECLadderDataMonitor(CommonConstants.Prizm3TagStructure ptag)//SS_Issue1472
        {
            return _evntCheckUsageIECLadderDataMonitor(ptag);
        }
        public static void UpdateTagInfoObjects()
        {
            _evntcallUpdateTagInfoObjects();
        }
        #region ss_addtag_taskchange
        public static void UpdateTagInfoTasks()
        {
            _evntcallUpdateTagInfoTasks();
        }
        public static void UpdateTagInfoKeys()
        {
            _evntcallUpdateTagInfoKeys();
        }
        public static void UpdateTagInfoDatalogger()
        {
            _evntcallUpdateTagInfoDatalogger();
        }
        public static void UpdateTagInfoAlarm()
        {
            _evntcallUpdateTagInfoAlarm();
        }
        public static void UpdateTagInfoScreenUCTasks()
        {
            _evntcallUpdateTagInfoScreenUCTasks();
        }
        public static void UpdateTagInfoScreenkeys()
        {
            _evntcallUpdateTagInfoScreenkeys();
        }
        public static void UpdateTagInfoScreenTasks()
        {
            _evntcallUpdateTagInfoScreenTasks();
        }
        public static void UpdateTagInfoTouchScreenTasks()
        {
            _evntcallUpdateTagInfoTouchScreenTasks();
        }
        #endregion
    }

    #region Sort ListViewItem
    public class ListViewColumnSorter : IComparer
    {
        private int ColumnToSort;
        private SortOrder OrderOfSort;
        private NumberCaseInsensitiveComparer ObjectCompare;
        private ImageTextComparer ObjImageTextComparer;

        public ListViewColumnSorter()
        {
            ColumnToSort = 0;
            OrderOfSort = SortOrder.Ascending;
            ObjectCompare = new NumberCaseInsensitiveComparer();
            ObjImageTextComparer = new ImageTextComparer();
        }


        public int Compare(object x, object y)
        {
            try
            {
                int compareResult;
                ListViewItem listviewX, listviewY;
                listviewX = (ListViewItem)x;
                listviewY = (ListViewItem)y;
                if (ColumnToSort == 0)
                    compareResult = ObjImageTextComparer.Compare(x, y);
                else if (listviewX.SubItems[ColumnToSort].Text.ToString() != string.Empty && listviewY.SubItems[ColumnToSort].Text.ToString() != string.Empty)
                    compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text);
                else
                    compareResult = ObjImageTextComparer.Compare(x, y);

                if (OrderOfSort == SortOrder.Ascending)
                {
                    return compareResult;
                }
                else if (OrderOfSort == SortOrder.Descending)
                {
                    return (-compareResult);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception eObject)
            {
                return 0;
            }

        }

        public int SortColumn
        {
            set
            {
                ColumnToSort = value;
            }
            get
            {
                return ColumnToSort;
            }
        }


        public SortOrder Order
        {
            set
            {
                OrderOfSort = value;
            }
            get
            {
                return OrderOfSort;
            }
        }
    }

    public class ImageTextComparer : IComparer
    {
        private NumberCaseInsensitiveComparer ObjectCompare;
        public ImageTextComparer()
        {
            ObjectCompare = new NumberCaseInsensitiveComparer();
        }


        public int Compare(object x, object y)
        {
            int image1, image2;
            ListViewItem listviewX, listviewY;
            listviewX = (ListViewItem)x;
            image1 = listviewX.ImageIndex;
            listviewY = (ListViewItem)y;
            image2 = listviewY.ImageIndex;
            if (image1 < image2)
            {
                return -1;
            }
            else if (image1 == image2)
            {
                return ObjectCompare.Compare(listviewX.Text, listviewY.Text);
            }
            else
            {
                return 1;
            }
        }
    }

    public class NumberCaseInsensitiveComparer : CaseInsensitiveComparer
    {
        public NumberCaseInsensitiveComparer()
        {

        }


        public new int Compare(object x, object y)
        {
            if ((x is System.String) && IsWholeNumber((string)x) && (y is System.String) && IsWholeNumber((string)y))
            {
                return base.Compare(System.Convert.ToInt32(x), System.Convert.ToInt32(y));
            }
            else
            {
                return base.Compare(x, y);
            }
        }


        private bool IsWholeNumber(string strNumber)
        {
            Regex objNotWholePattern = new Regex("[^0-9]");
            return !objNotWholePattern.IsMatch(strNumber);
        }
    }
    #endregion

    #region Project Information Class
    public class ProjectInfo
    {
        private string _projectInfoPath;
        private string _projectInfoName;
        private int _projectInfoID;
        private string _projectProductName;
        private CommonConstants.ProductData _projectInfoProductData;
        private string _filepath;

        public ProjectInfo()
        {
            _projectInfoProductData = new CommonConstants.ProductData();
        }
        /// <summary>
        /// It keeps projectID reference.
        /// </summary>
        public int ProjectID
        {
            set
            {
                _projectInfoID = value;
            }
            get
            {
                return _projectInfoID;
            }
        }
        /// <summary>
        /// Project Name without path.
        /// </summary>
        public string ProjectName
        {
            get
            {
                return _projectInfoName;
            }
            set
            {
                _projectInfoName = value;
            }
        }
        /// <summary>
        /// Project Path with name.
        /// </summary>
        public string ProjectPath
        {
            get
            {
                return _projectInfoPath;
            }
            set
            {
                _projectInfoPath = value;
            }
        }

        /// <summary>
        /// Product Name
        /// </summary>
        public string ProductName
        {
            get
            {
                return _projectProductName;
            }
            set
            {
                _projectProductName = value;
            }
        }


        /// <summary>
        /// File Path
        /// </summary>
        public string FilePath
        {
            get
            {
                return _filepath;
            }
            set
            {
                _filepath = value;
            }
        }

        /// <summary>
        /// Object of Product Data structure defined in commonconstant.
        /// </summary>
        public CommonConstants.ProductData ProductData
        {
            get
            {
                return _projectInfoProductData;
            }
            set
            {
                _projectInfoProductData = value;
            }
        }

        public bool IsValidBCD(string strBCD)
        {
            int iCount = 0;

            for (iCount = 0; iCount < strBCD.Length; iCount++)
            {
                if (strBCD[iCount] == 'A' || strBCD[iCount] == 'B' || strBCD[iCount] == 'C' || strBCD[iCount] == 'D' || strBCD[iCount] == 'E' || strBCD[iCount] == 'F')
                    break;
            }

            if (iCount < strBCD.Length)
                return false;
            else
                return true;
        }
    }
    #endregion

    #region FileSystem
    //Punit 6th mar '09
    /// <summary>
    /// Copies a directory
    /// </summary>
    public class FileSystem
    {
        // Copy directory structure recursively

        public static void copyDirectory(string Src, string Dst)
        {
            String[] Files;

            if (Dst[Dst.Length - 1] != Path.DirectorySeparatorChar)
                Dst += Path.DirectorySeparatorChar;
            if (!Directory.Exists(Dst)) Directory.CreateDirectory(Dst);
            Files = Directory.GetFileSystemEntries(Src);
            if (Files.Length == 0)
            {
                if (!Directory.Exists(Dst + Src.Substring(Src.LastIndexOf("\\") + 1)))
                    Directory.CreateDirectory(Dst + Src.Substring(Src.LastIndexOf("\\") + 1));
            }
            foreach (string Element in Files)//Kapil_Issue_integration_#1430
            {
                // Sub directories
                FileInfo newfileInfo = new FileInfo(Element);
                string tempFile = newfileInfo.Directory.Name;

                if (Directory.Exists(Element))
                {
                    #region Issue Picture folder.
                    String[] Filesnew = Directory.GetFileSystemEntries(Element);


                    if (Element.EndsWith(CommonConstants.PictureFolder) && Filesnew.Length <= 0)
                        copyDirectory(Element, Dst);
                    else
                    {
                        //Issue_1097
                        string p = System.IO.Path.GetDirectoryName(Element);
                        string p1 = System.IO.Path.GetDirectoryName(Dst);
                        if (Element.EndsWith(CommonConstants.PictureFolder))
                            copyDirectory(Element, Dst + Path.GetFileName(Element));

                        else if (ClassList.CommonConstants.IsApplicationConversion == false && !p1.Contains(p))
                            copyDirectory(Element, Dst + Path.GetFileName(Element));
                    }

                    #endregion
                }
                else
                {
                    if (Element.Substring(Element.LastIndexOf("\\") + 1, Element.Length - 4 - 1 - Element.LastIndexOf("\\") + 1 - 1) != tempFile)
                        File.Copy(Element, Dst + Path.GetFileName(Element), true);
                }

            }
        }
        /// <summary>
        /// Deletes the directory and its sub directories including all files
        /// </summary>
        /// <param name="pstrDirectory"></param>
        public static void DeleteDirectory(string pstrDirectory)
        {
            string[] strFiles, strDirectories;
            List<string> _lst = new List<string>();
            if (Directory.Exists(pstrDirectory))
            {
                strFiles = Directory.GetFiles(pstrDirectory, "*.*", SearchOption.AllDirectories);
                foreach (string file in strFiles)
                {
                    if (File.Exists(file))
                    {
                        //LoggCSV_sammed
                        try
                        {
                            File.Delete(file);
                        }
                        catch (Exception ex)
                        {
                        }
                        //End
                    }
                }
                strDirectories = Directory.GetDirectories(pstrDirectory, "*.*", SearchOption.AllDirectories);

                for (int i = 0; i < strDirectories.Length; i++)
                    _lst.Add(strDirectories[i]);
                _lst.Reverse();
                foreach (string sDirectory in _lst)
                {
                    if (Directory.Exists(sDirectory))
                    {
                        //LoggCSV_sammed
                        try
                        {
                            Directory.Delete(sDirectory);
                        }
                        catch (Exception ex)
                        {
                        }
                        //End
                    }
                }
                if (Directory.Exists(pstrDirectory))
                {
                    //LoggCSV_sammed
                    try
                    {
                        Directory.Delete(pstrDirectory);
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }

    }
    #endregion



    #region DriverTestUtilityClass
    public class DriverInformation
    {
        #region public Constructors
        public DriverInformation()
        {
            _screenObject = new ScreenObject();
            _screenobjectList = new List<ScreenObject>();
        }
        #endregion
        #region private members
        private InformationType _informationType;
        private string _screenNumber;
        private string _screenName;
        private ScreenObject _screenObject;
        private List<ScreenObject> _screenobjectList = new List<ScreenObject>();
        #endregion

        #region structure
        [Serializable]
        public struct ScreenObject
        {
            public string ObjectName;
            public string ObjectId;
            public string DirectAdderess;
            public string IndirectAdderess;
            public string FlashAnimationAdderess;
            public string VisibilityAnimationAdderess;
            public string TagName;
            public string TagAddr;
            public int TagId;
            public int FlashAnimationTagID;
            public int VisibilityAnimationTagID;
        }
        #endregion
        #region Enum
        public enum InformationType
        {
            SCREENBLOCK = 0,
            GLOBALBLOCK,
            NONE
        }
        #endregion
        #region Public methods
        #endregion

        #region public properties
        public string ScreenNumber
        {
            get
            {
                return _screenNumber;
            }
            set
            {
                _screenNumber = value;
            }
        }


        public string ScreenName
        {
            get
            {
                return _screenName;
            }
            set
            {
                _screenName = value;
            }
        }

        public InformationType TypeInfo
        {
            get
            {
                return _informationType;
            }
            set
            {
                _informationType = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public List<ScreenObject> ScreenObjectList
        {
            get
            {
                return _screenobjectList;
            }
            set
            {
                _screenobjectList = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ScreenObject ScreenObjectStructure
        {
            get
            {
                return _screenObject;
            }
            set
            {
                _screenObject = value;
            }
        }
        #endregion
    }
    #endregion
}