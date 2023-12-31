USE [LoyaltyMainServerDB]
GO
/****** Object:  StoredProcedure [dbo].[Ly_RedeemTransHead_Update]    Script Date: 07/30/2014 16:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- select * from Ly_RedeemTransHead
Create PROCEDURE [dbo].[Ly_RedeemTransHead_Update]
	@v_TrnId		Numeric(9,0)
,	@v_TrnDt		Datetime
,	@CoCd			char(2)
,	@v_CustCd		Char(10)
--,	@v_Loc			Char(5)
,	@v_RedPoints	Numeric(18,2)
--,	@v_BalPoints	Numeric(18,2)
,	@v_Narr			Varchar(200)
,	@v_RefDocTyp	varChar(5)
,	@v_RefDocNo		VarChar(max)
,	@v_DocStat		varChar(15)
,	@v_EntryBy		varChar(20)
As		-- Drop Procedure Ly_RedeemTransHead_Update
Begin
	If(Select Count(1) from Ly_RedeemTransHead Where TrnId=@v_TrnId)=0
	  Begin
			Insert into Ly_RedeemTransHead(TrnDt,CoCd,CustCd,Loc,RedPoints,Narr,RefDocTyp,RefDocNo,DocStat,EntryBy,EntryDt,EditBy,EditDt)
			Values(@v_TrnDt,@CoCd,@v_CustCd,'',@v_RedPoints,@v_Narr,@v_RefDocTyp,@v_RefDocNo,@v_DocStat,@v_EntryBy,GetDate(),NULL,NULL)
			select @@identity
			declare @RedNo as int
			set @RedNo=@@IDENTITY
			EXEC [Ly_RedeemTransBalance_Update_ApportionValue] @v_CustCd,@RedNo,@v_RedPoints
	  End
	Else
	  Begin
		Update Ly_RedeemTransHead Set 
			TrnDt	=	@v_TrnDt
		,	CustCd	=	@v_CustCd
		--,	Loc		=	@v_Loc
		,	RedPoints	=	@v_RedPoints
		,	Narr	=	@v_Narr
		,	DocStat	=	@v_DocStat
		,	EditBy	=	@v_EntryBy
		,	EditDt	=	GetDate()
		Where TrnId=@v_TrnId
	  End
End
Go