using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.IO;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CapaDatos
{
    public class ZkTekoHelper
    {
        public zkemkeeper.CZKEM CZKem = new zkemkeeper.CZKEM();

        public List<Employee> employeeList = new List<Employee>();
        public List<BioTemplate> bioTemplateList = new List<BioTemplate>();
        public List<string> biometricTypes = new List<string>();

        private static bool bIsConnected = false;//the boolean value identifies whether the device is connected
        private static int iMachineNumber = 1;
        private static int idwErrorCode = 0;
        private static int iDeviceTpye = 1;
        bool bAddControl = true;        //Get all user's ID

        #region UserBioTypeClass

        private string _biometricType = string.Empty;
        private string _biometricVersion = string.Empty;

        private SupportBiometricType _supportBiometricType = new SupportBiometricType();

        public const string PersBioTableName = "Pers_Biotemplate";

        public const string PersBioTableFields = "*";

        public SupportBiometricType supportBiometricType
        {
            get { return _supportBiometricType; }
        }

        public string biometricType
        {
            get { return _biometricType; }
        }
        public class Employee
        {
            public string pin { get; set; }
            public string name { get; set; }
            public string password { get; set; }
            public int privilege { get; set; }
            public string cardNumber { get; set; }
        }
        public class SupportBiometricType
        {
            public bool fp_available { get; set; }
            public bool face_available { get; set; }
            public bool fingerVein_available { get; set; }
            public bool palm_available { get; set; }
        }
        public class BioTemplate
        {
            private int validFlag = 1;

            public virtual int valid_flag
            {
                get { return validFlag; }
                set { validFlag = value; }
            }
            public virtual int is_duress { get; set; }
            public virtual int bio_type { get; set; }
            public virtual string version { get; set; }
            public virtual int data_format { get; set; }
            public virtual int template_no { get; set; }
            public virtual int template_no_index { get; set; }
            public virtual string template_data { get; set; }
            public virtual string pin { get; set; }
        }
        public class BioType
        {
            public string name { get; set; }
            public int value { get; set; }

            public override string ToString()
            {
                return name;
            }
        }

        #endregion
        #region ConnectDevice
        public bool GetConnectState()
        {
            return bIsConnected;
        }

        public void SetConnectState(bool state)
        {
            bIsConnected = state;
            //connected = state;
        }

        public int GetMachineNumber()
        {
            return iMachineNumber;
        }

        public void SetMachineNumber(int Number)
        {
            iMachineNumber = Number;
        }

        public int sta_ConnectTCP(string ip, string port, string commKey)
        {
            if (ip == "" || port == "" || commKey == "")
            {
                //lblOutputInfo.Items.Add("*Name, IP, Port or Commkey cannot be null !");
                return -1;// ip or port is null
            }

            if (Convert.ToInt32(port) <= 0 || Convert.ToInt32(port) > 65535)
            {
                //lblOutputInfo.Items.Add("*Port illegal!");
                return -1;
            }

            if (Convert.ToInt32(commKey) < 0 || Convert.ToInt32(commKey) > 999999)
            {
                //lblOutputInfo.Items.Add("*CommKey illegal!");
                return -1;
            }

            int idwErrorCode = 0;

            CZKem.SetCommPassword(Convert.ToInt32(commKey));

            if (bIsConnected == true)
            {
                CZKem.Disconnect();
                sta_UnRegRealTime();
                SetConnectState(false);
                //lblOutputInfo.Items.Add("Disconnect with device !");
                //connected = false;
                return -2; //disconnect
            }

            if (CZKem.Connect_Net(ip, Convert.ToInt32(port)) == true)
            {
                SetConnectState(true);
                //sta_RegRealTime(lblOutputInfo);
                //lblOutputInfo.Items.Add("Connect with device !");

                //get Biotype
                sta_getBiometricType();

                return 1;
            }
            else
            {
                CZKem.GetLastError(ref idwErrorCode);
                //lblOutputInfo.Items.Add("*Unable to connect the device,ErrorCode=" + idwErrorCode.ToString());
                return idwErrorCode;
            }
        }

        public int sta_ConnectRS(ListBox lblOutputInfo, string deviceid, string port, string baudrate, string commkey)
        {
            if (deviceid == "" || port == "" || baudrate == "" || commkey == "")
            {
                lblOutputInfo.Items.Add("*Device ID, Port, Baudrate, Comm Key cannot be null !");
                return -1;
            }

            if (Convert.ToInt32(deviceid) < 0 || Convert.ToInt32(deviceid) > 256)
            {
                lblOutputInfo.Items.Add("*Device illegal!");
                return -1;
            }

            if (Convert.ToInt32(commkey) < 0 || Convert.ToInt32(commkey) > 999999)
            {
                lblOutputInfo.Items.Add("*CommKey illegal!");
                return -1;
            }

            int idwErrorCode = 0;

            int iDeviceID = Convert.ToInt32(deviceid);
            int iPort = 0;
            int iBaudrate = Convert.ToInt32(baudrate);
            int iCommkey = Convert.ToInt32(commkey);

            for (iPort = 1; iPort < 10; iPort++)
            {
                if (port.IndexOf(iPort.ToString()) > -1)
                {
                    break;
                }
            }

            CZKem.SetCommPassword(iCommkey);

            if (bIsConnected == true)
            {
                CZKem.Disconnect();
                sta_UnRegRealTime();
                SetConnectState(false);
                lblOutputInfo.Items.Add("Disconnect with device !");
                return -2; //disconnect
            }

            if (CZKem.Connect_Com(iPort, iDeviceID, iBaudrate) == true)
            {
                SetConnectState(true);
                sta_RegRealTime(lblOutputInfo);

                //get Biotype
                sta_getBiometricType();
                lblOutputInfo.Items.Add("Connect with device !");
                return 1;
            }
            else
            {
                CZKem.GetLastError(ref idwErrorCode);
                lblOutputInfo.Items.Add("*Unable to connect the device,ErrorCode=" + idwErrorCode.ToString());
                return idwErrorCode;
            }
        }

        public int sta_ConnectUSB(ListBox lblOutputInfo, string deviceid, string commkey)
        {
            if (deviceid == "" || commkey == "")
            {
                lblOutputInfo.Items.Add("*deviceid, commkey cannot be null !");
                return -1;
            }

            if (Convert.ToInt32(deviceid) < 0 || Convert.ToInt32(deviceid) > 256)
            {
                lblOutputInfo.Items.Add("*Device illegal!");
                return -1;
            }

            if (Convert.ToInt32(commkey) < 0 || Convert.ToInt32(commkey) > 999999)
            {
                lblOutputInfo.Items.Add("*CommKey illegal!");
                return -1;
            }

            int idwErrorCode = 0;
            int iPort = 0;
            int iBaudrate = 115200;
            int iDeviceID = Convert.ToInt32(deviceid);
            int iCommkey = Convert.ToInt32(commkey);
            string sCom = "";

            if (iDeviceID == 0 || iDeviceID > 255)
            {
                lblOutputInfo.Items.Add("*The Device ID is invalid !");
                return -1;
            }

            SearchforUSBCom usbcom = new SearchforUSBCom();
            bool bSearch = usbcom.SearchforCom(ref sCom);//modify by Darcy on Nov.26 2009
            if (bSearch == false)
            {
                lblOutputInfo.Items.Add("*Can not find the virtual serial port that can be used !");
                return -1;
            }

            for (iPort = 1; iPort < 10; iPort++)
            {
                if (sCom.IndexOf(iPort.ToString()) > -1)
                {
                    break;
                }
            }

            CZKem.SetCommPassword(iCommkey);

            if (bIsConnected == true)
            {
                CZKem.Disconnect();
                sta_UnRegRealTime();
                SetConnectState(false);
                lblOutputInfo.Items.Add("Disconnect with device !");
                return -2; //disconnect
            }

            if (CZKem.Connect_Com(iPort, iDeviceID, iBaudrate) == true)
            {
                SetConnectState(true);
                sta_RegRealTime(lblOutputInfo);

                //Get BioType
                sta_getBiometricType();

                lblOutputInfo.Items.Add("Connect with device !");
                return 1;
            }
            else
            {
                CZKem.GetLastError(ref idwErrorCode);
                lblOutputInfo.Items.Add("*Unable to connect the device,ErrorCode=" + idwErrorCode.ToString());
                return idwErrorCode;
            }
        }

        public int sta_GetDeviceInfo(ListBox lblOutputInfo, out string sFirmver, out string sMac, out string sPlatform, out string sSN, out string sProductTime, out string sDeviceName, out int iFPAlg, out int iFaceAlg, out string sProducter)
        {
            int iRet = 0;

            sFirmver = "";
            sMac = "";
            sPlatform = "";
            sSN = "";
            sProducter = "";
            sDeviceName = "";
            iFPAlg = 0;
            iFaceAlg = 0;
            sProductTime = "";
            string strTemp = "";

            if (GetConnectState() == false)
            {
                lblOutputInfo.Items.Add("*Please connect first!");
                return -1024;
            }

            CZKem.EnableDevice(GetMachineNumber(), false);//disable the device

            CZKem.GetSysOption(GetMachineNumber(), "~ZKFPVersion", out strTemp);
            iFPAlg = Convert.ToInt32(strTemp);

            CZKem.GetSysOption(GetMachineNumber(), "ZKFaceVersion", out strTemp);
            iFaceAlg = Convert.ToInt32(strTemp);

            /*
            axCZKEM1.GetDeviceInfo(GetMachineNumber(), 72, ref iFPAlg);
            axCZKEM1.GetDeviceInfo(GetMachineNumber(), 73, ref iFaceAlg);
            */

            CZKem.GetVendor(ref sProducter);
            CZKem.GetProductCode(GetMachineNumber(), out sDeviceName);
            CZKem.GetDeviceMAC(GetMachineNumber(), ref sMac);
            CZKem.GetFirmwareVersion(GetMachineNumber(), ref sFirmver);

            /*
            if (sta_GetDeviceType() == 1)
            {
                axCZKEM1.GetDeviceFirmwareVersion(GetMachineNumber(), ref sFirmver);
            }
             */
            //lblOutputInfo.Items.Add("[func GetDeviceFirmwareVersion]Temporarily unsupported");

            CZKem.GetPlatform(GetMachineNumber(), ref sPlatform);
            CZKem.GetSerialNumber(GetMachineNumber(), out sSN);
            CZKem.GetDeviceStrInfo(GetMachineNumber(), 1, out sProductTime);

            CZKem.EnableDevice(GetMachineNumber(), true);//enable the device

            lblOutputInfo.Items.Add("Get the device info successfully");
            iRet = 1;
            return iRet;
        }

        public int sta_GetCapacityInfo(ListBox lblOutputInfo, out int adminCnt, out int userCount, out int fpCnt, out int recordCnt, out int pwdCnt, out int oplogCnt, out int faceCnt)
        {
            int ret = 0;

            adminCnt = 0;
            userCount = 0;
            fpCnt = 0;
            recordCnt = 0;
            pwdCnt = 0;
            oplogCnt = 0;
            faceCnt = 0;

            if (GetConnectState() == false)
            {
                lblOutputInfo.Items.Add("*Please connect first!");
                return -1024;
            }

            CZKem.EnableDevice(GetMachineNumber(), false);//disable the device

            CZKem.GetDeviceStatus(GetMachineNumber(), 2, ref userCount);
            CZKem.GetDeviceStatus(GetMachineNumber(), 1, ref adminCnt);
            CZKem.GetDeviceStatus(GetMachineNumber(), 3, ref fpCnt);
            CZKem.GetDeviceStatus(GetMachineNumber(), 4, ref pwdCnt);
            CZKem.GetDeviceStatus(GetMachineNumber(), 5, ref oplogCnt);
            CZKem.GetDeviceStatus(GetMachineNumber(), 6, ref recordCnt);
            CZKem.GetDeviceStatus(GetMachineNumber(), 21, ref faceCnt);

            CZKem.EnableDevice(GetMachineNumber(), true);//enable the device

            lblOutputInfo.Items.Add("Get the device capacity successfully");

            ret = 1;
            return ret;
        }

        public void sta_DisConnect()
        {
            if (GetConnectState() == true)
            {
                CZKem.Disconnect();
                sta_UnRegRealTime();
            }
        }
        #endregion
        #region RealTimeEvent

        public delegate ListBox GetRealEventListBoxHandler();
        private GetRealEventListBoxHandler gRealEventListBoxHandler;
        private ListBox gRealEventListBox;

        public void sta_SetRTLogListBox(GetRealEventListBoxHandler gvHandler)
        {
            gRealEventListBoxHandler = gvHandler;
            gRealEventListBox = gRealEventListBoxHandler();
        }

        public void sta_UnRegRealTime()
        {
            this.CZKem.OnFinger -= new zkemkeeper._IZKEMEvents_OnFingerEventHandler(axCZKEM1_OnFinger);
            this.CZKem.OnVerify -= new zkemkeeper._IZKEMEvents_OnVerifyEventHandler(axCZKEM1_OnVerify);
            this.CZKem.OnAttTransactionEx -= new zkemkeeper._IZKEMEvents_OnAttTransactionExEventHandler(axCZKEM1_OnAttTransactionEx);
            this.CZKem.OnFingerFeature -= new zkemkeeper._IZKEMEvents_OnFingerFeatureEventHandler(axCZKEM1_OnFingerFeature);
            this.CZKem.OnDeleteTemplate -= new zkemkeeper._IZKEMEvents_OnDeleteTemplateEventHandler(axCZKEM1_OnDeleteTemplate);
            this.CZKem.OnNewUser -= new zkemkeeper._IZKEMEvents_OnNewUserEventHandler(axCZKEM1_OnNewUser);
            this.CZKem.OnHIDNum -= new zkemkeeper._IZKEMEvents_OnHIDNumEventHandler(axCZKEM1_OnHIDNum);
            this.CZKem.OnAlarm -= new zkemkeeper._IZKEMEvents_OnAlarmEventHandler(axCZKEM1_OnAlarm);
            this.CZKem.OnDoor -= new zkemkeeper._IZKEMEvents_OnDoorEventHandler(axCZKEM1_OnDoor);
            this.CZKem.OnEnrollFingerEx -= new zkemkeeper._IZKEMEvents_OnEnrollFingerExEventHandler(axCZKEM1_OnEnrollFingerEx);
            this.CZKem.OnWriteCard += new zkemkeeper._IZKEMEvents_OnWriteCardEventHandler(axCZKEM1_OnWriteCard);
            this.CZKem.OnEmptyCard += new zkemkeeper._IZKEMEvents_OnEmptyCardEventHandler(axCZKEM1_OnEmptyCard);
            this.CZKem.OnHIDNum += new zkemkeeper._IZKEMEvents_OnHIDNumEventHandler(axCZKEM1_OnHIDNum);
            this.CZKem.OnAttTransaction -= new zkemkeeper._IZKEMEvents_OnAttTransactionEventHandler(axCZKEM1_OnAttTransaction);
            this.CZKem.OnKeyPress += new zkemkeeper._IZKEMEvents_OnKeyPressEventHandler(axCZKEM1_OnKeyPress);
            this.CZKem.OnEnrollFinger += new zkemkeeper._IZKEMEvents_OnEnrollFingerEventHandler(axCZKEM1_OnEnrollFinger);

        }

        public int sta_RegRealTime(ListBox lblOutputInfo)
        {
            if (GetConnectState() == false)
            {
                lblOutputInfo.Items.Add("*Please connect first!");
                return -1024;
            }

            int ret = 0;

            if (CZKem.RegEvent(GetMachineNumber(), 65535))//Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)
            {
                //common interface
                this.CZKem.OnFinger += new zkemkeeper._IZKEMEvents_OnFingerEventHandler(axCZKEM1_OnFinger);
                this.CZKem.OnVerify += new zkemkeeper._IZKEMEvents_OnVerifyEventHandler(axCZKEM1_OnVerify);
                this.CZKem.OnFingerFeature += new zkemkeeper._IZKEMEvents_OnFingerFeatureEventHandler(axCZKEM1_OnFingerFeature);
                this.CZKem.OnDeleteTemplate += new zkemkeeper._IZKEMEvents_OnDeleteTemplateEventHandler(axCZKEM1_OnDeleteTemplate);
                this.CZKem.OnNewUser += new zkemkeeper._IZKEMEvents_OnNewUserEventHandler(axCZKEM1_OnNewUser);
                this.CZKem.OnHIDNum += new zkemkeeper._IZKEMEvents_OnHIDNumEventHandler(axCZKEM1_OnHIDNum);
                this.CZKem.OnAlarm += new zkemkeeper._IZKEMEvents_OnAlarmEventHandler(axCZKEM1_OnAlarm);
                this.CZKem.OnDoor += new zkemkeeper._IZKEMEvents_OnDoorEventHandler(axCZKEM1_OnDoor);

                //only for color device
                this.CZKem.OnAttTransactionEx += new zkemkeeper._IZKEMEvents_OnAttTransactionExEventHandler(axCZKEM1_OnAttTransactionEx);
                this.CZKem.OnEnrollFingerEx += new zkemkeeper._IZKEMEvents_OnEnrollFingerExEventHandler(axCZKEM1_OnEnrollFingerEx);

                //only for black&white device
                this.CZKem.OnAttTransaction -= new zkemkeeper._IZKEMEvents_OnAttTransactionEventHandler(axCZKEM1_OnAttTransaction);
                this.CZKem.OnWriteCard += new zkemkeeper._IZKEMEvents_OnWriteCardEventHandler(axCZKEM1_OnWriteCard);
                this.CZKem.OnEmptyCard += new zkemkeeper._IZKEMEvents_OnEmptyCardEventHandler(axCZKEM1_OnEmptyCard);
                this.CZKem.OnKeyPress += new zkemkeeper._IZKEMEvents_OnKeyPressEventHandler(axCZKEM1_OnKeyPress);
                this.CZKem.OnEnrollFinger += new zkemkeeper._IZKEMEvents_OnEnrollFingerEventHandler(axCZKEM1_OnEnrollFinger);


                ret = 1;
            }
            else
            {
                CZKem.GetLastError(ref idwErrorCode);
                ret = idwErrorCode;

                if (idwErrorCode != 0)
                {
                    lblOutputInfo.Items.Add("*RegEvent failed,ErrorCode: " + idwErrorCode.ToString());
                }
                else
                {
                    lblOutputInfo.Items.Add("*No data from terminal returns!");
                }
            }
            return ret;
        }

        //When you are enrolling your finger,this event will be triggered.
        void axCZKEM1_OnEnrollFingerEx(string EnrollNumber, int FingerIndex, int ActionResult, int TemplateLength)
        {
            if (ActionResult == 0)
            {
                gRealEventListBox.Items.Add("Enroll finger succeed. UserID=" + EnrollNumber.ToString() + "...FingerIndex=" + FingerIndex.ToString());
            }
            else
            {
                gRealEventListBox.Items.Add("Enroll finger failed. Result=" + ActionResult.ToString());
            }
            throw new NotImplementedException();
        }

        //Door sensor event
        void axCZKEM1_OnDoor(int EventType)
        {
            gRealEventListBox.Items.Add("Door opened" + "...EventType=" + EventType.ToString());

            throw new NotImplementedException();
        }

        //When the dismantling machine or duress alarm occurs, trigger this event.
        void axCZKEM1_OnAlarm(int AlarmType, int EnrollNumber, int Verified)
        {
            gRealEventListBox.Items.Add("Alarm triggered" + "...AlarmType=" + AlarmType.ToString() + "...EnrollNumber=" + EnrollNumber.ToString() + "...Verified=" + Verified.ToString());

            throw new NotImplementedException();
        }

        //When you swipe a card to the device, this event will be triggered to show you the card number.
        void axCZKEM1_OnHIDNum(int CardNumber)
        {
            gRealEventListBox.Items.Add("Card event" + "...Cardnumber=" + CardNumber.ToString());

            throw new NotImplementedException();
        }

        //When you have enrolled a new user,this event will be triggered.
        void axCZKEM1_OnNewUser(int EnrollNumber)
        {
            gRealEventListBox.Items.Add("Enroll a　new user" + "...UserID=" + EnrollNumber.ToString());

            throw new NotImplementedException();
        }

        //When you have deleted one one fingerprint template,this event will be triggered.
        void axCZKEM1_OnDeleteTemplate(int EnrollNumber, int FingerIndex)
        {
            gRealEventListBox.Items.Add("Delete a finger template" + "...UserID=" + EnrollNumber.ToString() + "..FingerIndex=" + FingerIndex.ToString());

            throw new NotImplementedException();
        }

        //When you have enrolled your finger,this event will be triggered and return the quality of the fingerprint you have enrolled
        void axCZKEM1_OnFingerFeature(int Score)
        {
            gRealEventListBox.Items.Add("Press finger score=" + Score.ToString());

            throw new NotImplementedException();
        }

        //If your fingerprint(or your card) passes the verification,this event will be triggered,only for color device
        void axCZKEM1_OnAttTransactionEx(string EnrollNumber, int IsInValid, int AttState, int VerifyMethod, int Year, int Month, int Day, int Hour, int Minute, int Second, int WorkCode)
        {
            string time = Year + "-" + Month + "-" + Day + " " + Hour + ":" + Minute + ":" + Second;

            gRealEventListBox.Items.Add("Verify OK.UserID=" + EnrollNumber + " isInvalid=" + IsInValid.ToString() + " state=" + AttState.ToString() + " verifystyle=" + VerifyMethod.ToString() + " time=" + time);

            throw new NotImplementedException();
        }

        //If your fingerprint(or your card) passes the verification,this event will be triggered,only for black%white device
        private void axCZKEM1_OnAttTransaction(int EnrollNumber, int IsInValid, int AttState, int VerifyMethod, int Year, int Month, int Day, int Hour, int Minute, int Second)
        {
            string time = Year + "-" + Month + "-" + Day + " " + Hour + ":" + Minute + ":" + Second;
            gRealEventListBox.Items.Add("Verify OK.UserID=" + EnrollNumber.ToString() + " isInvalid=" + IsInValid.ToString() + " state=" + AttState.ToString() + " verifystyle=" + VerifyMethod.ToString() + " time=" + time);

            throw new NotImplementedException();
        }

        //After you have placed your finger on the sensor(or swipe your card to the device),this event will be triggered.
        //If you passes the verification,the returned value userid will be the user enrollnumber,or else the value will be -1;
        void axCZKEM1_OnVerify(int UserID)
        {
            if (UserID != -1)
            {
                gRealEventListBox.Items.Add("User fingerprint verified... UserID=" + UserID.ToString());
            }
            else
            {
                gRealEventListBox.Items.Add("Failed to verify... ");
            }

            throw new NotImplementedException();
        }

        //When you place your finger on sensor of the device,this event will be triggered
        void axCZKEM1_OnFinger()
        {
            gRealEventListBox.Items.Add("OnFinger event ");

            throw new NotImplementedException();
        }

        //When you have written into the Mifare card ,this event will be triggered.
        void axCZKEM1_OnWriteCard(int iEnrollNumber, int iActionResult, int iLength)
        {
            if (iActionResult == 0)
            {
                gRealEventListBox.Items.Add("Write Mifare Card OK" + "...EnrollNumber=" + iEnrollNumber.ToString() + "...TmpLength=" + iLength.ToString());
            }
            else
            {
                gRealEventListBox.Items.Add("...Write Failed");
            }
        }

        //When you have emptyed the Mifare card,this event will be triggered.
        void axCZKEM1_OnEmptyCard(int iActionResult)
        {
            if (iActionResult == 0)
            {
                gRealEventListBox.Items.Add("Empty Mifare Card OK...");
            }
            else
            {
                gRealEventListBox.Items.Add("Empty Failed...");
            }
        }

        //When you press the keypad,this event will be triggered.
        void axCZKEM1_OnKeyPress(int iKey)
        {
            gRealEventListBox.Items.Add("RTEvent OnKeyPress Has been Triggered, Key: " + iKey.ToString());
        }

        //When you are enrolling your finger,this event will be triggered.
        void axCZKEM1_OnEnrollFinger(int EnrollNumber, int FingerIndex, int ActionResult, int TemplateLength)
        {
            if (ActionResult == 0)
            {
                gRealEventListBox.Items.Add("Enroll finger succeed. UserID=" + EnrollNumber + "...FingerIndex=" + FingerIndex.ToString());
            }
            else
            {
                gRealEventListBox.Items.Add("Enroll finger failed. Result=" + ActionResult.ToString());
            }
            throw new NotImplementedException();
        }

        #endregion

        #region UserMng
        #region UserBio

        /*
        public void connectDevice(string ip, int port, int commKey)
        {
            
            axCZKEM1.SetCommPassword(commKey);
            connected = axCZKEM1.Connect_Net(ip, port);
            if (connected)
            {
                sta_getBiometricType();
            }
        }

        public void disconnectDevice()
        {
            if (connected) axCZKEM1.Disconnect();
        }
        */

        private string sta_getSysOptions(string option)
        {
            string value = string.Empty;
            CZKem.GetSysOption(iMachineNumber, option, out value);
            return value;
        }

        /// <summary>
        /// get version
        /// </summary>
        /// <returns></returns>
        public void sta_getBiometricVersion()
        {
            string result = string.Empty;
            _biometricVersion = sta_getSysOptions("BiometricVersion");
        }

        /// <summary>
        /// get support type
        /// </summary>
        /// <returns></returns>
        public void sta_getBiometricType()
        {
            string result = string.Empty;
            result = sta_getSysOptions("BiometricType");
            if (!string.IsNullOrEmpty(result))
            {
                _supportBiometricType.fp_available = result[1] == '1';
                _supportBiometricType.face_available = result[2] == '1';
                if (result.Length >= 9)
                {
                    _supportBiometricType.fingerVein_available = result[7] == '1';
                    _supportBiometricType.palm_available = result[8] == '1';
                }
            }
            _biometricType = result;
        }

        public List<Employee> sta_getEmployees()
        {
            if (!GetConnectState())
            {
                return new List<Employee>();
            }
            List<Employee> employees = new List<Employee>();

            string empnoStr = string.Empty;
            string name = string.Empty;
            string pwd = string.Empty;
            int pri = 0;
            bool enable = true;
            string cardNum = string.Empty;

            CZKem.EnableDevice(iMachineNumber, false);
            try
            {
                CZKem.ReadAllUserID(iMachineNumber);

                while (CZKem.SSR_GetAllUserInfo(iMachineNumber, out empnoStr, out name, out pwd, out pri, out enable))
                {
                    cardNum = "";
                    if (CZKem.GetStrCardNumber(out cardNum))
                    {
                        if (string.IsNullOrEmpty(cardNum))
                            cardNum = "";
                    }
                    if (!string.IsNullOrEmpty(name))
                    {
                        int index = name.IndexOf("\0");
                        if (index > 0)
                        {
                            name = name.Substring(0, index);
                        }
                    }

                    Employee emp = new Employee();
                    emp.pin = empnoStr;
                    emp.name = name;
                    emp.privilege = pri;
                    emp.password = pwd;
                    emp.cardNumber = cardNum;

                    employees.Add(emp);
                }
            }
            catch
            {

            }
            finally
            {
                CZKem.EnableDevice(iMachineNumber, true);
            }
            return employees;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="bioTemplate"></param>
        private void sta_getBioTemplateFromBuffer(string buffer, ref BioTemplate bioTemplate)
        {
            string temp;
            for (int i = 1; i <= 10; i++)
            {
                if (buffer.IndexOf(',') > 0)
                {
                    temp = buffer.Substring(0, buffer.IndexOf(','));
                }
                else
                {
                    temp = buffer;
                }

                switch (i)
                {
                    case 1:
                        bioTemplate.pin = temp;
                        break;
                    case 2:
                        bioTemplate.valid_flag = int.Parse(temp);
                        break;
                    case 3:
                        bioTemplate.is_duress = int.Parse(temp);
                        break;
                    case 4:
                        bioTemplate.bio_type = int.Parse(temp);
                        break;
                    case 5:
                        bioTemplate.version = temp;
                        break;
                    case 6:
                        bioTemplate.version = bioTemplate.version + "." + temp;
                        break;
                    case 7:
                        bioTemplate.data_format = int.Parse(temp);
                        break;
                    case 8:
                        bioTemplate.template_no = int.Parse(temp);
                        break;
                    case 9:
                        bioTemplate.template_no_index = int.Parse(temp);
                        break;
                    case 10:
                        bioTemplate.template_data = temp;
                        break;
                }

                buffer = buffer.Substring(buffer.IndexOf(',') + 1);
            }
        }

        /// <summary>
        /// get template
        /// </summary>
        /// <param name="aBioType">
        /// <returns></returns>
        private List<string> sta_batchDownloadBioTemplates(System.Windows.Forms.ProgressBar procBar, int aBioType)
        {
            int tempNum = 50;
            int tn = 2;
            List<string> bufferList = new List<string>();
            foreach (Employee e in employeeList)
            {
                string filter;
                if (aBioType == 1)
                    filter = string.Format("Type={0}", aBioType);
                else
                    filter = string.Format("Pin={0}\tType={1}", e.pin, aBioType);

                int dataCount = CZKem.SSR_GetDeviceDataCount(PersBioTableName, filter, string.Empty);
                int nC = aBioType == 1 ? 1 : aBioType == 2 ? 12 : aBioType == 7 ? 3 : aBioType == 8 ? 6 : 0;

                string strOffBuffer = string.Empty;
                int eBufferSize = 0;
                bool result = true;
                int n = 0;

                while (true)
                {
                    n = 0;
                    strOffBuffer = string.Empty;
                    eBufferSize = dataCount * 3500 * nC;
                    string option = string.Empty;
                    try
                    {
                        result = CZKem.SSR_GetDeviceData(iMachineNumber, out strOffBuffer, eBufferSize,
                            PersBioTableName, PersBioTableFields, filter, option);
                    }
                    catch
                    {
                        result = false;
                        int errorCode = 0;
                        CZKem.GetLastError(ref errorCode);
                    }
                    if (result) break;
                    if (!result && n == 2) break;
                    n++;
                }
                if (result)
                {
                    bufferList.Add(strOffBuffer);
                    if ((bufferList.Count / tempNum) >= 0)
                    {
                        procBar.Value = tn;
                        tn += tn;
                        if (tn >= 90)
                            tn = 90;
                        tempNum = tempNum + 50;
                    }
                }
                if (aBioType == 1)   //表示指纹模板获取
                {
                    break;
                }
            }
            return bufferList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aBioType"></param>
        /// <returns></returns>
        public List<BioTemplate> sta_BatchGetBioTemplates(System.Windows.Forms.ProgressBar procBar, int aBioType)
        {
            List<BioTemplate> bioTemplateList = new List<BioTemplate>();
            List<string> bufferList = sta_batchDownloadBioTemplates(procBar, aBioType);
            for (int i = 0; i < bufferList.Count; i++)
            {
                string[] buffers = bufferList[i].Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 1; j < buffers.Length; j++)
                {
                    BioTemplate bioTemplate = new BioTemplate();
                    sta_getBioTemplateFromBuffer(buffers[j], ref bioTemplate);
                    bioTemplateList.Add(bioTemplate);
                }
            }

            return bioTemplateList;
        }

        private string sta_AssemblesAllUserBioTemplateInfo(List<BioTemplate> bioTemplateList, int aBioType, string version)
        {
            List<BioTemplate> uploadBioTemplateList = bioTemplateList.FindAll(t => t.bio_type == aBioType && t.version.Equals(version));

            string bioTemplateVersion = string.Empty;
            string eMajorVer = string.Empty;
            string eMinorVer = string.Empty;
            StringBuilder result = new StringBuilder();
            foreach (BioTemplate template in uploadBioTemplateList)
            {
                bioTemplateVersion = template.version;
                if (bioTemplateVersion.IndexOf('.') < 0) bioTemplateVersion = bioTemplateVersion + ".0";
                eMajorVer = bioTemplateVersion.Substring(0, bioTemplateVersion.IndexOf('.'));
                eMinorVer = bioTemplateVersion.Substring(bioTemplateVersion.IndexOf('.') + 1);
                result.Append(string.Format("Pin={0}\tValid={1}\tDuress={2}\tType={3}\tMajorVer={4}\tMinorVer={5}\tFormat={6}\tNo={7}\tIndex={8}\tTmp={9}\r\n",
                    template.pin, template.valid_flag, template.is_duress, template.bio_type, eMajorVer, eMinorVer, template.data_format, template.template_no,
                    template.template_no_index, template.template_data));
            }
            return result.ToString();
        }

        public void sta_setBioTemplates(List<BioTemplate> bioTemplateList, out string message)
        {
            message = string.Empty;
            if (string.IsNullOrEmpty(_biometricVersion)) sta_getBiometricVersion();
            if (string.IsNullOrEmpty(_biometricType)) sta_getBiometricType();
            string[] versions = _biometricVersion.Split(':');

            StringBuilder errorMsg = new StringBuilder();
            for (int i = 0; i < _biometricType.Length; i++)
            {
                if (_biometricType[i] == '1')
                {
                    string buffer = sta_AssemblesAllUserBioTemplateInfo(bioTemplateList, i, versions[i]);
                    try
                    {
                        int errorCode = 0;
                        bool result = true;
                        if (!string.IsNullOrEmpty(buffer))
                        {
                            result = CZKem.SSR_SetDeviceData(1, PersBioTableName, buffer, string.Empty);
                        }

                        if (!result)
                        {
                            CZKem.GetLastError(ref errorCode);
                            errorMsg.Append(string.Format(" errorcode={0} ", errorCode));
                        }
                    }
                    catch (Exception e)
                    {
                        errorMsg.Append(e.Message);
                    }
                }
            }
            CZKem.RefreshData(iMachineNumber);
            CZKem.EnableDevice(iMachineNumber, true);
        }

        public void sta_setEmployees(List<Employee> employees)
        {
            CZKem.EnableDevice(1, false);
            try
            {
                bool batchUpdate = CZKem.BeginBatchUpdate(iMachineNumber, 1);
                foreach (Employee emp in employees)
                {
                    CZKem.SetStrCardNumber(emp.cardNumber);
                    CZKem.SSR_SetUserInfo(iMachineNumber, emp.pin, emp.name, emp.password, emp.privilege, true);
                }
                if (batchUpdate)
                {
                    CZKem.BatchUpdate(iMachineNumber);
                    batchUpdate = false;
                }
            }
            catch
            { }
            finally
            {
                CZKem.EnableDevice(iMachineNumber, true);
            }
        }

        #endregion
        public int sta_GetAllUserID(bool bEnable, ComboBox cbUserID, ComboBox cbUserID1, ComboBox cbUserID2, ComboBox cbUserID3, ComboBox cbUserID4, TextBox txtID2, ComboBox cbUserID7)
        {
            if (GetConnectState() == false)
            {
                return -1024;
            }

            string sEnrollNumber = "";
            bool bEnabled = false;
            string sName = "";
            string sPassword = "";
            int iPrivilege = 0;

            if (bAddControl == true || bEnable == true)
            {
                cbUserID.Items.Clear();
                cbUserID1.Items.Clear();
                cbUserID2.Items.Clear();
                cbUserID3.Items.Clear();
                cbUserID4.Items.Clear();
                txtID2.Clear();
                cbUserID7.Items.Clear();

                CZKem.EnableDevice(iMachineNumber, false);
                CZKem.ReadAllUserID(iMachineNumber);//read all the user information to the memory
                while (CZKem.SSR_GetAllUserInfo(iMachineNumber, out sEnrollNumber, out sName, out sPassword, out iPrivilege, out bEnabled))//get all the users' information from the memory
                {
                    cbUserID.Items.Add(sEnrollNumber);
                    cbUserID1.Items.Add(sEnrollNumber);
                    cbUserID2.Items.Add(sEnrollNumber);
                    cbUserID3.Items.Add(sEnrollNumber);
                    cbUserID4.Items.Add(sEnrollNumber);
                    //txtID2.Text = sEnrollNumber;
                    cbUserID7.Items.Add(sEnrollNumber);
                }

                CZKem.EnableDevice(iMachineNumber, true);
            }

            bAddControl = false;
            bEnable = false;

            return 1;
        }
        #endregion

        #region DataMng
        #region AttLogMng
        public int sta_readAttLog(ListBox lblOutputInfo, DataTable dt_log)
        {
            if (GetConnectState() == false)
            {
                lblOutputInfo.Items.Add("*Please connect first!");
                return -1024;
            }

            int ret = 0;

            CZKem.EnableDevice(GetMachineNumber(), false);//disable the device

            string sdwEnrollNumber = "";
            int idwVerifyMode = 0;
            int idwInOutMode = 0;
            int idwYear = 0;
            int idwMonth = 0;
            int idwDay = 0;
            int idwHour = 0;
            int idwMinute = 0;
            int idwSecond = 0;
            int idwWorkcode = 0;

            if (CZKem.ReadGeneralLogData(GetMachineNumber()))
            {
                while (CZKem.SSR_GetGeneralLogData(GetMachineNumber(), out sdwEnrollNumber, out idwVerifyMode,
                            out idwInOutMode, out idwYear, out idwMonth, out idwDay, out idwHour, out idwMinute, out idwSecond, ref idwWorkcode))//get records from the memory
                {
                    DataRow dr = dt_log.NewRow();
                    dr["User ID"] = sdwEnrollNumber;
                    dr["Verify Date"] = idwYear + "-" + idwMonth + "-" + idwDay + " " + idwHour + ":" + idwMinute + ":" + idwSecond;
                    dr["Verify Type"] = idwVerifyMode;
                    dr["Verify State"] = idwInOutMode;
                    dr["WorkCode"] = idwWorkcode;
                    dt_log.Rows.Add(dr);
                }
                ret = 1;
            }
            else
            {
                CZKem.GetLastError(ref idwErrorCode);
                ret = idwErrorCode;

                if (idwErrorCode != 0)
                {
                    lblOutputInfo.Items.Add("*Read attlog failed,ErrorCode: " + idwErrorCode.ToString());
                }
                else
                {
                    lblOutputInfo.Items.Add("No data from terminal returns!");
                }
            }

            CZKem.EnableDevice(GetMachineNumber(), true);//enable the device

            return ret;
        }
        public void sta_ReadByDate(int Day, int Month, int Year, DataTable dt_log)
        {
            if (GetConnectState() == false)
            {
                //lblOutputInfo.Items.Add("*Please connect first!");
                //return -1024;
            }


            CZKem.EnableDevice(GetMachineNumber(), false);//disable the device

            string sdwEnrollNumber = "";
            int idwVerifyMode = 0;
            int idwInOutMode = 0;
            int idwYear = 0;
            int idwMonth = 0;
            int idwDay = 0;
            int idwHour = 0;
            int idwMinute = 0;
            int idwSecond = 0;
            int idwWorkcode = 0;

            if (CZKem.ReadGeneralLogData(GetMachineNumber()))
            {
                while (CZKem.SSR_GetGeneralLogData(GetMachineNumber(), out sdwEnrollNumber, out idwVerifyMode,
                            out idwInOutMode, out idwYear, out idwMonth, out idwDay, out idwHour, out idwMinute, out idwSecond, ref idwWorkcode))//get records from the memory
                {
                    DataRow dr = dt_log.NewRow();
                    if (idwYear == Year && idwMonth == Month && idwDay == Day)
                    {
                        int IdZkt=Convert.ToInt32(sdwEnrollNumber);
                        string Nombre = DAOZkTeko.ObtenerNombre(IdZkt);
                        dr["Nombre"] = Nombre;
                        dr["User ID"] = sdwEnrollNumber;
                        dr["Verify Date"] = idwYear + "-" + idwMonth + "-" + idwDay + " " + idwHour + ":" + idwMinute + ":" + idwSecond;
                        
                        dt_log.Rows.Add(dr);
                    }


                }

            }
            else
            {
                CZKem.GetLastError(ref idwErrorCode);


                if (idwErrorCode != 0)
                {
                    //lblOutputInfo.Items.Add("*Read attlog failed,ErrorCode: " + idwErrorCode.ToString());
                }
                else
                {
                    //lblOutputInfo.Items.Add("No data from terminal returns!");
                }
            }

            CZKem.EnableDevice(GetMachineNumber(), true);//enable the device
            Desconectar();

        }


        public void Desconectar()
        {
            CZKem.Disconnect();
            sta_UnRegRealTime();
            SetConnectState(false);
        }
        public int sta_readLogByPeriod(ListBox lblOutputInfo, DataTable dt_logPeriod, string fromTime, string toTime)
        {
            if (GetConnectState() == false)
            {
                //lblOutputInfo.Items.Add("*Please connect first!");
                return -1024;
            }

            int ret = 0;

            CZKem.EnableDevice(GetMachineNumber(), false);//disable the device

            string sdwEnrollNumber = "";
            int idwVerifyMode = 0;
            int idwInOutMode = 0;
            int idwYear = 0;
            int idwMonth = 0;
            int idwDay = 0;
            int idwHour = 0;
            int idwMinute = 0;
            int idwSecond = 0;
            int idwWorkcode = 0;


            if (CZKem.ReadTimeGLogData(GetMachineNumber(), fromTime, toTime))
            {
                while (CZKem.SSR_GetGeneralLogData(GetMachineNumber(), out sdwEnrollNumber, out idwVerifyMode,
                            out idwInOutMode, out idwYear, out idwMonth, out idwDay, out idwHour, out idwMinute, out idwSecond, ref idwWorkcode))//get records from the memory
                {
                    DataRow dr = dt_logPeriod.NewRow();
                    dr["User ID"] = sdwEnrollNumber;
                    dr["Verify Date"] = idwYear + "-" + idwMonth + "-" + idwDay + " " + idwHour + ":" + idwMinute + ":" + idwSecond;
                    dr["Verify Type"] = idwVerifyMode;
                    dr["Verify State"] = idwInOutMode;
                    dr["WorkCode"] = idwWorkcode;
                    dt_logPeriod.Rows.Add(dr);
                }
                ret = 1;
            }
            else
            {
                CZKem.GetLastError(ref idwErrorCode);
                ret = idwErrorCode;

                if (idwErrorCode != 0)
                {
                    //lblOutputInfo.Items.Add("*Read attlog by period failed,ErrorCode: " + idwErrorCode.ToString());
                }
                else
                {
                    //lblOutputInfo.Items.Add("No data from terminal returns!");
                }
            }


            //lblOutputInfo.Items.Add("[func ReadTimeGLogData]Temporarily unsupported");
            CZKem.EnableDevice(GetMachineNumber(), true);//enable the device

            return ret;
        }

        public int sta_DeleteAttLog(ListBox lblOutputInfo)
        {
            if (GetConnectState() == false)
            {
                lblOutputInfo.Items.Add("*Please connect first!");
                return -1024;
            }

            int ret = 0;

            CZKem.EnableDevice(GetMachineNumber(), false);//disable the device


            if (CZKem.ClearGLog(GetMachineNumber()))
            {
                CZKem.RefreshData(GetMachineNumber());
                ret = 1;
            }
            else
            {
                CZKem.GetLastError(ref idwErrorCode);
                ret = idwErrorCode;

                if (idwErrorCode != 0)
                {
                    lblOutputInfo.Items.Add("*Delete attlog, ErrorCode: " + idwErrorCode.ToString());
                }
                else
                {
                    lblOutputInfo.Items.Add("No data from terminal returns!");
                }
            }

            CZKem.EnableDevice(GetMachineNumber(), true);//enable the device

            return ret;
        }

        public int sta_DeleteAttLogByPeriod(ListBox lblOutputInfo, string fromTime, string toTime)
        {
            if (GetConnectState() == false)
            {
                lblOutputInfo.Items.Add("*Please connect first!");
                return -1024;
            }

            int ret = 0;

            CZKem.EnableDevice(GetMachineNumber(), false);//disable the device


            if (CZKem.DeleteAttlogBetweenTheDate(GetMachineNumber(), fromTime, toTime))
            {
                CZKem.RefreshData(GetMachineNumber());
                ret = 1;
            }
            else
            {
                CZKem.GetLastError(ref idwErrorCode);
                ret = idwErrorCode;

                if (idwErrorCode != 0)
                {
                    lblOutputInfo.Items.Add("*Delete attlog by period failed,ErrorCode: " + idwErrorCode.ToString());
                }
                else
                {
                    lblOutputInfo.Items.Add("No data from terminal returns!");
                }
            }

            //lblOutputInfo.Items.Add("[func DeleteAttlogBetweenTheDate]Temporarily unsupported");
            CZKem.EnableDevice(GetMachineNumber(), true);//enable the device

            return ret;
        }

        public int sta_DelOldAttLogFromTime(ListBox lblOutputInfo, string fromTime)
        {
            if (GetConnectState() == false)
            {
                lblOutputInfo.Items.Add("Please connect first!");
                return -1024;
            }

            int ret = 0;

            CZKem.EnableDevice(GetMachineNumber(), false);//disable the device


            if (CZKem.DeleteAttlogByTime(GetMachineNumber(), fromTime))
            {
                CZKem.RefreshData(GetMachineNumber());
                ret = 1;
            }
            else
            {
                CZKem.GetLastError(ref idwErrorCode);
                ret = idwErrorCode;

                if (idwErrorCode != 0)
                {
                    lblOutputInfo.Items.Add("*Delete old attlog from time failed,ErrorCode: " + idwErrorCode.ToString());
                }
                else
                {
                    lblOutputInfo.Items.Add("No data from terminal returns!");
                }
            }

            //lblOutputInfo.Items.Add("[func DeleteAttlogByTime]Temporarily unsupported");
            CZKem.EnableDevice(GetMachineNumber(), true);//enable the device

            return ret;
        }

        public int sta_ReadNewAttLog(ListBox lblOutputInfo, DataTable dt_logNew)
        {
            if (GetConnectState() == false)
            {
                lblOutputInfo.Items.Add("Please connect first!");
                return -1024;
            }

            int ret = 0;

            CZKem.EnableDevice(GetMachineNumber(), false);//disable the device

            string sdwEnrollNumber = "";
            int idwVerifyMode = 0;
            int idwInOutMode = 0;
            int idwYear = 0;
            int idwMonth = 0;
            int idwDay = 0;
            int idwHour = 0;
            int idwMinute = 0;
            int idwSecond = 0;
            int idwWorkcode = 0;


            if (CZKem.ReadNewGLogData(GetMachineNumber()))
            {
                while (CZKem.SSR_GetGeneralLogData(GetMachineNumber(), out sdwEnrollNumber, out idwVerifyMode,
                            out idwInOutMode, out idwYear, out idwMonth, out idwDay, out idwHour, out idwMinute, out idwSecond, ref idwWorkcode))//get records from the memory
                {
                    DataRow dr = dt_logNew.NewRow();
                    dr["User ID"] = sdwEnrollNumber;
                    dr["Verify Date"] = idwYear + "-" + idwMonth + "-" + idwDay + " " + idwHour + ":" + idwMinute + ":" + idwSecond;
                    dr["Verify Type"] = idwVerifyMode;
                    dr["Verify State"] = idwInOutMode;
                    dr["WorkCode"] = idwWorkcode;
                    dt_logNew.Rows.Add(dr);
                }
                ret = 1;
            }
            else
            {
                CZKem.GetLastError(ref idwErrorCode);
                ret = idwErrorCode;

                if (idwErrorCode != 0)
                {
                    lblOutputInfo.Items.Add("*Read attlog by period failed,ErrorCode: " + idwErrorCode.ToString());
                }
                else
                {
                    lblOutputInfo.Items.Add("No data from terminal returns!");
                }
            }

            //lblOutputInfo.Items.Add("[func ReadNewGLogData]Temporarily unsupported");
            CZKem.EnableDevice(GetMachineNumber(), true);//enable the device

            return ret;
        }
        #endregion
        #endregion
    }
}