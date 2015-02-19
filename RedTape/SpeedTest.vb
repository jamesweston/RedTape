Imports System.Net
Imports RGiesecke.DllExport
Imports System.IO
Namespace Network
    Namespace Internet
        Module SpeedTest
            Public ReadOnly Null As StreamWriter
            <DllExport("RedTape.SpeedTest")> _
            Public Function InetSpeed() As String
                Dim generator As New Random
                Dim randomValue As Integer
                randomValue = generator.Next(1, 9999999)
                ' the URL to download a file from
                Dim URL2MB As New Uri("http://download.meamod.com/speedtest/2048.stf?" & randomValue)
                Dim URL4MB As New Uri("http://download.meamod.com/speedtest/4096.stf?" & randomValue)
                Dim NewText As String
                NewText = DoSpeed(URL2MB, "2MB")
                NewText = NewText & DoSpeed(URL4MB, "4MB")
                Return NewText
            End Function

            Private Function DoSpeed(URL As Uri, Size As String) As String
                Dim wc As New WebClient()
                Dim starttime As Double = Environment.TickCount
                Try
                    Dim myDatabuffer As Byte() = wc.DownloadData(URL)
                    myDatabuffer = Nothing
                    GC.Collect()
                    ' get current tickcount
                    Dim endtime As Double = Environment.TickCount

                    ' how many seconds did it take?
                    ' we are calculating this by subtracting starttime from endtime
                    ' and dividing by 1000 (since the tickcount is in miliseconds.. 1000 ms = 1 sec)
                    Dim secs As Double = Math.Floor(endtime - starttime) / 1000

                    ' round the number of secs and remove the decimal point
                    Dim secs2 As Double = Math.Round(secs, 0)

                    ' calculate download rate in kb per sec.
                    ' this is done by dividing 1024 by the number of seconds it
                    ' took to download the file (1024 bytes = 1 kilobyte)
                    Dim kbsec As Double = Math.Round(1024 / secs)

                    DoSpeed = (Size & " download: " & Chr(9) & secs2 & " secs (" & secs & "secs)" & vbNewLine & "Download rate: " & Chr(9) & kbsec & " KB/sec" & vbNewLine & vbNewLine)

                Catch WebException As Exception
                    DoSpeed = ("Error")
                End Try

            End Function
        End Module
    End Namespace
End Namespace
