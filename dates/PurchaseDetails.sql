IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA='dbo' and TABLE_NAME='PurchaseDetails')
BEGIN
CREATE TABLE [dbo].[PurchaseDetails]
(
[ID]                  [INT] IDENTITY(1,1),
[Date]				  [Date] NOT NULL,
[PurchaseId]          [INT],
[ProductId]           [VARCHAR](100) NOT NULL,
[ProductCode]         [INT] NOT NULL,
[HSNCode]             [VARCHAR](100) NOT NULL DEFAULT(''), 
[Quantity]            [INT] NOT NULL DEFAULT(0),
[Rate]                [MONEY] NOT NULL DEFAULT(0),
[Amount]              [MONEY] NOT NULL DEFAULT(0),
[LotNo]               [VARCHAR](100) NULL,
[SizeId]              [INT],
[Expirydate]          [Datetime],
[IsFree]              [bit] NOT NULL DEFAULT(0),
[ParentProductId]	  [INT],
[CreatedOn]	          [datetime]  NOT NULL DEFAULT(GETDATE()),
[ModifiedOn]	      [datetime] NULL,
[CreatedBy]	          [INT] NULL,
[ModifiedBy]	      [INT] NULL,
[RowTS]			      [timestamp] NOT NULL,
[IsActive]		      [bit] NOT NULL DEFAULT(1)
	CONSTRAINT [PK_PurchaseDetails_ID] PRIMARY KEY NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO




