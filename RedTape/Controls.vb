Imports System.Collections.Generic
Imports System.Text

Namespace Controls
    Public Class ScrollingRichTextBox
        Inherits Windows.Forms.RichTextBox
        <Runtime.InteropServices.DllImport("user32.dll", CharSet:=Runtime.InteropServices.CharSet.Auto)> _
        Private Shared Function SendMessage(hWnd As IntPtr, Msg As UInteger, wParam As IntPtr, lParam As IntPtr) As IntPtr
        End Function

        Private Const WM_VSCROLL As Integer = 277
        Private Const SB_LINEUP As Integer = 0
        Private Const SB_LINEDOWN As Integer = 1
        Private Const SB_TOP As Integer = 6
        Private Const SB_BOTTOM As Integer = 7

        Public Sub ScrollToBottom()
            SendMessage(Handle, WM_VSCROLL, New IntPtr(SB_BOTTOM), New IntPtr(0))
        End Sub

        Public Sub ScrollToTop()
            SendMessage(Handle, WM_VSCROLL, New IntPtr(SB_TOP), New IntPtr(0))
        End Sub

        Public Sub ScrollLineDown()
            SendMessage(Handle, WM_VSCROLL, New IntPtr(SB_LINEDOWN), New IntPtr(0))
        End Sub

        Public Sub ScrollLineUp()
            SendMessage(Handle, WM_VSCROLL, New IntPtr(SB_LINEUP), New IntPtr(0))
        End Sub
    End Class
End Namespace
