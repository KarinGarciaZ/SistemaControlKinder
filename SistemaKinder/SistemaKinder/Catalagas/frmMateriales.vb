﻿Imports System.Data.SqlClient
Public Class frmMateriales
    Dim conexionsql As SqlConnection = openConection()
    Dim comando As SqlCommand = conexionsql.CreateCommand
    Dim lector As SqlDataReader

    Private Sub frmMateriales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conexionsql.Open()
    End Sub

    Private Sub cmdNuevo_Click(sender As Object, e As EventArgs) Handles cmdNuevo.Click
        gbMaterial.Enabled = True
        dtpFecha.Enabled = True
        txtDescripcion.Enabled = True
        txtExistencias.Enabled = True
        txtMaximo.Enabled = True
        txtMinimo.Enabled = True
        txtCosto.Enabled = True
        cboUnidad.Enabled = True
        cmdGuardar.Enabled = True
        comando.CommandText = "SELECT COUNT(*) FROM Materiales"
        txtIdMaterial.Text = comando.ExecuteScalar + 1

        cmdNuevo.Enabled = False
    End Sub

    Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        If Not txtDescripcion.Text.Equals("") And Not txtDescripcion.Text.Contains("'") Then
            If IsNumeric(txtExistencias.Text) Then
                If IsNumeric(txtMaximo.Text) Then
                    If IsNumeric(txtMinimo.Text) Then
                        If IsNumeric(txtCosto.Text) Then
                            If Not cboUnidad.Text.Equals("") Then
                                If Not CDbl(txtExistencias.Text) > 2147483647 And Not CDbl(txtExistencias.Text) < 1 Then
                                    If Not CDbl(txtMaximo.Text) > 2147483647 And Not CDbl(txtMaximo.Text) < 1 Then
                                        If Not CDbl(txtMinimo.Text) > 2147483647 And Not CDbl(txtMinimo.Text) < 1 Then
                                            If Not CDbl(txtCosto.Text) > 2147483647 And Not CDbl(txtCosto.Text) < 1 Then
                                                Dim id As Integer = txtIdMaterial.Text
                                                Dim fec As Date = dtpFecha.Value.Date
                                                Dim des As String = txtDescripcion.Text
                                                Dim exi As Integer = txtExistencias.Text
                                                Dim max As Integer = txtMaximo.Text
                                                Dim min As Integer = txtMinimo.Text
                                                Dim cos As Double = txtCosto.Text
                                                Dim uni As String = cboUnidad.Text

                                                Dim R As String
                                                R = "INSERT INTO Materiales(idMaterial, ultimaFechaCompra, descripcion, existencias, maximo, minimo, costo, unidadMedida) VALUES(" & id & ",'" & fec & "','" & des & "'," & exi & "," & max & "," & min & "," & cos & ",'" & uni & "')"
                                                comando.CommandText = R
                                                comando.ExecuteNonQuery()

                                                txtIdMaterial.Text = ""
                                                txtDescripcion.Text = ""
                                                txtExistencias.Text = ""
                                                txtMaximo.Text = ""
                                                txtMinimo.Text = ""
                                                cboUnidad.Text = ""
                                                txtCosto.Text = ""

                                                gbMaterial.Enabled = False
                                                dtpFecha.Enabled = False
                                                txtDescripcion.Enabled = False
                                                txtExistencias.Enabled = False
                                                txtMaximo.Enabled = False
                                                txtMinimo.Enabled = False
                                                txtCosto.Enabled = False
                                                cboUnidad.Enabled = False
                                                cmdGuardar.Enabled = False
                                                cmdNuevo.Enabled = True
                                                cmdGuardar.Enabled = False
                                            Else
                                                MessageBox.Show("No se aceptan valores numericos mayores a 2,147,483,647 ó menores a 1")
                                            End If

                                        Else
                                            MessageBox.Show("No se aceptan valores numericos mayores a 2,147,483,647 ó menores a 1")
                                        End If
                                    Else
                                        MessageBox.Show("No se aceptan valores numericos mayores a 2,147,483,647 ó menores a 1")
                                    End If
                                Else
                                    MessageBox.Show("No se aceptan valores numericos mayores a 2,147,483,647 ó menores a 1")
                                End If

                            Else
                                MessageBox.Show("Seleccione una unidad de medida")
                            End If
                        Else
                            MessageBox.Show("Introduzca un valor válido para costo")
                        End If
                    Else
                        MessageBox.Show("Introduzca un valor válido para mínimo")
                    End If
                Else
                    MessageBox.Show("Introduzca un valor válido para máximo")
                End If
            Else
                MessageBox.Show("Introduzca un valor válido para existencias")
            End If
        Else
            MessageBox.Show("Introduzca un valor válido para descripción")
        End If


    End Sub

    Private Sub cmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
        conexionsql.Close()
        Me.Dispose()
    End Sub
End Class