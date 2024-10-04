Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.Compatibility.VB6
Imports System
Imports System.Windows.Forms
Imports CCWAPI


Partial Friend Class frmMain
	Inherits System.Windows.Forms.Form
    Dim project As AgtPBProject
    Dim cw1 As AgtPBPulse
    Dim cw2 As AgtPBPulse
    Dim cw3 As AgtPBPulse
    Dim BarkerA As AgtPBPulse
    Dim BarkerB As AgtPBPulse
    Dim ComplexPattern As AgtPBPattern
    Dim AgilePattern As AgtPBPattern
    Dim AgileItem As AgtPBPatternItem
    Dim DoubletPattern As AgtPBPattern
    Dim DoubletItem As AgtPBPatternItem
    Dim SensitivityPattern As AgtPBPattern
    Dim SensitivityItem As AgtPBPatternItem
    Dim ComplexItem As AgtPBPatternItem
    Dim SpectrumAnalyzer As AgtPBSpectrumAnalyzer
    Dim SignalGenerator As AgtPBSignalGenerator
    Dim IData() As Double
    Dim QData() As Double
    Dim customProfile() As Double
    Dim dataType As String = ""
    Dim SAConnected As Boolean
    Dim SGConnected As Boolean


    'UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx
    Public Sub New()
        MyBase.New()
        If m_vb6FormDefInstance Is Nothing Then
            If m_InitializingDefInstance Then
                m_vb6FormDefInstance = Me
            Else
                Try
                    'For the start-up form, the first instance created is the default instance.
                    If System.Reflection.Assembly.GetExecutingAssembly.EntryPoint.DeclaringType Is Me.GetType Then
                        m_vb6FormDefInstance = Me
                    End If

                Catch
                End Try
            End If
        End If
        'This call is required by the Windows Form Designer.
        InitializeComponent()
        ReLoadForm(False)
    End Sub


    Private Sub Form_Load()
        On Error GoTo Error_Handler ' sets up an error trap to handle errors. If an error
        'occurs in this procedure, the code execution jumps to the 'Error_Handler line label
        'and a message describing the error is generated.

        project = New AgtPBProject() ' Creates a new project by instantiating an object
        'of type AgtPBProject.

        Exit Sub

