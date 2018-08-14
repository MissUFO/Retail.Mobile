SET IDENTITY_INSERT [auth].[Store] ON 

GO
INSERT [auth].[Store] ([Id], [StoreId], [Name], [Address], [CreatedOn], [ModifiedOn]) VALUES (1, 1, N'Adidas (Home of sport)', N'ул. Крылатская, д.15', CAST(N'2017-06-16T06:11:13.573' AS DateTime), CAST(N'2017-06-16T06:11:13.573' AS DateTime))
GO
SET IDENTITY_INSERT [auth].[Store] OFF
GO
SET IDENTITY_INSERT [auth].[User] ON 

GO
INSERT [auth].[User] ([Id], [UserName], [EmployeeId], [PhoneNumber], [StoreId], [Status], [CreatedOn], [ModifiedOn], [LastLoginOn]) VALUES (1, N'Петр Иванов', 575623, N'+79031222341', 1, 1, CAST(N'2017-06-16T06:13:10.307' AS DateTime), CAST(N'2017-06-16T06:13:10.307' AS DateTime), CAST(N'2017-06-18T17:54:30.600' AS DateTime))
GO
SET IDENTITY_INSERT [auth].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[Device] ON 

GO
INSERT [dbo].[Device] ([Id], [ImageUrl], [Name], [Model], [Description], [CreatedOn], [ModifiedOn]) VALUES (1, N'http://adidasretailarquickhelp.azurewebsites.net/Images/shtrih01.jpg', N'Фискальный регистратор', N'Штрих-М 01', N'<p><b>Что это?</b><br/>
Это принтер, который печатает чеки.</p>
<p>
<b>Где это найти?</b><br/>
В кассовой зоне.
</p>
<p>
<b>Для кого?</b><br/>
Для менеджеров, кассиров и специалистов по продажам.
</p>', CAST(N'2017-06-16T10:14:59.030' AS DateTime), CAST(N'2017-06-16T10:14:59.030' AS DateTime))
GO
INSERT [dbo].[Device] ([Id], [ImageUrl], [Name], [Model], [Description], [CreatedOn], [ModifiedOn]) VALUES (2, N'https://bit-kassa.ru//upload/iblock/5ca/5ca179ac1bfb399b45e070899b3379f5.jpg', N'Счётчик банкнот', N'PRO-40U NEO', N'<p><b>Что это?</b><br/>
Аппарат, который считает бумажные деньги.</p>
<p>
<b>Где это найти?</b><br/>
В кассовой зоне.
</p>
<p>
<b>Для кого?</b><br/>
Для менеджеров, кассиров и специалистов по продажам.
</p>', CAST(N'2017-06-18T18:40:12.330' AS DateTime), CAST(N'2017-06-18T18:40:12.330' AS DateTime))
GO
INSERT [dbo].[Device] ([Id], [ImageUrl], [Name], [Model], [Description], [CreatedOn], [ModifiedOn]) VALUES (3, N'https://bit-kassa.ru/upload/resize_cache/iblock/1f6/348_318_1/1f6f84bfcc36fa1c502d01fc82e736ed.jpeg', N'Принтер печати этикеток', N'Zebra GK420d', N'<p><b>Что это?</b><br/>
Аппарат, который печатает ценники для товаров.</p>
<p>
<b>Где это найти?</b><br/>
На складе.
</p>
<p>
<b>Для кого?</b><br/>
Для менеджеров и специалистов по продажам.
</p>', CAST(N'2017-06-18T18:44:22.690' AS DateTime), CAST(N'2017-06-18T18:44:22.690' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Device] OFF
GO
SET IDENTITY_INSERT [dbo].[Document] ON 

GO
INSERT [dbo].[Document] ([Id], [Title], [Description], [DocumentUrl], [DocumentType], [CreatedOn], [ModifiedOn]) VALUES (1, N'Как использовать?', N' ', N'http://adidasretailarquickhelp.azurewebsites.net/Images/shrtih01_howto.png', 1, CAST(N'2017-06-16T10:48:11.457' AS DateTime), CAST(N'2017-06-16T10:48:11.457' AS DateTime))
GO
INSERT [dbo].[Document] ([Id], [Title], [Description], [DocumentUrl], [DocumentType], [CreatedOn], [ModifiedOn]) VALUES (2, N'Видеоинструкция по подключению', N' ', N'https://www.youtube.com/watch?v=8y6WZoEQJ3I', 0, CAST(N'2017-06-16T10:51:37.407' AS DateTime), CAST(N'2017-06-16T10:51:37.407' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Document] OFF
GO
INSERT [enum].[DocumentType] ([Id], [Name]) VALUES (0, N'Document')
GO
INSERT [enum].[DocumentType] ([Id], [Name]) VALUES (1, N'Video')
GO
SET IDENTITY_INSERT [logs].[Error] ON 

GO
INSERT [logs].[Error] ([Id], [UserId], [ErrorCode], [ErrorMessage], [StackTrace], [CreatedOn], [ModifiedOn]) VALUES (1, NULL, 123, N'Test Error', N'Test Error Stack trace', CAST(N'2017-06-16T06:09:45.870' AS DateTime), CAST(N'2017-06-16T06:09:45.870' AS DateTime))
GO
SET IDENTITY_INSERT [logs].[Error] OFF
GO
SET IDENTITY_INSERT [map].[DeviceDocument] ON 

GO
INSERT [map].[DeviceDocument] ([Id], [DeviceId], [DocumentId]) VALUES (1, 1, 1)
GO
INSERT [map].[DeviceDocument] ([Id], [DeviceId], [DocumentId]) VALUES (2, 1, 2)
GO
SET IDENTITY_INSERT [map].[DeviceDocument] OFF
GO
SET IDENTITY_INSERT [map].[DeviceIssue] ON 

GO
INSERT [map].[DeviceIssue] ([Id], [DeviceId], [IssueId]) VALUES (1, 1, 1)
GO
INSERT [map].[DeviceIssue] ([Id], [DeviceId], [IssueId]) VALUES (2, 1, 2)
GO
INSERT [map].[DeviceIssue] ([Id], [DeviceId], [IssueId]) VALUES (3, 1, 4)
GO
SET IDENTITY_INSERT [map].[DeviceIssue] OFF
GO
SET IDENTITY_INSERT [map].[DeviceQrCode] ON 

GO
INSERT [map].[DeviceQrCode] ([Id], [QRCode], [DeviceId]) VALUES (2, N'0', 1)
GO
SET IDENTITY_INSERT [map].[DeviceQrCode] OFF

GO
INSERT [enum].[UsageLogActionType] ([Id], [Name]) VALUES (0, N'Просмотр')
GO
INSERT [enum].[UsageLogActionType] ([Id], [Name]) VALUES (1, N'Авторизация')
GO
INSERT [enum].[UsageLogActionType] ([Id], [Name]) VALUES (2, N'Выход')
GO
INSERT [enum].[UsageLogActionType] ([Id], [Name]) VALUES (3, N'Создание')
GO
INSERT [enum].[UsageLogActionType] ([Id], [Name]) VALUES (4, N'Поиск')
GO
INSERT [enum].[UsageLogActionType] ([Id], [Name]) VALUES (5, N'Сканирование')

GO
INSERT [enum].[DeviceType] ([Id], [Name]) VALUES (0, N'Торговое оборудование')
GO
INSERT [enum].[DeviceType] ([Id], [Name]) VALUES (1, N'Сетевое оборудование')
GO
INSERT [enum].[DeviceType] ([Id], [Name]) VALUES (2, N'Компьютерное оборудование')
GO
INSERT [enum].[DeviceType] ([Id], [Name]) VALUES (3, N'Видео оборудование')
GO

INSERT [conf].[AppSettings] ([Key], [Value]) VALUES (N'HELPDESK_EMAIL', N'mbx_123_cis@adidas-group.com')
GO
INSERT [conf].[AppSettings] ([Key], [Value]) VALUES (N'HELPDESK_EMAIL_SUBJ', N'myStore: новый запрос на поддержку')
GO
INSERT [conf].[AppSettings] ([Key], [Value]) VALUES (N'HELPDESK_PHONE', N'+78007752525')
GO
INSERT [conf].[AppSettings] ([Key], [Value]) VALUES (N'HELPDESK_URL', N'http://helpdesk-cis/')
GO
INSERT [conf].[AppSettings] ([Key], [Value]) VALUES (N'CREATORSHUB_LOGIN_URL', N'https://creatorshub.adidas.ru/public_api')
GO
INSERT [conf].[AppSettings] ([Key], [Value]) VALUES (N'CREATORSHUB_LOGIN_API_KEY', N'8bf61ef4bfd5be068223940e94ae0b51')
GO