USE [master]
GO
/****** Object:  Database [SIMS]    Script Date: 12/09/2015 1:03:42 PM ******/
CREATE DATABASE [SIMS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SIMS', FILENAME = N'G:\Meet\SIMS\SIMS.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SIMS_log', FILENAME = N'G:\Meet\SIMS\SIMS_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SIMS] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SIMS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SIMS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SIMS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SIMS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SIMS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SIMS] SET ARITHABORT OFF 
GO
ALTER DATABASE [SIMS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SIMS] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [SIMS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SIMS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SIMS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SIMS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SIMS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SIMS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SIMS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SIMS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SIMS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SIMS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SIMS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SIMS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SIMS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SIMS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SIMS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SIMS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SIMS] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SIMS] SET  MULTI_USER 
GO
ALTER DATABASE [SIMS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SIMS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SIMS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SIMS] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [SIMS]
GO
/****** Object:  StoredProcedure [dbo].[CityMasterDelete]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CityMasterDelete] (
	@CityID int
)
AS

SET NOCOUNT ON

DELETE FROM
	[CityMaster]
WHERE
	[CityID] = @CityID

GO
/****** Object:  StoredProcedure [dbo].[CityMasterGetAllRecords]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CityMasterGetAllRecords] AS

SET NOCOUNT ON

SELECT
	[CityID],
	[Name],
	[StateID]
FROM
	[CityMaster]

GO
/****** Object:  StoredProcedure [dbo].[CityMasterGetAllRecordsByState]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CityMasterGetAllRecordsByState] 
(
@StateID int
)
AS

SET NOCOUNT ON

SELECT
	[CityID],
	[Name],
	[StateID]
FROM
	[CityMaster]
WHERE
	[StateID] = @StateID

GO
/****** Object:  StoredProcedure [dbo].[CityMasterGetRecord]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CityMasterGetRecord] (
	@CityID int
)
AS

SET NOCOUNT ON

SELECT
	[CityID],
	[Name],
	[StateID]
FROM
	[CityMaster]
WHERE
	[CityID] = @CityID

GO
/****** Object:  StoredProcedure [dbo].[CityMasterSave]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CityMasterSave] (
	@CityID int,
	@Name varchar(50),
	@StateID int
)
AS

SET NOCOUNT ON


IF (@CityID = NULL OR @CityID = 0)
Begin
	INSERT INTO [CityMaster] (
		[Name],
		[StateID]
	) VALUES (
		@Name,
		@StateID
	)

	SELECT @@IDENTITY

End
Else
Begin
	UPDATE
		[CityMaster]
	SET
		[Name] = @Name,
		[StateID] = @StateID
	WHERE
		[CityID] = @CityID
	SELECT @CityID
End


GO
/****** Object:  StoredProcedure [dbo].[CompanyMasterDelete]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CompanyMasterDelete] (
	@CompanyID int
)
AS

SET NOCOUNT ON

DELETE FROM
	[CompanyMaster]
WHERE
	[CompanyID] = @CompanyID

GO
/****** Object:  StoredProcedure [dbo].[CompanyMasterGetAllRecords]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CompanyMasterGetAllRecords] AS

SET NOCOUNT ON

SELECT
	[CompanyID],
	[CityID],
	[StateID],
	[CountryID],
	[CompanyName],
	[Address],
	[Zip],
	[Mobile],
	[Phone],
	[Email],
	[CreatedOn],
	[UpdatedOn],
	[CreatedBy],
	[UpdatedBy]
FROM
	[CompanyMaster]

GO
/****** Object:  StoredProcedure [dbo].[CompanyMasterGetRecord]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CompanyMasterGetRecord] (
	@CompanyID int
)
AS

SET NOCOUNT ON

SELECT
	[CompanyID],
	[CityID],
	[StateID],
	[CountryID],
	[CompanyName],
	[Address],
	[Zip],
	[Mobile],
	[Phone],
	[Email],
	[CreatedOn],
	[UpdatedOn],
	[CreatedBy],
	[UpdatedBy]
FROM
	[CompanyMaster]
WHERE
	[CompanyID] = @CompanyID

GO
/****** Object:  StoredProcedure [dbo].[CompanyMasterSave]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CompanyMasterSave] (
	@CompanyID int,
	@CityID int,
	@StateID int,
	@CountryID int,
	@CompanyName varchar(100),
	@Address varchar(200),
	@Zip varchar(20),
	@Mobile varchar(20),
	@Phone varchar(20),
	@Email varchar(100),
	@CreatedOn datetime,
	@UpdatedOn datetime,
	@CreatedBy int,
	@UpdatedBy int
)
AS

SET NOCOUNT ON


IF (@CompanyID = NULL OR @CompanyID = 0)
Begin
	INSERT INTO [CompanyMaster] (
		[CityID],
		[StateID],
		[CountryID],
		[CompanyName],
		[Address],
		[Zip],
		[Mobile],
		[Phone],
		[Email],
		[CreatedOn],
		[UpdatedOn],
		[CreatedBy],
		[UpdatedBy]
	) VALUES (
		@CityID,
		@StateID,
		@CountryID,
		@CompanyName,
		@Address,
		@Zip,
		@Mobile,
		@Phone,
		@Email,
		@CreatedOn,
		@UpdatedOn,
		@CreatedBy,
		@UpdatedBy
	)

	SELECT @@IDENTITY

End
Else
Begin
	UPDATE
		[CompanyMaster]
	SET
		[CityID] = @CityID,
		[StateID] = @StateID,
		[CountryID] = @CountryID,
		[CompanyName] = @CompanyName,
		[Address] = @Address,
		[Zip] = @Zip,
		[Mobile] = @Mobile,
		[Phone] = @Phone,
		[Email] = @Email,
		[CreatedOn] = @CreatedOn,
		[UpdatedOn] = @UpdatedOn,
		[CreatedBy] = @CreatedBy,
		[UpdatedBy] = @UpdatedBy
	WHERE
		[CompanyID] = @CompanyID
	SELECT @CompanyID
End


GO
/****** Object:  StoredProcedure [dbo].[CountryMasterDelete]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CountryMasterDelete] (
	@CountryID int
)
AS

SET NOCOUNT ON

DELETE FROM
	[CountryMaster]
WHERE
	[CountryID] = @CountryID

GO
/****** Object:  StoredProcedure [dbo].[CountryMasterGetAllRecords]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CountryMasterGetAllRecords] AS

SET NOCOUNT ON

SELECT
	[CountryID],
	[Name]
FROM
	[CountryMaster]

GO
/****** Object:  StoredProcedure [dbo].[CountryMasterGetRecord]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CountryMasterGetRecord] (
	@CountryID int
)
AS

SET NOCOUNT ON

SELECT
	[CountryID],
	[Name]
FROM
	[CountryMaster]
WHERE
	[CountryID] = @CountryID

GO
/****** Object:  StoredProcedure [dbo].[CountryMasterSave]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CountryMasterSave] (
	@CountryID int,
	@Name varchar(100)
)
AS

SET NOCOUNT ON


IF (@CountryID = NULL OR @CountryID = 0)
Begin
	INSERT INTO [CountryMaster] (
		[Name]
	) VALUES (
		@Name
	)

	SELECT @@IDENTITY

End
Else
Begin
	UPDATE
		[CountryMaster]
	SET
		[Name] = @Name
	WHERE
		[CountryID] = @CountryID
	SELECT @CountryID
End


GO
/****** Object:  StoredProcedure [dbo].[CustomerMasterDelete]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CustomerMasterDelete] (
	@CustomerID int
)
AS

SET NOCOUNT ON

DELETE FROM
	[CustomerMaster]
WHERE
	[CustomerID] = @CustomerID

GO
/****** Object:  StoredProcedure [dbo].[CustomerMasterGetAllRecords]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CustomerMasterGetAllRecords] AS

SET NOCOUNT ON

SELECT
	[CustomerID],
	[CityID],
	[StateID],
	[CoutryID],
	[FirstName],
	[LastName],
	[Address],
	[Zip],
	[Email],
	[Mobile],
	[Phone],
	[BirthDate],
	[CreatedBy],
	[UpdatedBy],
	[CreatedOn],
	[UpdatedOn]
FROM
	[CustomerMaster]

GO
/****** Object:  StoredProcedure [dbo].[CustomerMasterGetRecord]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CustomerMasterGetRecord] (
	@CustomerID int
)
AS

SET NOCOUNT ON

SELECT
	[CustomerID],
	[CityID],
	[StateID],
	[CoutryID],
	[FirstName],
	[LastName],
	[Address],
	[Zip],
	[Email],
	[Mobile],
	[Phone],
	[BirthDate],
	[CreatedBy],
	[UpdatedBy],
	[CreatedOn],
	[UpdatedOn]
FROM
	[CustomerMaster]
WHERE
	[CustomerID] = @CustomerID

GO
/****** Object:  StoredProcedure [dbo].[CustomerMasterSave]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CustomerMasterSave] (
	@CustomerID int,
	@CityID int,
	@StateID int,
	@CoutryID int,
	@FirstName varchar(50),
	@LastName varchar(50),
	@Address varchar(200),
	@Zip varchar(20),
	@Email varchar(100),
	@Mobile varchar(20),
	@Phone varchar(20),
	@BirthDate datetime,
	@CreatedBy int,
	@UpdatedBy int,
	@CreatedOn datetime,
	@UpdatedOn datetime
)
AS

SET NOCOUNT ON


IF (@CustomerID = NULL OR @CustomerID = 0)
Begin
	INSERT INTO [CustomerMaster] (
		[CityID],
		[StateID],
		[CoutryID],
		[FirstName],
		[LastName],
		[Address],
		[Zip],
		[Email],
		[Mobile],
		[Phone],
		[BirthDate],
		[CreatedBy],
		[UpdatedBy],
		[CreatedOn],
		[UpdatedOn]
	) VALUES (
		@CityID,
		@StateID,
		@CoutryID,
		@FirstName,
		@LastName,
		@Address,
		@Zip,
		@Email,
		@Mobile,
		@Phone,
		@BirthDate,
		@CreatedBy,
		@UpdatedBy,
		@CreatedOn,
		@UpdatedOn
	)

	SELECT @@IDENTITY

End
Else
Begin
	UPDATE
		[CustomerMaster]
	SET
		[CityID] = @CityID,
		[StateID] = @StateID,
		[CoutryID] = @CoutryID,
		[FirstName] = @FirstName,
		[LastName] = @LastName,
		[Address] = @Address,
		[Zip] = @Zip,
		[Email] = @Email,
		[Mobile] = @Mobile,
		[Phone] = @Phone,
		[BirthDate] = @BirthDate,
		[CreatedBy] = @CreatedBy,
		[UpdatedBy] = @UpdatedBy,
		[CreatedOn] = @CreatedOn,
		[UpdatedOn] = @UpdatedOn
	WHERE
		[CustomerID] = @CustomerID
	SELECT @CustomerID
End


GO
/****** Object:  StoredProcedure [dbo].[ImvoiceMasterDelete]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ImvoiceMasterDelete] (
	@InvoiceID int
)
AS

SET NOCOUNT ON

DELETE FROM
	[ImvoiceMaster]
WHERE
	[InvoiceID] = @InvoiceID

GO
/****** Object:  StoredProcedure [dbo].[ImvoiceMasterGetAllRecords]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ImvoiceMasterGetAllRecords] AS

SET NOCOUNT ON

SELECT
	[InvoiceID],
	[PaymentModeID],
	[InvoiceStatusID],
	[InvoiceNumber],
	[Amount],
	[InvoiceDate],
	[PaymentDate],
	[Discount],
	[SubTotal],
	[Taxes],
	[Total],
	[RoundOfValue],
	[CreatedOn],
	[UpdatedOn],
	[CreatedBy],
	[UpdatedBy]
FROM
	[ImvoiceMaster]

GO
/****** Object:  StoredProcedure [dbo].[ImvoiceMasterGetRecord]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ImvoiceMasterGetRecord] (
	@InvoiceID int
)
AS

SET NOCOUNT ON

SELECT
	[InvoiceID],
	[PaymentModeID],
	[InvoiceStatusID],
	[InvoiceNumber],
	[Amount],
	[InvoiceDate],
	[PaymentDate],
	[Discount],
	[SubTotal],
	[Taxes],
	[Total],
	[RoundOfValue],
	[CreatedOn],
	[UpdatedOn],
	[CreatedBy],
	[UpdatedBy]
FROM
	[ImvoiceMaster]
WHERE
	[InvoiceID] = @InvoiceID

GO
/****** Object:  StoredProcedure [dbo].[ImvoiceMasterSave]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ImvoiceMasterSave] (
	@InvoiceID int,
	@PaymentModeID int,
	@InvoiceStatusID int,
	@InvoiceNumber varchar(50),
	@Amount decimal(10, 2),
	@InvoiceDate datetime,
	@PaymentDate datetime,
	@Discount decimal(10, 2),
	@SubTotal decimal(10, 2),
	@Taxes decimal(10, 2),
	@Total decimal(10, 2),
	@RoundOfValue decimal(10, 2),
	@CreatedOn datetime,
	@UpdatedOn datetime,
	@CreatedBy int,
	@UpdatedBy int
)
AS

SET NOCOUNT ON


IF (@InvoiceID = NULL OR @InvoiceID = 0)
Begin
	INSERT INTO [ImvoiceMaster] (
		[PaymentModeID],
		[InvoiceStatusID],
		[InvoiceNumber],
		[Amount],
		[InvoiceDate],
		[PaymentDate],
		[Discount],
		[SubTotal],
		[Taxes],
		[Total],
		[RoundOfValue],
		[CreatedOn],
		[UpdatedOn],
		[CreatedBy],
		[UpdatedBy]
	) VALUES (
		@PaymentModeID,
		@InvoiceStatusID,
		@InvoiceNumber,
		@Amount,
		@InvoiceDate,
		@PaymentDate,
		@Discount,
		@SubTotal,
		@Taxes,
		@Total,
		@RoundOfValue,
		@CreatedOn,
		@UpdatedOn,
		@CreatedBy,
		@UpdatedBy
	)

	SELECT @@IDENTITY

End
Else
Begin
	UPDATE
		[ImvoiceMaster]
	SET
		[PaymentModeID] = @PaymentModeID,
		[InvoiceStatusID] = @InvoiceStatusID,
		[InvoiceNumber] = @InvoiceNumber,
		[Amount] = @Amount,
		[InvoiceDate] = @InvoiceDate,
		[PaymentDate] = @PaymentDate,
		[Discount] = @Discount,
		[SubTotal] = @SubTotal,
		[Taxes] = @Taxes,
		[Total] = @Total,
		[RoundOfValue] = @RoundOfValue,
		[CreatedOn] = @CreatedOn,
		[UpdatedOn] = @UpdatedOn,
		[CreatedBy] = @CreatedBy,
		[UpdatedBy] = @UpdatedBy
	WHERE
		[InvoiceID] = @InvoiceID
	SELECT @InvoiceID
End


GO
/****** Object:  StoredProcedure [dbo].[InvoiceStatusMasterDelete]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InvoiceStatusMasterDelete] (
	@InoiceStatusID int
)
AS

SET NOCOUNT ON

DELETE FROM
	[InvoiceStatusMaster]
WHERE
	[InoiceStatusID] = @InoiceStatusID

GO
/****** Object:  StoredProcedure [dbo].[InvoiceStatusMasterGetAllRecords]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InvoiceStatusMasterGetAllRecords] AS

SET NOCOUNT ON

SELECT
	[InoiceStatusID],
	[Name],
	[CreatedOn],
	[UpdatedOn],
	[CreatedBy],
	[UpdatedBy]
FROM
	[InvoiceStatusMaster]

GO
/****** Object:  StoredProcedure [dbo].[InvoiceStatusMasterGetRecord]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InvoiceStatusMasterGetRecord] (
	@InoiceStatusID int
)
AS

SET NOCOUNT ON

SELECT
	[InoiceStatusID],
	[Name],
	[CreatedOn],
	[UpdatedOn],
	[CreatedBy],
	[UpdatedBy]
FROM
	[InvoiceStatusMaster]
WHERE
	[InoiceStatusID] = @InoiceStatusID

GO
/****** Object:  StoredProcedure [dbo].[InvoiceStatusMasterSave]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InvoiceStatusMasterSave] (
	@InoiceStatusID int,
	@Name varchar(100),
	@CreatedOn datetime,
	@UpdatedOn datetime,
	@CreatedBy int,
	@UpdatedBy int
)
AS

SET NOCOUNT ON


IF (@InoiceStatusID = NULL OR @InoiceStatusID = 0)
Begin
	INSERT INTO [InvoiceStatusMaster] (
		[Name],
		[CreatedOn],
		[UpdatedOn],
		[CreatedBy],
		[UpdatedBy]
	) VALUES (
		@Name,
		@CreatedOn,
		@UpdatedOn,
		@CreatedBy,
		@UpdatedBy
	)

	SELECT @@IDENTITY

End
Else
Begin
	UPDATE
		[InvoiceStatusMaster]
	SET
		[Name] = @Name,
		[CreatedOn] = @CreatedOn,
		[UpdatedOn] = @UpdatedOn,
		[CreatedBy] = @CreatedBy,
		[UpdatedBy] = @UpdatedBy
	WHERE
		[InoiceStatusID] = @InoiceStatusID
	SELECT @InoiceStatusID
End


GO
/****** Object:  StoredProcedure [dbo].[InvoiceTaxMasterDelete]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InvoiceTaxMasterDelete] (
	@InvoiceTaxID int
)
AS

SET NOCOUNT ON

DELETE FROM
	[InvoiceTaxMaster]
WHERE
	[InvoiceTaxID] = @InvoiceTaxID

GO
/****** Object:  StoredProcedure [dbo].[InvoiceTaxMasterGetAllRecords]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InvoiceTaxMasterGetAllRecords] AS

SET NOCOUNT ON

SELECT
	[InvoiceTaxID],
	[InvoiceID],
	[TaxID],
	[CreatedOn],
	[CreatedBy],
	[UpdatedBy],
	[UpdatedOn]
FROM
	[InvoiceTaxMaster]

GO
/****** Object:  StoredProcedure [dbo].[InvoiceTaxMasterGetRecord]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InvoiceTaxMasterGetRecord] (
	@InvoiceTaxID int
)
AS

SET NOCOUNT ON

SELECT
	[InvoiceTaxID],
	[InvoiceID],
	[TaxID],
	[CreatedOn],
	[CreatedBy],
	[UpdatedBy],
	[UpdatedOn]
FROM
	[InvoiceTaxMaster]
WHERE
	[InvoiceTaxID] = @InvoiceTaxID

GO
/****** Object:  StoredProcedure [dbo].[InvoiceTaxMasterSave]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InvoiceTaxMasterSave] (
	@InvoiceTaxID int,
	@InvoiceID int,
	@TaxID int,
	@CreatedOn datetime,
	@CreatedBy int,
	@UpdatedBy int,
	@UpdatedOn datetime
)
AS

SET NOCOUNT ON


IF (@InvoiceTaxID = NULL OR @InvoiceTaxID = 0)
Begin
	INSERT INTO [InvoiceTaxMaster] (
		[InvoiceID],
		[TaxID],
		[CreatedOn],
		[CreatedBy],
		[UpdatedBy],
		[UpdatedOn]
	) VALUES (
		@InvoiceID,
		@TaxID,
		@CreatedOn,
		@CreatedBy,
		@UpdatedBy,
		@UpdatedOn
	)

	SELECT @@IDENTITY

End
Else
Begin
	UPDATE
		[InvoiceTaxMaster]
	SET
		[InvoiceID] = @InvoiceID,
		[TaxID] = @TaxID,
		[CreatedOn] = @CreatedOn,
		[CreatedBy] = @CreatedBy,
		[UpdatedBy] = @UpdatedBy,
		[UpdatedOn] = @UpdatedOn
	WHERE
		[InvoiceTaxID] = @InvoiceTaxID
	SELECT @InvoiceTaxID
End


GO
/****** Object:  StoredProcedure [dbo].[PaymentModeMasterDelete]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PaymentModeMasterDelete] (
	@PaymentModeID int
)
AS

SET NOCOUNT ON

DELETE FROM
	[PaymentModeMaster]
WHERE
	[PaymentModeID] = @PaymentModeID

GO
/****** Object:  StoredProcedure [dbo].[PaymentModeMasterGetAllRecords]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PaymentModeMasterGetAllRecords] AS

SET NOCOUNT ON

SELECT
	[PaymentModeID],
	[Name],
	[CreatedOn],
	[UpdatedOn],
	[CreatedBy],
	[UpdatedBy]
FROM
	[PaymentModeMaster]

GO
/****** Object:  StoredProcedure [dbo].[PaymentModeMasterGetRecord]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PaymentModeMasterGetRecord] (
	@PaymentModeID int
)
AS

SET NOCOUNT ON

SELECT
	[PaymentModeID],
	[Name],
	[CreatedOn],
	[UpdatedOn],
	[CreatedBy],
	[UpdatedBy]
FROM
	[PaymentModeMaster]
WHERE
	[PaymentModeID] = @PaymentModeID

GO
/****** Object:  StoredProcedure [dbo].[PaymentModeMasterSave]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PaymentModeMasterSave] (
	@PaymentModeID int,
	@Name varchar(100),
	@CreatedOn datetime,
	@UpdatedOn datetime,
	@CreatedBy int,
	@UpdatedBy int
)
AS

SET NOCOUNT ON


IF (@PaymentModeID = NULL OR @PaymentModeID = 0)
Begin
	INSERT INTO [PaymentModeMaster] (
		[Name],
		[CreatedOn],
		[UpdatedOn],
		[CreatedBy],
		[UpdatedBy]
	) VALUES (
		@Name,
		@CreatedOn,
		@UpdatedOn,
		@CreatedBy,
		@UpdatedBy
	)

	SELECT @@IDENTITY

End
Else
Begin
	UPDATE
		[PaymentModeMaster]
	SET
		[Name] = @Name,
		[CreatedOn] = @CreatedOn,
		[UpdatedOn] = @UpdatedOn,
		[CreatedBy] = @CreatedBy,
		[UpdatedBy] = @UpdatedBy
	WHERE
		[PaymentModeID] = @PaymentModeID
	SELECT @PaymentModeID
End


GO
/****** Object:  StoredProcedure [dbo].[ProductBarCodeDetailsDelete]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ProductBarCodeDetailsDelete] (
	@ProductBarCodeDetaiID int
)
AS

SET NOCOUNT ON

DELETE FROM
	[ProductBarCodeDetails]
WHERE
	[ProductBarCodeDetaiID] = @ProductBarCodeDetaiID

GO
/****** Object:  StoredProcedure [dbo].[ProductBarCodeDetailsGetAllRecords]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ProductBarCodeDetailsGetAllRecords] AS

SET NOCOUNT ON

SELECT
	[ProductBarCodeDetaiID],
	[ProductID],
	[BarCodeNumber],
	[ExtaDiscount],
	[CreatedBy],
	[CreatedOn],
	[UpdatedBy],
	[UpdateOn],
	[IsDeleted],
	[DeletedOn],
	[IsBarcodeGenerated]
FROM
	[ProductBarCodeDetails]

GO
/****** Object:  StoredProcedure [dbo].[ProductBarCodeDetailsGetRecord]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ProductBarCodeDetailsGetRecord] (
	@ProductBarCodeDetaiID int
)
AS

SET NOCOUNT ON

SELECT
	[ProductBarCodeDetaiID],
	[ProductID],
	[BarCodeNumber],
	[ExtaDiscount],
	[CreatedBy],
	[CreatedOn],
	[UpdatedBy],
	[UpdateOn],
	[IsDeleted],
	[DeletedOn],
	[IsBarcodeGenerated]
FROM
	[ProductBarCodeDetails]
WHERE
	[ProductBarCodeDetaiID] = @ProductBarCodeDetaiID

GO
/****** Object:  StoredProcedure [dbo].[ProductBarCodeDetailsSave]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ProductBarCodeDetailsSave] (
	@ProductBarCodeDetaiID int,
	@ProductID int,
	@BarCodeNumber varchar(200),
	@ExtaDiscount int,
	@CreatedBy int,
	@CreatedOn datetime,
	@UpdatedBy int,
	@UpdateOn datetime,
	@IsDeleted bit,
	@DeletedOn datetime,
	@IsBarcodeGenerated bit
)
AS

SET NOCOUNT ON


IF (@ProductBarCodeDetaiID = NULL OR @ProductBarCodeDetaiID = 0)
Begin
	INSERT INTO [ProductBarCodeDetails] (
		[ProductID],
		[BarCodeNumber],
		[ExtaDiscount],
		[CreatedBy],
		[CreatedOn],
		[UpdatedBy],
		[UpdateOn],
		[IsDeleted],
		[DeletedOn],
		[IsBarcodeGenerated]
	) VALUES (
		@ProductID,
		@BarCodeNumber,
		@ExtaDiscount,
		@CreatedBy,
		@CreatedOn,
		@UpdatedBy,
		@UpdateOn,
		@IsDeleted,
		@DeletedOn,
		@IsBarcodeGenerated
	)

	SELECT @@IDENTITY

End
Else
Begin
	UPDATE
		[ProductBarCodeDetails]
	SET
		[ProductID] = @ProductID,
		[BarCodeNumber] = @BarCodeNumber,
		[ExtaDiscount] = @ExtaDiscount,
		[CreatedBy] = @CreatedBy,
		[CreatedOn] = @CreatedOn,
		[UpdatedBy] = @UpdatedBy,
		[UpdateOn] = @UpdateOn,
		[IsDeleted] = @IsDeleted,
		[DeletedOn] = @DeletedOn,
		[IsBarcodeGenerated] = @IsBarcodeGenerated
	WHERE
		[ProductBarCodeDetaiID] = @ProductBarCodeDetaiID
	SELECT @ProductBarCodeDetaiID
End


GO
/****** Object:  StoredProcedure [dbo].[ProductCategoryMasterDelete]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ProductCategoryMasterDelete] (
	@ProductCategoryID int
)
AS

SET NOCOUNT ON

DELETE FROM
	[ProductCategoryMaster]
WHERE
	[ProductCategoryID] = @ProductCategoryID

GO
/****** Object:  StoredProcedure [dbo].[ProductCategoryMasterGetAllRecords]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ProductCategoryMasterGetAllRecords] AS

SET NOCOUNT ON

SELECT
	[ProductCategoryID],
	[Name],
	[CreatedBy],
	[CreatedOn],
	[UpdateBy],
	[UpdatedOn]
FROM
	[ProductCategoryMaster]

GO
/****** Object:  StoredProcedure [dbo].[ProductCategoryMasterGetAllRecordsByUser]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[ProductCategoryMasterGetAllRecordsByUser]
(
@UserID int
)
as
begin


Declare @CompanyID int
Select @CompanyID = CompanyID from [User] Where ID = @UserID

SELECT
	PCM.[ProductCategoryID],
	PCM.[Name],
	PCM.[CreatedBy],
	PCM.[CreatedOn],
	PCM.[UpdateBy],
	PCM.[UpdatedOn]
FROM
	[ProductCategoryMaster] PCM
	inner join [User] U on U.CompanyID = @CompanyID

end
GO
/****** Object:  StoredProcedure [dbo].[ProductCategoryMasterGetRecord]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ProductCategoryMasterGetRecord] (
	@ProductCategoryID int
)
AS

SET NOCOUNT ON

SELECT
	[ProductCategoryID],
	[Name],
	[CreatedBy],
	[CreatedOn],
	[UpdateBy],
	[UpdatedOn]
FROM
	[ProductCategoryMaster]
WHERE
	[ProductCategoryID] = @ProductCategoryID

GO
/****** Object:  StoredProcedure [dbo].[ProductCategoryMasterSave]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ProductCategoryMasterSave] (
	@ProductCategoryID int,
	@Name varchar(100),
	@CreatedBy int,
	@CreatedOn datetime,
	@UpdateBy int,
	@UpdatedOn datetime
)
AS

SET NOCOUNT ON


IF (@ProductCategoryID = NULL OR @ProductCategoryID = 0)
Begin
	INSERT INTO [ProductCategoryMaster] (
		[Name],
		[CreatedBy],
		[CreatedOn],
		[UpdateBy],
		[UpdatedOn]
	) VALUES (
		@Name,
		@CreatedBy,
		@CreatedOn,
		@UpdateBy,
		@UpdatedOn
	)

	SELECT @@IDENTITY

End
Else
Begin
	UPDATE
		[ProductCategoryMaster]
	SET
		[Name] = @Name,
		[CreatedBy] = @CreatedBy,
		[CreatedOn] = @CreatedOn,
		[UpdateBy] = @UpdateBy,
		[UpdatedOn] = @UpdatedOn
	WHERE
		[ProductCategoryID] = @ProductCategoryID
	SELECT @ProductCategoryID
End


GO
/****** Object:  StoredProcedure [dbo].[ProductColorMasterDelete]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ProductColorMasterDelete] (
	@ColorID int
)
AS

SET NOCOUNT ON

DELETE FROM
	[ProductColorMaster]
WHERE
	[ColorID] = @ColorID

GO
/****** Object:  StoredProcedure [dbo].[ProductColorMasterGetAllRecords]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ProductColorMasterGetAllRecords] AS

SET NOCOUNT ON

SELECT
	[ColorID],
	[Name],
	[ColorCode],
	[CreatedBy],
	[CreatedOn],
	[UpdatedBy],
	[UpdatedOn]
FROM
	[ProductColorMaster]

GO
/****** Object:  StoredProcedure [dbo].[ProductColorMasterGetRecord]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ProductColorMasterGetRecord] (
	@ColorID int
)
AS

SET NOCOUNT ON

SELECT
	[ColorID],
	[Name],
	[ColorCode],
	[CreatedBy],
	[CreatedOn],
	[UpdatedBy],
	[UpdatedOn]
FROM
	[ProductColorMaster]
WHERE
	[ColorID] = @ColorID

GO
/****** Object:  StoredProcedure [dbo].[ProductColorMasterSave]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ProductColorMasterSave] (
	@ColorID int,
	@Name varchar(100),
	@ColorCode varchar(20),
	@CreatedBy int,
	@CreatedOn datetime,
	@UpdatedBy int,
	@UpdatedOn datetime
)
AS

SET NOCOUNT ON


IF (@ColorID = NULL OR @ColorID = 0)
Begin
	INSERT INTO [ProductColorMaster] (
		[Name],
		[ColorCode],
		[CreatedBy],
		[CreatedOn],
		[UpdatedBy],
		[UpdatedOn]
	) VALUES (
		@Name,
		@ColorCode,
		@CreatedBy,
		@CreatedOn,
		@UpdatedBy,
		@UpdatedOn
	)

	SELECT @@IDENTITY

End
Else
Begin
	UPDATE
		[ProductColorMaster]
	SET
		[Name] = @Name,
		[ColorCode] = @ColorCode,
		[CreatedBy] = @CreatedBy,
		[CreatedOn] = @CreatedOn,
		[UpdatedBy] = @UpdatedBy,
		[UpdatedOn] = @UpdatedOn
	WHERE
		[ColorID] = @ColorID
	SELECT @ColorID
End


GO
/****** Object:  StoredProcedure [dbo].[ProductCompanyMasterDelete]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ProductCompanyMasterDelete] (
	@CompanyID int
)
AS

SET NOCOUNT ON

DELETE FROM
	[ProductCompanyMaster]
WHERE
	[CompanyID] = @CompanyID

GO
/****** Object:  StoredProcedure [dbo].[ProductCompanyMasterGetAllRecords]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ProductCompanyMasterGetAllRecords] AS

SET NOCOUNT ON

SELECT
	[CompanyID],
	[Name],
	[CreatedBy],
	[CreatedOn],
	[UpdateBy],
	[UpdatedOn]
FROM
	[ProductCompanyMaster]

GO
/****** Object:  StoredProcedure [dbo].[ProductCompanyMasterGetRecord]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ProductCompanyMasterGetRecord] (
	@CompanyID int
)
AS

SET NOCOUNT ON

SELECT
	[CompanyID],
	[Name],
	[CreatedBy],
	[CreatedOn],
	[UpdateBy],
	[UpdatedOn]
FROM
	[ProductCompanyMaster]
WHERE
	[CompanyID] = @CompanyID

GO
/****** Object:  StoredProcedure [dbo].[ProductCompanyMasterSave]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ProductCompanyMasterSave] (
	@CompanyID int,
	@Name varchar(100),
	@CreatedBy int,
	@CreatedOn datetime,
	@UpdateBy int,
	@UpdatedOn datetime
)
AS

SET NOCOUNT ON


IF (@CompanyID = NULL OR @CompanyID = 0)
Begin
	INSERT INTO [ProductCompanyMaster] (
		[Name],
		[CreatedBy],
		[CreatedOn],
		[UpdateBy],
		[UpdatedOn]
	) VALUES (
		@Name,
		@CreatedBy,
		@CreatedOn,
		@UpdateBy,
		@UpdatedOn
	)

	SELECT @@IDENTITY

End
Else
Begin
	UPDATE
		[ProductCompanyMaster]
	SET
		[Name] = @Name,
		[CreatedBy] = @CreatedBy,
		[CreatedOn] = @CreatedOn,
		[UpdateBy] = @UpdateBy,
		[UpdatedOn] = @UpdatedOn
	WHERE
		[CompanyID] = @CompanyID
	SELECT @CompanyID
End


GO
/****** Object:  StoredProcedure [dbo].[ProductForMasterDelete]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ProductForMasterDelete] (
	@ProductForID int
)
AS

SET NOCOUNT ON

DELETE FROM
	[ProductForMaster]
WHERE
	[ProductForID] = @ProductForID

GO
/****** Object:  StoredProcedure [dbo].[ProductForMasterGetAllRecords]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ProductForMasterGetAllRecords] AS

SET NOCOUNT ON

SELECT
	[ProductForID],
	[Name],
	[CreatedOn],
	[UpdatedOn]
FROM
	[ProductForMaster]

GO
/****** Object:  StoredProcedure [dbo].[ProductForMasterGetRecord]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ProductForMasterGetRecord] (
	@ProductForID int
)
AS

SET NOCOUNT ON

SELECT
	[ProductForID],
	[Name],
	[CreatedOn],
	[UpdatedOn]
FROM
	[ProductForMaster]
WHERE
	[ProductForID] = @ProductForID

GO
/****** Object:  StoredProcedure [dbo].[ProductForMasterSave]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ProductForMasterSave] (
	@ProductForID int,
	@Name varchar(200),
	@CreatedOn datetime,
	@UpdatedOn datetime
)
AS

SET NOCOUNT ON


IF (@ProductForID = NULL OR @ProductForID = 0)
Begin
	INSERT INTO [ProductForMaster] (
		[Name],
		[CreatedOn],
		[UpdatedOn]
	) VALUES (
		@Name,
		@CreatedOn,
		@UpdatedOn
	)

	SELECT @@IDENTITY

End
Else
Begin
	UPDATE
		[ProductForMaster]
	SET
		[Name] = @Name,
		[CreatedOn] = @CreatedOn,
		[UpdatedOn] = @UpdatedOn
	WHERE
		[ProductForID] = @ProductForID
	SELECT @ProductForID
End


GO
/****** Object:  StoredProcedure [dbo].[ProductMasterDelete]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ProductMasterDelete] (
	@ProductID int
)
AS

SET NOCOUNT ON

DELETE FROM
	[ProductMaster]
WHERE
	[ProductID] = @ProductID

GO
/****** Object:  StoredProcedure [dbo].[ProductMasterGetAllRecords]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ProductMasterGetAllRecords] AS

SET NOCOUNT ON

SELECT
	[ProductID],
	[VendorID],
	[ProductCompanyID],
	[ProductSizeID],
	[ProductColorID],
	[ProductCategoryID],
	[ProductForID],
	[Name],
	[Descryption],
	[ShortCode],
	[Quantity],
	[TotalPrice],
	[PurchasePrice],
	[MRP],
	[Discount],
	[CreatedOn],
	[UpdatedOn],
	[CreatedBy],
	[UpdatedBy]
FROM
	[ProductMaster]

GO
/****** Object:  StoredProcedure [dbo].[ProductMasterGetRecord]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ProductMasterGetRecord] (
	@ProductID int
)
AS

SET NOCOUNT ON

SELECT
	[ProductID],
	[VendorID],
	[ProductCompanyID],
	[ProductSizeID],
	[ProductColorID],
	[ProductCategoryID],
	[ProductForID],
	[Name],
	[Descryption],
	[ShortCode],
	[Quantity],
	[TotalPrice],
	[PurchasePrice],
	[MRP],
	[Discount],
	[CreatedOn],
	[UpdatedOn],
	[CreatedBy],
	[UpdatedBy]
FROM
	[ProductMaster]
WHERE
	[ProductID] = @ProductID

GO
/****** Object:  StoredProcedure [dbo].[ProductMasterSave]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ProductMasterSave] (
	@ProductID int,
	@VendorID int,
	@ProductCompanyID int,
	@ProductSizeID int,
	@ProductColorID int,
	@ProductCategoryID int,
	@ProductForID int,
	@Name varchar(100),
	@Descryption varchar(300),
	@ShortCode varchar(10),
	@Quantity int,
	@TotalPrice decimal(10, 2),
	@PurchasePrice decimal(10, 2),
	@MRP decimal(10, 2),
	@Discount int,
	@CreatedOn datetime,
	@UpdatedOn datetime,
	@CreatedBy int,
	@UpdatedBy int
)
AS

SET NOCOUNT ON


IF (@ProductID = NULL OR @ProductID = 0)
Begin
	INSERT INTO [ProductMaster] (
		[VendorID],
		[ProductCompanyID],
		[ProductSizeID],
		[ProductColorID],
		[ProductCategoryID],
		[ProductForID],
		[Name],
		[Descryption],
		[ShortCode],
		[Quantity],
		[TotalPrice],
		[PurchasePrice],
		[MRP],
		[Discount],
		[CreatedOn],
		[UpdatedOn],
		[CreatedBy],
		[UpdatedBy]
	) VALUES (
		@VendorID,
		@ProductCompanyID,
		@ProductSizeID,
		@ProductColorID,
		@ProductCategoryID,
		@ProductForID,
		@Name,
		@Descryption,
		@ShortCode,
		@Quantity,
		@TotalPrice,
		@PurchasePrice,
		@MRP,
		@Discount,
		@CreatedOn,
		@UpdatedOn,
		@CreatedBy,
		@UpdatedBy
	)

	SELECT @@IDENTITY

End
Else
Begin
	UPDATE
		[ProductMaster]
	SET
		[VendorID] = @VendorID,
		[ProductCompanyID] = @ProductCompanyID,
		[ProductSizeID] = @ProductSizeID,
		[ProductColorID] = @ProductColorID,
		[ProductCategoryID] = @ProductCategoryID,
		[ProductForID] = @ProductForID,
		[Name] = @Name,
		[Descryption] = @Descryption,
		[ShortCode] = @ShortCode,
		[Quantity] = @Quantity,
		[TotalPrice] = @TotalPrice,
		[PurchasePrice] = @PurchasePrice,
		[MRP] = @MRP,
		[Discount] = @Discount,
		[CreatedOn] = @CreatedOn,
		[UpdatedOn] = @UpdatedOn,
		[CreatedBy] = @CreatedBy,
		[UpdatedBy] = @UpdatedBy
	WHERE
		[ProductID] = @ProductID
	SELECT @ProductID
End


GO
/****** Object:  StoredProcedure [dbo].[ProductSizeMasterDelete]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ProductSizeMasterDelete] (
	@ProductSizeID int
)
AS

SET NOCOUNT ON

DELETE FROM
	[ProductSizeMaster]
WHERE
	[ProductSizeID] = @ProductSizeID

GO
/****** Object:  StoredProcedure [dbo].[ProductSizeMasterGetAllRecords]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ProductSizeMasterGetAllRecords] AS

SET NOCOUNT ON

SELECT
	[ProductSizeID],
	[ProductCategoryID],
	[Name],
	[CreatedBy],
	[CreatedOn],
	[UpdateBy],
	[UpdatedOn]
FROM
	[ProductSizeMaster]

GO
/****** Object:  StoredProcedure [dbo].[ProductSizeMasterGetRecord]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ProductSizeMasterGetRecord] (
	@ProductSizeID int
)
AS

SET NOCOUNT ON

SELECT
	[ProductSizeID],
	[ProductCategoryID],
	[Name],
	[CreatedBy],
	[CreatedOn],
	[UpdateBy],
	[UpdatedOn]
FROM
	[ProductSizeMaster]
WHERE
	[ProductSizeID] = @ProductSizeID

GO
/****** Object:  StoredProcedure [dbo].[ProductSizeMasterSave]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ProductSizeMasterSave] (
	@ProductSizeID int,
	@ProductCategoryID int,
	@Name varchar(100),
	@CreatedBy int,
	@CreatedOn datetime,
	@UpdateBy int,
	@UpdatedOn datetime
)
AS

SET NOCOUNT ON


IF (@ProductSizeID = NULL OR @ProductSizeID = 0)
Begin
	INSERT INTO [ProductSizeMaster] (
		[ProductCategoryID],
		[Name],
		[CreatedBy],
		[CreatedOn],
		[UpdateBy],
		[UpdatedOn]
	) VALUES (
		@ProductCategoryID,
		@Name,
		@CreatedBy,
		@CreatedOn,
		@UpdateBy,
		@UpdatedOn
	)

	SELECT @@IDENTITY

End
Else
Begin
	UPDATE
		[ProductSizeMaster]
	SET
		[ProductCategoryID] = @ProductCategoryID,
		[Name] = @Name,
		[CreatedBy] = @CreatedBy,
		[CreatedOn] = @CreatedOn,
		[UpdateBy] = @UpdateBy,
		[UpdatedOn] = @UpdatedOn
	WHERE
		[ProductSizeID] = @ProductSizeID
	SELECT @ProductSizeID
End


GO
/****** Object:  StoredProcedure [dbo].[ProductStatusTrackingDelete]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ProductStatusTrackingDelete] (
	@StatusID int
)
AS

SET NOCOUNT ON

DELETE FROM
	[ProductStatusTracking]
WHERE
	[StatusID] = @StatusID

GO
/****** Object:  StoredProcedure [dbo].[ProductStatusTrackingGetAllRecords]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ProductStatusTrackingGetAllRecords] AS

SET NOCOUNT ON

SELECT
	[StatusID],
	[ProductBarCodeDetailD],
	[InvoiceID],
	[StockIN],
	[StockINDate],
	[StockOUTDate],
	[StockOUT],
	[CreatedBy],
	[CreatedOn],
	[UpdateBy],
	[UpdatedOn],
	[IsReversed],
	[ReversedDate],
	[IsActive]
FROM
	[ProductStatusTracking]

GO
/****** Object:  StoredProcedure [dbo].[ProductStatusTrackingGetRecord]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ProductStatusTrackingGetRecord] (
	@StatusID int
)
AS

SET NOCOUNT ON

SELECT
	[StatusID],
	[ProductBarCodeDetailD],
	[InvoiceID],
	[StockIN],
	[StockINDate],
	[StockOUTDate],
	[StockOUT],
	[CreatedBy],
	[CreatedOn],
	[UpdateBy],
	[UpdatedOn],
	[IsReversed],
	[ReversedDate],
	[IsActive]
FROM
	[ProductStatusTracking]
WHERE
	[StatusID] = @StatusID

GO
/****** Object:  StoredProcedure [dbo].[ProductStatusTrackingSave]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ProductStatusTrackingSave] (
	@StatusID int,
	@ProductBarCodeDetailD int,
	@InvoiceID int,
	@StockIN bit,
	@StockINDate datetime,
	@StockOUTDate datetime,
	@StockOUT bit,
	@CreatedBy int,
	@CreatedOn datetime,
	@UpdateBy int,
	@UpdatedOn datetime,
	@IsReversed bit,
	@ReversedDate datetime,
	@IsActive bit
)
AS

SET NOCOUNT ON


IF (@StatusID = NULL OR @StatusID = 0)
Begin
	INSERT INTO [ProductStatusTracking] (
		[ProductBarCodeDetailD],
		[InvoiceID],
		[StockIN],
		[StockINDate],
		[StockOUTDate],
		[StockOUT],
		[CreatedBy],
		[CreatedOn],
		[UpdateBy],
		[UpdatedOn],
		[IsReversed],
		[ReversedDate],
		[IsActive]
	) VALUES (
		@ProductBarCodeDetailD,
		@InvoiceID,
		@StockIN,
		@StockINDate,
		@StockOUTDate,
		@StockOUT,
		@CreatedBy,
		@CreatedOn,
		@UpdateBy,
		@UpdatedOn,
		@IsReversed,
		@ReversedDate,
		@IsActive
	)

	SELECT @@IDENTITY

End
Else
Begin
	UPDATE
		[ProductStatusTracking]
	SET
		[ProductBarCodeDetailD] = @ProductBarCodeDetailD,
		[InvoiceID] = @InvoiceID,
		[StockIN] = @StockIN,
		[StockINDate] = @StockINDate,
		[StockOUTDate] = @StockOUTDate,
		[StockOUT] = @StockOUT,
		[CreatedBy] = @CreatedBy,
		[CreatedOn] = @CreatedOn,
		[UpdateBy] = @UpdateBy,
		[UpdatedOn] = @UpdatedOn,
		[IsReversed] = @IsReversed,
		[ReversedDate] = @ReversedDate,
		[IsActive] = @IsActive
	WHERE
		[StatusID] = @StatusID
	SELECT @StatusID
End


GO
/****** Object:  StoredProcedure [dbo].[ReOrderDetailsDelete]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ReOrderDetailsDelete] (
	@ReOrderID int
)
AS

SET NOCOUNT ON

DELETE FROM
	[ReOrderDetails]
WHERE
	[ReOrderID] = @ReOrderID

GO
/****** Object:  StoredProcedure [dbo].[ReOrderDetailsGetAllRecords]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ReOrderDetailsGetAllRecords] AS

SET NOCOUNT ON

SELECT
	[ReOrderID],
	[ProductID],
	[VendorID],
	[Quantity],
	[MinimumQuntity],
	[IsActive],
	[CreatedOn],
	[UpdatedOn],
	[CreatedBy],
	[UpdatedBy]
FROM
	[ReOrderDetails]

GO
/****** Object:  StoredProcedure [dbo].[ReOrderDetailsGetRecord]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ReOrderDetailsGetRecord] (
	@ReOrderID int
)
AS

SET NOCOUNT ON

SELECT
	[ReOrderID],
	[ProductID],
	[VendorID],
	[Quantity],
	[MinimumQuntity],
	[IsActive],
	[CreatedOn],
	[UpdatedOn],
	[CreatedBy],
	[UpdatedBy]
FROM
	[ReOrderDetails]
WHERE
	[ReOrderID] = @ReOrderID

GO
/****** Object:  StoredProcedure [dbo].[ReOrderDetailsSave]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ReOrderDetailsSave] (
	@ReOrderID int,
	@ProductID int,
	@VendorID int,
	@Quantity int,
	@MinimumQuntity int,
	@IsActive bit,
	@CreatedOn datetime,
	@UpdatedOn datetime,
	@CreatedBy int,
	@UpdatedBy int
)
AS

SET NOCOUNT ON


IF (@ReOrderID = NULL OR @ReOrderID = 0)
Begin
	INSERT INTO [ReOrderDetails] (
		[ProductID],
		[VendorID],
		[Quantity],
		[MinimumQuntity],
		[IsActive],
		[CreatedOn],
		[UpdatedOn],
		[CreatedBy],
		[UpdatedBy]
	) VALUES (
		@ProductID,
		@VendorID,
		@Quantity,
		@MinimumQuntity,
		@IsActive,
		@CreatedOn,
		@UpdatedOn,
		@CreatedBy,
		@UpdatedBy
	)

	SELECT @@IDENTITY

End
Else
Begin
	UPDATE
		[ReOrderDetails]
	SET
		[ProductID] = @ProductID,
		[VendorID] = @VendorID,
		[Quantity] = @Quantity,
		[MinimumQuntity] = @MinimumQuntity,
		[IsActive] = @IsActive,
		[CreatedOn] = @CreatedOn,
		[UpdatedOn] = @UpdatedOn,
		[CreatedBy] = @CreatedBy,
		[UpdatedBy] = @UpdatedBy
	WHERE
		[ReOrderID] = @ReOrderID
	SELECT @ReOrderID
End


GO
/****** Object:  StoredProcedure [dbo].[StateMasterDelete]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[StateMasterDelete] (
	@StateID int
)
AS

SET NOCOUNT ON

DELETE FROM
	[StateMaster]
WHERE
	[StateID] = @StateID

GO
/****** Object:  StoredProcedure [dbo].[StateMasterGetAllRecords]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[StateMasterGetAllRecords] AS

SET NOCOUNT ON

SELECT
	[StateID],
	[CountryID],
	[Name]
FROM
	[StateMaster]

GO
/****** Object:  StoredProcedure [dbo].[StateMasterGetAllRecordsByCountry]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[StateMasterGetAllRecordsByCountry]
(
@CountryID int
)
AS

SET NOCOUNT ON

SELECT
	[StateID],
	[CountryID],
	[Name]
FROM
	[StateMaster]
WHERE
	[CountryID] = @CountryID

GO
/****** Object:  StoredProcedure [dbo].[StateMasterGetRecord]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[StateMasterGetRecord] (
	@StateID int
)
AS

SET NOCOUNT ON

SELECT
	[StateID],
	[CountryID],
	[Name]
FROM
	[StateMaster]
WHERE
	[StateID] = @StateID

GO
/****** Object:  StoredProcedure [dbo].[StateMasterSave]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[StateMasterSave] (
	@StateID int,
	@CountryID int,
	@Name varchar(50)
)
AS

SET NOCOUNT ON


IF (@StateID = NULL OR @StateID = 0)
Begin
	INSERT INTO [StateMaster] (
		[CountryID],
		[Name]
	) VALUES (
		@CountryID,
		@Name
	)

	SELECT @@IDENTITY

End
Else
Begin
	UPDATE
		[StateMaster]
	SET
		[CountryID] = @CountryID,
		[Name] = @Name
	WHERE
		[StateID] = @StateID
	SELECT @StateID
End


GO
/****** Object:  StoredProcedure [dbo].[TaxMasterDelete]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[TaxMasterDelete] (
	@TaxID int
)
AS

SET NOCOUNT ON

DELETE FROM
	[TaxMaster]
WHERE
	[TaxID] = @TaxID

GO
/****** Object:  StoredProcedure [dbo].[TaxMasterGetAllRecords]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[TaxMasterGetAllRecords] AS

SET NOCOUNT ON

SELECT
	[TaxID],
	[Name],
	[Percentage],
	[CreatedOn],
	[CreatedBy],
	[UpdateBy],
	[UpdatedOn]
FROM
	[TaxMaster]

GO
/****** Object:  StoredProcedure [dbo].[TaxMasterGetDetailByUser]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[TaxMasterGetDetailByUser] 
(
@UserID int
)
as
begin

Declare @CompanyID int
Select @CompanyID = CompanyID From [User] Where ID = @UserID

Select 
TM.TaxID,TM.Name,TM.Percentage,TM.CreatedOn,TM.CreatedBy,TM.UpdateBy,TM.UpdatedOn
From
TaxMaster TM
inner join [User] U on U.ID = TM.CreatedBy
Where U.CompanyID = @CompanyID

end
GO
/****** Object:  StoredProcedure [dbo].[TaxMasterGetRecord]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[TaxMasterGetRecord] (
	@TaxID int
)
AS

SET NOCOUNT ON

SELECT
	[TaxID],
	[Name],
	[Percentage],
	[CreatedOn],
	[CreatedBy],
	[UpdateBy],
	[UpdatedOn]
FROM
	[TaxMaster]
WHERE
	[TaxID] = @TaxID

GO
/****** Object:  StoredProcedure [dbo].[TaxMasterSave]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[TaxMasterSave] (
	@TaxID int,
	@Name varchar(100),
	@Percentage varchar(10),
	@CreatedOn datetime,
	@CreatedBy int,
	@UpdateBy int,
	@UpdatedOn datetime
)
AS

SET NOCOUNT ON


IF (@TaxID = NULL OR @TaxID = 0)
Begin
	INSERT INTO [TaxMaster] (
		[Name],
		[Percentage],
		[CreatedOn],
		[CreatedBy],
		[UpdateBy],
		[UpdatedOn]
	) VALUES (
		@Name,
		@Percentage,
		@CreatedOn,
		@CreatedBy,
		@UpdateBy,
		@UpdatedOn
	)

	SELECT @@IDENTITY

End
Else
Begin
	UPDATE
		[TaxMaster]
	SET
		[Name] = @Name,
		[Percentage] = @Percentage,
		[CreatedOn] = @CreatedOn,
		[CreatedBy] = @CreatedBy,
		[UpdateBy] = @UpdateBy,
		[UpdatedOn] = @UpdatedOn
	WHERE
		[TaxID] = @TaxID
	SELECT @TaxID
End


GO
/****** Object:  StoredProcedure [dbo].[UserDelete]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UserDelete] (
	@ID int
)
AS

SET NOCOUNT ON

DELETE FROM
	[User]
WHERE
	[ID] = @ID

GO
/****** Object:  StoredProcedure [dbo].[UserGetAllRecords]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UserGetAllRecords] AS

SET NOCOUNT ON

SELECT
	[ID],
	[CompanyID],
	[CityID],
	[StateID],
	[CountryID],
	[FirstName],
	[LastName],
	[UserName],
	[Password],
	[Address],
	[Zip],
	[Email],
	[Mobile],
	[Phone],
	[LastLogin],
	[CreatedOn],
	[UpdatedOn],
	[CreatedBy],
	[UpdatedBy]
FROM
	[User]

GO
/****** Object:  StoredProcedure [dbo].[UserGetLoginAuthentication]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- UserGetLoginAuthentication 'TIMOTHY','175Qaa29TWt3U1HOqdQ/9w=='
CREATE PROCEDURE [dbo].[UserGetLoginAuthentication]
 (
@UserName varchar(100),
@Password varchar(200)
)
AS

SET NOCOUNT ON

Declare @UserID int = 0

Select @UserID = ID from [User] WHERE [UserName] = @UserName AND [Password] = @Password 

IF (@UserID is not NULL OR @UserID >0)
Begin

	SELECT 
	[ID],
	[CompanyID],
	[CityID],
	[StateID],
	[CountryID],
	[FirstName],
	[LastName],
	[UserName],
	[Password],
	[Address],
	[Zip],
	[Email],
	[Mobile],
	[Phone],
	[LastLogin],
	[CreatedOn],
	[UpdatedOn],
	[CreatedBy],
	[UpdatedBy]
	FROM [User]
	WHERE ID = @UserID
end




GO
/****** Object:  StoredProcedure [dbo].[UserGetRecord]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UserGetRecord] (
	@ID int
)
AS

SET NOCOUNT ON

SELECT
	[ID],
	[CompanyID],
	[CityID],
	[StateID],
	[CountryID],
	[FirstName],
	[LastName],
	[UserName],
	[Password],
	[Address],
	[Zip],
	[Email],
	[Mobile],
	[Phone],
	[LastLogin],
	[CreatedOn],
	[UpdatedOn],
	[CreatedBy],
	[UpdatedBy]
FROM
	[User]
WHERE
	[ID] = @ID

GO
/****** Object:  StoredProcedure [dbo].[UserSave]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UserSave] (
	@ID int,
	@CompanyID int,
	@CityID int,
	@StateID int,
	@CountryID int,
	@FirstName varchar(50),
	@LastName varchar(50),
	@UserName varchar(100),
	@Password varchar(200),
	@Address varchar(200),
	@Zip varchar(20),
	@Email varchar(100),
	@Mobile varchar(20),
	@Phone varchar(20),
	@LastLogin datetime,
	@CreatedOn datetime,
	@UpdatedOn datetime,
	@CreatedBy int,
	@UpdatedBy int
)
AS

SET NOCOUNT ON


IF (@ID = NULL OR @ID = 0)
Begin
	INSERT INTO [User] (
		[CompanyID],
		[CityID],
		[StateID],
		[CountryID],
		[FirstName],
		[LastName],
		[UserName],
		[Password],
		[Address],
		[Zip],
		[Email],
		[Mobile],
		[Phone],
		[LastLogin],
		[CreatedOn],
		[UpdatedOn],
		[CreatedBy],
		[UpdatedBy]
	) VALUES (
		@CompanyID,
		@CityID,
		@StateID,
		@CountryID,
		@FirstName,
		@LastName,
		@UserName,
		@Password,
		@Address,
		@Zip,
		@Email,
		@Mobile,
		@Phone,
		@LastLogin,
		@CreatedOn,
		@UpdatedOn,
		@CreatedBy,
		@UpdatedBy
	)

	SELECT @@IDENTITY

End
Else
Begin
	UPDATE
		[User]
	SET
		[CompanyID] = @CompanyID,
		[CityID] = @CityID,
		[StateID] = @StateID,
		[CountryID] = @CountryID,
		[FirstName] = @FirstName,
		[LastName] = @LastName,
		[UserName] = @UserName,
		[Password] = @Password,
		[Address] = @Address,
		[Zip] = @Zip,
		[Email] = @Email,
		[Mobile] = @Mobile,
		[Phone] = @Phone,
		[LastLogin] = @LastLogin,
		[CreatedOn] = @CreatedOn,
		[UpdatedOn] = @UpdatedOn,
		[CreatedBy] = @CreatedBy,
		[UpdatedBy] = @UpdatedBy
	WHERE
		[ID] = @ID
	SELECT @ID
End


GO
/****** Object:  StoredProcedure [dbo].[VendorMasterDelete]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[VendorMasterDelete] (
	@VendorID int
)
AS

SET NOCOUNT ON

DELETE FROM
	[VendorMaster]
WHERE
	[VendorID] = @VendorID

GO
/****** Object:  StoredProcedure [dbo].[VendorMasterGetAllRecords]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[VendorMasterGetAllRecords] AS

SET NOCOUNT ON

SELECT
	[VendorID],
	[Name],
	[BrandName],
	[Address],
	[CityID],
	[StateID],
	[CountryID],
	[Zip],
	[Mobile],
	[Phone],
	[Fax],
	[Email],
	[CreatedBy],
	[CreatedOn],
	[UpdateBy],
	[UpdatedOn]
FROM
	[VendorMaster]

GO
/****** Object:  StoredProcedure [dbo].[VendorMasterGetAllRecordsByUser]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Exec VendorMasterGetAllRecordsByUser 1,1,5,11,null
CREATE PROCEDURE [dbo].[VendorMasterGetAllRecordsByUser]
(
@UserID int,
@PageID INT,
@Rows INT,
@SortBy Varchar(20),
@searchkeyword varchar(100) = null,
@Name varchar(100) = null,
@BrandName varchar(100) = null,
@Address varchar(300) = null,
@CityName varchar(100) = null,
@StateName varchar(100) = null,
@CountryName varchar(100) = null,
@Zip varchar(20) = null,
@Mobile varchar(15) = null,
@Phone varchar(15) = null,
@Fax varchar(15) = null,
@Email varchar(100) = null
)
AS

SET NOCOUNT ON

DECLARE @SortDirection AS VARCHAR(1) = LEFT(@SortBy,1)

Declare @CompanyID int
Select @CompanyID = CompanyID from [User] Where ID = @UserID

DECLARE @StartRowIndex INT = (@PageID -1) * @Rows 
Declare @EndRowIndex INT = @StartRowIndex + @Rows

;with cte as (
SELECT
ROW_NUMBER() Over(Order by 
	Case @SortBy when '11' then VM.[Name] END,
	Case @SortBy when '21' then VM.[Name] END DESC ,
	Case @SortBy when '12' then VM.[BrandName] END,
	Case @SortBy when '22' then VM.[BrandName] END DESC,
	Case @SortBy when '13' then VM.[Address] END,
	Case @SortBy when '23' then VM.[Address] END DESC,
	Case @SortBy when '14' then VM.[CityID] END,
	Case @SortBy when '24' then VM.[CityID] END DESC,
	Case @SortBy when '15' then VM.[StateID] END,
	Case @SortBy when '25' then VM.[StateID] END DESC,
	Case @SortBy when '16' then VM.[CountryID] END,
	Case @SortBy when '26' then VM.[CountryID] END DESC,
	Case @SortBy when '17' then VM.[Zip] END,
	Case @SortBy when '27' then VM.[Zip] END DESC,
	Case @SortBy when '18' then VM.[Mobile] END,
	Case @SortBy when '28' then VM.[Mobile] END DESC,
	Case @SortBy when '19' then VM.[Phone] END,
	Case @SortBy when '29' then VM.[Phone] END DESC,
	Case @SortBy when '110' then VM.[Fax] END,
	Case @SortBy when '210' then VM.[Fax] END DESC,
	Case @SortBy when '111' then VM.[Email] END,
	Case @SortBy when '211' then VM.[Email] END DESC,
	Case @SortDirection WHEN '1' THEN VM.[VendorID] ELSE VM.[VendorID] END DESC
	) RowID,COUNT(1) OVER () AS TotalRows,
	VM.[VendorID],
	VM.[Name],
	VM.[BrandName],
	VM.[Address],
	VM.[CityID],
	VM.[StateID],
	VM.[CountryID],
	VM.[Zip],
	VM.[Mobile],
	VM.[Phone],
	VM.[Fax],
	VM.[Email],
	VM.[CreatedBy],
	VM.[CreatedOn],
	VM.[UpdateBy],
	VM.[UpdatedOn],
	CM.Name as CountryName,
	SM.Name as StateName,
	CMM.Name as CityName
FROM
	[User] U 
	inner join [VendorMaster] VM on U.ID = VM.CreatedBy
	inner join [CountryMaster] CM on CM.CountryID = VM.CountryID
	inner join [StateMaster] SM on SM.StateID = VM.StateID
	inner join [CityMaster] CMM on CMM.CityID = VM.CityID
Where
	 (@searchkeyword is null  
		or (VM.[Name] like '%'+@searchkeyword+'%' 
		or VM.[BrandName] like '%'+@searchkeyword+'%' 
		or VM.[Address] like '%'+@searchkeyword+'%'
		or VM.[Zip] like '%'+@searchkeyword+'%'
		or VM.[Mobile] like '%'+@searchkeyword+'%'
		or VM.[Phone] like '%'+@searchkeyword+'%' 
		or VM.[Fax] like '%'+@searchkeyword+'%' 
		or VM.[Email] like '%'+@searchkeyword+'%' 
		or CM.Name like  '%'+@searchkeyword+'%' 
		or SM.Name like  '%'+@searchkeyword+'%' 
		or CMM.Name like  '%'+@searchkeyword+'%' )
	)
	AND (@Name is null or VM.[Name] like  '%'+@Name+'%')
	AND (@BrandName is null or VM.[BrandName] like  '%'+@BrandName+'%')
	AND (@Address is null or VM.[Address] like  '%'+@Address+'%')
	AND (@Zip is null or VM.[Zip] like  '%'+@Zip+'%')
	AND (@Mobile is null or VM.[Mobile] like  '%'+@Mobile+'%')
	AND (@Phone is null or VM.[Phone] like  '%'+@Phone+'%')
	AND (@Fax is null or VM.[Fax] like  '%'+@Fax+'%')
	AND (@Email is null or VM.[Email] like  '%'+@Email+'%')
	AND (@CountryName is null or CM.Name like  '%'+@CountryName+'%')
	AND (@StateName is null or SM.Name like  '%'+@StateName+'%')
	AND (@CityName is null or CMM.Name like  '%'+@CityName+'%')

	)

Select * from cte
where (RowID > @StartRowIndex and RowID <= @EndRowIndex) OR @Rows = -1
GO
/****** Object:  StoredProcedure [dbo].[VendorMasterGetRecord]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[VendorMasterGetRecord] (
	@VendorID int
)
AS

SET NOCOUNT ON

SELECT
	[VendorID],
	[Name],
	[BrandName],
	[Address],
	[CityID],
	[StateID],
	[CountryID],
	[Zip],
	[Mobile],
	[Phone],
	[Fax],
	[Email],
	[CreatedBy],
	[CreatedOn],
	[UpdateBy],
	[UpdatedOn]
FROM
	[VendorMaster]
WHERE
	[VendorID] = @VendorID

GO
/****** Object:  StoredProcedure [dbo].[VendorMasterSave]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[VendorMasterSave] (
	@VendorID int,
	@Name varchar(100),
	@BrandName varchar(100),
	@Address varchar(300),
	@CityID int,
	@StateID int,
	@CountryID int,
	@Zip varchar(20),
	@Mobile varchar(15),
	@Phone varchar(15),
	@Fax varchar(15),
	@Email varchar(100),
	@CreatedBy int,
	@CreatedOn datetime,
	@UpdateBy int,
	@UpdatedOn datetime
)
AS

SET NOCOUNT ON


IF (@VendorID = NULL OR @VendorID = 0)
Begin
	INSERT INTO [VendorMaster] (
		[Name],
		[BrandName],
		[Address],
		[CityID],
		[StateID],
		[CountryID],
		[Zip],
		[Mobile],
		[Phone],
		[Fax],
		[Email],
		[CreatedBy],
		[CreatedOn],
		[UpdateBy],
		[UpdatedOn]
	) VALUES (
		@Name,
		@BrandName,
		@Address,
		@CityID,
		@StateID,
		@CountryID,
		@Zip,
		@Mobile,
		@Phone,
		@Fax,
		@Email,
		@CreatedBy,
		@CreatedOn,
		@UpdateBy,
		@UpdatedOn
	)

	SELECT @@IDENTITY

End
Else
Begin
	UPDATE
		[VendorMaster]
	SET
		[Name] = @Name,
		[BrandName] = @BrandName,
		[Address] = @Address,
		[CityID] = @CityID,
		[StateID] = @StateID,
		[CountryID] = @CountryID,
		[Zip] = @Zip,
		[Mobile] = @Mobile,
		[Phone] = @Phone,
		[Fax] = @Fax,
		[Email] = @Email,
		[CreatedBy] = @CreatedBy,
		[CreatedOn] = @CreatedOn,
		[UpdateBy] = @UpdateBy,
		[UpdatedOn] = @UpdatedOn
	WHERE
		[VendorID] = @VendorID
	SELECT @VendorID
End


GO
/****** Object:  Table [dbo].[CityMaster]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CityMaster](
	[CityID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[StateID] [int] NOT NULL,
 CONSTRAINT [PK_CityMaster] PRIMARY KEY CLUSTERED 
(
	[CityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CompanyMaster]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CompanyMaster](
	[CompanyID] [int] IDENTITY(1,1) NOT NULL,
	[CityID] [int] NOT NULL,
	[StateID] [int] NOT NULL,
	[CountryID] [int] NOT NULL,
	[CompanyName] [varchar](100) NOT NULL,
	[Address] [varchar](200) NOT NULL,
	[Zip] [varchar](20) NOT NULL,
	[Mobile] [varchar](20) NOT NULL,
	[Phone] [varchar](20) NOT NULL,
	[Email] [varchar](100) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[UpdatedBy] [int] NOT NULL,
 CONSTRAINT [PK_CompanyMaster] PRIMARY KEY CLUSTERED 
(
	[CompanyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CountryMaster]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CountryMaster](
	[CountryID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
 CONSTRAINT [PK_CountryMaster] PRIMARY KEY CLUSTERED 
(
	[CountryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CustomerMaster]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CustomerMaster](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[CityID] [int] NOT NULL,
	[StateID] [int] NOT NULL,
	[CoutryID] [int] NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Address] [varchar](200) NOT NULL,
	[Zip] [varchar](20) NOT NULL,
	[Email] [varchar](100) NULL,
	[Mobile] [varchar](20) NOT NULL,
	[Phone] [varchar](20) NOT NULL,
	[BirthDate] [datetime] NULL,
	[CreatedBy] [int] NOT NULL,
	[UpdatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_CustomerMaster] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ImvoiceMaster]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ImvoiceMaster](
	[InvoiceID] [int] IDENTITY(1,1) NOT NULL,
	[PaymentModeID] [int] NOT NULL,
	[InvoiceStatusID] [int] NOT NULL,
	[InvoiceNumber] [varchar](50) NOT NULL,
	[Amount] [decimal](10, 2) NOT NULL,
	[InvoiceDate] [datetime] NOT NULL,
	[PaymentDate] [datetime] NOT NULL,
	[Discount] [decimal](10, 2) NOT NULL,
	[SubTotal] [decimal](10, 2) NOT NULL,
	[Taxes] [decimal](10, 2) NOT NULL,
	[Total] [decimal](10, 2) NOT NULL,
	[RoundOfValue] [decimal](10, 2) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[UpdatedBy] [int] NOT NULL,
 CONSTRAINT [PK_ImvoiceMaster] PRIMARY KEY CLUSTERED 
(
	[InvoiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[InvoiceStatusMaster]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[InvoiceStatusMaster](
	[InoiceStatusID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[UpdatedBy] [int] NOT NULL,
 CONSTRAINT [PK_InvoiceStatusMaster] PRIMARY KEY CLUSTERED 
(
	[InoiceStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[InvoiceTaxMaster]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceTaxMaster](
	[InvoiceTaxID] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceID] [int] NOT NULL,
	[TaxID] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_ProductTaxMaster] PRIMARY KEY CLUSTERED 
(
	[InvoiceTaxID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PaymentModeMaster]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PaymentModeMaster](
	[PaymentModeID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[UpdatedBy] [int] NOT NULL,
 CONSTRAINT [PK_PaymentModeMaster] PRIMARY KEY CLUSTERED 
(
	[PaymentModeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProductBarCodeDetails]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProductBarCodeDetails](
	[ProductBarCodeDetaiID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NOT NULL,
	[BarCodeNumber] [varchar](200) NOT NULL,
	[ExtaDiscount] [int] NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdateOn] [datetime] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeletedOn] [datetime] NULL,
	[IsBarcodeGenerated] [bit] NOT NULL,
 CONSTRAINT [PK_ProductBarCodeDetails] PRIMARY KEY CLUSTERED 
(
	[ProductBarCodeDetaiID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProductCategoryMaster]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProductCategoryMaster](
	[ProductCategoryID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdateBy] [int] NULL,
	[UpdatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_ProductCategoryMaster] PRIMARY KEY CLUSTERED 
(
	[ProductCategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProductColorMaster]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProductColorMaster](
	[ColorID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[ColorCode] [varchar](20) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_ProductColorMaster] PRIMARY KEY CLUSTERED 
(
	[ColorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProductCompanyMaster]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProductCompanyMaster](
	[CompanyID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdateBy] [int] NULL,
	[UpdatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_ProductCompany] PRIMARY KEY CLUSTERED 
(
	[CompanyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProductForMaster]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProductForMaster](
	[ProductForID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_ProductForMaster] PRIMARY KEY CLUSTERED 
(
	[ProductForID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProductMaster]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProductMaster](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[VendorID] [int] NULL,
	[ProductCompanyID] [int] NOT NULL,
	[ProductSizeID] [int] NULL,
	[ProductColorID] [int] NOT NULL,
	[ProductCategoryID] [int] NULL,
	[ProductForID] [int] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Descryption] [varchar](300) NOT NULL,
	[ShortCode] [varchar](10) NOT NULL,
	[Quantity] [int] NOT NULL,
	[TotalPrice] [decimal](10, 2) NOT NULL,
	[PurchasePrice] [decimal](10, 2) NOT NULL,
	[MRP] [decimal](10, 2) NOT NULL,
	[Discount] [int] NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[UpdatedBy] [int] NULL,
 CONSTRAINT [PK_ProductMaster] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProductSizeMaster]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProductSizeMaster](
	[ProductSizeID] [int] IDENTITY(1,1) NOT NULL,
	[ProductCategoryID] [int] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdateBy] [int] NULL,
	[UpdatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_ProductSizeMaster] PRIMARY KEY CLUSTERED 
(
	[ProductSizeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProductStatusTracking]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductStatusTracking](
	[StatusID] [int] IDENTITY(1,1) NOT NULL,
	[ProductBarCodeDetailD] [int] NOT NULL,
	[InvoiceID] [int] NULL,
	[StockIN] [bit] NOT NULL,
	[StockINDate] [datetime] NOT NULL,
	[StockOUTDate] [datetime] NULL,
	[StockOUT] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdateBy] [int] NULL,
	[UpdatedOn] [datetime] NOT NULL,
	[IsReversed] [bit] NOT NULL,
	[ReversedDate] [datetime] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_ProductStatusTracking] PRIMARY KEY CLUSTERED 
(
	[StatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ReOrderDetails]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReOrderDetails](
	[ReOrderID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NOT NULL,
	[VendorID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[MinimumQuntity] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[UpdatedBy] [int] NOT NULL,
 CONSTRAINT [PK_ReOrderDetails] PRIMARY KEY CLUSTERED 
(
	[ReOrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StateMaster]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StateMaster](
	[StateID] [int] IDENTITY(1,1) NOT NULL,
	[CountryID] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_StateMaster] PRIMARY KEY CLUSTERED 
(
	[StateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TaxMaster]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TaxMaster](
	[TaxID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Percentage] [varchar](10) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[UpdateBy] [int] NULL,
	[UpdatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_TaxMaster] PRIMARY KEY CLUSTERED 
(
	[TaxID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyID] [int] NOT NULL,
	[CityID] [int] NOT NULL,
	[StateID] [int] NOT NULL,
	[CountryID] [int] NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[UserName] [varchar](100) NOT NULL,
	[Password] [varchar](200) NOT NULL,
	[Address] [varchar](200) NOT NULL,
	[Zip] [varchar](20) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Mobile] [varchar](20) NOT NULL,
	[Phone] [varchar](20) NOT NULL,
	[LastLogin] [datetime] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[UpdatedBy] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VendorMaster]    Script Date: 12/09/2015 1:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VendorMaster](
	[VendorID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[BrandName] [varchar](100) NOT NULL,
	[Address] [varchar](300) NOT NULL,
	[CityID] [int] NOT NULL,
	[StateID] [int] NOT NULL,
	[CountryID] [int] NOT NULL,
	[Zip] [varchar](20) NOT NULL,
	[Mobile] [varchar](15) NOT NULL,
	[Phone] [varchar](15) NULL,
	[Fax] [varchar](15) NULL,
	[Email] [varchar](100) NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdateBy] [int] NOT NULL,
	[UpdatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_VendorMaster] PRIMARY KEY CLUSTERED 
(
	[VendorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[CityMaster] ON 

GO
INSERT [dbo].[CityMaster] ([CityID], [Name], [StateID]) VALUES (1, N'Ahmedabad', 1)
GO
INSERT [dbo].[CityMaster] ([CityID], [Name], [StateID]) VALUES (2, N'Baroda', 1)
GO
INSERT [dbo].[CityMaster] ([CityID], [Name], [StateID]) VALUES (3, N'Surat', 1)
GO
INSERT [dbo].[CityMaster] ([CityID], [Name], [StateID]) VALUES (4, N'Mumbai', 2)
GO
INSERT [dbo].[CityMaster] ([CityID], [Name], [StateID]) VALUES (5, N'Nasik', 2)
GO
INSERT [dbo].[CityMaster] ([CityID], [Name], [StateID]) VALUES (6, N'MP', 3)
GO
INSERT [dbo].[CityMaster] ([CityID], [Name], [StateID]) VALUES (7, N'Ad', 4)
GO
INSERT [dbo].[CityMaster] ([CityID], [Name], [StateID]) VALUES (8, N'sd', 5)
GO
SET IDENTITY_INSERT [dbo].[CityMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[CompanyMaster] ON 

GO
INSERT [dbo].[CompanyMaster] ([CompanyID], [CityID], [StateID], [CountryID], [CompanyName], [Address], [Zip], [Mobile], [Phone], [Email], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (1, 1, 1, 1, N'Magnific', N'Krishnanagar', N'382345', N'9601662118', N'22831618', N'abc@gmail.com', CAST(0x0000A50C00000000 AS DateTime), CAST(0x0000A50C00000000 AS DateTime), -1, -1)
GO
SET IDENTITY_INSERT [dbo].[CompanyMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[CountryMaster] ON 

GO
INSERT [dbo].[CountryMaster] ([CountryID], [Name]) VALUES (1, N'India')
GO
INSERT [dbo].[CountryMaster] ([CountryID], [Name]) VALUES (2, N'Australia')
GO
SET IDENTITY_INSERT [dbo].[CountryMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[PaymentModeMaster] ON 

GO
INSERT [dbo].[PaymentModeMaster] ([PaymentModeID], [Name], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (1, N'Cash', CAST(0x0000A50C00000000 AS DateTime), CAST(0x0000A50C00000000 AS DateTime), 1, 1)
GO
INSERT [dbo].[PaymentModeMaster] ([PaymentModeID], [Name], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (2, N'By Card', CAST(0x0000A50C00000000 AS DateTime), CAST(0x0000A50C00000000 AS DateTime), 1, 1)
GO
SET IDENTITY_INSERT [dbo].[PaymentModeMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductCategoryMaster] ON 

GO
INSERT [dbo].[ProductCategoryMaster] ([ProductCategoryID], [Name], [CreatedBy], [CreatedOn], [UpdateBy], [UpdatedOn]) VALUES (1, N'Jeans', 1, CAST(0x0000A510017EEBC0 AS DateTime), 1, CAST(0x0000A510017EEBC0 AS DateTime))
GO
INSERT [dbo].[ProductCategoryMaster] ([ProductCategoryID], [Name], [CreatedBy], [CreatedOn], [UpdateBy], [UpdatedOn]) VALUES (2, N'T-Shirt', 1, CAST(0x0000A510017F1B7C AS DateTime), 1, CAST(0x0000A510017F1B7C AS DateTime))
GO
INSERT [dbo].[ProductCategoryMaster] ([ProductCategoryID], [Name], [CreatedBy], [CreatedOn], [UpdateBy], [UpdatedOn]) VALUES (3, N'Sari', 1, CAST(0x0000A510017F59C5 AS DateTime), 1, CAST(0x0000A510017F59C5 AS DateTime))
GO
INSERT [dbo].[ProductCategoryMaster] ([ProductCategoryID], [Name], [CreatedBy], [CreatedOn], [UpdateBy], [UpdatedOn]) VALUES (4, N'Jeans', 1, CAST(0x0000A51100D15350 AS DateTime), 1, CAST(0x0000A51100D15350 AS DateTime))
GO
INSERT [dbo].[ProductCategoryMaster] ([ProductCategoryID], [Name], [CreatedBy], [CreatedOn], [UpdateBy], [UpdatedOn]) VALUES (5, N'Sari', 1, CAST(0x0000A51100D15F3B AS DateTime), 1, CAST(0x0000A51100D15F3B AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[ProductCategoryMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[StateMaster] ON 

GO
INSERT [dbo].[StateMaster] ([StateID], [CountryID], [Name]) VALUES (1, 1, N'Gujarat')
GO
INSERT [dbo].[StateMaster] ([StateID], [CountryID], [Name]) VALUES (2, 1, N'Maharashtra')
GO
INSERT [dbo].[StateMaster] ([StateID], [CountryID], [Name]) VALUES (3, 1, N'Madhyapradesh')
GO
INSERT [dbo].[StateMaster] ([StateID], [CountryID], [Name]) VALUES (4, 2, N'Adiland')
GO
INSERT [dbo].[StateMaster] ([StateID], [CountryID], [Name]) VALUES (5, 2, N'Melbourn')
GO
SET IDENTITY_INSERT [dbo].[StateMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[TaxMaster] ON 

GO
INSERT [dbo].[TaxMaster] ([TaxID], [Name], [Percentage], [CreatedOn], [CreatedBy], [UpdateBy], [UpdatedOn]) VALUES (1, N'Service Tax', N'12.44', CAST(0x0000A50F017207AE AS DateTime), 1, 1, CAST(0x0000A510017E4D72 AS DateTime))
GO
INSERT [dbo].[TaxMaster] ([TaxID], [Name], [Percentage], [CreatedOn], [CreatedBy], [UpdateBy], [UpdatedOn]) VALUES (2, N'Service Tax', N'15', CAST(0x0000A50F01723DE1 AS DateTime), 1, 1, CAST(0x0000A51100B76562 AS DateTime))
GO
INSERT [dbo].[TaxMaster] ([TaxID], [Name], [Percentage], [CreatedOn], [CreatedBy], [UpdateBy], [UpdatedOn]) VALUES (3, N'Service Tax', N'12', CAST(0x0000A50F017D4726 AS DateTime), 1, 1, CAST(0x0000A50F017D4726 AS DateTime))
GO
INSERT [dbo].[TaxMaster] ([TaxID], [Name], [Percentage], [CreatedOn], [CreatedBy], [UpdateBy], [UpdatedOn]) VALUES (4, N'Service Tax', N'12.685', CAST(0x0000A50F017D7B23 AS DateTime), 1, 1, CAST(0x0000A510017E5575 AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[TaxMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

GO
INSERT [dbo].[User] ([ID], [CompanyID], [CityID], [StateID], [CountryID], [FirstName], [LastName], [UserName], [Password], [Address], [Zip], [Email], [Mobile], [Phone], [LastLogin], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (1, 1, 1, 1, 1, N'Meet', N'Shah', N'Meet.Shah', N'pL0+HBSQbcSuP8tjyk1V9w==', N'Manekpark', N'3822345', N'abc@gmail.com', N'9601662118', N'22831618', CAST(0x0000A51100D13D48 AS DateTime), CAST(0x0000A50B00000000 AS DateTime), CAST(0x0000A50B00000000 AS DateTime), -1, -1)
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[VendorMaster] ON 

GO
INSERT [dbo].[VendorMaster] ([VendorID], [Name], [BrandName], [Address], [CityID], [StateID], [CountryID], [Zip], [Mobile], [Phone], [Fax], [Email], [CreatedBy], [CreatedOn], [UpdateBy], [UpdatedOn]) VALUES (1, N'Meet shah', N'denim', N'manek park', 1, 1, 1, N'14646', N'9601662118', N'22831618', N'', N'shahmeet111@gmail.com', 1, CAST(0x0000A50D0011F9B2 AS DateTime), 1, CAST(0x0000A50D0011FADA AS DateTime))
GO
INSERT [dbo].[VendorMaster] ([VendorID], [Name], [BrandName], [Address], [CityID], [StateID], [CountryID], [Zip], [Mobile], [Phone], [Fax], [Email], [CreatedBy], [CreatedOn], [UpdateBy], [UpdatedOn]) VALUES (2, N'Dhaval Pandya', N'denim', N'manek park', 1, 1, 1, N'88888', N'9601662118', N'22831618', N'', N'valuepadappraiser@gmail.com', 1, CAST(0x0000A50D001346CE AS DateTime), 1, CAST(0x0000A51100B733C3 AS DateTime))
GO
INSERT [dbo].[VendorMaster] ([VendorID], [Name], [BrandName], [Address], [CityID], [StateID], [CountryID], [Zip], [Mobile], [Phone], [Fax], [Email], [CreatedBy], [CreatedOn], [UpdateBy], [UpdatedOn]) VALUES (3, N'Viradiya', N'denim', N'manek park', 1, 1, 1, N'88888', N'9601662118', N'22831618', N'', N'valuepadappraiser@gmail.com', 1, CAST(0x0000A50D009FB055 AS DateTime), 1, CAST(0x0000A50D009FB055 AS DateTime))
GO
INSERT [dbo].[VendorMaster] ([VendorID], [Name], [BrandName], [Address], [CityID], [StateID], [CountryID], [Zip], [Mobile], [Phone], [Fax], [Email], [CreatedBy], [CreatedOn], [UpdateBy], [UpdatedOn]) VALUES (4, N'Dhaval Pandya 1', N'denim 1', N'manek park 1', 8, 5, 2, N'8888834', N'940852778', N'07922831618', N'3434', N'shahmeet111@gmail.com', 1, CAST(0x0000A50E0027D6FE AS DateTime), 1, CAST(0x0000A50E0027D6FE AS DateTime))
GO
INSERT [dbo].[VendorMaster] ([VendorID], [Name], [BrandName], [Address], [CityID], [StateID], [CountryID], [Zip], [Mobile], [Phone], [Fax], [Email], [CreatedBy], [CreatedOn], [UpdateBy], [UpdatedOn]) VALUES (5, N'Dhaval Pandya 2', N'denim 2', N'manek park', 5, 2, 1, N'8888834', N'940852778', N'07922831618', N'34343432', N'shahmeet111@gmail.com', 1, CAST(0x0000A50E002A6484 AS DateTime), 1, CAST(0x0000A51100B53D90 AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[VendorMaster] OFF
GO
ALTER TABLE [dbo].[CompanyMaster] ADD  CONSTRAINT [DF_CompanyMaster_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[CompanyMaster] ADD  CONSTRAINT [DF_CompanyMaster_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
ALTER TABLE [dbo].[CustomerMaster] ADD  CONSTRAINT [DF_CustomerMaster_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[CustomerMaster] ADD  CONSTRAINT [DF_CustomerMaster_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
ALTER TABLE [dbo].[ImvoiceMaster] ADD  CONSTRAINT [DF_ImvoiceMaster_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[ImvoiceMaster] ADD  CONSTRAINT [DF_ImvoiceMaster_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
ALTER TABLE [dbo].[InvoiceStatusMaster] ADD  CONSTRAINT [DF_InvoiceStatusMaster_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[InvoiceStatusMaster] ADD  CONSTRAINT [DF_InvoiceStatusMaster_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
ALTER TABLE [dbo].[InvoiceTaxMaster] ADD  CONSTRAINT [DF_ProductTaxMaster_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[InvoiceTaxMaster] ADD  CONSTRAINT [DF_ProductTaxMaster_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
ALTER TABLE [dbo].[PaymentModeMaster] ADD  CONSTRAINT [DF_PaymentModeMaster_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[PaymentModeMaster] ADD  CONSTRAINT [DF_PaymentModeMaster_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
ALTER TABLE [dbo].[ProductBarCodeDetails] ADD  CONSTRAINT [DF_ProductBarCodeDetails_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[ProductBarCodeDetails] ADD  CONSTRAINT [DF_ProductBarCodeDetails_UpdateOn]  DEFAULT (getdate()) FOR [UpdateOn]
GO
ALTER TABLE [dbo].[ProductBarCodeDetails] ADD  CONSTRAINT [DF_ProductBarCodeDetails_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[ProductCategoryMaster] ADD  CONSTRAINT [DF_ProductCategoryMaster_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[ProductCategoryMaster] ADD  CONSTRAINT [DF_ProductCategoryMaster_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
ALTER TABLE [dbo].[ProductColorMaster] ADD  CONSTRAINT [DF_ProductColorMaster_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[ProductColorMaster] ADD  CONSTRAINT [DF_ProductColorMaster_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
ALTER TABLE [dbo].[ProductCompanyMaster] ADD  CONSTRAINT [DF_ProductCompany_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[ProductCompanyMaster] ADD  CONSTRAINT [DF_ProductCompany_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
ALTER TABLE [dbo].[ProductForMaster] ADD  CONSTRAINT [DF_ProductForMaster_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[ProductForMaster] ADD  CONSTRAINT [DF_ProductForMaster_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
ALTER TABLE [dbo].[ProductMaster] ADD  CONSTRAINT [DF_ProductMaster_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[ProductMaster] ADD  CONSTRAINT [DF_ProductMaster_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
ALTER TABLE [dbo].[ProductSizeMaster] ADD  CONSTRAINT [DF_ProductSizeMaster_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[ProductSizeMaster] ADD  CONSTRAINT [DF_ProductSizeMaster_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
ALTER TABLE [dbo].[ProductStatusTracking] ADD  CONSTRAINT [DF_ProductStatusTracking_StockIN]  DEFAULT ((0)) FOR [StockIN]
GO
ALTER TABLE [dbo].[ProductStatusTracking] ADD  CONSTRAINT [DF_ProductStatusTracking_StockINDate]  DEFAULT (getdate()) FOR [StockINDate]
GO
ALTER TABLE [dbo].[ProductStatusTracking] ADD  CONSTRAINT [DF_ProductStatusTracking_StockOUT]  DEFAULT ((0)) FOR [StockOUT]
GO
ALTER TABLE [dbo].[ProductStatusTracking] ADD  CONSTRAINT [DF_ProductStatusTracking_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[ProductStatusTracking] ADD  CONSTRAINT [DF_ProductStatusTracking_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
ALTER TABLE [dbo].[ReOrderDetails] ADD  CONSTRAINT [DF_ReOrderDetails_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[ReOrderDetails] ADD  CONSTRAINT [DF_ReOrderDetails_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[ReOrderDetails] ADD  CONSTRAINT [DF_ReOrderDetails_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
ALTER TABLE [dbo].[TaxMaster] ADD  CONSTRAINT [DF_TaxMaster_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[TaxMaster] ADD  CONSTRAINT [DF_TaxMaster_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
ALTER TABLE [dbo].[VendorMaster] ADD  CONSTRAINT [DF_VendorMaster_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[VendorMaster] ADD  CONSTRAINT [DF_VendorMaster_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
ALTER TABLE [dbo].[CityMaster]  WITH CHECK ADD  CONSTRAINT [FK_CityMaster_StateMaster] FOREIGN KEY([StateID])
REFERENCES [dbo].[StateMaster] ([StateID])
GO
ALTER TABLE [dbo].[CityMaster] CHECK CONSTRAINT [FK_CityMaster_StateMaster]
GO
ALTER TABLE [dbo].[CompanyMaster]  WITH CHECK ADD  CONSTRAINT [FK_CompanyMaster_CityMaster] FOREIGN KEY([CityID])
REFERENCES [dbo].[CityMaster] ([CityID])
GO
ALTER TABLE [dbo].[CompanyMaster] CHECK CONSTRAINT [FK_CompanyMaster_CityMaster]
GO
ALTER TABLE [dbo].[CompanyMaster]  WITH CHECK ADD  CONSTRAINT [FK_CompanyMaster_CountryMaster] FOREIGN KEY([CountryID])
REFERENCES [dbo].[CountryMaster] ([CountryID])
GO
ALTER TABLE [dbo].[CompanyMaster] CHECK CONSTRAINT [FK_CompanyMaster_CountryMaster]
GO
ALTER TABLE [dbo].[CompanyMaster]  WITH CHECK ADD  CONSTRAINT [FK_CompanyMaster_StateMaster] FOREIGN KEY([StateID])
REFERENCES [dbo].[StateMaster] ([StateID])
GO
ALTER TABLE [dbo].[CompanyMaster] CHECK CONSTRAINT [FK_CompanyMaster_StateMaster]
GO
ALTER TABLE [dbo].[CustomerMaster]  WITH CHECK ADD  CONSTRAINT [FK_CustomerMaster_User] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[CustomerMaster] CHECK CONSTRAINT [FK_CustomerMaster_User]
GO
ALTER TABLE [dbo].[CustomerMaster]  WITH CHECK ADD  CONSTRAINT [FK_CustomerMaster_User1] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[CustomerMaster] CHECK CONSTRAINT [FK_CustomerMaster_User1]
GO
ALTER TABLE [dbo].[ImvoiceMaster]  WITH CHECK ADD  CONSTRAINT [FK_ImvoiceMaster_InvoiceStatusMaster] FOREIGN KEY([InvoiceStatusID])
REFERENCES [dbo].[InvoiceStatusMaster] ([InoiceStatusID])
GO
ALTER TABLE [dbo].[ImvoiceMaster] CHECK CONSTRAINT [FK_ImvoiceMaster_InvoiceStatusMaster]
GO
ALTER TABLE [dbo].[ImvoiceMaster]  WITH CHECK ADD  CONSTRAINT [FK_ImvoiceMaster_PaymentModeMaster] FOREIGN KEY([PaymentModeID])
REFERENCES [dbo].[PaymentModeMaster] ([PaymentModeID])
GO
ALTER TABLE [dbo].[ImvoiceMaster] CHECK CONSTRAINT [FK_ImvoiceMaster_PaymentModeMaster]
GO
ALTER TABLE [dbo].[ImvoiceMaster]  WITH CHECK ADD  CONSTRAINT [FK_ImvoiceMaster_User] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[ImvoiceMaster] CHECK CONSTRAINT [FK_ImvoiceMaster_User]
GO
ALTER TABLE [dbo].[ImvoiceMaster]  WITH CHECK ADD  CONSTRAINT [FK_ImvoiceMaster_User1] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[ImvoiceMaster] CHECK CONSTRAINT [FK_ImvoiceMaster_User1]
GO
ALTER TABLE [dbo].[InvoiceStatusMaster]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceStatusMaster_User] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[InvoiceStatusMaster] CHECK CONSTRAINT [FK_InvoiceStatusMaster_User]
GO
ALTER TABLE [dbo].[InvoiceStatusMaster]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceStatusMaster_User1] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[InvoiceStatusMaster] CHECK CONSTRAINT [FK_InvoiceStatusMaster_User1]
GO
ALTER TABLE [dbo].[InvoiceTaxMaster]  WITH CHECK ADD  CONSTRAINT [FK_ProductTaxMaster_ImvoiceMaster] FOREIGN KEY([InvoiceID])
REFERENCES [dbo].[ImvoiceMaster] ([InvoiceID])
GO
ALTER TABLE [dbo].[InvoiceTaxMaster] CHECK CONSTRAINT [FK_ProductTaxMaster_ImvoiceMaster]
GO
ALTER TABLE [dbo].[InvoiceTaxMaster]  WITH CHECK ADD  CONSTRAINT [FK_ProductTaxMaster_TaxMaster] FOREIGN KEY([TaxID])
REFERENCES [dbo].[TaxMaster] ([TaxID])
GO
ALTER TABLE [dbo].[InvoiceTaxMaster] CHECK CONSTRAINT [FK_ProductTaxMaster_TaxMaster]
GO
ALTER TABLE [dbo].[InvoiceTaxMaster]  WITH CHECK ADD  CONSTRAINT [FK_ProductTaxMaster_User] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[InvoiceTaxMaster] CHECK CONSTRAINT [FK_ProductTaxMaster_User]
GO
ALTER TABLE [dbo].[InvoiceTaxMaster]  WITH CHECK ADD  CONSTRAINT [FK_ProductTaxMaster_User1] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[InvoiceTaxMaster] CHECK CONSTRAINT [FK_ProductTaxMaster_User1]
GO
ALTER TABLE [dbo].[PaymentModeMaster]  WITH CHECK ADD  CONSTRAINT [FK_PaymentModeMaster_User] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[PaymentModeMaster] CHECK CONSTRAINT [FK_PaymentModeMaster_User]
GO
ALTER TABLE [dbo].[PaymentModeMaster]  WITH CHECK ADD  CONSTRAINT [FK_PaymentModeMaster_User1] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[PaymentModeMaster] CHECK CONSTRAINT [FK_PaymentModeMaster_User1]
GO
ALTER TABLE [dbo].[ProductBarCodeDetails]  WITH CHECK ADD  CONSTRAINT [FK_ProductBarCodeDetails_ProductMaster] FOREIGN KEY([ProductID])
REFERENCES [dbo].[ProductMaster] ([ProductID])
GO
ALTER TABLE [dbo].[ProductBarCodeDetails] CHECK CONSTRAINT [FK_ProductBarCodeDetails_ProductMaster]
GO
ALTER TABLE [dbo].[ProductBarCodeDetails]  WITH CHECK ADD  CONSTRAINT [FK_ProductBarCodeDetails_User] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[ProductBarCodeDetails] CHECK CONSTRAINT [FK_ProductBarCodeDetails_User]
GO
ALTER TABLE [dbo].[ProductBarCodeDetails]  WITH CHECK ADD  CONSTRAINT [FK_ProductBarCodeDetails_User1] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[ProductBarCodeDetails] CHECK CONSTRAINT [FK_ProductBarCodeDetails_User1]
GO
ALTER TABLE [dbo].[ProductCategoryMaster]  WITH CHECK ADD  CONSTRAINT [FK_ProductCategoryMaster_User] FOREIGN KEY([UpdateBy])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[ProductCategoryMaster] CHECK CONSTRAINT [FK_ProductCategoryMaster_User]
GO
ALTER TABLE [dbo].[ProductCategoryMaster]  WITH CHECK ADD  CONSTRAINT [FK_ProductCategoryMaster_User1] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[ProductCategoryMaster] CHECK CONSTRAINT [FK_ProductCategoryMaster_User1]
GO
ALTER TABLE [dbo].[ProductColorMaster]  WITH CHECK ADD  CONSTRAINT [FK_ProductColorMaster_User] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[ProductColorMaster] CHECK CONSTRAINT [FK_ProductColorMaster_User]
GO
ALTER TABLE [dbo].[ProductColorMaster]  WITH CHECK ADD  CONSTRAINT [FK_ProductColorMaster_User1] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[ProductColorMaster] CHECK CONSTRAINT [FK_ProductColorMaster_User1]
GO
ALTER TABLE [dbo].[ProductCompanyMaster]  WITH CHECK ADD  CONSTRAINT [FK_ProductCompanyMaster_User] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[ProductCompanyMaster] CHECK CONSTRAINT [FK_ProductCompanyMaster_User]
GO
ALTER TABLE [dbo].[ProductCompanyMaster]  WITH CHECK ADD  CONSTRAINT [FK_ProductCompanyMaster_User1] FOREIGN KEY([UpdateBy])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[ProductCompanyMaster] CHECK CONSTRAINT [FK_ProductCompanyMaster_User1]
GO
ALTER TABLE [dbo].[ProductMaster]  WITH CHECK ADD  CONSTRAINT [FK_ProductMaster_Category] FOREIGN KEY([ProductCategoryID])
REFERENCES [dbo].[ProductCategoryMaster] ([ProductCategoryID])
GO
ALTER TABLE [dbo].[ProductMaster] CHECK CONSTRAINT [FK_ProductMaster_Category]
GO
ALTER TABLE [dbo].[ProductMaster]  WITH CHECK ADD  CONSTRAINT [FK_ProductMaster_ProductColorMaster] FOREIGN KEY([ProductColorID])
REFERENCES [dbo].[ProductColorMaster] ([ColorID])
GO
ALTER TABLE [dbo].[ProductMaster] CHECK CONSTRAINT [FK_ProductMaster_ProductColorMaster]
GO
ALTER TABLE [dbo].[ProductMaster]  WITH CHECK ADD  CONSTRAINT [FK_ProductMaster_ProductCompanyMaster] FOREIGN KEY([ProductCompanyID])
REFERENCES [dbo].[ProductCompanyMaster] ([CompanyID])
GO
ALTER TABLE [dbo].[ProductMaster] CHECK CONSTRAINT [FK_ProductMaster_ProductCompanyMaster]
GO
ALTER TABLE [dbo].[ProductMaster]  WITH CHECK ADD  CONSTRAINT [FK_ProductMaster_ProductForMaster] FOREIGN KEY([ProductForID])
REFERENCES [dbo].[ProductForMaster] ([ProductForID])
GO
ALTER TABLE [dbo].[ProductMaster] CHECK CONSTRAINT [FK_ProductMaster_ProductForMaster]
GO
ALTER TABLE [dbo].[ProductMaster]  WITH CHECK ADD  CONSTRAINT [FK_ProductMaster_ProductSizeMaster] FOREIGN KEY([ProductSizeID])
REFERENCES [dbo].[ProductSizeMaster] ([ProductSizeID])
GO
ALTER TABLE [dbo].[ProductMaster] CHECK CONSTRAINT [FK_ProductMaster_ProductSizeMaster]
GO
ALTER TABLE [dbo].[ProductMaster]  WITH CHECK ADD  CONSTRAINT [FK_ProductMaster_User] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[ProductMaster] CHECK CONSTRAINT [FK_ProductMaster_User]
GO
ALTER TABLE [dbo].[ProductMaster]  WITH CHECK ADD  CONSTRAINT [FK_ProductMaster_User1] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[ProductMaster] CHECK CONSTRAINT [FK_ProductMaster_User1]
GO
ALTER TABLE [dbo].[ProductMaster]  WITH CHECK ADD  CONSTRAINT [FK_ProductMaster_VendorMaster] FOREIGN KEY([VendorID])
REFERENCES [dbo].[VendorMaster] ([VendorID])
GO
ALTER TABLE [dbo].[ProductMaster] CHECK CONSTRAINT [FK_ProductMaster_VendorMaster]
GO
ALTER TABLE [dbo].[ProductSizeMaster]  WITH CHECK ADD  CONSTRAINT [FK_ProductSizeMaster_ProductCategoryMaster] FOREIGN KEY([ProductCategoryID])
REFERENCES [dbo].[ProductCategoryMaster] ([ProductCategoryID])
GO
ALTER TABLE [dbo].[ProductSizeMaster] CHECK CONSTRAINT [FK_ProductSizeMaster_ProductCategoryMaster]
GO
ALTER TABLE [dbo].[ProductSizeMaster]  WITH CHECK ADD  CONSTRAINT [FK_ProductSizeMaster_User] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[ProductSizeMaster] CHECK CONSTRAINT [FK_ProductSizeMaster_User]
GO
ALTER TABLE [dbo].[ProductSizeMaster]  WITH CHECK ADD  CONSTRAINT [FK_ProductSizeMaster_User1] FOREIGN KEY([UpdateBy])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[ProductSizeMaster] CHECK CONSTRAINT [FK_ProductSizeMaster_User1]
GO
ALTER TABLE [dbo].[ProductStatusTracking]  WITH CHECK ADD  CONSTRAINT [FK_ProductStatusTracking_ProductBarCodeDetails] FOREIGN KEY([ProductBarCodeDetailD])
REFERENCES [dbo].[ProductBarCodeDetails] ([ProductBarCodeDetaiID])
GO
ALTER TABLE [dbo].[ProductStatusTracking] CHECK CONSTRAINT [FK_ProductStatusTracking_ProductBarCodeDetails]
GO
ALTER TABLE [dbo].[ProductStatusTracking]  WITH CHECK ADD  CONSTRAINT [FK_ProductStatusTracking_User] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[ProductStatusTracking] CHECK CONSTRAINT [FK_ProductStatusTracking_User]
GO
ALTER TABLE [dbo].[ProductStatusTracking]  WITH CHECK ADD  CONSTRAINT [FK_ProductStatusTracking_User1] FOREIGN KEY([UpdateBy])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[ProductStatusTracking] CHECK CONSTRAINT [FK_ProductStatusTracking_User1]
GO
ALTER TABLE [dbo].[ReOrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_ReOrderDetails_ProductMaster] FOREIGN KEY([ProductID])
REFERENCES [dbo].[ProductMaster] ([ProductID])
GO
ALTER TABLE [dbo].[ReOrderDetails] CHECK CONSTRAINT [FK_ReOrderDetails_ProductMaster]
GO
ALTER TABLE [dbo].[ReOrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_ReOrderDetails_User] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[ReOrderDetails] CHECK CONSTRAINT [FK_ReOrderDetails_User]
GO
ALTER TABLE [dbo].[ReOrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_ReOrderDetails_User1] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[ReOrderDetails] CHECK CONSTRAINT [FK_ReOrderDetails_User1]
GO
ALTER TABLE [dbo].[ReOrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_ReOrderDetails_VendorMaster] FOREIGN KEY([VendorID])
REFERENCES [dbo].[VendorMaster] ([VendorID])
GO
ALTER TABLE [dbo].[ReOrderDetails] CHECK CONSTRAINT [FK_ReOrderDetails_VendorMaster]
GO
ALTER TABLE [dbo].[StateMaster]  WITH CHECK ADD  CONSTRAINT [FK_StateMaster_CountryMaster] FOREIGN KEY([CountryID])
REFERENCES [dbo].[CountryMaster] ([CountryID])
GO
ALTER TABLE [dbo].[StateMaster] CHECK CONSTRAINT [FK_StateMaster_CountryMaster]
GO
ALTER TABLE [dbo].[TaxMaster]  WITH CHECK ADD  CONSTRAINT [FK_TaxMaster_User] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[TaxMaster] CHECK CONSTRAINT [FK_TaxMaster_User]
GO
ALTER TABLE [dbo].[TaxMaster]  WITH CHECK ADD  CONSTRAINT [FK_TaxMaster_User1] FOREIGN KEY([UpdateBy])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[TaxMaster] CHECK CONSTRAINT [FK_TaxMaster_User1]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_CityMaster] FOREIGN KEY([CityID])
REFERENCES [dbo].[CityMaster] ([CityID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_CityMaster]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_CompanyMaster] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[CompanyMaster] ([CompanyID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_CompanyMaster]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_CountryMaster] FOREIGN KEY([CountryID])
REFERENCES [dbo].[CountryMaster] ([CountryID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_CountryMaster]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_StateMaster] FOREIGN KEY([StateID])
REFERENCES [dbo].[StateMaster] ([StateID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_StateMaster]
GO
ALTER TABLE [dbo].[VendorMaster]  WITH CHECK ADD  CONSTRAINT [FK_VendorMaster_CityMaster] FOREIGN KEY([CityID])
REFERENCES [dbo].[CityMaster] ([CityID])
GO
ALTER TABLE [dbo].[VendorMaster] CHECK CONSTRAINT [FK_VendorMaster_CityMaster]
GO
ALTER TABLE [dbo].[VendorMaster]  WITH CHECK ADD  CONSTRAINT [FK_VendorMaster_CountryMaster] FOREIGN KEY([CountryID])
REFERENCES [dbo].[CountryMaster] ([CountryID])
GO
ALTER TABLE [dbo].[VendorMaster] CHECK CONSTRAINT [FK_VendorMaster_CountryMaster]
GO
ALTER TABLE [dbo].[VendorMaster]  WITH CHECK ADD  CONSTRAINT [FK_VendorMaster_StateMaster] FOREIGN KEY([StateID])
REFERENCES [dbo].[StateMaster] ([StateID])
GO
ALTER TABLE [dbo].[VendorMaster] CHECK CONSTRAINT [FK_VendorMaster_StateMaster]
GO
ALTER TABLE [dbo].[VendorMaster]  WITH CHECK ADD  CONSTRAINT [FK_VendorMaster_User] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[VendorMaster] CHECK CONSTRAINT [FK_VendorMaster_User]
GO
ALTER TABLE [dbo].[VendorMaster]  WITH CHECK ADD  CONSTRAINT [FK_VendorMaster_User1] FOREIGN KEY([UpdateBy])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[VendorMaster] CHECK CONSTRAINT [FK_VendorMaster_User1]
GO
USE [master]
GO
ALTER DATABASE [SIMS] SET  READ_WRITE 
GO