Error_Handler:
        MessageBox.Show(Information.Err().Description, Application.ProductName)
    End Sub

    Private Sub cmdRun_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cmdRun.Click

        On Error GoTo ErrorHandler

        If Not SGConnected Then
            MessageBox.Show("Connect Signal Generator", Application.ProductName, MessageBoxButtons.OK)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
        If Not SAConnected And chkCorrections.CheckState = CheckState.Checked Then
            MessageBox.Show("Connect Spectrum Analyzer", Application.ProductName, MessageBoxButtons.OK)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If


        Me.Cursor = Cursors.WaitCursor ' Use the hourglass mouse pointer to indicate program activity
        cmdRun.Enabled = False ' Disable the Download and Play button until this process has finished

        ' Counter variable
        Dim powerScale As Integer ' Variable to indicate the power scale setting

        project.NewProject("Complex Test.pbp") ' Create a new .pbp project
        cw1 = project.PulseLibrary.CreateNewPulse("CW1") ' Instanatiate a new pulse
        'cw1.PulseType = AgtPBPulseType_Trapezoidal ' Set the pulse type to Trapezoidal
        cw1.PulseType = AgtPBPulseType.Trapezoidal ' Set the pulse type to Trapezoidal
        ' The next line of code sets the rise time of the pulse to 30 ns, the fall time to 30 ns, 100% to 100% to
        ' 940 ns, the width jitter type to none, and the jitter deviation to 0 seconds
        cw1.SetEnvelopeTrapezoidal(0.00000003, 0.00000003, 0.00000094, AgtPBJitterType.None, 0)

        cw1.ModulationType = AgtPBModulationType.None ' Set the modulation type to FM Chirp

        dataType = "IQ" 'Variable to identify the IQ data text file
        ReadDataASCIIFile(IData, QData, customProfile, dataType) ' Read pulse data from a text file

        cw2 = project.PulseLibrary.CreateNewPulse("CW2") 'Instantiate a new pulse
        cw2.PulseType = AgtPBPulseType.CustomIQ 'Set the pulse type to CustomIQ
        ' Set the sampling rate to 100 MHz, and use the I and Q data from the text file as the pulse data
        cw2.SetCustomIQ(100000000, IData, QData)

        cw2.ModulationType = AgtPBModulationType.None ' Set the modulation type to none

        cw3 = project.PulseLibrary.CreateNewPulse("CW3") ' Create a new pulse called CW3
        cw3.PulseType = AgtPBPulseType.CustomEnvelope 'Set the pulse type to custom profile

        dataType = "Custom" 'Variable to identify the custom profile data text file
        ReadDataASCIIFile(IData, QData, customProfile, dataType) ' Read pulse data from a text file
        ' Set the sampling rate to 100 MHz, and use the customProfile data to create the CW3 Custom Profile Pulse
        cw3.SetEnvelopeCustom(100000000, customProfile)

        ' Instantiate a Frequency Agile Pulse Pattern
        AgilePattern = project.PatternLibrary.CreateNewPattern("Frequency Agile")

        ' Adding the trapezoidal pulse (CW1) as the first pattern item (0)
        AgileItem = AgilePattern.CreateNewItemAt(AgtPBPatternItemObjectType.Pulse, "CW1", 0)
        ' The following code statements set up the pattern item parameters
        AgileItem.RepetitionIntervalSec = 0.00000333 'Set CW1 to a 3 us repetition interval
        AgileItem.NumberOfRepeats = 1 ' CW1 is repeated twice; the duration is 6 us
        AgileItem.EdgeJitterType = AgtPBJitterType.None ' No jitter is applied to CW1
        AgileItem.JitterDeviationSec = 0 ' No jitter applied so there is no jitter deviation
        AgileItem.RelativePowerScaleDB = 0 ' The item's signal generator RF power level is not changed
        AgileItem.FrequencyOffsetHz = -10000000 ' The signal generator frequency is decreased by 10 MHz
        AgileItem.PhaseOffsetRad = 0 ' No phase offset

        ' Adding the custom I/Q pulse (CW2) as the second pattern item
        AgileItem = AgilePattern.CreateNewItemAt(AgtPBPatternItemObjectType.Pulse, "CW2", 1)
        ' The following code statements set up the pattern item parameters
        AgileItem.RepetitionIntervalSec = 0.00000333 'Set CW1 to a 3 us repetition interval
        AgileItem.NumberOfRepeats = 1 ' Repeat CW2 1 time. The duration of this item with the repeats is 120 us
        AgileItem.EdgeJitterType = AgtPBJitterType.None ' Set jitter type to gaussian
        AgileItem.JitterDeviationSec = 0 ' Set the deviation to 100 ns
        AgileItem.RelativePowerScaleDB = 0 ' The item's signal generator RF power level is not changed
        AgileItem.FrequencyOffsetHz = 0 ' No frequency offset
        AgileItem.PhaseOffsetRad = 0 ' No phase offset applied

        ' Adding the custom envelope pulse (CW3) as the third pattern item
        AgileItem = AgilePattern.CreateNewItemAt(AgtPBPatternItemObjectType.Pulse, "CW3", 2)
        ' The following code statements set up the pattern item parameters
        AgileItem.RepetitionIntervalSec = 0.00000333 'Set CW3 to a 10 us repetition interval
        AgileItem.NumberOfRepeats = 1 ' Repeat CW3 1 time. The duration of this item with the repeats is 200 us
        AgileItem.EdgeJitterType = AgtPBJitterType.None ' No jitter is applied to CW3
        AgileItem.JitterDeviationSec = 0 ' No jitter applied so there is no jitter deviation
        AgileItem.RelativePowerScaleDB = 0 ' No power scale offset
        AgileItem.FrequencyOffsetHz = 10000000 ' The signal generator's frequency is increased 10 MHz
        AgileItem.PhaseOffsetRad = 0 ' No phase offset applied

        ' Adding the trapezoidal pulse (CW1) as the 4th pattern item
        AgileItem = AgilePattern.CreateNewItemAt(AgtPBPatternItemObjectType.Pulse, "CW1", 3)
        ' The following code statements set up the pattern item parameters
        AgileItem.RepetitionIntervalSec = 0.00000333 'Set CW3 to a 10 us repetition interval
        AgileItem.NumberOfRepeats = 1 ' Repeat CW1 1 time. The duration of this item with the repeats is 200 us
        AgileItem.EdgeJitterType = AgtPBJitterType.None ' No jitter is applied to CW3
        AgileItem.JitterDeviationSec = 0 ' No jitter applied so there is no jitter deviation
        AgileItem.RelativePowerScaleDB = 0 ' No power scale offset
        AgileItem.FrequencyOffsetHz = -10000000 ' -10 MHz frequency offset applied
        AgileItem.PhaseOffsetRad = 1.047 ' 1.047 radians phase offset applied

        ' Adding the custom IQ pulse (CW2) as the 5th pattern item
        AgileItem = AgilePattern.CreateNewItemAt(AgtPBPatternItemObjectType.Pulse, "CW2", 4)
        ' The following code statements set up the pattern item parameters
        AgileItem.RepetitionIntervalSec = 0.00000333 'Set CW3 to a 10 us repetition interval
        AgileItem.NumberOfRepeats = 1 ' Repeat CW1 1 time. The duration of this item with the repeats is 200 us
        AgileItem.EdgeJitterType = AgtPBJitterType.None ' No jitter is applied to CW3
        AgileItem.JitterDeviationSec = 0 ' No jitter applied so there is no jitter deviation
        AgileItem.RelativePowerScaleDB = 0 ' No power scale offset
        AgileItem.FrequencyOffsetHz = 0 ' No frequency offset applied
        AgileItem.PhaseOffsetRad = 1.047 ' 1.047 radians phase offset applied

        ' Adding the custom envelope pulse (CW3) as the 6th pattern item
        AgileItem = AgilePattern.CreateNewItemAt(AgtPBPatternItemObjectType.Pulse, "CW3", 5)
        ' The following code statements set up the pattern item parameters
        AgileItem.RepetitionIntervalSec = 0.00000333 'Set CW3 to a 10 us repetition interval
        AgileItem.NumberOfRepeats = 1 ' Repeat CW1 1 time. The duration of this item with the repeats is 200 us
        AgileItem.EdgeJitterType = AgtPBJitterType.None ' No jitter is applied to CW3
        AgileItem.JitterDeviationSec = 0 ' No jitter applied so there is no jitter deviation
        AgileItem.RelativePowerScaleDB = 0 ' No power scale offset
        AgileItem.FrequencyOffsetHz = 10000000 ' 10 MHz frequency offset applied
        AgileItem.PhaseOffsetRad = 1.047 ' 1.047 radians phase offset applied

        ' Adding the trapezoidal pulse (CW1) as the 7th pattern item
        AgileItem = AgilePattern.CreateNewItemAt(AgtPBPatternItemObjectType.Pulse, "CW1", 6)
        ' The following code statements set up the pattern item parameters
        AgileItem.RepetitionIntervalSec = 0.00000333 'Set CW3 to a 10 us repetition interval
        AgileItem.NumberOfRepeats = 1 ' Repeat CW1 1 time. The duration of this item with the repeats is 200 us
        AgileItem.EdgeJitterType = AgtPBJitterType.None ' No jitter is applied to CW3
        AgileItem.JitterDeviationSec = 0 ' No jitter applied so there is no jitter deviation
        AgileItem.RelativePowerScaleDB = 0 ' No power scale offset
        AgileItem.FrequencyOffsetHz = -10000000 ' -10 MHz frequency offset applied
        AgileItem.PhaseOffsetRad = 2.093 ' 2.093 radians phase offset applied

        ' Adding the custom IQ pulse (CW2) as the 8th pattern item
        AgileItem = AgilePattern.CreateNewItemAt(AgtPBPatternItemObjectType.Pulse, "CW2", 7)
        ' The following code statements set up the pattern item parameters
        AgileItem.RepetitionIntervalSec = 0.00000333 'Set CW3 to a 10 us repetition interval
        AgileItem.NumberOfRepeats = 1 ' Repeat CW1 1 time. The duration of this item with the repeats is 200 us
        AgileItem.EdgeJitterType = AgtPBJitterType.None ' No jitter is applied to CW3
        AgileItem.JitterDeviationSec = 0 ' No jitter applied so there is no jitter deviation
        AgileItem.RelativePowerScaleDB = 0 ' No power scale offset
        AgileItem.FrequencyOffsetHz = 0 ' No frequency offset applied
        AgileItem.PhaseOffsetRad = 2.093 ' 2.093 radians phase offset applied

        ' Adding the custom envelope pulse (CW3) as the 9th pattern item
        AgileItem = AgilePattern.CreateNewItemAt(AgtPBPatternItemObjectType.Pulse, "CW3", 8)
        ' The following code statements set up the pattern item parameters
        AgileItem.RepetitionIntervalSec = 0.00000333 'Set CW3 to a 10 us repetition interval
        AgileItem.NumberOfRepeats = 1 ' Repeat CW1 1 time. The duration of this item with the repeats is 200 us
        AgileItem.EdgeJitterType = AgtPBJitterType.None ' No jitter is applied to CW3
        AgileItem.JitterDeviationSec = 0 ' No jitter applied so there is no jitter deviation
        AgileItem.RelativePowerScaleDB = 0 ' No power scale offset
        AgileItem.FrequencyOffsetHz = 10000000 ' 10 MHz frequency offset applied
        AgileItem.PhaseOffsetRad = 2.093 ' 2.093 radians phase offset applied


        ' Instantiating a new pulse
        BarkerA = project.PulseLibrary.CreateNewPulse("BarkerA")
        BarkerA.PulseType = AgtPBPulseType.RaisedCosine ' Setting the pulse type to raised cosine

        ' Set the rise time to 100 ns, the fall time to 100 ns, 100% to 100% to 800 ns, the width jitter type to
        ' none, and the jitter deviation to 0 seconds
        BarkerA.SetEnvelopeRaisedCosine(0.0000001, 0.0000001, 0.0000008, AgtPBJitterType.None, 0)
        BarkerA.ModulationType = AgtPBModulationType.Barker ' Select Barker code modulation for the pulse
        BarkerA.SetModulationBarker(13) ' Use Barker code number 13

        ' Instantiate a new pulse
        BarkerB = project.PulseLibrary.CreateNewPulse("BarkerB")
        BarkerB.PulseType = AgtPBPulseType.RaisedCosine ' Setting the pulse type to raised cosine

        ' Set the rise time to 100 ns, the fall time to 100 ns, 100% to 100% to 800 ns, the width jitter type to
        ' none, and the jitter deviation to 0 seconds
        BarkerB.SetEnvelopeRaisedCosine(0.0000001, 0.0000001, 0.0000008, AgtPBJitterType.None, 0)
        BarkerB.ModulationType = AgtPBModulationType.Barker ' Select Barker code modulation for the pulse
        BarkerB.SetModulationBarker(7) ' Use Barker code number 7

        'Instantiate a new pattern
        DoubletPattern = project.PatternLibrary.CreateNewPattern("Doublet")

        ' Instantiate a pattern with the raised cosine (BarkerA) as the first pattern item
        DoubletItem = DoubletPattern.CreateNewItemAt(AgtPBPatternItemObjectType.Pulse, "BarkerA", 0)
        DoubletItem.RepetitionIntervalSec = 0.000005 ' Repetition interval set for 5 us
        DoubletItem.NumberOfRepeats = 1 ' Number of repeats for the pattern item set to 1
        DoubletItem.EdgeJitterType = AgtPBJitterType.None ' No jitter selected
        DoubletItem.JitterDeviationSec = 0 ' Jitter deviation set to 0
        DoubletItem.RelativePowerScaleDB = 0 ' The item's signal generator RF power level is not changed
        DoubletItem.FrequencyOffsetHz = 0 ' Signal generator RF frequency is not changed
        DoubletItem.PhaseOffsetRad = 0 ' Signal generator RF signal phase offset is 0 degrees

        ' Instantiate a pattern with the raised cosine (BarkerB) as the second pattern item
        DoubletItem = DoubletPattern.CreateNewItemAt(AgtPBPatternItemObjectType.Pulse, "BarkerB", 1)
        DoubletItem.RepetitionIntervalSec = 0.000045 ' Repetition interval set for 45 us
        DoubletItem.NumberOfRepeats = 1 ' Number of repeats for the pattern item set to 1
        DoubletItem.EdgeJitterType = AgtPBJitterType.None ' No jitter selected
        DoubletItem.JitterDeviationSec = 0 ' Jitter deviation set to 0
        DoubletItem.RelativePowerScaleDB = -20 ' The item's power level is 20 dB less than the first item
        DoubletItem.FrequencyOffsetHz = 0 ' Signal generator frequency is not changed
        DoubletItem.PhaseOffsetRad = 0 ' Signal generator RF signal phase is 0 degrees


        ' Instantiating the Sensitivity pattern that will be used as the last item in the complex test pattern
        SensitivityPattern = project.PatternLibrary.CreateNewPattern("Sensitivity")

        ' The next section of code uses a loop to fill in the pattern items and parameters for the Sensitivity pattern
        ' Each of the Sensitivity pattern items is a Doublet pattern. The first line of code in the loop instantiates
        ' a pattern item object; SensitivityItem using the Doublet pattern and at the counter "indexItem" index position.
        'UPGRADE_ISSUE: (2068) AgtPBPatternItem object was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2068.aspx
        For indexItem As Integer = 0 To 9
            SensitivityItem = SensitivityPattern.CreateNewItemAt(AgtPBPatternItemObjectType.Pattern, "Doublet", indexItem)
            SensitivityItem.RepetitionIntervalSec = 0.00005 ' Repetition interval set for 50 us
            SensitivityItem.NumberOfRepeats = 1 ' Number of repeats for the pattern item set to 1
            SensitivityItem.EdgeJitterType = AgtPBJitterType.None ' No jitter applied
            SensitivityItem.JitterDeviationSec = 0 ' Jitter deviation set to 0
            SensitivityItem.RelativePowerScaleDB = powerScale ' Set the power scale value for this item
            SensitivityItem.FrequencyOffsetHz = 0 ' No change to signal generator RF signal
            SensitivityItem.PhaseOffsetRad = 0 ' No change to the phase of the signal generator RF signal
            If indexItem < 5 Then ' Based on the index, change the power scale value.
                powerScale -= 6
            Else
                powerScale += 6
            End If
        Next 'indexItem

        ' Instantiate a Complex Test pattern object
        ComplexPattern = project.PatternLibrary.CreateNewPattern("Complex Test")
        ' Instantiate a pattern item object using the trapezoidal pulse (cw1)(put it at index 0)
        ComplexItem = ComplexPattern.CreateNewItemAt(AgtPBPatternItemObjectType.Pulse, "CW1", 0)
        ComplexItem.RepetitionIntervalSec = 0.000005 ' Repetition interval set for 5 us
        ComplexItem.NumberOfRepeats = 2 ' Number of repeats for the pattern item set to 2
        ComplexItem.EdgeJitterType = AgtPBJitterType.None ' No jitter applied
        ComplexItem.JitterDeviationSec = 0 ' Jitter deviation set to 0
        ComplexItem.RelativePowerScaleDB = 0 ' No power scale offset from carrier
        ComplexItem.FrequencyOffsetHz = 0 ' No frequency offset from carrier
        ComplexItem.PhaseOffsetRad = 0 ' No phase offset

        ' Adding the custom I/Q pulse (cw2) as the second pattern item
        ComplexItem = ComplexPattern.CreateNewItemAt(AgtPBPatternItemObjectType.Pulse, "CW2", 1)
        ComplexItem.RepetitionIntervalSec = 0.000005 ' Repetition interval set for 5 us
        ComplexItem.NumberOfRepeats = 2 ' Number of repeats for the pattern item set to 2
        ComplexItem.EdgeJitterType = AgtPBJitterType.None ' No jitter applied
        ComplexItem.JitterDeviationSec = 0 ' Jitter deviation set to 0
        ComplexItem.RelativePowerScaleDB = 0 ' No power scale offset from carrier
        ComplexItem.FrequencyOffsetHz = 0 ' No frequency offset from carrier
        ComplexItem.PhaseOffsetRad = 0 ' No phase offset

        ' Adding the custom profile pulse (cw3)as the third pattern item. Same comments as for CW2
        ComplexItem = ComplexPattern.CreateNewItemAt(AgtPBPatternItemObjectType.Pulse, "CW3", 2)
        ComplexItem.RepetitionIntervalSec = 0.000005 ' Repetition interval set for 5 us
        ComplexItem.NumberOfRepeats = 2 ' Number of repeats for the pattern item set to 2
        ComplexItem.EdgeJitterType = AgtPBJitterType.None ' No jitter applied
        ComplexItem.JitterDeviationSec = 0 ' Jitter deviation set to 0
        ComplexItem.RelativePowerScaleDB = 0 ' No power scale offset from carrier
        ComplexItem.FrequencyOffsetHz = 0 ' No frequency offset from carrier
        ComplexItem.PhaseOffsetRad = 0 ' No phase offset

        ' Adding the raised cosine pulse (BarkerA) as the fourth pattern item. Same comments as for CW2
        ComplexItem = ComplexPattern.CreateNewItemAt(AgtPBPatternItemObjectType.Pulse, "BarkerA", 3)
        ComplexItem.RepetitionIntervalSec = 0.000005 ' Repetition interval set for 5 us
        ComplexItem.NumberOfRepeats = 1 ' Number of repeats
        ComplexItem.EdgeJitterType = AgtPBJitterType.None ' No jitter applied
        ComplexItem.JitterDeviationSec = 0 ' Jitter deviation set to 0
        ComplexItem.RelativePowerScaleDB = 0 ' No power scale offset from carrier
        ComplexItem.FrequencyOffsetHz = 0 ' No frequency offset from carrier
        ComplexItem.PhaseOffsetRad = 0 ' No phase offset

        ' Adding the raised cosine pulse (BarkerB) as the fifth pattern item. Same comments as for CW2
        ComplexItem = ComplexPattern.CreateNewItemAt(AgtPBPatternItemObjectType.Pulse, "BarkerB", 4)
        ComplexItem.RepetitionIntervalSec = 0.000005 ' Repetition interval set for 5 us
        ComplexItem.NumberOfRepeats = 1 ' Number of repeats
        ComplexItem.EdgeJitterType = AgtPBJitterType.None ' No jitter applied
        ComplexItem.JitterDeviationSec = 0 ' Jitter deviation set to 0
        ComplexItem.RelativePowerScaleDB = 0 ' No power scale offset from carrier
        ComplexItem.FrequencyOffsetHz = 0 ' No frequency offset from carrier
        ComplexItem.PhaseOffsetRad = 0 ' No phase offset

        ' Adding the Frequency Agile pattern (Agile) as the sixth pattern item.
        ComplexItem = ComplexPattern.CreateNewItemAt(AgtPBPatternItemObjectType.Pattern, "Frequency Agile", 5)
        ComplexItem.RepetitionIntervalSec = 0.0004 ' Repetition interval set for 400 us
        ComplexItem.NumberOfRepeats = 3 ' Number of repeats for the pattern item set to 3
        ComplexItem.EdgeJitterType = AgtPBJitterType.None ' No jitter applied
        ComplexItem.JitterDeviationSec = 0 ' Jitter deviation set to 0
        ComplexItem.RelativePowerScaleDB = 0 ' No power scale offset from carrier
        ComplexItem.FrequencyOffsetHz = 5000000 'The frequency of the carrier is increased by 5 MHz
        ComplexItem.PhaseOffsetRad = 0 ' No phase offset

        ' Adding the Frequency Agile pattern (Agile) as the seventh pattern item.
        ComplexItem = ComplexPattern.CreateNewItemAt(AgtPBPatternItemObjectType.Pattern, "Frequency Agile", 6)
        ComplexItem.RepetitionIntervalSec = 0.0004 ' Repetition interval set for 400 us
        ComplexItem.NumberOfRepeats = 3 ' Number of repeats for the pattern item set to 3
        ComplexItem.EdgeJitterType = AgtPBJitterType.None ' No jitter applied
        ComplexItem.JitterDeviationSec = 0 ' Jitter deviation set to 0
        ComplexItem.RelativePowerScaleDB = 0 ' No power scale offset from carrier
        ComplexItem.FrequencyOffsetHz = -5000000 'The frequency of the carrier is decreased by 5 MHz
        ComplexItem.PhaseOffsetRad = 1.57 ' The phase of the signal generator signal is shifted 90 degrees

        ' Adding the Doublet pattern (Doublet) as the eighth pattern item
        ComplexItem = ComplexPattern.CreateNewItemAt(AgtPBPatternItemObjectType.Pattern, "Doublet", 7)
        ComplexItem.RepetitionIntervalSec = 0.0001 ' Repetition interval set for 100 us
        ComplexItem.NumberOfRepeats = 4 ' Number of repeats
        ComplexItem.EdgeJitterType = AgtPBJitterType.None ' No jitter applied
        ComplexItem.JitterDeviationSec = 0 ' Jitter deviation set to 0
        ComplexItem.RelativePowerScaleDB = 0 ' No power scale offset from carrier
        ComplexItem.FrequencyOffsetHz = 0 ' No frequency offset from carrier
        ComplexItem.PhaseOffsetRad = 0 ' No phase offset


        ' Adding the Sensitivity pattern (Sensitivity) as the ninth pattern item
        ComplexItem = ComplexPattern.CreateNewItemAt(AgtPBPatternItemObjectType.Pattern, "Sensitivity", 8)
        ComplexItem.RepetitionIntervalSec = 0.001 ' Repetition interval set for 5 us
        ComplexItem.NumberOfRepeats = 5 ' Number of repeats for the pattern item set to 2
        ComplexItem.EdgeJitterType = AgtPBJitterType.None ' No jitter applied
        ComplexItem.JitterDeviationSec = 0 ' Jitter deviation set to 0
        ComplexItem.RelativePowerScaleDB = -3 ' No power scale offset from carrier
        ComplexItem.FrequencyOffsetHz = 0 ' No frequency offset from carrier
        ComplexItem.PhaseOffsetRad = 0 ' No phase offset


        ' Save the .pbp file to the PC
        If chkSaveFile.CheckState = CheckState.Checked Then
            project.SaveProject()
        End If

        ' If no spectrum analyzer then corrections must be disabled.
        project.Corrections.Enabled = Not (chkCorrections.CheckState = CheckState.Unchecked)

        ComplexPattern.Properties.FrequencyHz = 2000000000.0#
        ComplexPattern.Properties.ModAttenuationDB = 4

        project.DownloadAndPlayPattern("Complex Test") 'Download and play the signal on the signal generator
        MessageBox.Show("Signal Downloaded to Signal Generator", Application.ProductName, MessageBoxButtons.OK)
        Me.Cursor = Cursors.Default ' Use default mouse icon
        cmdRun.Enabled = True ' Re-enable the Download and Play button; the process is finished

        Exit Sub

