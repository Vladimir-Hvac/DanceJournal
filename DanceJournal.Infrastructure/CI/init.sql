-- Вставка данных в порядке очереди
INSERT INTO "public"."Levels" ("Id", "Title", "Coefficient") VALUES (1, 'A', 1),(2, 'B', 2),(3, 'C', 3);
INSERT INTO "public"."Roles" ("Id", "Name") VALUES (1, 'Танцор'),(2, 'Тренер'),(3, 'Руководитель'),(4, 'Админ');
INSERT INTO "public"."Rooms" ("Id", "Name") VALUES (1, 'Бассеин'),(2, 'Октагон'),(3, 'Комната 1'),(4, 'Комната 2'),(5, 'Комната 3'),(6, 'Комната 4'),(7, 'Кабинет Директора');
INSERT INTO "public"."LessonTypes" ("Id", "Name", "Price", "Type") VALUES (1, 'Танго', 1000, 'Тип 1'),(2, 'Манго', 2000, 'Тип 2'),(3, 'Вальс', 1000, 'Тип 3'),(4, 'Грязные танцы', 99999, 'Тип 4');
INSERT INTO "public"."SubscriptionTypes" ("Id", "Name", "ContDay", "Price") VALUES (1, 'Еженедельная', 7, 999),(2, 'Ежемесячная', 31, 999),(3, 'Годовая', 365, 999);
INSERT INTO "public"."Subscriptions" ("Id","SubscriptionTypeId","StartDay","FinishDay") VALUES(1,1,'2021-10-01','2022-10-02'),(2,1,'2021-10-01','2022-10-02'),(3,1,'2021-11-01','2022-11-02');
INSERT INTO "public"."Users" ("Id","Surname","FirstName","SecondName","BirthDate","IsDeleted","Gender","Email","PhoneNumber","RoleId","SubscriptionId","LevelId","Salary")
VALUES (1,'Петров','Надя','Васильевич','2017-03-18',true,'man','CodeX@test.ru','88005553535',2,2,3,1.1),
(2,'Воробей','Надя','Александрович','2017-05-10',true,'man','DevZen@test.ru','88005553535',4,2,1,1.1),
(3,'Волков','Антон','Иванович','2017-09-24',true,'women','ProgM@test.ru','88005553535',4,2,2,1.1),
(4,'Сиденков','Женя','Александрович','2017-02-27',true,'man','ByteB@test.ru','88005553535',1,2,1,1.1),
(5,'Петров','Саша','Сергеевич','2017-10-06',true,'women','DataD@test.ru','88005553535',4,1,2,1.1),
(6,'Иванов','Женя','Александрович','2017-09-28',true,'man','LogicL@test.ru','88005553535',1,2,3,1.1),
(7,'Иванов','Геворг','Петрович','2017-07-31',true,'women','FlowF@test.ru','88005553535',1,1,2,1.1),
(8,'Сиденков','Геворг','Иванович','2017-03-03',true,'man','LoopL@test.ru','88005553535',2,3,3,1.1),
(9,'Воробей','Геворг','Иванович','2017-10-28',true,'man','MathM@test.ru','88005553535',4,3,1,1.1),
(10,'Огородник','Надя','Васильевич','2017-07-02',true,'women','NumN@test.ru','88005553535',1,3,3,1.1);

INSERT INTO "public"."Lessons" ("Id", "LessonTypeId", "UserId", "RoomId", "Date", "Start", "Finish", "LevelId") 
VALUES (1, 1, 10, 7, '2024-01-25 22:23:09', '2024-01-25 22:23:10', '2024-01-25 22:23:11', 1),
(2, 1, 9, 7, '2024-01-25 22:23:09', '2024-01-25 22:23:10', '2024-01-25 22:23:11', 1),
(3, 1, 8, 7, '2024-01-25 22:23:09', '2024-01-25 22:23:10', '2024-01-25 22:23:11', 1);
INSERT INTO "public"."LessonUsers" ("Id", "UserId", "LessonId", "IsVisit") VALUES (1, 6, 2, 'false'),
(2, 5, 2, 'true'),
(3, 4, 1, 'true'),
(4, 3, 1, 'false');
INSERT INTO "public"."Invitations" ("Id", "CreatorId", "LessonId", "IsSatisfied") VALUES (1, 6, 2, 'false'),
(2, 4, 2, 'true'),
(3, 3, 1, 'true'),
(4, 2, 1, 'false');
INSERT INTO "public"."Notifications" ("Id", "CreatorId", "Body") VALUES (1, 6, 'Hello'),
(2, 5, 'Its me'),
(3, 7, 'I am'),
(4, 8, 'Here');
INSERT INTO "public"."InvitationNotificationStatuses" ("Id", "InvitationId", "NotificationId", "ReceiverId", "IsRead", "IsAccepted") VALUES (1, 1, 1, 1, 'false', 'true'),
(2, 2, 2, 3, 'true', 'false'),
(3, 3, 3, 8, 'true', 'false'),
(4, 4, 3, 10, 'false', 'true');

-- А вот теперь обновляем аутоинкременты
SELECT setval('"Lessons_Id_seq"',10);
SELECT setval('"LessonTypes_Id_seq"',10);
SELECT setval('"LessonUsers_Id_seq"',10);
SELECT setval('"Levels_Id_seq"',10);
SELECT setval('"Roles_Id_seq"',10);
SELECT setval('"Rooms_Id_seq"',10);
SELECT setval('"Subscriptions_Id_seq"',10);
SELECT setval('"SubscriptionTypes_Id_seq"',10);
SELECT setval('"Users_Id_seq"',110);
SELECT setval('"Invitations_Id_seq"',10);
SELECT setval('"Notifications_Id_seq"',10);
SELECT setval('"InvitationNotificationStatuses_Id_seq"',10);
