Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Namespace WindowsApplication1
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
			list = New BindingList(Of MyObject)()

			For i As Integer = 0 To 9
				list.Add(New MyObject(i.ToString(),(i+10).ToString()))
			Next i
			bs = New BindingSource()
			bs.DataSource = list

			gridControl1.DataSource = bs

		End Sub


		Private bs As BindingSource
		Private list As BindingList(Of MyObject)

		Private Sub simpleButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton1.Click
			listBoxControl1.Items.Clear()
			For i As Integer = 0 To gridView1.SelectedRowsCount - 1
				Dim row As Integer = (gridView1.GetSelectedRows()(i))
				Dim obj As MyObject = TryCast(gridView1.GetRow(row), MyObject)
				If obj Is Nothing Then
					Return
				End If
				listBoxControl1.Items.Add(obj.Field2.ToString())
			Next i
		End Sub

	End Class
	Public Class MyObject
		Implements INotifyPropertyChanged
		Public Sub New(ByVal str1 As String, ByVal str2 As String)
			field1_Renamed = str1
			field2_Renamed = str2
		End Sub
		Private field1_Renamed As String
		Public Property Field1() As String
			Get
				Return field1_Renamed
			End Get
			Set(ByVal value As String)
				field1_Renamed = value
				NotifyPropertyChanged("Field1")
			End Set
		End Property

		Private field2_Renamed As String
		Public Property Field2() As String
			Get
				Return field2_Renamed
			End Get
			Set(ByVal value As String)
				field2_Renamed = value
				NotifyPropertyChanged("Field2")
			End Set
		End Property


		#Region "INotifyPropertyChanged Members"

		Private Sub NotifyPropertyChanged(ByVal info As String)
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(info))
		End Sub

		Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

		#End Region
	End Class
End Namespace