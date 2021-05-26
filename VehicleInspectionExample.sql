ALTER TABLE [dbo].[VehicleInspection] DROP CONSTRAINT [FK_VehicleInspection_VehicleMaker]
GO

IF EXISTS(SELECT * FROM sys.objects WHERE name = 'VehicleMaker' AND [type] = 'U')
DROP TABLE [VehicleMaker]
GO
IF EXISTS(SELECT * FROM sys.objects WHERE name = 'VehicleInspection' AND [type] = 'U')
DROP TABLE [VehicleInspection]
GO

CREATE TABLE [dbo].[VehicleMaker](
	[MakerID] [int] IDENTITY(1,1) NOT NULL,
	[Maker] [varchar](512) NOT NULL,
 CONSTRAINT [PK_VehicleMaker] PRIMARY KEY CLUSTERED 
(
	[MakerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[VehicleInspection](
	[RowId] [int] IDENTITY(1,1) NOT NULL,
	[VIN] [varchar](128) NOT NULL,
	[Vehicle_Maker] [int] NOT NULL,
	[Vehicle_Year] [int] NOT NULL,
	[Vehicle_Model] [varchar](128) NOT NULL,
	[Inspection_Date] [datetime] NOT NULL,
	[Inspector_Name] [varchar](128) NOT NULL,
	[Inspection_Location] [varchar](512) NOT NULL,
	[Pass_Fail] [bit] NOT NULL,
	[Notes] [text] NULL,
 CONSTRAINT [PK_Vehicle_Inspection] PRIMARY KEY CLUSTERED 
(
	[RowId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[VehicleInspection]  WITH CHECK ADD  CONSTRAINT [FK_VehicleInspection_VehicleMaker] FOREIGN KEY([Vehicle_Maker])
REFERENCES [dbo].[VehicleMaker] ([MakerID])
ON UPDATE CASCADE
GO

ALTER TABLE [dbo].[VehicleInspection] CHECK CONSTRAINT [FK_VehicleInspection_VehicleMaker]
GO


---Scaffold-DbContext "Server=dsSCSMdev01;Database=ASPState;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
