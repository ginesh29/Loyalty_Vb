Imports Microsoft.VisualBasic
Imports System.Data
Imports CrystalDecisions.CrystalReports.Engine
Imports Microsoft.Reporting.WebForms

Public Class clsBllLoyalty
#Region "Members"
    Private _Cd As String
    Private _Des As String
    Private _FName As String
    Private _LName As String
    Private _MName As String
    Private _Gender As Boolean
    Private _BirthDt As DateTime
    Private _Addr1 As String
    Private _Addr2 As String
    Private _Addr3 As String
    Private _CustCo As Integer
    Private _CustArea As Integer
    Private _Religion As Integer

    Private _Phone As String
    Private _Fax As String
    Private _Mobile As String
    Private _Email As String
    Private _UID As String
    Private _Curr As String
    Private _Country As String
    Private _CountryName As String
    Private _Region As String
    Private _CustGrp As String
    Private _CardType As String
    Private _Appr_Points As Double
    Private _Redm_Points As Double
    Private _Unappr_Points As Double
    Private _Last_PurDt As DateTime
    Private _Active As Boolean
    Private _BlackListed As Boolean
    Private _CardIssued As Boolean
    Private _Remarks As String
    Private _EntryBy As String
    Private _EntryDt As DateTime
    Private _EditBy As String
    Private _EditDt As DateTime

    Private _CompanyId As String
    Private _CompanyName As String
    Private _CustGrpCd As String

    Private _IDType As String


    'General
    Private _ddl As DropDownList
    Private _gv As GridView
    Private _ConnLocalSvr As String

    '----Redemption
    Private _ItemCode As String
    Private _TrnId As Integer
    Private _TrnDate As DateTime
    Private _Narration As String
    Private _RefDocNo As String
    Private _ItemName As String
    Private _Qty As Integer
    Private _BaseQty As Integer
    Private _Unit As String
    Private _DocStatus As String
    Private _MaxRedeemPnts As Integer
    Private _TrnAutoNo As Integer
    Private _LocCd As String 'Nitheesh



    '--Login
    Private _Username As String
    Private _pwd As String
    Private _pwdNew As String
    Private _UserType As Integer
    Private _errorMsg As String

    '--Sales Rule
    Private _RuleId As Integer
    Private _FromDt As Date
    Private _ToDt As Date
    Private _Points As Decimal
    Private _DiscPerc As Decimal

    Private _Srl As Integer
    Private _Grp As String
    Private _SubGrp As String
    Private _Category As String
    Private _Amt As Decimal

    'Red Rules
    'Private _PointsTo As Decimal
    Private _Cost As Decimal

    '--Reports
    Private _Rpt As ReportDocument
    Private _Qry As String
    Private _SelRpt As String
    Private _RptVr As ReportViewer

    'Settings
    Private _UpdatingInterval As Integer

    'Company
    Private _DBName As String
    Private _ServerName As String


    'Profession
    Private _ProfessionId As Integer
    Private _Profession As String

    Private _Area As String


    'Failed Trans
    Private _BillNo As String
    Private _PosId As String
    Private _Dt As DataTable

    Private _TrnLoc As String

#End Region
    Public Property Cost As Decimal
        Get
            Return _Cost
        End Get
        Set(ByVal value As Decimal)
            _Cost = value
        End Set
    End Property
    Public Property TrnLoc As String
        Get
            Return _TrnLoc
        End Get
        Set(ByVal value As String)
            _TrnLoc = value
        End Set
    End Property

    Public Property BillNo As String
        Get
            Return _BillNo
        End Get
        Set(ByVal value As String)
            _BillNo = value
        End Set
    End Property
    Public Property PosId As String
        Get
            Return _PosId
        End Get
        Set(ByVal value As String)
            _PosId = value
        End Set
    End Property
    Public Property Dt As DataTable
        Get
            Return _Dt
        End Get
        Set(ByVal value As DataTable)
            _Dt = value
        End Set
    End Property
    Public Property Area As String
        Get
            Return _Area
        End Get
        Set(ByVal value As String)
            _Area = value
        End Set
    End Property
    Public Property DBName As String
        Get
            Return _DBName
        End Get
        Set(ByVal value As String)
            _DbName = value
        End Set
    End Property

    Public Property ServerName As String
        Get
            Return _ServerName
        End Get
        Set(ByVal value As String)
            _ServerName = value
        End Set
    End Property
    Public Property IDType As String
        Get
            Return _IDType
        End Get
        Set(ByVal value As String)
            _IDType = value
        End Set
    End Property
    Public Property Profession As String
        Get
            Return _Profession
        End Get
        Set(ByVal value As String)
            _Profession = value
        End Set
    End Property
    Public Property ProfessionId As Integer
        Get
            Return _ProfessionId
        End Get
        Set(ByVal value As Integer)
            _ProfessionId = value
        End Set
    End Property
    Public Property ErrorMsg As String
        Get
            Return _errorMsg
        End Get
        Set(ByVal value As String)
            _errorMsg = value
        End Set
    End Property
