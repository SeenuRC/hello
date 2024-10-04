Option Strict Off
Option Explicit On
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Partial Friend Class SGConnection
	Inherits System.Windows.Forms.Form
	Public okSelected As Boolean
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
		isInitializingComponent = True
		InitializeComponent()
		isInitializingComponent = False
		ReLoadForm(False)
	End Sub



	Private Sub CancelButton_Renamed_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles CancelButton_Renamed.Click
		Me.Hide()
		SAConnection.DefInstance.Cursor = Cursors.Default
		okSelected = False
	End Sub

	Private isInitializingComponent As Boolean
	Private Sub GPIBCheck_CheckStateChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles GPIBCheck.CheckStateChanged
		If isInitializingComponent Then
			Exit Sub
		End If
		' For GPIB connection
		SAConnection.DefInstance.Cursor = Cursors.WaitCursor
		If GPIBCheck.CheckState = CheckState.Checked Then
			TCPIPCheck.CheckState = CheckState.Unchecked
			' Disable TCPIP address text box
			AddressText.Enabled = False
			AddressText.BackColor = SystemColors.Control
			' Enable GPIB board, primary, and secondary text boxes
			BoardTextGPIB.Enabled = True
			BoardTextGPIB.BackColor = SystemColors.Window
			PrimaryTextGPIB.Enabled = True
			PrimaryTextGPIB.BackColor = SystemColors.Window
			SecondaryTextGPIB.Enabled = True
			SecondaryTextGPIB.BackColor = SystemColors.Window
		End If
		SAConnection.DefInstance.Cursor = Cursors.Default
	End Sub

	Private Sub OKButton_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles OKButton.Click
		SAConnection.DefInstance.Cursor = Cursors.WaitCursor
		If GPIBCheck.CheckState = CheckState.Checked Then
			If BoardTextGPIB.Text = "" Then
				BoardTextGPIB.Text = CStr(0)
			ElseIf PrimaryTextGPIB.Text = "" Then 
				PrimaryTextGPIB.Text = CStr(18)
			ElseIf SecondaryTextGPIB.Text = "" Then 
				SecondaryTextGPIB.Text = CStr(0)
			End If
		End If

		If TCPIPCheck.CheckState = CheckState.Checked Then
			If AddressText.Text = "" Then
				AddressText.Text = " "
			End If
		End If

		Me.Hide()
		SAConnection.DefInstance.Cursor = Cursors.Default
		okSelected = True
	End Sub

	Private Sub TCPIPCheck_CheckStateChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles TCPIPCheck.CheckStateChanged
		If isInitializingComponent Then
			Exit Sub
		End If
		' For TCPIP connection
		SAConnection.DefInstance.Cursor = Cursors.WaitCursor
		If TCPIPCheck.CheckState = CheckState.Checked Then
			GPIBCheck.CheckState = CheckState.Unchecked
			' Disable GPIB board, primary, and secondary text boxes
			BoardTextGPIB.Enabled = False
			BoardTextGPIB.BackColor = SystemColors.Control
			PrimaryTextGPIB.Enabled = False
			PrimaryTextGPIB.BackColor = SystemColors.Control
			SecondaryTextGPIB.Enabled = False
			SecondaryTextGPIB.BackColor = SystemColors.Control
			' Enable TCPIP address text box
			AddressText.Enabled = True
			AddressText.BackColor = SystemColors.Window
		End If
		SAConnection.DefInstance.Cursor = Cursors.Default
	End Sub
	Private Sub SGConnection_Closed(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Closed
	End Sub
End Class