Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Forms
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Xml.Serialization
Imports System.ComponentModel
Imports DevExpress.Xpf.Docking

Imports DevExpress.Xpf.Core.Serialization
Imports DevExpress.Mvvm.UI.Interactivity
Imports DevExpress.Utils.Serializing

Namespace Q557494
    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Partial Public Class MainWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()
            DXSerializer.AddLayoutUpgradeHandler(DockManager, AddressOf layoutUpgrade)
        End Sub
        Private Sub layoutUpgrade(ByVal sender As Object, ByVal e As LayoutUpgradeEventArgs)
            If e.RestoredVersion = "1" Then
                documentGroup1.MDIStyle = MDIStyle.MDI
            End If
        End Sub
        Private Sub Button_Click_1(ByVal sender As Object, ByVal e As RoutedEventArgs)
            DockManager.SaveLayoutToXml("..//..//layout.xml")
        End Sub

        Private Sub Button_Click_2(ByVal sender As Object, ByVal e As RoutedEventArgs)
            DockManager.RestoreLayoutFromXml("..//..//layout.xml")
        End Sub

        Private Sub Button_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim layoutVersion As String = DXSerializer.GetLayoutVersion(DockManager)
            Dim number As Integer = Integer.Parse(layoutVersion)
            number += 1
            DXSerializer.SetLayoutVersion(DockManager, number.ToString())
        End Sub
    End Class

End Namespace

