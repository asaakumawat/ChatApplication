
Alter Procedure GetAvailableStock
(
@ProductCode int=0,
@Date Date=''
)
as
BEGIN


IF @ProductCode<>0 and @Date<>'' and EXISTS(SELECT 1 FROM stockDetails Where TranDate<=@Date)
Begin
		SELECT		SUM(AQty) as AvaibleStock
		FROM		stockDetails
		WHERE		ProductCode=@ProductCode  and IaActive=1
		GROUP BY	ProductCode
end
ELSE
BEGIN
Select 0
END

END