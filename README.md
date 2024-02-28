# Service for storing schedules

### Требования к веб-сервису:
1. Необходимо создать ASP.NET Core Web API проект, который будет обеспечивать возможность взаимодействия с базой данных MS SQL Server.   
2. Реализовать сущности (модели) для работы с информацией о семестрах, неделях, предметах, типах аудиторий, кабинетах, преподавателях, группах, парах и расписаниях в соответствии с бизнес-логикой приложения.
3. Реализовать контроллеры для каждой сущности с методами, позволяющими выполнять CRUD операции (GET - чтение, POST - добавление, PUT - изменение, DELETE - удаление).
4. Добавить логику проверки перед удалением записи из базы данных, чтобы предотвратить удаление записи, если она уже используется в других таблицах (связь по внешнему ключу).
5. Реализовать возможность обработки и возврата ошибок в формате JSON для обеспечения хорошего опыта пользователя.
6. Протестировать всю функциональность API.

<details><summary><b>Структура БД (MS SQL):</b></summary>

- Таблица `Subjects`:
  - ID,
  - SubjectName,
  - LectureHours,
  - PracticHours,
  - TotalHours,
  - ConsultationHours,
  - TypeOfCertification.

- Таблица `Teachers`:
  - ID,
  - Name,
  - Surname,
  - Patronymic.

- Таблица `Groups`:
  - ID,
  - GroupNumber, //код группы
  - ShortNumber, //короткое наименование группы
  - StudentNumber.

- Таблица `AudienceTypes`:
  - ID,
  - TypeName,
  - Description.

- Таблица `Audiences`:
  - ID,
  - AudienceTypeID,
  - SeatsNumber, //количество мест
  - StudentNumber, //количество студентов
  - AudienceNumber.

- Таблица `Semesters`:
  - ID,
  - Year,
  - IsEven. //имеется ввиду 1 или 2 семестр

- Таблица `Weeks`:
  - ID,
  - SemesterID,
  - WeekNumber.

- Таблица `Users`:
  - UserID,
  - UserName,
  - Password,
  - Email.

- Таблица `Pairs`:
  - PairID,
  - AudienceID,
  - GroupID,
  - SubjectID,
  - TeacherID.

- Таблица `Days`:
  - ID,
  - DayOfWeek,
  - WeekID,
  - FirstPairID, //ID 1 пары
  - SecondPairID, //ID 2 пары
  - ThirdPairID, //ID 3 пары
  - FourthPairID, //ID 4 пары
  - FifthPairID, //ID 5 пары
  - SixthPairID, //ID 6 пары
  - SeventhPairID. //ID 7 пары

</details>

Описание
-
Данный веб-сервис разработан на ASP.NET Core Web API и обеспечивает взаимодействие с базой данных MS SQL Server для выполнения CRUD операций с использованием HTTP запросов. API предназначен для хранения данных, необходимых для составления расписания.

### CRUD операции, поддерживаемые веб-сервисом:
- GET: Получение данных (например, список всех записей или конкретной записи по идентификатору).
- POST: Создание новой записи.
- PUT: Обновление существующей записи.
- DELETE: Удаление записи по идентификатору.

**Особенности API** - При попытке удаления элемента API проверяет, связан ли данный элемент с другими таблицами. Если элемент уже используется в другой таблице, API возвращает ошибку и не позволяет удалить запись, чтобы избежать нарушения целостности данных.

Таким образом, этот RESTful API обеспечивает безопасное взаимодействие с данными, предотвращая нецелевые действия при попытке удаления элементов, которые имеют зависимости в других таблицах.

<details><summary><b>Методы HTTP данного API</b></summary>

**Семестры:**
- GET: /api/Semesters | /api/Semesters/{id}
- POST: /api/Semesters
- PUT: /api/Semesters/{id}
- DELETE: /api/Semesters/{id}

**Недели:**
- GET: /api/Weeks | /api/Weeks/{id}
- POST: /api/Weeks
- PUT: /api/Weeks/{id}
- DELETE: /api/Weeks/{id}

**Пользователи:**
- GET: /api/Users | /api/Users/{id}
- POST: /api/Users
- PUT: /api/Users/{id}
- DELETE: /api/Users/{id}

**Преподаватели:**
- GET: /api/Teachers | /api/Teachers/{id}
- POST: /api/Teachers
- PUT: /api/Teachers/{id}
- DELETE: /api/Teachers/{id}

