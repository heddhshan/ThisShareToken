
USE [ShareTokenDb]
GO
/****** Object:  Table [dbo].[AppInfo_OnPublishAppDownload]    Script Date: 2023/8/20 20:48:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppInfo_OnPublishAppDownload](
	[ChainId] [int] NOT NULL,
	[ContractAddress] [nvarchar](43) NOT NULL,
	[BlockNumber] [bigint] NOT NULL,
	[TransactionHash] [nvarchar](66) NOT NULL,
	[_eventId] [bigint] NOT NULL,
	[_AppId] [int] NULL,
	[_PlatformId] [int] NULL,
	[_Version] [int] NULL,
	[_HttpLink] [nvarchar](1024) NULL,
	[_BTLink] [nvarchar](1024) NULL,
	[_eMuleLink] [nvarchar](1024) NULL,
	[_IpfsLink] [nvarchar](1024) NULL,
	[_OtherLink] [nvarchar](1024) NULL,
 CONSTRAINT [PK_AppInfo_OnPublishAppDownload] PRIMARY KEY CLUSTERED 
(
	[ChainId] ASC,
	[ContractAddress] ASC,
	[_eventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppInfo_OnPublishAppVersion]    Script Date: 2023/8/20 20:48:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppInfo_OnPublishAppVersion](
	[ChainId] [int] NOT NULL,
	[ContractAddress] [nvarchar](43) NOT NULL,
	[BlockNumber] [bigint] NOT NULL,
	[TransactionHash] [nvarchar](66) NOT NULL,
	[_eventId] [bigint] NOT NULL,
	[_AppId] [int] NULL,
	[_PlatformId] [int] NULL,
	[_Version] [int] NULL,
	[_Sha256Value] [nvarchar](128) NULL,
	[_AppName] [nvarchar](128) NULL,
	[_UpdateInfo] [nvarchar](1024) NULL,
	[_IconUri] [nvarchar](1024) NULL,
 CONSTRAINT [PK_AppInfo_OnPublishAppVersion] PRIMARY KEY CLUSTERED 
(
	[ChainId] ASC,
	[ContractAddress] ASC,
	[_eventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Appinfo_OnPublishNotice]    Script Date: 2023/8/20 20:48:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appinfo_OnPublishNotice](
	[ChainId] [int] NOT NULL,
	[ContractAddress] [nvarchar](43) NOT NULL,
	[BlockNumber] [bigint] NOT NULL,
	[TransactionHash] [nvarchar](66) NOT NULL,
	[_publisher] [nvarchar](43) NOT NULL,
	[_appId] [bigint] NOT NULL,
	[_subject] [nvarchar](1024) NOT NULL,
	[_body] [nvarchar](max) NOT NULL,
	[BlockTime] [datetime] NULL,
 CONSTRAINT [PK_Tools_OnPublishNotice] PRIMARY KEY NONCLUSTERED 
(
	[ChainId] ASC,
	[TransactionHash] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BasicBusShareToken_DividendsDistributed]    Script Date: 2023/8/20 20:48:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BasicBusShareToken_DividendsDistributed](
	[ChainId] [int] NOT NULL,
	[ContractAddress] [nvarchar](43) NOT NULL,
	[BlockNumber] [bigint] NOT NULL,
	[TransactionHash] [nvarchar](66) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[DivToken] [nvarchar](43) NOT NULL,
	[_dividendIndex] [bigint] NOT NULL,
	[_caller] [nvarchar](43) NOT NULL,
	[_waitingDivAmount] [float] NOT NULL,
	[_realDivAmount] [float] NOT NULL,
	[_currentSupply] [float] NOT NULL,
	[_divHeight] [float] NOT NULL,
	[_waitingDivAmount_Text] [nvarchar](80) NOT NULL,
	[_realDivAmount_Text] [nvarchar](80) NOT NULL,
	[_currentSupply_Text] [nvarchar](80) NOT NULL,
	[_divHeight_Text] [nvarchar](80) NOT NULL,
 CONSTRAINT [PK_BasicBusShareToken_DividendsDistributed] PRIMARY KEY CLUSTERED 
(
	[ChainId] ASC,
	[ContractAddress] ASC,
	[_dividendIndex] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BasicBusShareToken_IconImage]    Script Date: 2023/8/20 20:48:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BasicBusShareToken_IconImage](
	[ChainId] [int] NOT NULL,
	[ContractAddress] [nvarchar](43) NOT NULL,
	[BlockNumber] [bigint] NOT NULL,
	[TransactionHash] [nvarchar](66) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[_sender] [nvarchar](43) NOT NULL,
	[_fileName] [nvarchar](128) NOT NULL,
	[_data] [varbinary](max) NOT NULL,
	[LocalFileName] [nvarchar](2048) NOT NULL,
 CONSTRAINT [PK_ShareToken_IconImage] PRIMARY KEY NONCLUSTERED 
(
	[ChainId] ASC,
	[ContractAddress] ASC,
	[TransactionHash] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BasicBusShareToken_NoticePublish]    Script Date: 2023/8/20 20:48:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BasicBusShareToken_NoticePublish](
	[ChainId] [int] NOT NULL,
	[ContractAddress] [nvarchar](43) NOT NULL,
	[BlockNumber] [bigint] NOT NULL,
	[TransactionHash] [nvarchar](66) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[_sender] [nvarchar](43) NOT NULL,
	[_noticeId] [bigint] NOT NULL,
	[_notice] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_ShareToken_NoticePublish] PRIMARY KEY CLUSTERED 
(
	[ChainId] ASC,
	[ContractAddress] ASC,
	[_noticeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BasicBusShareTokenFactory_OnAddShareToken]    Script Date: 2023/8/20 20:48:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BasicBusShareTokenFactory_OnAddShareToken](
	[ChainId] [int] NOT NULL,
	[ContractAddress] [nvarchar](43) NOT NULL,
	[BlockNumber] [bigint] NOT NULL,
	[TransactionHash] [nvarchar](66) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[_sender] [nvarchar](43) NOT NULL,
	[_shareTokenAddrss] [nvarchar](43) NOT NULL,
	[ShareTokenName] [nvarchar](128) NULL,
	[ShareTokenCurrentTotalSupply] [float] NULL,
	[ShareTokenDecimals] [int] NULL,
	[ShareTokenSymbol] [nvarchar](64) NULL,
	[ShareTokenIconLocalFileName] [nvarchar](2048) NULL,
	[DivTokenAddress] [nvarchar](43) NULL,
	[DivTokenSymbol] [nvarchar](64) NULL,
	[DivTokenCurrentAmount] [float] NULL,
	[UpdateBlockNumber] [bigint] NULL,
	[DivTokenImagePath] [nvarchar](2048) NULL,
 CONSTRAINT [PK_BasicBusShareTokenFactory_OnAddShareToken] PRIMARY KEY CLUSTERED 
(
	[ChainId] ASC,
	[ContractAddress] ASC,
	[TransactionHash] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContEventBlockNum]    Script Date: 2023/8/20 20:48:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContEventBlockNum](
	[ChainId] [int] NOT NULL,
	[ContractAddress] [nvarchar](43) NOT NULL,
	[EventName] [nvarchar](256) NOT NULL,
	[LastBlockNumber] [bigint] NOT NULL,
 CONSTRAINT [PK_ContEventBlockNum] PRIMARY KEY CLUSTERED 
(
	[ChainId] ASC,
	[ContractAddress] ASC,
	[EventName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DivShareTokenPair_DividendsDistributed]    Script Date: 2023/8/20 20:48:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DivShareTokenPair_DividendsDistributed](
	[ChainId] [int] NOT NULL,
	[ContractAddress] [nvarchar](43) NOT NULL,
	[BlockNumber] [bigint] NOT NULL,
	[TransactionHash] [nvarchar](66) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[DivTokenAddress] [nvarchar](43) NOT NULL,
	[_dividendIndex] [bigint] NOT NULL,
	[_from] [nvarchar](43) NOT NULL,
	[_divAmount] [float] NOT NULL,
	[_currentLiqValue] [float] NOT NULL,
	[_shareTokenHeight] [float] NOT NULL,
	[_pairHeight] [float] NOT NULL,
	[_pairHeight_Text] [nvarchar](80) NOT NULL,
	[_shareTokenHeight_Text] [nvarchar](80) NOT NULL,
	[_divAmount_Text] [nvarchar](80) NOT NULL,
	[_currentLiqValue_Text] [nvarchar](80) NOT NULL,
 CONSTRAINT [PK_DivExPair_DividendsDistributed] PRIMARY KEY NONCLUSTERED 
(
	[ChainId] ASC,
	[ContractAddress] ASC,
	[TransactionHash] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DivShareTokenPairFactory_OnAddDivExPair]    Script Date: 2023/8/20 20:48:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DivShareTokenPairFactory_OnAddDivExPair](
	[ChainId] [int] NOT NULL,
	[ContractAddress] [nvarchar](43) NOT NULL,
	[BlockNumber] [bigint] NOT NULL,
	[TransactionHash] [nvarchar](66) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[_sender] [nvarchar](43) NOT NULL,
	[_shareToken] [nvarchar](43) NOT NULL,
	[_oldPair] [nvarchar](43) NOT NULL,
	[_newPair] [nvarchar](43) NOT NULL,
	[_powerM] [int] NOT NULL,
	[IsPaused] [bit] NOT NULL,
	[ShareTokenName] [nvarchar](128) NULL,
	[ShareTokenCurrentLiqAmount] [float] NULL,
	[ShareTokenDecimals] [int] NULL,
	[ShareTokenSymbol] [nvarchar](64) NULL,
	[DivTokenAddress] [nvarchar](43) NULL,
	[DivTokenSymbol] [nvarchar](64) NULL,
	[DivTokenCurrentLiqAmount] [float] NULL,
	[UpdateBlockNumber] [bigint] NULL,
	[Price0] [nvarchar](36) NULL,
	[Price1] [nvarchar](36) NULL,
	[DivTokenImagePath] [nvarchar](2048) NULL,
	[ShareTokenIconLocalFileName] [nvarchar](2048) NULL,
 CONSTRAINT [PK_DivExPairFactory_DivExPairNew] PRIMARY KEY CLUSTERED 
(
	[ChainId] ASC,
	[ContractAddress] ASC,
	[TransactionHash] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DutchAuction_OnBuy]    Script Date: 2023/8/20 20:48:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DutchAuction_OnBuy](
	[ChainId] [int] NOT NULL,
	[ContractAddress] [nvarchar](43) NOT NULL,
	[BlockNumber] [bigint] NOT NULL,
	[TransactionHash] [nvarchar](66) NOT NULL,
	[_buyer] [nvarchar](43) NOT NULL,
	[_seller] [nvarchar](43) NOT NULL,
	[_sellHash] [nvarchar](66) NOT NULL,
	[_sellTokenAmountOut] [float] NOT NULL,
	[_buyTokenAmountIn] [float] NOT NULL,
	[_sellTokenAmountOut_Text] [nvarchar](80) NOT NULL,
	[_buyTokenAmountIn_Text] [nvarchar](80) NOT NULL,
 CONSTRAINT [PK_DutchAuction_OnBuy_1] PRIMARY KEY CLUSTERED 
(
	[ChainId] ASC,
	[ContractAddress] ASC,
	[_sellHash] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DutchAuction_OnSell]    Script Date: 2023/8/20 20:48:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DutchAuction_OnSell](
	[ChainId] [int] NOT NULL,
	[ContractAddress] [nvarchar](43) NOT NULL,
	[BlockNumber] [bigint] NOT NULL,
	[TransactionHash] [nvarchar](66) NOT NULL,
	[_seller] [nvarchar](43) NOT NULL,
	[_tokenSell] [nvarchar](43) NOT NULL,
	[_tokenSellAmount] [float] NULL,
	[_tokenBuy] [nvarchar](43) NOT NULL,
	[_buyHighestAmount] [float] NOT NULL,
	[_sellId] [bigint] NOT NULL,
	[_sellHash] [nvarchar](66) NOT NULL,
	[curTokenSellAmount] [float] NULL,
	[next1Block] [bigint] NULL,
	[next1Price] [float] NULL,
	[next2Block] [bigint] NULL,
	[next2Price] [float] NULL,
	[next3Block] [bigint] NULL,
	[next3Price] [float] NULL,
	[_tokenSellAmount_Text] [nvarchar](80) NOT NULL,
	[_buyHighestAmount_Text] [nvarchar](80) NOT NULL,
	[curTokenSellAmount_Text] [nvarchar](80) NULL,
	[CreateTime] [datetime] NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
	[IsDone] [bit] NOT NULL,
 CONSTRAINT [PK_DutchAuction_OnBuy] PRIMARY KEY CLUSTERED 
(
	[ChainId] ASC,
	[ContractAddress] ASC,
	[_sellId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DutchAuctionParam]    Script Date: 2023/8/20 20:48:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DutchAuctionParam](
	[ChainId] [int] NOT NULL,
	[ContractAddress] [nvarchar](43) NOT NULL,
	[tokenSell] [nvarchar](43) NOT NULL,
	[tokenSellAmountSellMin] [float] NOT NULL,
	[tokenSellAmountBuyMin] [float] NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
	[tokenSellAmountSellMin_Text] [nvarchar](80) NOT NULL,
	[tokenSellAmountBuyMin_Text] [nvarchar](80) NOT NULL,
 CONSTRAINT [PK_DutchAuctionParam] PRIMARY KEY CLUSTERED 
(
	[ChainId] ASC,
	[ContractAddress] ASC,
	[tokenSell] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KeyStore_Address]    Script Date: 2023/8/20 20:48:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KeyStore_Address](
	[AddressAlias] [nvarchar](64) NULL,
	[Address] [nvarchar](43) NOT NULL,
	[FilePath] [nvarchar](2048) NOT NULL,
	[KeyStoreText] [nvarchar](2048) NULL,
	[IsTxAddress] [bit] NULL,
	[HasPrivatekey] [bit] NULL,
 CONSTRAINT [PK_KeyStore_Address] PRIMARY KEY CLUSTERED 
(
	[Address] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Language]    Script Date: 2023/8/20 20:48:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Language](
	[LCID] [int] NOT NULL,
	[CultureInfoName] [nvarchar](32) NOT NULL,
	[TwoLetterISOLanguageName] [nvarchar](8) NOT NULL,
	[ThreeLetterISOLanguageName] [nvarchar](8) NOT NULL,
	[ThreeLetterWindowsLanguageName] [nvarchar](8) NOT NULL,
	[NativeName] [nvarchar](64) NOT NULL,
	[DisplayName] [nvarchar](64) NOT NULL,
	[EnglishName] [nvarchar](64) NOT NULL,
	[IsSelected] [bit] NOT NULL,
	[ItemsNumber] [int] NULL,
 CONSTRAINT [PK_T_Language] PRIMARY KEY CLUSTERED 
(
	[CultureInfoName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_OriginalText]    Script Date: 2023/8/20 20:48:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_OriginalText](
	[OriginalHash] [nvarchar](64) NOT NULL,
	[OriginalText] [nvarchar](4000) NOT NULL,
 CONSTRAINT [PK_T_OriginalText1] PRIMARY KEY CLUSTERED 
(
	[OriginalHash] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_OriginalText_BAK]    Script Date: 2023/8/20 20:48:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_OriginalText_BAK](
	[OriginalHash] [nvarchar](64) NOT NULL,
	[OriginalText] [nvarchar](4000) NOT NULL,
 CONSTRAINT [PK_T_OriginalText] PRIMARY KEY CLUSTERED 
(
	[OriginalHash] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Refrence]    Script Date: 2023/8/20 20:48:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Refrence](
	[OriginalHash] [nvarchar](64) NOT NULL,
	[RefrenceFormHash] [nvarchar](64) NOT NULL,
	[RefrenceForm] [nvarchar](3096) NULL,
 CONSTRAINT [PK_T_Refrence] PRIMARY KEY CLUSTERED 
(
	[OriginalHash] ASC,
	[RefrenceFormHash] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_TranslationText]    Script Date: 2023/8/20 20:48:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_TranslationText](
	[OriginalHash] [nvarchar](64) NOT NULL,
	[LanCode] [nvarchar](8) NOT NULL,
	[TranslationText] [nvarchar](4000) NOT NULL,
 CONSTRAINT [PK_T_TranslationText] PRIMARY KEY CLUSTERED 
(
	[OriginalHash] ASC,
	[LanCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_TranslationText_BAK]    Script Date: 2023/8/20 20:48:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_TranslationText_BAK](
	[OriginalHash] [nvarchar](64) NOT NULL,
	[LanCode] [nvarchar](8) NOT NULL,
	[TranslationText] [nvarchar](4000) NOT NULL,
 CONSTRAINT [PK_T_TranslationText_1] PRIMARY KEY CLUSTERED 
(
	[OriginalHash] ASC,
	[LanCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Token]    Script Date: 2023/8/20 20:48:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Token](
	[ChainId] [int] NOT NULL,
	[Name] [nvarchar](64) NOT NULL,
	[Address] [nvarchar](43) NOT NULL,
	[Decimals] [int] NOT NULL,
	[Symbol] [nvarchar](64) NOT NULL,
	[ImagePath] [nvarchar](2048) NULL,
	[IsPricingToken] [bit] NOT NULL,
	[PricingTokenAddress] [nvarchar](43) NULL,
	[PricingTokenPrice] [float] NULL,
	[PricingTokenPriceUpdateTime] [datetime] NULL,
	[PricingIsFixed] [bit] NULL,
 CONSTRAINT [PK_Token_1] PRIMARY KEY CLUSTERED 
(
	[ChainId] ASC,
	[Address] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransactionReceipt]    Script Date: 2023/8/20 20:48:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactionReceipt](
	[ChainId] [int] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TransactionHash] [nvarchar](66) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[UserMethod] [nvarchar](128) NOT NULL,
	[UserFrom] [nvarchar](43) NOT NULL,
	[UserRemark] [nvarchar](1024) NOT NULL,
	[TransactionIndex] [bigint] NULL,
	[GotReceipt] [bit] NOT NULL,
	[BlockHash] [nvarchar](66) NULL,
	[BlockNumber] [bigint] NULL,
	[CumulativeGasUsed] [bigint] NULL,
	[GasUsed] [bigint] NULL,
	[GasPrice] [float] NULL,
	[ContractAddress] [nvarchar](43) NULL,
	[Status] [bigint] NULL,
	[Logs] [nvarchar](max) NULL,
	[HasErrors] [bit] NULL,
	[ResultTime] [datetime] NULL,
	[Canceled] [bit] NULL,
 CONSTRAINT [PK_TransactionReceipt] PRIMARY KEY CLUSTERED 
(
	[ChainId] ASC,
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserTokenApprove]    Script Date: 2023/8/20 20:48:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTokenApprove](
	[ChainId] [int] NOT NULL,
	[TransactionHash] [nvarchar](66) NOT NULL,
	[UserAddress] [nvarchar](43) NOT NULL,
	[TokenAddress] [nvarchar](43) NOT NULL,
	[SpenderAddress] [nvarchar](43) NOT NULL,
	[TokenDecimals] [int] NULL,
	[TokenSymbol] [nvarchar](64) NULL,
	[CurrentAmount] [float] NULL,
	[IsDivToken] [bit] NULL,
	[DivTokenIsWithdrawable] [bit] NULL,
 CONSTRAINT [PK_UserTokenApprove] PRIMARY KEY CLUSTERED 
(
	[ChainId] ASC,
	[TokenAddress] ASC,
	[UserAddress] ASC,
	[SpenderAddress] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Web3Url]    Script Date: 2023/8/20 20:48:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Web3Url](
	[Layer] [int] NOT NULL,
	[UrlAlias] [nvarchar](64) NOT NULL,
	[UrlHash] [nvarchar](128) NOT NULL,
	[Url] [nvarchar](2000) NOT NULL,
	[IsSelected] [bit] NOT NULL,
 CONSTRAINT [PK_Web3Url] PRIMARY KEY CLUSTERED 
(
	[UrlHash] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BasicBusShareToken_NoticePublish] ADD  CONSTRAINT [DF_ShareToken_NoticePublish_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[DivShareTokenPair_DividendsDistributed] ADD  CONSTRAINT [DF_DivExPair_DividendsDistributed_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[DutchAuction_OnSell] ADD  CONSTRAINT [DF_DutchAuction_OnSell_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[DutchAuction_OnSell] ADD  CONSTRAINT [DF_DutchAuction_OnSell_IsDone]  DEFAULT ((0)) FOR [IsDone]
GO
ALTER TABLE [dbo].[KeyStore_Address] ADD  CONSTRAINT [DF_KeyStore_Address_IsTxAddress]  DEFAULT ((1)) FOR [IsTxAddress]
GO
ALTER TABLE [dbo].[KeyStore_Address] ADD  CONSTRAINT [DF_KeyStore_Address_HasPrivatekey]  DEFAULT ((1)) FOR [HasPrivatekey]
GO
ALTER TABLE [dbo].[T_Language] ADD  CONSTRAINT [DF_T_Language_IsSelected]  DEFAULT ((0)) FOR [IsSelected]
GO
ALTER TABLE [dbo].[T_Language] ADD  CONSTRAINT [DF_T_Language_ItemsNumber]  DEFAULT ((0)) FOR [ItemsNumber]
GO
ALTER TABLE [dbo].[Token] ADD  CONSTRAINT [DF_Token_IsPricingToken]  DEFAULT ((0)) FOR [IsPricingToken]
GO
ALTER TABLE [dbo].[Token] ADD  CONSTRAINT [DF_Token_PricingIsFixed]  DEFAULT ((0)) FOR [PricingIsFixed]
GO
ALTER TABLE [dbo].[TransactionReceipt] ADD  CONSTRAINT [DF_TransactionReceipt_HasReceipt]  DEFAULT ((0)) FOR [GotReceipt]
GO
ALTER TABLE [dbo].[UserTokenApprove] ADD  CONSTRAINT [DF_UserTokenApprove_Amount]  DEFAULT ((0)) FOR [CurrentAmount]
GO
ALTER TABLE [dbo].[UserTokenApprove] ADD  CONSTRAINT [DF_UserTokenApprove_IsDivToken]  DEFAULT ((0)) FOR [IsDivToken]
GO