#Region "Properties"

    Public Property RptVr As ReportViewer
        Get
            Return _RptVr
        End Get
        Set(ByVal value As ReportViewer)
            _RptVr = value
        End Set
    End Property
    Public Property UpdatingInterval As Integer
        Get
            Return _UpdatingInterval
        End Get
        Set(value As Integer)
            _UpdatingInterval = value
        End Set
    End Property
    Public Property DocStatus As String
        Get
            Return _DocStatus
        End Get
        Set(ByVal value As String)
            _DocStatus = value
        End Set
    End Property
    Public Property UserType As Integer
        Get
            Return _UserType
        End Get
        Set(ByVal value As Integer)
            _UserType = value
        End Set
    End Property


    Public Property ItemName As String
        Get
            Return _ItemName
        End Get
        Set(ByVal value As String)
            _ItemName = value
        End Set
    End Property
    Public Property Qty As Integer
        Get
            Return _Qty
        End Get
        Set(ByVal value As Integer)
            _Qty = value
        End Set
    End Property
    Public Property Unit As String
        Get
            Return _Unit
        End Get
        Set(ByVal value As String)
            _Unit = value
        End Set
    End Property
    Public Property Religion As Integer
        Get
            Return _Religion
        End Get
        Set(ByVal value As Integer)
            _Religion = value
        End Set
    End Property
    Public Property CustCo As Integer
        Get
            Return _CustCo
        End Get
        Set(ByVal value As Integer)
            _CustCo = value
        End Set
    End Property
    Public Property CustArea As Integer
        Get
            Return _CustArea
        End Get
        Set(ByVal value As Integer)
            _CustArea = value
        End Set
    End Property

    Public Property SelRpt As String
        Get
            Return _SelRpt
        End Get
        Set(ByVal value As String)
            _SelRpt = value
        End Set
    End Property

    Public Property Qry As String
        Get
            Return _Qry
        End Get
        Set(ByVal value As String)
            _Qry = value
        End Set
    End Property
    Public Property ConnLocalSvr As String
        Get
            Return _ConnLocalSvr
        End Get
        Set(ByVal value As String)
            _ConnLocalSvr = value
        End Set
    End Property

    Public Property Amt As Decimal
        Get
            Return _Amt
        End Get
        Set(ByVal value As Decimal)
            _Amt = value
        End Set
    End Property
    Public Property Category As String
        Get
            Return _Category
        End Get
        Set(ByVal value As String)
            _Category = value
        End Set
    End Property
    Public Property SubGrp As String
        Get
            Return _SubGrp
        End Get
        Set(ByVal value As String)
            _SubGrp = value
        End Set
    End Property


    Public Property Srl As Integer
        Get
            Return _Srl
        End Get
        Set(ByVal value As Integer)
            _Srl = value
        End Set
    End Property
    Public Property Grp As String
        Get
            Return _Grp
        End Get
        Set(ByVal value As String)
            _Grp = value
        End Set
    End Property
    Public Property DiscPers As Decimal
        Get
            Return _DiscPerc
        End Get
        Set(ByVal value As Decimal)
            _DiscPerc = value
        End Set
    End Property
    Public Property Points As Decimal
        Get
            Return _Points
        End Get
        Set(ByVal value As Decimal)
            _Points = value
        End Set
    End Property


    Public Property FromDt As Date
        Get
            Return _FromDt
        End Get
        Set(ByVal value As Date)
            _FromDt = value
        End Set
    End Property
    Public Property ToDt As Date
        Get
            Return _ToDt
        End Get
        Set(ByVal value As Date)
            _ToDt = value
        End Set
    End Property
    Public Property Rpt As ReportDocument
        Get
            Return _Rpt
        End Get
        Set(ByVal value As ReportDocument)
            _Rpt = value
        End Set
    End Property
    Public Property RuleId As Integer
        Get
            Return _RuleId
        End Get
        Set(ByVal value As Integer)
            _RuleId = value
        End Set
    End Property
    Public Property CompanyId As String
        Get
            Return _CompanyId
        End Get
        Set(ByVal value As String)
            _CompanyId = value
        End Set
    End Property



    Public Property CompanyName As String
        Get
            Return _CompanyName
        End Get
        Set(ByVal value As String)
            _CompanyName = value
        End Set
    End Property

    Public Property Ddl As DropDownList
        Get
            Return _ddl
        End Get
        Set(ByVal value As DropDownList)
            _ddl = value
        End Set
    End Property

    Public Property Gv As GridView
        Get
            Return _gv
        End Get
        Set(ByVal value As GridView)
            _gv = value
        End Set
    End Property

    Public Property Cd As String
        Get
            Return _Cd
        End Get
        Set(ByVal value As String)
            _Cd = value
        End Set
    End Property
    Public Property Des As String
        Get
            Return _Des
        End Get
        Set(ByVal value As String)
            _Des = value
        End Set
    End Property
    Public Property FName As String
        Get
            Return _FName
        End Get
        Set(ByVal value As String)
            _FName = value
        End Set
    End Property
    Public Property LName As String
        Get
            Return _LName
        End Get
        Set(ByVal value As String)
            _LName = value
        End Set
    End Property
    Public Property MName As String
        Get
            Return _MName
        End Get
        Set(ByVal value As String)
            _MName = value
        End Set
    End Property
    Public Property Gender As Boolean
        Get
            Return _Gender
        End Get
        Set(ByVal value As Boolean)
            _Gender = value
        End Set
    End Property
    Public Property BirthDt As DateTime
        Get
            Return _BirthDt
        End Get
        Set(ByVal value As DateTime)
            _BirthDt = value
        End Set
    End Property
    Public Property Addr1 As String
        Get
            Return _Addr1
        End Get
        Set(ByVal value As String)
            _Addr1 = value
        End Set
    End Property
    Public Property Addr2 As String
        Get
            Return _Addr2
        End Get
        Set(ByVal value As String)
            _Addr2 = value
        End Set
    End Property
    Public Property Addr3 As String
        Get
            Return _Addr3
        End Get
        Set(ByVal value As String)
            _Addr3 = value
        End Set
    End Property
    Public Property Phone As String
        Get
            Return _Phone
        End Get
        Set(ByVal value As String)
            _Phone = value
        End Set
    End Property
    Public Property Fax As String
        Get
            Return _Fax
        End Get
        Set(ByVal value As String)
            _Fax = value
        End Set
    End Property
    Public Property Mobile As String
        Get
            Return _Mobile
        End Get
        Set(ByVal value As String)
            _Mobile = value
        End Set
    End Property
    Public Property Email As String
        Get
            Return _Email
        End Get
        Set(ByVal value As String)
            _Email = value
        End Set
    End Property
    Public Property UID As String
        Get
            Return _UID
        End Get
        Set(ByVal value As String)
            _UID = value
        End Set
    End Property
    Public Property Curr As String
        Get
            Return _Curr
        End Get
        Set(ByVal value As String)
            _Curr = value
        End Set
    End Property

    Public Property Country As String
        Get
            Return _Country
        End Get
        Set(ByVal value As String)
            _Country = value
        End Set
    End Property
    Public Property CountryName As String
        Get
            Return _CountryName
        End Get
        Set(ByVal value As String)
            _CountryName = value
        End Set
    End Property
    Public Property Region As String
        Get
            Return _Region
        End Get
        Set(ByVal value As String)
            _Region = value
        End Set
    End Property
    Public Property CustGrp As String
        Get
            Return _CustGrp
        End Get
        Set(ByVal value As String)
            _CustGrp = value
        End Set
    End Property
    Public Property CardType As String
        Get
            Return _CardType
        End Get
        Set(ByVal value As String)
            _CardType = value
        End Set
    End Property
    Public Property Appr_Points As Double
        Get
            Return _Appr_Points
        End Get
        Set(ByVal value As Double)
            _Appr_Points = value
        End Set
    End Property
    Public Property Redm_Points As Double
        Get
            Return _Redm_Points
        End Get
        Set(ByVal value As Double)
            _Redm_Points = value
        End Set
    End Property
    Public Property Unappr_Points As Double
        Get
            Return _Unappr_Points
        End Get
        Set(ByVal value As Double)
            _Unappr_Points = value
        End Set
    End Property
    Public Property Last_PurDt As DateTime
        Get
            Return _Last_PurDt
        End Get
        Set(ByVal value As DateTime)
            _Last_PurDt = value
        End Set
    End Property
    Public Property Active As Boolean
        Get
            Return _Active
        End Get
        Set(ByVal value As Boolean)
            _Active = value
        End Set
    End Property
    Public Property BlackListed As Boolean
        Get
            Return _BlackListed
        End Get
        Set(ByVal value As Boolean)
            _BlackListed = value
        End Set
    End Property
    Public Property CardIssued As Boolean
        Get
            Return _CardIssued
        End Get
        Set(ByVal value As Boolean)
            _CardIssued = value
        End Set
    End Property
    Public Property Remarks As String
        Get
            Return _Remarks
        End Get
        Set(ByVal value As String)
            _Remarks = value
        End Set
    End Property

    Public Property EntryBy As String
        Get
            Return _EntryBy
        End Get
        Set(ByVal value As String)
            _EntryBy = value
        End Set
    End Property
    Public Property EntryDt As DateTime
        Get
            Return _EntryDt
        End Get
        Set(ByVal value As DateTime)
            _EntryDt = value
        End Set
    End Property
    Public Property EditBy As String
        Get
            Return _EditBy
        End Get
        Set(ByVal value As String)
            _EditBy = value
        End Set
    End Property
    Public Property EditDt As DateTime
        Get
            Return _EditDt
        End Get
        Set(ByVal value As DateTime)
            _EditDt = value
        End Set
    End Property

    Public Property CustGrpCd As String
        Get
            Return _CustGrpCd
        End Get
        Set(ByVal value As String)
            _CustGrpCd = value
        End Set
    End Property


    Public Property ItemCode As String
        Get
            Return _ItemCode
        End Get
        Set(ByVal value As String)
            _ItemCode = value
        End Set
    End Property

    Public Property TrnId As Integer
        Get
            Return _TrnId
        End Get
        Set(ByVal value As Integer)
            _TrnId = value
        End Set
    End Property
    Public Property TrnDate As DateTime
        Get
            Return _TrnDate
        End Get
        Set(ByVal value As DateTime)
            _TrnDate = value
        End Set
    End Property
    Public Property Narration As String
        Get
            Return _Narration
        End Get
        Set(ByVal value As String)
            _Narration = value
        End Set
    End Property

    Public Property RefDocNo As String
        Get
            Return _RefDocNo
        End Get
        Set(ByVal value As String)
            _RefDocNo = value
        End Set
    End Property

    Public Property Username As String
        Get
            Return _Username
        End Get
        Set(ByVal value As String)
            _Username = value
        End Set
    End Property
    Public Property Pwd As String
        Get
            Return _pwd
        End Get
        Set(ByVal value As String)
            _pwd = value
        End Set
    End Property
    Public Property PwdNew As String
        Get
            Return _pwdNew
        End Get
        Set(ByVal value As String)
            _pwdNew = value
        End Set
    End Property
