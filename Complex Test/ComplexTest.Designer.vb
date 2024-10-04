<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
#Region "Upgrade Support "
	Private Shared m_vb6FormDefInstance As frmMain
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As frmMain
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = CreateInstance()
				m_InitializingDefInstance = False
			End If
			Return m_vb6FormDefInstance
		End Get
		Set(ByVal Value As frmMain)
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region
#Region "Windows Form Designer generated code "
	Public Shared Function CreateInstance() As frmMain
		Dim theInstance As frmMain = New frmMain()
		theInstance.Form_Load()
		Return theInstance
	End Function
	Private visualControls() As String = New String() {"components", "ToolTipMain", "chkSaveFile", "chkCorrections", "cmdRun", "ConnectSA", "Frame2", "ConnectSG", "Frame1", "lblTitle"}
	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer
	Public ToolTipMain As System.Windows.Forms.ToolTip
	Public WithEvents chkSaveFile As System.Windows.Forms.CheckBox
	Public WithEvents chkCorrections As System.Windows.Forms.CheckBox
	Public WithEvents cmdRun As System.Windows.Forms.Button
	Public WithEvents ConnectSA As System.Windows.Forms.Button
	Public WithEvents Frame2 As System.Windows.Forms.GroupBox
	Public WithEvents ConnectSG As System.Windows.Forms.Button
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public WithEvents lblTitle As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> _
	 Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
		Me.ToolTipMain = New System.Windows.Forms.ToolTip(Me.components)
		Me.chkSaveFile = New System.Windows.Forms.CheckBox()
		Me.chkCorrections = New System.Windows.Forms.CheckBox()
		Me.cmdRun = New System.Windows.Forms.Button()
		Me.Frame2 = New System.Windows.Forms.GroupBox()
		Me.ConnectSA = New System.Windows.Forms.Button()
		Me.Frame1 = New System.Windows.Forms.GroupBox()
		Me.ConnectSG = New System.Windows.Forms.Button()
		Me.lblTitle = New System.Windows.Forms.Label()
		Me.Frame2.SuspendLayout()
		Me.Frame1.SuspendLayout()
		Me.SuspendLayout()
		' 
		'chkSaveFile
		' 
		Me.chkSaveFile.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkSaveFile.BackColor = System.Drawing.SystemColors.Control
		Me.chkSaveFile.CausesValidation = True
		Me.chkSaveFile.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkSaveFile.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkSaveFile.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkSaveFile.Enabled = True
		Me.chkSaveFile.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkSaveFile.Location = New System.Drawing.Point(10, 270)
		Me.chkSaveFile.Name = "chkSaveFile"
		Me.chkSaveFile.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkSaveFile.Size = New System.Drawing.Size(302, 42)
		Me.chkSaveFile.TabIndex = 7
		Me.chkSaveFile.TabStop = True
		Me.chkSaveFile.Text = "Save File (save .pbp file to PC) "
		Me.chkSaveFile.Visible = True
		' 
		'chkCorrections
		' 
		Me.chkCorrections.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkCorrections.BackColor = System.Drawing.SystemColors.Control
		Me.chkCorrections.CausesValidation = True
		Me.chkCorrections.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkCorrections.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkCorrections.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkCorrections.Enabled = True
		Me.chkCorrections.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkCorrections.Location = New System.Drawing.Point(10, 240)
		Me.chkCorrections.Name = "chkCorrections"
		Me.chkCorrections.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkCorrections.Size = New System.Drawing.Size(302, 32)
		Me.chkCorrections.TabIndex = 6
		Me.chkCorrections.TabStop = True
		Me.chkCorrections.Text = "Apply Corrections (requires Spectrum Analyzer) "
		Me.chkCorrections.Visible = True
		' 
		'cmdRun
		' 
		Me.cmdRun.BackColor = System.Drawing.SystemColors.Control
		Me.cmdRun.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdRun.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
		Me.cmdRun.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdRun.Location = New System.Drawing.Point(10, 330)
		Me.cmdRun.Name = "cmdRun"
		Me.cmdRun.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdRun.Size = New System.Drawing.Size(298, 50)
		Me.cmdRun.TabIndex = 4
		Me.cmdRun.Text = "Download and Play"
		Me.cmdRun.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
		Me.cmdRun.UseVisualStyleBackColor = False
		' 
		'Frame2
		' 
		Me.Frame2.BackColor = System.Drawing.SystemColors.Control
		Me.Frame2.Controls.Add(Me.ConnectSA)
		Me.Frame2.Enabled = True
		Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame2.Location = New System.Drawing.Point(10, 140)
		Me.Frame2.Name = "Frame2"
		Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame2.Size = New System.Drawing.Size(302, 82)
		Me.Frame2.TabIndex = 2
		Me.Frame2.Text = "Spectrum Analyzer Configuration"
		Me.Frame2.Visible = True
		' 
		'ConnectSA
		' 
		Me.ConnectSA.BackColor = System.Drawing.SystemColors.Control
		Me.ConnectSA.Cursor = System.Windows.Forms.Cursors.Default
		Me.ConnectSA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
		Me.ConnectSA.ForeColor = System.Drawing.SystemColors.ControlText
		Me.ConnectSA.Location = New System.Drawing.Point(20, 30)
		Me.ConnectSA.Name = "ConnectSA"
		Me.ConnectSA.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ConnectSA.Size = New System.Drawing.Size(92, 32)
		Me.ConnectSA.TabIndex = 3
		Me.ConnectSA.Text = "Connect..."
		Me.ConnectSA.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
		Me.ConnectSA.UseVisualStyleBackColor = False
		' 
		'Frame1
		' 
		Me.Frame1.BackColor = System.Drawing.SystemColors.Control
		Me.Frame1.Controls.Add(Me.ConnectSG)
		Me.Frame1.Enabled = True
		Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame1.Location = New System.Drawing.Point(10, 50)
		Me.Frame1.Name = "Frame1"
		Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame1.Size = New System.Drawing.Size(302, 82)
		Me.Frame1.TabIndex = 0
		Me.Frame1.Text = "Signal Generator Configuration"
		Me.Frame1.Visible = True
		' 
		'ConnectSG
		' 
		Me.ConnectSG.BackColor = System.Drawing.SystemColors.Control
		Me.ConnectSG.Cursor = System.Windows.Forms.Cursors.Default
		Me.ConnectSG.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
		Me.ConnectSG.ForeColor = System.Drawing.SystemColors.ControlText
		Me.ConnectSG.Location = New System.Drawing.Point(20, 30)
		Me.ConnectSG.Name = "ConnectSG"
		Me.ConnectSG.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ConnectSG.Size = New System.Drawing.Size(92, 32)
		Me.ConnectSG.TabIndex = 1
		Me.ConnectSG.Text = "Connect..."
		Me.ConnectSG.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
		Me.ConnectSG.UseVisualStyleBackColor = False
		' 
		'lblTitle
		' 
		Me.lblTitle.BackColor = System.Drawing.SystemColors.Control
		Me.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblTitle.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
		Me.lblTitle.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblTitle.Location = New System.Drawing.Point(10, 10)
		Me.lblTitle.Name = "lblTitle"
		Me.lblTitle.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblTitle.Size = New System.Drawing.Size(312, 22)
		Me.lblTitle.TabIndex = 5
		Me.lblTitle.Text = "Complex Test Program Example"
		' 
		'frmMain
		' 
		Me.AutoScaleDimensions = New System.Drawing.SizeF(8, 16)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.ClientSize = New System.Drawing.Size(445, 399)
		Me.Controls.Add(Me.chkSaveFile)
		Me.Controls.Add(Me.chkCorrections)
		Me.Controls.Add(Me.cmdRun)
		Me.Controls.Add(Me.Frame2)
		Me.Controls.Add(Me.Frame1)
		Me.Controls.Add(Me.lblTitle)
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.Location = New System.Drawing.Point(5, 29)
		Me.MaximizeBox = True
		Me.MinimizeBox = True
		Me.Name = "frmMain"
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Text = "Signal Studio for Pulse Building"
		Me.Frame2.ResumeLayout(False)
		Me.Frame1.ResumeLayout(False)
		Me.ResumeLayout(False)
	End Sub
	Sub ReLoadForm(ByVal addEvents As Boolean)
		Form_Load()
	End Sub
#End Region
End Class