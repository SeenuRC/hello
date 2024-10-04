<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SGConnection
#Region "Upgrade Support "
	Private Shared m_vb6FormDefInstance As SGConnection
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As SGConnection
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = CreateInstance()
				m_InitializingDefInstance = False
			End If
			Return m_vb6FormDefInstance
		End Get
		Set(ByVal Value As SGConnection)
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region
#Region "Windows Form Designer generated code "
	Public Shared Function CreateInstance() As SGConnection
		Dim theInstance As SGConnection = New SGConnection()
		Return theInstance
	End Function
	Private visualControls() As String = New String() {"components", "ToolTipMain", "CancelButton_Renamed", "OKButton", "AddressText", "Label4", "Frame2", "TCPIPCheck", "SecondaryTextGPIB", "PrimaryTextGPIB", "BoardTextGPIB", "Label3", "Label2", "Label1", "Frame1", "GPIBCheck"}
	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer
	Public ToolTipMain As System.Windows.Forms.ToolTip
	Public WithEvents CancelButton_Renamed As System.Windows.Forms.Button
	Public WithEvents OKButton As System.Windows.Forms.Button
	Public WithEvents AddressText As System.Windows.Forms.TextBox
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Frame2 As System.Windows.Forms.GroupBox
	Public WithEvents TCPIPCheck As System.Windows.Forms.CheckBox
	Public WithEvents SecondaryTextGPIB As System.Windows.Forms.TextBox
	Public WithEvents PrimaryTextGPIB As System.Windows.Forms.TextBox
	Public WithEvents BoardTextGPIB As System.Windows.Forms.TextBox
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public WithEvents GPIBCheck As System.Windows.Forms.CheckBox
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> _
	 Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTipMain = New System.Windows.Forms.ToolTip(Me.components)
        Me.CancelButton_Renamed = New System.Windows.Forms.Button()
        Me.OKButton = New System.Windows.Forms.Button()
        Me.Frame2 = New System.Windows.Forms.GroupBox()
        Me.AddressText = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TCPIPCheck = New System.Windows.Forms.CheckBox()
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.SecondaryTextGPIB = New System.Windows.Forms.TextBox()
        Me.PrimaryTextGPIB = New System.Windows.Forms.TextBox()
        Me.BoardTextGPIB = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GPIBCheck = New System.Windows.Forms.CheckBox()
        Me.Frame2.SuspendLayout()
        Me.Frame1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CancelButton_Renamed
        '
        Me.CancelButton_Renamed.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton_Renamed.Cursor = System.Windows.Forms.Cursors.Default
        Me.CancelButton_Renamed.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CancelButton_Renamed.Location = New System.Drawing.Point(180, 228)
        Me.CancelButton_Renamed.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CancelButton_Renamed.Name = "CancelButton_Renamed"
        Me.CancelButton_Renamed.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CancelButton_Renamed.Size = New System.Drawing.Size(76, 26)
        Me.CancelButton_Renamed.TabIndex = 13
        Me.CancelButton_Renamed.Text = "Cancel"
        Me.CancelButton_Renamed.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.CancelButton_Renamed.UseVisualStyleBackColor = False
        '
        'OKButton
        '
        Me.OKButton.BackColor = System.Drawing.SystemColors.Control
        Me.OKButton.Cursor = System.Windows.Forms.Cursors.Default
        Me.OKButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.OKButton.Location = New System.Drawing.Point(45, 228)
        Me.OKButton.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.OKButton.Size = New System.Drawing.Size(76, 26)
        Me.OKButton.TabIndex = 12
        Me.OKButton.Text = "OK"
        Me.OKButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.OKButton.UseVisualStyleBackColor = False
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.SystemColors.Control
        Me.Frame2.Controls.Add(Me.AddressText)
        Me.Frame2.Controls.Add(Me.Label4)
        Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame2.Location = New System.Drawing.Point(22, 138)
        Me.Frame2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(249, 75)
        Me.Frame2.TabIndex = 9
        Me.Frame2.TabStop = False
        '
        'AddressText
        '
        Me.AddressText.AcceptsReturn = True
        Me.AddressText.BackColor = System.Drawing.SystemColors.Control
        Me.AddressText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.AddressText.Enabled = False
        Me.AddressText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.AddressText.Location = New System.Drawing.Point(22, 32)
        Me.AddressText.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.AddressText.MaxLength = 0
        Me.AddressText.Name = "AddressText"
        Me.AddressText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.AddressText.Size = New System.Drawing.Size(205, 20)
        Me.AddressText.TabIndex = 10
        Me.AddressText.Text = "IP address here"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(22, 16)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(106, 18)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Address:"
        '
        'TCPIPCheck
        '
        Me.TCPIPCheck.BackColor = System.Drawing.SystemColors.Control
        Me.TCPIPCheck.Cursor = System.Windows.Forms.Cursors.Default
        Me.TCPIPCheck.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TCPIPCheck.Location = New System.Drawing.Point(22, 122)
        Me.TCPIPCheck.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TCPIPCheck.Name = "TCPIPCheck"
        Me.TCPIPCheck.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TCPIPCheck.Size = New System.Drawing.Size(128, 18)
        Me.TCPIPCheck.TabIndex = 8
        Me.TCPIPCheck.Text = "TCPIP Connection"
        Me.TCPIPCheck.UseVisualStyleBackColor = False
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.SecondaryTextGPIB)
        Me.Frame1.Controls.Add(Me.PrimaryTextGPIB)
        Me.Frame1.Controls.Add(Me.BoardTextGPIB)
        Me.Frame1.Controls.Add(Me.Label3)
        Me.Frame1.Controls.Add(Me.Label2)
        Me.Frame1.Controls.Add(Me.Label1)
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(22, 41)
        Me.Frame1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(249, 75)
        Me.Frame1.TabIndex = 1
        Me.Frame1.TabStop = False
        '
        'SecondaryTextGPIB
        '
        Me.SecondaryTextGPIB.AcceptsReturn = True
        Me.SecondaryTextGPIB.BackColor = System.Drawing.SystemColors.Window
        Me.SecondaryTextGPIB.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.SecondaryTextGPIB.ForeColor = System.Drawing.SystemColors.WindowText
        Me.SecondaryTextGPIB.Location = New System.Drawing.Point(165, 32)
        Me.SecondaryTextGPIB.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.SecondaryTextGPIB.MaxLength = 0
        Me.SecondaryTextGPIB.Name = "SecondaryTextGPIB"
        Me.SecondaryTextGPIB.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SecondaryTextGPIB.Size = New System.Drawing.Size(55, 20)
        Me.SecondaryTextGPIB.TabIndex = 4
        Me.SecondaryTextGPIB.Text = "0"
        '
        'PrimaryTextGPIB
        '
        Me.PrimaryTextGPIB.AcceptsReturn = True
        Me.PrimaryTextGPIB.BackColor = System.Drawing.SystemColors.Window
        Me.PrimaryTextGPIB.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.PrimaryTextGPIB.ForeColor = System.Drawing.SystemColors.WindowText
        Me.PrimaryTextGPIB.Location = New System.Drawing.Point(90, 32)
        Me.PrimaryTextGPIB.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.PrimaryTextGPIB.MaxLength = 0
        Me.PrimaryTextGPIB.Name = "PrimaryTextGPIB"
        Me.PrimaryTextGPIB.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PrimaryTextGPIB.Size = New System.Drawing.Size(55, 20)
        Me.PrimaryTextGPIB.TabIndex = 3
        Me.PrimaryTextGPIB.Text = "19"
        '
        'BoardTextGPIB
        '
        Me.BoardTextGPIB.AcceptsReturn = True
        Me.BoardTextGPIB.BackColor = System.Drawing.SystemColors.Window
        Me.BoardTextGPIB.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.BoardTextGPIB.ForeColor = System.Drawing.SystemColors.WindowText
        Me.BoardTextGPIB.Location = New System.Drawing.Point(22, 32)
        Me.BoardTextGPIB.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.BoardTextGPIB.MaxLength = 0
        Me.BoardTextGPIB.Name = "BoardTextGPIB"
        Me.BoardTextGPIB.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BoardTextGPIB.Size = New System.Drawing.Size(55, 20)
        Me.BoardTextGPIB.TabIndex = 2
        Me.BoardTextGPIB.Text = "0"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(165, 16)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(54, 18)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Secondary"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(90, 16)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(54, 18)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Primary"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(22, 16)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(62, 18)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Board"
        '
        'GPIBCheck
        '
        Me.GPIBCheck.BackColor = System.Drawing.SystemColors.Control
        Me.GPIBCheck.Checked = True
        Me.GPIBCheck.CheckState = System.Windows.Forms.CheckState.Checked
        Me.GPIBCheck.Cursor = System.Windows.Forms.Cursors.Default
        Me.GPIBCheck.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GPIBCheck.Location = New System.Drawing.Point(22, 16)
        Me.GPIBCheck.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GPIBCheck.Name = "GPIBCheck"
        Me.GPIBCheck.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GPIBCheck.Size = New System.Drawing.Size(128, 18)
        Me.GPIBCheck.TabIndex = 0
        Me.GPIBCheck.Text = "GPIB Connection"
        Me.GPIBCheck.UseVisualStyleBackColor = False
        '
        'SGConnection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(298, 268)
        Me.Controls.Add(Me.CancelButton_Renamed)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.Frame2)
        Me.Controls.Add(Me.TCPIPCheck)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.GPIBCheck)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Location = New System.Drawing.Point(5, 29)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "SGConnection"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Signal Generator Connection"
        Me.Frame2.ResumeLayout(False)
        Me.Frame2.PerformLayout()
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
	Sub ReLoadForm(ByVal addEvents As Boolean)
		If addEvents Then
			AddHandler MyBase.Closed, AddressOf Me.SGConnection_Closed
		End If
	End Sub
#End Region
End Class