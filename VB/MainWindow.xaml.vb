﻿Imports System.Windows
Imports DevExpress.Xpf.Docking
Imports DevExpress.Xpf.Core.Serialization
Imports DevExpress.Mvvm
Imports System.Collections.ObjectModel
Imports System.IO
Imports DevExpress.Xpf.Grid
Imports DevExpress.Xpf.Core

Namespace DXSample
	Partial Public Class MainWindow
		Inherits Window

		Private Const layoutPath As String = "../../layout.xml"
		Private Const workspaceName As String = "TestWorkspace"
		Public Property Items() As ObservableCollection(Of Item)
		Public Sub New()
			Items = New ObservableCollection(Of Item)()
			For i As Integer = 0 To 99
				Dim item As New Item With {
					.Group = i Mod 5,
					.Name = String.Format("Name_{0}", i)
				}
				Items.Add(item)
			Next i
			DataContext = Me
			InitializeComponent()
		End Sub
		Private Sub OnSaveClick(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim manager = WorkspaceManager.GetWorkspaceManager(dockLayoutManager)
			manager.CaptureWorkspace(workspaceName)
			manager.SaveWorkspace(workspaceName, layoutPath)
		End Sub
		Private Sub OnRestoreClick(ByVal sender As Object, ByVal e As RoutedEventArgs)
			If File.Exists(layoutPath) Then
				Dim manager = WorkspaceManager.GetWorkspaceManager(dockLayoutManager)
				manager.LoadWorkspace(workspaceName, layoutPath)
				manager.ApplyWorkspace(workspaceName)
			End If
		End Sub
		Private Sub OnDockLayoutManagerLayoutUpgrade(ByVal sender As Object, ByVal e As LayoutUpgradeEventArgs)
			If e.RestoredVersion = "1.0" Then
				documentGroup1.MDIStyle = MDIStyle.MDI
			End If
		End Sub
		Private Sub OnGridControlLayoutUpgrade(ByVal sender As Object, ByVal e As LayoutUpgradeEventArgs)
			If e.RestoredVersion = "1.0" Then
				DirectCast(sender, GridControl).GroupBy("Group")
			End If
		End Sub
	End Class
	Public Class Item
		Inherits BindableBase

		Private _group As Integer
		Private _name As String
		Public Property Group() As Integer
			Get
				Return _group
			End Get
			Set(ByVal value As Integer)
				SetProperty(_group, value, "Group")
			End Set
		End Property
		Public Property Name() As String
			Get
				Return _name
			End Get
			Set(ByVal value As String)
				SetProperty(_name, value, "Name")
			End Set
		End Property
	End Class
End Namespace