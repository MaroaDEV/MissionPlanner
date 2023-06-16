using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Xml.Serialization;

namespace MissionPlanner.Utilities
{
    [Serializable]
    public enum DisplayNames
    {
        Basic,
        Advanced,
        Custom
    }

    public enum SeverityLevel
    {
        Emergency,
        Alert,
        Critical,
        Error,
        Warning,
        Notice,
        Info,
        Debug
    }

    [Serializable]
    public class DisplayView
    {
        public bool displayRTKInject { get; set; } = true;
        public bool displayGPSOrder { get; set; } = true;
        public bool displayHWIDs { get; set; } = true;
        public bool displayADSB { get; set; } = true;
        public DisplayNames displayName { get; set; }

        //MainV2 buttons
        public Boolean displaySimulation { get; set; }
        public Boolean displayTerminal { get; set; }
        public Boolean displayDonate { get; set; }
        public Boolean displayHelp { get; set; }

        //flight Data view
        public Boolean displayAnenometer { get; set; }
        public Boolean displayQuickTab { get; set; }
        public Boolean displayPreFlightTab { get; set; }
        public Boolean displayAdvActionsTab { get; set; }
        public Boolean displaySimpleActionsTab { get; set; }
        public Boolean displayGaugesTab { get; set; }
        public Boolean displayStatusTab { get; set; }
        public Boolean displayServoTab { get; set; }
        public Boolean displayScriptsTab { get; set; }
        public Boolean displayTelemetryTab { get; set; }
        public Boolean displayDataflashTab { get; set; }
        public Boolean displayMessagesTab { get; set; }

        //flight plan
        public Boolean displayRallyPointsMenu { get; set; }
        public Boolean displayGeoFenceMenu { get; set; }
        public Boolean displaySplineCircleAutoWp { get; set; }
        public Boolean displayTextAutoWp { get; set; }
        public Boolean displayCircleSurveyAutoWp { get; set; }
        public Boolean displayPoiMenu { get; set; }
        public Boolean displayTrackerHomeMenu { get; set; }
        public Boolean displayCheckHeightBox { get; set; }
        public Boolean displayPluginAutoWp { get; set; }

        //initial setup
        public Boolean displayInstallFirmware { get; set; }
        public Boolean displayWizard { get; set; }
        public Boolean displayFrameType { get; set; }
        public Boolean displayAccelCalibration { get; set; }
        public Boolean displayCompassConfiguration { get; set; }
        public Boolean displayRadioCalibration { get; set; }
        public Boolean displayEscCalibration { get; set; }
        public Boolean displayFlightModes { get; set; }
        public Boolean displayFailSafe { get; set; }
        public Boolean displaySikRadio { get; set; }
        public Boolean displayBattMonitor { get; set; }
        public Boolean displayCAN { get; set; }
        public Boolean displayCompassMotorCalib { get; set; }
        public Boolean displayRangeFinder { get; set; }
        public Boolean displayAirSpeed { get; set; }
        public Boolean displayPx4Flow { get; set; }
        public Boolean displayOpticalFlow { get; set; }
        public Boolean displayOsd { get; set; }
        public Boolean displayCameraGimbal { get; set; }
        public Boolean displayMotorTest { get; set; }
        public Boolean displayBluetooth { get; set; }
        public Boolean displayParachute { get; set; }
        public Boolean displayEsp { get; set; }
        public Boolean displayAntennaTracker { get; set; }


        //config tuning
        public Boolean displayBasicTuning { get; set; }
        public Boolean displayExtendedTuning { get; set; }
        public Boolean displayStandardParams { get; set; }
        public Boolean displayAdvancedParams { get; set; }
        public Boolean displayFullParamList { get; set; }
        public Boolean displayFullParamTree { get; set; }
        public Boolean displayParamCommitButton { get; set; }
        public Boolean displayBaudCMB { get; set; }
        public Boolean displaySerialPortCMB { get; set; }
        public Boolean standardFlightModesOnly { get; set; }
        public Boolean autoHideMenuForce { get; set; }
        public Boolean displayInitialParams { get; set; }
        public bool isAdvancedMode { get; set; }
        public bool displayServoOutput { get; set; } = false;
        public bool displayJoystick { get; set; } = false;
        public bool displayOSD { get; set; } = false;
        public bool displayUserParam { get; set; } = false;
        public bool displayPlannerSettings { get; set; } = false;
        public bool displayFFTSetup { get; set; } = false;
        public bool displayPreFlightTabEdit { get; set; } = false;
        public bool displayPlannerLayout { get; set; } = false;

