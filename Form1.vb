Public Class Form1

    Dim liczba01 As Integer ' wybrane liczby uzytkownika
    Dim liczba02 As Integer
    Dim liczba03 As Integer
    Dim liczba04 As Integer
    Dim liczba05 As Integer
    Dim liczba06 As Integer
    Dim kolor(10) ' kolory w tabelce
    Dim zakresmin
    Dim zakresmax
    Dim zakres
    Dim UstWyswA = 1
    Dim UstWyswB = 0
    Dim SwLosowe = 0 ' switch czy wczytane 0 czy losowe 1
    ' koniec deklaracji




    Sub licz_ogolny()

        'sortuj tabele
        DataGridView1.Sort(DataGridView1.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
        DataGridView2.Sort(DataGridView2.Columns(0), System.ComponentModel.ListSortDirection.Ascending)

        czysc()
        licz_trafienia()
        trafien()
        licz_tabele2()
        koloruj_tabele()
        licz_procenty()

        Ekran_ilosc.Text = "Rozpatrywanych losowań:" & zakres

        'sortuj tabele
        DataGridView1.Sort(DataGridView1.Columns(8), System.ComponentModel.ListSortDirection.Descending)
        DataGridView2.Sort(DataGridView2.Columns(1), System.ComponentModel.ListSortDirection.Descending)

        'likwidacja zaznaczania w tabelach
        DataGridView1.ClearSelection()
        DataGridView2.ClearSelection()

    End Sub

    Sub blokuj()

        'wylaczenie przelacznikow
        TrackBar1.Enabled = False
        TrackBar2.Enabled = False

    End Sub

    Sub ulubione()

        NumericUpDown1.Value = 9
        NumericUpDown2.Value = 19
        NumericUpDown3.Value = 22
        NumericUpDown4.Value = 24
        NumericUpDown5.Value = 42
        NumericUpDown6.Value = 45

    End Sub

    Sub czysc()

        Dim w As Integer
        Dim k As Integer

        'czysc zaznaczenie tabela 1
        For w = 0 To DataGridView1.RowCount - 1
            For k = 0 To 7
                DataGridView1.Rows(w).Cells(k).Style.BackColor = kolor(0)
            Next k
        Next w

        'czysc zaznaczenie tabela 2
        For w = 0 To DataGridView2.RowCount - 1
            For k = 0 To 1
                DataGridView2.Rows(w).Cells(k).Style.BackColor = kolor(0)
            Next k
        Next w

        'czysc kolumne8 tabela 1
        For w = 0 To DataGridView1.RowCount - 1
            DataGridView1.Rows(w).Cells(8).Value = 0
        Next w

        'czysc kolumne1 tabela 2
        For w = 0 To DataGridView2.RowCount - 1
            DataGridView2.Rows(w).Cells(1).Value = ""
        Next w

        'czysc suwaki procentowe
        ProgressBar1.Value = 0
        ProgressBar2.Value = 0
        ProgressBar3.Value = 0
        ProgressBar4.Value = 0
        ProgressBar5.Value = 0
        ProgressBar6.Value = 0

        'czysc ekrany oraz paski procentowe z danych i kolorow
        Ekran1.Text = ""
        Ekran2.Text = ""
        Ekran3.Text = ""
        Ekran4.Text = ""
        Ekran5.Text = ""
        Ekran6.Text = ""
        Ekran11.Text = ""
        Ekran12.Text = ""
        Ekran13.Text = ""
        Ekran14.Text = ""
        Ekran15.Text = ""
        Ekran16.Text = ""
        Ekran_ilosc.Text = ""
        Ekran1.BackColor = kolor(0)
        Ekran2.BackColor = kolor(0)
        Ekran3.BackColor = kolor(0)
        Ekran4.BackColor = kolor(0)
        Ekran5.BackColor = kolor(0)
        Ekran6.BackColor = kolor(0)
        ProgressBar1.ForeColor = kolor(0)
        ProgressBar2.ForeColor = kolor(0)
        ProgressBar3.ForeColor = kolor(0)
        ProgressBar4.ForeColor = kolor(0)
        ProgressBar5.ForeColor = kolor(0)
        ProgressBar6.ForeColor = kolor(0)

        'likwidacja zaznaczania w tabelach
        DataGridView1.ClearSelection()
        DataGridView2.ClearSelection()

        'gas kontrolki na wyswietlaczu 
        lblTrafien.ForeColor = kolor(8)
        lblTrafien3.ForeColor = kolor(8)
        lblTrafien4.ForeColor = kolor(8)
        lblTrafien5.ForeColor = kolor(8)
        lblTrafien6.ForeColor = kolor(8)
        lblTrafien3a.ForeColor = kolor(8)
        lblTrafien4a.ForeColor = kolor(8)
        lblTrafien5a.ForeColor = kolor(8)
        lblTrafien6a.ForeColor = kolor(8)

        'zeruj wskazania
        lblTrafien3a.Text = 0
        lblTrafien4a.Text = 0
        lblTrafien5a.Text = 0
        lblTrafien6a.Text = 0

        'ustawienie kontrolki losowe
        If SwLosowe = 0 Then lblLosowo.ForeColor = kolor(8)
        If SwLosowe = 1 Then lblLosowo.ForeColor = Color.Tomato

    End Sub

    Sub kontrolki()

        'koloruj ciemnym kolory ekraniki zakresu
        EkranZakres1.ForeColor = kolor(8)
        EkranZakres2.ForeColor = kolor(8)
        EkranZakres3.ForeColor = kolor(8)
        EkranZakres4.ForeColor = kolor(8)


        'zaswiecenie kontrolki na wyswietlaczu
        If UstWyswB = 0 Then EkranZakres2.ForeColor = kolor(8) : EkranZakres3.ForeColor = kolor(8)
        If UstWyswB = 2 Then EkranZakres2.ForeColor = kolor(9)
        If UstWyswB = 3 Then EkranZakres3.ForeColor = kolor(9)

        If UstWyswA = 1 Then EkranZakres1.ForeColor = kolor(9) : EkranZakres4.ForeColor = kolor(8)
        If UstWyswA = 4 Then EkranZakres4.ForeColor = kolor(9) : EkranZakres1.ForeColor = kolor(8)

    End Sub

    Sub koloruj_tabele()

        Dim d As Integer
        Dim a As Integer

        'zaznaczanie na kolorowo pol tab 1
        For d = zakresmin To zakresmax
            For a = 2 To 7
                If DataGridView1.Rows(d).Cells(a).Value = liczba01 Then DataGridView1.Rows(d).Cells(a).Style.BackColor = kolor(1)
                If DataGridView1.Rows(d).Cells(a).Value = liczba02 Then DataGridView1.Rows(d).Cells(a).Style.BackColor = kolor(2)
                If DataGridView1.Rows(d).Cells(a).Value = liczba03 Then DataGridView1.Rows(d).Cells(a).Style.BackColor = kolor(3)
                If DataGridView1.Rows(d).Cells(a).Value = liczba04 Then DataGridView1.Rows(d).Cells(a).Style.BackColor = kolor(4)
                If DataGridView1.Rows(d).Cells(a).Value = liczba05 Then DataGridView1.Rows(d).Cells(a).Style.BackColor = kolor(5)
                If DataGridView1.Rows(d).Cells(a).Value = liczba06 Then DataGridView1.Rows(d).Cells(a).Style.BackColor = kolor(6)
            Next a
        Next d

        'zaznaczanie na kolorowo pol tab 2
        DataGridView2.Rows(liczba01 - 1).Cells(0).Style.BackColor = kolor(1)
        DataGridView2.Rows(liczba02 - 1).Cells(0).Style.BackColor = kolor(2)
        DataGridView2.Rows(liczba03 - 1).Cells(0).Style.BackColor = kolor(3)
        DataGridView2.Rows(liczba04 - 1).Cells(0).Style.BackColor = kolor(4)
        DataGridView2.Rows(liczba05 - 1).Cells(0).Style.BackColor = kolor(5)
        DataGridView2.Rows(liczba06 - 1).Cells(0).Style.BackColor = kolor(6)


    End Sub

    Sub licz_trafienia()
        Dim d As Integer
        Dim a As Integer
        Dim wynik(DataGridView1.RowCount * 6) As Integer


        'zliczenie trafien
        For d = zakresmin To zakresmax
            For a = 2 To 7
                If DataGridView1.Rows(d).Cells(a).Value = liczba01 Then wynik(d) = wynik(d) + 1
                If DataGridView1.Rows(d).Cells(a).Value = liczba02 Then wynik(d) = wynik(d) + 1
                If DataGridView1.Rows(d).Cells(a).Value = liczba03 Then wynik(d) = wynik(d) + 1
                If DataGridView1.Rows(d).Cells(a).Value = liczba04 Then wynik(d) = wynik(d) + 1
                If DataGridView1.Rows(d).Cells(a).Value = liczba05 Then wynik(d) = wynik(d) + 1
                If DataGridView1.Rows(d).Cells(a).Value = liczba06 Then wynik(d) = wynik(d) + 1
                DataGridView1.Rows(d).Cells(8).Value = wynik(d)
            Next a
        Next d
    End Sub

    Sub trafien()

        Dim wynik(6) As Integer
        Dim t = 0

        'zliczenie trojek,czworek piatek i szostek
        For d = zakresmin To zakresmax
            If DataGridView1.Rows(d).Cells(8).Value = 3 Then wynik(3) = wynik(3) + 1
            If DataGridView1.Rows(d).Cells(8).Value = 4 Then wynik(4) = wynik(4) + 1
            If DataGridView1.Rows(d).Cells(8).Value = 5 Then wynik(5) = wynik(5) + 1
            If DataGridView1.Rows(d).Cells(8).Value = 6 Then wynik(6) = wynik(6) + 1
           
            If wynik(3) <> 0 Then lblTrafien3a.Text = wynik(3) : lblTrafien3a.ForeColor = kolor(9) : lblTrafien3.ForeColor = kolor(9) : t = 1
            If wynik(4) <> 0 Then lblTrafien4a.Text = wynik(4) : lblTrafien4a.ForeColor = kolor(9) : lblTrafien4.ForeColor = kolor(9) : t = 1
            If wynik(5) <> 0 Then lblTrafien5a.Text = wynik(5) : lblTrafien5a.ForeColor = kolor(9) : lblTrafien5.ForeColor = kolor(9) : t = 1
            If wynik(6) <> 0 Then lblTrafien6a.Text = wynik(6) : lblTrafien6a.ForeColor = kolor(9) : lblTrafien6.ForeColor = kolor(9) : t = 1
            If t <> 0 Then lblTrafien.ForeColor = kolor(9)
        Next d


    End Sub
    Sub licz_tabele2()

        Dim d As Integer
        Dim a As Integer
        Dim ilosc As Integer
        Dim wynik(50) As Integer

        'wypełnienie tabelki 2  kolumna 0
        For d = 0 To DataGridView2.RowCount - 2
            DataGridView2.Rows(d).Cells(0).Value = d + 1
        Next d



        ''''oblicz i wpisuje dane do tabeli 2 kolumna 1''''''''''''''''''''''''''''''''''''''''''''''

        'dla wszystkich
        If TrackBar2.Value = 6 Then
            For ilosc = 1 To 49
                For d = zakresmin To zakresmax
                    For a = 2 To 7
                        If DataGridView1.Rows(d).Cells(a).Value = ilosc Then wynik(ilosc) = wynik(ilosc) + 1
                    Next a
                Next d
                DataGridView2.Rows(ilosc - 1).Cells(1).Value = wynik(ilosc)
            Next ilosc
        End If

        'dla A
        If TrackBar2.Value = 5 Then
            For ilosc = 1 To 49
                For d = zakresmin To zakresmax
                    If DataGridView1.Rows(d).Cells(2).Value = ilosc Then wynik(ilosc) = wynik(ilosc) + 1
                Next d
                DataGridView2.Rows(ilosc - 1).Cells(1).Value = wynik(ilosc)
            Next ilosc
        End If

        'dla B
        If TrackBar2.Value = 4 Then
            For ilosc = 1 To 49
                For d = zakresmin To zakresmax
                    If DataGridView1.Rows(d).Cells(3).Value = ilosc Then wynik(ilosc) = wynik(ilosc) + 1
                Next d
                DataGridView2.Rows(ilosc - 1).Cells(1).Value = wynik(ilosc)
            Next ilosc
        End If

        'dla C
        If TrackBar2.Value = 3 Then
            For ilosc = 1 To 49
                For d = zakresmin To zakresmax
                    If DataGridView1.Rows(d).Cells(4).Value = ilosc Then wynik(ilosc) = wynik(ilosc) + 1
                Next d
                DataGridView2.Rows(ilosc - 1).Cells(1).Value = wynik(ilosc)
            Next ilosc
        End If

        'dla D
        If TrackBar2.Value = 2 Then
            For ilosc = 1 To 49
                For d = zakresmin To zakresmax
                    If DataGridView1.Rows(d).Cells(5).Value = ilosc Then wynik(ilosc) = wynik(ilosc) + 1
                Next d
                DataGridView2.Rows(ilosc - 1).Cells(1).Value = wynik(ilosc)
            Next ilosc
        End If

        'dla E
        If TrackBar2.Value = 1 Then
            For ilosc = 1 To 49
                For d = zakresmin To zakresmax
                    If DataGridView1.Rows(d).Cells(6).Value = ilosc Then wynik(ilosc) = wynik(ilosc) + 1
                Next d
                DataGridView2.Rows(ilosc - 1).Cells(1).Value = wynik(ilosc)
            Next ilosc
        End If

        'dla F
        If TrackBar2.Value = 0 Then
            For ilosc = 1 To 49
                For d = zakresmin To zakresmax
                    If DataGridView1.Rows(d).Cells(7).Value = ilosc Then wynik(ilosc) = wynik(ilosc) + 1
                Next d
                DataGridView2.Rows(ilosc - 1).Cells(1).Value = wynik(ilosc)
            Next ilosc
        End If
        ''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Sub licz_procenty()

        'oblicz procenty dla liczb wybranych oraz wszystkich i ustaw pasek oraz kolory w okienkach statystyki procentowej 
        'zaleznie od wyboru przelacznika TRACKBAR1

        '' 0 ''''''''''''''''''''''''''''''''''''''''''''''''''''
        If TrackBar1.Value = 0 Then

            If DataGridView2.Rows(liczba01 - 1).Cells(1).Value <> 0 Then ProgressBar1.Value = Int(((DataGridView2.Rows(liczba01 - 1).Cells(1).Value) * 100) / zakres) : Ekran11.Text = Int(((DataGridView2.Rows(liczba01 - 1).Cells(1).Value) * 100) / zakres) & " %"
            If DataGridView2.Rows(liczba02 - 1).Cells(1).Value <> 0 Then ProgressBar2.Value = Int(((DataGridView2.Rows(liczba02 - 1).Cells(1).Value) * 100) / zakres) : Ekran12.Text = Int(((DataGridView2.Rows(liczba02 - 1).Cells(1).Value) * 100) / zakres) & " %"
            If DataGridView2.Rows(liczba03 - 1).Cells(1).Value <> 0 Then ProgressBar3.Value = Int(((DataGridView2.Rows(liczba03 - 1).Cells(1).Value) * 100) / zakres) : Ekran13.Text = Int(((DataGridView2.Rows(liczba03 - 1).Cells(1).Value) * 100) / zakres) & " %"
            If DataGridView2.Rows(liczba04 - 1).Cells(1).Value <> 0 Then ProgressBar4.Value = Int(((DataGridView2.Rows(liczba04 - 1).Cells(1).Value) * 100) / zakres) : Ekran14.Text = Int(((DataGridView2.Rows(liczba04 - 1).Cells(1).Value) * 100) / zakres) & " %"
            If DataGridView2.Rows(liczba05 - 1).Cells(1).Value <> 0 Then ProgressBar5.Value = Int(((DataGridView2.Rows(liczba05 - 1).Cells(1).Value) * 100) / zakres) : Ekran15.Text = Int(((DataGridView2.Rows(liczba05 - 1).Cells(1).Value) * 100) / zakres) & " %"
            If DataGridView2.Rows(liczba06 - 1).Cells(1).Value <> 0 Then ProgressBar6.Value = Int(((DataGridView2.Rows(liczba06 - 1).Cells(1).Value) * 100) / zakres) : Ekran16.Text = Int(((DataGridView2.Rows(liczba06 - 1).Cells(1).Value) * 100) / zakres) & " %"

            ' ustaw odpowiednie kolory i liczby
            Ekran1.BackColor = kolor(1)
            Ekran2.BackColor = kolor(2)
            Ekran3.BackColor = kolor(3)
            Ekran4.BackColor = kolor(4)
            Ekran5.BackColor = kolor(5)
            Ekran6.BackColor = kolor(6)

            ProgressBar1.ForeColor = kolor(1)
            ProgressBar2.ForeColor = kolor(2)
            ProgressBar3.ForeColor = kolor(3)
            ProgressBar4.ForeColor = kolor(4)
            ProgressBar5.ForeColor = kolor(5)
            ProgressBar6.ForeColor = kolor(6)

            Ekran1.Text = liczba01
            Ekran2.Text = liczba02
            Ekran3.Text = liczba03
            Ekran4.Text = liczba04
            Ekran5.Text = liczba05
            Ekran6.Text = liczba06


            '' 1 ''''''''''''''''''''''''''''''''''''''''''''''''''''
        Else

            'oblicz procenty dla liczb wszystkich z tabeli 2 i ustaw pasek

            DataGridView2.Sort(DataGridView2.Columns(1), System.ComponentModel.ListSortDirection.Descending)

            Ekran1.Text = DataGridView2.Rows(0).Cells(0).Value
            Ekran2.Text = DataGridView2.Rows(1).Cells(0).Value
            Ekran3.Text = DataGridView2.Rows(2).Cells(0).Value
            Ekran4.Text = DataGridView2.Rows(3).Cells(0).Value
            Ekran5.Text = DataGridView2.Rows(4).Cells(0).Value
            Ekran6.Text = DataGridView2.Rows(5).Cells(0).Value

            If DataGridView2.Rows(0).Cells(1).Value <> 0 Then ProgressBar1.Value = Int(((DataGridView2.Rows(0).Cells(1).Value) * 100) / zakres) : Ekran11.Text = Int(((DataGridView2.Rows(0).Cells(1).Value) * 100) / zakres) & " %"
            If DataGridView2.Rows(1).Cells(1).Value <> 0 Then ProgressBar2.Value = Int(((DataGridView2.Rows(1).Cells(1).Value) * 100) / zakres) : Ekran12.Text = Int(((DataGridView2.Rows(1).Cells(1).Value) * 100) / zakres) & " %"
            If DataGridView2.Rows(2).Cells(1).Value <> 0 Then ProgressBar3.Value = Int(((DataGridView2.Rows(2).Cells(1).Value) * 100) / zakres) : Ekran13.Text = Int(((DataGridView2.Rows(2).Cells(1).Value) * 100) / zakres) & " %"
            If DataGridView2.Rows(3).Cells(1).Value <> 0 Then ProgressBar4.Value = Int(((DataGridView2.Rows(3).Cells(1).Value) * 100) / zakres) : Ekran14.Text = Int(((DataGridView2.Rows(3).Cells(1).Value) * 100) / zakres) & " %"
            If DataGridView2.Rows(4).Cells(1).Value <> 0 Then ProgressBar5.Value = Int(((DataGridView2.Rows(4).Cells(1).Value) * 100) / zakres) : Ekran15.Text = Int(((DataGridView2.Rows(4).Cells(1).Value) * 100) / zakres) & " %"
            If DataGridView2.Rows(5).Cells(1).Value <> 0 Then ProgressBar6.Value = Int(((DataGridView2.Rows(5).Cells(1).Value) * 100) / zakres) : Ekran16.Text = Int(((DataGridView2.Rows(5).Cells(1).Value) * 100) / zakres) & " %"


            'koloruj paski
            Ekran1.BackColor = kolor(7)
            Ekran2.BackColor = kolor(7)
            Ekran3.BackColor = kolor(7)
            Ekran4.BackColor = kolor(7)
            Ekran5.BackColor = kolor(7)
            Ekran6.BackColor = kolor(7)

            ProgressBar1.ForeColor = kolor(7)
            ProgressBar2.ForeColor = kolor(7)
            ProgressBar3.ForeColor = kolor(7)
            ProgressBar4.ForeColor = kolor(7)
            ProgressBar5.ForeColor = kolor(7)
            ProgressBar6.ForeColor = kolor(7)

            'sprawdzenie czy liczba nie jest liczba wybrana i jak tak odpowiednio koloruj
            If Ekran1.Text = liczba01 Then Ekran1.BackColor = kolor(1)
            If Ekran1.Text = liczba02 Then Ekran1.BackColor = kolor(2)
            If Ekran1.Text = liczba03 Then Ekran1.BackColor = kolor(3)
            If Ekran1.Text = liczba04 Then Ekran1.BackColor = kolor(4)
            If Ekran1.Text = liczba05 Then Ekran1.BackColor = kolor(5)
            If Ekran1.Text = liczba06 Then Ekran1.BackColor = kolor(6)

            If Ekran2.Text = liczba01 Then Ekran2.BackColor = kolor(1)
            If Ekran2.Text = liczba02 Then Ekran2.BackColor = kolor(2)
            If Ekran2.Text = liczba03 Then Ekran2.BackColor = kolor(3)
            If Ekran2.Text = liczba04 Then Ekran2.BackColor = kolor(4)
            If Ekran2.Text = liczba05 Then Ekran2.BackColor = kolor(5)
            If Ekran2.Text = liczba06 Then Ekran2.BackColor = kolor(6)

            If Ekran3.Text = liczba01 Then Ekran3.BackColor = kolor(1)
            If Ekran3.Text = liczba02 Then Ekran3.BackColor = kolor(2)
            If Ekran3.Text = liczba03 Then Ekran3.BackColor = kolor(3)
            If Ekran3.Text = liczba04 Then Ekran3.BackColor = kolor(4)
            If Ekran3.Text = liczba05 Then Ekran3.BackColor = kolor(5)
            If Ekran3.Text = liczba06 Then Ekran3.BackColor = kolor(6)

            If Ekran4.Text = liczba01 Then Ekran4.BackColor = kolor(1)
            If Ekran4.Text = liczba02 Then Ekran4.BackColor = kolor(2)
            If Ekran4.Text = liczba03 Then Ekran4.BackColor = kolor(3)
            If Ekran4.Text = liczba04 Then Ekran4.BackColor = kolor(4)
            If Ekran4.Text = liczba05 Then Ekran4.BackColor = kolor(5)
            If Ekran4.Text = liczba06 Then Ekran4.BackColor = kolor(6)

            If Ekran5.Text = liczba01 Then Ekran5.BackColor = kolor(1)
            If Ekran5.Text = liczba02 Then Ekran5.BackColor = kolor(2)
            If Ekran5.Text = liczba03 Then Ekran5.BackColor = kolor(3)
            If Ekran5.Text = liczba04 Then Ekran5.BackColor = kolor(4)
            If Ekran5.Text = liczba05 Then Ekran5.BackColor = kolor(5)
            If Ekran5.Text = liczba06 Then Ekran5.BackColor = kolor(6)

            If Ekran6.Text = liczba01 Then Ekran6.BackColor = kolor(1)
            If Ekran6.Text = liczba02 Then Ekran6.BackColor = kolor(2)
            If Ekran6.Text = liczba03 Then Ekran6.BackColor = kolor(3)
            If Ekran6.Text = liczba04 Then Ekran6.BackColor = kolor(4)
            If Ekran6.Text = liczba05 Then Ekran6.BackColor = kolor(5)
            If Ekran6.Text = liczba06 Then Ekran6.BackColor = kolor(6)

        End If
    End Sub

sub WczytajPlik


        ' '' Odczyt pliku i wypelnienie danymi DataGirdView1 '''

        '  '' '' Uwaga w pliku format daty musi byc yyyy-mm-dd oraz znak oddzielajacy dane to ,

        Dim filename As String
        Dim ciag As String

        'filename = "C:\Users\Blondyn\Desktop\\lotto.dat"
        filename = Application.StartupPath & "\lotto.dat"
        ciag = My.Computer.FileSystem.ReadAllText(filename)

        'deklaracja zmiennych
        Dim ccc() As String = ciag.Split(","c)
        Dim dl As Integer = (ccc.Length / 8) - 1
        Dim licznik = 0

        'jesli tabelka nie ma wierszy dodaj wiersze
        If DataGridView1.RowCount = 0 Then DataGridView1.Rows.Add(dl + 1)

        For wiersz = 0 To dl
            For komorka = 0 To 7
                If komorka = 1 Then
                    Dim PoleDaty As Date = (ccc(licznik))
                    DataGridView1.Rows(wiersz).Cells(komorka).Value = PoleDaty
                Else
                    Dim Poleliczb As Integer = (ccc(licznik))
                    DataGridView1.Rows(wiersz).Cells(komorka).Value = Poleliczb
                End If
                licznik = licznik + 1
            Next komorka
        Next wiersz

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        WczytajPlik()

        'ustawienie zakresu tabelki 1
        zakresmax = DataGridView1.RowCount - 1
        zakresmin = 0

        'ustawienie tabelki 3 na 5 wierszy
        DataGridView3.Rows.Add(6)

        'ustawienie i wypełnienie tabelki 2 na 49 wierszy
        DataGridView2.Rows.Add(49)

        For d = 0 To DataGridView2.RowCount - 2
            DataGridView2.Rows(d).Cells(0).Value = d + 1
        Next d

        'ustawienia kolorow
        kolor(0) = Color.White
        kolor(1) = Color.Red
        kolor(2) = Color.Orange
        kolor(3) = Color.Yellow
        kolor(4) = Color.Lime
        kolor(5) = Color.Cyan
        kolor(6) = Color.CornflowerBlue
        kolor(7) = Color.Gray
        kolor(8) = Color.Teal 'zgaszony
        kolor(9) = Color.Aqua 'swieci

        'ustawienie kolorow w okienkach wyboru liczb
        NumericUpDown1.BackColor = kolor(1)
        NumericUpDown2.BackColor = kolor(2)
        NumericUpDown3.BackColor = kolor(3)
        NumericUpDown4.BackColor = kolor(4)
        NumericUpDown5.BackColor = kolor(5)
        NumericUpDown6.BackColor = kolor(6)

        'ustawienie kolorow w okienku wyboru swicz 1/0 (ikonka paskowa)
        lbl1.BackColor = kolor(1)
        lbl2.BackColor = kolor(2)
        lbl3.BackColor = kolor(3)
        lbl4.BackColor = kolor(4)
        lbl5.BackColor = kolor(5)
        lbl6.BackColor = kolor(6)

        'wypelnienie listy combo box 1 i combo box 2
        For d = 0 To DataGridView1.RowCount - 1
            ComboBox1.Items.Add(DataGridView1.Rows(d).Cells(0).Value)
            ComboBox2.Items.Add(DataGridView1.Rows(d).Cells(0).Value)
        Next d

        'wypelnienie listy combo box 3
        Dim RokStart As Date
        Dim RokStop As Date
        Dim intRokStart
        Dim intRokStop
        RokStart = DataGridView1.Rows(0).Cells(1).Value
        RokStop = DataGridView1.Rows(DataGridView1.RowCount - 1).Cells(1).Value
        intRokStart = RokStart.Year
        intRokStop = RokStop.Year
        If intRokStart = intRokStop Then
            ComboBox3.Items.Add(intRokStop)
        Else
            For a = intRokStart To intRokStop
                ComboBox3.Items.Add(a)
            Next a
        End If

        'wypelnienie listy combo box 4 
        ComboBox4.Items.Add("styczeń")
        ComboBox4.Items.Add("luty")
        ComboBox4.Items.Add("marzec")
        ComboBox4.Items.Add("kwiecień")
        ComboBox4.Items.Add("maj")
        ComboBox4.Items.Add("czerwiec")
        ComboBox4.Items.Add("lipiec")
        ComboBox4.Items.Add("sierpień")
        ComboBox4.Items.Add("wrzesień")
        ComboBox4.Items.Add("październik")
        ComboBox4.Items.Add("listopad")
        ComboBox4.Items.Add("grudzień")

        'ustawienie list zakresowych na pierwsza i ostatnia pozycje
        ComboBox1.SelectedIndex = 0
        ComboBox2.SelectedIndex = ComboBox2.Items.Count - 1

        'ustawienie combobox3 na bierzacy rok
        Dim Aktualrok As Date
        Aktualrok = Now
        ComboBox3.SelectedItem = Aktualrok.Year

        'ustawienie combobox4 na bierzacy miesiac
        Dim AktualMiesiac As Date
        AktualMiesiac = Now
        ComboBox4.SelectedIndex = AktualMiesiac.Month - 1

    End Sub

    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown1.ValueChanged

        liczba01 = NumericUpDown1.Value
        NumericUpDown2.Minimum = liczba01 + 1
        czysc()

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click


        ' sprawdzenie zeby nie wybrac wiekszej niz combobox2
        If ComboBox2.SelectedIndex <= ComboBox1.SelectedIndex Then ComboBox1.SelectedIndex = ComboBox2.SelectedIndex - 1

        zakres = ((zakresmax + 1) - zakresmin)
        licz_ogolny()

        'wlaczenie przelacznikow
        TrackBar1.Enabled = True
        TrackBar2.Enabled = True

    End Sub

    Private Sub NumericUpDown2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown2.ValueChanged

        liczba02 = NumericUpDown2.Value
        NumericUpDown3.Minimum = liczba02 + 1
        czysc()

    End Sub

    Private Sub NumericUpDown3_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown3.ValueChanged

        liczba03 = NumericUpDown3.Value
        NumericUpDown4.Minimum = liczba03 + 1
        czysc()

    End Sub

    Private Sub NumericUpDown4_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown4.ValueChanged

        liczba04 = NumericUpDown4.Value
        NumericUpDown5.Minimum = liczba04 + 1
        czysc()

    End Sub

    Private Sub NumericUpDown5_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown5.ValueChanged

        liczba05 = NumericUpDown5.Value
        NumericUpDown6.Minimum = liczba05 + 1
        czysc()

    End Sub

    Private Sub NumericUpDown6_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown6.ValueChanged

        liczba06 = NumericUpDown6.Value
        czysc()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        'ustawienie switcha do kontrolki
        SwLosowe = 1
        czysc()

        ' losowanie przypadkowych roznych 6 liczb i wypelnienie tabelki
        Dim LosLiczba(6)
       
        For d = 0 To DataGridView1.RowCount - 1

            LosLiczba(1) = (Int(Rnd() * 49)) + 1
            LosLiczba(2) = (Int(Rnd() * 49)) + 1
            LosLiczba(3) = (Int(Rnd() * 49)) + 1
            LosLiczba(4) = (Int(Rnd() * 49)) + 1
            LosLiczba(5) = (Int(Rnd() * 49)) + 1
            LosLiczba(6) = (Int(Rnd() * 49)) + 1

            Do While LosLiczba(2) = LosLiczba(1)
                LosLiczba(2) = (Int(Rnd() * 49)) + 1
            Loop

            Do While LosLiczba(3) = LosLiczba(1) Or LosLiczba(3) = LosLiczba(2)
                LosLiczba(3) = (Int(Rnd() * 49)) + 1
            Loop

            Do While LosLiczba(4) = LosLiczba(1) Or LosLiczba(4) = LosLiczba(2) Or LosLiczba(4) = LosLiczba(3)
                LosLiczba(4) = (Int(Rnd() * 49)) + 1
            Loop

            Do While LosLiczba(5) = LosLiczba(1) Or LosLiczba(5) = LosLiczba(2) Or LosLiczba(5) = LosLiczba(3) Or LosLiczba(5) = LosLiczba(4)
                LosLiczba(5) = (Int(Rnd() * 49)) + 1
            Loop

            Do While LosLiczba(6) = LosLiczba(1) Or LosLiczba(6) = LosLiczba(2) Or LosLiczba(6) = LosLiczba(3) Or LosLiczba(6) = LosLiczba(4) Or LosLiczba(6) = LosLiczba(5)
                LosLiczba(6) = (Int(Rnd() * 49)) + 1
            Loop

            'wypelnienie tabelki 3 w celu posortowania
            DataGridView3.Rows(0).Cells(0).Value = LosLiczba(1)
            DataGridView3.Rows(1).Cells(0).Value = LosLiczba(2)
            DataGridView3.Rows(2).Cells(0).Value = LosLiczba(3)
            DataGridView3.Rows(3).Cells(0).Value = LosLiczba(4)
            DataGridView3.Rows(4).Cells(0).Value = LosLiczba(5)
            DataGridView3.Rows(5).Cells(0).Value = LosLiczba(6)

            DataGridView3.Sort(DataGridView3.Columns(0), System.ComponentModel.ListSortDirection.Ascending)

            LosLiczba(1) = DataGridView3.Rows(0).Cells(0).Value
            LosLiczba(2) = DataGridView3.Rows(1).Cells(0).Value
            LosLiczba(3) = DataGridView3.Rows(2).Cells(0).Value
            LosLiczba(4) = DataGridView3.Rows(3).Cells(0).Value
            LosLiczba(5) = DataGridView3.Rows(4).Cells(0).Value
            LosLiczba(6) = DataGridView3.Rows(5).Cells(0).Value

            DataGridView1.Rows(d).Cells(2).Value = LosLiczba(1)
            DataGridView1.Rows(d).Cells(3).Value = LosLiczba(2)
            DataGridView1.Rows(d).Cells(4).Value = LosLiczba(3)
            DataGridView1.Rows(d).Cells(5).Value = LosLiczba(4)
            DataGridView1.Rows(d).Cells(6).Value = LosLiczba(5)
            DataGridView1.Rows(d).Cells(7).Value = LosLiczba(6)

        Next d

        Ekran_ilosc.Text = "Wylosowano"

    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)



    End Sub

    Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.Scroll

        licz_ogolny()

    End Sub

    Private Sub TrackBar2_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar2.Scroll

        licz_ogolny()


    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)



    End Sub

    Private Sub Ekran1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ekran1.Click

    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

        ulubione()

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged


        'sortuj dane tab1 wedlug nr
        DataGridView1.Sort(DataGridView1.Columns(0), System.ComponentModel.ListSortDirection.Ascending)

        zakresmin = ComboBox1.SelectedIndex
        DateTimePicker1.Value = DataGridView1.Rows(ComboBox1.SelectedIndex).Cells(1).Value

        'ustawienie kontrolki na wyswietlaczu
        If ComboBox1.SelectedIndex = 0 And ComboBox2.SelectedIndex = DataGridView1.RowCount - 1 Then
            UstWyswA = 1
            UstWyswB = 0
            kontrolki()
        Else
            UstWyswA = 4
            UstWyswB = 0
            kontrolki()
        End If

        czysc()
        blokuj()

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

       'sortuj dane tab1 wedlug nr
        DataGridView1.Sort(DataGridView1.Columns(0), System.ComponentModel.ListSortDirection.Ascending)

        Dim wybranyrok
        wybranyrok = ComboBox3.SelectedItem

        Dim IloscDni = 31

        'ustawienie dat zakresu ze wzgledu na wybrany rok (start)
        DateTimePicker1.Value = wybranyrok & "-01-01"

        'ustawienie dat zakresu ze wzgledu na wybrany rok (koniec)
        For b = DataGridView1.RowCount - 1 To 0 Step -1
            For c = 12 To 1 Step -1
                Select Case c
                    Case 12, 10, 8, 7, 5, 3, 1
                        IloscDni = 31
                    Case 11, 9, 6, 4
                        IloscDni = 30
                    Case 2
                        If wybranyrok / 4 = Int(wybranyrok / 4) Then
                            IloscDni = 29
                        Else
                            IloscDni = 28
                        End If
                End Select

                For a = IloscDni To 1 Step -1
                    If (DataGridView1.Rows(b).Cells(1).Value).date = wybranyrok & "-" & c & "-" & a Then
                        DateTimePicker2.Value = wybranyrok & "-" & c & "-" & a
                        'ustawienie kontrolki na wyswietlaczu
                        UstWyswA = 4
                        UstWyswB = 2
                        kontrolki()
                        Exit Sub
                    End If
                Next a
            Next c
        Next b

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged

        ' sprawdzenie zeby nie wybrac mniejszej niz combobox1
        If ComboBox2.SelectedIndex <= ComboBox1.SelectedIndex Then ComboBox2.SelectedIndex = ComboBox1.SelectedIndex + 1

        'sortuj dane tab1 wedlug nr
        DataGridView1.Sort(DataGridView1.Columns(0), System.ComponentModel.ListSortDirection.Ascending)

        zakresmax = ComboBox2.SelectedIndex
        DateTimePicker2.Value = DataGridView1.Rows(ComboBox2.SelectedIndex).Cells(1).Value


        'ustawienie kontrolki na wyswietlaczu     
        If ComboBox1.SelectedIndex = 0 And ComboBox2.SelectedIndex = DataGridView1.RowCount - 1 Then
            UstWyswA = 1
            UstWyswB = 0
            kontrolki()
        Else
            UstWyswA = 4
            UstWyswB = 0
            kontrolki()
        End If

        czysc()
        blokuj()

    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged

        'sortuj dane tab1 wedlug nr
        DataGridView1.Sort(DataGridView1.Columns(0), System.ComponentModel.ListSortDirection.Ascending)

        'jesli wybrana data mniejsza niz zakres dat w bazie
        If (DataGridView1.Rows(0).Cells(1).Value).Date >= (DateTimePicker1.Value).Date Then ComboBox1.SelectedIndex = 0 : DateTimePicker1.Value = (DataGridView1.Rows(0).Cells(1).Value).Date : czysc() : Exit Sub

        'jesli wybrana data wiekszaa niz zakres dat w bazie
        If (DataGridView1.Rows(DataGridView1.RowCount - 1).Cells(1).Value).Date <= (DateTimePicker1.Value).Date Then ComboBox1.SelectedIndex = (DataGridView1.RowCount - 2) : DateTimePicker1.Value = (DataGridView1.Rows(DataGridView1.RowCount - 2).Cells(1).Value).Date : czysc() : Exit Sub

        'jesli wybrana data w zakresie dat w bazie
        Dim a = 0
