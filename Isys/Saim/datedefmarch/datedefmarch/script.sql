USE [SAIM]
GO
/****** Object:  StoredProcedure [dbo].[Prc_FillMstVals]    Script Date: 01-03-2019 12:20:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================                                                            
-- Author:  AKSHAY DHANJI                                                    
-- Create date: <Create Date,,>                                                            
-- Description: <Description,,>                                                      
-- [Prc_FillMstVals] '33','','','','P','',''                                                    
-- =============================================                                                            
CREATE PROCEDURE [dbo].[Prc_FillMstVals]                                                            
@Flag varchar(10),                                                    
@YEAR_TYPE VARCHAR(10)=NULL,                                                    
@CMPNSTYPE VARCHAR(10)=NULL,                                                  
@CODE VARCHAR(20)=NULL,                                        
@TYPFLG VARCHAR(20)=NULL,                                    
@KPI_CODE VARCHAR(20)=NULL,                              
@CMPNSTN_CODE VARCHAR(20)=NULL,                              
@CYCLE_CODE VARCHAR(20)=NULL,        
@UserID VARCHAR(20)=NULL  
--@KPI_CODE varchar(20)=null        
                              
                                    
AS                                                            
BEGIN           
BEGIN TRY        
 declare @cmpType varchar(10)                                                         
                                                            
 IF(@Flag = '1')                                                            
 BEGIN                                                            
 SELECT CODE,DESC01 FROM MST_TYPE WHERE ISACTIVE = '1'                                                      
 END                                                            
 ELSE IF(@Flag = '2')                                                            
 BEGIN                                                            
 SELECT CODE,DESC01 FROM MST_SUBTYPE WHERE ISACTIVE = '1'                                                    
 END                                                            
 ELSE IF(@Flag = '3')                                                            
 BEGIN                                                            
 SELECT CODE,DESC01 FROM MST_MEASURED_AS WHERE ISACTIVE = '1'                                                    
 END                                                            
 ELSE IF(@Flag = '4')                                                            
 BEGIN                                                            
 SELECT CODE,DESC01 FROM MST_ORIGIN WHERE ISACTIVE = '1'                                                    
 END                                                            
 ELSE IF(@Flag = '5')                                                          
 BEGIN                                                          
 SELECT CODE,DESC01 FROM MST_DBTABLE WHERE ISACTIVE = '1'                                                    
 END                                                          
 ELSE IF(@Flag = '6')                                                          
 BEGIN                                                          
 SELECT CODE,DESC01 FROM MST_TBL_FIELD WHERE ISACTIVE = '1'                                                    
 END                                                          
 ELSE IF(@Flag = '7')                                                          
 BEGIN                                                          
 SELECT CODE,DESC01 FROM MST_DBFUNCTION WHERE ISACTIVE = '1'                                                    
 END                                                        
 ELSE IF(@Flag = '8')                                                          
 BEGIN                                                          
 SELECT CODE,DESC01 FROM MST_ACC_CYCLE WHERE ISACTIVE = '1' order by SORT_ORDER asc                                          
 END                                                        
 ELSE IF(@Flag = '9')                                      
 BEGIN                                                          
 SELECT CODE,DESC01 FROM MST_ACC_YEAR WHERE ISACTIVE = '1'                                                    
 END                                    
 ELSE IF(@Flag = '10')                                       
 BEGIN                                                          
 SELECT CODE,DESC01 FROM MST_CMPNSTNTYPE WHERE ISACTIVE = '1'                                                    
 END                                        
ELSE IF(@Flag = '11')                                                          
 BEGIN                
  --SELECT CODE,DESC01 FROM MST_CMPSTTS WHERE CODE  in(select  CMP_STS_ID from USER_CMPSTTS_MAPPER WHERE IS_ACTIVE='Y' AND   USR_ROLE in(select UserRoleCode FROM [USRMGMT]..[iUser] where UserName=@UserID))        
    select  mst.CODE,mst.DESC01 from  MST_CMPSTTS mst inner join  USER_CMPSTTS_MAPPER ucmp on mst.CODE=ucmp.CMP_STS_ID         
    inner join [USRMGMT]..[iUser] usr on ucmp.USR_ROLE = usr.UserRoleCode collate SQL_Latin1_General_CP1_CI_AS where ucmp.IS_ACTIVE='Y' and usr.UserId=@UserID        
 END                                 
 ELSE IF(@Flag = '12')                                                          
 BEGIN                     
 SELECT CODE,DESC01 FROM MST_CMPSTTS WHERE WS_STATUS = '10' AND ISACTIVE = '1'                                                     
 END                                             
 ELSE IF(@Flag = '13')                                                          
 BEGIN                                                          
 SELECT CODE,DESC01 FROM MST_ACC_MODE WHERE ISACTIVE = '1'                                                     
 END                                                      
 ELSE IF(@Flag = '14')                                                          
 BEGIN                                                          
 SELECT CODE,DESC01,[DEFAULT] AS DEFLT FROM MST_ACC_CYCLE WHERE ISACTIVE = '1' AND [DEFAULT] = 'Y'                                                    
 END                                                        
 ELSE IF(@Flag = '15')                              
 BEGIN                                                          
 SELECT BUSI_CODE AS CODE,BUSI_DESC AS DESC01,SHRT_BUSI_DESC FROM MST_BUSI_YR WHERE YEAR_TYPE = @YEAR_TYPE AND PARENT_BUSI_CODE IS NULL          
 and IS_CURRENTYEAR='1'                                                 
 END                                                    
 ELSE IF(@Flag = '16')                                                    
 BEGIN                                                    
 SELECT CMPNSTN_CODE AS CODE,CMPNSTN_DESC01 AS DESC01 FROM Mst_Cmpnstn WHERE CMPNSTN_TYPE = @CMPNSTYPE                                                    
 END                                                    
 ELSE IF(@Flag = '17')                                                    
 BEGIN                                   
 SELECT CODE AS CODE,DESC01 AS DESC01 FROM MST_CMPCATG WHERE ISACTIVE='1' ORDER BY SEQNO           
         
                                                  
 END                                                    
 ELSE IF(@Flag = '18')                                       
 BEGIN                                                    
 SELECT CODE AS CODE,DB_FUNCNAME AS DESC01 FROM MST_DBFUNCTION WHERE ISACTIVE='1' and CODE=@CODE ORDER BY SEQNO                                                    
 END                                                   
 ELSE IF(@Flag = '19')                                                
 BEGIN                                                    
 SELECT CODE AS CODE,DB_TABLENAME AS DESC01,TBL_ALIAS_NAME AS ALIAS_NAME FROM MST_DBTABLE WHERE ISACTIVE='1' and CODE=@CODE ORDER BY SEQNO                                              
 END                   
 ELSE IF(@Flag = '20')                                                    
 BEGIN                                                    
 SELECT CODE AS CODE,TBL_FIELDNAME AS DESC01 FROM MST_TBL_FIELD WHERE ISACTIVE='1' and CODE=@CODE ORDER BY SEQNO                                                    
 END                                                   
 ELSE IF(@Flag = '21')                                                    
 BEGIN                                                    
 SELECT CODE AS CODE,DESC01 AS DESC01 FROM MST_RWDTYPE WHERE ISACTIVE='1' ORDER BY SEQNO                                                    
 END                                        
 ELSE IF(@Flag = '22')                                                    
 BEGIN                                                
 DECLARE @SORT_ORDER int                                              
 SELECT @SORT_ORDER = SORT_ORDER FROM MST_ACC_CYCLE WHERE CODE=@CODE                                              
 SELECT CODE AS CODE,DESC01 AS DESC01 FROM MST_ACC_CYCLE WHERE CONVERT(INT,SORT_ORDER) >= @SORT_ORDER AND ISACTIVE='1' ORDER BY SORT_ORDER asc                                                    
 END                                                 
 ELSE IF(@Flag = '23')                                                          
 BEGIN                                  
 SELECT CODE as CODE,DESC01 as DESC01,CYCLE_TYPE as CYCLE_TYPE,IS_STANDARD as IS_STANDARD FROM MST_ACC_CYCLE WHERE CODE = @CODE                                             
 END                                  
 ELSE IF(@Flag = '24')                                                          
 BEGIN                                                          
 SELECT CODE,DESC01 FROM MST_CMPNSTNTYPE WHERE ISACTIVE = '1' AND TYPEFLG = @TYPFLG                                        
 END                                      
 ELSE IF(@Flag = '25')                                      
 BEGIN                                                          
 SELECT CODE,DESC01 FROM MST_UPLDTYP WHERE ISACTIVE = '1'                                      
 END                                        
  ELSE IF(@Flag = '26')                                      
 BEGIN                                                          
  SELECT CODE AS CODE,DESC01 AS DESC01,TBL_ALIAS_NAME AS ALIAS_NAME,KPI_CODE AS KPI_CODE                                     
  FROM MST_DBTABLE WHERE ISACTIVE='1'                                     
 and KPI_CODE=@KPI_CODE ORDER BY SEQNO                                                
 END                                        
 ELSE IF(@Flag = '27')                      
 BEGIN                                                          
 SELECT CODE AS CODE,BusiType_Desc AS DESC01 FROM Mst_BusinessType where ISACTIVE='1'                                  
 END                              
 ELSE IF(@Flag='28')                              
 BEGIN                              
 SELECT DISTINCT BatchID as BATCHID from cmpBTCHSEQ_InBriefDtl where CMPNSTN_CODE=@CMPNSTN_CODE and Cycle_Code = @CYCLE_CODE                              
 END                                   
 ELSE IF(@Flag = '29')                                      
 BEGIN                                                          
 SELECT CODE AS CODE,DESC01 AS DESC01 FROM MST_TAXTYPE WHERE ISDIRECT = @TYPFLG AND ISACTIVE = '1' ORDER BY SEQNO                            
 END                          
 ELSE IF(@Flag = '30')                                      
 BEGIN                                                          
 SELECT CMPNSTN_CODE AS CODE,CMPNSTN_DESC01 AS DESC01 FROM Mst_Cmpnstn WHERE STATUS = '1006' ORDER BY SEQNO                            
 END                                             
 ELSE IF(@Flag = '31')                                      
 BEGIN                                                          
 SELECT distinct CYCLE as CODE,BUSI_DESC as DESC01 FROM Mst_Cmpnstn_Cntstnt_KPI_Trgt kpitrg                        
 inner join MST_BUSI_YR yr on yr.BUSI_CODE=kpitrg.CYCLE                        
 where CMPNSTN_CODE=@CMPNSTN_CODE                        
 END                                             
 ELSE IF(@Flag = '32')                                      
 BEGIN                                                          
 SELECT distinct CNTSTNT_CODE as CODE,chm.MemTypeDesc01 as DESC01 FROM Mst_Cmpnstn_Cntstnt mcc                      
 inner join chnMemSu chm on chm.BizSrc=mcc.CHN and chm.ChnCls=mcc.CHNCLS and chm.MemType=mcc.MEMTYPE                                        
 where CMPNSTN_CODE=@CMPNSTN_CODE                        
 END                    
 ELSE IF(@Flag='33')                    
 BEGIN                    
 SELECT CODE,DESC01,DESC02,DESC03,ISACTIVE,DATETYPE FROM MST_DATETYPE WHERE DATETYPE=@TYPFLG AND ISACTIVE='1'                    
 END                    
 ELSE IF(@Flag='34')                    
 BEGIN           
                  
 --SELECT distinct ClassCode as CODE,ClassName as DESC01 FROM ProductSu where IsActive='1' and ClassCode is not null and ClassName is not null and classcode='10'                 
   Select Product_Category_ID_PK as CODE,Product_Category as DESC01 from Product_Category_Master         
         
 END              
 ELSE IF(@Flag='35')                    
 BEGIN                    
 SELECT DB_FUNCNAME as CODE,DESC01 as DESC01 FROM MST_DBOPERATORS WHERE ISACTIVE = '1'              
 END            
 --New added 02_12_2017          
 ELSE IF(@Flag='36')                    
 BEGIN                    
 --SELECT distinct ClassCode as CODE,ClassName as DESC01 FROM ProductSu         
 --where ClassCode is not null and ClassName is not null and ClassCode in(1,10,5,4) -- and  IsActive='1' and classcode='10'                 
 --Select Product_Category_ID_PK as CODE,Product_Category as DESC01 from Product_Category_Master         
         
  Select Product_Category_ID_PK as CODE,Product_Category as DESC01 from Product_Category_Master         
         
 END        
 else If(@Flag='37')        
 begin        
 Select Product_Category_ID_PK as CODE,Product_Category as DESC01 from Product_Category_Master         
 end        
  else If(@Flag='38')        
 begin        
 select Portfolio_ID_PK as CODE,Portfolio as DESC01         
 From dbo.Portfolio_Master          
 end        
         
 else If(@Flag='39')        
 begin        
  SELECT @cmpType=CMPNSTN_TYPE FROM Mst_Cmpnstn  WHERE CMPNSTN_CODE=@CMPNSTN_CODE        
   select ParamValue as CODE,        
    ParamDesc1 as DESC01 from LookUpSU look INNER JOIN MST_CMPTYPE_RULSET_MAP map on look.ParamValue=map.RUL_MTHD_CODE         
    where LookupCode='RuleMethod'   AND map.CMP_CODE_TYPE=@cmpType        
           
        
 end        
 else If(@Flag='40')        
 begin        
          
  select  ParamValue as CODE,ParamDesc1 as DESC01 from LookUpSU where   LookupCode='Operator' order by SortOrder        
           
        
 end        
         
 else If(@Flag='41')        
 begin        
          
  select  ParamValue as CODE,ParamDesc1 as DESC01 from LookUpSU where   LookupCode='RulClass' order by SortOrder        
           
        
 end        
 else If(@Flag='42')        
 begin        
          
         
    select '1000000100' as CODE,'NONE'  as DESC01 union all      
  select  KPI_CODE as CODE,KPI_DESC_01 as DESC01 from Mst_KPI  where KPI_ORIGIN='1002' order by CODE        
           
        
        
 end        
         
  else If(@Flag='43')        
 begin        
          
  --select * from  LookUpSU        
  select  ParamValue as CODE,ParamDesc1 as DESC01 from LookUpSU where   LookupCode='RuleComplexity' order by SortOrder        
           
        
        
 end        
    
 else If(@Flag='44')        
 begin        
          
  --select * from  LookUpSU        
  SELECT CMPNSTN_CODE AS CODE,CMPNSTN_DESC01 AS DESC01 FROM Mst_Cmpnstn --where STATUS = '1006'     
  Order By SEQNO Asc    
        
 end       
 else If(@Flag='45')        
 begin        
          
  --select * from  LookUpSU        
  SELECT 'cmpTRGCATG_ACC_Cycle' AS CODE,'Category' AS DESC01    
  UNION ALL    
  SELECT 'CmpTRGRWD_ACC_Cycle' AS CODE,'Reward' AS DESC01    
        
 end        
    
     
   else If(@Flag='46')    
 begin    
      
  select  ParamValue as CODE,ParamDesc1 as DESC01 from LookUpSU where   LookupCode='RelType' order by SortOrder    
       
    
 end    
  
  ELSE IF(@Flag='47')                    
 BEGIN                    
 SELECT CODE,DESC01,DESC02,DESC03,ISACTIVE,DATETYPE FROM MST_DATETYPE_KPI WHERE DATETYPE=@TYPFLG AND ISACTIVE='1'   
 and KPI_CODE= replace(@KPI_CODE,'-','')                   
 END    
         
             
END TRY        
 BEGIN CATCH        
INSERT INTO  SQLRaisedErrorTracking                                              
  (InsertDate,ErrorNumber,ErrorSeverity,ErrorState,ErrorProcedure,ErrorLine,ErrorMessage)                                              
  select GETDATE(), ERROR_NUMBER(), ERROR_SEVERITY(), ERROR_STATE(),'Prc_FillMstVals',ERROR_LINE(),ERROR_MESSAGE()        
END CATCH;              
END 
GO
/****** Object:  StoredProcedure [dbo].[Prc_GETKPI_CODE]    Script Date: 01-03-2019 12:20:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================                        
-- Author:  <Pawar Bhaurao>                        
-- Create date: <19-08-2015>                        
-- Description: <For Getting Business Code>                        
-- Prc_BUSI_CODE                        
-- =============================================                        
CREATE PROCEDURE [dbo].[Prc_GETKPI_CODE]     
@MAPPED_CODE varchar(20)                                                             
AS                        
BEGIN      

    
    
select distinct KPI_CODE  from [MST_STDDEFNTN]  where MAPPED_CODE=@MAPPED_CODE

---- set @strsql = 'Select (Max(BUSI_CODE) + 1) as BUSI_CODE from MST_BUSI_YR'  
-- EXEC(@strsql)          
END 


GO
