USE [ERP]
GO
SET IDENTITY_INSERT [dbo].[Barcode] ON 
GO
INSERT [dbo].[Barcode] ([BarcodeID], [BarcodeNumber]) VALUES (1, N'1234567890')
GO
INSERT [dbo].[Barcode] ([BarcodeID], [BarcodeNumber]) VALUES (2, N'1234567899')
GO
INSERT [dbo].[Barcode] ([BarcodeID], [BarcodeNumber]) VALUES (3, N'1234567800')
GO
SET IDENTITY_INSERT [dbo].[Barcode] OFF
GO
SET IDENTITY_INSERT [dbo].[Brand] ON 
GO
INSERT [dbo].[Brand] ([BrandID], [BrandName], [BrandDescription]) VALUES (1, N'삼성전자', N'삼성전자가 삼성전자지뭐야')
GO
INSERT [dbo].[Brand] ([BrandID], [BrandName], [BrandDescription]) VALUES (2, N'LG전자', N'LG전자가 LG전자')
GO
INSERT [dbo].[Brand] ([BrandID], [BrandName], [BrandDescription]) VALUES (3, N'위니아', N'위니아')
GO
SET IDENTITY_INSERT [dbo].[Brand] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [CategoryDescription]) VALUES (1, N'스마트폰', N'스마트폰')
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [CategoryDescription]) VALUES (2, N'냉장고', N'냉장고')
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [CategoryDescription]) VALUES (3, N'세탁기', N'세탁기')
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [CategoryDescription]) VALUES (4, N'건조기', N'건조기')
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [CategoryDescription]) VALUES (5, N'LED TV', N'LED TV')
GO
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Tag] ON 
GO
INSERT [dbo].[Tag] ([TagID], [EPC]) VALUES (1, N'1234567880')
GO
INSERT [dbo].[Tag] ([TagID], [EPC]) VALUES (2, N'1234567888')
GO
INSERT [dbo].[Tag] ([TagID], [EPC]) VALUES (3, N'1123456789')
GO
SET IDENTITY_INSERT [dbo].[Tag] OFF
GO