test:
        If (DataGridView1.Rows(a).Cells(1).Value).Date <> (DateTimePicker1.Value).Date And (DateTimePicker1.Value).Date < (DataGridView1.Rows(a + 1).Cells(1).Value).Date Then DateTimePicker1.Value = DateAdd("d", 1, DateTimePicker1.Value)
        If (DataGridView1.Rows(a).Cells(1).Value).Date = (DateTimePicker1.Value).Date Then ComboBox1.SelectedIndex = a : czysc() : Exit Sub
        If (DateTimePicker1.Value).Date >= (DataGridView1.Rows(a + 1).Cells(1).Value).Date Then a = a + 1
        If a = DataGridView1.RowCount - 1 Then czysc() : Exit Sub
        GoTo test

    End Sub

    Private Sub DateTimePicker2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker2.ValueChanged

        'sortuj dane tab1 wedlug nr
        DataGridView1.Sort(DataGridView1.Columns(0), System.ComponentModel.ListSortDirection.Ascending)

        'jesli wybrana data mniejsza niz zakres dat w bazie
        If (DataGridView1.Rows(0).Cells(1).Value).Date >= (DateTimePicker2.Value).Date Then ComboBox2.SelectedIndex = 1 : DateTimePicker2.Value = (DataGridView1.Rows(1).Cells(1).Value).Date : czysc() : Exit Sub

        'jesli wybrana data wiekszaa niz zakres dat w bazie
        If (DataGridView1.Rows(DataGridView1.RowCount - 1).Cells(1).Value).Date <= (DateTimePicker2.Value).Date Then ComboBox2.SelectedIndex = (DataGridView1.RowCount - 1) : DateTimePicker2.Value = (DataGridView1.Rows(DataGridView1.RowCount - 1).Cells(1).Value).Date : czysc() : Exit Sub

        'jesli wybrana data w zakresie dat w bazie
        Dim a = 0
