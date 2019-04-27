IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA='dbo' and TABLE_NAME='Purchase')
BEGIN
CREATE TABLE [dbo].[Purchase]
(
[Id]             [INT] IDENTITY(1,1) NOT NULL,
[VendorId]       [INT] NOT NULL DEFAULT(0),
[Date]			 [Date] NOT NULL,
[BillNo]         [Varchar](50) NOT NULL DEFAULT('No Entry Bill No'),
[TotalDiscount]  [MONEY] NOT NULL DEFAULT(0),
[ShippingCharge] [MONEY] NOT NULL DEFAULT(0),
[ExtraCharge]    [MONEY] NOT NULL DEFAULT(0),
[TotalAmount]    [MONEY] NOT NULL DEFAULT(0),
[TotalTax]		 [MONEY] NOT NULL DEFAULT(0),
[TotalNetAmount] [MONEY] NOT NULL DEFAULT(0),
[IGSTRate]	     [MONEY] NOT NULL DEFAULT(0) ,
[IGSTAmount]	 [MONEY] NOT NULL DEFAULT(0) ,
[SGSTRate]	     [MONEY] NOT NULL DEFAULT(0) ,
[SGSTAmount]	 [MONEY] NOT NULL DEFAULT(0) ,
[CGSTRate]	     [MONEY] NOT NULL DEFAULT(0) ,
[CGSTAmount]	 [MONEY] NOT NULL DEFAULT(0) ,
[TaxIGSTId]		 [INT]   NOT NULL DEFAULT(0) ,
[TaxSGSTId]		 [INT]   NOT NULL DEFAULT(0) ,
[TaxCGSTId]		 [INT]   NOT NULL DEFAULT(0),
[CreatedOn]	     [Datetime]  NOT NULL DEFAULT(GETDATE()),
[ModifiedOn]	 [datetime] NULL,
[CreatedBy]	     [INT]   NOT NULL DEFAULT(0),
[ModifiedBy]	 [INT]   NOT NULL DEFAULT(0),
[RowTS]			 [timestamp] NOT NULL,
[IsActive]		 [bit] NOT NULL DEFAULT(1)
CONSTRAINT [PK_Purchase_ID] PRIMARY KEY NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO









