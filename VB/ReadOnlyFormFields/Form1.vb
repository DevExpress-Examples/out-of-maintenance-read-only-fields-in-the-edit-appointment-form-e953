Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraScheduler
Imports System.IO

Namespace ReadOnlyFormFields
	Partial Public Class Form1
		Inherits Form
		Private Const aptDataFileName As String = "..\..\Data\appointments.xml"
		Private Const resDataFileName As String = "..\..\Data\resources.xml"

		Public Sub New()
			InitializeComponent()
			schedulerControl1.Start = New DateTime(2008, 07, 14)
			FillResourceStorage(schedulerStorage1.Resources.Items, resDataFileName)
			FillAppointmentStorage(schedulerStorage1.Appointments.Items, aptDataFileName)
		End Sub

		Private Sub schedulerControl1_EditAppointmentFormShowing(ByVal sender As Object, ByVal e As DevExpress.XtraScheduler.AppointmentFormEventArgs) Handles schedulerControl1.EditAppointmentFormShowing
			Dim f As New Form2(CType(sender, SchedulerControl), e.Appointment, False)
			f.ShowDialog()
			e.Handled = True
		End Sub

		#Region "FillData"

		Private Shared Function GetFileStream(ByVal fileName As String) As Stream
			Return New StreamReader(fileName).BaseStream
		End Function

		Private Shared Sub FillResourceStorage(ByVal c As ResourceCollection, ByVal fileName As String)
			Using stream As Stream = GetFileStream(fileName)
				c.ReadXml(stream)
				stream.Close()
			End Using
		End Sub
		Private Shared Sub FillAppointmentStorage(ByVal c As AppointmentCollection, ByVal fileName As String)
			Using stream As Stream = GetFileStream(fileName)
				c.ReadXml(stream)
				stream.Close()
			End Using
		End Sub
		#End Region
	End Class
End Namespace