ErrorHandler:
        Me.Cursor = Cursors.Default
        cmdRun.Enabled = True ' Re-enable the Download  and Play button because; an excerption occurred
        MessageBox.Show(Information.Err().Description, Application.ProductName, MessageBoxButtons.OK)

    End Sub




    Private Sub ConnectSA_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles ConnectSA.Click
        ' This function sets up a connection to the spectrum analyzer

        On Error GoTo IO_problem

        Me.Cursor = Cursors.WaitCursor
        VB6.ShowForm(SAConnection.DefInstance, FormShowConstants.Modal, Me)
        If SAConnection.DefInstance.okSelected Then
            SAConnected = True
            'if GPIB check box is checked, create a GPIB connection else
            'create a TCPIP connection

            If SAConnection.DefInstance.GPIBCheck.CheckState = CheckState.Checked Then
                project.SpectrumAnalyzer.SetConnectionGPIB(CInt(SAConnection.DefInstance.BoardTextGPIB.Text), CInt(SAConnection.DefInstance.PrimaryTextGPIB.Text), CInt(SAConnection.DefInstance.SecondaryTextGPIB.Text))
            Else
                project.SpectrumAnalyzer.SetConnectionTCPIP(SAConnection.DefInstance.AddressText.Text)
            End If
        End If

        Me.Cursor = Cursors.Default
        Exit Sub

