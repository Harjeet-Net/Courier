/*
	update tblTranItemStock   set Stock=0  where Stock<0

	select  'SELECT ',ItemID ,',', Stock ,',' ,OpeningStock  ,'UNION ALL' from tblTranItemStock  

	select BranchID,BranchCode,BranchName from tblBranchMaster


1	001	MOBILE CITY GENERAL DEALERS LIMITED
2	S01	Cairo Road
3	W01	WARE HOUSE 01
4	S02	Millenium Bus Station
5	S03	South Gate Mall
6	S04	Nkwazi Road
7	S05	Kitwe Town
8	S06	Great East Mall
9	S07	Mukuba Mall
10	S08	Cosmopolitan Mall
11	S09	East Park Mall
12	S10	Kabwe Town Centre
13	S11	Solwezi Town
14	S12	Choma Town
15	S13	Great North Mall
16	S14	Levy Junction Mall
17	S15	Ndola Town
18	S16	Kasama Town
19	S17	Mongu Town
20	S18	Lewanika Mall

 
*/

DECLARE @Table AS TABLE
(
        B_ItemID INT,
        B_ItemStock INT,
        B_OpeningStock INT

)
DECLARE @BranchID INT
SET @BranchID=10


INSERT INTO @Table 
    
  
--BEGIN TRAN 

----UPDATE  tblTranItemStock
----SET Stock=B_ItemStock
----,OpeningStock =B_OpeningStock 
----FROM  @Table
----WHERE TranPartyID=@BranchID
---- AND Stock<>B_ItemStock
---- AND ItemID =B_ItemID
 
 ----------	ROLLBACK
 
 -------------	COMMIT
 
 
 
SELECT  IM.Itemkey, IM.ItemCode +' '+ IM.ItemName , ST.Stock ,T.B_ItemStock ,B_OpeningStock ,OpeningStock 
FROM tblTranItemStock ST
INNER JOIN @Table T
ON ItemID =B_ItemID
INNER JOIN tblItemMaster IM WITH(NOLOCK)
ON IM.ItemKey = ST.ItemID 
WHERE TranPartyID=@BranchID
 AND Stock<>T.B_ItemStock
 