test:
        If (DataGridView1.Rows(a).Cells(1).Value).Date <> (DateTimePicker2.Value).Date And (DateTimePicker2.Value).Date < (DataGridView1.Rows(a + 1).Cells(1).Value).Date Then DateTimePicker2.Value = DateAdd("d", 1, DateTimePicker2.Value)
        If (DataGridView1.Rows(a).Cells(1).Value).Date = (DateTimePicker2.Value).Date Then ComboBox2.SelectedIndex = a : czysc() : Exit Sub
        If (DateTimePicker2.Value).Date >= (DataGridView1.Rows(a + 1).Cells(1).Value).Date Then a = a + 1
        If a = DataGridView1.RowCount - 1 Then czysc() : Exit Sub
        GoTo test
    End Sub

    Private Sub DataGridView2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick


        'likwidacja zaznaczania w tabelach
        DataGridView2.ClearSelection()

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click

        'zaswiecenie kontrolki na wyswietlaczu
        UstWyswA = 1
        UstWyswB = 0
        kontrolki()

        'ustawienie list zakresowych na pierwsza i ostatnia pozycje
        ComboBox1.SelectedIndex = 0
        ComboBox2.SelectedIndex = ComboBox2.Items.Count - 1

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click

        'sortuj dane tab1 wedlug nr
        DataGridView1.Sort(DataGridView1.Columns(0), System.ComponentModel.ListSortDirection.Ascending)

        Dim wybranymiesiac
        wybranymiesiac = ComboBox4.SelectedIndex + 1

        Dim wybranyrok
        wybranyrok = ComboBox3.SelectedItem

        Dim IloscDni = 31
        Dim c

        'ustawienie dat zakresu ze wzgledu na wybrany rok (startowa)
        DateTimePicker1.Value = wybranyrok & "-" & wybranymiesiac & "-01"

        'ustawienie dat zakresu (koncowa)
        For b = DataGridView1.RowCount - 1 To 0 Step -1

            c = wybranymiesiac
            If c = 12 Or c = 10 Or c = 8 Or c = 7 Or c = 5 Or c = 3 Or c = 1 Then IloscDni = 31
            If c = 11 Or c = 9 Or c = 6 Or c = 4 Then IloscDni = 30
            If c = 2 And wybranyrok / 4 = Int(wybranyrok / 4) Then IloscDni = 29
            If c = 2 And wybranyrok / 4 <> Int(wybranyrok / 4) Then IloscDni = 28

            For a = IloscDni To 1 Step -1
                If (DataGridView1.Rows(b).Cells(1).Value).date = wybranyrok & "-" & c & "-" & a Then
                    DateTimePicker2.Value = wybranyrok & "-" & c & "-" & a
                    'ustawienie kontrolki na wyswietlaczu
                    UstWyswA = 4
                    UstWyswB = 3
                    kontrolki()
                    Exit Sub
                End If
            Next a
        Next b
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

        'likwidacja zaznaczania w tabelach
        DataGridView1.ClearSelection()

    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        'ustawienie swicza do kontrolki
        SwLosowe = 0

        WczytajPlik()

        czysc()

        Ekran_ilosc.Text = "Wczytano dane"

    End Sub

    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        ' losowanie przypadkowych roznych 6 liczb i wypelnienie tabelki
        Dim LosLiczba(6)

            LosLiczba(1) = (Int(Rnd() * 49)) + 1
            LosLiczba(2) = (Int(Rnd() * 49)) + 1
            LosLiczba(3) = (Int(Rnd() * 49)) + 1
            LosLiczba(4) = (Int(Rnd() * 49)) + 1
            LosLiczba(5) = (Int(Rnd() * 49)) + 1
            LosLiczba(6) = (Int(Rnd() * 49)) + 1

            Do While LosLiczba(2) = LosLiczba(1)
                LosLiczba(2) = (Int(Rnd() * 49)) + 1
            Loop

            Do While LosLiczba(3) = LosLiczba(1) Or LosLiczba(3) = LosLiczba(2)
                LosLiczba(3) = (Int(Rnd() * 49)) + 1
            Loop

            Do While LosLiczba(4) = LosLiczba(1) Or LosLiczba(4) = LosLiczba(2) Or LosLiczba(4) = LosLiczba(3)
                LosLiczba(4) = (Int(Rnd() * 49)) + 1
            Loop

            Do While LosLiczba(5) = LosLiczba(1) Or LosLiczba(5) = LosLiczba(2) Or LosLiczba(5) = LosLiczba(3) Or LosLiczba(5) = LosLiczba(4)
                LosLiczba(5) = (Int(Rnd() * 49)) + 1
            Loop

            Do While LosLiczba(6) = LosLiczba(1) Or LosLiczba(6) = LosLiczba(2) Or LosLiczba(6) = LosLiczba(3) Or LosLiczba(6) = LosLiczba(4) Or LosLiczba(6) = LosLiczba(5)
                LosLiczba(6) = (Int(Rnd() * 49)) + 1
            Loop

        'wypelnienie tabelki 3 w celu posortowania
        DataGridView3.Rows(0).Cells(0).Value = LosLiczba(1)
        DataGridView3.Rows(1).Cells(0).Value = LosLiczba(2)
        DataGridView3.Rows(2).Cells(0).Value = LosLiczba(3)
        DataGridView3.Rows(3).Cells(0).Value = LosLiczba(4)
        DataGridView3.Rows(4).Cells(0).Value = LosLiczba(5)
        DataGridView3.Rows(5).Cells(0).Value = LosLiczba(6)

        DataGridView3.Sort(DataGridView3.Columns(0), System.ComponentModel.ListSortDirection.Ascending)

        LosLiczba(1) = DataGridView3.Rows(0).Cells(0).Value
        LosLiczba(2) = DataGridView3.Rows(1).Cells(0).Value
        LosLiczba(3) = DataGridView3.Rows(2).Cells(0).Value
        LosLiczba(4) = DataGridView3.Rows(3).Cells(0).Value
        LosLiczba(5) = DataGridView3.Rows(4).Cells(0).Value
        LosLiczba(6) = DataGridView3.Rows(5).Cells(0).Value

        ' ustawienie losowych liczb w wyborze liczb obstawianych
        NumericUpDown1.Value = LosLiczba(1)
        NumericUpDown2.Value = LosLiczba(2)
        NumericUpDown3.Value = LosLiczba(3)
        NumericUpDown4.Value = LosLiczba(4)
        NumericUpDown5.Value = LosLiczba(5)
        NumericUpDown6.Value = LosLiczba(6)

        Ekran_ilosc.Text = LosLiczba(1) & " : " & LosLiczba(2) & " : " & LosLiczba(3) & " : " & LosLiczba(4) & " : " & LosLiczba(5) & " : " & LosLiczba(6)

    End Sub
End Class