IO_problem:
        Me.Cursor = Cursors.Default
        MessageBox.Show(Information.Err().Description, Application.ProductName)
    End Sub


    Private Sub ConnectSG_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles ConnectSG.Click
        ' This function sets up a connection to the signal generator

        On Error GoTo IO_problem

        Me.Cursor = Cursors.WaitCursor
        VB6.ShowForm(SGConnection.DefInstance, FormShowConstants.Modal, Me)
        If SGConnection.DefInstance.okSelected Then
            SGConnected = True
            'if GPIB check box is checked, create a GPIB connection else
            'create a TCPIP connection
            If SGConnection.DefInstance.GPIBCheck.CheckState = CheckState.Checked Then
                project.SignalGenerator.SetConnectionGPIB(CInt(SGConnection.DefInstance.BoardTextGPIB.Text), CInt(SGConnection.DefInstance.PrimaryTextGPIB.Text), CInt(SGConnection.DefInstance.SecondaryTextGPIB.Text))
            Else
                project.SignalGenerator.SetConnectionTCPIP(SGConnection.DefInstance.AddressText.Text)
            End If
        End If


        Me.Cursor = Cursors.Default
        Exit Sub

IO_problem:
        Me.Cursor = Cursors.Default
        MessageBox.Show(Information.Err().Description, Application.ProductName)
    End Sub

    Private Function ReadDataASCIIFile(ByRef IValues() As Double, ByRef QValues() As Double, ByRef customProfile() As Double, ByRef dataType As String) As Object
        Dim fso As New Scripting.FileSystemObject()
        'Try
        Dim s As String = "" ' Declare a string variable to hold each line of text data
        Dim i As Integer 'Counter variable
        Dim sArray() As String ' Declare a string array to hold the tab delimited text read from the file

        Dim textFile As Scripting.File
        Dim ts As Scripting.TextStream ' Declare a file object

        On Error GoTo FileError ' Sets up an error trap to handle errors. If an error occurs in this procedure,
        'code execution jumps to the FileError line label and a message describing the error is generated.
        ' The following code access the text data file; either IQ or Custom Profile data
        If dataType = "IQ" Then
            textFile = fso.GetFile(My.Application.Info.DirectoryPath & "\..\..\Complex IQ.txt")
        Else
            textFile = fso.GetFile(My.Application.Info.DirectoryPath & "\..\..\Complex Custom Profile.txt")
        End If


        ts = textFile.OpenAsTextStream(Scripting.IOMode.ForReading) ' Declare a file handle
        ' The following code uses a loop to read in text data from the open file
        Do While Not ts.AtEndOfStream
            s = ts.ReadLine() ' Read the current line of text data
            If dataType = "IQ" Then ' Read IQ data from tab delimited text formated file
                ReDim Preserve IValues(i) ' Redimension the I data array
                ReDim Preserve QValues(i) ' Redimension the Q data array
                sArray = s.Split(CChar(Strings.Chr(9))) ' Read the tab delimited data into sArray
                IValues(i) = CDbl(sArray(0)) ' I data at counter is set to the previously read data
                QValues(i) = CDbl(sArray(1)) ' Q data at counter is set to the previously read data
            Else
                ' Read Custom Profile data
                ReDim Preserve customProfile(i)
                customProfile(i) = CDbl(s) ' Read the single data value into the customProfile array
            End If
            i += 1 ' Increment the loop counter
        Loop

        ts.Close() ' Close the file handle

        Exit Function

        'Finally
        '    MemoryHelper.ReleaseAndCleanObject(fso)
FileError:
        MessageBox.Show(Information.Err().Description, Application.ProductName)

        'End Try

    End Function
    Protected Overrides Sub Finalize()
        project = Nothing
        cw1 = Nothing
        cw2 = Nothing
        cw3 = Nothing
        BarkerA = Nothing
        BarkerB = Nothing
        ComplexPattern = Nothing
        AgilePattern = Nothing
        AgileItem = Nothing
        DoubletPattern = Nothing
        DoubletItem = Nothing
        SensitivityPattern = Nothing
        SensitivityItem = Nothing
        ComplexItem = Nothing
        SpectrumAnalyzer = Nothing
        SignalGenerator = Nothing
    End Sub
End Class