        public bool lockQuickView { get; set; } = false;

        public DisplayView()
        {
            // default to basic.
            //also when a new field is added/created this defines the template for missing options
            displayName = DisplayNames.Basic;
            

            //MainV2 buttons
            displaySimulation = false;
            displayTerminal = false;
            displayDonate = false;
            displayHelp = true;

            //flight Data view
            displayAnenometer = false;
            displayQuickTab = false;
            displayPreFlightTab = false;
            displayAdvActionsTab = false;
            displaySimpleActionsTab = false;
            displayGaugesTab = false;
            displayStatusTab = false;
            displayServoTab = false;
            displayScriptsTab = false;
            displayTelemetryTab = false;
            displayDataflashTab = false;
            displayMessagesTab = false;

            //flight plan
            displayRallyPointsMenu = false;
            displayGeoFenceMenu = false;
            displaySplineCircleAutoWp = false;
            displayTextAutoWp = false;
            displayCircleSurveyAutoWp = false;
            displayPoiMenu = false;
            displayTrackerHomeMenu = false;
            displayCheckHeightBox = false;
            displayPluginAutoWp = false;

            //initial setup
            displayInstallFirmware = false;
            displayInitialParams = false;
            displayWizard = false;
            displayFrameType = false;
            displayAccelCalibration = false;
            displayCompassConfiguration = false;
            displayRadioCalibration = false;
            displayServoOutput = false;
            displayEscCalibration = false;
            displayFlightModes = false;
            displayFailSafe = false;
            displaySikRadio = false;
            displayBattMonitor = false;
            displayCAN = false;
            displayCompassMotorCalib = false;
            displayRangeFinder = false;
            displayAirSpeed = false;
            displayPx4Flow = false;
            displayOpticalFlow = false;
            displayOsd = false;
            displayCameraGimbal = false;
            displayMotorTest = false;
            displayBluetooth = false;
            displayParachute = false;
            displayEsp = false;
            displayAntennaTracker = false;
            displayRTKInject = false;
            displayJoystick = false;


            //config tuning
            displayBasicTuning = true;
            displayExtendedTuning = true;
            displayStandardParams = true;
            displayAdvancedParams = false;
            displayFullParamList = false;
            displayFullParamTree = false;
            displayParamCommitButton = false;
            displayBaudCMB = false;
            standardFlightModesOnly = false;
            displaySerialPortCMB = false;
            autoHideMenuForce = false;
            displayOSD = false;
            isAdvancedMode = false;
        }
    }
    public static class DisplayViewExtensions
    {
        public static bool TryParse(string value, out DisplayView result)
        {
            result = new DisplayView();
            var serializer = new XmlSerializer(result.GetType());

            using (TextReader reader = new StringReader(value))
            {
                if (!value.StartsWith("{"))
                {
                    try
                    {
                        result = (DisplayView) serializer.Deserialize(reader);
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }

                try
                {
                    result = value.FromJSON<DisplayView>();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public static string ConvertToString(this DisplayView v)
        {
            return v.ToJSON();

            XmlSerializer xmlSerializer = new XmlSerializer(v.GetType());
            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, v);
                return textWriter.ToString();
            }
        }
        public static DisplayView Basic(this DisplayView v)
        {
            return new DisplayView()
            {
                displayName = DisplayNames.Basic,
                //MainV2 buttons
                displaySimulation = false,
                displayTerminal = false,
                displayDonate = true,
                displayHelp = true,

                //flight Data view
                displayAnenometer = false,
                displayQuickTab = false,
                displayPreFlightTab = false,
                displayAdvActionsTab = false,
                displaySimpleActionsTab = false,
                displayGaugesTab = false,
                displayStatusTab = false,
                displayServoTab = false,
                displayScriptsTab = false,
                displayTelemetryTab = false,
                displayDataflashTab = false,
                displayMessagesTab = false,

                //flight plan
                displayRallyPointsMenu = false,
                displayGeoFenceMenu = false,
                displaySplineCircleAutoWp = false,
                displayCircleSurveyAutoWp = false,
                displayTextAutoWp = false,
                displayPoiMenu = false,
                displayTrackerHomeMenu = false,
                displayCheckHeightBox = false,
                displayPluginAutoWp = false,

                //initial setup
                displayInstallFirmware = false,
                displayWizard = false,
                displayFrameType = false,
                displayAccelCalibration = false,
                displayCompassConfiguration = false,
                displayRadioCalibration = false,
                displayServoOutput = false,
                displayEscCalibration = false,
                displayFlightModes = false,
                displayFailSafe = false,
                displaySikRadio = false,
                displayBattMonitor = false,
                displayCAN = false,
                displayCompassMotorCalib = false,
                displayRangeFinder = false,
                displayAirSpeed = false,
                displayPx4Flow = false,
                displayOpticalFlow = false,
                displayOsd = false,
                displayCameraGimbal = false,
                displayMotorTest = false,
                displayBluetooth = false,
                displayParachute = false,
                displayEsp = false,
                displayAntennaTracker = false,
                displayRTKInject = false,
                displayJoystick = false,


                 //config tuning
                displayBasicTuning = false,
                displayExtendedTuning = false,
                displayStandardParams = false,
                displayAdvancedParams = false,
                displayFullParamList = false,
                displayFullParamTree = false,
                displayParamCommitButton = false,
                displayBaudCMB = false,
                displaySerialPortCMB = false,
                displayOSD = false,
                standardFlightModesOnly = false,
                autoHideMenuForce = false,
                isAdvancedMode = false
            };
        }
        public static DisplayView Advanced(this DisplayView v)
        {
            return new DisplayView()
            {
                displayName = DisplayNames.Advanced,
                //MainV2 buttons
                displaySimulation = false,
                displayTerminal = false,
                displayDonate = false,
                displayHelp = true,

                //flight Data view
                displayAnenometer = false,
                displayQuickTab = false,
                displayPreFlightTab = false,
                displayAdvActionsTab = false,
                displaySimpleActionsTab = false,
                displayGaugesTab = false,
                displayStatusTab = false,
                displayServoTab = false,
                displayScriptsTab = false,
                displayTelemetryTab = false,
                displayDataflashTab = false,
                displayMessagesTab = false,

                //flight plan
                displayRallyPointsMenu = false,
                displayGeoFenceMenu = false,
                displaySplineCircleAutoWp = false,
                displayTextAutoWp = false,
                displayCircleSurveyAutoWp = false,
                displayPoiMenu = false,
                displayTrackerHomeMenu = false,
                displayCheckHeightBox = false,
                displayPluginAutoWp = false,

                //initial setup
                displayInstallFirmware = false,
                displayWizard = false,
                displayFrameType = false,
                displayAccelCalibration = false,
                displayCompassConfiguration = false,
                displayRadioCalibration = false,
                displayServoOutput = false,
                displayEscCalibration = false,
                displayFlightModes = false,
                displayFailSafe = false,
                displaySikRadio = false,
                displayBattMonitor = false,
                displayCAN = false,
                displayCompassMotorCalib = false,
                displayRangeFinder = false,
                displayAirSpeed = false,
                displayPx4Flow = false,
                displayOpticalFlow = false,
                displayOsd = false,
                displayCameraGimbal = false,
                displayMotorTest = false,
                displayBluetooth = false,
                displayParachute = false,
                displayEsp = false,
                displayAntennaTracker = false,
                displayRTKInject = false,
                displayJoystick = false,


                //config tuning
                displayBasicTuning = false,
                displayExtendedTuning = false,
                displayStandardParams = false,
                displayAdvancedParams = false,
                displayFullParamList = false,
                displayFullParamTree = false,
                displayParamCommitButton = false,
                displayBaudCMB = false,
                displaySerialPortCMB = false,
                standardFlightModesOnly =  false,
                displayOSD = false,
                autoHideMenuForce = false,
                isAdvancedMode = true
            };
        }

        public static string custompath = Settings.GetRunningDirectory() + Path.DirectorySeparatorChar + "custom.displayview";

        public static DisplayView Custom(this DisplayView v)
        {
            var result = new DisplayView().Advanced();

            if (File.Exists(custompath) && TryParse(File.ReadAllText(custompath), out result))
            {
                result.displayName = DisplayNames.Custom;
                return result;
            }

            return result;
        }
    }
}
