Imports RedTape.System

Public Class Form1
    Dim ControlMonitor As New Monitor
    Dim ControlPower As New Power
    Dim Hash As New RedTape.Crypto.Hash
    Dim Ser As New RedTape.IO.Serialize
    Dim FirstArray As New ArrayList
    Dim i As Integer = 0
    Dim generator As New Random
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Do Until i = 100
            FirstArray.Add(i)
            i = i + 1
        Loop
    End Sub

    Private Sub btnTurnOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTurnOff.Click
        ControlMonitor.TurnOff()
    End Sub

    Private Sub btnTurnOn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTurnOn.Click
        ControlMonitor.TurnOn()
    End Sub

    Private Sub btnStandby_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStandby.Click
        ControlMonitor.StandBy()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ControlPower.Lock()
    End Sub

    Private Sub btnHash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHash.Click
        rtbHash.Clear()
        rtbHash.AppendText("MD5: " + Hash.MD5(tbValue.Text))
        rtbHash.AppendText(vbNewLine)
        rtbHash.AppendText("SHA1: " + Hash.SHA1(tbValue.Text))
        rtbHash.AppendText(vbNewLine)
        rtbHash.AppendText("SHA256: " + Hash.SHA256(tbValue.Text))
        rtbHash.AppendText(vbNewLine)
        rtbHash.AppendText("SHA384: " + Hash.SHA384(tbValue.Text))
        rtbHash.AppendText(vbNewLine)
        rtbHash.AppendText("SHA512: " + Hash.SHA512(tbValue.Text))
        rtbHash.AppendText(vbNewLine)
        rtbHash.AppendText("RIPEMD160: " + Hash.RIPEMD160(tbValue.Text))
    End Sub

    Private Sub btnOutput_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOutput.Click
        rtbHash.Clear()
        Dim x As Integer
        Do While x < FirstArray.Count
            rtbHash.AppendText(FirstArray(x))
            rtbHash.AppendText(vbNewLine)
            x = x + 1
        Loop
    End Sub

    Private Sub btnSerializeToFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSerializeToFile.Click
        Ser.SerializeToFile("Output.dat", FirstArray)
    End Sub

    Private Sub btnDeSerializeToFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeSerializeToFile.Click
        rtbHash.Clear()
        Dim SecondArray As New ArrayList(CType(Ser.DeSerializeFromFile("Output.dat"), System.Collections.ICollection))
        Dim x As Integer
        Do While x < SecondArray.Count
            rtbHash.AppendText(SecondArray(x))
            rtbHash.AppendText(vbNewLine)
            x = x + 1
        Loop
    End Sub
End Class