**Предметы:**
- GET: /api/Subjects | /api/Subjects/{id}
- POST: /api/Subjects
- PUT: /api/Subjects/{id}
- DELETE: /api/Subjects/{id}

**Группы:**
- GET: /api/Groups | /api/Groups/{id}
- POST: /api/Groups
- PUT: /api/Groups/{id}
- DELETE: /api/Groups/{id}

**Типы аудиторий:**
- GET: /api/AudienceTypes | /api/AudienceTypes/{id}
- POST: /api/AudienceTypes
- PUT: /api/AudienceTypes/{id}
- DELETE: /api/AudienceTypes/{id}

**Аудитории:**
- GET: /api/Audiences | /api/Audiences/{id}
- POST: /api/Audiences
- PUT: /api/Audiences/{id}
- DELETE: /api/Audiences/{id}

**Пары:**
- GET: /api/Pairs | /api/Pairs/{id}
- POST: /api/Pairs
- PUT: /api/Pairs/{id}
- DELETE: /api/Pairs/{id}

**Расписания:**
- GET: /api/Days | /api/Days/{id}
- POST: /api/Days
- PUT: /api/Days/{id}
- DELETE: /api/Days/{id}

</details>  

**Формат данных - JSON**

<details><summary><b>Коды состояния HTTP этого веб-сервиса:</b></summary>

- 200 OK - запрос успешно выполнен.
- 204 No Content - для этого запроса нет содержимого для отправки.
- 400 Bad Request - возникает, когда вы пытаетесь изменить данные с использованием идентификатора, которого нет в базе данных, или когда запись, которую вы пытаетесь удалить, уже связана с другой таблицей.
- 404 Not Found - означает, что запрошенный идентификатор для удаления не найден в базе данных или данные вообще отсутствуют.

</details>

<details><summary><b>Тесты</b></summary>

### Чек-листы для тестирования функциональности CRUD:
#### Создание (Create):
1. [X] Отправить POST запрос для создания новой записи.
2. [X] Проверить статус код ответа. //200
3. [X] Проверить наличие созданной записи в базе данных.

#### Чтение (Read):
1. [X] Отправить GET запрос для получения списка записей.
2. [X] Проверить статус код ответа. //200
3. [X] Проверить формат и содержание возвращаемых данных.
4. [X] Отправить GET запрос для получения конкретной записи.
5. [X] Проверить статус код ответа для запроса конкретной записи. //200
6. [X] Проверить содержание возвращаемых данных для конкретной записи.

#### Обновление (Update):
1. [X] Отправить PUT запрос для обновления существующей записи.
2. [X] Проверить статус код ответа. //204
3. [X] Проверить обновленную запись в базе данных.

#### Удаление (Delete):
1. [X] Попытаться удалить запись, не используемую в другой таблице.
2. [X] Проверить статус код ответа для удаления записи без зависимостей. //200
3. [X] Убедиться, что запись удалена.
4. [X] Попытаться удалить запись, используемую в другой таблице.
5. [X] Проверить статус код ответа для удаления записи с зависимостями. //400 this record is used as a foreign key in other entities
6. [X] Убедиться, что запись осталась нетронутой в базе данных.

### Чек-лист для обработки ошибочных сценариев:

#### Обработка ошибок:
1. [ ] Проверить обработку ошибок при отправке неверного запроса.
2. [X] Проверить обработку ошибок при попытке доступа к несуществующей записи. //404
3. [X] Проверить обработку ошибок при попытке выполнить действие, нарушающее правила таблиц в базе данных. //400 this record is used as a foreign key in other entities

</details>

### Для работы были использованы следующие библиотеки и фреймворки:
- AutoMapper: для упрощения процесса маппинга между сущностями базы данных и DTO объектами.
- Microsoft.EntityFrameworkCore: для работы с базой данных.
- Microsoft.EntityFrameworkCore.SqlServer: предоставляет поддержку для работы с MS SQL Server.
- Microsoft.EntityFrameworkCore.Tools: для использования инструментов Entity Framework Core, таких как миграции и т.д.

[API for Mobile](https://github.com/FredNekrasov/service_for_storing_schedules/tree/ForMobile) может выполнять только GET запросы для передачи данных мобильному клиенту и при этом имеет схожую структуру. Данный веб-сервис используется в следующих приложениях [Windows scheduling app](https://github.com/FredNekrasov/A_scheduling_desktop_application), [Android schedule app](https://github.com/FredNekrasov/Android-app-for-viewing-schedules)
