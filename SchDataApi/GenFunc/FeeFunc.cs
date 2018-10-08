using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchDataApi.GenFunc
{
    public static class FeeFunc
    {
        //        public boolean tCalculateDues(int tUniReg  ,  double tForPeriod   , string  tCategory  , string  tClass   , double  tFeeStartDate   )
        //        {
        //          string MySql ="";
        //          double tFee = 0;
        //            double tStdFee = 0;
        //            double tReceipt = 0;
        //            double tTransportFee = 0;
        //            double TmpDate = 0;
        //            bool isDues = false;
        //            double TrnsTillDate = 0;
        //            double PreForPeriod = 0;
        //            double tStdLateFee = 0;
        //            int TransMonth = 1;
        //            int tDuesAmt = 0;
        //            //If ckbSchoolFeeDues.Checked Then
        //            If (tForPeriod >= tFeeStartDate)
        //            { MySql = "SELECT SUM(Amount) From DynaFee WITH (NOLOCK)  "
        //                MySql = MySql + " WHERE Dormant=0 AND ForMonth=" + tForPeriod
        //                MySql = MySql + " AND StdCategory='" + tCategory + "'"
        //                MySql = MySql + " AND SessionName='" + cbSession.SelectedItem + "'"
        //                MySql = MySql + " AND ForClass='" + tClass + "'"
        //                DataCom2.CommandText = MySql
        //                If Not myReader2.IsClosed Then myReader2.Close()
        //                myReader2 = DataCom2.ExecuteReader
        //                If myReader2.HasRows Then
        //                    myReader2.Read()
        //                    If Not myReader2.IsDBNull(0) Then tFee = myReader2.GetValue(0)
        //                End If
        //                myReader2.Close()
        //                MySql = "SELECT  SUM(Amount) FROM StdFee WITH (NOLOCK) "
        //                MySql = MySql + " WHERE Dormant=0 AND ForMonth=" + tForPeriod
        //                MySql = MySql + " AND UniReg=" + tUniReg
        //                MySql = MySql + " AND Caption NOT IN ('LateFee','TransportLateFee','Transport')"
        //                DataCom2.CommandText = MySql
        //                If Not myReader2.IsClosed Then myReader2.Close()
        //                myReader2 = DataCom2.ExecuteReader
        //                If myReader2.HasRows Then
        //                    myReader2.Read()
        //                    If Not myReader2.IsDBNull(0) Then tStdFee = myReader2.GetValue(0)
        //                End If

        //                tFee = tFee + tStdFee
        //                tReceipt = 0
        //                If tFee > 0 Then
        //                    MySql = "SELECT  SUM(AmountPaid) FROM ReceiptDetails WITH (NOLOCK) "
        //                    MySql = MySql + " WHERE Dormant=0 AND ForPeriod=" + tForPeriod
        //                    MySql = MySql + " AND UniReg=" + tUniReg
        //                    MySql = MySql + " AND FEEnWAHead NOT IN ('LateFee','TransportLateFee','Transport')"
        //                    DataCom2.CommandText = MySql
        //                    If Not myReader2.IsClosed Then myReader2.Close()
        //                    myReader2 = DataCom2.ExecuteReader
        //                    If myReader2.HasRows Then
        //                        myReader2.Read()
        //                        If Not myReader2.IsDBNull(0) Then tReceipt = myReader2.GetValue(0)
        //                    End If
        //                    If (tFee -tReceipt > 0) Then
        //                        '''''Add Late Fee..................................................................
        //                        If IsFeePaidForMonthLFD(tUniReg, Date.FromOADate(tForPeriod)) = False 
        //                    { 

        //                            MySql = " SELECT Amount From LateConFee WITH (NOLOCK)";
        //                            MySql = MySql + " WHERE ForMonth = " + tForPeriod '<= " + BillDate  'GetFeeDate(cbFeeName.SelectedItem, Pcls, MyCurrentSession);
        //                            MySql = MySql + " AND SessionName = '" + RepSplChr(MyCurrentSession) + "'";
        //                            MySql = MySql + " AND ForClass = '" + RepSplChr(tClass.Trim) + "'";
        //                            MySql = MySql + " AND LateDate <= " + Int(dtpDODuesReport.Value.ToOADate);
        //                            MySql = MySql + " AND StdCategory = '" + RepSplChr(tCategory) + "'";
        //                            MySql = MySql + " AND Dormant = 0";
        //                            MySql = MySql + " AND dBID = " + mdBID;
        //                            MySql = MySql + " ORDER BY LateDate Desc";

        //                            DataCom2.CommandText = MySql;
        //                            If ! myReader2.IsClosed { myReader2.Close(); }

        //                            myReader2 = DataCom2.ExecuteReader;
        //                            If (myReader2.HasRows) {
        //                    myReader2.Read();
        //                    If !myReader2.IsDBNull(0) { tStdLateFee = myReader2.GetValue(0); }
        //                }
        //                        myReader2.Close()

        //                        tDuesAmt = tFee - tReceipt + tStdLateFee
        //                        isDues = True
        //                    End If
        //                    'End If
        //                End If
        //}
        //            //ElseIf ckbTransportDues.Checked Then

        ////                    Else
        ////End


        //    }

        //    //    If tForPeriod >= tFeeStartDate Then
        //    //            MySql = "SELECT SUM(Amount) From DynaFee WITH (NOLOCK)  "
        //    //            MySql = MySql + " WHERE Dormant=0 AND ForMonth=" + tForPeriod
        //    //            MySql = MySql + " AND StdCategory='" + tCategory + "'"
        //    //            MySql = MySql + " AND SessionName='" + cbSession.SelectedItem + "'"
        //    //            MySql = MySql + " AND ForClass='" + tClass + "'"
        //    //            DataCom2.CommandText = MySql
        //    //            If Not myReader2.IsClosed Then myReader2.Close()
        //    //            myReader2 = DataCom2.ExecuteReader
        //    //            If myReader2.HasRows Then
        //    //                myReader2.Read()
        //    //                If Not myReader2.IsDBNull(0) Then tFee = myReader2.GetValue(0)
        //    //            End If
        //    //            myReader2.Close()
        //    //            MySql = "SELECT  SUM(Amount) FROM StdFee WITH (NOLOCK) "
        //    //            MySql = MySql + " WHERE Dormant=0 AND ForMonth=" + tForPeriod
        //    //            MySql = MySql + " AND UniReg=" + tUniReg
        //    //            MySql = MySql + " AND Caption NOT IN ('LateFee','TransportLateFee','Transport')"
        //    //            DataCom2.CommandText = MySql
        //    //            If Not myReader2.IsClosed Then myReader2.Close()
        //    //            myReader2 = DataCom2.ExecuteReader
        //    //            If myReader2.HasRows Then
        //    //                myReader2.Read()
        //    //                If Not myReader2.IsDBNull(0) Then tStdFee = myReader2.GetValue(0)
        //    //            End If

        //    //            tFee = tFee + tStdFee
        //    //            tReceipt = 0
        //    //            If tFee > 0 Then
        //    //                MySql = "SELECT  SUM(AmountPaid) FROM ReceiptDetails WITH (NOLOCK) "
        //    //                MySql = MySql + " WHERE Dormant=0 AND ForPeriod=" + tForPeriod
        //    //                MySql = MySql + " AND UniReg=" + tUniReg
        //    //                MySql = MySql + " AND FEEnWAHead NOT IN ('LateFee','TransportLateFee','Transport')"
        //    //                DataCom2.CommandText = MySql
        //    //                If Not myReader2.IsClosed Then myReader2.Close()
        //    //                myReader2 = DataCom2.ExecuteReader
        //    //                If myReader2.HasRows Then
        //    //                    myReader2.Read()
        //    //                    If Not myReader2.IsDBNull(0) Then tReceipt = myReader2.GetValue(0)
        //    //                End If
        //    //                'If tReceipt <= 0 Then
        //    //                '    MySql = "SELECT  SUM(Amount) FROM StdFee WITH (NOLOCK) "
        //    //                '    MySql = MySql + " WHERE Dormant=0 AND ForMonth=" + tForPeriod
        //    //                '    MySql = MySql + " AND UniReg=" + tUniReg
        //    //                '    MySql = MySql + " AND Caption NOT IN ('LateFee','TransportLateFee')"
        //    //                '    DataCom2.CommandText = MySql
        //    //                '    If Not myReader2.IsClosed Then myReader2.Close()
        //    //                '    myReader2 = DataCom2.ExecuteReader
        //    //                '    If myReader2.HasRows Then
        //    //                '        myReader2.Read()
        //    //                '        If Not myReader2.IsDBNull(0) Then tStdFee = myReader2.GetValue(0)
        //    //                '    End If
        //    //                '    If tFee + tStdFee > 0 Then
        //    //                '        isDues = True
        //    //                '    End If
        //    //                'Else
        //    //                If tFee - tReceipt > 0 Then
        //    //                    '''''Add Late Fee..................................................................
        //    //                    If IsFeePaidForMonthLFD(tUniReg, Date.FromOADate(tForPeriod)) = False Then
        //    //                        MySql = " SELECT Amount From LateConFee WITH (NOLOCK)"
        //    //                        MySql = MySql + " WHERE ForMonth = " + tForPeriod '<= " + BillDate  'GetFeeDate(cbFeeName.SelectedItem, Pcls, MyCurrentSession)
        //    //                        MySql = MySql + " AND SessionName = '" + RepSplChr(MyCurrentSession) + "'"
        //    //                        MySql = MySql + " AND ForClass = '" + RepSplChr(tClass.Trim) + "'"
        //    //                        MySql = MySql + " AND LateDate <= " + Int(dtpDODuesReport.Value.ToOADate)
        //    //                        MySql = MySql + " AND StdCategory = '" + RepSplChr(tCategory) + "'"
        //    //                        MySql = MySql + " AND Dormant = 0"
        //    //                        MySql = MySql + " AND dBID = " + mdBID
        //    //                        MySql = MySql + " ORDER BY LateDate Desc"

        //    //                        DataCom2.CommandText = MySql
        //    //                        If Not myReader2.IsClosed Then myReader2.Close()

        //    //                        myReader2 = DataCom2.ExecuteReader
        //    //                        If myReader2.HasRows Then
        //    //                            myReader2.Read()
        //    //                            If Not myReader2.IsDBNull(0) Then tStdLateFee = myReader2.GetValue(0)
        //    //                        End If
        //    //                    End If
        //    //                    myReader2.Close()

        //    //                    tDuesAmt = tFee - tReceipt + tStdLateFee
        //    //                    isDues = True
        //    //                End If
        //    //                'End If
        //    //            End If
        //    //        End If
        //    //    ElseIf ckbTransportDues.Checked Then
        //    //        MySql = "Select Max(ForMonth) From DynaFee WITH (NOLOCK)  "
        //    //        MySql = MySql + " WHERE ForMonth < " + Int(tForPeriod)
        //    //        MySql = MySql + " AND ForClass = '" + RepSplChr(tClass) + "'"
        //    //        MySql = MySql + " AND StdCategory = '" + RepSplChr(tCategory) + "'"
        //    //        MySql = MySql + " AND SessionName = '" + RepSplChr(cbSession.SelectedItem) + "'"
        //    //        MySql = MySql + " AND Dormant=0 "
        //    //        MySql = MySql + " AND dBID = " + mdBID
        //    //        If Not myReader2.IsClosed Then myReader2.Close()
        //    //        DataCom2.CommandText = MySql
        //    //        myReader2 = DataCom2.ExecuteReader
        //    //        If myReader2.HasRows Then
        //    //            myReader2.Read()
        //    //            If Not myReader2.IsDBNull(0) Then
        //    //                PreForPeriod = myReader2.GetValue(0)
        //    //            Else
        //    //                PreForPeriod = SessionStartDate.ToOADate
        //    //            End If
        //    //        Else
        //    //            PreForPeriod = SessionStartDate.ToOADate
        //    //        End If

        //    //        myReader2.Close()

        //    //        MySql = "Select min(ForMonth) From DynaFee WITH (NOLOCK)  "
        //    //        MySql = MySql + " WHERE ForMonth > " + Int(tForPeriod)
        //    //        MySql = MySql + " AND ForClass = '" + RepSplChr(tClass) + "'"
        //    //        MySql = MySql + " AND StdCategory = '" + RepSplChr(tCategory) + "'"
        //    //        MySql = MySql + " AND SessionName = '" + RepSplChr(cbSession.SelectedItem) + "'"
        //    //        MySql = MySql + " AND Dormant=0 "
        //    //        MySql = MySql + " AND dBID = " + mdBID
        //    //        If Not myReader2.IsClosed Then myReader2.Close()
        //    //        DataCom2.CommandText = MySql
        //    //        myReader2 = DataCom2.ExecuteReader
        //    //        If myReader2.HasRows Then
        //    //            myReader2.Read()
        //    //            If Not myReader2.IsDBNull(0) Then
        //    //                TrnsTillDate = myReader2.GetValue(0)
        //    //            Else
        //    //                TrnsTillDate = SessionEndDate.ToOADate
        //    //            End If
        //    //        Else
        //    //            TrnsTillDate = SessionEndDate.ToOADate
        //    //        End If
        //    //        myReader2.Close()
        //    //        Dim tTmpDate As Date = Date.FromOADate(tForPeriod)
        //    //        Dim nRouteID As Integer = -1
        //    //        Do While tTmpDate<Date.FromOADate(TrnsTillDate)
        //    //          nRouteID = -1
        //    //            MySql = " SELECT  StopID, DateFrom  From Conveyance WITH (NOLOCK)  "
        //    //            MySql = MySql + " WHERE UniReg = " + tUniReg
        //    //            MySql = MySql + " AND DateFrom <= " + Int(tTmpDate.ToOADate)
        //    //            '   MySql = MySql + " AND DateFrom > " + Int(PreForPeriod - 1)
        //    //            MySql = MySql + " AND Dormant =0"
        //    //            MySql = MySql + " And dBID = " + mdBID
        //    //            MySql = MySql + " ORDER BY DateFrom DESC"
        //    //            DataCom2.CommandText = MySql
        //    //            If Not myReader2.IsClosed Then myReader2.Close()
        //    //            myReader2 = DataCom2.ExecuteReader
        //    //            If myReader2.HasRows Then
        //    //                myReader2.Read()
        //    //                nRouteID = myReader2.GetValue(0)
        //    //            End If
        //    //            myReader2.Close()
        //    //            If nRouteID<> -1 Then
        //    //                MySql = " SELECT  MonthlyFare, FareFromMonth  FROM Stops WITH (NOLOCK) "
        //    //                MySql = MySql + " WHERE StopID = " + nRouteID
        //    //                MySql = MySql + " AND FareFromMonth <= " + Int(tTmpDate.ToOADate)
        //    //                MySql = MySql + " AND Dormant = 0 "
        //    //                MySql = MySql + " And dBID = " + mdBID
        //    //                MySql = MySql + " ORDER BY FareFromMonth DESC "
        //    //                DataCom2.CommandText = MySql
        //    //                If Not myReader2.IsClosed Then myReader2.Close()
        //    //                myReader2 = DataCom2.ExecuteReader
        //    //                If myReader2.HasRows Then
        //    //                    myReader2.Read()
        //    //                    tFee = tFee + myReader2.GetValue(0)
        //    //                    'FeeTotal = FeeTotal + myReader.GetValue(0)
        //    //                    J = J + 1
        //    //                End If
        //    //                myReader2.Close()
        //    //            End If
        //    //            tTmpDate = tTmpDate.AddMonths(1)
        //    //        Loop
        //    //        MySql = "SELECT  SUM(Amount) FROM StdFee WITH (NOLOCK) "
        //    //        MySql = MySql + " WHERE Dormant=0 AND ForMonth=" + tForPeriod
        //    //        MySql = MySql + " AND UniReg=" + tUniReg
        //    //        MySql = MySql + " AND Caption NOT IN ('LateFee','TransportLateFee')"
        //    //        MySql = MySql + " AND Caption IN ('Transport')"
        //    //        DataCom2.CommandText = MySql
        //    //        If Not myReader2.IsClosed Then myReader2.Close()
        //    //        myReader2 = DataCom2.ExecuteReader
        //    //        If myReader2.HasRows Then
        //    //            myReader2.Read()
        //    //            If Not myReader2.IsDBNull(0) Then tStdFee = myReader2.GetValue(0)
        //    //        End If
        //    //        tFee = tFee + tStdFee

        //    //        If tFee > 0 Then

        //    //            MySql = "SELECT  SUM(AmountPaid) FROM ReceiptDetails WITH (NOLOCK) "
        //    //            MySql = MySql + " WHERE Dormant=0 AND ForPeriod>=" + Int(tForPeriod)
        //    //            MySql = MySql + " AND ForPeriod <" + Int(TrnsTillDate)
        //    //            MySql = MySql + " AND UniReg=" + tUniReg
        //    //            MySql = MySql + " AND FEEnWAHead NOT IN ('LateFee','TransportLateFee')"
        //    //            MySql = MySql + " AND FEEnWAHead IN ('Transport')"
        //    //            DataCom2.CommandText = MySql
        //    //            If Not myReader2.IsClosed Then myReader2.Close()
        //    //            myReader2 = DataCom2.ExecuteReader
        //    //            If myReader2.HasRows Then
        //    //                myReader2.Read()
        //    //                If Not myReader2.IsDBNull(0) Then tReceipt = myReader2.GetValue(0)
        //    //            End If
        //    //            'If tReceipt <= 0 Then

        //    //            'Else
        //    //            If tFee - tReceipt > 0 Then
        //    //                tDuesAmt = tFee - tReceipt
        //    //                isDues = True
        //    //            End If
        //    //            'End If

        //    //        End If
        //    //    Else
        //    //        If tForPeriod >= tFeeStartDate Then
        //    //            MySql = "SELECT SUM(Amount) From DynaFee WITH (NOLOCK)  "
        //    //            MySql = MySql + " WHERE Dormant=0 AND ForMonth=" + tForPeriod
        //    //            MySql = MySql + " AND StdCategory='" + tCategory + "'"
        //    //            MySql = MySql + " AND SessionName='" + cbSession.SelectedItem + "'"
        //    //            MySql = MySql + " AND ForClass='" + tClass + "'"
        //    //            DataCom2.CommandText = MySql
        //    //            If Not myReader2.IsClosed Then myReader2.Close()
        //    //            myReader2 = DataCom2.ExecuteReader
        //    //            If myReader2.HasRows Then
        //    //                myReader2.Read()
        //    //                If Not myReader2.IsDBNull(0) Then tFee = myReader2.GetValue(0)
        //    //            End If
        //    //            myReader2.Close()
        //    //            '''' Add Transport Fees
        //    //            MySql = "Select Max(ForMonth) From DynaFee WITH (NOLOCK)  "
        //    //            MySql = MySql + " WHERE ForMonth < " + Int(tForPeriod)
        //    //            MySql = MySql + " AND ForClass = '" + RepSplChr(tClass) + "'"
        //    //            MySql = MySql + " AND StdCategory = '" + RepSplChr(tCategory) + "'"
        //    //            MySql = MySql + " AND SessionName = '" + RepSplChr(cbSession.SelectedItem) + "'"
        //    //            MySql = MySql + " AND Dormant=0 "
        //    //            MySql = MySql + " AND dBID = " + mdBID
        //    //            If Not myReader2.IsClosed Then myReader2.Close()
        //    //            DataCom2.CommandText = MySql
        //    //            myReader2 = DataCom2.ExecuteReader
        //    //            If myReader2.HasRows Then
        //    //                myReader2.Read()
        //    //                If Not myReader2.IsDBNull(0) Then
        //    //                    PreForPeriod = myReader2.GetValue(0)
        //    //                Else
        //    //                    PreForPeriod = SessionStartDate.ToOADate
        //    //                End If
        //    //            Else
        //    //                PreForPeriod = SessionStartDate.ToOADate
        //    //            End If

        //    //            myReader2.Close()

        //    //            MySql = "Select min(ForMonth) From DynaFee WITH (NOLOCK)  "
        //    //            MySql = MySql + " WHERE ForMonth > " + Int(tForPeriod)
        //    //            MySql = MySql + " AND ForClass = '" + RepSplChr(tClass) + "'"
        //    //            MySql = MySql + " AND StdCategory = '" + RepSplChr(tCategory) + "'"
        //    //            MySql = MySql + " AND SessionName = '" + RepSplChr(cbSession.SelectedItem) + "'"
        //    //            MySql = MySql + " AND Dormant=0 "
        //    //            MySql = MySql + " AND dBID = " + mdBID
        //    //            If Not myReader2.IsClosed Then myReader2.Close()
        //    //            DataCom2.CommandText = MySql
        //    //            myReader2 = DataCom2.ExecuteReader
        //    //            If myReader2.HasRows Then
        //    //                myReader2.Read()
        //    //                If Not myReader2.IsDBNull(0) Then
        //    //                    TrnsTillDate = myReader2.GetValue(0)
        //    //                Else
        //    //                    TrnsTillDate = tForPeriod + 1 'SessionEndDate.ToOADate
        //    //                End If
        //    //            Else
        //    //                TrnsTillDate = tForPeriod + 1 'SessionEndDate.ToOADate
        //    //            End If
        //    //            myReader2.Close()
        //    //            Dim tTmpDate As Date = Date.FromOADate(tForPeriod)
        //    //            Dim nRouteID As Integer = -1
        //    //            Do While tTmpDate<Date.FromOADate(TrnsTillDate)
        //    //              nRouteID = -1
        //    //                MySql = " SELECT  StopID, DateFrom  From Conveyance WITH (NOLOCK)  "
        //    //                MySql = MySql + " WHERE UniReg = " + tUniReg
        //    //                MySql = MySql + " AND DateFrom <= " + Int(tTmpDate.ToOADate)
        //    //                'MySql = MySql + " AND DateFrom > " + Int(PreForPeriod - 1)
        //    //                MySql = MySql + " AND Dormant =0"
        //    //                MySql = MySql + " And dBID = " + mdBID
        //    //                MySql = MySql + " ORDER BY DateFrom DESC"
        //    //                DataCom2.CommandText = MySql
        //    //                If Not myReader2.IsClosed Then myReader2.Close()
        //    //                myReader2 = DataCom2.ExecuteReader
        //    //                If myReader2.HasRows Then
        //    //                    myReader2.Read()
        //    //                    nRouteID = myReader2.GetValue(0)
        //    //                End If
        //    //                myReader2.Close()
        //    //                If nRouteID<> -1 Then
        //    //                    MySql = " SELECT  MonthlyFare, FareFromMonth  FROM Stops WITH (NOLOCK) "
        //    //                    MySql = MySql + " WHERE StopID = " + nRouteID
        //    //                    MySql = MySql + " AND FareFromMonth <= " + Int(tTmpDate.ToOADate)
        //    //                    MySql = MySql + " AND Dormant = 0 "
        //    //                    MySql = MySql + " And dBID = " + mdBID
        //    //                    MySql = MySql + " ORDER BY FareFromMonth DESC "
        //    //                    DataCom2.CommandText = MySql
        //    //                    If Not myReader2.IsClosed Then myReader2.Close()
        //    //                    myReader2 = DataCom2.ExecuteReader
        //    //                    If myReader2.HasRows Then
        //    //                        myReader2.Read()
        //    //                        tFee = tFee + myReader2.GetValue(0)
        //    //                        'FeeTotal = FeeTotal + myReader.GetValue(0)
        //    //                        J = J + 1
        //    //                    End If
        //    //                    myReader2.Close()
        //    //                End If
        //    //                tTmpDate = tTmpDate.AddMonths(1)
        //    //            Loop


        //    //            MySql = "SELECT  SUM(Amount) FROM StdFee WITH (NOLOCK) "
        //    //            MySql = MySql + " WHERE Dormant=0 AND ForMonth=" + tForPeriod
        //    //            MySql = MySql + " AND UniReg=" + tUniReg
        //    //            MySql = MySql + " AND Caption NOT IN ('LateFee','TransportLateFee')"
        //    //            DataCom2.CommandText = MySql
        //    //            If Not myReader2.IsClosed Then myReader2.Close()
        //    //            myReader2 = DataCom2.ExecuteReader
        //    //            If myReader2.HasRows Then
        //    //                myReader2.Read()
        //    //                If Not myReader2.IsDBNull(0) Then tStdFee = myReader2.GetValue(0)
        //    //            End If

        //    //            tFee = tFee + tStdFee

        //    //            tReceipt = 0
        //    //            If tFee > 0 Then
        //    //                MySql = "SELECT  SUM(AmountPaid) FROM ReceiptDetails WITH (NOLOCK) "
        //    //                MySql = MySql + " WHERE Dormant=0 AND ForPeriod=" + tForPeriod
        //    //                MySql = MySql + " AND ForPeriod <" + Int(TrnsTillDate)
        //    //                MySql = MySql + " AND UniReg=" + tUniReg
        //    //                MySql = MySql + " AND FEEnWAHead NOT IN ('LateFee','TransportLateFee')"
        //    //                DataCom2.CommandText = MySql
        //    //                If Not myReader2.IsClosed Then myReader2.Close()
        //    //                myReader2 = DataCom2.ExecuteReader
        //    //                If myReader2.HasRows Then
        //    //                    myReader2.Read()
        //    //                    If Not myReader2.IsDBNull(0) Then tReceipt = myReader2.GetValue(0)
        //    //                End If

        //    //                'If tReceipt <= 0 Then
        //    //                '    MySql = "SELECT  SUM(Amount) FROM StdFee WITH (NOLOCK) "
        //    //                '    MySql = MySql + " WHERE Dormant=0 AND ForMonth=" + tForPeriod
        //    //                '    MySql = MySql + " AND UniReg=" + tUniReg
        //    //                '    MySql = MySql + " AND Caption NOT IN ('LateFee','TransportLateFee')"
        //    //                '    DataCom2.CommandText = MySql
        //    //                '    If Not myReader2.IsClosed Then myReader2.Close()
        //    //                '    myReader2 = DataCom2.ExecuteReader
        //    //                '    If myReader2.HasRows Then
        //    //                '        myReader2.Read()
        //    //                '        If Not myReader2.IsDBNull(0) Then tStdFee = myReader2.GetValue(0)
        //    //                '    End If
        //    //                '    If tFee + tStdFee > 0 Then
        //    //                '        isDues = True
        //    //                '    End If
        //    //                'Else
        //    //                If tFee - tReceipt > 0 Then
        //    //                    If IsFeePaidForMonthLF(tUniReg, Date.FromOADate(tForPeriod)) = False Then
        //    //                        MySql = " SELECT Amount From LateConFee WITH (NOLOCK)"
        //    //                        MySql = MySql + " WHERE ForMonth = " + tForPeriod '<= " + BillDate  'GetFeeDate(cbFeeName.SelectedItem, Pcls, MyCurrentSession)
        //    //                        MySql = MySql + " AND SessionName = '" + RepSplChr(MyCurrentSession) + "'"
        //    //                        MySql = MySql + " AND ForClass = '" + RepSplChr(tClass.Trim) + "'"
        //    //                        MySql = MySql + " AND LateDate <= " + Int(dtpDODuesReport.Value.ToOADate)
        //    //                        MySql = MySql + " AND StdCategory = '" + RepSplChr(tCategory) + "'"
        //    //                        MySql = MySql + " AND Dormant = 0"
        //    //                        MySql = MySql + " AND dBID = " + mdBID
        //    //                        MySql = MySql + " ORDER BY LateDate Desc"

        //    //                        DataCom2.CommandText = MySql
        //    //                        If Not myReader2.IsClosed Then myReader2.Close()

        //    //                        myReader2 = DataCom2.ExecuteReader
        //    //                        If myReader2.HasRows Then
        //    //                            myReader2.Read()
        //    //                            If Not myReader2.IsDBNull(0) Then tStdLateFee = myReader2.GetValue(0)
        //    //                        End If
        //    //                    End If
        //    //                    myReader2.Close()

        //    //                    tDuesAmt = tFee - tReceipt + tStdLateFee
        //    //                    isDues = True
        //    //                End If
        //    //                'End If
        //    //            End If
        //    //        End If

        //    //    End If
        //    //    Return isDues
        //    //End Function

        //    }
    }
}