#End Region
    'Public Property PointsTo As Integer
    '    Get
    '        Return _PointsTo
    '    End Get
    '    Set(ByVal value As Integer)
    '        _PointsTo = value
    '    End Set
    'End Property
    Public Property TrnAutoNo As Integer
        Get
            Return _TrnAutoNo
        End Get
        Set(ByVal value As Integer)
            _TrnAutoNo = value
        End Set
    End Property
    Public Property MaxRedeemPnts As Integer
        Get
            Return _MaxRedeemPnts
        End Get
        Set(ByVal value As Integer)
            _MaxRedeemPnts = value
        End Set
    End Property
    Public Property LocCd As String 'Nitheesh
        Get
            Return _LocCd
        End Get
        Set(ByVal value As String)
            _LocCd = value
        End Set
    End Property

    Public Property BaseQty As Integer
        Get
            Return _BaseQty
        End Get
        Set(value As Integer)
            _BaseQty = value
        End Set
    End Property
   
    Public Function SetCustomer() As String
        Dim objDal As New clsDalLoyalty
        Return objDal.SetCustomer(Me)
    End Function
    Public Sub ComboFill()
        Dim objDal As New clsDalLoyalty
        objDal.ComboFill(Me)
    End Sub
    Public Sub GridFill()
        Dim objDal As New clsDalLoyalty
        objDal.GridFill(Me)
    End Sub
    Public Function GetLocation() As String 'added fro testing by nitheesh on 23032017
        Dim objDal As New clsDalLoyalty
        Return objDal.GetLocation(Me)
    End Function
    
    Public Sub GetCustArea()
        Dim objDal As New clsDalLoyalty
        objDal.GetCustArea(Me)
    End Sub

    Public Function GetCustomerDetails() As Data.DataSet
        Dim objDal As New clsDalLoyalty
        Return objDal.GetCustomers(Me)
    End Function
    Public Function ValidateLogin() As Boolean
        Dim objDal As New clsDalLoyalty
        Return objDal.getUserDetails(Me)
    End Function
    Public Function GetSalesRuleHead() As Data.DataSet
        Dim objDal As New clsDalLoyalty
        Return objDal.getSalesRules(Me)
    End Function
    Public Function GetRedRulesHead() As Data.DataSet
        Dim objDal As New clsDalLoyalty
        Return objDal.getRedRules(Me)
    End Function

    'Public Function ValidateRedeemItems() As Boolean
    '    Dim objDal As New clsDalLoyalty
    '    Return objDal.ValidateRedeemItems(Me)
    'End Function
    Public Function SetRedeemHead(ByVal serverName As String) As String
        Dim objDal As New clsDalLoyalty
        Return objDal.setRedeemHead(Me, serverName)
    End Function

    Public Function SetRedeemDetail(ByVal serverName As String) As String
        Dim objDal As New clsDalLoyalty
        Return objDal.setRedeemDetail(Me, serverName)
    End Function
    Public Function GetRedeemHead() As Data.DataSet
        Dim objDal As New clsDalLoyalty
        Return objDal.getRedeemHead(Me)
    End Function
    Public Function GetRedeemDetails() As Data.DataSet
        Dim objDal As New clsDalLoyalty
        Return objDal.GetRedeemDetails(Me)
    End Function

    Public Function UpdateSalesRulesHead_LocalMachine() As String
        Dim objDal As New clsDalLoyalty
        Return objDal.UpdateSalesRulesHead_LocalMachine(Me)
    End Function

    Public Function UpdateSalesRulesDetail_LocalMachine() As String
        Dim objDal As New clsDalLoyalty
        Return objDal.updateSalesRulesDetail_LocalMachine(Me)
    End Function
    Public Function UpdateRedRulesHead_LocalMachine() As String
        Dim objDal As New clsDalLoyalty
        Return objDal.updateRedRulesHead_LocalMachine(Me)
    End Function

    Public Function UpdateRedRulesDetail_LocalMachine() As String
        Dim objDal As New clsDalLoyalty
        Return objDal.updateRedRulesDetail_LocalMachine(Me)
    End Function
    Public Sub GetNextCustomerNo()
        Dim objDal As New clsDalLoyalty
        objDal.getNextCustomerNo(Me)
    End Sub
    Public Sub GetFirstRedeemDt()
        Dim objDal As New clsDalLoyalty
        objDal.getFirstRedeemDt(Me)
    End Sub

    Public Function GetSalesUpdnDetails() As DataSet
        Dim objDal As New clsDalLoyalty
        Return objDal.getSalesUpdnDetails(Me)
    End Function

    Public Function UpdateSalesTransUpdnInterval() As String
        Dim objDal As New clsDalLoyalty
        Return objDal.updateSalesTransUpdnInterval(Me)
    End Function
    Public Function UpdateCustTransactions() As String
        Dim objDal As New clsDalLoyalty
        Return objDal.updateCustTransactions(Me)
    End Function
    Public Sub ShowReport()
        Dim objDal As New clsDalLoyalty
        objDal.showReport(Me)
    End Sub
    Public Function SetCustCompany() As String
        Dim objDal As New clsDalLoyalty
        Return objDal.setCustCompany(Me)
    End Function

   
    'Public Function ShowReport(path As String) As ReportDocument
    '    Dim objDal As New clsDalLoyalty
    '    Return objDal.showReport(Me, path)
    'End Function
    Public Function SetSalesRulesHead() As String
        Dim objDal As New clsDalLoyalty
        Return objDal.setSalesRulesHead(Me)
    End Function
    Public Function SetSalesRulesDetail() As String
        Dim objDal As New clsDalLoyalty
        Return objDal.setSalesRulesDetail(Me)
    End Function

    Public Function SetRedRules() As String
        Dim objDal As New clsDalLoyalty
        Return objDal.setRedRules(Me)
    End Function
    Public Function SetUser() As String
        Dim objDal As New clsDalLoyalty
        Return objDal.setUser(Me)
    End Function
    Public Function CheckUserExists() As Boolean
        Dim objDal As New clsDalLoyalty
        Return objDal.checkUserExists(Me)
    End Function
    Public Sub GetRedeemItemDetails()
        Dim objDal As New clsDalLoyalty
        objDal.GetRedeemItemDetails(Me)
    End Sub

    Public Function DeleteUser() As String
        Dim objDal As New clsDalLoyalty
        Return objDal.deleteUser(Me)
    End Function
    Public Function ChangePassword() As String
        Dim objDal As New clsDalLoyalty
        Return objDal.changePassword(Me)
    End Function
    Public Function GetGroupDetails() As Data.DataSet
        Dim objDal As New clsDalLoyalty
        Return objDal.getGroupDetails(Me)
    End Function

    Public Sub GetItemDetails()
        Dim objDal As New clsDalLoyalty
        objDal.getItemDetails(Me)
    End Sub
    Public Function DeleteSalesRule() As String
        Dim objDal As New clsDalLoyalty
        Return objDal.deleteSalesRule(Me)
    End Function
    Public Function DeleteSalesRuleHead() As String
        Dim objDal As New clsDalLoyalty
        Return objDal.deleteSalesRuleHead(Me)
    End Function
    Public Function Update_Ly_Groups() As String
        Dim objDal As New clsDalLoyalty
        Return objDal.update_Ly_Groups(Me)
    End Function

    Public Function ValidateMobileNo() As String
        Dim objDal As New clsDalLoyalty
        Return objDal.validateMobileNo(Me)
    End Function
    Public Function GetCompanydetails() As Data.DataSet
        Dim objDal As New clsDalLoyalty
        Return objDal.GetCompany(Me)
    End Function
    Public Function SetProfession() As String
        Dim objDal As New clsDalLoyalty
        Return objDal.setProfession(Me)
    End Function
    Public Function DeleteProfession() As String
        Dim objDal As New clsDalLoyalty
        Return objDal.deleteProfession(Me)
    End Function
    Public Function DeleteCustCompany() As String
        Dim objDal As New clsDalLoyalty
        Return objDal.deleteCustCompany(Me)
    End Function
    Public Function SetCustLocation() As String
        Dim objDal As New clsDalLoyalty
        Return objDal.setCustLocation(Me)
    End Function
    Public Function DeleteCustLocation() As String
        Dim objDal As New clsDalLoyalty
        Return objDal.deleteCustLocation(Me)
    End Function
    Public Function GetFailedTrans() As DataSet
        Dim objDal As New clsDalLoyalty
        Return objDal.getFailedTrans(Me)
    End Function
    Public Function UpdateFailedTrans() As String
        Dim objDal As New clsDalLoyalty
        Return objDal.updateFailedTrans(Me)
    End Function
    Public Sub GetRedVoucherDetails()
        Dim objDal As New clsDalLoyalty
        objDal.getRedVoucherDetails(Me)
    End Sub
    'Public Function InsufficientRedPoints() As Boolean
    '    Dim objDal As New clsDalLoyalty
    '    Return objDal.insufficientRedPoints()(Me)
    'End Function

    'Public Function GeCustTransactions() As DataSet
    '    Dim objDal As New clsDalLoyalty
    '    Return objDal.geCustTransactions(Me)
    'End Function


    '#Region "Methods"
    '    Public Sub Add()
    '        SqlHelper.ExecuteNonQuery(SqlHelper.GetConn(), "proc_Ly_CustomersInsert", Cd, Des, FName, LName, MName, Gender, BirthDt, Addr1, Addr2, Addr3, Phone, Fax, Mobile, Email, UID, Curr, Area, Country, Region, CustGrp, CardType, Appr_Points, Redm_Points, Unappr_Points, Last_PurDt, Active, BlackListed, EntryBy, EntryDt, EditBy, EditDt)
    '    End Sub

    '    Public Sub Update()
    '        SqlHelper.ExecuteNonQuery(SqlHelper.GetConn(), "proc_Ly_CustomersUpdate", Cd, Des, FName, LName, MName, Gender, BirthDt, Addr1, Addr2, Addr3, Phone, Fax, Mobile, Email, UID, Curr, Area, Country, Region, CustGrp, CardType, Appr_Points, Redm_Points, Unappr_Points, Last_PurDt, Active, BlackListed, EntryBy, EntryDt, EditBy, EditDt)
    '    End Sub

    '    Public Sub Delete()
    '        SqlHelper.ExecuteNonQuery(SqlHelper.GetConn(), "proc_Ly_CustomersDelete", Cd)
    '    End Sub

    '    Public Function LoadAll() As Data.DataSet
    '        Return SqlHelper.ExecuteDataset(SqlHelper.GetConn(), "proc_Ly_CustomersLoadAll")
    '    End Function

    '    Public Function LoadByID() As Data.DataSet
    '        Dim ds As New Data.DataSet
    '        ds = SqlHelper.ExecuteDataset(SqlHelper.GetConn(), "proc_Ly_CustomersLoadByPrimaryKey", Cd)
    '        If ds.Tables(0).Rows.Count > 0 Then
    '            Cd = ds.Tables(0).Rows(0)("Cd").ToString()
    '            Des = ds.Tables(0).Rows(0)("Des").ToString()
    '            FName = ds.Tables(0).Rows(0)("FName").ToString()
    '            LName = ds.Tables(0).Rows(0)("LName").ToString()
    '            MName = ds.Tables(0).Rows(0)("MName").ToString()
    '            Gender = ds.Tables(0).Rows(0)("Gender").ToString()
    '            BirthDt = ds.Tables(0).Rows(0)("BirthDt").ToString()
    '            Addr1 = ds.Tables(0).Rows(0)("Addr1").ToString()
    '            Addr2 = ds.Tables(0).Rows(0)("Addr2").ToString()
    '            Addr3 = ds.Tables(0).Rows(0)("Addr3").ToString()
    '            Phone = ds.Tables(0).Rows(0)("Phone").ToString()
    '            Fax = ds.Tables(0).Rows(0)("Fax").ToString()
    '            Mobile = ds.Tables(0).Rows(0)("Mobile").ToString()
    '            Email = ds.Tables(0).Rows(0)("Email").ToString()
    '            UID = ds.Tables(0).Rows(0)("UID").ToString()
    '            Curr = ds.Tables(0).Rows(0)("Curr").ToString()
    '            Area = ds.Tables(0).Rows(0)("Area").ToString()
    '            Country = ds.Tables(0).Rows(0)("Country").ToString()
    '            Region = ds.Tables(0).Rows(0)("Region").ToString()
    '            CustGrp = ds.Tables(0).Rows(0)("CustGrp").ToString()
    '            CardType = ds.Tables(0).Rows(0)("CardType").ToString()
    '            Appr_Points = ds.Tables(0).Rows(0)("Appr_Points").ToString()
    '            Redm_Points = ds.Tables(0).Rows(0)("Redm_Points").ToString()
    '            Unappr_Points = ds.Tables(0).Rows(0)("Unappr_Points").ToString()
    '            Last_PurDt = ds.Tables(0).Rows(0)("Last_PurDt").ToString()
    '            Active = ds.Tables(0).Rows(0)("Active").ToString()
    '            BlackListed = ds.Tables(0).Rows(0)("BlackListed").ToString()
    '            CardIssued = ds.Tables(0).Rows(0)("CardIssued").ToString()
    '            Remarks = ds.Tables(0).Rows(0)("Remarks").ToString()

    '            EntryBy = ds.Tables(0).Rows(0)("EntryBy").ToString()
    '            EntryDt = ds.Tables(0).Rows(0)("EntryDt").ToString()
    '            EditBy = ds.Tables(0).Rows(0)("EditBy").ToString()
    '            EditDt = ds.Tables(0).Rows(0)("EditDt").ToString()

    '        End If
    '        Return ds
    '    End Function

    '    '   Public Sub Save()
    '    '       If (Me.isNew) Then Me.Add()
    '    'Else If (Me.isDirty) Then Me.Update()
    '    'Else If (Me.isDelete) Then Me.Delete()
    '    'End If
    '    '   End Sub
    '#End Region

End Class
