<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnTurnOff = New System.Windows.Forms.Button()
        Me.btnStandby = New System.Windows.Forms.Button()
        Me.btnTurnOn = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnHash = New System.Windows.Forms.Button()
        Me.tbValue = New System.Windows.Forms.TextBox()
        Me.rtbHash = New System.Windows.Forms.RichTextBox()
        Me.btnOutput = New System.Windows.Forms.Button()
        Me.btnSerializeToFile = New System.Windows.Forms.Button()
        Me.btnDeSerializeToFile = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnTurnOff
        '
        Me.btnTurnOff.Location = New System.Drawing.Point(12, 12)
        Me.btnTurnOff.Name = "btnTurnOff"
        Me.btnTurnOff.Size = New System.Drawing.Size(75, 23)
        Me.btnTurnOff.TabIndex = 0
        Me.btnTurnOff.Text = "Turn Off"
        Me.btnTurnOff.UseVisualStyleBackColor = True
        '
        'btnStandby
        '
        Me.btnStandby.Location = New System.Drawing.Point(12, 70)
        Me.btnStandby.Name = "btnStandby"
        Me.btnStandby.Size = New System.Drawing.Size(75, 23)
        Me.btnStandby.TabIndex = 1
        Me.btnStandby.Text = "Standby"
        Me.btnStandby.UseVisualStyleBackColor = True
        '
        'btnTurnOn
        '
        Me.btnTurnOn.Location = New System.Drawing.Point(12, 41)
        Me.btnTurnOn.Name = "btnTurnOn"
        Me.btnTurnOn.Size = New System.Drawing.Size(75, 23)
        Me.btnTurnOn.TabIndex = 2
        Me.btnTurnOn.Text = "Turn On"
        Me.btnTurnOn.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 99)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 44)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Lock Computer"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnHash
        '
        Me.btnHash.Location = New System.Drawing.Point(320, 41)
        Me.btnHash.Name = "btnHash"
        Me.btnHash.Size = New System.Drawing.Size(75, 22)
        Me.btnHash.TabIndex = 4
        Me.btnHash.Text = "Hash"
        Me.btnHash.UseVisualStyleBackColor = True
        '
        'tbValue
        '
        Me.tbValue.Location = New System.Drawing.Point(93, 43)
        Me.tbValue.Name = "tbValue"
        Me.tbValue.Size = New System.Drawing.Size(221, 20)
        Me.tbValue.TabIndex = 5
        '
        'rtbHash
        '
        Me.rtbHash.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbHash.Location = New System.Drawing.Point(93, 70)
        Me.rtbHash.Name = "rtbHash"
        Me.rtbHash.Size = New System.Drawing.Size(334, 299)
        Me.rtbHash.TabIndex = 6
        Me.rtbHash.Text = ""
        '
        'btnOutput
        '
        Me.btnOutput.Location = New System.Drawing.Point(93, 12)
        Me.btnOutput.Name = "btnOutput"
        Me.btnOutput.Size = New System.Drawing.Size(75, 23)
        Me.btnOutput.TabIndex = 7
        Me.btnOutput.Text = "Output"
        Me.btnOutput.UseVisualStyleBackColor = True
        '
        'btnSerializeToFile
        '
        Me.btnSerializeToFile.Location = New System.Drawing.Point(174, 12)
        Me.btnSerializeToFile.Name = "btnSerializeToFile"
        Me.btnSerializeToFile.Size = New System.Drawing.Size(98, 23)
        Me.btnSerializeToFile.TabIndex = 8
        Me.btnSerializeToFile.Text = "SerializeToFile"
        Me.btnSerializeToFile.UseVisualStyleBackColor = True
        '
        'btnDeSerializeToFile
        '
        Me.btnDeSerializeToFile.Location = New System.Drawing.Point(278, 12)
        Me.btnDeSerializeToFile.Name = "btnDeSerializeToFile"
        Me.btnDeSerializeToFile.Size = New System.Drawing.Size(117, 23)
        Me.btnDeSerializeToFile.TabIndex = 9
        Me.btnDeSerializeToFile.Text = "DeSerializeFromFile"
        Me.btnDeSerializeToFile.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(439, 381)
        Me.Controls.Add(Me.btnDeSerializeToFile)
        Me.Controls.Add(Me.btnSerializeToFile)
        Me.Controls.Add(Me.btnOutput)
        Me.Controls.Add(Me.rtbHash)
        Me.Controls.Add(Me.tbValue)
        Me.Controls.Add(Me.btnHash)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnTurnOn)
        Me.Controls.Add(Me.btnStandby)
        Me.Controls.Add(Me.btnTurnOff)
        Me.Name = "Form1"
        Me.Text = "RedTape Tester"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnTurnOff As System.Windows.Forms.Button
    Friend WithEvents btnStandby As System.Windows.Forms.Button
    Friend WithEvents btnTurnOn As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnHash As System.Windows.Forms.Button
    Friend WithEvents tbValue As System.Windows.Forms.TextBox
    Friend WithEvents rtbHash As System.Windows.Forms.RichTextBox
    Friend WithEvents btnOutput As System.Windows.Forms.Button
    Friend WithEvents btnSerializeToFile As System.Windows.Forms.Button
    Friend WithEvents btnDeSerializeToFile As System.Windows.Forms.Button

End Class
