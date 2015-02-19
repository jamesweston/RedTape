Imports System.Net

Namespace Network
    Namespace Internet
        Public Class Connection
            '**************************************
            ' Name: Check internet connection type
            ' This code makes API calls to check for an internet conection and
            ' returns the type of connection through API calls to the wininet.dll

            Public Declare Function InternetGetConnectedState Lib "wininet.dll" (ByRef lpdwFlags As Integer, ByVal dwReserved As Integer) As Integer
            'Internet connection VIA Proxy server.
            Public Const ProxyConnection As Integer = &H4S

            'Modem is busy.s
            Public Const ModemConnectionIsBusy As Integer = &H8S

            'Internet connection is currently Offline
            Public Const InternetIsOffline As Integer = &H20S

            'Internet connection is currently configured
            Public Const InternetConnectionIsConfigured As Integer = &H40S

            'Internet connection VIA Modem.
            Public Const ModemConnection As Integer = &H1S

            'Remote Access Server is installed.
            Public Const RasInstalled As Integer = &H10S

            'Internet connection VIA LAN.
            Public Const LanConnection As Integer = &H2S

            Public Function IsLanConnection() As Boolean
                Dim dwflags As Integer
                'return True if LAN connection
                Call InternetGetConnectedState(dwflags, 0)
                IsLanConnection = dwflags And LanConnection
            End Function


            Public Function IsModemConnection() As Boolean
                Dim dwflags As Integer
                'return True if modem connection.
                Call InternetGetConnectedState(dwflags, 0)
                IsModemConnection = dwflags And ModemConnection
            End Function


            Public Function IsProxyConnection() As Boolean
                Dim dwflags As Integer
                'return True if connected through a proxy.
                Call InternetGetConnectedState(dwflags, 0)
                IsProxyConnection = dwflags And ProxyConnection
            End Function


            Public Function IsConnected() As Boolean
                'Returns true if there is any internet connection.
                IsConnected = InternetGetConnectedState(0, 0)
            End Function


            Public Function IsRasInstalled() As Boolean
                Dim dwflags As Integer
                'return True if RAS installed.
                Call InternetGetConnectedState(dwflags, 0)
                IsRasInstalled = dwflags And RasInstalled
            End Function

            Public Function CanConnectToMeaMod() As Boolean
                Dim siteResponds As Boolean = False
                Try
                    siteResponds = My.Computer.Network.Ping("meamod.com")
                Catch ex As Exception
                    siteResponds = False
                End Try
                CanConnectToMeaMod = siteResponds
            End Function


            Public Function ConnectionTypeMsg() As String
                Dim dwflags As Integer
                Dim msg As String = ""
                'Return Internet connection msg.

                If InternetGetConnectedState(dwflags, 0) Then

                    If dwflags And InternetConnectionIsConfigured Then
                        msg = msg & "Internet connection is configured." & vbCrLf
                    End If

                    If dwflags And LanConnection Then
                        msg = msg & "Internet connection via a LAN"
                    End If

                    If dwflags And ProxyConnection Then
                        msg = msg & ", and connection is through a proxy server."
                    Else
                        msg = msg & "."
                    End If

                    If dwflags And ModemConnection Then
                        msg = msg & "Internet connection via a Modem"
                    End If

                    If dwflags And InternetIsOffline Then
                        msg = msg & "Internet connection is currently offline."
                    End If

                    If dwflags And ModemConnectionIsBusy Then
                        msg = msg & "Modem is busy with a non-Internet connection."
                    End If

                    If dwflags And RasInstalled Then
                        msg = msg & "Remote Access Services are installed on local system."
                    End If

                    If dwflags And CanConnectToMeaMod() = True Then
                        msg = msg & "Connected to MeaMod successfully."
                    Else
                        msg = msg & ""
                    End If

                Else
                    msg = "You are currently not connected to the internet."

                End If

                ConnectionTypeMsg = msg

            End Function
        End Class
    End Namespace
    Public Module Address
        Public Function InternalIPAddress() As String
            Dim host As IPHostEntry
            Dim localIP As String = "Error"
            host = Dns.GetHostEntry(Dns.GetHostName())
            For Each ip As IPAddress In host.AddressList
                If ip.AddressFamily = Sockets.AddressFamily.InterNetwork Then
                    'Console.WriteLine (ip.ToString())
                    If ip.ToString = "127.0.0.1" Then
                        localIP = "Loopback Error"
                    Else
                        localIP = ip.ToString()
                        Exit For
                    End If
                End If
            Next
            Return localIP
        End Function

        Public Function ExternalIPAddress() As String
            Dim globalIP As String = APIGlobalIPAddress()
            If globalIP = Nothing Then
                Return ("Error")
            Else
                Return globalIP
            End If
        End Function

        Private Function APIGlobalIPAddress() As String
            Dim inetcon As New RedTape.Network.Internet.Connection
            If inetcon.IsConnected = True Then
                Try
                    Dim l_WebClient As New WebClient()
                    Dim l_String As String = l_WebClient.DownloadString("http://www.myipsupport.com/api/?remoteip")
                    Return l_String
                Catch WebException As Exception
                    Return Nothing
                End Try
            Else
                Return Nothing
            End If
        End Function
    End Module
End Namespace



