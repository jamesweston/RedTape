Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace System
    Public Class Monitor
        Dim HWND_BROADCAST As Integer = &HFFFF
        Const SC_MONITORPOWER As Integer = &HF170
        Const WM_SYSCOMMAND As Integer = &H112
        Const MONITOR_ON As Integer = -1
        Const MONITOR_OFF As Integer = 2
        Const MONITOR_STANDBY As Integer = 1

        <DllImport("user32.dll")> _
        Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As UInteger, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
        End Function

        Public Sub StandBy()
            SendMessage(HWND_BROADCAST, WM_SYSCOMMAND, SC_MONITORPOWER, MONITOR_STANDBY)
        End Sub

        Public Sub TurnOff()
            SendMessage(HWND_BROADCAST, WM_SYSCOMMAND, SC_MONITORPOWER, MONITOR_OFF)
        End Sub

        Public Sub TurnOn()
            SendMessage(HWND_BROADCAST, WM_SYSCOMMAND, SC_MONITORPOWER, MONITOR_ON)
        End Sub
    End Class

    Public Class Power
        Private Declare Function GetCurrentProcess Lib "kernel32.dll" () As IntPtr
        Private Declare Function OpenProcessToken Lib "advapi32.dll" (ByVal ProcessHandle As IntPtr, ByVal DesiredAccess As Int32, ByRef TokenHandle As IntPtr) As Int32
        Private Declare Function LookupPrivilegeValue Lib "advapi32.dll" Alias "LookupPrivilegeValueA" (ByVal lpSystemName As String, ByVal lpName As String, ByRef lpLuid As LUID) As Int32
        Private Declare Function AdjustTokenPrivileges Lib "advapi32.dll" (ByVal TokenHandle As IntPtr, ByVal DisableAllPrivileges As Int32, ByRef NewState As TOKEN_PRIVILEGES, ByVal BufferLength As Int32, ByRef PreviousState As TOKEN_PRIVILEGES, ByRef ReturnLength As Int32) As Int32
        Private Declare Function ExitWindowsExAlt Lib "user32.dll" (ByVal uFlags As Int32, ByVal dwReserved As Int32) As Int32
        Private Const EWX_FORCE As Int32 = 4
        Private Const EWX_SHUTDOWN As Int32 = 1
        Private Const EWX_REBOOT As Int32 = 2
        Private Const EWX_LOGOFF As Int32 = 0

        <DllImport("user32.dll")> _
        Protected Shared Function ExitWindowsEx(ByVal uFlags As Integer, ByVal dwReason As Integer) As Integer
        End Function

        <DllImport("user32.dll")> _
        Protected Shared Sub LockWorkStation()
        End Sub

        Protected Structure LUID
            Dim LowPart As Int32
            Dim HighPart As Int32
        End Structure

        Protected Structure TOKEN_PRIVILEGES
            Public PrivilegeCount As Integer
            Public Privileges As LUID
            Public Attributes As Int32
        End Structure
        Public Sub AltRestart()
            Dim platform As New PlatformID
            Select Case Environment.OSVersion.Platform
                Case PlatformID.Win32NT
                    Dim token As TOKEN_PRIVILEGES
                    Dim blank_token As TOKEN_PRIVILEGES
                    Dim token_handle As IntPtr
                    Dim uid As LUID
                    Dim ret_length As Integer
                    Dim ptr As IntPtr = GetCurrentProcess() '/// get the process handle

                    OpenProcessToken(ptr, &H20 Or &H8, token_handle)
                    LookupPrivilegeValue("", "SeShutdownPrivilege", uid)
                    token.PrivilegeCount = 1
                    token.Privileges = uid
                    token.Attributes = &H2

                    AdjustTokenPrivileges(token_handle, False, token, Marshal.SizeOf(blank_token), blank_token, ret_length)

                    ExitWindowsExAlt(EWX_LOGOFF Or EWX_FORCE Or EWX_REBOOT, &HFFFF)

                Case Else
                    ExitWindowsExAlt(EWX_SHUTDOWN Or EWX_FORCE Or EWX_REBOOT, &HFFFF)
            End Select
        End Sub

        Public Sub AltShutdown()
            Dim platform As New PlatformID
            Select Case Environment.OSVersion.Platform
                Case PlatformID.Win32NT
                    Dim token As TOKEN_PRIVILEGES
                    Dim blank_token As TOKEN_PRIVILEGES
                    Dim token_handle As IntPtr
                    Dim uid As LUID
                    Dim ret_length As Integer
                    Dim ptr As IntPtr = GetCurrentProcess() '/// get the process handle

                    OpenProcessToken(ptr, &H20 Or &H8, token_handle)
                    LookupPrivilegeValue("", "SeShutdownPrivilege", uid)
                    token.PrivilegeCount = 1
                    token.Privileges = uid
                    token.Attributes = &H2

                    AdjustTokenPrivileges(token_handle, 0, token, Marshal.SizeOf(blank_token), blank_token, ret_length)

                    ExitWindowsExAlt(EWX_SHUTDOWN Or EWX_FORCE, &HFFFF)

                Case Else
                    ExitWindowsExAlt(EWX_SHUTDOWN Or EWX_FORCE, &HFFFF)
            End Select
        End Sub
        Public Sub AltLogoff()
            Dim platform As New PlatformID
            Select Case Environment.OSVersion.Platform
                Case PlatformID.Win32NT
                    Dim token As TOKEN_PRIVILEGES
                    Dim blank_token As TOKEN_PRIVILEGES
                    Dim token_handle As IntPtr
                    Dim uid As LUID
                    Dim ret_length As Integer
                    Dim ptr As IntPtr = GetCurrentProcess() '/// get the process handle

                    OpenProcessToken(ptr, &H20 Or &H8, token_handle)
                    LookupPrivilegeValue("", "SeShutdownPrivilege", uid)
                    token.PrivilegeCount = 1
                    token.Privileges = uid
                    token.Attributes = &H2

                    AdjustTokenPrivileges(token_handle, False, token, Marshal.SizeOf(blank_token), blank_token, ret_length)

                    ExitWindowsExAlt(EWX_LOGOFF Or EWX_FORCE Or EWX_LOGOFF, &HFFFF)

                Case Else
                    ExitWindowsExAlt(EWX_LOGOFF Or EWX_FORCE Or EWX_REBOOT, &HFFFF)
            End Select
        End Sub
        Public Sub Shutdown()
            ExitWindowsEx(1, 0)
        End Sub
        Public Sub Restart()
            ExitWindowsEx(2, 0)
        End Sub
        Public Sub Logoff()
            ExitWindowsEx(0, 0)
        End Sub
        Public Sub Lock()
            LockWorkStation()
        End Sub
        Public Sub Hibernate()
            Application.SetSuspendState(PowerState.Hibernate, True, True)
        End Sub
        Public Sub Suspend()
            Application.SetSuspendState(PowerState.Suspend, True, True)
        End Sub
    End Class
    Public Module OS
        Public Function isWindows7OrAbove() As Boolean
            If My.Computer.Info.OSVersion < "6.1" Then
                Return False
            ElseIf My.Computer.Info.OSVersion >= "6.1" Then
                Return True
            Else
                Return False
            End If
        End Function

        Public Function isWindowsVistaOrAbove() As Boolean
            If My.Computer.Info.OSVersion < "6.0" Then
                Return False
            ElseIf My.Computer.Info.OSVersion >= "6.0" Then
                Return True
            Else
                Return False
            End If
        End Function
        Public Function isWindowsXPOrAbove() As Boolean
            If My.Computer.Info.OSVersion < "5.1" Then
                Return False
            ElseIf My.Computer.Info.OSVersion >= "5.1" Then
                Return True
            Else
                Return False
            End If
        End Function
    End Module
End Namespace
